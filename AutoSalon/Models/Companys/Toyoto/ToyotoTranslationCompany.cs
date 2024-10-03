using AutoSalon.Models.UnversalCompany;

namespace AutoSalon.Models.Companys.Toyoto
{
    public class ToyotoTranslationCompany : TranslationCompany
    {
        public long ToyotoId {  get; set; }
        public Toyotocompanys ToyotoCompanys { get; set; }
    }
}
