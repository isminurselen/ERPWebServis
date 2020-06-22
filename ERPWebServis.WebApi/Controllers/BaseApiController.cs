using ERPWebServis.Data;
using ERPWebServis.Model;
using ERPWebServis.WebApi.Attribute;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace ERPWebServis.WebApi.Controllers
{


    
    public class BaseApiController<TEntity> : ApiController
                                where TEntity : class 
    {
       


        public IGenericRepository<TEntity> _repo;

        private UnifOfWork _uow = new UnifOfWork(new ERPEntities());

        public BaseApiController()
        {
                      
            _repo = _uow.GetRepository<TEntity>();


        }


      //   [ApiExceptionAttribute]
        // [AuthorizeAttribute]
        // özel yetki etiketi
        //[ApiAuthorizeAttribute(Roles ="A")] // action seviyesinde yaptık controller seviyesindede kontrol yapabiliriz
    //    [ApiAuthenticationAttribute]
        
        public IHttpActionResult Get(int id)
        {
        //    var user = User.Identity.Name;
      //      var user_ = Thread.CurrentPrincipal.Identity.Name;

            var entity = _repo.Get(id);


            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);


            /*Sürekli try cath yazmakmak içn attribute([ApiExceptionAttribute]) yaptık ve application seviyesinde ekledik.  Class veya metodun başınada eklenebilir. Kod tekrarında kaçmak içn application botunda yaptık*/
            /*
            try
            {
                 var entity = _repo.GetEntity(id);
                if (entity == null)
                {
                    return NotFound();
                }
                return Ok(entity);
                
            }
            catch (Exception ex)
            {          
                return InternalServerError(ex);


            } */
        }

    
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            try
            {
                var entity = await _repo.GetAsync(id);
                if (entity == null)
                {
                    return NotFound();
                }
                return Ok(entity);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


      //  [AllowAnonymous] // bu metodu yetki kontrolünden çıkardık control bazlı yetkilendirmede kullanılabilir.
        public  IHttpActionResult Get()
        {

            
            try
            {
              
                var entity =_repo.Get();

                if (entity == null)
                {
                    return NotFound();
                }
                return Ok(entity);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        

        public async Task<IHttpActionResult> GetAsync()
        {

            try
            {
                var entity = _repo.GetAsync();
                if (entity == null)
                {
                    return NotFound();
                }                               
                return await Task.FromResult<IHttpActionResult>(Ok(entity));              
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }


        }


                
        public IHttpActionResult Post(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    return NotFound();
                }
              
                _repo.Save(entity);
          //      _uow.Commit();
                return Ok(entity);
            }
            catch(Exception ex)
            {

                return InternalServerError(ex);
                 
            }


            
        }




                     
        public IHttpActionResult Put(int id)
        {
            try
            {
                var entity = _repo.Get(id);
                if (entity == null)
                {
                    return NotFound();
                }

                _repo.Update(entity);
              //  _uow.Commit();
                return Ok(entity);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        

        
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = _repo.Get(id);
                if (entity == null)
                {
                    return NotFound();
                }

                _repo.Delete(entity);

                return Ok(entity);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);

            }

        }

        

        protected override void Dispose(bool disposing)
        {
            _uow.Dispose();
            base.Dispose(disposing);
        }


    }
}
