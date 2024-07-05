using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
namespace ProyectoFinalRestaurante
{
    public partial class FormEditarInfoMesa : Form
    {
        public Mesa InformacionMes { get; set; }
        public Button boton;
        public FormEditarInfoMesa(Mesa infoMesa, Button boton)
        {
            InitializeComponent();
            //?? Se utiliza para proporcionar un valor predeterminado en caso de que una expresión sea nula. Este operador evalúa
            //la expresión a la izquierda del ?? y, si es nula, devuelve la expresión a la derecha caso contrario la de la izq
            InformacionMes = infoMesa ?? new Mesa();
            this.boton = boton ?? new Button();

            // Agregar columnas al DataGridView
            dataGridViewInsumosEditar.Columns.Add("Insumos", "Insumos");
            dataGridViewInsumosEditar.Columns.Add("Cantidad", "Cantidad");
            dataGridViewInsumosEditar.Columns.Add("PrecioPorUnidad", "Precio por Unidad");
            var precioPorCantidadColumn = new DataGridViewTextBoxColumn
            {
                Name = "PrecioPorCantidad",
                HeaderText = "Precio por Cantidad",
                ReadOnly = true // Hacer que la columna sea de solo lectura
            };
            dataGridViewInsumosEditar.Columns.Add(precioPorCantidadColumn);

            // Configurar el evento CellValueChanged para calcular el precio por cantidad
            dataGridViewInsumosEditar.CellValueChanged += dataGridViewInsumosEditar_CellValueChanged;
            dataGridViewInsumosEditar.EditingControlShowing += dataGridViewInsumosEditar_EditingControlShowing;

            CargarInformacion();
        }

        private void CargarInformacion()
        {
            textBoxEditarNumeroMesa.Text = InformacionMes.NumeroMesa.ToString();

            // Asignar un valor predeterminado si MozoEncargado está vacío
            textBoxMozoEncargado.Text = InformacionMes.MozoEncargado ?? "No asignado";

            // Asignar un valor predeterminado si HoraReserva está vacía
            dateTimePickerHoraReserva.Value = InformacionMes.HoraReserva ?? DateTime.Now;

            // Asignar un valor predeterminado si HoraSalida está vacía
            dateTimePickerHoraSalida.Value = InformacionMes.HoraSalida ?? DateTime.Now.AddHours(1);

            // Según el valor de Estado (Libre, Reservada u Ocupada), se selecciona el RadioButton correspondiente. Si Estado está
            // vacío o no coincide con ninguna de las opciones, se selecciona Libre por defecto.
            switch (InformacionMes.Estado)
            {
                case "Libre":
                    radioButtonLibre.Checked = true;
                    break;
                case "Reservada":
                    radioButtonReservada.Checked = true;
                    break;
                case "Ocupada":
                    radioButtonOcupada.Checked = true;
                    break;
                default:
                    // Opción predeterminada si el estado está vacío
                    radioButtonLibre.Checked = true;
                    break;
            }

            // Limpiar el DataGridView antes de cargar los consumos
            dataGridViewInsumosEditar.Rows.Clear();

            // Cargar los consumos en el DataGridView
            //Este bloque de código itera a través de los consumos en InformacionMes.Consumos y los agrega al DataGridView. Los
            //consumos se dividen en partes utilizando el carácter : como delimitador. Si hay 4 partes, se agregan todas al
            //DataGridView; si hay 2 partes, solo se agregan las dos primeras.
            if (InformacionMes.Consumos != null)
            {
                foreach (var consumo in InformacionMes.Consumos)
                {
                    var partes = consumo.Split(':');
                    if (partes.Length == 4) // Asegurarse de que haya suficientes partes
                    {
                        dataGridViewInsumosEditar.Rows.Add(partes[0].Trim(), partes[1].Trim(), partes[2].Trim(), partes[3].Trim());
                    }
                    else if (partes.Length == 2)
                    {
                        dataGridViewInsumosEditar.Rows.Add(partes[0].Trim(), partes[1].Trim());
                    }
                }
            }

            // Calcular el total inicial
            CalcularTotal();
        }
        private void dataGridViewInsumosEditar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Se comprueba si la celda modificada pertenece a la columna "Cantidad" o "PrecioPorUnidad". Si es así, se procede con
            // el cálculo; de lo contrario, el método termina.
            if (e.ColumnIndex == dataGridViewInsumosEditar.Columns["Cantidad"].Index ||
                e.ColumnIndex == dataGridViewInsumosEditar.Columns["PrecioPorUnidad"].Index)
            {
                // Se obtiene el valor de las celdas "Cantidad" y "PrecioPorUnidad" de la fila modificada. Si ambos valores no son
                // nulos, se procede con la conversión y el cálculo.
                if (dataGridViewInsumosEditar.Rows[e.RowIndex].Cells["Cantidad"].Value != null &&
                    dataGridViewInsumosEditar.Rows[e.RowIndex].Cells["PrecioPorUnidad"].Value != null)
                {
                    string cantidadStr = dataGridViewInsumosEditar.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString();
                    string precioPorUnidadStr = dataGridViewInsumosEditar.Rows[e.RowIndex].Cells["PrecioPorUnidad"].Value.ToString();

                    // Se reemplazan las comas por puntos para asegurar que los valores se puedan convertir correctamente a decimal.
                    cantidadStr = cantidadStr.Replace(',', '.');
                    precioPorUnidadStr = precioPorUnidadStr.Replace(',', '.');
                    //Se intenta convertir los valores de cantidadStr y precioPorUnidadStr a decimal utilizando la configuración
                    //de cultura invariable (CultureInfo.InvariantCulture).
                    if (decimal.TryParse(cantidadStr, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal cantidad) &&
                        decimal.TryParse(precioPorUnidadStr, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precioPorUnidad))
                    {
                        //Si la conversión es exitosa, se calcula el precio por cantidad multiplicando cantidad por precioPorUnidad.
                        //El resultado se asigna a la celda "PrecioPorCantidad" de la fila modificada, formateado con dos decimales.
                        decimal precioPorCantidad = cantidad * precioPorUnidad;
                        dataGridViewInsumosEditar.Rows[e.RowIndex].Cells["PrecioPorCantidad"].Value = precioPorCantidad.ToString("0.00");
                    }
                    else
                    {
                        //Si la conversión falla, se asigna "0.00" a la celda "PrecioPorCantidad".
                        dataGridViewInsumosEditar.Rows[e.RowIndex].Cells["PrecioPorCantidad"].Value = "0.00";
                    }
                }
                else
                {
                    dataGridViewInsumosEditar.Rows[e.RowIndex].Cells["PrecioPorCantidad"].Value = "0.00";
                }

                // Calcular el total actualizado
                CalcularTotal();
            }
        }


        private void dataGridViewInsumosEditar_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //Desvincula cualquier manejador KeyPress previamente asociado al control de edición para evitar múltiples suscripciones.
            //Sin desvinculación, si el usuario edita varias celdas consecutivamente, cada pulsación de tecla podría disparar el
            //manejador Column_KeyPress múltiples veces
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
            //Se comprueba si la celda actualmente en edición pertenece a la columna de índice 1 (Cantidad) o de índice 2
            //(PrecioPorUnidad). Si es así, se procede a asociar el evento KeyPress con el manejador Column_KeyPress.
            if (dataGridViewInsumosEditar.CurrentCell.ColumnIndex == 1 || dataGridViewInsumosEditar.CurrentCell.ColumnIndex == 2) // Cantidad or PrecioPorUnidad
            {
                //Se obtiene el control de edición actual como un TextBox. Si el control es efectivamente un TextBox, se asocia el
                //evento KeyPress con el manejador Column_KeyPress. Esto asegura que mientras el usuario está editando las celdas
                //de las columnas "Cantidad" o "PrecioPorUnidad", las entradas del teclado se filtren mediante Column_KeyPress.
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }
        //para controlar y validar los caracteres que el usuario puede ingresar.Este método se asegura de que solo se permitan
        //números, la tecla de retroceso, y un único punto o coma decimal en las celdas de las columnas "Cantidad" y
        //"PrecioPorUnidad"
        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char.IsControl(e.KeyChar): Verifica si la tecla presionada es una tecla de control (como la tecla de retroceso).
            //char.IsDigit(e.KeyChar): Verifica si la tecla presionada es un dígito (0-9).
            //e.KeyChar != ',': Permite la coma decimal.
            //e.KeyChar != '.': Permite el punto decimal.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                MessageBox.Show("Debe ingresar valores numéricos", "Entrada no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // e.KeyChar == '.' || e.KeyChar == ',': Verifica si la tecla presionada es un punto o una coma.
            //tb != null: Se asegura de que el control de edición sea un TextBox.
            //(tb.Text.IndexOf('.') > -1 || tb.Text.IndexOf(',') > -1): Verifica si el TextBox ya contiene un punto o una coma.
            TextBox tb = sender as TextBox;
            if ((e.KeyChar == '.' || e.KeyChar == ',') && tb != null && (tb.Text.IndexOf('.') > -1 || tb.Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        //Este método se encarga de calcular el total de los precios por cantidad de todos los insumos en el DataGridView y
        //actualizar el TextBox y la propiedad Pagar de la clase Mesa
        private void CalcularTotal()
        {
            decimal total = 0;
            //Recorre todas las filas del DataGridView llamado dataGridViewInsumosEditar
            foreach (DataGridViewRow row in dataGridViewInsumosEditar.Rows)
            {
                //Verifica si la celda PrecioPorCantidad de la fila actual no es null y si el valor puede convertirse a decimal.
                if (row.Cells["PrecioPorCantidad"].Value != null && decimal.TryParse(row.Cells["PrecioPorCantidad"].Value.ToString(), out decimal precioPorCantidad))
                {
                    //Si ambas condiciones son verdaderas, agrega el valor de PrecioPorCantidad a total.
                    total += precioPorCantidad;
                }
            }
            //Actualiza el TextBox textBoxTotal con el valor total, formateado a dos decimales
            textBoxTotal.Text = total.ToString("0.00");
            InformacionMes.Pagar = total; // Asignar el total a la propiedad Pagar
        }

        private void textBoxEditarNumeroMesa_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonLibre_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerHoraReserva.Enabled = false;
            boton.BackColor = Color.GreenYellow;
            timer1.Stop();
            InformacionMes.Stopwatch.Reset();
        }

        private void radioButtonReservada_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerHoraReserva.Enabled = true;
            boton.BackColor = Color.LightBlue; // para indicar visualmente que la mesa está libre
            timer1.Stop();
            InformacionMes.Stopwatch.Reset();
        }

        Stopwatch sw = new Stopwatch();

        private void radioButtonOcupada_CheckedChanged(object sender, EventArgs e)
        {
            
            

            InformacionMes.Stopwatch.Start();
            timer1.Start();
            dateTimePickerHoraReserva.Enabled = false;
            boton.BackColor = Color.OrangeRed;

        }

        private void textBoxMozoEncargado_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerHoraReserva_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerHoraSalida_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewInsumosEditar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AceptarBtn_Click(object sender, EventArgs e)
        {
            //ActualizarInformacionMesa() para actualizar los datos de la mesa con la información del formulario.
            ActualizarInformacionMesa();
            //Serializa la información de la mesa (InformacionMes) a formato JSON.
            //Escribe el JSON resultante en un archivo llamado informacionMesaEditada.json.
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelarBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ActualizarInformacionMesa()
        {
            // Asignar un valor predeterminado si el campo de número de mesa está vacío
            if (string.IsNullOrWhiteSpace(textBoxEditarNumeroMesa.Text))
            {
                InformacionMes.NumeroMesa = InformacionMes.NumeroMesa; // Valor predeterminado
            }
            else
            {
                InformacionMes.NumeroMesa = int.Parse(textBoxEditarNumeroMesa.Text);
            }

            InformacionMes.Estado = radioButtonLibre.Checked ? "Libre" : radioButtonReservada.Checked ? "Reservada" : "Ocupada";
            InformacionMes.MozoEncargado = textBoxMozoEncargado.Text;
            InformacionMes.HoraReserva = dateTimePickerHoraReserva.Value;
            InformacionMes.HoraSalida = dateTimePickerHoraSalida.Value;
            InformacionMes.Consumos.Clear();
            foreach (DataGridViewRow row in dataGridViewInsumosEditar.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                {
                    InformacionMes.Consumos.Add($"{row.Cells[0].Value}: {row.Cells[1].Value}: {row.Cells[2].Value}: {row.Cells[3].Value}");
                }
            }

            // Actualizar la propiedad Pagar con el total calculado
            InformacionMes.Pagar = decimal.TryParse(textBoxTotal.Text, out decimal total) ? total : 0;
        }



        private void FormEditarInfoMesa_Load(object sender, EventArgs e)
        {

        }

        private void EliminarInformacionBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea eliminar los cambios?", "Eliminar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Limpiar los campos del formulario
                textBoxEditarNumeroMesa.Text = string.Empty;
                textBoxMozoEncargado.Text = string.Empty;
                dateTimePickerHoraReserva.Value = DateTime.Now;
                dateTimePickerHoraSalida.Value = DateTime.Now.AddHours(1);
                radioButtonLibre.Checked = true;
                // Limpiar el DataGridView
                dataGridViewInsumosEditar.Rows.Clear();
                // Limpiar el total
                textBoxTotal.Text = "0.00";
            }
        }

        private void textBoxTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = InformacionMes.Stopwatch.Elapsed.ToString("hh\\:mm\\:ss");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
