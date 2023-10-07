using GestionaleAlbergo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionaleAlbergo.Controllers
{
    [Authorize(Roles = "Admin")]

    public class ClientiController : Controller
    {
        // GET: Clienti
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CreaCliente()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreaCliente(Clienti c)
        {
           
                Clienti.AddClienti(c);
                return RedirectToAction("ListaClienti");
            
        }


        public ActionResult ListaClienti()
        {
            List<Clienti> c=new List<Clienti>();
            c=Clienti.ListClienti();
            return View(c);
        }

        public ActionResult DettaglioClienti(int id) 
        {
            Clienti c =new Clienti();  
            c=Clienti.DettaglioClienti(id);
            return View(c);
        
        }

        public ActionResult ModificaClienti(int id)
        {
            Clienti c = new Clienti();
            c = Clienti.DettaglioClienti(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult ModificaClienti(Clienti c)
        {
            if (ModelState.IsValid)
            {
                Clienti.ModificaClienti(c);
                return RedirectToAction("ListaClienti");
            }
            return View(c);
        }

        public ActionResult Elimina(int id)
        {
            Clienti.Delete(id);
            return RedirectToAction("ListaClienti");
        }
    }
}