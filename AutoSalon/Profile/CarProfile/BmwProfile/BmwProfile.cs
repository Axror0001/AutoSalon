using AutoSalon.DTO.CarsDTO.BmwDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Cars.BMW;

namespace AutoSalonAPI.Profile.CarProfile.BmwProfile
{
    public class BmwProfile : AutoMapper.Profile
    {
        public BmwProfile()
        {
            CreateMap<BMWcars, BmwDTOs>().ReverseMap();
            CreateMap<BmwDTOs, BmwResponse>().ReverseMap();
            CreateMap<BmwResponse, BMWcars>().ReverseMap();
            CreateMap<BmwResponse, BMWTranslation>().ReverseMap();
            CreateMap<BMWTranslation, TranslationDto>().ReverseMap();
        }
    }
}
