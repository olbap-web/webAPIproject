using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPI.Models;

namespace webAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        private ConexionSQL conect;

        public ConexionSQL Conect { get=>conect; set=>conect=value; }


        public string configurarConexion()
        {
            try
            {
                this.Conect = new ConexionSQL();
                this.Conect.NombreBaseDatos = "EmployeeDB";
                this.Conect.NombreTabla = "Department";
                this.Conect.CadenaConexion = @"Data Source=.;Initial Catalog=EmployeeDB;Integrated Security=True";

            }
            catch (Exception ex)
            {
                return (" Mensaje Sistema" + ex.Message);
            }
            return "conexion exitosa";
        }//finConfigurarConexion    

        public HttpResponseMessage Get()
        {
            this.configurarConexion();
            this.Conect.CadenaSQL = "SELECT * FROM " + this.Conect.NombreTabla;
            this.Conect.EsSelect = true;
            this.Conect.conectar();

            var table = this.Conect.DbDataSet.Tables["Department"];

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

    }
}
