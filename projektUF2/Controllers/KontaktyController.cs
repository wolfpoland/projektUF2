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
        [HttpGet]
        // public IEnumerable<Kontakt> Get() {
        public IEnumerable<Kontakt> Get()
        {
            return komunikat.getAll();
        }
       [HttpPost]
        public HttpResponseMessage Post(Kontakt kontakt)
        {

           // komunikat.saveKontakt(kontakt);
            List<Kontakt> tmp = komunikat.getLista();
            tmp.Add(kontakt);
            komunikat.kom = tmp;
            List<Kontakt> testowo = komunikat.getLista();
            System.Diagnostics.Debug.WriteLine("Wypisuje liste testowo Post: ");
            int n = 0;
            foreach (Kontakt item in testowo)
            {
                System.Diagnostics.Debug.WriteLine("[" + n + "]" + "ID: " + item.Id + " Imie:" + item.Imie + " Nazwisko: " + item.Nazwisko);
                n++;
            }
            System.Diagnostics.Debug.WriteLine("ID: {0} Imie: {1} Nazwisko: {2}", kontakt.Id, kontakt.Imie, kontakt.Nazwisko);
            //Console.WriteLine("ID: {0} Imie: {1} Nazwisko: {2}",kontakt.id,kontakt.imie, kontakt.nazwisko);

            var response = Request.CreateResponse<Kontakt>(System.Net.HttpStatusCode.Created, kontakt);

            return response;
        }
        [HttpGet]
        public IHttpActionResult getProduct(int id)
        {
            List<Kontakt> tmp = komunikat.getLista();
            Kontakt kontakt = tmp.Single(k => k.Id == id);
            if(kontakt == null)
            {
                return NotFound();
            }
            return Ok(kontakt);
            
        }
        
        [HttpDelete]
        public HttpResponseMessage Delete(int Id)
        {
            komunikat = new Komunikacja();
            List<Kontakt> lista = komunikat.kom;
            System.Diagnostics.Debug.WriteLine("Wypisuje liste testowo: ");
            int n = 0;
            foreach (Kontakt item in lista)
            {
                System.Diagnostics.Debug.WriteLine("["+n+"]"+"ID: "+item.Id+" Imie:"+item.Imie+" Nazwisko: "+item.Nazwisko);
                n++;
            }
            Kontakt ko = lista.Single(k => k.Id == Id);
            lista.Remove(ko);
            komunikat.setLista(lista);
            System.Diagnostics.Debug.WriteLine("Dziala cos: {0}", ko.Imie);
            System.Diagnostics.Debug.WriteLine("Wypisuje liste: ");
            n = 0;
            foreach (Kontakt item in lista)
            {
                System.Diagnostics.Debug.WriteLine("["+n+"]"+ item.Imie + " " + item.Nazwisko + " " +item.Id);
                n++;
            }
            var respone = Request.CreateResponse<Kontakt>(System.Net.HttpStatusCode.OK, ko);
            return respone;
        }
    }
}
