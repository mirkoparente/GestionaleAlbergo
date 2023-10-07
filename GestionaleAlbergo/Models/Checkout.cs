using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionaleAlbergo.Models
{
    public class Checkout
    {
        public int IDPrenotazioni { get; set; }
        public DateTime PeriodoDal { get; set; }
        public DateTime PeriodoAl { get; set; }
        public double Caparra { get; set; }
        public double Prezzo { get; set; }
        public int IDServizio { get; set; }
        public DateTime Data { get; set; }
        public string TipoServizio { get; set; }
        public int Quantità { get; set; }


        [Display(Name ="Totale Servizi")]
        public double TotServizi { get; set; }


        public static Checkout Totale(int id)
        {

            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
                    Checkout p = new Checkout();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"select Prenotazioni.IdPrenotazioni, Prenotazioni.Caparra, Prenotazioni.Prezzo, Sum(ServiziAggiuntivi.Prezzo)as Tot from Prenotazioni inner join Serviziaggiuntivi on  Prenotazioni.IdPrenotazioni=ServiziAggiuntivi.IdPrenotazioni where Prenotazioni.IdPrenotazioni={id} group by Prenotazioni.IdPrenotazioni, Prenotazioni.Caparra, Prenotazioni.Prezzo", conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    p.IDPrenotazioni = Convert.ToInt32(reader["IDPrenotazioni"]);
                    p.Caparra = Convert.ToInt32(reader["Caparra"]);
                    p.Prezzo = Convert.ToInt32(reader["Prezzo"]);
                    p.TotServizi = Convert.ToDouble(reader["Tot"]);


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

    }
}