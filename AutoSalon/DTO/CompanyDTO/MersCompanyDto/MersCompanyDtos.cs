using AutoSalon.DTO.CarsDTO.MersDto;
using AutoSalon.HelperClass;
using AutoSalon.HelperClassDTO;
using AutoSalon.Models.Cars.BYD;

namespace AutoSalon.DTO.CompanyDTO.MersCompanyDto
{
    public class MersCompanyDtos : CompanyDto
    {
        public string Code { get; set; }
        public List<MersDtos> BYDcars { get; set; }
        public List<TranslationDto> Translations { get; set; }
    }
}
