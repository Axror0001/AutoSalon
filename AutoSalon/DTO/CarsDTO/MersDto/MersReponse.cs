using AutoSalon.Models.UnversalCar;

namespace AutoSalon.DTO.CarsDTO.MersDto
{
    public class MersReponse : Car
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
    }
}
