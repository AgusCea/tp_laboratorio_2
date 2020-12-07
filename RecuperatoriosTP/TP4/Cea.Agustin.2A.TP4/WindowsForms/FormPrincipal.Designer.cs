namespace WindowsForms
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCargarListaPelotas = new System.Windows.Forms.Button();
            this.btnCargarListaVideoJuegos = new System.Windows.Forms.Button();
            this.btnVender = new System.Windows.Forms.Button();
            this.btnSerializar = new System.Windows.Forms.Button();
            this.btnDeserializar = new System.Windows.Forms.Button();
            this.richTextBoxVentas = new System.Windows.Forms.RichTextBox();
            this.lblVentas = new System.Windows.Forms.Label();
            this.btnPelotasVendidas = new System.Windows.Forms.Button();
            this.btnJuegosVendidos = new System.Windows.Forms.Button();
            this.LblProductos = new System.Windows.Forms.Label();
            this.lblFechaHora = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Location = new System.Drawing.Point(12, 28);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.Size = new System.Drawing.Size(535, 265);
            this.dgvGrilla.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(12, 309);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Yellow;
            this.btnAgregar.Location = new System.Drawing.Point(181, 309);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(38, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "+";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.Orange;
            this.btnModificar.Location = new System.Drawing.Point(225, 309);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(38, 23);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "M";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Location = new System.Drawing.Point(269, 309);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(38, 23);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "-";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCargarListaPelotas
            // 
            this.btnCargarListaPelotas.Location = new System.Drawing.Point(360, 309);
            this.btnCargarListaPelotas.Name = "btnCargarListaPelotas";
            this.btnCargarListaPelotas.Size = new System.Drawing.Size(187, 23);
            this.btnCargarListaPelotas.TabIndex = 6;
            this.btnCargarListaPelotas.Text = "&Cargar Inventario Pelotas";
            this.btnCargarListaPelotas.UseVisualStyleBackColor = true;
            this.btnCargarListaPelotas.Click += new System.EventHandler(this.btnCargarListaPelotas_Click);
            // 
            // btnCargarListaVideoJuegos
            // 
            this.btnCargarListaVideoJuegos.Location = new System.Drawing.Point(360, 338);
            this.btnCargarListaVideoJuegos.Name = "btnCargarListaVideoJuegos";
            this.btnCargarListaVideoJuegos.Size = new System.Drawing.Size(187, 23);
            this.btnCargarListaVideoJuegos.TabIndex = 8;
            this.btnCargarListaVideoJuegos.Text = "&Cargar Inventario VideoJuegos";
            this.btnCargarListaVideoJuegos.UseVisualStyleBackColor = true;
            this.btnCargarListaVideoJuegos.Click += new System.EventHandler(this.btnCargarListaVideoJuegos_Click);
            // 
            // btnVender
            // 
            this.btnVender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnVender.Location = new System.Drawing.Point(181, 338);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(126, 23);
            this.btnVender.TabIndex = 9;
            this.btnVender.Text = "Vender";
            this.btnVender.UseVisualStyleBackColor = false;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // btnSerializar
            // 
            this.btnSerializar.Location = new System.Drawing.Point(652, 309);
            this.btnSerializar.Name = "btnSerializar";
            this.btnSerializar.Size = new System.Drawing.Size(116, 23);
            this.btnSerializar.TabIndex = 10;
            this.btnSerializar.Text = "&Serializar registros";
            this.btnSerializar.UseVisualStyleBackColor = true;
            this.btnSerializar.Click += new System.EventHandler(this.btnSerializar_Click);
            // 
            // btnDeserializar
            // 
            this.btnDeserializar.Location = new System.Drawing.Point(652, 338);
            this.btnDeserializar.Name = "btnDeserializar";
            this.btnDeserializar.Size = new System.Drawing.Size(116, 23);
            this.btnDeserializar.TabIndex = 11;
            this.btnDeserializar.Text = "&Deserializar registros";
            this.btnDeserializar.UseVisualStyleBackColor = true;
            this.btnDeserializar.Click += new System.EventHandler(this.btnDeserializar_Click);
            // 
            // richTextBoxVentas
            // 
            this.richTextBoxVentas.Location = new System.Drawing.Point(553, 28);
            this.richTextBoxVentas.Name = "richTextBoxVentas";
            this.richTextBoxVentas.Size = new System.Drawing.Size(408, 265);
            this.richTextBoxVentas.TabIndex = 12;
            this.richTextBoxVentas.Text = "";
            // 
            // lblVentas
            // 
            this.lblVentas.AutoSize = true;
            this.lblVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblVentas.Location = new System.Drawing.Point(553, 12);
            this.lblVentas.Name = "lblVentas";
            this.lblVentas.Size = new System.Drawing.Size(153, 13);
            this.lblVentas.TabIndex = 13;
            this.lblVentas.Text = "Ventas x tipo de producto";
            // 
            // btnPelotasVendidas
            // 
            this.btnPelotasVendidas.Location = new System.Drawing.Point(774, 309);
            this.btnPelotasVendidas.Name = "btnPelotasVendidas";
            this.btnPelotasVendidas.Size = new System.Drawing.Size(187, 23);
            this.btnPelotasVendidas.TabIndex = 14;
            this.btnPelotasVendidas.Text = "&Actualizar lista pelotas vendidas";
            this.btnPelotasVendidas.UseVisualStyleBackColor = true;
            this.btnPelotasVendidas.Click += new System.EventHandler(this.btnPelotasVendidas_Click);
            // 
            // btnJuegosVendidos
            // 
            this.btnJuegosVendidos.Location = new System.Drawing.Point(774, 338);
            this.btnJuegosVendidos.Name = "btnJuegosVendidos";
            this.btnJuegosVendidos.Size = new System.Drawing.Size(187, 23);
            this.btnJuegosVendidos.TabIndex = 15;
            this.btnJuegosVendidos.Text = "&Actualizar lista juegos vendidos";
            this.btnJuegosVendidos.UseVisualStyleBackColor = true;
            this.btnJuegosVendidos.Click += new System.EventHandler(this.btnJuegosVendidos_Click);
            // 
            // LblProductos
            // 
            this.LblProductos.AutoSize = true;
            this.LblProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.LblProductos.Location = new System.Drawing.Point(9, 9);
            this.LblProductos.Name = "LblProductos";
            this.LblProductos.Size = new System.Drawing.Size(171, 13);
            this.LblProductos.TabIndex = 16;
            this.LblProductos.Text = "Inventario x tipo de producto";
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.AutoSize = true;
            this.lblFechaHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFechaHora.Location = new System.Drawing.Point(840, 12);
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(0, 13);
            this.lblFechaHora.TabIndex = 17;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 373);
            this.Controls.Add(this.lblFechaHora);
            this.Controls.Add(this.LblProductos);
            this.Controls.Add(this.btnJuegosVendidos);
            this.Controls.Add(this.btnPelotasVendidas);
            this.Controls.Add(this.lblVentas);
            this.Controls.Add(this.richTextBoxVentas);
            this.Controls.Add(this.btnDeserializar);
            this.Controls.Add(this.btnSerializar);
            this.Controls.Add(this.btnVender);
            this.Controls.Add(this.btnCargarListaVideoJuegos);
            this.Controls.Add(this.btnCargarListaPelotas);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvGrilla);
            this.Name = "FormPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrilla;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCargarListaPelotas;
        private System.Windows.Forms.Button btnCargarListaVideoJuegos;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.Button btnSerializar;
        private System.Windows.Forms.Button btnDeserializar;
        private System.Windows.Forms.RichTextBox richTextBoxVentas;
        private System.Windows.Forms.Label lblVentas;
        private System.Windows.Forms.Button btnPelotasVendidas;
        private System.Windows.Forms.Button btnJuegosVendidos;
        private System.Windows.Forms.Label LblProductos;
        private System.Windows.Forms.Label lblFechaHora;
    }
}

