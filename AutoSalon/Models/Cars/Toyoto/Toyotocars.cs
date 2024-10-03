using AutoSalon.Models.Companys.Toyoto;
using AutoSalon.Models.UnversalCar;

namespace AutoSalon.Models.Cars.Toyoto
{
    public class Toyotocars : Car
    {
        public string Code {  get; set; }
        public long CompanyId { get; set; }
        public Toyotocompanys Toyotocompanys { get; set; }
        public List<ToyotoTranslation> Translations { get; set; }
    }
}
