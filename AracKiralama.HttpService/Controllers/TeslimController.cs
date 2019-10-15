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
    [RoutePrefix("api/Teslim")]
    [EnableCors(origins: "*", headers: "*", methods: "*" /*exposedHeaders: "X-Custom-Header"*/)]

    public class TeslimController : ApiController
    {

        private UnitOfWork uow = new UnitOfWork(new TeslimContext());

        ///<summary>
        ///Bütün Teslimleri Getir
        ///</summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<tblTeslim>))]
        public IHttpActionResult Get()
        {

            try
            {

                var teslimler = uow.TeslimRepository.GetAll();
                if (teslimler == null)
                {
                    return NotFound();
                }
                return Ok(new { results = teslimler });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }
        }


        /// <summary>
        /// Parametre olarak gelen teslim tipindeki nesneyi ekleme işlemi yapar.
        /// </summary>

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(tblTeslim))]

        public IHttpActionResult Post(tblTeslim teslim)
        {
            try
            {
                uow.TeslimRepository.Add(teslim);
                uow.Commit();
                return Ok(new { results = teslim });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }

        }





        /// <summary>
        /// gunluk toplam kiralama  getir.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("KmSiniri/{tarih}/{sirketID}")]

        public IHttpActionResult GunlukKmsiniriAsan(DateTime tarih, int sirketID)
        {
            try
            {
                var sayı = uow.TeslimRepository.KmSiniriGecenAracSayisi(sirketID, tarih);
                if (sayı == null)
                {
                    return NotFound();

                }
                else
                {
                    return Ok(new { results = sayı });
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
        /// Verilen arac  Id'sine göre kilometreleri getirir.
        /// </summary>

        [HttpGet]
        [Route("KilometreDondur/{aracID}")]
        [ResponseType(typeof(IEnumerable<tblKiralama>))]
        public IHttpActionResult GetKilometre(int aracID)
        {
            try
            {
                IEnumerable<long?> kilometreler = uow.TeslimRepository.KilometreDondur(aracID);
                if (kilometreler == null)
                {
                    return NotFound();
                }

                return Ok(new { results = kilometreler });
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
