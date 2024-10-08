using AutoSalon.DTO.CarsDTO.ChevroletDto;
using AutoSalon.HelperClass;
using AutoSalon.HelperClassDTO;
using System.ComponentModel.DataAnnotations;

namespace AutoSalon.DTO.CompanyDTO.ChevroletCompanyDto
{
    public class ChevroletCompanyDtos : CompanyDto
    {
        [Required]
        public string Code { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public List<ChevroletDtos> BYDcars { get; set; }
        public List<TranslationDto> Translations { get; set; }
    }
}
