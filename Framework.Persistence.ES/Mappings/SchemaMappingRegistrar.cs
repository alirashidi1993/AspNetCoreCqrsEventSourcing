using Framework.Persistence.ES.Mappings.Filters;
using Framework.Persistence.ES.Mappings.Schemas;
using System.Reflection;

namespace Framework.Persistence.ES.Mappings
{
    public static class SchemaMappingRegistrar
    {

        private static Dictionary<Type, IFilter> filters = new Dictionary<Type, IFilter>();

        public static void RegisterMappingsInAssembly(Assembly assembly)
        {

            filters = assembly.GetTypes()
                .Where(t => t.BaseType == typeof(SchemaMapping<>))
                .Select(Activator.CreateInstance)
                .OfType<ISchemaMapping>()
                .ToDictionary(a => a.GetType().GetGenericTypeDefinition(), a => a.CreateFilter());

        }
        public static IFilter GetFilterForType(Type type)
        {
            if (filters.ContainsKey(type)) return filters[type];
            return null;
        }
    }
}
