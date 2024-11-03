using medilink.Models;
using medilink.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medilink.BD;
using medilink.Views.citas;
using static medilink.BD.Crud;

namespace medilink.ViewModels
{
    internal class CrudVM
    {
        //usar numerito 
        //1.Sistemas
        //2.Gestor
        //3.Medico
        //4.Recepcionista 

        private Crud usuarioLogueado = new Crud(); 
        private int id_perfil;

        public CrudVM(int rol)
        {
            this.id_perfil= rol;
        }

        //filtros de sistemas y gestor
        public bool CrearUsuario(UsuarioM usuario, int especialidad, int turno, out string mensajeError)
        {
            // Validar que el perfil sea adecuado para crear usuarios
            if (id_perfil == 1 || id_perfil == 2)
            {
                // Llamar al método Registrar del CRUD y pasar el parámetro de salida mensajeError
                return Crud.Registrar(usuario, especialidad, turno, out mensajeError);
            }
            else
            {
                // Si no tiene permisos, lanzar una excepción
                throw new UnauthorizedAccessException("No tienes permisos para crear usuarios.");
            }
        }


        public List<UsuarioM> ListarUsuarios()
         {
            if (id_perfil == 1 || id_perfil == 2)
            {
                return usuarioLogueado.Listar();
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permisos para listar usuarios.");
            }
         }

        public bool DarDeBajaUsuario(int id_usuario)
        {
            if (id_perfil == 1 || id_perfil == 2)
            {
                return usuarioLogueado.Baja(id_usuario);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permisos para dar de baja usuarios.");
            }
        }

        public bool DarDeAltaUsuario(int id_usuario)
        {
            if (id_perfil == 1 || id_perfil == 2)
            {
                return usuarioLogueado.Alta(id_usuario);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permisos para dar de alta usuarios.");
            }
        }
        //filtros recep y medico
        public bool ProgramarCita(CitaM cita)
        {
            if (id_perfil == 4)
            {
                return Crud.Programar(cita);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permisos para programar una cita.");
            }
        }

        public bool ReprogramarCita(int id_cita, DateTime nuevaFecha)
        {
            return usuarioLogueado.ReprogramarCita(id_cita, nuevaFecha);
        }

        public bool VerificarDisponibilidadMedico(int idMedico, DateTime fechaHora)
        {
            return Crud.VerificarDisponibilidadMedico(idMedico, fechaHora);
        }


        public bool CancelarCita(int cita)
        {
            if (id_perfil == 4 || id_perfil == 3)
            {
                return Crud.Cancelar(cita);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permisos para cancelar una cita.");
            }
        }
        public bool CompletarCita(int cita)
        {
            if (id_perfil == 3)
            {
                return Crud.Completar(cita);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permisos para completar una cita.");
            }
        }

        public List<CitaM> ListarCitas(int idUsuarioLogueado)
        {
            
            if (id_perfil == 3)
            {
                return Crud.ListarCitasPorMedico(idUsuarioLogueado);
            }
            else if (id_perfil == 4)
            {
                
                return Crud.ListarCitas();
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permisos para ver citas.");
            }
        }

        //filtros recep y gestor
        public bool RegistrarPaciente(PacienteM paciente, out string mensajeError)
        {
            if (id_perfil == 4 || id_perfil == 2)
            {
                return Crud.RegistrarPaciente(paciente, out mensajeError);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permisos para registrar pacientes.");
            }
        }

        public bool EditarPaciente(PacienteM paciente)
        {
            return Crud.EditarPaciente(paciente);
        }
        public PacienteM ObtenerPacientePorId(int idPaciente)
        {
            return Crud.ObtenerPacientePorId(idPaciente);
        }

        public List<PacienteM> ListarPacientes()
        {
            if (id_perfil == 4 || id_perfil == 2) //quizas que solo dejamos medico
            {
                return usuarioLogueado.ListarPacientes();
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permisos para listar pacientes.");
            }
        }


        public List<MedicoM> ListarMedicos()
        {
            if (id_perfil == 2)
            {
                return usuarioLogueado.ListarMedicos();
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permisos para listar médicos.");
            }
        }

        public bool DarDeBajaPaciente(int id_paciente)
        {
            if (id_perfil == 4 || id_perfil == 2)
            {
                return usuarioLogueado.BajaPacientes(id_paciente);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permisos para dar de baja pacientes.");
            }
        }

        public bool DarDeAltaPaciente(int id_paciente)
        {
            if (id_perfil == 4 || id_perfil == 2)
            {
                return usuarioLogueado.AltaPacientes(id_paciente);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permisos para dar de alta pacientes.");
            }
        }

        //todos los users
        public bool EditarPerfil(UsuarioM usuarioAEditar, int idUsuarioLogueado) //tengo que controlar esta funcion pq no se si esta bien 
        {
            if (usuarioAEditar.id_usuario == idUsuarioLogueado)  
            {
                return usuarioLogueado.EditarPerfil(usuarioAEditar);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permisos para editar este perfil.");
            }
        }

        public UsuarioM ObtenerUsuarioPorId(int idUsuario)
        {
            Crud crud = new Crud();
            return crud.ObtenerUsuarioPorId(idUsuario);
        }

        //comboboxes
        public List<ProvinciaM> ListarProvincias()
        {
            return usuarioLogueado.ObtenerProvincias();  
        }

        public List<CiudadM> ListarCiudades()
        {
            return usuarioLogueado.ObtenerCiudades(); 
        }

        public List<PerfilM> ListarPerfiles()
        {
            return usuarioLogueado.ObtenerPerfiles();  
        }

        public List<PacienteM> ObtenerPacientes()
        {
            return usuarioLogueado.ObtenerPacientes(); 
        }

        public List<MedicoM> ObtenerMedicos()
        {
            return usuarioLogueado.ObtenerMedicos();  
        }


        public List<EspecialidadM> ObtenerEspecialidades()
        {
            return usuarioLogueado.ObtenerEspecialidades();
        }
        public List<TurnoM> ObtenerTurnos()
        {
            return usuarioLogueado.ObtenerTurnos();
        }

        public List<ObraSocialM> ObtenerObrasSociales()
        {
            return usuarioLogueado.ObtenerObrasSociales();
        }

        //reportes
        public List<CitaM> ListarCitasFiltradas(int idMedico, string estado, DateTime fechaInicio, DateTime fechaFin)

        {
            if (id_perfil == 3)
            {
                return Crud.ObtenerCitasFiltradas(idMedico, estado, fechaInicio, fechaFin);
            }
            else
            {
                return new List<CitaM>();
            }
            
        }
        public List<CitaM> ListarCitasRecep( string estado, DateTime fechaInicio, DateTime fechaFin)

        {
            if (id_perfil == 4)
            {
                return Crud.ObtenerCitasRecep(estado, fechaInicio, fechaFin);
            }
            else
            {
                return new List<CitaM>();
            }

        }

        public List<CitaM> ListarCitasGestor(string estado, DateTime fechaInicio, DateTime fechaFin, int? idMedico = null, int? idPaciente = null)
        {
            return Crud.ObtenerCitasGestor(estado, fechaInicio, fechaFin, idMedico, idPaciente);
        }




    }
}
