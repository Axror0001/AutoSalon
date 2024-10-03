using AutoSalon.HelperClass;
using AutoSalon.HelperClassDTO;
using AutoSalon.Models.Companys.BYD;
using System.ComponentModel.DataAnnotations;

namespace AutoSalon.DTO.CarsDTO.BYDDto
{
    public class BydDtos : CarDto
    {
        [Required]
        public string Code { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public BYDcompanys BYDcompanys { get; set; }
        public List<TranslationDto> Translations { get; set; }
    }
}
