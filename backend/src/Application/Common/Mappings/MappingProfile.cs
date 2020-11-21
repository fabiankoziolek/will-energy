using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using WillEnergy.Application.Measurements.Dto;
using WillEnergy.Domain.Common.RichObjects;
using WillEnergy.Domain.Core.Measurements;

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
            CreateMap<Measurement, MeasurementDto>()
                .ForMember(dest =>dest.CurrentColourPm10, opt => opt.MapFrom(src => src.CurrentSubjectiveColourPm10))
                .ForMember(dest =>dest.CurrentColourPm25, opt => opt.MapFrom(src => src.CurrentSubjectiveColourPm25))
                .ForMember(dest =>dest.CurrentValuePm10, opt => opt.MapFrom(src => src.CurrentSubjectiveValuePm10))
                .ForMember(dest =>dest.CurrentValuePm25, opt => opt.MapFrom(src => src.CurrentSubjectiveValuePm25))
                .ForMember(dest =>dest.ForecastedColourPm10, opt => opt.MapFrom(src => src.ForecastedSubjectiveColourPm10))
                .ForMember(dest =>dest.ForecastedColourPm25, opt => opt.MapFrom(src => src.ForecastedSubjectiveColourPm25))
                .ForMember(dest =>dest.ForecastedValuePm10, opt => opt.MapFrom(src => src.ForecastedSubjectiveValuePm10))
                .ForMember(dest =>dest.ForecastedValuePm25, opt => opt.MapFrom(src => src.ForecastedSubjectiveValuePm25))
                .ForMember(dest =>dest.CurrentOrderNumberPm10, opt => opt.MapFrom(src => src.CurrentSubjectiveOrderNumberPm10))
                .ForMember(dest =>dest.CurrentOrderNumberPm25, opt => opt.MapFrom(src => src.CurrentSubjectiveOrderNumberPm25))
                .ForMember(dest =>dest.ForecastedOrderNumberPm10, opt => opt.MapFrom(src => src.ForecastedSubjectiveOrderNumberPm10))
                .ForMember(dest =>dest.ForecastedOrderNumberPm25, opt => opt.MapFrom(src => src.ForecastedSubjectiveOrderNumberPm25))
                .ForMember(dest =>dest.Temperatura, opt => opt.MapFrom(src => src.TEMPERATURA))
                .ForMember(dest =>dest.Predkosc, opt => opt.MapFrom(src => src.PREDKOSC))
                .ForMember(dest =>dest.DataGodzina, opt => opt.MapFrom(src => src.DATA_GODZINA))
                .ForMember(dest =>dest.PredkoscMax, opt => opt.MapFrom(src => src.PREDKOSC_MAX));
        }
    }
}
