using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ERPWebServis.Data
{

    public interface IUnifOfWork : IDisposable
    {
        void Commit();
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }


    public class UnifOfWork : IUnifOfWork
    {

        private readonly DbContext _db;


        public UnifOfWork(DbContext db)
        {
            _db = db;

        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {

            return new GenericRepository<TEntity>(_db);

        }



        bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //db
                _db.Dispose();
            }

            // Free any unmanaged objects here.
            //
            disposed = true;

            // Call the base class implementation.
            // base.Dispose(disposing);


        }

        ~UnifOfWork()
        {
            Dispose(false);
        }
    }
}
