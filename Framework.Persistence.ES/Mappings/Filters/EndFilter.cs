using Newtonsoft.Json.Linq;

namespace Framework.Persistence.ES.Mappings.Filters
{
    internal class EndFilter : IFilter
    {
        internal static EndFilter Instance;

        private EndFilter() { }

        static EndFilter()
        {
            Instance = new EndFilter();
        }

        public JObject Apply(JObject json)
        {
            return json;
        }

        public void SetNextFilter(IFilter nextFilter)
        {
            throw new NotSupportedException("Can't set next filter in end filter");
        }
    }
}
