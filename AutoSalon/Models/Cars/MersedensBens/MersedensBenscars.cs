using AutoSalon.Models.Companys.MersedensBens;
using AutoSalon.Models.UnversalCar;

namespace AutoSalon.Models.Cars.MersedensBens
{
    public class MersedensBenscars : Car
    {
        public string Code {  get; set; }
        public long CompanyId { get; set; }
        public MersedensBenscompanys MersedensBenscompanys { get; set; }
        public List<MersTranslation> Translations { get; set; }
    }
}
