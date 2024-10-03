using AutoSalon.Models.UnversalCar;

namespace AutoSalon.Models.Cars.BYD
{
    public class BYDTranslation : Translation
    {
        public long bydId {  get; set; }
        public BYDcars BYDcars { get; set; }
    }
}
