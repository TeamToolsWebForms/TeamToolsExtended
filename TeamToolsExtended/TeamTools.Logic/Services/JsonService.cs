using Newtonsoft.Json;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Services
{
    public class JsonService : IJsonService
    {
        public string GetAsJson(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
