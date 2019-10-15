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
    [RoutePrefix("api/Arac")]
    [EnableCors(origins: "*", headers: "*", methods: "*" /*exposedHeaders: "X-Custom-Header"*/)]
    public class AracController : ApiController
    {

        private UnitOfWork uow = new UnitOfWork(new AracContext());

        ///<summary>
        ///Bütün Aracları Getir
        ///</summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<tblArac>))]
        public IHttpActionResult Get()
        {

            try
            {

                var araclar = uow.AracRepository.GetAll();
                if (araclar == null)
                {
                    return NotFound();
                }
                return Ok(new { results = araclar });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }
        }

        /// <summary>
        /// Id'si şu olan aracı getirir.
        /// </summary>

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(tblArac))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var arac = uow.AracRepository.GetById(id);
                if (arac == null)
                {
                    return NotFound();
                }
                return Ok(new { results = arac });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }

        }
        /// <summary>
        /// Sirket Idsi şu olan aracı getirir.
        /// </summary>

        [HttpGet]
        [Route("SirketAraclari/{sirketID}")]
        [ResponseType(typeof(tblArac))]
        public IHttpActionResult GetSirketArac(int sirketID)
        {
            try
            {
                var arac = uow.AracRepository.SirketAracGetir(sirketID);
                if (arac == null)
                {
                    return NotFound();
                }
                return Ok(new { results = arac });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }

        }





        /// <summary>
        /// Parametre olarak gelen arac tipindeki nesneyi ekleme işlemi yapar.
        /// </summary>

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(tblArac))]

        public IHttpActionResult Post(tblArac arac)
        {
            try
            {
                uow.AracRepository.Add(arac);
                uow.Commit();
                return Ok(new { results = arac });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }

        }

        /// <summary>
        /// Id'si şu olan aracı siler.
        /// </summary>

        [HttpDelete]
        [Route("{id}")]

        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (uow.AracRepository.GetById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    tblArac arac = uow.AracRepository.GetById(id);
                    uow.AracRepository.Remove(arac);
                    uow.Commit();
                    return Ok(new { results = arac });
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
        /// Id'si şu olan aracın kiralama fiyatını gunceller.
        /// </summary>

        [HttpPut]
        [Route("")]
        [ResponseType(typeof(tblArac))]
        public IHttpActionResult Put(tblArac arac)
        {
            try
            {
                var guncellenecek = uow.AracRepository.GetById(arac.aracID);
                //id ye ait kayıt yok ise
                if (arac == null)
                {
                    return NotFound();
                }
                //urun modeli doğrulanmadıysa
                else if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState);
                }
                //OK
                else
                {


                    guncellenecek.aracAciklama = arac.aracAciklama;
                    guncellenecek.aracMarka = arac.aracMarka;
                    guncellenecek.aracModel = arac.aracModel;
                    guncellenecek.koltukSayisi = arac.koltukSayisi;
                    guncellenecek.minEhliyetYasi = arac.minEhliyetYasi;
                    guncellenecek.minSurucuYasi = arac.minSurucuYasi;
                    guncellenecek.sirketID = arac.sirketID;
                    guncellenecek.yakitTuru = arac.yakitTuru;
                    guncellenecek.gunlukKiralamaFiyati = arac.gunlukKiralamaFiyati;
                    



                    uow.Commit();
                    return Ok(new { results = arac });
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
        /// arac km  izle.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AracKmGor/{aracID}")]

        public IHttpActionResult AracKmGor(int aracID)
        {
            try
            {
                var arac = uow.AracRepository.AracKmGor(aracID);
                if (arac == null)
                {
                    return NotFound();

                }
                else
                {
                    return Ok(new { results = arac });
                }
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
