using Base.Proyecto.Common.Dto.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Proyecto.Service.Interfaces
{
    public interface IUserService
    {
        bool Authenticate(LoginRequest model);
    }
}
