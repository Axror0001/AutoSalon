using AutoSalon.DTO.CarsDTO.MersDto;
using AutoSalon.Models.Cars.MersedensBens;
using AutoSalon.Models.UnversalCar;

namespace AutoSalonAPI.Profile.CarProfile.MersProfile
{
    public class MersProfile : AutoMapper.Profile
    {
        public MersProfile()
        {
            CreateMap<MersedensBenscars, MersDtos>().ReverseMap();
            CreateMap<MersDtos, MersReponse>().ReverseMap();
            CreateMap<MersReponse, MersTranslation>().ReverseMap();
            CreateMap<MersTranslation, Translation>().ReverseMap();
        }
    }
}
