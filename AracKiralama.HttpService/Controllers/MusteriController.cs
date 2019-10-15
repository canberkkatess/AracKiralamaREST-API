using AracKiralama.Data;
using AracKiralama.DataAccess.Context;
using AracKiralama.DataAccess.Repositories.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace AracKiralama.HttpService.Controllers
{
    [RoutePrefix("api/Musteri")]
    [EnableCors(origins: "*", headers: "*", methods: "*" /*exposedHeaders: "X-Custom-Header"*/)]

    public class MusteriController : ApiController
    {

        private UnitOfWork uow = new UnitOfWork(new MusteriContext());

        ///<summary>
        ///Bütün Müşterileri Getir
        ///</summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<tblMusteri>))]
        public IHttpActionResult Get()
        {

            try
            {

                var musteriler = uow.MusteriRepository.GetAll();
                if (musteriler == null)
                {
                    return NotFound();
                }
                return Ok(new { results = musteriler });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }
        }

        /// <summary>
        /// Id'si şu olan musteriyi getirir.
        /// </summary>

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(tblMusteri))]
        public IHttpActionResult Get(int id)
        {
           
                var musteri = uow.MusteriRepository.GetById(id);
                if (musteri == null)
                {
                    return NotFound();
                }
                return Ok(new { results = musteri });
            
           

        }

        /// <summary>
        /// Parametre olarak gelen müşteri tipindeki nesneyi ekleme işlemi yapar.
        /// </summary>

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(tblMusteri))]

        public IHttpActionResult Post(tblMusteri musteri)
        {
            try
            {
                uow.MusteriRepository.musteriEkle(musteri);
                uow.Commit();
                return Ok(new { results = musteri });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }

        }

        /// <summary>
        /// String tipinde gelen email ve sifre ile müşteri girişi yapar giriş başarısızsa : 0 başarılı ise :giriş yapan sirket Id'si döner.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="sifre"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GirisYap/{email}/{sifre}")]
        public IHttpActionResult Login(string email, string sifre)
        {
            var loginId = uow.MusteriRepository.Login(email, sifre);

            if (loginId == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(new { results = loginId });

            }

        }

        private string MD5eDonustur(string metin)
        {
            MD5CryptoServiceProvider pwd = new MD5CryptoServiceProvider();
            return Sifrele(metin, pwd);
        }
        private string Sifrele(string metin, HashAlgorithm alg)
        {
            byte[] bytDegeri = System.Text.Encoding.UTF8.GetBytes(metin);
            byte[] sifreliByte = alg.ComputeHash(bytDegeri);
            return Convert.ToBase64String(sifreliByte);
        }
        /// <summary>
        /// Müşteri bilgi Güncelleme
        /// </summary>    
        /// <returns></returns>

        [HttpPut]
        [Route("")]
        [ResponseType(typeof(tblMusteri))]
        public IHttpActionResult Put(tblMusteri musteri)
        {
            try
            {
                var guncellenecek = uow.MusteriRepository.GetById(musteri.musteriID);
                //id ye ait kayıt yok ise
                if (musteri == null)
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

                    guncellenecek.musteriEmail = musteri.musteriEmail;

                    guncellenecek.musteriPassword = MD5eDonustur(musteri.musteriPassword);
                    guncellenecek.musteriSehir = musteri.musteriSehir;
                    guncellenecek.musteriAdres = musteri.musteriAdres;



                    uow.Commit();
                    return Ok(new { results = musteri });
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
