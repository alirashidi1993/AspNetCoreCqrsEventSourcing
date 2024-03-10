using Framework.Domain;
using Framework.Persistence.ES.Mappings.Builders;
using Framework.Persistence.ES.Mappings.Filters;

namespace Framework.Persistence.ES.Mappings.Schemas
{
    public interface ISchemaMapping
    {
        IFilter CreateFilter();
        

    }
    public abstract class SchemaMapping<T> : ISchemaMapping where T : DomainEvent
    {
        public IFilter CreateFilter()
        {
            FilterBuilder builder = CreateFilterBuilder();
            Configure(builder);
            return builder.Build();
        }

        protected abstract void Configure(FilterBuilder builder);

        

        private FilterBuilder CreateFilterBuilder()
        {
            return new FilterBuilder();
        }


    }
}
