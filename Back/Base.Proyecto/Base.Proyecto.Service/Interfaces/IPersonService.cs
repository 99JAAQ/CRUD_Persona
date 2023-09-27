using Base.Proyecto.Common.Dto;
using Base.Proyecto.Common.Dto.Person;
using Base.Proyecto.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Proyecto.Service.Interfaces
{
    public interface IPersonService
    {
        BodyResponse<object> GetAll();
        BodyResponse<object> GetById(Guid id);
        BodyResponse<object> Add(AddPersonDto model);
        BodyResponse<object> Update(AddPersonDto model);
        BodyResponse<object> Delete(Guid id);
    }
}
