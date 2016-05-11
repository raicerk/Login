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
        public string Usuario { get; set; }
        public string Contrasena { get; set; }

        public DataTable ListaContrasena() {
            DataTable dt = new DataTable();
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("@strUsuario", this.Cadena);
                dt = SQLSERVER.Query("login", "spRec_Login_ListaPalabras", data, dt);
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }

        public bool CreaUsuario() {
            try
            {
                Dictionary<string, string> Data = new Dictionary<string, string>();
                Data.Add("@Usuario",this.Usuario);
                Data.Add("@Contrasena", this.Contrasena);
                SQLSERVER.Query("login", "spRec_Login_CreaUsuario", Data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CargaCadenas() {
            bool estado = false;
            DataTable dt = new DataTable();
            Dictionary<string, string> Data = new Dictionary<string, string>();
            Data.Add("@Usuario", this.Cadena);
            Data.Add("@Contrasena", this.Contrasena);
            dt = SQLSERVER.Query("login","spRec_Login_ValidaUsuario",Data,dt);
            foreach (DataRow item in dt.Rows)
            {
                estado = bool.Parse(item["Validado"].ToString());
            }
            return estado;
        }
    }
}