using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medilink.Views.usuario
{
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SQL Files (*.sql)|*.sql";
            saveFileDialog.Title = "Guardar Backup de Base de Datos";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaBackup = saveFileDialog.FileName;
                // Aquí puedes usar la ruta seleccionada para ejecutar la lógica de generar el backup
                MessageBox.Show("Backup guardado en: " + rutaBackup);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
