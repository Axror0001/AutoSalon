using AutoSalon.UnversalModel.UnversalCar;

namespace AutoSalon.Models.UnversalCompany
{
    public class Company : BaseEntity
    {
        public Guid Guid { get; set; }
        public string CompanyName { get; set; }
        public string CompanyBreand { get; set; }
        public string CompanyDirector {  get; set; }
        public string Country {  get; set; }

    }
}
