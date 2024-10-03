using AutoSalon.DTO.CompanyDTO.ChevroletCompanyDto;
using AutoSalon.HelperClass;
using AutoSalon.HelperClassDTO;
using System.ComponentModel.DataAnnotations;

namespace AutoSalon.DTO.CarsDTO.ChevroletDto
{
    public class ChevroletDtos : CarDto
    {
        [Required]
        public string Code { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public ChevroletCompanyDtos chevroletCompanyDtos { get; set; }
        public List<TranslationDto> Translations { get; set; }
    }
}
