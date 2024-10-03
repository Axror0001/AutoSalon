using AutoSalon.DTO.CompanyDTO.ChevroletCompanyDto;
using AutoSalon.DTO.CompanyDTO.MersCompanyDto;
using AutoSalon.Models.Companys.Chevrolet;
using AutoSalon.Models.Companys.MersedensBens;
using AutoSalon.Models.UnversalCar;

namespace AutoSalonAPI.Profile.CompanyProfile.MersCompanyProfile
{
    public class MersCompanyProfile : AutoMapper.Profile
    {
        public MersCompanyProfile()
        {
            CreateMap<MersedensBenscompanys, MersCompanyDtos>().ReverseMap();
            CreateMap<MersCompanyDtos, MersCompanyResponce>().ReverseMap();
            CreateMap<MersCompanyResponce, MersTranslationCompany>().ReverseMap();
            CreateMap<MersTranslationCompany, Translation>().ReverseMap();
        }
    }
}
