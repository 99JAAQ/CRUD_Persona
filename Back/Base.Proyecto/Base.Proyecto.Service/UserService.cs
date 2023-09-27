using Base.Proyecto.Common;
using Base.Proyecto.Common.Dto;
using Base.Proyecto.Common.Dto.AppUser;
using Base.Proyecto.Common.Interfaces;
using Base.Proyecto.Infraestructure.Interfaces;
using Base.Proyecto.Infraestructure.Models;
using Base.Proyecto.Service.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Proyecto.Service
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtSetting _jwtSetting;
        private readonly IUtility _utility;

        public UserService(IUnitOfWork unitOfWork, IOptions<JwtSetting> jwtSetting,IUtility utility)
        {
            _unitOfWork = unitOfWork;
            _jwtSetting = jwtSetting.Value;
            _utility = utility;
        }

        public bool Authenticate(LoginRequest model)
        {
            byte[] salt = new byte[] { 0x1};
            AppUsers user = _unitOfWork.AppUsers.FirstOrDefault(x => x.Email == model.Email);

            if (user == null) throw new Exception("El usuario no existe");
            if (!_utility.VerifyPassword(model.Password,salt , user.Password))
                throw new Exception("Contraseña incorrecta");

            return true;
        } 
    }
}
