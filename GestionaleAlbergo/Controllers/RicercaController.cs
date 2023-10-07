using GestionaleAlbergo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionaleAlbergo.Controllers
{
    public class RicercaController : Controller
    {
        // GET: Ricerca

        
        public ActionResult CercaPrenotazioni()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CercaPrenotazioniCF(string CodiceFiscale)
        {

                List<Prenotazioni> prenotazioni = new List<Prenotazioni>();
                string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connection);

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"select Clienti.Nome,Clienti.Cognome,Clienti.CodiceFiscale,Camere.NumeroCamera,Prenotazioni.* from Prenotazioni inner join Clienti on Prenotazioni.IdClienti=Clienti.IdClienti inner join Camere on Camere.IdCamere=Prenotazioni.IdCamere where Clienti.CodiceFiscale={CodiceFiscale}", conn);
                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        Prenotazioni p = new Prenotazioni();
                        p.IDPrenotazioni = Convert.ToInt32(reader["IDPrenotazioni"]);
                        p.DataPrenotazione = Convert.ToDateTime(reader["DataPrenotazione"]);
                        p.Anno = Convert.ToInt32(reader["Anno"]);
                        p.PeriodoDal = Convert.ToDateTime(reader["PeriodoDal"]);
                        p.PeriodoAl = Convert.ToDateTime(reader["PeriodoAl"]);
                        p.Caparra = Convert.ToDouble(reader["Caparra"]);
                        p.Prezzo = Convert.ToDouble(reader["Prezzo"]);
                        p.Trattamento = reader["Trattamento"].ToString();
                        p.IdClienti = Convert.ToInt32(reader["IdClienti"]);
                        p.IdCamere = Convert.ToInt32(reader["IdCamere"]);
                        p.Nome = reader["Nome"].ToString();
                        p.Cognome = reader["Cognome"].ToString();
                        p.NumeroCamera = Convert.ToInt32(reader["NumeroCamera"]);
                        p.CodiceFiscale = reader["CodiceFiscale"].ToString();


                        prenotazioni.Add(p);
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    conn.Close();
                }
                
            
            return Json(prenotazioni);
        }



        public JsonResult CercaPensione()
        {
            List<Prenotazioni> prenotazioni = new List<Prenotazioni>();
            int tot = 0;
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select count(*) AS Tot FROM Prenotazioni where Trattamento like 'Pensione Completa'", conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    //p.IDPrenotazioni = Convert.ToInt32(reader["IDPrenotazioni"]);
                    //p.DataPrenotazione = Convert.ToDateTime(reader["DataPrenotazione"]);
                    //p.Anno = Convert.ToInt32(reader["Anno"]);
                    //p.PeriodoDal = Convert.ToDateTime(reader["PeriodoDal"]);
                    //p.PeriodoAl = Convert.ToDateTime(reader["PeriodoAl"]);
                    //p.Caparra = Convert.ToDouble(reader["Caparra"]);
                    //p.Prezzo = Convert.ToDouble(reader["Prezzo"]);
                    //p.Trattamento = reader["Trattamento"].ToString();
                    //p.IdClienti = Convert.ToInt32(reader["IdClienti"]);
                    //p.IdCamere = Convert.ToInt32(reader["IdCamere"]);
                    //p.Nome = reader["Nome"].ToString();
                    //p.Cognome = reader["Cognome"].ToString();
                    //p.NumeroCamera = Convert.ToInt32(reader["NumeroCamera"]);
                    //p.CodiceFiscale = reader["CodiceFiscale"].ToString();
                    tot = Convert.ToInt32(reader["Tot"]);


                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return Json(tot, JsonRequestBehavior.AllowGet);
        }
    }
}