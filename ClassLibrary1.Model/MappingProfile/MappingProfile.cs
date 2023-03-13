using AutoMapper;
using ClassLibrary1.Core;
using Microsoft.IdentityModel.Tokens;

namespace ClassLibrary1.Model
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<ClientCompany, Company>()
                .ForMember(
                    d => d.Id,
                    map => map.Ignore()
                );

            CreateMap<ClientTenant, Tenant>()
                .ForMember(
                    d => d.Id,
                    map => map.Ignore()
                );
        }
    }
}
