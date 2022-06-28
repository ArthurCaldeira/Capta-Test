using AutoMapper;
using Capta_Teste.Customer.Api.Data.ValueObject;

namespace Capta_Teste.Customer.Api.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CustomerVO, Model.Customer>();
                config.CreateMap<CustomerStatusVO, Model.CustomerStatus>();
                config.CreateMap<CustomerTypeVO, Model.CustomerType>();

                config.CreateMap<Model.Customer, CustomerVO>();
                config.CreateMap<Model.CustomerStatus, CustomerStatusVO>();
                config.CreateMap<Model.CustomerType, CustomerTypeVO>();
            });

            return mappingConfig;
        }
    }
}