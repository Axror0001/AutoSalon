using AutoSalon.DTO.CarsDTO.MersDto;
using AutoSalon.HelperClass;
using AutoSalon.HelperClassDTO;
using System.ComponentModel.DataAnnotations;

namespace AutoSalon.DTO.CompanyDTO.MersCompanyDto
{
    public class MersCompanyDtos : CompanyDto
    {
        [Required]
        public string Code { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public List<MersDtos> BYDcars { get; set; }
        public List<TranslationDto> Translations { get; set; }
    }
}
