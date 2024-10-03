using AutoSalon.Models.UnversalCar;

namespace AutoSalon.DTO.CarsDTO.ToyotoDto
{
    public class ToyotoResponse : Car
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
    }
}
