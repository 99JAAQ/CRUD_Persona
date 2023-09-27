using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Proyecto.Infraestructure.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MinLength(7)]
        public string Cedula { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }

        public bool Estado { get; set; }

    }
}
