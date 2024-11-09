using medilink.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medilink.BD
{
    public class Crud
    {

        //regsitro de un user y si es medico lo almacena en la tabla medico (contexto: usado por sistemas)
        public static bool Registrar(UsuarioM usuario, int idEspecialidad, int idTurno, out string mensajeError)
        {
            bool resultado = false;
            mensajeError = "";

            using (MySqlConnection oconexion = ConexionBD.ObtenerConexion()) 
            {
                if (oconexion.State == ConnectionState.Closed)
                {
                    oconexion.Open();
                }

                using (MySqlTransaction transaccion = oconexion.BeginTransaction())
                {
                    try
                    {
                        // Primero, verificar si el DNI, correo, teléfono o usuario ya existen en la base de datos
                        string queryVerificacion = @"SELECT COUNT(*) FROM Usuario 
                                             WHERE dni = @dni OR correo = @correo OR telefono = @telefono OR usuario = @usuario";

                        MySqlCommand comandoVerificacion = new MySqlCommand(queryVerificacion, oconexion, transaccion);
                        comandoVerificacion.Parameters.AddWithValue("@dni", usuario.dni);
                        comandoVerificacion.Parameters.AddWithValue("@correo", usuario.correo);
                        comandoVerificacion.Parameters.AddWithValue("@telefono", usuario.telefono);
                        comandoVerificacion.Parameters.AddWithValue("@usuario", usuario.usuario);

                        int count = Convert.ToInt32(comandoVerificacion.ExecuteScalar());

                        if (count > 0)
                        {
                            // Si el registro ya existe, configurar el mensaje de error y retornar
                            mensajeError = "El DNI, correo, teléfono o usuario ya están registrados.";
                            transaccion.Rollback();
                            return false;
                        }

                        // Si no hay conflictos, insertar el usuario
                        string queryUsuario = @"INSERT INTO Usuario (dni, nombre, apellido, usuario, contraseña, 
                                        fecha_nacimiento, telefono, correo, direccion, status, id_provincia, 
                                        id_ciudad, id_perfil) 
                                        VALUES (@dni, @nombre, @apellido, @usuario, @contraseña, 
                                        @fecha_nacimiento, @telefono, @correo, @direccion, 'si', 
                                        @id_provincia, @id_ciudad, @id_perfil)";

                        MySqlCommand comandoUsuario = new MySqlCommand(queryUsuario, oconexion, transaccion);
                        comandoUsuario.Parameters.AddWithValue("@dni", usuario.dni);
                        comandoUsuario.Parameters.AddWithValue("@nombre", usuario.nombre);
                        comandoUsuario.Parameters.AddWithValue("@apellido", usuario.apellido);
                        comandoUsuario.Parameters.AddWithValue("@usuario", usuario.usuario);
                        comandoUsuario.Parameters.AddWithValue("@contraseña", usuario.contraseña);
                        comandoUsuario.Parameters.AddWithValue("@fecha_nacimiento", usuario.fecha_nacimiento);
                        comandoUsuario.Parameters.AddWithValue("@telefono", usuario.telefono);
                        comandoUsuario.Parameters.AddWithValue("@correo", usuario.correo);
                        comandoUsuario.Parameters.AddWithValue("@direccion", usuario.direccion);
                        comandoUsuario.Parameters.AddWithValue("@id_provincia", usuario.id_provincia);
                        comandoUsuario.Parameters.AddWithValue("@id_ciudad", usuario.id_ciudad);
                        comandoUsuario.Parameters.AddWithValue("@id_perfil", usuario.id_perfil);

                        comandoUsuario.ExecuteNonQuery();

                        long idUsuarioInsertado = comandoUsuario.LastInsertedId;

                        // Verificar si el perfil del usuario es médico (id_perfil == 3)
                        if (usuario.id_perfil == 3)
                        {
                            string queryMedico = "INSERT INTO Medico (id_usuario, id_especialidad, id_turno) VALUES (@id_usuario, @id_especialidad, @id_turno)";

                            MySqlCommand comandoMedico = new MySqlCommand(queryMedico, oconexion, transaccion);
                            comandoMedico.Parameters.AddWithValue("@id_usuario", idUsuarioInsertado);
                            comandoMedico.Parameters.AddWithValue("@id_especialidad", idEspecialidad);
                            comandoMedico.Parameters.AddWithValue("@id_turno", idTurno);

                            comandoMedico.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                        resultado = true;
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        mensajeError = "Error al registrar usuario y/o médico: " + ex.Message;
                        throw;
                    }
                }
            }

            return resultado;
        }



        public List<UsuarioM> Listar(int? idPerfil = null)
        {
            List<UsuarioM> listaUsuarios = new List<UsuarioM>();
            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    // Construir la consulta SQL con base en los filtros
                    string query = "SELECT * FROM Usuario WHERE 1=1"; // 1=1 para facilitar la adición de filtros

                    if (idPerfil.HasValue)
                    {
                        query += " AND id_perfil = @idPerfil";
                    }

                    using (MySqlCommand comando = new MySqlCommand(query, oconexion))
                    {
                        if (idPerfil.HasValue)
                        {
                            comando.Parameters.AddWithValue("@idPerfil", idPerfil.Value);
                        }

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaUsuarios.Add(new UsuarioM()
                                {
                                    dni = (int)reader["dni"],
                                    nombre = reader["nombre"].ToString(),
                                    apellido = reader["apellido"].ToString(),
                                    usuario = reader["usuario"].ToString(),
                                    id_perfil = (int)reader["id_perfil"],
                                    id_usuario = (int)reader["id_usuario"],
                                    status = reader["status"].ToString(),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar usuarios: " + ex.Message);
            }
            return listaUsuarios;
        }


        //Dar de baja un user (contexto: usado por sistemas y gestor)
        public bool Baja(int id_usuario)
        {
            bool resultado = false;
            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    using (MySqlCommand comando = new MySqlCommand("UPDATE Usuario SET status = @status WHERE id_usuario = @id_usuario", oconexion))
                    {
                        comando.Parameters.AddWithValue("@status", "no");
                        comando.Parameters.AddWithValue("@id_usuario", id_usuario);

                        int filasAfectadas = comando.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al dar de baja el usuario" + ex.Message);
            }
            return resultado;
        }

        //dar de alta un user (contexto: usado por sistemas y gestor)
        public bool Alta(int id_usuario)
        {
            bool resultado = false;
            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    using (MySqlCommand comando = new MySqlCommand("UPDATE Usuario SET status = @status WHERE id_usuario = @id_usuario", oconexion))
                    {
                        comando.Parameters.AddWithValue("@status", "si");
                        comando.Parameters.AddWithValue("@id_usuario", id_usuario);

                        int filasAfectadas = comando.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al dar de alta el usuario" + ex.Message);
            }
            return resultado;
        }


        //editar perfil (todos los perfiles/roles pueden usar)
        public bool EditarPerfil(UsuarioM usuario)
        {
            bool resultado = false;
            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    using (MySqlCommand comando = new MySqlCommand("UPDATE Usuario SET  usuario = @usuario, direccion = @direccion, correo = @correo, telefono = @telefono, contraseña = @contraseña WHERE id_usuario = @id_usuario", oconexion))
                    {
                        

                        comando.Parameters.AddWithValue("@usuario", usuario.usuario);
                        comando.Parameters.AddWithValue("@direccion", usuario.direccion);
                        comando.Parameters.AddWithValue("@correo", usuario.correo);
                        comando.Parameters.AddWithValue("@telefono", usuario.telefono);
                        comando.Parameters.AddWithValue("@contraseña", usuario.contraseña);
                        comando.Parameters.AddWithValue("@id_usuario", usuario.id_usuario);

                        int filasAfectadas = comando.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al editar perfil." + ex.Message);
            }
            return resultado;
        }


        //obteiene el user logueado y lo actualiza luego de editar perfil
        public UsuarioM ObtenerUsuarioPorId(int idUsuario)
        {
            UsuarioM usuario = null;
            try
            {
                using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
                {
                    if (conexion.State == ConnectionState.Closed)
                    {
                        conexion.Open();
                    }

                    string query = "SELECT id_usuario, usuario, correo, direccion, telefono, contraseña FROM Usuario WHERE id_usuario = @id_usuario";
                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@id_usuario", idUsuario);

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuario = new UsuarioM
                                {
                                    id_usuario = reader.GetInt32("id_usuario"),
                                    usuario = reader.GetString("usuario"),
                                    correo = reader.GetString("correo"),
                                    direccion = reader.GetString("direccion"),
                                    telefono = reader.GetString("telefono"),
                                    contraseña = reader.GetString("contraseña")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el usuario por ID: " + ex.Message);
            }

            return usuario;
        }
        

        //recueperar contraseña
        public static bool ValidarCredencial(string credencial)
        {
            bool resultado = false;

            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    
                    string query = "SELECT COUNT(*) FROM usuario WHERE correo = @credencial OR telefono = @credencial";
                    using (MySqlCommand comando = new MySqlCommand(query, oconexion))
                    {
                        comando.Parameters.AddWithValue("@credencial", credencial);

                        int count = Convert.ToInt32(comando.ExecuteScalar());
                        if (count > 0)
                        {
                            resultado = true; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al validar credencial: " + ex.Message);
            }

            return resultado;
        }


        //cambiar contraseña
        public static bool CambiarContrasena(string credencial, string nuevaContrasena)
        {
            bool resultado = false;

            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                   
                    string queryCheck = "SELECT contraseña FROM usuario WHERE correo = @credencial OR telefono = @credencial";
                    using (MySqlCommand comandoCheck = new MySqlCommand(queryCheck, oconexion))
                    {
                        comandoCheck.Parameters.AddWithValue("@credencial", credencial);
                        object currentPassword = comandoCheck.ExecuteScalar();

                        if (currentPassword != null && currentPassword.ToString() == nuevaContrasena)
                        {
                            Console.WriteLine("La nueva contraseña no puede ser la misma que la actual.");
                            return false; 
                        }
                    }

                    
                    string query = "UPDATE usuario SET contraseña = @nuevaContrasena WHERE correo = @credencial OR telefono = @credencial";
                    using (MySqlCommand comando = new MySqlCommand(query, oconexion))
                    {
                        comando.Parameters.AddWithValue("@nuevaContrasena", nuevaContrasena);
                        comando.Parameters.AddWithValue("@credencial", credencial);

                        int rowsAffected = comando.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            resultado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al reestablecer contraseña: " + ex.Message);
            }

            return resultado;
        }

        //agendar cita (contexto: usado por recep)
        public static bool Programar(CitaM cita)
        { bool resultado = false;
            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    using (MySqlCommand comando = new MySqlCommand("INSERT INTO Cita (fecha, motivo, status, id_paciente, id_medico) VALUES (@fecha, @motivo, @status, @id_paciente, @id_medico)", oconexion))
                    {
                        comando.Parameters.AddWithValue("@fecha", cita.fecha);
                        comando.Parameters.AddWithValue("@motivo", cita.motivo);
                        comando.Parameters.AddWithValue("@status", "activa");
                        comando.Parameters.AddWithValue("id_paciente", cita.id_paciente);
                        comando.Parameters.AddWithValue("@id_medico", cita.id_medico);


                        int filasAfectadas = comando.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al programar cita." + ex.Message);
            }
            return resultado;
        }

        public bool ReprogramarCita(int id_cita, DateTime nuevaFecha)
        {
            bool resultado = false;
            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    using (MySqlCommand comando = new MySqlCommand(
                        "UPDATE Cita SET fecha = @fecha, status = 'activa' WHERE id_cita = @id_cita", oconexion))
                    {
                        comando.Parameters.AddWithValue("@fecha", nuevaFecha);
                        comando.Parameters.AddWithValue("@id_cita", id_cita);

                        int filasAfectadas = comando.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al reprogramar la cita: " + ex.Message);
            }

            return resultado;
        }

        public static bool VerificarDisponibilidadMedico(int idMedico, DateTime fechaHora)
        {
            bool disponible = true;

            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    // Consulta para verificar si hay citas activas para el médico en esa fecha y hora específica
                    string query = "SELECT COUNT(*) FROM Cita WHERE id_medico = @idMedico " +
                                   "AND DATE(fecha) = DATE(@fecha) AND status = 'activa'";

                    using (MySqlCommand comando = new MySqlCommand(query, oconexion))
                    {
                        comando.Parameters.AddWithValue("@idMedico", idMedico);
                        comando.Parameters.AddWithValue("@fecha", fechaHora);

                        int count = Convert.ToInt32(comando.ExecuteScalar());
                        // Si el conteo es mayor a 0, significa que el médico ya tiene una cita en esa fecha y hora exacta
                        if (count > 0)
                        {
                            disponible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar la disponibilidad del médico: " + ex.Message);
                disponible = false;
            }

            return disponible;
        }




        //cancelar cita (contexto: usado por recep y medico)
        public static bool Cancelar(int id_cita)
        {
            bool resultado = false;
            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    using (MySqlCommand comando = new MySqlCommand("UPDATE Cita SET status = 'cancelada' WHERE id_cita = @id_cita", oconexion))
                    {
                        comando.Parameters.AddWithValue("@status", "cancelada");
                        comando.Parameters.AddWithValue("@id_cita", id_cita);

                        int filasAfectadas = comando.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cancelar cita." + ex.Message);
            }
            return resultado;
        }

        //completar cita cita (contexto: usado por medico)
        public static bool Completar(int id_cita)
        {
            bool resultado = false;
            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    using (MySqlCommand comando = new MySqlCommand("UPDATE Cita SET status = 'completada' WHERE id_cita = @id_cita", oconexion))
                    {
                        comando.Parameters.AddWithValue("@status", "completada");
                        comando.Parameters.AddWithValue("@id_cita", id_cita);

                        int filasAfectadas = comando.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al marcar cita como completada." + ex.Message);
            }
            return resultado;
        }

        //listar citas (contexto: usado por recep)
        public static List<CitaM> ListarCitas(int? idMedico = null, int? idPaciente = null)
        {
            List<CitaM> listaCitas = new List<CitaM>();

            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                // Consulta base
                string query = "SELECT c.id_cita, c.fecha, c.motivo, c.status, c.id_medico, c.id_paciente, " +
                               "p.nombre AS paciente_nombre, u.nombre AS medico_nombre " +
                               "FROM Cita c " +
                               "INNER JOIN Medico m ON c.id_medico = m.id_medico " +
                               "INNER JOIN Paciente p ON c.id_paciente = p.id_paciente " +
                               "INNER JOIN Usuario u ON m.id_usuario = u.id_usuario " +
                               "WHERE 1=1"; 

                
                if (idMedico.HasValue)
                {
                    query += " AND c.id_medico = @idMedico";
                }

                if (idPaciente.HasValue)
                {
                    query += " AND c.id_paciente = @idPaciente";
                }

                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    if (idMedico.HasValue)
                    {
                        comando.Parameters.AddWithValue("@idMedico", idMedico.Value);
                    }

                    if (idPaciente.HasValue)
                    {
                        comando.Parameters.AddWithValue("@idPaciente", idPaciente.Value);
                    }

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaCitas.Add(new CitaM
                            {
                                id_cita = Convert.ToInt32(reader["id_cita"]),
                                fecha = Convert.ToDateTime(reader["fecha"]),
                                motivo = reader["motivo"].ToString(),
                                status = reader["status"].ToString(),
                                id_medico = Convert.ToInt32(reader["id_medico"]),
                                id_paciente = Convert.ToInt32(reader["id_paciente"]),
                                paciente_nombre = reader["paciente_nombre"].ToString(),
                                medico_nombre = reader["medico_nombre"].ToString()
                            });
                        }
                    }
                }
            }

            return listaCitas;
        }


        //listar citas asociadas a un medico
        internal static List<CitaM> ListarCitasPorMedico(int idUsuarioLogueado, int? idMedico = null, int? idPaciente = null)
        {
            List<CitaM> listaCitas = new List<CitaM>();

            using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
            {
                if (oconexion.State == ConnectionState.Closed)
                {
                    oconexion.Open();
                }

                string query = "SELECT c.id_cita, c.fecha, c.motivo, c.status, p.id_paciente, p.nombre AS paciente_nombre, m.id_medico " +
                               "FROM Cita c " +
                               "INNER JOIN Medico m ON c.id_medico = m.id_medico " +
                               "INNER JOIN Paciente p ON c.id_paciente = p.id_paciente " +
                               "INNER JOIN Usuario u ON m.id_usuario = u.id_usuario " +
                               "WHERE u.id_usuario = @idUsuarioLogueado";

                
                if (idMedico.HasValue)
                {
                    query += " AND c.id_medico = @idMedico";
                }

                if (idPaciente.HasValue)
                {
                    query += " AND c.id_paciente = @idPaciente";
                }

                using (MySqlCommand comando = new MySqlCommand(query, oconexion))
                {
                    // Asignación del parámetro obligatorio
                    comando.Parameters.AddWithValue("@idUsuarioLogueado", idUsuarioLogueado);

                    // Asignación de parámetros opcionales
                    if (idMedico.HasValue)
                    {
                        comando.Parameters.AddWithValue("@idMedico", idMedico.Value);
                    }

                    if (idPaciente.HasValue)
                    {
                        comando.Parameters.AddWithValue("@idPaciente", idPaciente.Value);
                    }

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaCitas.Add(new CitaM
                            {
                                id_medico = Convert.ToInt32(reader["id_medico"]),
                                id_paciente = Convert.ToInt32(reader["id_paciente"]),
                                id_cita = Convert.ToInt32(reader["id_cita"]),
                                fecha = Convert.ToDateTime(reader["fecha"]),
                                motivo = reader["motivo"].ToString(),
                                status = reader["status"].ToString(),
                                paciente_nombre = reader["paciente_nombre"].ToString()
                            });
                        }
                    }
                }
            }

            return listaCitas;
        }



        public static bool RegistrarPaciente(PacienteM paciente, out string mensajeError)
        {
            bool resultado = false;
            mensajeError = "";

            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    string queryVerificacion = @"SELECT COUNT(*) FROM Paciente 
                                         WHERE dni = @dni OR correo = @correo OR telefono = @telefono";

                    using (MySqlCommand comandoVerificacion = new MySqlCommand(queryVerificacion, oconexion))
                    {
                        comandoVerificacion.Parameters.AddWithValue("@dni", paciente.dni);
                        comandoVerificacion.Parameters.AddWithValue("@correo", paciente.correo);
                        comandoVerificacion.Parameters.AddWithValue("@telefono", paciente.telefono);

                        int count = Convert.ToInt32(comandoVerificacion.ExecuteScalar());

                        if (count > 0)
                        {
                            mensajeError = "El DNI, correo o teléfono ya están registrados para otro paciente.";
                            return false;
                        }
                    }

                    string queryInsert = @"INSERT INTO Paciente (dni, nombre, apellido, genero, fecha_nacimiento, correo, telefono, 
                                  direccion, edad, status, id_obra_social, id_ciudad, id_provincia) 
                                  VALUES (@dni, @nombre, @apellido, @genero, @fecha_nacimiento, @correo, @telefono, 
                                  @direccion, @edad, 'si', @id_obra_social, @id_ciudad, @id_provincia)";

                    using (MySqlCommand comandoInsert = new MySqlCommand(queryInsert, oconexion))
                    {
                        comandoInsert.Parameters.AddWithValue("@dni", paciente.dni);
                        comandoInsert.Parameters.AddWithValue("@nombre", paciente.nombre);
                        comandoInsert.Parameters.AddWithValue("@apellido", paciente.apellido);
                        comandoInsert.Parameters.AddWithValue("@genero", paciente.genero);
                        comandoInsert.Parameters.AddWithValue("@fecha_nacimiento", paciente.fecha_nacimiento);
                        comandoInsert.Parameters.AddWithValue("@correo", paciente.correo);
                        comandoInsert.Parameters.AddWithValue("@telefono", paciente.telefono);
                        comandoInsert.Parameters.AddWithValue("@direccion", paciente.direccion);
                        comandoInsert.Parameters.AddWithValue("@edad", paciente.edad);
                        comandoInsert.Parameters.AddWithValue("@id_obra_social", paciente.id_obra_social);
                        comandoInsert.Parameters.AddWithValue("@id_ciudad", paciente.id_ciudad);
                        comandoInsert.Parameters.AddWithValue("@id_provincia", paciente.id_provincia);

                        int filasAfectadas = comandoInsert.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError = "Error al registrar paciente: " + ex.Message;
            }

            return resultado;
        }




        //listar pacientes (contexto: a cargo de gestor)
        public List<PacienteM> ListarPacientes()
        {
            List<PacienteM> listaPacientes = new List<PacienteM>();
            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    using (MySqlCommand comando = new MySqlCommand("SELECT * FROM Paciente", oconexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaPacientes.Add(new PacienteM()
                                {
                                    id_paciente = (int)reader["id_paciente"],
                                    dni = (int)reader["dni"],
                                    nombre = reader["nombre"].ToString(),
                                    apellido = reader["apellido"].ToString(),
                                    telefono = reader["telefono"].ToString(),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar pacientes." + ex.Message);
            }
            return listaPacientes;
        }

        //editar pacientes (a cargo de recep)
        public static bool EditarPaciente(PacienteM paciente)
        {
            bool resultado = false;
            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    // Verificar si el correo o el teléfono ya están en uso por otro paciente
                    string checkQuery = "SELECT COUNT(*) FROM Paciente WHERE (correo = @correo OR telefono = @telefono) AND id_paciente != @idPaciente";
                    using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, oconexion))
                    {
                        checkCommand.Parameters.AddWithValue("@correo", paciente.correo);
                        checkCommand.Parameters.AddWithValue("@telefono", paciente.telefono);
                        checkCommand.Parameters.AddWithValue("@idPaciente", paciente.id_paciente);

                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (count > 0)
                        {
                            // Si ya existe un paciente con el mismo correo o teléfono, devolver false
                            return false;
                        }
                    }

                    // Si no hay conflicto, proceder a la actualización
                    string query = "UPDATE Paciente SET id_obra_social = @obraSocial, direccion = @direccion, " +
                                   "correo = @correo, telefono = @telefono WHERE id_paciente = @idPaciente";

                    using (MySqlCommand comando = new MySqlCommand(query, oconexion))
                    {
                        comando.Parameters.AddWithValue("@obraSocial", paciente.id_obra_social);
                        comando.Parameters.AddWithValue("@direccion", paciente.direccion);
                        comando.Parameters.AddWithValue("@correo", paciente.correo);
                        comando.Parameters.AddWithValue("@telefono", paciente.telefono);
                        comando.Parameters.AddWithValue("@idPaciente", paciente.id_paciente);

                        int filasAfectadas = comando.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al editar el paciente: " + ex.Message);
            }
            return resultado;
        }


        public static PacienteM ObtenerPacientePorId(int idPaciente)
        {
            PacienteM paciente = null;
            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    string query = "SELECT id_paciente, id_obra_social, direccion, correo, telefono " +
                                   "FROM Paciente WHERE id_paciente = @idPaciente";

                    using (MySqlCommand comando = new MySqlCommand(query, oconexion))
                    {
                        comando.Parameters.AddWithValue("@idPaciente", idPaciente);

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                paciente = new PacienteM
                                {
                                    id_paciente = Convert.ToInt32(reader["id_paciente"]),
                                    id_obra_social = Convert.ToInt32(reader["id_obra_social"]),
                                    direccion = reader["direccion"].ToString(),
                                    correo = reader["correo"].ToString(),
                                    telefono = reader["telefono"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el paciente: " + ex.Message);
            }
            return paciente;
        }


        //dar de baja y alta pacientes (contexto: a cargo de gestor)
        public bool BajaPacientes(int id_paciente)
        {
            bool resultado = false;
            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    using (MySqlCommand comando = new MySqlCommand("UPDATE Paciente SET status = @status WHERE id_paciente = @id_paciente", oconexion))
                    {
                        comando.Parameters.AddWithValue("@status", "no"); 
                        comando.Parameters.AddWithValue("@id_paciente", id_paciente);


                        int filasAfectadas = comando.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                        Console.WriteLine(filasAfectadas);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al dar de baja el paciente." + ex.Message);
            }
            return resultado;
        }

        public bool AltaPacientes(int id_paciente)
        {
            bool resultado = false;
            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    using (MySqlCommand comando = new MySqlCommand("UPDATE Paciente SET status = @status WHERE id_paciente = @id_paciente", oconexion))
                    {
                        comando.Parameters.AddWithValue("@status", "si"); 
                        comando.Parameters.AddWithValue("@id_paciente", id_paciente);


                        int filasAfectadas = comando.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                        Console.WriteLine(filasAfectadas);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al dar de alta el paciente." + ex.Message);
            }
            return resultado;
        }

        //listar medicos (es ditinto de obtner los medicos que está mas abajo)
        public List<MedicoM> ListarMedicos()
        {
            List<MedicoM> listaMedicos = new List<MedicoM>();

            using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
            {
                try
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    using (MySqlCommand comando = new MySqlCommand(
                            "SELECT m.id_medico, m.id_especialidad, e.nombre AS especialidad_nombre, " +
                            "m.id_turno, t.nombre AS turno_nombre, " +
                            "m.id_usuario, u.nombre AS nombre, u.apellido, u.telefono, u.status " +
                            "FROM Medico m " +
                            "INNER JOIN Usuario u ON m.id_usuario = u.id_usuario " +
                            "INNER JOIN Turno t ON m.id_turno = t.id_turno " +
                            "INNER JOIN Especialidad e ON m.id_especialidad = e.id_especialidad", oconexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaMedicos.Add(new MedicoM()
                                {
                                    id_medico = (int)reader["id_medico"],
                                    id_especialidad = (int)reader["id_especialidad"],
                                    especialidad_nombre = reader["especialidad_nombre"].ToString(),
                                    id_turno = (int)reader["id_turno"],
                                    turno_nombre = reader["turno_nombre"].ToString(),
                                    id_usuario = (int)reader["id_usuario"],
                                    nombre = reader["nombre"].ToString(),
                                    apellido = reader["apellido"].ToString(),
                                    telefono = reader["telefono"].ToString(),
                                    status = reader["status"].ToString(),
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al listar médicos: " + ex.Message);
                }
            }

            return listaMedicos;
        }

        //comboboxes
        public List<ProvinciaM> ObtenerProvincias()
        {
            List<ProvinciaM> provincias = new List<ProvinciaM>();

            using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())  // Se abre una nueva conexión
            {
                try
                {
                    using (MySqlCommand comando = new MySqlCommand("SELECT id_provincia, nombre FROM Provincia", oconexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                provincias.Add(new ProvinciaM
                                {
                                    id_provincia = Convert.ToInt32(reader["id_provincia"]),
                                    nombre = reader["nombre"].ToString()
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener provincias: " + ex.Message);
                    throw;
                }
            }  // Aquí la conexión se cierra automáticamente

            return provincias;
        }


        public List<CiudadM> ObtenerCiudades()
        {
            List<CiudadM> ciudades = new List<CiudadM>();

            using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
            {
                try
                {
                    using (MySqlCommand comando = new MySqlCommand("SELECT id_ciudad, nombre FROM Ciudad", oconexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ciudades.Add(new CiudadM
                                {
                                    id_ciudad = Convert.ToInt32(reader["id_ciudad"]),
                                    nombre = reader["nombre"].ToString()
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener ciudades: " + ex.Message);
                    throw;
                }
            }  // Aquí la conexión se cierra correctamente

            return ciudades;
        }
        public List<PerfilM> ObtenerPerfiles()
        {
            List<PerfilM> perfiles = new List<PerfilM>();

            using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
            {
                try
                {
                    using (MySqlCommand comando = new MySqlCommand("SELECT id_perfil, nombre FROM Perfil", oconexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                perfiles.Add(new PerfilM
                                {
                                    id_perfil = Convert.ToInt32(reader["id_perfil"]),
                                    nombre = reader["nombre"].ToString()
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener perfiles: " + ex.Message);
                    throw;
                }
            }  // Aquí la conexión se cierra correctamente

            return perfiles;
        }

        //funciones para los comboboxes de "nueva cita" que tienen que listar pacientes y medicos
        public List<PacienteM> ObtenerPacientes()
        {
            List<PacienteM> pacientes = new List<PacienteM>();

            using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
            {
                try
                {
                    using (MySqlCommand comando = new MySqlCommand("SELECT id_paciente, dni FROM Paciente", oconexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pacientes.Add(new PacienteM
                                {
                                    id_paciente = Convert.ToInt32(reader["id_paciente"]),
                                    dni = Convert.ToInt32(reader["dni"])
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener pacientes para el combobox: " + ex.Message);
                    throw;
                }
            }  

            return pacientes;
        }

        public List<MedicoM> ObtenerMedicos()
        {
            List<MedicoM> medicos = new List<MedicoM>();

            using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
            {
                try
                {
                    using (MySqlCommand comando = new MySqlCommand(
                             "SELECT m.id_medico, u.nombre, m.id_especialidad " +
                             "FROM Medico m " +
                             "INNER JOIN Usuario u ON m.id_usuario = u.id_usuario", oconexion)){
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                medicos.Add(new MedicoM
                                {
                                    id_medico = Convert.ToInt32(reader["id_medico"]),
                                    nombre = reader["nombre"].ToString(),
                                    id_especialidad = Convert.ToInt32(reader["id_especialidad"])
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener medicos: " + ex.Message);
                    throw;
                }
            }

            return medicos;
        }

        public List<EspecialidadM> ObtenerEspecialidades()
        {
            List<EspecialidadM> especialidades = new List<EspecialidadM>();

            using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
            {
                try
                {
                    using (MySqlCommand comando = new MySqlCommand("SELECT id_especialidad, nombre FROM Especialidad", oconexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                especialidades.Add(new EspecialidadM
                                {
                                    id_especialidad = Convert.ToInt32(reader["id_especialidad"]),
                                    nombre = reader["nombre"].ToString()
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener especialidades: " + ex.Message);
                    throw;
                }
            }

            return especialidades;
        }

        public List<TurnoM> ObtenerTurnos()
        {
            List<TurnoM> turnos = new List<TurnoM>();

            using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
            {
                try
                {
                    using (MySqlCommand comando = new MySqlCommand("SELECT id_turno, nombre FROM Turno", oconexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                turnos.Add(new TurnoM
                                {
                                    id_turno = Convert.ToInt32(reader["id_turno"]),
                                    nombre = reader["nombre"].ToString()
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener turnos: " + ex.Message);
                    throw;
                }
            }

            return turnos;
        }

        public List<ObraSocialM> ObtenerObrasSociales()
        {
            List<ObraSocialM> obras = new List<ObraSocialM>();

            using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
            {
                try
                {
                    using (MySqlCommand comando = new MySqlCommand("SELECT id_obra_social, nombre FROM obra_social", oconexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                obras.Add(new ObraSocialM
                                {
                                    id_obra_social = Convert.ToInt32(reader["id_obra_social"]),
                                    nombre = reader["nombre"].ToString()
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener obras: " + ex.Message);
                    throw;
                }
            }

            return obras;
        }

        //reportes
    
        //medicos
        public static List<CitaM> ObtenerCitasFiltradas(int idMedico, string estado, DateTime fechaInicio, DateTime fechaFin)
        {
            List<CitaM> citas = new List<CitaM>();

            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {

                string query = "SELECT c.id_cita, c.fecha, c.motivo, c.status, c.id_medico, p.id_paciente, p.nombre, p.apellido, p.genero " +
                               "FROM Cita c " +
                               "LEFT JOIN Paciente p ON c.id_paciente = p.id_paciente " +
                               "WHERE c.id_medico = @idMedico " +
                               "AND c.fecha BETWEEN @fechaInicio AND @fechaFin";


                if (!string.IsNullOrEmpty(estado) && estado != "Todas")
                {
                    query += " AND c.status = @estado";
                }

                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@idMedico", idMedico);
                    comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    comando.Parameters.AddWithValue("@fechaFin", fechaFin);

                    if (!string.IsNullOrEmpty(estado) && estado != "Todas")
                    {
                        comando.Parameters.AddWithValue("@estado", estado);
                    }

                    //conexion.Open();
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            citas.Add(new CitaM
                            {
                                id_cita = Convert.ToInt32(reader["id_cita"]),
                                fecha = Convert.ToDateTime(reader["fecha"]),
                                motivo = reader["motivo"].ToString(),
                                status = reader["status"].ToString(),
                                Paciente = new PacienteM
                                {
                                    id_paciente = reader["id_paciente"] != DBNull.Value ? Convert.ToInt32(reader["id_paciente"]) : 0,
                                    nombre = reader["nombre"].ToString(),
                                    apellido = reader["apellido"].ToString(),
                                    genero = reader["genero"].ToString()
                                }


                            });
                        }
                    }
                }
            }

            return citas;
        }

        //recepcionista
        public static List<CitaM> ObtenerCitasRecep(string estado, DateTime fechaInicio, DateTime fechaFin)
        {
            List<CitaM> citas = new List<CitaM>();

            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT c.id_cita, c.fecha, c.motivo, c.status, m.id_medico, m.id_especialidad, m.id_usuario, e.nombre AS nombre_especialidad " +
                               "FROM Cita c " +
                               "LEFT JOIN Medico m ON c.id_medico = m.id_medico " +
                               "LEFT JOIN Especialidad e ON m.id_especialidad = e.id_especialidad " +
                               "WHERE c.fecha BETWEEN @fechaInicio AND @fechaFin";





                if (!string.IsNullOrEmpty(estado) && estado != "Todas")
                {
                    query += " AND status = @estado";
                }

                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    comando.Parameters.AddWithValue("@fechaFin", fechaFin);

                    if (!string.IsNullOrEmpty(estado) && estado != "Todas")
                    {
                        comando.Parameters.AddWithValue("@estado", estado);
                    }

                    //conexion.Open();
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            citas.Add(new CitaM
                            {
                                id_cita = Convert.ToInt32(reader["id_cita"]),
                                fecha = Convert.ToDateTime(reader["fecha"]),
                                motivo = reader["motivo"].ToString(),
                                status = reader["status"].ToString(),
                                Medico = new MedicoM
                                {
                                    id_medico = reader["id_medico"] != DBNull.Value ? Convert.ToInt32(reader["id_medico"]) : 0,
                                    id_especialidad = Convert.ToInt32(reader["id_especialidad"]),
                                    id_usuario = Convert.ToInt32(reader["id_usuario"]),
                                },
                                Especialidad = new EspecialidadM{
                                   id_especialidad= Convert.ToInt32(reader["id_especialidad"]),
                                   nombre = reader["nombre_especialidad"].ToString() 
                                }

                            });
                        }
                    }
                }
            }

            return citas;
        }

        //gestor
        public static List<CitaM> ObtenerCitasGestor(string estado, DateTime fechaInicio, DateTime fechaFin, int? idMedico = null)
        {
            List<CitaM> citas = new List<CitaM>();

            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                // Se construye la consulta con filtros opcionales
                string query = "SELECT c.id_cita, c.fecha, c.motivo, c.status, m.id_medico, m.id_especialidad, m.id_usuario, " +
                               "p.id_paciente, p.nombre AS nombre_paciente, p.apellido, p.genero, e.nombre AS nombre_especialidad " +
                               "FROM Cita c " +
                               "LEFT JOIN Medico m ON c.id_medico = m.id_medico " +
                               "LEFT JOIN Paciente p ON c.id_paciente = p.id_paciente " +
                               "LEFT JOIN Especialidad e ON m.id_especialidad = e.id_especialidad " +
                               "WHERE c.fecha BETWEEN @fechaInicio AND @fechaFin";

                if (!string.IsNullOrEmpty(estado) && estado != "Todas")
                {
                    query += " AND c.status = @estado";
                }

                if (idMedico.HasValue)
                {
                    query += " AND c.id_medico = @idMedico";
                }
                else
                {
                    query += " AND c.id_medico IS NOT NULL";
                }

                query += " ORDER BY fecha ASC";

                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    comando.Parameters.AddWithValue("@fechaFin", fechaFin);

                    if (!string.IsNullOrEmpty(estado) && estado != "Todas")
                    {
                        comando.Parameters.AddWithValue("@estado", estado);
                    }

                    if (idMedico.HasValue)
                    {
                        comando.Parameters.AddWithValue("@idMedico", idMedico.Value);
                    }

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            citas.Add(new CitaM
                            {
                                id_cita = Convert.ToInt32(reader["id_cita"]),
                                fecha = Convert.ToDateTime(reader["fecha"]),
                                motivo = reader["motivo"].ToString(),
                                status = reader["status"].ToString(),
                                Paciente = new PacienteM
                                {
                                    id_paciente = reader["id_paciente"] != DBNull.Value ? Convert.ToInt32(reader["id_paciente"]) : 0,
                                    nombre = reader["nombre_paciente"].ToString(),
                                    apellido = reader["apellido"].ToString(),
                                    genero = reader["genero"].ToString()
                                },
                                 Especialidad = new EspecialidadM
                                 {
                                     id_especialidad = Convert.ToInt32(reader["id_especialidad"]),
                                     nombre = reader["nombre_especialidad"].ToString()
                                 }
                            });
                        }
                    }
                }
            }

            return citas;
        }
        public static List<UsuarioM> ObtenerUsuariosPorEstadoYPerfil(string status, int? perfil)
        {
            List<UsuarioM> usuarios = new List<UsuarioM>();

            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                string query = "SELECT * FROM Usuario WHERE 1=1";

                if (status != "Todos")
                {
                    query += " AND status = @estado";
                }

                if (perfil.HasValue)
                {
                    query += " AND id_perfil = @perfil";
                }

                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    if (status != "Todos")
                    {
                        comando.Parameters.AddWithValue("@estado", status);
                    }

                    if (perfil.HasValue)
                    {
                        comando.Parameters.AddWithValue("@perfil", perfil);
                    }

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(new UsuarioM
                            {
                                id_usuario = Convert.ToInt32(reader["id_usuario"]),
                                id_perfil = Convert.ToInt32(reader["id_perfil"]),
                                status = reader["status"].ToString()
                                // Agrega otros campos según tu modelo
                            });
                        }
                    }
                }
            }

            return usuarios;
        }



    }
} 

