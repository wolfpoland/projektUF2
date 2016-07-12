using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projektUF2.Models.Service
{
    public class Komunikacja
    {
        private const string CacheKey = "KontaktStore";
        public List<Kontakt> kom = new List<Kontakt>();
      /*  {
            new Kontakt { Id=1, Imie="Patriko", Nazwisko="Fantastico"},
            new Kontakt { Id = 2, Imie = "Framlp", Nazwisko = "Fantastico" }
        };*/
        public Komunikacja()
        {

        }
        public List<Kontakt> getLista()
        {
            return kom;
        }
        public void setLista(List<Kontakt> nowa)
        {
            kom = new List<Kontakt>();
            foreach (Kontakt item in nowa)
            {
                kom.Add(item);
            }
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