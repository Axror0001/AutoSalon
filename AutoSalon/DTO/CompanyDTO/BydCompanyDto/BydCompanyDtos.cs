using AutoSalon.DTO.CarsDTO.BYDDto;
using AutoSalon.HelperClass;
using AutoSalon.HelperClassDTO;
using AutoSalon.Models.Cars.BYD;

namespace AutoSalon.DTO.CompanyDTO.BydCompanyDto
{
    public class BydCompanyDtos : CompanyDto
    {
        public string Code { get; set; }
        public List<BydDtos> BYDcars { get; set; }
        public List<TranslationDto> Translations { get; set; }
    }
}
