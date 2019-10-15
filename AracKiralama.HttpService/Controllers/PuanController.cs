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
    [RoutePrefix("api/Puan")]
    [EnableCors(origins: "*", headers: "*", methods: "*" /*exposedHeaders: "X-Custom-Header"*/)]

    public class PuanController : ApiController
    {

        private UnitOfWork uow = new UnitOfWork(new PuanContext());

        ///<summary>
        ///Bütün Puanları Getir
        ///</summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<tblPuan>))]
        public IHttpActionResult Get()
        {

            try
            {

                var puanlar = uow.PuanRepository.GetAll();
                if (puanlar == null)
                {
                    return NotFound();
                }
                return Ok(new { results = puanlar });
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
        [ResponseType(typeof(tblPuan))]

        public IHttpActionResult Post(tblPuan puan)
        {
            
            try
            {
                uow.PuanRepository.Add(puan);
                uow.Commit();
                return Ok(new { results = puan });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }

        }



       






    }
}
