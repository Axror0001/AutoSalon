using AutoSalon.DTO.CarsDTO.ChevroletDto;
using AutoSalon.HelperClass;
using AutoSalon.HelperClassDTO;
using AutoSalon.Models.Cars.BYD;

namespace AutoSalon.DTO.CompanyDTO.ChevroletCompanyDto
{
    public class ChevroletCompanyDtos : CompanyDto
    {
        public string Code { get; set; }
        public List<ChevroletDtos> BYDcars { get; set; }
        public List<TranslationDto> Translations { get; set; }
    }
}
