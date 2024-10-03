using AutoSalon.DTO.CarsDTO.ChevroletDto;
using AutoSalon.Models.Cars.Chevrolet;
using AutoSalon.Models.UnversalCar;

namespace AutoSalonAPI.Profile.CarProfile.ChevroletProfile
{
    public class ChevroletProfile : AutoMapper.Profile
    {
        public ChevroletProfile()
        {
            CreateMap<Chevroletcars, ChevroletDtos>().ReverseMap();
            CreateMap<ChevroletDtos , ChevroletResponse>().ReverseMap();
            CreateMap<ChevroletResponse, ChevroletTranslation>().ReverseMap();
            CreateMap<ChevroletTranslation, Translation>().ReverseMap();
        }
    }
}
