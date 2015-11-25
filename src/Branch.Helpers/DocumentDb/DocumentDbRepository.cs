using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.Azure.Documents.Client.TransientFaultHandling.Strategies;
using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
using Microsoft.Azure.Documents.Client.TransientFaultHandling;

namespace Branch.Helpers.DocumentDb
{
	public class DocumentDbRepository
	{
		/// <summary>
		/// Creates a new DocumentDb Repository
		/// </summary>
		/// <param name="configuration"></param>
		/// <param name="baseKey"></param>
		public DocumentDbRepository(IConfiguration configuration, string baseKey)
		{
			var endpoint = configuration.Get<string>($"{baseKey}:DocumentDb:Endpoint");
			var accessKey = configuration.Get<string>($"{baseKey}:DocumentDb:AccessKey");
			var databaseId = configuration.Get<string>($"{baseKey}:DocumentDb:DatabaseId");
			var collectionId = configuration.Get<string>($"{baseKey}:DocumentDb:CollectionId");

			var documentClient = new DocumentClient(new Uri(endpoint), accessKey, connectionPolicy: new ConnectionPolicy
			{
				//UserAgentSuffix = "Branch-vNext/1.0.0",
				ConnectionMode = ConnectionMode.Direct,
				MediaReadMode = MediaReadMode.Buffered,
				ConnectionProtocol = Protocol.Https
			});
			var documentRetryStrategy = new DocumentDbRetryStrategy(RetryStrategy.DefaultExponential) { FastFirstRetry = true };
			_client = documentClient.AsReliable(documentRetryStrategy);
			_database = GetOrCreateDatabase(databaseId);
			_collection = GetOrCreateCollection(_database.SelfLink, collectionId);
		}
		
		static DocumentDbRepository()
		{
			JsonConvert.DefaultSettings = () =>
			{
				return new JsonSerializerSettings
				{
					TypeNameHandling = TypeNameHandling.Auto
				};
			};
		}
		
		/// <summary>
		/// 
		/// </summary>
		private Microsoft.Azure.Documents.Database _database { get; set; }

		/// <summary>
		/// 
		/// </summary>
		private DocumentCollection _collection { get; set; }

		/// <summary>
		/// 
		/// </summary>
		private IReliableReadWriteDocumentClient _client { get; set; }

		public T Get<T>(Expression<Func<T, bool>> predicate)
			where T : Document
		{
			return _client.CreateDocumentQuery<T>(_collection.SelfLink)
						.Where(predicate)
						.AsEnumerable()
						.FirstOrDefault();
		}

		public Document Exists(string id)
		{
			return _client.CreateDocumentQuery(_collection.SelfLink)
				.Where(d => d.Id == id)
				.AsEnumerable()
				.FirstOrDefault();
		}

		public T GetById<T>(string id)
			where T : Document
		{
			Document doc = _client.CreateDocumentQuery<Document>(_collection.SelfLink)
				.Where(d => d.Id == id)
				.AsEnumerable()
				.FirstOrDefault();
				
			if (doc == null)
				return null;

			var x = DeserializeObject<T>(doc.ToString());
			return x;
		}

		public IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate)
			where T : Document
		{
			return _client.CreateDocumentQuery<T>(_collection.SelfLink)
				.Where(predicate)
				.AsEnumerable()
				.Select(doc => DeserializeObject<T>(doc.ToString()));
		}

		public async Task<T> CreateAsync<T>(T entity)
			where T : Document
		{
			using (var stream = await GetStreamFromObjectAsync(entity))
			{
				Document doc = await _client.CreateDocumentAsync(_collection.SelfLink, Document.LoadFrom<Document>(stream));
				return (T)(dynamic)doc;
			}
		}

		public async Task<T> UpdateAsync<T>(string id, T entity)
			where T : Document
		{
			var doc = Exists(id);
			if (doc != null)
			{
				entity.Id = id;
				using (var stream = await GetStreamFromObjectAsync(entity))
				{
					Document updatedDocumet = await _client.ReplaceDocumentAsync(doc.SelfLink, JsonSerializable.LoadFrom<Document>(stream));
					return (T)(dynamic)updatedDocumet;
				}
			}
			else
			{
				return await CreateAsync<T>(entity);
			}
		}

		public async Task DeleteAsync<T>(string id)
			where T : Document
		{
			var doc = GetById<T>(id);
			await _client.DeleteDocumentAsync(doc.SelfLink);
		}

		private async Task<Stream> GetStreamFromObjectAsync<T>(T @object)
		{
			var str = SerializeObject(@object);
			var stream = new MemoryStream();
			var writer = new StreamWriter(stream);
			await writer.WriteAsync(str);
			await writer.FlushAsync();
			stream.Position = 0;
			return stream;
		}

		private async Task<T> GetObjectFromStreamAsync<T>(Stream stream)
		{
			using (var reader = new StreamReader(stream))
			{
				var str = await reader.ReadToEndAsync();
				return DeserializeObject<T>(str);
			}
		}

		private string SerializeObject<T>(T @object)
		{
			return JsonConvert.SerializeObject(@object, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
		}

		private T DeserializeObject<T>(string str)
		{
			var x = JsonConvert.DeserializeObject<T>(str, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
			return x;
		}

		private DocumentCollection GetOrCreateCollection(string databaseLink, string collectionId)
		{
			var col = _client.CreateDocumentCollectionQuery(databaseLink)
							  .Where(c => c.Id == collectionId)
							  .AsEnumerable()
							  .FirstOrDefault();

			if (col == null)
			{
				col = _client.CreateDocumentCollectionAsync(databaseLink,
					new DocumentCollection { Id = collectionId }).Result;
			}

			return col;
		}

		private Microsoft.Azure.Documents.Database GetOrCreateDatabase(string databaseId)
		{
			var db = _client.CreateDatabaseQuery()
							.Where(d => d.Id == databaseId)
							.AsEnumerable()
							.FirstOrDefault();

			if (db == null)
			{
				db = _client.CreateDatabaseAsync(new Microsoft.Azure.Documents.Database { Id = databaseId }).Result;
			}

			return db;
		}
	}
}