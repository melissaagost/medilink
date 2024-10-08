using medilink.Models;
using medilink.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medilink.BD;

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
        public bool CrearUsuario(UsuarioM usuario)
        {
            if (id_perfil == 1 || id_perfil == 2)
            {
                return Crud.Registrar(usuario);
            }
            else
            {
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
        public bool ProgramarCitaC(CitaM cita)
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
        public bool RegistrarPaciente(PacienteM paciente)
        {
            if (id_perfil == 4 || id_perfil == 2)
            {
                return Crud.RegistrarPaciente(paciente);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permisos para registrar pacientes.");
            }
        }

        public List<PacienteM> ListarPacientes()
        {
            if (id_perfil == 4 || id_perfil == 2)
            {
                return usuarioLogueado.ListarPacientes();
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permisos para listar pacientes.");
            }
        }

        public bool DarDeBajaPaciente(int id_paciente)
        {
            if (id_perfil == 4 || id_perfil == 2)
            {
                return usuarioLogueado.Baja(id_paciente);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permisos para dar de baja pacientes.");
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

     
            public List<ProvinciaM> ListarProvincias()
            {
                return usuarioLogueado.ObtenerProvincias();  // Maneja su propia conexión
            }

            public List<CiudadM> ListarCiudades()
            {
                return usuarioLogueado.ObtenerCiudades();  // Maneja su propia conexión
            }

            public List<PerfilM> ListarPerfiles()
            {
                return usuarioLogueado.ObtenerPerfiles();  // Maneja su propia conexión
            }
       


    }
}
