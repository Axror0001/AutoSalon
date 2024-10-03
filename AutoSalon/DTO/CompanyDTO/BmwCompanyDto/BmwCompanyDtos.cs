using AutoSalon.DTO.CarsDTO.BmwDto;
using AutoSalon.HelperClass;
using AutoSalon.HelperClassDTO;
using AutoSalon.Models.Cars.BMW;
using AutoSalon.Models.Companys.BMW;

namespace AutoSalon.DTO.CompanyDTO.BmwCompanyDto
{
    public class BmwCompanyDtos : CompanyDto
    {
        public string Code { get; set; }
        public List<BmwDTOs> BMWcars { get; set; }
        public List<TranslationDto> Translations { get; set; }
    }
}
