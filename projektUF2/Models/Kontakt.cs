﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace projektUF2.Models
{
   
    public class Kontakt
    {
      /*  public Kontakt(int id,string imie, string nazwisko)
        {
            this.Id = id;
            this.Imie = imie;
            this.Nazwisko = nazwisko;
        }*/
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
    }
}