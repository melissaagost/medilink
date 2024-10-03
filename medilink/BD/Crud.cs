using medilink.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medilink.BD
{
    public class Crud
    {

        //regsitro de un user
        public bool Registrar(UsuarioM usuario)
        {
            bool resultado = false;
            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    oconexion.Open();
                    using (MySqlCommand comando = new MySqlCommand("INSERT INTO Usuarios (dni, nombre, apellido, usuario, contraseña, fecha_nacimiento, telefono, correo, direccion, status, id_provincia, id_ciudad, id_perfil) VALUES (@dni, @nombre, @apellido, @usuario, @contraseña, @fecha_nacimiento, @telefono, @correo, @direccion, @status, @id_provincia, @id_ciudad, @id_perfil)", oconexion))
                    {
                        comando.Parameters.AddWithValue("@dni", usuario.dni);
                        comando.Parameters.AddWithValue("@nombre", usuario.nombre);
                        comando.Parameters.AddWithValue("@apellido", usuario.apellido);
                        comando.Parameters.AddWithValue("@usuario", usuario.usuario);
                        comando.Parameters.AddWithValue("@contraseña", usuario.contraseña);
                        comando.Parameters.AddWithValue("@fecha_nacimiento", usuario.fecha_nacimiento);
                        comando.Parameters.AddWithValue("@telefono", usuario.telefono);
                        comando.Parameters.AddWithValue("@correo", usuario.correo);
                        comando.Parameters.AddWithValue("@direccion", usuario.direccion);
                        comando.Parameters.AddWithValue("@status", "si");
                        comando.Parameters.AddWithValue("@id_provincia", usuario.id_provincia);
                        comando.Parameters.AddWithValue("@id_ciudad", usuario.id_ciudad);
                        comando.Parameters.AddWithValue("@id_perfil", usuario.id_perfil);

                        int filasAfectadas = comando.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al registrar usuario" + ex.Message);
            }
            return resultado;

        }
    }
}
