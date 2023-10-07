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

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult Login([Bind(Exclude = "IdUser")] Admin a)
        {
          
                string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
                SqlConnection conn = new SqlConnection(connection);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Admin WHERE Username=@Username And Password=@Password", conn);
                    cmd.Parameters.AddWithValue("Username", a.Username);
                    cmd.Parameters.AddWithValue("Password", a.Password);


                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {

                        FormsAuthentication.SetAuthCookie(a.Username, false);
                        return RedirectToAction("Index", "Home");

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

       
    }
}