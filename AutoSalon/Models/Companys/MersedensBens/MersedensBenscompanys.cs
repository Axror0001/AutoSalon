using AutoSalon.Models.Cars.MersedensBens;
using AutoSalon.Models.UnversalCompany;

namespace AutoSalon.Models.Companys.MersedensBens
{
    public class MersedensBenscompanys : Company
    {
        public string Code {  get; set; }
        public List<MersedensBenscars> MersedensBenscars { get; set; }
        public List<MersTranslationCompany> Translations { get; set; }
    }
}
