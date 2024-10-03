using AutoSalon.DTO.CarsDTO.ToyotoDto;
using AutoSalon.Models.Cars.Toyoto;
using AutoSalon.Models.UnversalCar;

namespace AutoSalonAPI.Profile.CarProfile.ToyotoProfile
{
    public class ToyotoProfile : AutoMapper.Profile
    {
        public ToyotoProfile()
        {
            CreateMap<Toyotocars, ToyotoDtos>().ReverseMap();
            CreateMap<ToyotoDtos, ToyotoResponse>().ReverseMap();
            CreateMap<ToyotoResponse, ToyotoTranslation>().ReverseMap();
            CreateMap<ToyotoTranslation, Translation>().ReverseMap();
        }
    }
}
