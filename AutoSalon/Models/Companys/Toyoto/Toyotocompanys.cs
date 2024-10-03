using AutoSalon.Models.Cars.Toyoto;
using AutoSalon.Models.UnversalCompany;

namespace AutoSalon.Models.Companys.Toyoto
{
    public class Toyotocompanys : Company
    {
        public string Code { get; set; }
        public List<Toyotocars> Toyotocars { get; set; }
        public List<ToyotoTranslationCompany> Translations { get; set; }
    }
}
