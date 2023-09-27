using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Proyecto.Infraestructure.Models
{
    [Table("AppUsers")]
    public class AppUsers
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(250)]
        public string Email { get; set; }

        [Required, StringLength(50)]
        public string Password { get; set; }
    }
}
