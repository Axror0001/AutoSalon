using AutoSalon.Models.UnversalCar;

namespace AutoSalon.DTO.CarsDTO.ChevroletDto
{
    public class ChevroletResponse : Car
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
    }
}
