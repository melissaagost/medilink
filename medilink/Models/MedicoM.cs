﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medilink.Models
{
    internal class MedicoM
    {
        public int id_medico { get; set; }
        public int id_especialidad { get; set; }
        public int id_usuario { get; set; }
        public int id_turno { get; set; }
    }
}
