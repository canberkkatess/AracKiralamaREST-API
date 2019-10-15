using AracKiralama.Data;
using AracKiralama.DataAccess.Context;
using AracKiralama.DataAccess.Repositories.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace AracKiralama.HttpService.Controllers
{
    [RoutePrefix("api/Sirket")]
    [EnableCors(origins: "*", headers: "*", methods: "*" /*exposedHeaders: "X-Custom-Header"*/)]

    public class SirketController : ApiController
    {

        private UnitOfWork uow = new UnitOfWork(new SirketContext());

        ///<summary>
        ///Bütün Sirketleri Getir
        ///</summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<tblSirket>))]
        public IHttpActionResult Get()
        {

            try
            {

                var sirketler = uow.SirketRepository.GetAll();
                if (sirketler == null)
                {
                    return NotFound();
                }
                return Ok(new { results = sirketler });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }
        }

        /// <summary>
        /// Id'si şu olan sirketi getirir.
        /// </summary>

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(tblSirket))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var sirket = uow.SirketRepository.GetById(id);
                if (sirket == null)
                {
                    return NotFound();
                }
                return Ok(new { results = sirket });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }

        }

        /// <summary>
        /// Parametre olarak gelen sirket tipindeki nesneyi ekleme işlemi yapar.
        /// </summary>

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(tblSirket))]

        public IHttpActionResult Post(tblSirket sirket)
        {
            try
            {
                uow.SirketRepository.sirketEkle(sirket);
                uow.Commit();
                return Ok(new { results = sirket });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }

        }

        /// <summary>
        /// Id'si şu olan sirketi siler.
        /// </summary>

        [HttpDelete]
        [Route("{id}")]

        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (uow.SirketRepository.GetById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    tblSirket sirket = uow.SirketRepository.GetById(id);
                    uow.SirketRepository.Remove(sirket);
                    uow.Commit();
                    return Ok(new { results = sirket });
                }

            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }


        }
        /// <summary>
        /// String tipinde gelen email ve sifre ile sirket girişi yapar giriş başarısızsa : 0 başarılı ise :giriş yapan sirket Id'si döner.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="sifre"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GirisYap/{email}/{sifre}")]
        public IHttpActionResult Login(string email, string sifre)
        {
            var loginId = uow.SirketRepository.Login(email, sifre);

            if (loginId == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(new { results = loginId });

            }

        }






    }
}
