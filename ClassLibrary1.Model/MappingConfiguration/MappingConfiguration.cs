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

            CreateMap<ClientSaleTransaction, SaleTransaction>().ForMember(dst => dst.Id, opt => opt.Ignore());

            CreateMap<ClientPayment, Payment>().ForMember(dst => dst.Id, opt => opt.Ignore());

            CreateMap<ClientSaleItems, SaleItems>().ForMember(dst => dst.Id, opt => opt.Ignore());

            CreateMap<ClientSaleTransactionDetails, SaleTransactionDetails>().ForMember(dst => dst.Id, opt => opt.Ignore());
        }
    }
}
