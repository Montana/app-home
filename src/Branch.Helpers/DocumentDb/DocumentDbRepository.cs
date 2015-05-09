using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Branch.Helpers.Configuration;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Framework.ConfigurationModel;

namespace Branch.Helpers.DocumentDb
{
	public class DocumentDbRepository
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="configuration"></param>
		public DocumentDbRepository(IConfiguration configuration)
		{
			var endpoint = configuration.Get("DocumentDb:Endpoint");
			var accessKey = configuration.Get("DocumentDb:AccessKey");
			var databaseId = configuration.Get("DocumentDb:DatabaseId");
			var collectionId = configuration.Get("DocumentDb:CollectionId");

			_client = new DocumentClient(new Uri(endpoint), accessKey, connectionPolicy: new ConnectionPolicy
			{
				//UserAgentSuffix = "Branch-vNext/1.0.0",
				ConnectionMode = ConnectionMode.Direct,
				MediaReadMode = MediaReadMode.Buffered,
				ConnectionProtocol = Protocol.Https
			});
			_database = GetOrCreateDatabase(databaseId);
			_collection = GetOrCreateCollection(_database.SelfLink, collectionId);
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
		private DocumentClient _client { get; set; }

		public T Get<T>(Expression<Func<T, bool>> predicate)
			where T : Document
		{
			return _client.CreateDocumentQuery<T>(_collection.SelfLink)
						.Where(predicate)
						.AsEnumerable()
						.FirstOrDefault();
		}

		public T GetById<T>(string id)
			where T : Document
		{
			var doc = _client.CreateDocumentQuery<T>(_collection.SelfLink)
				.Where(d => d.Id == id)
				.AsEnumerable()
				.FirstOrDefault();

			return doc;
		}

		public IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate)
			where T : Document
		{
			var ret = _client.CreateDocumentQuery<T>(_collection.SelfLink)
				.Where(predicate)
				.AsEnumerable();

			return ret;
		}

		public async Task<T> CreateAsync<T>(T entity)
			where T : Document
		{
			Document doc = await _client.CreateDocumentAsync(_collection.SelfLink, entity);
			return (T)(dynamic)doc;
		}

		public async Task<T> UpdateAsync<T>(string id, T entity)
			where T : Document
		{
			var doc = GetById<T>(id);
			return (T)(dynamic)await _client.ReplaceDocumentAsync(doc.SelfLink, entity);
		}

		public async Task DeleteAsync<T>(string id)
			where T : Document
		{
			var doc = GetById<T>(id);
			await _client.DeleteDocumentAsync(doc.SelfLink);
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
					new DocumentCollection { Id = collectionId },
					new RequestOptions { OfferType = "S1" }).Result;
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