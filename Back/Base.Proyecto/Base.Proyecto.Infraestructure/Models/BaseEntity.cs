using System.ComponentModel.DataAnnotations;

namespace Base.Proyecto.Infraestructure.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public Guid? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool IsActive { get; set; } = true;
    }
}