using GestionaleAlbergo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionaleAlbergo.Controllers
{
    [Authorize(Roles = "Admin")]

    public class PrenotazioniController : Controller
    {

        public List<SelectListItem> Trattamento
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                SelectListItem item = new SelectListItem { Text = "Seleziona", Value = "0" };
                SelectListItem item2 = new SelectListItem { Text = "Pernotto", Value = "Pernotto" };
                SelectListItem item3 = new SelectListItem { Text = "Prima Colazione", Value = "Prima Colazione" };
                SelectListItem item4 = new SelectListItem { Text = "Mezza Pensione", Value = "Mezza Pensione" };
                SelectListItem item5 = new SelectListItem { Text = "Pensione Completa", Value = "Pensione Completa" };
                list.Add(item);
                list.Add(item2);
                list.Add(item3);
                list.Add(item4);
                list.Add(item5);
                return list;
            }
        }
        // GET: Prenotazioni
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreaPrenotazione()
        {
            ViewBag.trattamento = Trattamento;

            return View();
        }
        [HttpPost]
        public ActionResult CreaPrenotazione(Prenotazioni c,string trattamento)
        {
            c.Trattamento = trattamento;
            Prenotazioni.AddPrenotazioni(c);
            return RedirectToAction("ListaPrenotazioni");

        }
        public ActionResult ListaPrenotazioni()
        {
            List<Prenotazioni> c = new List<Prenotazioni>();
            c = Prenotazioni.ListPrenotazioni();
            return View(c);
        }

        public ActionResult DettaglioPrenotazioni(int id)
        {
            Prenotazioni c = new Prenotazioni();
            c = Prenotazioni.DettaglioPrenotazioni(id);
            return View(c);

        }

        public ActionResult ModificaPrenotazione(int id)
        {
            ViewBag.trattamento = Trattamento;
            Prenotazioni c = new Prenotazioni();
            c = Prenotazioni.DettaglioPrenotazioni(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult ModificaPrenotazione(Prenotazioni c,string trattamento)
        {
            if (ModelState.IsValid)
            {
                c.Trattamento= trattamento;
                Prenotazioni.ModificaPrenotazioni(c);
                return RedirectToAction("ListaPrenotazioni");
            }
            ViewBag.trattamento = Trattamento;
            return View(c);
        }

        public ActionResult Elimina(int id)
        {
            Prenotazioni.Delete(id);
            return RedirectToAction("ListaPrenotazioni");
        }

    }
}