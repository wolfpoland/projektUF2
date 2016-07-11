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
            List<Kontakt> tmp = komunikat.kom;
            tmp.Add(kontakt);
             System.Diagnostics.Debug.WriteLine("ID: {0} Imie: {1} Nazwisko: {2}", kontakt.Id, kontakt.Imie, kontakt.Nazwisko);
            //Console.WriteLine("ID: {0} Imie: {1} Nazwisko: {2}",kontakt.id,kontakt.imie, kontakt.nazwisko);

            var response = Request.CreateResponse<Kontakt>(System.Net.HttpStatusCode.Created, kontakt);

            return response;
        }
        public IHttpActionResult getProduct(int id)
        {
            List<Kontakt> tmp = komunikat.kom;
            Kontakt kontakt = tmp.Single(k => k.Id == id);
            if(kontakt == null)
            {
                return NotFound();
            }
            return Ok(kontakt);
            
        }
        public HttpResponseMessage Delete(int id)
        {
            List<Kontakt> lista = komunikat.kom;
            Kontakt ko = lista.Single(k => k.Id == id);
            var respone = Request.CreateResponse<Kontakt>(System.Net.HttpStatusCode.Accepted, ko);
            return respone;
        }
    }
}
