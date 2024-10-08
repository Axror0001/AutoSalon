using AutoSalon.DTO.CarsDTO.BmwDto;
using AutoSalon.HelperClass;
using AutoSalon.HelperClassDTO;
using System.ComponentModel.DataAnnotations;

namespace AutoSalon.DTO.CompanyDTO.BmwCompanyDto
{
    public class BmwCompanyDtos : CompanyDto
    {
        [Required]
        public string Code { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public List<BmwDTOs> BMWcars { get; set; }
        public List<TranslationDto> Translations { get; set; }
    }
}
