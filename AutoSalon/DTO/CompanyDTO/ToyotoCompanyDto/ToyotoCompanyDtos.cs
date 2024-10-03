using AutoSalon.DTO.CarsDTO.ToyotoDto;
using AutoSalon.HelperClass;
using AutoSalon.HelperClassDTO;
using AutoSalon.Models.Cars.BYD;

namespace AutoSalon.DTO.CompanyDTO.ToyotoCompanyDto
{
    public class ToyotoCompanyDtos : CompanyDto
    {
        public string Code { get; set; }
        public List<ToyotoDtos> BYDcars { get; set; }
        public List<TranslationDto> Translations { get; set; }
    }
}
