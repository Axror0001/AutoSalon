namespace AutoSalon.HelperClass
{
    public abstract class BaseDtoEntity
    {
        public virtual long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
