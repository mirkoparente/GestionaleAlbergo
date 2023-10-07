using GestionaleAlbergo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionaleAlbergo.Controllers
{
    [Authorize(Roles = "Admin")]

    public class ServiziAggiuntiviController : Controller
    {
        public List<SelectListItem> TipoServizio
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                SelectListItem item = new SelectListItem { Text = "Seleziona", Value = "0" };
                SelectListItem item2 = new SelectListItem { Text = "Colazione in Camera", Value = "Colazione in Camera" };
                SelectListItem item3 = new SelectListItem { Text = "WiFi", Value = "WiFi" };
                SelectListItem item4 = new SelectListItem { Text = "Biancheria Extra", Value = "Biancheria Extra" };
                SelectListItem item5 = new SelectListItem { Text = "Letto Aggiuntivo", Value = "Letto Aggiuntivo" };
                SelectListItem item6 = new SelectListItem { Text = "Culla", Value = "Culla" };
                list.Add(item);
                list.Add(item2);
                list.Add(item3);
                list.Add(item4);
                list.Add(item5);
                list.Add(item6);
                return list;
            }
        }
        // GET: ServiziAggiuntivi
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreaServizi()
        {
            ViewBag.tiposervizio = TipoServizio;
            return View();
        }
        [HttpPost]
        public ActionResult CreaServizi(ServiziAggiuntivi c,string tiposervizio)
        {
            c.TipoServizio = tiposervizio;
            ServiziAggiuntivi.AddServizi(c);
            return RedirectToAction("ListaServizi");

        }


        public ActionResult ListaServizi()
        {
            List<ServiziAggiuntivi> c = new List<ServiziAggiuntivi>();
            c = ServiziAggiuntivi.ListServiziAggiuntivi();
            return View(c);
        }

        public ActionResult DettaglioServizi(int id)
        {
            ServiziAggiuntivi c = new ServiziAggiuntivi();
            c = ServiziAggiuntivi.DettaglioServizi(id);
            return View(c);

        }

        public ActionResult ModificaServizi(int id)
        {
            ViewBag.tiposervizio = TipoServizio;
            ServiziAggiuntivi c = new ServiziAggiuntivi();
            c = ServiziAggiuntivi.DettaglioServizi(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult ModificaServizi(ServiziAggiuntivi c,string tiposervizio)
        {
            if (ModelState.IsValid)
            {
                c.TipoServizio = tiposervizio;
                ServiziAggiuntivi.ModificaServizi(c);
                return RedirectToAction("ListaServizi");
            }
            ViewBag.tiposervizio = TipoServizio;
            return View(c);
        }

        public ActionResult Elimina(int id)
        {
            ServiziAggiuntivi.Delete(id);
            return RedirectToAction("ListaServizi");
        }
    }
}