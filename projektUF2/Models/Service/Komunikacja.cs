﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projektUF2.Models.Service
{
    public class Komunikacja
    {
        private const string CacheKey = "KontaktStore";
        public List<Kontakt> kom = new List<Kontakt>();
        public Komunikacja()
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    kom.Add(new Kontakt(1, "Patryk", "Krasuski"));
                    kom.Add(new Kontakt(2, "Alicja", "ZkrainyCzarwow"));
                    ctx.Cache[CacheKey] = kom.ToArray();

                }
            }
           
        }
        public Kontakt[] getAll()
        {
            var ctx = HttpContext.Current;
            if(ctx != null)
            {
                return (Kontakt[])ctx.Cache[CacheKey];
            }
            List<Kontakt> kontakty = new List<Kontakt>();
            kontakty.Add(new Kontakt(1, "PLACEHOLDER", "PlaceHoleder"));
            return kontakty.ToArray();
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