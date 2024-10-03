using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutoSalon.Models.UnversalCar
{
    public abstract class AuditEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [StringLength(50)]
        public string CreatedIp { get; set; }

        public DateTime ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(50)]
        public string ModifiedIp { get; set; }

        [NotMapped]
        public int Query { get; set; }
    }
}
