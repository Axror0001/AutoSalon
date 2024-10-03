using AutoSalon.DTO.CompanyDTO.BydCompanyDto;
using AutoSalon.DTO.CompanyDTO.ChevroletCompanyDto;
using AutoSalon.Models.Companys.BYD;
using AutoSalon.Models.Companys.Chevrolet;
using AutoSalon.Models.UnversalCar;

namespace AutoSalonAPI.Profile.CompanyProfile.ChevroletCompanyProfile
{
    public class ChevroletCompanyProfile : AutoMapper.Profile
    {
        public ChevroletCompanyProfile()
        {
            CreateMap<Chevroletcompanys, ChevroletCompanyDtos>().ReverseMap();
            CreateMap<ChevroletCompanyDtos, ChevroletCompanyResponce>().ReverseMap();
            CreateMap<ChevroletCompanyResponce, ChevroletTranslationCompany>().ReverseMap();
            CreateMap<ChevroletTranslationCompany, Translation>().ReverseMap();
        }
    }
}
