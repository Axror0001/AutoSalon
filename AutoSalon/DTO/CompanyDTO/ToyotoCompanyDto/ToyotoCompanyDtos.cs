using AutoSalon.DTO.CarsDTO.ToyotoDto;
using AutoSalon.HelperClass;
using AutoSalon.HelperClassDTO;
using System.ComponentModel.DataAnnotations;

namespace AutoSalon.DTO.CompanyDTO.ToyotoCompanyDto
{
    public class ToyotoCompanyDtos : CompanyDto
    {
        [Required]
        public string Code { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public List<ToyotoDtos> BYDcars { get; set; }
        public List<TranslationDto> Translations { get; set; }
    }
}
