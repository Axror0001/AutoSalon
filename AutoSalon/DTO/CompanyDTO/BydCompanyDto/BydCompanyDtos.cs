using AutoSalon.DTO.CarsDTO.BYDDto;
using AutoSalon.HelperClass;
using AutoSalon.HelperClassDTO;
using AutoSalon.Models.Cars.BYD;
using System.ComponentModel.DataAnnotations;

namespace AutoSalon.DTO.CompanyDTO.BydCompanyDto
{
    public class BydCompanyDtos : CompanyDto
    {
        [Required]
        public string Code { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public List<BydDtos> BYDcars { get; set; }
        public List<TranslationDto> Translations { get; set; }
    }
}
