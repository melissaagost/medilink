using medilink.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medilink.BD
{
    public class Crud
    {

        //regsitro de un user y si es medico lo almacena en la tabla medico (contexto: usado por sistemas)
        public static bool Registrar(UsuarioM usuario, int idEspecialidad, int idTurno)
        {
            bool resultado = false;

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
                        Console.WriteLine("Error al registrar usuario y/o médico: " + ex.Message);
                        throw;
                    }
                }
            }

            return resultado;
        }


        // listar usuarios (contexto: usado por sistemas y gestor) 
        public List<UsuarioM> Listar()
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

                    using (MySqlCommand comando = new MySqlCommand("SELECT * FROM Usuario", oconexion))
                    {
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
                Console.WriteLine("Error al listar usuarios" + ex.Message);
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
                        //comando.Parameters.AddWithValue("@foto_perfil", usuario.foto_perfil);
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

                    using (MySqlCommand comando = new MySqlCommand("UPDATE Cita SET status = @status WHERE id_cita = @id_cita", oconexion))
                    {
                        comando.Parameters.AddWithValue("@status", "cancelada");
                        comando.Parameters.AddWithValue("@id_usuario", id_cita);

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

        //listar citas (contexto: usado por recep)
        public static List<CitaM> ListarCitas()
        {
            List<CitaM> listaCitas = new List<CitaM>();
            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    using (MySqlCommand comando = new MySqlCommand("SELECT * FROM Cita", oconexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaCitas.Add(new CitaM()
                                {
                                    fecha = (DateTime)reader["fecha"],
                                    status = reader["status"].ToString(),
                                    id_paciente = (int)reader["id_paciente"],
                                    id_medico = (int)reader["id_medico"],
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar citas." + ex.Message);
            }
            return listaCitas;
        }

        //listar citas asociadas a un medico
        internal static List<CitaM> ListarCitasPorMedico(int idMedico)
        {
            List<CitaM> listaCitas = new List<CitaM>();

            using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
            {
                if (oconexion.State == ConnectionState.Closed)
                {
                    oconexion.Open();
                }

                using (MySqlCommand comando = new MySqlCommand("SELECT * FROM Cita WHERE id_medico = @idMedico", oconexion))
                {
                    comando.Parameters.AddWithValue("@idMedico", idMedico);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaCitas.Add(new CitaM
                            {
                                id_paciente = Convert.ToInt32(reader["id_paciente"]),
                                fecha = Convert.ToDateTime(reader["fecha"]),
                                motivo = (string)reader["motivo"],
                                status = (string)reader["status"],
                            });
                        }
                    }
                }
            }
            return listaCitas;
        }


        //registrar un paciente (Contexto: a cargo de la recep)
        public static bool RegistrarPaciente(PacienteM paciente)
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

                    using (MySqlCommand comando = new MySqlCommand("INSERT INTO Paciente (dni, nombre, apellido, fecha_nacimiento, correo, telefono, direccion, edad, status, id_obra_social, id_ciudad, id_provincia) VALUES (@dni, @nombre, @apellido, @fecha_nacimiento, @correo, @telefono, @direccion, @edad, 'si', @id_obra_social, @id_ciudad, @id_provincia)", oconexion))
                    {
                        comando.Parameters.AddWithValue("@dni", paciente.dni);
                        comando.Parameters.AddWithValue("@nombre", paciente.nombre);
                        comando.Parameters.AddWithValue("@apellido", paciente.apellido);
                        comando.Parameters.AddWithValue("@fecha_nacimiento", paciente.fecha_nacimiento);
                        comando.Parameters.AddWithValue("@correo", paciente.correo);
                        comando.Parameters.AddWithValue("@telefono", paciente.telefono);
                        comando.Parameters.AddWithValue("@direccion", paciente.direccion);
                        comando.Parameters.AddWithValue("@edad", paciente.edad);
                        comando.Parameters.AddWithValue("@id_obra_social", paciente.id_obra_social);
                        comando.Parameters.AddWithValue("@id_ciudad", paciente.id_ciudad);
                        comando.Parameters.AddWithValue("@id_provincia", paciente.id_provincia);
                        int filasAfectadas = comando.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al registrar paciente" + ex.Message);
            }
            return resultado;

        }



        //listar pacientes (contexto: a cargo de gestor y recep)
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
                                    dni = (int)reader["dni"],
                                    nombre = reader["nombre"].ToString(),
                                    apellido = reader["apellido"].ToString(),
                                    status = reader["status"].ToString(),
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
        //dar de baja pacientes (contexto: a cargo de gestor)
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
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al dar de baja el paciente." + ex.Message);
            }
            return resultado;
        }

        //listar medicos (es ditinto de obtner los medicos que está mas abajo)
        public List<MedicoM> ListarMedicos()
        {
            List<MedicoM> listaMedicos = new List<MedicoM>();
            try
            {
                using (MySqlConnection oconexion = ConexionBD.ObtenerConexion())
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    using (MySqlCommand comando = new MySqlCommand("SELECT * FROM Medico", oconexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaMedicos.Add(new MedicoM()
                                {
                                    id_medico = (int)reader["id_medico"],
                                    id_especialidad = (int)reader["id_especialidad"],
                                    id_turno = (int)reader["id_turno"],
                                    id_usuario = (int)reader["id_usuario"],
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar médicos." + ex.Message);
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
                    using (MySqlCommand comando = new MySqlCommand("SELECT id_medico, id_especialidad FROM Medico", oconexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                medicos.Add(new MedicoM
                                {
                                    id_medico = Convert.ToInt32(reader["id_medico"]),
                                    id_especialidad = Convert.ToInt32(reader["id_especialidad"]),
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

    }
} 

