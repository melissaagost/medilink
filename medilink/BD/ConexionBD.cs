using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace medilink.BD
{
    internal class ConexionBD : IDisposable
    {
        public static MySqlConnection conexion;
        public static string cadenaConexion;

        public ConexionBD()
        {
            cadenaConexion = "Server=localhost;Port=3307;Database=medilink;User=root;Password=;";
            conexion = new MySqlConnection(cadenaConexion);
        }

        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);  // Nueva conexión en cada llamada
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al abrir la conexión: " + ex.Message);
                throw;
            }

            return conexion;
        }

        public void CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
       
        public void Dispose()
        {
            CerrarConexion(); // Cierra la conexión
            if (conexion != null)
            {
                conexion.Dispose(); // Libera recursos de la conexión
                conexion = null;
            }
        }
    }
}
