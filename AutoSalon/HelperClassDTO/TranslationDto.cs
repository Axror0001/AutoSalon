using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace AutoSalon.HelperClass
{
    public class TranslationDto : BaseDtoEntity
    {
        public string? LanguageCode { get; set; }
        public string? FullTitle { get; set; }
        public string? ShortTitle { get; set; }
    }
}
