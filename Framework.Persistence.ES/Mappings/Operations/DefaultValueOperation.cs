using Newtonsoft.Json.Linq;

namespace Framework.Persistence.ES.Mappings.Operations
{
    public class DefaultValueOperation : IOperation
    {
        private readonly string key;
        private readonly string value;

        public DefaultValueOperation(string key, string value)
        {
            this.key = key;
            this.value = value;
        }

        public JObject Apply(JObject json)
        {
            json[key] = value;
            return json;
        }
    }
}
