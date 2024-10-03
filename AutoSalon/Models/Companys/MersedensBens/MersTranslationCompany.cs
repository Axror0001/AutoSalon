using AutoSalon.Models.UnversalCompany;

namespace AutoSalon.Models.Companys.MersedensBens
{
    public class MersTranslationCompany : TranslationCompany
    {
        public long MersId {  get; set; }
        public MersedensBenscompanys MersedensBenscompanys { get; set; }
    }
}
