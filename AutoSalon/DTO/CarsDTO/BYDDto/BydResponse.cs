using AutoSalon.Models.UnversalCar;

namespace AutoSalon.DTO.CarsDTO.BYDDto
{
    public class BydResponse : Car
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
    }
}
