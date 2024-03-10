using Newtonsoft.Json.Linq;

namespace Framework.Persistence.ES.Mappings.Operations
{
    public class FillFromAnotherPropertyOperation : IOperation
    {
        private readonly string absentKey;
        private readonly string keyToFillFrom;

        public FillFromAnotherPropertyOperation(string absentKey, string keyToFillFrom)
        {
            this.absentKey = absentKey;
            this.keyToFillFrom = keyToFillFrom;
        }
        public JObject Apply(JObject json)
        {
            json[absentKey] = json[keyToFillFrom];
            json.Remove(keyToFillFrom);
            return json;
        }
    }
}
