using AutoSalon.Models.Cars.Chevrolet;
using AutoSalon.Models.UnversalCompany;

namespace AutoSalon.Models.Companys.Chevrolet
{
    public class Chevroletcompanys : Company
    {
        public string Code {  get; set; }
        public List<Chevroletcars> Chevroletcars { get; set; }
        public List<ChevroletTranslationCompany> Translation { get; set; }
    }
}
