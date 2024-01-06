using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Usersapp.Datos
{
    internal static class CONEXIONMAESTRA
    {
        public static SqlConnection conexion = new SqlConnection(@"Data source=GARBOX0\SQLEXPRESS; Initial Catalog=ProyectoXamarin; Integrated Security=true");
        public static void abrir()
        {
            if (conexion.State == ConnectionState.Closed ) 
            { 
                conexion.Open(); 
            }
        }
        public static void cerrar()
        {
            if (conexion.State == ConnectionState.Open ) 
            { 
                conexion.Close(); 
            }
        }
    }
}    