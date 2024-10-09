using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medilink.Models
{
    public class CitaM
    {
        public int id_cita { get; set; }
        public DateTime fecha { get; set; }
        public DateTime hora { get; set; }
        public string motivo { get; set; }
        public string status { get; set; }
        public int id_paciente { get; set; }
        public string paciente_nombre { get; set; }
        public int id_medico { get; set; }

        public string medico_nombre { get; set; }

    }
}
