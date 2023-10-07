using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionaleAlbergo.Models
{
    public class Admin
    {
        public int IdAdmin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Ruolo { get; set; }
    }
}