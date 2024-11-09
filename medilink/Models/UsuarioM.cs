using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medilink.Models
{
    public class UsuarioM
    {
        //delegacion de responsabilidades: el usuario se "autocrea" leyendo los datos de la BD
        public static UsuarioM UserFromTableRow(MySqlDataReader reader)
        {
            return new UsuarioM
            {
                id_usuario = Convert.ToInt32(reader["id_usuario"]),
                dni = Convert.ToInt32(reader["dni"]),
                id_perfil = Convert.ToInt32(reader["id_perfil"]),
                usuario = reader["usuario"].ToString(),
                nombre = reader["nombre"].ToString(),
                apellido = reader["apellido"].ToString(),
                correo = reader["correo"].ToString(),
                status = reader["status"].ToString(),
                id_provincia = Convert.ToInt32(reader["id_provincia"]),
                id_ciudad = Convert.ToInt32(reader["id_ciudad"]),
                contraseña = reader["contraseña"].ToString(),
                fecha_nacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]),
                direccion = reader["direccion"].ToString(),
                telefono = reader["telefono"].ToString()
            };
        }

        public int id_usuario { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string usuario { get; set; }

        public string contraseña { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public string status { get; set; }
        public int id_provincia { get; set; }
        public int id_ciudad { get; set; }
        public int id_perfil { get; set; }
        //public int? id_medico { get; set; }
    }
}
