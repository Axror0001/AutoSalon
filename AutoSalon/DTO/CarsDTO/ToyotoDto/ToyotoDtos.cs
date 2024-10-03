using AutoSalon.DTO.CompanyDTO.ToyotoCompanyDto;
using AutoSalon.HelperClass;
using AutoSalon.HelperClassDTO;
using AutoSalon.Models.Companys.Toyoto;
using System.ComponentModel.DataAnnotations;

namespace AutoSalon.DTO.CarsDTO.ToyotoDto
{
    public class ToyotoDtos : CarDto
    {
        [Required]
        public string Code { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public ToyotoCompanyDtos ToyotoCompanyDtos { get; set; }
        public List<TranslationDto> Translations { get; set; }
    }
}
