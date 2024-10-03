using AutoSalon.Models.Companys.Chevrolet;
using AutoSalon.Models.UnversalCar;

namespace AutoSalon.Models.Cars.Chevrolet
{
    public class Chevroletcars : Car
    {
        public string Code {  get; set; }
        public long CompanyId { get; set; }
        public Chevroletcompanys Chevroletcompanys { get; set; }
        public List<ChevroletTranslation> Translations { get; set; }
    }
}
