using GestionaleAlbergo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GestionaleAlbergo.Controllers
{
        [Authorize(Roles ="Admin")]

    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Prenotazioni a) 
        {
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            SqlConnection conn = new SqlConnection(connection);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"select * from Prenotazioni where IdPrenotazioni=@IdPrenotazioni", conn);
                cmd.Parameters.AddWithValue("IdPrenotazioni",a.IDPrenotazioni);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                   
                    return RedirectToAction("Dettagli", new { id = a.IDPrenotazioni });

                }
                else
                {
                    return View();

                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return View();
        }


        public ActionResult Dettagli(int id)
        {
            Prenotazioni prenotazioni = new Prenotazioni();
            prenotazioni=Prenotazioni.DettaglioPrenotazioni(id);
            return View(prenotazioni);
        }


        public ActionResult GetPartialDettagli(int Id)
        {
            List<ServiziAggiuntivi> serviziAggiuntivi = new List<ServiziAggiuntivi>();
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"select * from ServiziAggiuntivi where IdPrenotazioni={Id}", conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    ServiziAggiuntivi p = new ServiziAggiuntivi();
                    p.IDServizio = Convert.ToInt32(reader["IDServizio"]);
                    p.Data = Convert.ToDateTime(reader["Data"]);
                    p.TipoServizio = reader["TipoServizio"].ToString();
                    p.Quantità = Convert.ToInt32(reader["Quantità"]);
                    p.Prezzo = Convert.ToDouble(reader["Prezzo"]);
                    p.IDPrenotazioni = Convert.ToInt32(reader["IDPrenotazioni"]);




                    serviziAggiuntivi.Add(p);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            
            return PartialView("GetPartialDettagli",serviziAggiuntivi);
        }


        public ActionResult GetTotale(int id)
        {
            Checkout c = new Checkout();
            c = Checkout.Totale(id);
            return PartialView("GetTotale",c);
        }
    }
}