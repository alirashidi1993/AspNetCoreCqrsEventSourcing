using Framework.Persistence.ES.Mappings.Filters;

namespace Framework.Persistence.ES.Mappings.Builders
{
    public interface IFilterBuilder
    {
        IFilter Build();
    }
}
