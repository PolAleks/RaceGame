using Newtonsoft.Json;

namespace Race.Services
{
    public class JsonConverter : IConvert
    {
        public string Serialize<T>(T value)
        {
            return JsonConvert.SerializeObject(value, Formatting.Indented);
        }

        public T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
