using AutoSalon.UnversalModel.UnversalCar;

namespace AutoSalon.Models.UnversalCar
{
    public class Translation : BaseEntity
    {
        public string LanguageCode { get; set; }

        public string ShortTitle { get; set; }

        public string FullTitle { get; set; }
    }
}
