using AutoSalon.DTO.CarsDTO.ToyotoDto;
using AutoSalon.DTO.CompanyDTO.BmwCompanyDto;
using AutoSalon.Models.Cars.Toyoto;
using AutoSalon.Models.Companys.BMW;
using AutoSalon.Models.UnversalCar;

namespace AutoSalonAPI.Profile.CompanyProfile.BmwCompanyProfile
{
    public class BmwCompanyProfile : AutoMapper.Profile
    {
        public BmwCompanyProfile()
        {
            CreateMap<BMWcompanys, BmwCompanyDtos>().ReverseMap();
            CreateMap<BmwCompanyDtos, BmwCompanyResponce>().ReverseMap();
            CreateMap<BmwCompanyResponce, BmwTranslationCompany>().ReverseMap();
            CreateMap<BmwTranslationCompany, Translation>().ReverseMap();
        }
    }
}
