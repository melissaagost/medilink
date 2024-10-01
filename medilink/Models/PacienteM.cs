using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medilink.Models
{
    internal class PacienteM
    {
        public int id_paciente { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public int edad { get; set; }
        public int id_obra_social { get; set; }
        public int id_ciudad { get; set; }
        public int id_provincia { get; set; }
    }
}
