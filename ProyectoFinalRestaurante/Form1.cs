using Newtonsoft.Json;
using ProyectoFinalRestaurante;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
namespace ProyectoFinalRestaurante
{
    public partial class Form1 : Form
    {   
        private TableLayoutPanel tableLayoutPanel1;
        private Panel largePanel;
        private int numeroMesa = 1;
        private int maxNumeroMesa = 1;
        


        private Dictionary<Button, Mesa> informacionMesas = new Dictionary<Button, Mesa>();
        private Dictionary<string, Image> imagenes = new Dictionary<string, Image>();
        private Dictionary<string, Color> colores = new Dictionary<string, Color>();
        Mesa informacionMesaForm = new Mesa();

        private string currentFilePath;
        public Form1()
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
            // Crear TableLayoutPanel
            tableLayoutPanel1 = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            // Crear Panel grande
            largePanel = new Panel
            {
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height), // Inicialmente del tamaño del formulario
                AutoSize = true, // Permitir que el panel crezca automáticamente
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            // Agregar Panel al TableLayoutPanel
            tableLayoutPanel1.Controls.Add(largePanel);

            // Agregar TableLayoutPanel al formulario
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

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeContextMenu();
            // Suscribir el evento FormClosing
            this.FormClosing += Form1_FormClosing;
            Mesa.TotalMesas = 1;
        }


        private void InitializeContextMenu()
        {
            contextMenuStrip1 = new ContextMenuStrip();
            contextMenuStrip1.Items.Add("Eliminar", null, Eliminar_Click);


        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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



        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (contextMenuStrip1.SourceControl is Button button)
            {
                largePanel.Controls.Remove(button);
                informacionMesas.Remove(button);
                //int maxnum = maxNumeroMesa-1;
                if(button.Tag.ToString() == "Mesa Redonda " || button.Tag.ToString() == "Mesa Cuadrada ")
                {
                    Mesa.TotalMesas--;
                }
                
            }
        }

        private void CrearElemento(string tipo)
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
            nuevoElemento.Tag = tipo.ToString();
            nuevoElemento.Size = new Size(100, 100); // Ajusta el tamaño para que sea más adecuado para un botón redondo
            

            if (colores.ContainsKey(tipo))
            {
                nuevoElemento.BackColor = colores[tipo];
            }

            // Colocar el botón dentro de los límites visibles inicialmente
            int maxX = Math.Max(largePanel.Width - nuevoElemento.Width, 0);
            int maxY = Math.Max(largePanel.Height - nuevoElemento.Height, 0);
            Random rand = new Random();
            Point initialLocation = new Point(rand.Next(maxX), rand.Next(maxY));
            nuevoElemento.Location = initialLocation;

            MoverBotones moverBotones = new MoverBotones(nuevoElemento, largePanel, tableLayoutPanel1);
            nuevoElemento.ContextMenuStrip = contextMenuStrip1;
            largePanel.Controls.Add(nuevoElemento);
            nuevoElemento.BringToFront();

            Mesa infoMesa = new Mesa();

            if (tipo == "Mesa Redonda " || tipo == "Mesa Cuadrada ")
            {
                infoMesa.NumeroMesa = Mesa.TotalMesas;
                nuevoElemento.Text = tipo + infoMesa.NumeroMesa;
                Mesa.TotalMesas++;
                
            }
            infoMesa.Stopwatch = new Stopwatch();

            informacionMesas.Add(nuevoElemento, infoMesa);
            //numeroMesa++;
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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON Files (*.json)|*.json";
                openFileDialog.Title = "Abrir Información de Mesas y Botones";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = openFileDialog.FileName;
                    DataSerializer.LoadDataEditing(openFileDialog.FileName, informacionMesas, largePanel.Controls, colores, contextMenuStrip1, largePanel, tableLayoutPanel1);
                    timer1.Start();
                    // Actualiza maxNumeroMesa después de cargar los datos
                    foreach (var infoMesa in informacionMesas.Values)
                    {
                        if (infoMesa.NumeroMesa > maxNumeroMesa)
                        {
                            maxNumeroMesa = infoMesa.NumeroMesa;
                        }
                    }
                    maxNumeroMesa++;
                }
            }
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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
                // Preguntar si se desean guardar los cambios antes de crear una nueva plantilla
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

        private void mesasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mesaRedondaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearElemento("Mesa Redonda ");
        }

        private void mesaCuadradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearElemento("Mesa Cuadrada ");
        }

        private void sillasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sillasDeGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearElemento("Silla de grupo");
        }

        private void sillasIndividualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearElemento("silla individual");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void divisoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void divisoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CrearElemento("divisores");
        }

        private void paredesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearElemento("pared");
        }

        private void puertasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearElemento("puertas");
        }

        private void indoroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearElemento("inodoro");
        }

        private void urinarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearElemento("urinario");
        }

        private void lavaboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearElemento("lavabo");
        }

        private void cocinaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CrearElemento("Cocina");
        }

        private void heladeraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearElemento("Heladera");
        }

        private void lavaderoGrandeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearElemento("lavadero grande");
        }

        private void lavaderoChicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearElemento("lavadero chico");
        }


        private void pasarAPrevisualizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            PrevisualizacionForm previsualizacionForm = new PrevisualizacionForm();
            previsualizacionForm.ShowDialog();
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
