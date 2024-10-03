using AutoSalon.Models.UnversalCar;
using System.Resources;

namespace AutoSalon.DTO.CarsDTO.BmwDto
{
    public class BmwResponse : Car
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
    }
}
