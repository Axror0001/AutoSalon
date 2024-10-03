using AutoSalon.Models.Companys.BMW;
using AutoSalon.Models.UnversalCar;

namespace AutoSalon.Models.Cars.BMW
{
    public class BMWcars : Car
    {
        public string Code { get; set; }
        public long CompanyId {  get; set; }
        public BMWcompanys BMWcompanys { get; set; }
        public List<BMWTranslation> Translations { get; set; }
    }
}
