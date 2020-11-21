using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using RestSharp.Serializers;

namespace WillEnergy.Infrastructure.Client
{
    public class NewtonsoftJsonSerializer : ISerializer
    {
                public const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";

        private readonly JsonSerializer _jsonSerializer;

        public NewtonsoftJsonSerializer()
        {
            _jsonSerializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = DateTimeFormat,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc

            };

            _jsonSerializer.Converters.Add(new StringEnumConverter());
        }

        public NewtonsoftJsonSerializer(DateTimeZoneHandling dateTimeZoneHandling)
        {
            _jsonSerializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = DateTimeFormat,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = dateTimeZoneHandling,
            };

            _jsonSerializer.Converters.Add(new StringEnumConverter());
        }

        public string ContentType
        {
            get { return "application/json"; }
            set { }
        }

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    _jsonSerializer.Serialize(jsonTextWriter, obj);
                    var result = stringWriter.ToString();
                    return result;
                }
            }
        }

        public T Deserialize<T>(IRestResponse response)
        {
            var content = response.Content;

            using (var stringReader = new StringReader(content))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {
                    return _jsonSerializer.Deserialize<T>(jsonTextReader);
                }
            }
        }

    }
}
