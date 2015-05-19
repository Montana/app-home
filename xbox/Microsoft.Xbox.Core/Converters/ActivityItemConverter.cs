using System;
using System.Collections.Generic;
using Microsoft.Xbox.Core.DataContracts;
using Microsoft.Xbox.Core.DataContracts.Abstracts;
using Microsoft.Xbox.Core.DataContracts.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Xbox.Core.Converters
{
	public class ActivityItemConverter
		: JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return true;
		}

		public override bool CanWrite
		{
			get { return false; }
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var x = new List<ActivityItem>();
			while (true)
			{
				reader.Read();

				if (reader.TokenType == JsonToken.EndArray)
					break;

				var k = (JObject)serializer.Deserialize(reader);
				switch ((ActivityItemType)Enum.Parse(typeof(ActivityItemType), ((JValue)k["activityItemType"]).Value.ToString()))
				{
					case ActivityItemType.Achievement:
						x.Add(k.ToObject<AchievementActivityItem>());
						break;

					case ActivityItemType.GameDVR:
						x.Add(k.ToObject<GameDvrActivityItem>());
						break;

					case ActivityItemType.Played:
						x.Add(k.ToObject<PlayedActivityItem>());
						break;

					case ActivityItemType.Screenshot:
						x.Add(k.ToObject<ScreenshotActivityItem>());
						break;

					case ActivityItemType.TextPost:
						x.Add(k.ToObject<TextPostActivityItem>());
						break;

					default:
						throw new IndexOutOfRangeException();
				}
			}

			return x;
		}
		
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}
