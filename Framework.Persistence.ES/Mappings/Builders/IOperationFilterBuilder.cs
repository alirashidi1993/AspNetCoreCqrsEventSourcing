namespace Framework.Persistence.ES.Mappings.Builders
{
    public interface IOperationFilterBuilder
    {
        IConditionFilterBuilder ThrowError(string errorMessage);
        IConditionFilterBuilder SetDefaultValue(string value);
        IConditionFilterBuilder CreateFromProperty(string propertyName);
    }
}
