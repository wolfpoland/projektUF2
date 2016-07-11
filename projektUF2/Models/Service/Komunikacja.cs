using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projektUF2.Models.Service
{
    public class Komunikacja
    {
        private const string CacheKey = "KontaktStore";
        public List<Kontakt> kom { get; set; }
        public Komunikacja()
        {
                     kom = new List<Kontakt>();
                    kom.Add(new Kontakt { Id=1, Imie="Patriko", Nazwisko="Fantastico"});
                     kom.Add(new Kontakt { Id = 2, Imie = "Framlp", Nazwisko = "Fantastico" });





        }
        public IEnumerable<Kontakt> getAll()
        {
            return kom;
        }
        public bool saveKontakt(Kontakt kontakt)
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                try
                {
                    var currentData = ((Kontakt[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(kontakt);
                    ctx.Cache[CacheKey] = currentData.ToArray();
                    return true;
                }catch(Exception e)
                {
                    Console.WriteLine("Cos poszlo nie tak kowboju");
                    return false;
                }
                

            }
            return false;
        }
    }
}