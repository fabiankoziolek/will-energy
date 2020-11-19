using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using WillEnergy.Domain.Common.RichObjects;

namespace WillEnergy.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
            ApplyMappingsForStronglyTypedId();
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping")
                                 ?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }

        private void ApplyMappingsForStronglyTypedId()
        {
            CreateMap<IntTypedId, int>().ConvertUsing(r => r.Value);
            CreateMap<GuidTypedId, Guid>().ConvertUsing(r => r.Value);
        }
    }
}
