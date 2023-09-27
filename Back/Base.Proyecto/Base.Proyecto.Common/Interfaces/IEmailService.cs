namespace Base.Proyecto.Common.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(string emailDestionation, string title, string body);
    }
}