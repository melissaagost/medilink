using medilink.Models;
using medilink.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using medilink.BD;
using medilink.Views;

namespace medilink.Views.citas
{
    public partial class ReprogramarCita : Form 
    {
       // private int idMedicoSeleccionado;
        private UsuarioM usuarioLogueado;
        private CrudVM usuarioVM;
        private int id_cita;

        private void CargarCitasActivas()
        {
            List<CitaM> citasActivas = usuarioVM.ListarCitas(usuarioLogueado.id_usuario);
            //falta ver como refrescar el grid de citas activas al reprogramar
        }


        public ReprogramarCita(int id_cita, string motivo, int id_paciente, int id_profesional, UsuarioM usuarioLogueado)
        {
            InitializeComponent();
            this.id_cita = id_cita;
            this.usuarioLogueado = usuarioLogueado; 
            usuarioVM = new CrudVM(usuarioLogueado.id_perfil);
           // this.idMedicoSeleccionado = id_profesional;



            // Mostrar los datos de la cita actual
            richTextBoxMotivo.Text = motivo;
            richTextBoxMotivo.ReadOnly = true;
            richTextBoxMotivo.Enabled = false;


            comboBoxBuscarPaciente.SelectedValue = id_paciente;
            comboBoxBuscarPaciente.Enabled = false;

            comboBoxSelecMedico.SelectedValue = id_profesional;
            comboBoxSelecMedico.Enabled = false;
        }


        private void buttonAgendar_Click_1(object sender, EventArgs e)
        {

            DateTime nuevaFechaHora = dateTimePickerCita.Value;

            DateTime fechaHoraActual = DateTime.Now; 

            if (nuevaFechaHora <= fechaHoraActual)
            {
                MessageBox.Show("Por favor, seleccione una fecha futura (no puede ser la fecha actual ni una anterior).");
                return;
            }


            bool resultado = usuarioVM.ReprogramarCita(id_cita, nuevaFechaHora);
            if (resultado)
            {
                MessageBox.Show("Cita reprogramada con éxito.");
                this.DialogResult = DialogResult.OK;


                this.Close();
            }
            else
            {
                MessageBox.Show("Error al reprogramar la cita.");
            }
        }

        private void buttonCancelarAgenda_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BVerificar_Click(object sender, EventArgs e)
        {
            DateTime nuevaFecha = dateTimePickerCita.Value;
            int idMedico = Convert.ToInt32(comboBoxSelecMedico.SelectedValue);

            bool disponible = usuarioVM.VerificarDisponibilidadMedico(idMedico, nuevaFecha);

            if (disponible)
            {
                MessageBox.Show("El médico está disponible en esta fecha y hora.");
            }
            else
            {
                MessageBox.Show("El médico no está disponible en esta fecha y hora. Por favor, seleccione otra.");
            }
        }

    }
}

