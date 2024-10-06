﻿using medilink.Models;
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

        //regsitro de un user (contexto: usado por sistemas y gestor)
        public static bool Registrar(UsuarioM usuario)
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
                    
                    using (MySqlCommand comando = new MySqlCommand("INSERT INTO Usuario (dni, nombre, apellido, usuario, contraseña, fecha_nacimiento, telefono, correo, direccion, status, id_provincia, id_ciudad, id_perfil) VALUES (@dni, @nombre, @apellido, @usuario, @contraseña, @fecha_nacimiento, @telefono, @correo, @direccion, @status, @id_provincia, @id_ciudad, @id_perfil)", oconexion))
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

                    using (MySqlCommand comando = new MySqlCommand("INSERT INTO Paciente (dni, nombre, apellido, fecha_nacimiento, correo, telefono, direccion, edad, id_obra_social, id_ciudad) VALUES (@dni, @nombre, @apellido, @fecha_nacimiento, @correo, @telefono, @direccion, @edad, @id_obra_social, @id_ciudad)", oconexion))
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



    }
} 

