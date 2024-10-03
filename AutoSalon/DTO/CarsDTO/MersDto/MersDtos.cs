using AutoSalon.DTO.CompanyDTO.MersCompanyDto;
using AutoSalon.HelperClass;
using AutoSalon.HelperClassDTO;
using System.ComponentModel.DataAnnotations;

namespace AutoSalon.DTO.CarsDTO.MersDto
{
    public class MersDtos : CarDto
    {
        [Required]
        public string Code { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public MersCompanyDtos MersCompanyDtos { get; set; }
        public List<TranslationDto> Translations { get; set; }
    }
}
