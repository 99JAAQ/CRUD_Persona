using Base.Proyecto.Infraestructure.Models;

namespace Base.Proyecto.Infraestructure.Interfaces
{
    public interface IUnitOfWork
    {
        Repository<AppUsers> AppUsers { get; }
        Repository<Person> Person { get; }

        void Dispose();

        int Save();

        void SaveAsync();
    }
}