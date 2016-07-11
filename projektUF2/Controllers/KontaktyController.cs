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
        
        public IEnumerable<Kontakt> Get() {
            return komunikat.getAll();
        }
       
        public HttpResponseMessage Post([FromBody]Kontakt kontakt)
        {
            komunikat.saveKontakt(kontakt);
          //  List<Kontakt> tmp = komunikat.kom;
           // tmp.Add(kontakt);
           //  System.Diagnostics.Debug.WriteLine("ID: {0} Imie: {1} Nazwisko: {2}", kontakt.id, kontakt.imie, kontakt.nazwisko);
            //Console.WriteLine("ID: {0} Imie: {1} Nazwisko: {2}",kontakt.id,kontakt.imie, kontakt.nazwisko);

            var response = Request.CreateResponse<Kontakt>(System.Net.HttpStatusCode.Created, kontakt);

            return response;
        }
    }
}
