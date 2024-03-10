using Framework.Persistence.ES.Mappings.Conditions;
using Framework.Persistence.ES.Mappings.Operations;
using Newtonsoft.Json.Linq;

namespace Framework.Persistence.ES.Mappings.Filters
{
    internal class Filter : IFilter
    {
        private readonly ICondition condition;
        private readonly IOperation operation;
        private IFilter nextFilter;

        public Filter(ICondition condition, IOperation operation)
        {
            this.condition = condition;
            this.operation = operation;
            nextFilter = EndFilter.Instance;
        }

        public void SetNextFilter(IFilter nextFilter)
        {
            this.nextFilter = nextFilter;
        }

        public JObject Apply(JObject json)
        {
            if (condition.IsSatisfied(json))
            {
                json = operation.Apply(json);
            }
            return nextFilter.Apply(json);
        }
    }
}
