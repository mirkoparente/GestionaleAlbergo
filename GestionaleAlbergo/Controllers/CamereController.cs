using GestionaleAlbergo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionaleAlbergo.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CamereController : Controller
    {
        public List<SelectListItem> Tipologia
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                SelectListItem item = new SelectListItem { Text = "Seleziona", Value = "0" };
                SelectListItem item2 = new SelectListItem { Text = "Singola", Value = "Singola" };
                SelectListItem item3 = new SelectListItem { Text = "Doppia", Value = "Doppia" };
                SelectListItem item4 = new SelectListItem { Text = "Tripla", Value = "Tripla" };
                SelectListItem item5 = new SelectListItem { Text = "Quadrupla", Value = "Quadrupla" };
                list.Add(item);
                list.Add(item2);
                list.Add(item3);
                list.Add(item4);
                list.Add(item5);
                return list;
            }
        }
        // GET: Camere
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreaCamere()
        {
            ViewBag.tipologia = Tipologia;
            return View();
        }
        [HttpPost]
        public ActionResult CreaCamere(Camere c,string tipologia)
        {
            c.Tipologia = tipologia;
            Camere.AddCamere(c);
            return RedirectToAction("ListaCamere");

        }


        public ActionResult ListaCamere()
        {
            List<Camere> c = new List<Camere>();
            c = Camere.ListCamere();
            return View(c);
        }

        public ActionResult DettaglioCamere(int id)
        {
            Camere c = new Camere();
            c = Camere.DettaglioCamere(id);
            return View(c);

        }

        public ActionResult ModificaCamere(int id)
        {
            ViewBag.tipologia = Tipologia;
            Camere c = new Camere();
            c = Camere.DettaglioCamere(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult ModificaCamere(Camere c,string tipologia)
        {
            if (ModelState.IsValid)
            {
                c.Tipologia = tipologia;
                Camere.ModificaCamere(c);
                return RedirectToAction("ListaCamere");
            }

            ViewBag.tipologia=Tipologia;
            return View(c);
        }

        public ActionResult Elimina(int id)
        {
            Camere.Delete(id);
            return RedirectToAction("ListaCamere");
        }
    }
}