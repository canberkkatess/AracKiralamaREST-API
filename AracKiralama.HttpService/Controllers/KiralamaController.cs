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
    [RoutePrefix("api/Kiralama")]
    [EnableCors(origins: "*", headers: "*", methods: "*" /*exposedHeaders: "X-Custom-Header"*/)]

    public class KiralamaController : ApiController
    {

        private UnitOfWork uow = new UnitOfWork(new KiralamaContext());

        ///<summary>
        ///Bütün Kiralamaları Getir
        ///</summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<tblKiralama>))]
        public IHttpActionResult Get()
        {

            try
            {

                var kiralamalar = uow.KiralamaRepository.GetAll();
                if (kiralamalar == null)
                {
                    return NotFound();
                }
                return Ok(new { results = kiralamalar });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }
        }

        /// <summary>
        /// Verilen sirket Id'sine göre kiralamaları getirir.
        /// </summary>

        [HttpGet]
        [Route("{sirketID}")]
        [ResponseType(typeof(IEnumerable<tblKiralama>))]
        public IHttpActionResult Get(int sirketID)
        {
            try
            {
                IEnumerable<tblKiralama> kiralamalar1 = uow.KiralamaRepository.SirketKiralamaGetir(sirketID);
                if (kiralamalar1 == null)
                {
                    return NotFound();
                }

                return Ok(new { results = kiralamalar1 });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }

        }

        /// <summary>
        /// Verilen kullanici Id'sine göre kiralamaları getirir.
        /// </summary>

        [HttpGet]
        [Route("Musteri/{musteriID}")]
        [ResponseType(typeof(IEnumerable<tblKiralama>))]
        public IHttpActionResult GetMusteri(int musteriID)
        {
            try
            {
                IEnumerable<tblKiralama> kiralamalar1 = uow.KiralamaRepository.KullaniciKiralamaGetir(musteriID);
                if (kiralamalar1 == null)
                {
                    return NotFound();
                }

                return Ok(new { results = kiralamalar1 });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }

        }


        /// <summary>
        /// Parametre olarak gelen kiralama tipindeki nesneyi ekleme işlemi yapar.
        /// </summary>

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(tblKiralama))]

        public IHttpActionResult Post(tblKiralama kiralama)
        {
            try
            {
                uow.KiralamaRepository.Add(kiralama);
                uow.Commit();
                return Ok(new { results = kiralama });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }

        }

        /// <summary>
        /// Id'si şu olan kiralamayı siler.
        /// </summary>

        [HttpDelete]
        [Route("{id}")]

        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (uow.KiralamaRepository.GetById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    tblKiralama kiralama = uow.KiralamaRepository.GetById(id);
                    uow.KiralamaRepository.Remove(kiralama);
                    uow.Commit();
                    return Ok(new { results = kiralama });
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
        /// Id'si şu olan aracın kiralamayı gunceller.
        /// </summary>

        [HttpPut]
        [Route("")]
        [ResponseType(typeof(tblKiralama))]
        public IHttpActionResult Put(tblKiralama kiralama)
        {
            try
            {
                var guncellenecek = uow.KiralamaRepository.GetById(kiralama.kiralamaID);
                //id ye ait kayıt yok ise
                if (kiralama == null)
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



                    guncellenecek.verisTarihi = kiralama.verisTarihi;
                    guncellenecek.alisTarihi = kiralama.alisTarihi;
                    




                    uow.Commit();
                    return Ok(new { results = kiralama });
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
        /// Aylık toplam kazanc  getir.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AylikToplamKazanc/{sirketID}")]

        public IHttpActionResult AylıkToplamKazanc(int sirketID)
        {
            try
            {
                var kazanc = uow.KiralamaRepository.ToplamKazancGetir(sirketID);
                if (kazanc == null)
                {
                    return NotFound();

                }
                else
                {
                    return Ok(new { results = kazanc });
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
        /// aylık toplam vergi getirir.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AylikVergi/{sirketID}")]

        public IHttpActionResult AylıkVergi(int sirketID)
        {
            try
            {
                var vergi = uow.KiralamaRepository.AylıkVergiGetir(sirketID);
                if (vergi == null)
                {
                    return NotFound();

                }
                else
                {
                    return Ok(new { results = vergi });
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
        /// aylık net kar getirir.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AylikNetKar/{sirketID}")]

        public IHttpActionResult AylikNetKar(int sirketID)
        {
            try
            {
                var kar = uow.KiralamaRepository.AylikNetKarGetir(sirketID);
                if (kar == null)
                {
                    return NotFound();

                }
                else
                {
                    return Ok(new { results = kar });
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
        /// gunluk toplam kiralama  getir.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GunlukKiralamaSayisi/{tarih}/{sirketID}")]

        public IHttpActionResult GunlukKiralamaSayisi(DateTime tarih, int sirketID)
        {
            try
            {
                var kazanc = uow.KiralamaRepository.GunlukKiralamaSayisi(tarih,sirketID);
                if (kazanc == null)
                {
                    return NotFound();

                }
                else
                {
                    return Ok(new { results = kazanc });
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
        /// Verilen sirket  Id'sine göre gelirleri getirir.
        /// </summary>

        [HttpGet]
        [Route("GelirDondur/{sirketID}")]
        [ResponseType(typeof(IEnumerable<tblKiralama>))]
        public IHttpActionResult GetGelir(int sirketID)
        {
            try
            {
                IEnumerable<int?> gelirler = uow.KiralamaRepository.GelirDondur(sirketID);
                if (gelirler == null)
                {
                    return NotFound();
                }

                return Ok(new { results = gelirler });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }

        }

        /// <summary>
        /// sirket gelir  döndür verilerle.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("SirketGelir/{sirketID}")]

        public IHttpActionResult GetGElir(int sirketID)
        {
            try
            {
                var arac = uow.KiralamaRepository.AylıkKazanclarVerileri(sirketID);
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
