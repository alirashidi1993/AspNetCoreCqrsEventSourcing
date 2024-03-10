using Newtonsoft.Json.Linq;

namespace Framework.Persistence.ES.Mappings.Operations
{
    public class ErrorOperation : IOperation
    {
        private readonly string errorText;

        public ErrorOperation(string errorText)
        {
            this.errorText = errorText;
        }
        public JObject Apply(JObject json)
        {
            throw new EventMappingException(errorText);
        }
    }
}
