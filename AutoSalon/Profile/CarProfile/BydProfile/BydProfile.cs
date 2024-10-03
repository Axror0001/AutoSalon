using AutoSalon.DTO.CarsDTO.BYDDto;
using AutoSalon.HelperClass;
using AutoSalon.Models.Cars.BYD;
using AutoSalon.Models.UnversalCar;

namespace AutoSalonAPI.Profile.CarProfile.BydProfile
{
    public class BydProfile : AutoMapper.Profile
    {
        public BydProfile()
        {
            CreateMap<BYDcars, BydDtos>().ReverseMap();
            CreateMap<BydDtos, BydResponse>().ReverseMap();
            CreateMap<BydResponse, TranslationDto>().ReverseMap();
            CreateMap<TranslationDto, Translation>().ReverseMap();
        }
    }
}
