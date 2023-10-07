using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace GestionaleAlbergo.Models
{
    public class Prenotazioni
    {
        public int IDPrenotazioni { get; set; }
        public DateTime DataPrenotazione { get; set; }
        public int Anno { get; set; }
        public DateTime PeriodoDal { get; set; }
        public DateTime PeriodoAl { get; set; }
        public double Caparra { get; set; }
        public double Prezzo { get; set; }
        public string Trattamento { get; set; }

        [Display(Name ="Cliente")]
        public int IdClienti { get; set; }

        [Display(Name ="N Stanza")]
        public int IdCamere { get; set; }


        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int NumeroCamera { get; set; }

        public string CodiceFiscale { get; set; }

        public int Tot {  get; set; }


        public static void AddPrenotazioni(Prenotazioni p)
        {
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Prenotazioni values (@DataPrenotazione, @Anno, @PeriodoDal, @PeriodoAl, @Caparra, @Prezzo, @Trattamento, @IdClienti, @IdCamere)", conn);


                cmd.Parameters.AddWithValue("@DataPrenotazione", DateTime.Now);
                cmd.Parameters.AddWithValue("@Anno",DateTime.Now.Year);
                cmd.Parameters.AddWithValue("@PeriodoDal",p.PeriodoDal);
                cmd.Parameters.AddWithValue("@PeriodoAl",p.PeriodoAl);
                cmd.Parameters.AddWithValue("@Caparra",p.Caparra);
                cmd.Parameters.AddWithValue("@Prezzo",p.Prezzo);
                cmd.Parameters.AddWithValue("@Trattamento",p.Trattamento);
                cmd.Parameters.AddWithValue("@IdClienti",p.IdClienti);
                cmd.Parameters.AddWithValue("@IdCamere",p.IdCamere);




                cmd.ExecuteNonQuery();



            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }


        }
        public static List<Prenotazioni> ListPrenotazioni()
        {
            List<Prenotazioni> prenotazioni = new List<Prenotazioni>();
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select Clienti.Nome,Clienti.Cognome,Camere.NumeroCamera,Prenotazioni.* from Prenotazioni inner join Clienti on Prenotazioni.IdClienti=Clienti.IdClienti inner join Camere on Camere.IdCamere=Prenotazioni.IdCamere", conn);
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
            return prenotazioni;
        }


        public static Prenotazioni DettaglioPrenotazioni(int id)
        {
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
            Prenotazioni p = new Prenotazioni();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"select * from Prenotazioni inner join Camere on Prenotazioni.IdCamere=Camere.IdCamere  where IdPrenotazioni={id}", conn);


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

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
                    p.NumeroCamera = Convert.ToInt32(reader["NumeroCamera"]);



                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return p;
        }



        public static void ModificaPrenotazioni(Prenotazioni p)
        {
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"update Prenotazioni set DataPrenotazione = @DataPrenotazione,Anno = @Anno, PeriodoDal = @PeriodoDal, PeriodoAl = @PeriodoAl,Caparra = @Caparra, Prezzo = @Prezzo, Trattamento = @Trattamento,IdClienti = @IdClienti, IdCamere = @IdCamere where IDPrenotazioni = {p.IDPrenotazioni}", conn);


                cmd.Parameters.AddWithValue("@DataPrenotazione", p.DataPrenotazione);
                cmd.Parameters.AddWithValue("@Anno", p.Anno);
                cmd.Parameters.AddWithValue("@PeriodoDal", p.PeriodoDal);
                cmd.Parameters.AddWithValue("@PeriodoAl", p.PeriodoAl);
                cmd.Parameters.AddWithValue("@Caparra", p.Caparra);
                cmd.Parameters.AddWithValue("@Prezzo", p.Prezzo);
                cmd.Parameters.AddWithValue("@Trattamento", p.Trattamento);
                cmd.Parameters.AddWithValue("@IdClienti", p.IdClienti);
                cmd.Parameters.AddWithValue("@IdCamere", p.IdCamere);



                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public static void Delete(int id)
        {
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"delete from Prenotazioni where IdPrenotazioni={id}", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
        }
    }
}