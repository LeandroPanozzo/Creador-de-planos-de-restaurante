using Newtonsoft.Json;
using ProyectoFinalRestaurante;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalRestaurante
{
    public partial class PrevisualizacionForm : Form
    {
        private TableLayoutPanel tableLayoutPanel1;
        private Panel largePanel;
        private Dictionary<Button, Mesa> informacionMesas = new Dictionary<Button, Mesa>();
        private Dictionary<string, Image> imagenes = new Dictionary<string, Image>();
        private Dictionary<string, Color> colores = new Dictionary<string, Color>();
        Mesa informacionMesaForm = new Mesa();

        private string currentFilePath;
        public PrevisualizacionForm()
        {
            InitializeComponent();
            InitializeContextMenu();
            //CargarImagenes();
            CargarColores();
            SetupScrollablePanel();

            InitializeAutoSaveTimer();
        }

        private void SetupScrollablePanel()
        {
            tableLayoutPanel1 = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            largePanel = new Panel
            {
                Size = new Size(2000, 2000),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            tableLayoutPanel1.Controls.Add(largePanel);
            this.Controls.Add(tableLayoutPanel1);
        }
        private void InitializeAutoSaveTimer()
        {
            
            timer1.Interval = 3000; // 3 segundos
            timer1.Tick += timer1_Tick;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                DataSerializer.SaveData(informacionMesas, largePanel.Controls, currentFilePath);
            }
        }
        private void PrevisualizacionForm_Load(object sender, EventArgs e)
        {
            this.FormClosing += PrevisualizacionForm_FormClosing;
        }

        private void InitializeContextMenu()
        {
            contextMenuStrip1 = new ContextMenuStrip();

            // Suscribirse al evento Opening del menú contextual
            contextMenuStrip1.Opening += ContextMenuStrip1_Opening;
        }

        private void ContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Limpiar los elementos específicos de mesa cada vez que se abre el menú
            contextMenuStrip1.Items.RemoveByKey("VerInformacion");
            contextMenuStrip1.Items.RemoveByKey("EditarInformacion");

            if (contextMenuStrip1.SourceControl is Button button)
            {
                // Verificar el Tag del botón
                if (button.Tag?.ToString() == "Mesa Cuadrada " || button.Tag?.ToString() == "Mesa Redonda ")
                {
                    contextMenuStrip1.Items.Add("Ver Información", null, VerInformacion_Click).Name = "VerInformacion";
                    contextMenuStrip1.Items.Add("Editar información", null, EditarInformacion_Click).Name = "EditarInformacion";
                }
            }
        }


        private void EditarInformacion_Click(object sender, EventArgs e)
        {
            if (contextMenuStrip1.SourceControl is Button button && informacionMesas.ContainsKey(button))
            {
                Mesa infoMesa = informacionMesas[button];
                using (FormEditarInfoMesa form = new FormEditarInfoMesa(infoMesa, button))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        informacionMesas[button] = infoMesa;
                        if (button.Tag?.ToString() == "Mesa Cuadrada ")
                        {
                            button.Text = "Mesa Cuadrada " + infoMesa.NumeroMesa.ToString();
                        }
                        else if (button.Tag?.ToString() == "Mesa Redonda ")
                        {
                            button.Text = "Mesa Redonda " + infoMesa.NumeroMesa.ToString();
                        }

                    }
                }
            }
        }

        private void VerInformacion_Click(object sender, EventArgs e)
        {
            if (contextMenuStrip1.SourceControl is Button button && informacionMesas.ContainsKey(button))
            {
                Mesa infoMesa = informacionMesas[button];

                string consumosInfo = "Consumos:\n";

                foreach (var item in infoMesa.Consumos)
                {
                    var partes = item.Split(':');
                    if (partes.Length == 4)
                    {
                        consumosInfo += $"Insumos: {partes[0].Trim()}\nCantidad: {partes[1].Trim()}\nPrecio por Unidad: {partes[2].Trim()}\nPrecio por Cantidad: {partes[3].Trim()}\n\n";
                    }
                }

                MessageBox.Show($"Número de Mesa: {infoMesa.NumeroMesa}\n" +
                                $"Estado: {infoMesa.Estado}\n" +
                                $"Mozo Encargado: {infoMesa.MozoEncargado}\n" +
                                $"Hora de Reserva: {infoMesa.HoraReserva}\n" +
                                $"Hora de Salida: {infoMesa.HoraSalida}\n\n" +
                                $"{consumosInfo}\n" +
                                $"Total a pagar: {infoMesa.Pagar.ToString("0.00")}\n",
                                "Información de la Mesa");
            }
        }


        private void PrevisualizacionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                // Guardar automáticamente en el archivo abierto y cerrar el formulario
                DataSerializer.SaveData(informacionMesas, largePanel.Controls, currentFilePath);
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Desea guardar los cambios antes de cerrar el programa?", "Guardar Cambios", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Guardar los cambios antes de cerrar el programa
                    saveToolStripMenuItem_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    // Cancelar el cierre del formulario
                    e.Cancel = true;
                }
            }
        }
        private void CargarColores()
        {
            colores.Add("Mesa Redonda ", Color.GreenYellow);
            colores.Add("Mesa Cuadrada ", Color.GreenYellow);
            colores.Add("Silla de grupo", Color.Gray);
            colores.Add("silla individual", Color.Gray);
            colores.Add("puertas", Color.Aquamarine);
            colores.Add("inodoro", Color.WhiteSmoke);
            colores.Add("urinario", Color.WhiteSmoke);
            colores.Add("lavabo", Color.WhiteSmoke);
            colores.Add("Cocina", Color.Turquoise);
            colores.Add("Heladera", Color.WhiteSmoke);
            colores.Add("lavadero grande", Color.WhiteSmoke);
            colores.Add("lavadero chico", Color.WhiteSmoke);
            colores.Add("pared", Color.Yellow);
            colores.Add("divisores", Color.Orange);
        }

        private void CrearElemento(string tipo, Point location)
        {
            Button nuevoElemento;
            if (tipo == "Mesa Redonda ")
            {
                nuevoElemento = new RoundButton();
            }
            else
            {
                nuevoElemento = new Button();
            }

            nuevoElemento.Text = tipo;
            nuevoElemento.Size = new Size(100, 100); 

            if (imagenes.ContainsKey(tipo))
            {
                nuevoElemento.BackgroundImage = imagenes[tipo];
                nuevoElemento.BackgroundImageLayout = ImageLayout.Stretch;
                nuevoElemento.TextImageRelation = TextImageRelation.ImageAboveText;
                nuevoElemento.ImageAlign = ContentAlignment.MiddleCenter;
            }

            nuevoElemento.Location = location;
            nuevoElemento.ContextMenuStrip = contextMenuStrip1;

            largePanel.Controls.Add(nuevoElemento);
            nuevoElemento.BringToFront();

            Mesa infoMesa = new Mesa { NumeroMesa = informacionMesas.Count + 1 };
            informacionMesas.Add(nuevoElemento, infoMesa);

            // Agregar MoverBotones para permitir mover y redimensionar el botón
            MoverBotones moverBotones = new MoverBotones(nuevoElemento, largePanel, tableLayoutPanel1);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                // Si hay un archivo abierto, guardar automáticamente los cambios antes de crear una nueva plantilla
                DataSerializer.SaveData(informacionMesas, largePanel.Controls, currentFilePath);
                // Cortar la conexión con el archivo actual estableciendo currentFilePath en null
                currentFilePath = null;
                // Detener el temporizador de auto-guardado
                timer1.Stop();
                // Resetear las mesas totales y limpiar el panel y el diccionario de mesas
                Mesa.TotalMesas = 1;
                largePanel.Controls.Clear();
                informacionMesas.Clear();
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Desea guardar los cambios antes de crear una nueva plantilla?", "Guardar Cambios", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
                // Cortar la conexión con el archivo actual estableciendo currentFilePath en null
                currentFilePath = null;
                // Detener el temporizador de auto-guardado
                timer1.Stop();
                // Resetear las mesas totales y limpiar el panel y el diccionario de mesas
                Mesa.TotalMesas = 1;
                largePanel.Controls.Clear();
                informacionMesas.Clear();

            }
                
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON Files (*.json)|*.json";
                saveFileDialog.Title = "Guardar Información de Mesas y Botones";
                saveFileDialog.FileName = "informacionMesasBotones.json";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveFileDialog.FileName;
                    DataSerializer.SaveData(informacionMesas, largePanel.Controls, currentFilePath);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON Files (*.json)|*.json";
                openFileDialog.Title = "Abrir Información de Mesas y Botones";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = openFileDialog.FileName;
                    DataSerializer.LoadData(openFileDialog.FileName, informacionMesas, largePanel.Controls, colores, contextMenuStrip1, largePanel, tableLayoutPanel1);
                    timer1.Start();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void pasarAEdicionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario actual
            this.Close();

            // Abrir Form1
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea eliminar los cambios?", "Eliminar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (Button button in largePanel.Controls)
                {
                    informacionMesas[button].Estado = "Libre";
                    if (button.Tag.ToString() == "Mesa Redonda " || button.Tag.ToString() == "Mesa Cuadrada ")
                    {
                        button.BackColor = Color.GreenYellow;

                    }

                    informacionMesas[button].Consumos.Clear();
                    informacionMesas[button].HoraReserva = DateTime.Now;
                    informacionMesas[button].HoraSalida = DateTime.Now;
                    informacionMesas[button].MozoEncargado = "No asignado ";
                }
            }

        }

        private void guardarEnElMismoArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                if (!timer1.Enabled)
                {
                    timer1.Start();
                }
            }
            else
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "JSON Files (*.json)|*.json";
                    saveFileDialog.Title = "Guardar Información de Mesas y Botones";
                    saveFileDialog.FileName = "informacionMesasBotones.json";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        currentFilePath = saveFileDialog.FileName;
                        DataSerializer.SaveData(informacionMesas, largePanel.Controls, currentFilePath);
                        timer1.Start();
                    }
                }
            }
        }


    }
}


