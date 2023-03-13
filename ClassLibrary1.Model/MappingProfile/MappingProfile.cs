using AutoMapper;
using ClassLibrary1.Core;
using Microsoft.IdentityModel.Tokens;

namespace ClassLibrary1.Model
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //CreateMap<ClientCompany, Company>()
            //    .ForMember(
            //        d => d.Id,
            //        opt => opt.MapFrom(s => string.IsNullOrEmpty(Guid.Equals(s.Id, s.Id)) ? Guid.NewGuid() : s.Id)
            //    );
            CreateMap<ClientCompany, Company>();
            CreateMap<ClientTenant, Tenant>().ForMember(d => d.Id, opt => opt.MapFrom(s => Guid.NewGuid()));
        }
    }
}
