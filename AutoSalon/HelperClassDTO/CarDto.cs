using AutoSalon.HelperClass;

namespace AutoSalon.HelperClassDTO
{
    public class CarDto : BaseDtoEntity
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
