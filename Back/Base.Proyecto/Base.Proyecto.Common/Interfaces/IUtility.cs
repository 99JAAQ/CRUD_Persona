using Base.Proyecto.Common.Dto;

namespace Base.Proyecto.Common.Interfaces
{
    public interface IUtility
    {
        HashSalt EncryptPassword(string password);

        bool VerifyPassword(string enteredPassword, byte[] salt, string storedPassword);
    }
}