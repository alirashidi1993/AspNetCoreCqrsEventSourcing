using Newtonsoft.Json.Linq;

namespace Framework.Persistence.ES.Mappings.Filters
{
    public interface IFilter
    {
        void SetNextFilter(IFilter nextFilter);
        JObject Apply(JObject json);
    }
}
