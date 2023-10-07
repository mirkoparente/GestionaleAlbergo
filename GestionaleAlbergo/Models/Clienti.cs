using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GestionaleAlbergo.Models
{
    public class Clienti
    {
        public int IdClienti { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public string Città { get; set; }
        public string Provincia { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }







        public static void AddClienti(Clienti p)
        {
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Clienti values (@Nome, @Cognome, @CodiceFiscale, @Città, @Provincia, @Email, @Telefono, @Cellulare)", conn);

                cmd.Parameters.AddWithValue("Nome", p.Nome);
                cmd.Parameters.AddWithValue("Cognome", p.Cognome);
                cmd.Parameters.AddWithValue("CodiceFiscale", p.CodiceFiscale);
                cmd.Parameters.AddWithValue("Città", p.Città);
                cmd.Parameters.AddWithValue("Provincia", p.Provincia);
                cmd.Parameters.AddWithValue("Email", p.Email);
                cmd.Parameters.AddWithValue("Telefono", p.Telefono);
                cmd.Parameters.AddWithValue("Cellulare", p.Cellulare);



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


        public static List<Clienti> ListClienti()
        {
            List<Clienti> clienti = new List<Clienti>();
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Clienti", conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Clienti p = new Clienti();
                    p.IdClienti = Convert.ToInt32(reader["IdClienti"]);
                    p.Nome = reader["Nome"].ToString();
                    p.Cognome = reader["Cognome"].ToString();
                    p.CodiceFiscale = reader["CodiceFiscale"].ToString();
                    p.Città = reader["Città"].ToString();
                    p.Provincia = reader["Provincia"].ToString();
                    p.Email = reader["Email"].ToString();
                    p.Telefono = reader["Telefono"].ToString();
                    p.Cellulare = reader["Cellulare"].ToString();



                    clienti.Add(p);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return clienti;
        }


        public static Clienti DettaglioClienti(int id)
        {
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
            Clienti p = new Clienti();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"select * from Clienti  where IdClienti={id}", conn);


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    p.IdClienti = Convert.ToInt32(reader["IdClienti"]);
                    p.Nome = reader["Nome"].ToString();
                    p.Cognome = reader["Cognome"].ToString();
                    p.CodiceFiscale = reader["CodiceFiscale"].ToString();
                    p.Città = reader["Città"].ToString();
                    p.Provincia = reader["Provincia"].ToString();
                    p.Email = reader["Email"].ToString();
                    p.Telefono = reader["Telefono"].ToString();
                    p.Cellulare = reader["Cellulare"].ToString();



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

        public static void ModificaClienti(Clienti p)
        {
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"update Clienti set Nome = @Nome, Cognome = @Cognome, Città = @Città,Provincia = @Provincia, Email = @Email, Telefono = @Telefono, Cellulare = @Cellulare WHERE IdClienti={p.IdClienti}", conn);


                cmd.Parameters.AddWithValue("Nome", p.Nome);
                cmd.Parameters.AddWithValue("Cognome", p.Cognome);
                cmd.Parameters.AddWithValue("CodiceFiscale", p.CodiceFiscale);
                cmd.Parameters.AddWithValue("Città", p.Città);
                cmd.Parameters.AddWithValue("Provincia", p.Provincia);
                cmd.Parameters.AddWithValue("Email", p.Email);
                cmd.Parameters.AddWithValue("Telefono", p.Telefono);
                cmd.Parameters.AddWithValue("Cellulare", p.Cellulare);


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
                SqlCommand cmd = new SqlCommand($"delete from Clienti where IdClienti={id}", conn);
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