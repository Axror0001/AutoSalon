using AutoSalon.DTO.CompanyDTO.ChevroletCompanyDto;
using AutoSalon.DTO.CompanyDTO.ToyotoCompanyDto;
using AutoSalon.Models.Companys.Chevrolet;
using AutoSalon.Models.Companys.Toyoto;
using AutoSalon.Models.UnversalCar;

namespace AutoSalonAPI.Profile.CompanyProfile.ToyotoCompanyProfile
{
    public class ToyotoCompanyProfile : AutoMapper.Profile
    {
        public ToyotoCompanyProfile()
        {
            CreateMap<Toyotocompanys, ToyotoCompanyDtos>().ReverseMap();
            CreateMap<ToyotoCompanyDtos, ToyotoCompanyResponce>().ReverseMap();
            CreateMap<ToyotoCompanyResponce, ToyotoTranslationCompany>().ReverseMap();
            CreateMap<ToyotoTranslationCompany, Translation>().ReverseMap();
        }
    }
}
