using System;
using System.Xml;
using Newtonsoft.Json;

namespace Branch.Helpers.Converters
{
	public class Iso8601Converter : JsonConverter
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
			string timespan = reader.Value.ToString();
			return XmlConvert.ToTimeSpan(timespan);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			string timespan;
			if (value is TimeSpan)
				timespan = XmlConvert.ToString((TimeSpan)value);
			else
				throw new Exception("Expected timespan object value.");

			writer.WriteValue(timespan);
		}
	}
}
