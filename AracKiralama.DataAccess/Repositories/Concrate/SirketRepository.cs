using AracKiralama.Data;
using AracKiralama.DataAccess.Context;
using AracKiralama.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAccess.Repositories.Concrate
{
    public class SirketRepository : Repository<tblSirket, int>, ISirketRepository
    {

        private Hastane_RandevuEntities db = new Hastane_RandevuEntities();
        private SirketContext _dbContext;
        public SirketRepository(SirketContext context) : base(context)
        {
            _dbContext = context;
        }

        public string MD5eDonustur(string metin)
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
        public void sirketEkle(tblSirket s)
        {
            s.sirketPassword = MD5eDonustur(s.sirketPassword);
            _dbContext.Sirketler.Add(s);
        }


        public int Login(string email, string sifre)
        {
            var user = _dbContext.Sirketler.FirstOrDefault(x => x.sirketEmail == email);
            if (user != null)
            {
                if (user.sirketPassword == MD5eDonustur(sifre))
                {
                    //kullanıcı ad pw doğru ise kullanıcı id döner
                    return user.sirketID;
                }
                else
                {
                    //Kullanıcı Var Pw yanlış 0 döner
                    return 0;

                }
            }
            else
            {

                //bu kullanıcı adında biri yoksa 0 döner
                return 0;
            }


        }
    }
}
