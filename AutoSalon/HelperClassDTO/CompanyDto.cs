using AutoSalon.HelperClass;

namespace AutoSalon.HelperClassDTO
{
    public class CompanyDto : BaseDtoEntity
    {
        public Guid Guid { get; set; }
        public string CompanyName { get; set; }
        public string CompanyBreand { get; set; }
        public string CompanyDirector { get; set; }
        public string Country { get; set; }
    }
}
