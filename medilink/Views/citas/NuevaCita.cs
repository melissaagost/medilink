using medilink.Models;
using medilink.ViewModels;
using medilink.Views.usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medilink.Views.citas
{
    public partial class NuevaCita : Form
    {
        private UsuarioM usuarioLogueado;
        private CrudVM usuarioVM; 

        public NuevaCita(UsuarioM usuarioLogueado)
        {
            InitializeComponent(); 
            this.usuarioLogueado = usuarioLogueado;
            usuarioVM = new CrudVM(usuarioLogueado.id_perfil);
            CargarComboboxes();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //por accidente
        }

        //lista los pacientes y medicos en los comboboxes (funciona pero paciente aparece vacio porque no hay pacientes registrados)
        private void CargarComboboxes()
        {
            try
            {
                comboBoxBuscarPaciente.DataSource = usuarioVM.ObtenerPacientes();
                comboBoxBuscarPaciente.DisplayMember = "dni";
                comboBoxBuscarPaciente.ValueMember = "id_paciente";


                comboBoxSelecMedico.DataSource = usuarioVM.ObtenerMedicos();
                comboBoxSelecMedico.DisplayMember = "nombre";
                comboBoxSelecMedico.ValueMember = "id_medico";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ComboBoxes: " + ex.Message);
            }
        }

        private void buttonAgendar_Click(object sender, EventArgs e)
        {
            // Validar que se seleccione un paciente
            if (comboBoxBuscarPaciente.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un paciente.");
                return;
            }


            // Validar que se seleccione un médico
            if (comboBoxSelecMedico.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un médico.");
                return;
            }

            

            // Validar que la fecha de la cita sea hoy o posterior
            if (dateTimePickerCita.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("La fecha de la cita debe ser hoy o una fecha futura.");
                return;
            }

            // Validar que el motivo no esté vacío
            if (string.IsNullOrWhiteSpace(richTextBoxMotivo.Text))
            {
                MessageBox.Show("Debe ingresar un motivo para la cita.");
                return;
            }

            CitaM nuevaCita = new CitaM()
            {
                id_paciente = (int)comboBoxBuscarPaciente.SelectedValue,
                id_medico = (int)comboBoxSelecMedico.SelectedValue,
                motivo = richTextBoxMotivo.Text,
                fecha = dateTimePickerCita.Value
            };

            try
            {
                bool resultado = usuarioVM.ProgramarCita(nuevaCita);  // Llamar al ViewModel
                if (resultado)
                {
                    MessageBox.Show("Cita agendada exitosamente.");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCancelarAgenda_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
