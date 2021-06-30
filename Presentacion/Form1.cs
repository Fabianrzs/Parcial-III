using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BLL.LiquidacioService;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        LiquidacioService service;
        public Form1()
        {
            InitializeComponent();
            service = new LiquidacioService(ConfigConnection.connectionString);
            LoadComboBox();
        }

        private void cargar()
        {

            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK && openFile.FileName != null)
            {
                string file = openFile.FileName;
                Validacion(file);
            }
        }

        private void Validacion(string file)
        {
            int log = 0, correcto = 0;
            ConsultaResponseLiquidacion response = service.ConsularLiquidacion(file);

            if (!response.Error)
            {
                foreach (var item in response.Liquidacions)
                {
                    if (service.RegistrarCorrectos(item, CbxProyectos.Text))
                    {
                        correcto++;
                    }
                    else { log++; }
                }
                if (log > 0)
                {
                    string ruta = "C:/Users/WIN10/Desktop/Practica_Preparcial/resentacion/bin/Debug";
                    MessageBox.Show($"Archivos Resportados {log + correcto}\nArchivos Correctos {correcto}\nArchivos con Error {log}\nVarifique en la ruta {ruta}", "Reporte de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Archivos Resportados {log + correcto}\nArchivos Correctos {correcto}\nArchivos con Error {log}", "Reporte de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(response.Message, "informacion", MessageBoxButtons.OK);
            }
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void LoadComboBox()
        {
            CargaResponseProyecto response = service.CargarProyecto();

            if (!response.Error)
            {
                foreach (var item in response.Proyectos)
                {
                    CbxProyectos.Items.Add(item.NombreProyecto);
                }
            }
            else
            {
                MessageBox.Show(response.Mensaje);
            }
        }
    }
}
