using Base.Proyecto.Infraestructure.Interfaces;
using Base.Proyecto.Infraestructure.Models;

namespace Base.Proyecto.Infraestructure
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DataBaseContext _context;

        public UnitOfWork(DataBaseContext context)
        {
            this._context = context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void SaveAsync()
        {
            _context.SaveChangesAsync();
        }

        private bool disposed = false;

        private Repository<AppUsers> _AppUsers;
        private Repository<Person> _Person;

        public Repository<AppUsers> AppUsers => _AppUsers ??= new Repository<AppUsers>(_context);
        public Repository<Person> Person => _Person ??= new Repository<Person>(_context);


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}