using AutoSalon.Models.Companys.BYD;
using AutoSalon.Models.UnversalCar;

namespace AutoSalon.Models.Cars.BYD
{
    public class BYDcars : Car
    {
        public string Code {  get; set; }
        public long CompanyId { get; set; }
        public BYDcompanys BYDcompanys { get; set; }
        public List<BYDTranslation> Translations { get; set; }
    }
}
