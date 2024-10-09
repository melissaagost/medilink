using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medilink.Models
{
    public class MedicoM
    {
        public int id_medico { get; set; }
        public int id_especialidad { get; set; }
        public string especialidad_nombre { get; set; }
        public int id_turno { get; set; }
        public string turno_nombre { get; set; }
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string status { get; set; }
    }
}
