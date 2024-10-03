using AutoSalon.UnversalModel.UnversalCar;

namespace AutoSalon.Models.UnversalCompany
{
    public abstract class TranslationCompany : BaseEntity
    {
        public string LanguageCode { get; set; }

        public string ShortTitle { get; set; }

        public string FullTitle { get; set; }
    }
}
