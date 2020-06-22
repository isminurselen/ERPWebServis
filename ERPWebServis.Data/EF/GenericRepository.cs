using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ERPWebServis.Data
{
    public interface IGenericRepository<TEntity>
    {      
        TEntity Get(int id);
        Task<TEntity> GetAsync(int id);
        IEnumerable<TEntity> Get();
        Task<IEnumerable<TEntity>> GetAsync();


        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        

       
    }

        
    public class GenericRepository<TEntity>: IGenericRepository<TEntity>
        where TEntity : class
    {
                
        private readonly  DbContext _db;       

        public GenericRepository()
        {
            
        }
        


        public GenericRepository(DbContext db)
        {
            _db = db;
        }


        public TEntity Get(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }



        public async Task<TEntity> GetAsync(int id)

        {
            return await _db.Set<TEntity>().FindAsync(id);
        }



        public IEnumerable<TEntity> Get()
        {
            return _db.Set<TEntity>().AsEnumerable();
        }



        public async Task<IEnumerable<TEntity>> GetAsync()
        {
        
            return await Task.FromResult<IEnumerable<TEntity>>(_db.Set<TEntity>().AsEnumerable());

        }

        
        public void Save(TEntity entity)
        {
            _db.Entry(entity).State = System.Data.Entity.EntityState.Added;            
        }

     

        public void Update(TEntity entity)
        {
            _db.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Modified;            
        }



        public void Delete(TEntity entity)
        {
            _db.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Deleted;
        }

                                            

      

    }
}
