using Newtonsoft.Json.Linq;

namespace Framework.Persistence.ES.Mappings.Operations
{
    public interface IOperation
    {
        JObject Apply(JObject json);
    }
}
