using AutoSalon.DTO.CompanyDTO.BydCompanyDto;
using AutoSalon.Models.Companys.BYD;
using AutoSalon.Models.UnversalCar;

namespace AutoSalonAPI.Profile.CompanyProfile.BydCompanyProfile
{
    public class BydCompanyProfile : AutoMapper.Profile
    {
        public BydCompanyProfile()
        {
            CreateMap<BYDcompanys, BydCompanyDtos>().ReverseMap();
            CreateMap<BydCompanyDtos, BydCompanyResponce>().ReverseMap();
            CreateMap<BydCompanyResponce, BYDTranslationCompany>().ReverseMap();
            CreateMap<BYDTranslationCompany, Translation>().ReverseMap();
        }
    }
}
