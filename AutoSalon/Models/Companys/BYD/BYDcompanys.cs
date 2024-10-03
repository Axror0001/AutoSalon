using AutoSalon.Models.Cars.BYD;
using AutoSalon.Models.UnversalCompany;

namespace AutoSalon.Models.Companys.BYD
{
    public class BYDcompanys : Company
    {
        public string Code {  get; set; }
        public List<BYDcars> BYDcars { get; set; }
        public List<BYDTranslationCompany> Translations { get; set; }
    }
}
