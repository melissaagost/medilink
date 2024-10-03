using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        private string selectedBackupFolderPath;
        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BExaminarBackup_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    selectedBackupFolderPath = folderDialog.SelectedPath;
                    MessageBox.Show("Ruta seleccionada: " + selectedBackupFolderPath);
                }
            }
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedBackupFolderPath))
            {
                try
                {
                    string backupFilePath = Path.Combine(selectedBackupFolderPath, "Backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".sql");


                    GenerarBackup(backupFilePath);



                    MessageBox.Show("Backup generado en: " + backupFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el backup: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona una carpeta para guardar el backup.");
            }
        }

       
        private void GenerarBackup(string filePath)
        {
            try
            {
                string mysqldumpPath = @"C:\xampp\mysql\bin\mysqldump.exe";

                string server = "localhost";    // Tu servidor MySQL
                int port = 3307;
                string database = "medilink";    // El nombre de tu base de datos
                string user = "root";           // El usuario con acceso a la base de datos
                string arguments = $"-h {server} --port={port} -u {user} {database}";

                // Crear el proceso para ejecutar el comando mysqldump
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = mysqldumpPath;
                    process.StartInfo.Arguments = arguments;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.UseShellExecute = false;

                    // Iniciar el proceso
                    process.Start();

                    // Capturar la salida del comando (el archivo SQL generado)
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    // Esperar a que el proceso termine
                    process.WaitForExit();

                    // Verificar si hubo algún error
                    if (process.ExitCode == 0)
                    {
                        // Guardar el contenido de salida en el archivo de backup
                        File.WriteAllText(filePath, output);
                    }
                    else
                    {
                        throw new Exception("Error al generar el backup" + error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error" + ex.Message);
            }


        }

    }
}
