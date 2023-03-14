using AutoMapper;
using ClassLibrary1.Core;

namespace ClassLibrary1.Model
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration() 
        {
            CreateMap<ClientCompany, Company>().ForMember(dst => dst.Id, opt => opt.Ignore());

            CreateMap<ClientTenant, Tenant>().ForMember(dst => dst.Id, opt => opt.Ignore());

            CreateMap<ClientDataGateway, SaleRequest>().ForMember(dst => dst.Id, opt => opt.Ignore());
        }
    }
}
