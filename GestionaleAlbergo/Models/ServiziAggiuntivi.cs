using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GestionaleAlbergo.Models
{
    public class ServiziAggiuntivi
    {
        public int IDServizio { get; set; }
        public DateTime Data { get; set; }
        public string TipoServizio { get; set; }
        public int Quantità { get; set; }
        public double Prezzo { get; set; }
        public int IDPrenotazioni { get; set; }




        public static void AddServizi(ServiziAggiuntivi p)
        {
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into ServiziAggiuntivi values (@Data, @TipoServizio, @Quantità, @Prezzo, @IDPrenotazioni)", conn);

                cmd.Parameters.AddWithValue("@Data",DateTime.Now);
                cmd.Parameters.AddWithValue("@TipoServizio", p.TipoServizio);
                cmd.Parameters.AddWithValue("@Quantità", p.Quantità);
                cmd.Parameters.AddWithValue("@Prezzo", p.Prezzo);
                cmd.Parameters.AddWithValue("@IDPrenotazioni", p.IDPrenotazioni);




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
        public static List<ServiziAggiuntivi> ListServiziAggiuntivi()
        {
            List<ServiziAggiuntivi> serviziAggiuntivi = new List<ServiziAggiuntivi>();
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from ServiziAggiuntivi", conn);
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
            return serviziAggiuntivi;
        }


        public static ServiziAggiuntivi DettaglioServizi(int id)
        {
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
            ServiziAggiuntivi p = new ServiziAggiuntivi();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"select * from ServiziAggiuntivi  where IdServizio={id}", conn);


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    p.IDServizio = Convert.ToInt32(reader["IDServizio"]);
                    p.Data = Convert.ToDateTime(reader["Data"]);
                    p.TipoServizio = reader["TipoServizio"].ToString();
                    p.Quantità = Convert.ToInt32(reader["Quantità"]);
                    p.Prezzo = Convert.ToDouble(reader["Prezzo"]);
                    p.IDPrenotazioni = Convert.ToInt32(reader["IDPrenotazioni"]);



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



        public static void ModificaServizi(ServiziAggiuntivi p)
        {
            string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"update ServiziAggiuntivi set Data = @Data, TipoServizio = @TipoServizio,Quantità = @Quantità, Prezzo = @Prezzo, IDPrenotazioni = @IDPrenotazioni where IDServizio = {p.IDServizio}", conn);


                cmd.Parameters.AddWithValue("@Data", DateTime.Now);
                cmd.Parameters.AddWithValue("@TipoServizio", p.TipoServizio);
                cmd.Parameters.AddWithValue("@Quantità", p.Quantità);
                cmd.Parameters.AddWithValue("@Prezzo", p.Prezzo);
                cmd.Parameters.AddWithValue("@IDPrenotazioni", p.IDPrenotazioni);



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
                SqlCommand cmd = new SqlCommand($"delete from ServiziAggiuntivi where IdServizio={id}", conn);
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