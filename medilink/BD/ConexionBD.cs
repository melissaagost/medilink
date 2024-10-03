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
        private MySqlConnection conexion;
        private string cadenaConexion;

        public ConexionBD()
        {
            cadenaConexion = "Server=localhost;Port=3307;Database=medilink;User=root;Password=;";
            conexion = new MySqlConnection(cadenaConexion);
        }

        public MySqlConnection ObtenerConexion()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                    Console.WriteLine("Conexión a la base de datos establecida exitosamente.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: No se pudo establecer conexión a la base de datos." + ex.Message);
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
        // Implementación del método Dispose
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
