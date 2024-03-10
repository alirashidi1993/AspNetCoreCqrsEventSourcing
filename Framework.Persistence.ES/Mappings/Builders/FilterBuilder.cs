using Framework.Persistence.ES.Mappings.Conditions;
using Framework.Persistence.ES.Mappings.Filters;
using Framework.Persistence.ES.Mappings.Operations;

namespace Framework.Persistence.ES.Mappings.Builders
{
    public class FilterBuilder : IConditionFilterBuilder, IOperationFilterBuilder
    {
        private List<Filter> filters = new List<Filter>();
        private ICondition currentCondition;

        public IFilter Build()
        {
            if (!filters.Any()) return EndFilter.Instance;

            filters.Aggregate((a, b) =>
            {
                a.SetNextFilter(b);
                return b;
            });
            return filters.First();
        }

        public IConditionFilterBuilder CreateFromProperty(string propertyName)
        {
            var op = new FillFromAnotherPropertyOperation(currentCondition.PropertyName, propertyName);
            return AddFilter(op);
        }

        public IConditionFilterBuilder SetDefaultValue(string value)
        {
            var op = new DefaultValueOperation(currentCondition.PropertyName, value);
            return AddFilter(op);
        }

        public IConditionFilterBuilder ThrowError(string errorMessage)
        {
            var op = new ErrorOperation(errorMessage);
            return AddFilter(op);
        }

        public IOperationFilterBuilder WhenAbsent(string propertyName)
        {
            currentCondition = new AbsentCondition(propertyName);
            return this;
        }

        private IConditionFilterBuilder AddFilter(IOperation op)
        {
            var filter = new Filter(currentCondition, op);
            filters.Add(filter);
            return this;
        }
    }
}
