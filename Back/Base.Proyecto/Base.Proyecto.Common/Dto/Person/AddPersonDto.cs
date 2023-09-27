using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Proyecto.Common.Dto.Person
{
    public class AddPersonDto
    {
        public Guid? Id { get; set; }
        [Required,MinLength(7)]
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
