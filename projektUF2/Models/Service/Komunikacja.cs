using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projektUF2.Models.Service
{
    public class Komunikacja
    {
        public List<Kontakt> kom = new List<Kontakt>();
        public Komunikacja()
        {
            kom.Add(new Kontakt(1, "Patryk", "Krasuski"));
        }
        public Kontakt[] getAll()
        {
            return kom.ToArray();
        }
    }
}