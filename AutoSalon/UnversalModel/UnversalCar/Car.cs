using AutoSalon.UnversalModel.UnversalCar;

namespace AutoSalon.Models.UnversalCar
{
    public class Car : BaseEntity
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
