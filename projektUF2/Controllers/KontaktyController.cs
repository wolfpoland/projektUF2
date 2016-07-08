using projektUF2.Models;
using projektUF2.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace projektUF2.Controllers
{
    public class KontaktyController : ApiController
    {
        public Komunikacja komunikat;
        public KontaktyController()
        {
            this.komunikat = new Komunikacja();
        }
        public Kontakt[] Get() {
            return komunikat.getAll();
        }
    }
}
