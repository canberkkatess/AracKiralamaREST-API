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
    [RoutePrefix("api/Talep")]
    [EnableCors(origins: "*", headers: "*", methods: "*" /*exposedHeaders: "X-Custom-Header"*/)]

    public class TalepController : ApiController
    {

        private UnitOfWork uow = new UnitOfWork(new TalepContext());

        ///<summary>
        ///Bütün Talepleri Getir
        ///</summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<tblTalep>))]
        public IHttpActionResult Get()
        {

            try
            {

                var talepler = uow.TalepRepository.GetAll();
                if (talepler == null)
                {
                    return NotFound();
                }
                return Ok(new { results = talepler });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }
        }

        /// <summary>
        /// Verilen sirket Id'sine göre talepleri getirir.
        /// </summary>

        [HttpGet]
        [Route("{sirketID}")]
        [ResponseType(typeof(IEnumerable<tblTalep>))]
        public IHttpActionResult Get(int sirketID)
        {
            try
            {
                IEnumerable<tblTalep> talepler1 = uow.TalepRepository.SirketTalepGetir(sirketID);
                if (talepler1 == null)
                {
                    return NotFound();
                }

                return Ok(new { results = talepler1 });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }

        }

        /// <summary>
        /// Verilen sirket Id'sine göre talepleri getirir.
        /// </summary>

        [HttpGet]
        [Route("Musteri/{musteriID}")]
        [ResponseType(typeof(IEnumerable<tblTalep>))]
        public IHttpActionResult GetMusteri(int musteriID)
        {
            try
            {
                IEnumerable<tblTalep> talepler1 = uow.TalepRepository.MusteriTalepGetir(musteriID);
                if (talepler1 == null)
                {
                    return NotFound();
                }

                return Ok(new { results = talepler1 });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }

        }

       
        
        
            

        /// <summary>
        /// Parametre olarak gelen talep tipindeki nesneyi ekleme işlemi yapar.
        /// </summary>

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(tblTalep))]

        public IHttpActionResult Post(tblTalep talep)
        {
            
            try
            {
                uow.TalepRepository.Add(talep);
                uow.Commit();
                return Ok(new { results = talep });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }

        }

        /// <summary>
        /// Id'si şu olan talebi siler.
        /// </summary>

        [HttpDelete]
        [Route("{id}")]

        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (uow.TalepRepository.GetById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    tblTalep talep = uow.TalepRepository.GetById(id);
                    uow.TalepRepository.Remove(talep);
                    uow.Commit();
                    return Ok(new { results = talep });
                }

            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }


        }


        [HttpGet]
        [Route("Ekle/{TalepId}")]
        [ResponseType(typeof(IEnumerable<tblTalep>))]
        public IHttpActionResult GetEkle(int talepID)
        {
           


            try
            {
                tblKiralama kiralama = new tblKiralama();
                tblTalep talep = new tblTalep();
                Hastane_RandevuEntities db = new Hastane_RandevuEntities();
                var kiralamalar = db.tblTalep.Where(x => x.talepID == talepID).ToList();

                foreach (var item in kiralamalar)
                {
                    kiralama.alisTarihi = item.alisTarihi;
                    kiralama.verisTarihi = item.verisTarihi;
                    kiralama.musteriID = item.musteriID;
                    kiralama.aracID = item.aracID;

                

                }
                db.tblKiralama.Add(kiralama);
                db.SaveChanges();

                return Ok(new { results = kiralama });
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
