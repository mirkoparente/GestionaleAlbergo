using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionaleAlbergo.Models
{
    public class Camere
    {
        public int IdCamere { get; set; }
        public int NumeroCamera { get; set; }
        public string Descrizione { get; set; }
        public string Tipologia { get; set; }


        public static void AddCamere(Camere p)
        {
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Camere values (@NumeroCamera, @Descrizione, @Tipologia)", conn);

                cmd.Parameters.AddWithValue("NumeroCamera", p.NumeroCamera);
                cmd.Parameters.AddWithValue("Descrizione", p.Descrizione);
                cmd.Parameters.AddWithValue("Tipologia", p.Tipologia);
               



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
        public static List<Camere> ListCamere()
        {
            List<Camere> camere = new List<Camere>();
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Camere", conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Camere p = new Camere();

                    p.IdCamere = Convert.ToInt32(reader["IdCamere"]);
                    p.NumeroCamera = Convert.ToInt32(reader["NumeroCamera"].ToString());
                    p.Descrizione = reader["Descrizione"].ToString();
                    p.Tipologia = reader["Tipologia"].ToString();
                   



                    camere.Add(p);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return camere;
        }


        public static Camere DettaglioCamere(int id)
        {
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
            Camere p = new Camere();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"select * from Camere  where IdCamere={id}", conn);


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    p.IdCamere = Convert.ToInt32(reader["IdCamere"]);
                    p.NumeroCamera = Convert.ToInt32(reader["NumeroCamera"].ToString());
                    p.Descrizione = reader["Descrizione"].ToString();
                    p.Tipologia = reader["Tipologia"].ToString();



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



        public static void ModificaCamere(Camere p)
        {
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"update Camere set NumeroCamera=@NumeroCamera, Descrizione = @Descrizione, Tipologia = @Tipologia where IdCamere={p.IdCamere}", conn);


                cmd.Parameters.AddWithValue("NumeroCamera", p.NumeroCamera);
                cmd.Parameters.AddWithValue("Descrizione", p.Descrizione);
                cmd.Parameters.AddWithValue("Tipologia", p.Tipologia);



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
                SqlCommand cmd = new SqlCommand($"delete from Camere where IdClienti={id}", conn);
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