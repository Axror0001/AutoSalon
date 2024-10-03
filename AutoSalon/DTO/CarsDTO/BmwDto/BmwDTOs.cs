using AutoSalon.DTO.CompanyDTO.BmwCompanyDto;
using AutoSalon.HelperClass;
using AutoSalon.HelperClassDTO;
using System.ComponentModel.DataAnnotations;

namespace AutoSalon.DTO.CarsDTO.BmwDto
{
    public class BmwDTOs : CarDto
    {
        [Required]
        public string Code { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public BmwCompanyDtos BmwCompanyDto { get; set; }
        public List<TranslationDto> Translations { get; set; }
    }
}
