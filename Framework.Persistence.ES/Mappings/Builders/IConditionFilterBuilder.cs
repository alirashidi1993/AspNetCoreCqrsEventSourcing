namespace Framework.Persistence.ES.Mappings.Builders
{
    public interface IConditionFilterBuilder : IFilterBuilder
    {
        IOperationFilterBuilder WhenAbsent(string propertyName);
    }
}
