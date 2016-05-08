using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EXECSQLSERVERSP;
using System.Data;

namespace Login.Models
{
    public class Home
    {
        public string Cadena { get; set; }

        public DataTable ListaContrasena() {
            DataTable dt = new DataTable();
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("@strCadena", this.Cadena);
                dt = SQLSERVER.Query("login", "spRec_Login_ListaPalabras", data, dt);
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }
    }
}