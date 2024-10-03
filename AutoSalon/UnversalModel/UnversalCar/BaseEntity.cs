using AutoSalon.Models.UnversalCar;

namespace AutoSalon.UnversalModel.UnversalCar
{
    public abstract class BaseEntity : AuditEntity
    {
        public virtual long Id { get; set; }
    }
}
