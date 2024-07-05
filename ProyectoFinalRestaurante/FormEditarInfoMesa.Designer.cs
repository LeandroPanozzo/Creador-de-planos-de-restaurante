namespace ProyectoFinalRestaurante
{
    partial class FormEditarInfoMesa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditarInfoMesa));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBoxEditarNumeroMesa = new TextBox();
            radioButtonLibre = new RadioButton();
            radioButtonReservada = new RadioButton();
            radioButtonOcupada = new RadioButton();
            textBoxMozoEncargado = new TextBox();
            dateTimePickerHoraReserva = new DateTimePicker();
            dateTimePickerHoraSalida = new DateTimePicker();
            dataGridViewInsumosEditar = new DataGridView();
            AceptarBtn = new Button();
            CancelarBtn = new Button();
            EliminarInformacionBtn = new Button();
            label9 = new Label();
            textBoxTotal = new TextBox();
            label10 = new Label();
            label7 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridViewInsumosEditar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(129, 15);
            label1.TabIndex = 0;
            label1.Text = "Editar numero de mesa";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 46);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 1;
            label2.Text = "Estado de la mesa";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 80);
            label3.Name = "label3";
            label3.Size = new Size(96, 15);
            label3.TabIndex = 2;
            label3.Text = "Mozo encargado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 116);
            label4.Name = "label4";
            label4.Size = new Size(160, 15);
            label4.TabIndex = 3;
            label4.Text = "Horario de reserva (opcional)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 150);
            label5.Name = "label5";
            label5.Size = new Size(96, 15);
            label5.TabIndex = 4;
            label5.Text = "Horario de salida";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 181);
            label6.Name = "label6";
            label6.Size = new Size(95, 15);
            label6.TabIndex = 5;
            label6.Text = "Editar consumos";
            // 
            // textBoxEditarNumeroMesa
            // 
            textBoxEditarNumeroMesa.Location = new Point(191, 10);
            textBoxEditarNumeroMesa.Name = "textBoxEditarNumeroMesa";
            textBoxEditarNumeroMesa.Size = new Size(100, 23);
            textBoxEditarNumeroMesa.TabIndex = 8;
            textBoxEditarNumeroMesa.TextChanged += textBoxEditarNumeroMesa_TextChanged;
            // 
            // radioButtonLibre
            // 
            radioButtonLibre.AutoSize = true;
            radioButtonLibre.Location = new Point(191, 46);
            radioButtonLibre.Name = "radioButtonLibre";
            radioButtonLibre.Size = new Size(51, 19);
            radioButtonLibre.TabIndex = 9;
            radioButtonLibre.TabStop = true;
            radioButtonLibre.Text = "Libre";
            radioButtonLibre.UseVisualStyleBackColor = true;
            radioButtonLibre.CheckedChanged += radioButtonLibre_CheckedChanged;
            // 
            // radioButtonReservada
            // 
            radioButtonReservada.AutoSize = true;
            radioButtonReservada.Location = new Point(335, 46);
            radioButtonReservada.Name = "radioButtonReservada";
            radioButtonReservada.Size = new Size(78, 19);
            radioButtonReservada.TabIndex = 10;
            radioButtonReservada.TabStop = true;
            radioButtonReservada.Text = "Reservada";
            radioButtonReservada.UseVisualStyleBackColor = true;
            radioButtonReservada.CheckedChanged += radioButtonReservada_CheckedChanged;
            // 
            // radioButtonOcupada
            // 
            radioButtonOcupada.AutoSize = true;
            radioButtonOcupada.Location = new Point(487, 46);
            radioButtonOcupada.Name = "radioButtonOcupada";
            radioButtonOcupada.Size = new Size(73, 19);
            radioButtonOcupada.TabIndex = 11;
            radioButtonOcupada.TabStop = true;
            radioButtonOcupada.Text = "Ocupada";
            radioButtonOcupada.UseVisualStyleBackColor = true;
            radioButtonOcupada.CheckedChanged += radioButtonOcupada_CheckedChanged;
            // 
            // textBoxMozoEncargado
            // 
            textBoxMozoEncargado.Location = new Point(191, 77);
            textBoxMozoEncargado.Name = "textBoxMozoEncargado";
            textBoxMozoEncargado.Size = new Size(388, 23);
            textBoxMozoEncargado.TabIndex = 12;
            textBoxMozoEncargado.TextChanged += textBoxMozoEncargado_TextChanged;
            // 
            // dateTimePickerHoraReserva
            // 
            dateTimePickerHoraReserva.Format = DateTimePickerFormat.Time;
            dateTimePickerHoraReserva.Location = new Point(191, 116);
            dateTimePickerHoraReserva.Name = "dateTimePickerHoraReserva";
            dateTimePickerHoraReserva.ShowUpDown = true;
            dateTimePickerHoraReserva.Size = new Size(67, 23);
            dateTimePickerHoraReserva.TabIndex = 13;
            dateTimePickerHoraReserva.ValueChanged += dateTimePickerHoraReserva_ValueChanged;
            // 
            // dateTimePickerHoraSalida
            // 
            dateTimePickerHoraSalida.Format = DateTimePickerFormat.Time;
            dateTimePickerHoraSalida.Location = new Point(191, 150);
            dateTimePickerHoraSalida.Name = "dateTimePickerHoraSalida";
            dateTimePickerHoraSalida.ShowUpDown = true;
            dateTimePickerHoraSalida.Size = new Size(67, 23);
            dateTimePickerHoraSalida.TabIndex = 14;
            dateTimePickerHoraSalida.ValueChanged += dateTimePickerHoraSalida_ValueChanged;
            // 
            // dataGridViewInsumosEditar
            // 
            dataGridViewInsumosEditar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewInsumosEditar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInsumosEditar.Location = new Point(113, 181);
            dataGridViewInsumosEditar.Name = "dataGridViewInsumosEditar";
            dataGridViewInsumosEditar.Size = new Size(466, 218);
            dataGridViewInsumosEditar.TabIndex = 15;
            dataGridViewInsumosEditar.CellContentClick += dataGridViewInsumosEditar_CellContentClick;
            // 
            // AceptarBtn
            // 
            AceptarBtn.Anchor = AnchorStyles.Bottom;
            AceptarBtn.Location = new Point(97, 450);
            AceptarBtn.Name = "AceptarBtn";
            AceptarBtn.Size = new Size(75, 23);
            AceptarBtn.TabIndex = 16;
            AceptarBtn.Text = "Aceptar";
            AceptarBtn.UseVisualStyleBackColor = true;
            AceptarBtn.Click += AceptarBtn_Click;
            // 
            // CancelarBtn
            // 
            CancelarBtn.Anchor = AnchorStyles.Bottom;
            CancelarBtn.Location = new Point(249, 450);
            CancelarBtn.Name = "CancelarBtn";
            CancelarBtn.Size = new Size(75, 23);
            CancelarBtn.TabIndex = 17;
            CancelarBtn.Text = "Cancelar";
            CancelarBtn.UseVisualStyleBackColor = true;
            CancelarBtn.Click += CancelarBtn_Click;
            // 
            // EliminarInformacionBtn
            // 
            EliminarInformacionBtn.Anchor = AnchorStyles.Bottom;
            EliminarInformacionBtn.Location = new Point(407, 450);
            EliminarInformacionBtn.Name = "EliminarInformacionBtn";
            EliminarInformacionBtn.Size = new Size(172, 23);
            EliminarInformacionBtn.TabIndex = 18;
            EliminarInformacionBtn.Text = "Eliminar toda la informacion";
            EliminarInformacionBtn.UseVisualStyleBackColor = true;
            EliminarInformacionBtn.Click += EliminarInformacionBtn_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(11, 413);
            label9.Name = "label9";
            label9.Size = new Size(32, 15);
            label9.TabIndex = 19;
            label9.Text = "Total";
            // 
            // textBoxTotal
            // 
            textBoxTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTotal.Location = new Point(191, 405);
            textBoxTotal.Name = "textBoxTotal";
            textBoxTotal.Size = new Size(388, 23);
            textBoxTotal.TabIndex = 20;
            textBoxTotal.TextChanged += textBoxTotal_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(298, 116);
            label10.Name = "label10";
            label10.Size = new Size(115, 15);
            label10.TabIndex = 21;
            label10.Text = "Tiempo Transcurrido";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(457, 116);
            label7.Name = "label7";
            label7.Size = new Size(45, 15);
            label7.TabIndex = 22;
            label7.Text = "tiempo";
            label7.Click += label7_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // FormEditarInfoMesa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 476);
            Controls.Add(label7);
            Controls.Add(label10);
            Controls.Add(textBoxTotal);
            Controls.Add(label9);
            Controls.Add(EliminarInformacionBtn);
            Controls.Add(CancelarBtn);
            Controls.Add(AceptarBtn);
            Controls.Add(dataGridViewInsumosEditar);
            Controls.Add(dateTimePickerHoraSalida);
            Controls.Add(dateTimePickerHoraReserva);
            Controls.Add(textBoxMozoEncargado);
            Controls.Add(radioButtonOcupada);
            Controls.Add(radioButtonReservada);
            Controls.Add(radioButtonLibre);
            Controls.Add(textBoxEditarNumeroMesa);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(607, 515);
            MinimumSize = new Size(607, 404);
            Name = "FormEditarInfoMesa";
            Text = "FormEditarInfoMesa";
            Load += FormEditarInfoMesa_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewInsumosEditar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBoxEditarNumeroMesa;
        private RadioButton radioButtonLibre;
        private RadioButton radioButtonReservada;
        private RadioButton radioButtonOcupada;
        private TextBox textBoxMozoEncargado;
        private DateTimePicker dateTimePickerHoraReserva;
        private DateTimePicker dateTimePickerHoraSalida;
        private DataGridView dataGridViewInsumosEditar;
        private Button AceptarBtn;
        private Button CancelarBtn;
        private Button EliminarInformacionBtn;
        private Label label9;
        private TextBox textBoxTotal;
        private Label label10;
        private System.Windows.Forms.Timer timer1;
    }
}