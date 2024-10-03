using AutoSalon.Models.UnversalCompany;

namespace AutoSalon.Models.Companys.BYD
{
    public class BYDTranslationCompany : TranslationCompany
    {
        public long bydId {  get; set; }
        public BYDcompanys BYDcompanys { get; set; }
    }
}
