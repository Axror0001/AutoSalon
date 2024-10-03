using AutoSalon.Models.Cars.BMW;
using AutoSalon.Models.UnversalCompany;

namespace AutoSalon.Models.Companys.BMW
{
    public class BMWcompanys : Company
    {
        public string Code {  get; set; }
        public List<BMWcars> BMWcars { get; set; }
        public List<BmwTranslationCompany> Translations { get; set; }
    }
}
