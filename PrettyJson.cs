using System.Text.Json;

namespace CP380_B1_BlockList
{
    public static class PrettyJson
    {
        public static string MakePretty(string unPrettyJson)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            var jsonElement = JsonSerializer.Deserialize<JsonElement>(unPrettyJson);

            return JsonSerializer.Serialize(jsonElement, options);
        }
    }

}
