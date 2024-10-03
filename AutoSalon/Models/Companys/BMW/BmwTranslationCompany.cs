using AutoSalon.Models.Cars.BMW;
using AutoSalon.Models.UnversalCompany;

namespace AutoSalon.Models.Companys.BMW
{
    public class BmwTranslationCompany : TranslationCompany
    {
        public long bmwId {  get; set; }
        public BMWcompanys BMWcompanys { get; set; }
    }
}
