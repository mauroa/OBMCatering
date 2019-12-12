namespace OBMCatering.Presentacion
{
    partial class FacturasForm
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
            this.grvFacturas = new System.Windows.Forms.DataGridView();
            this.lblClienteTitulo = new System.Windows.Forms.Label();
            this.lblFechaInicioTitulo = new System.Windows.Forms.Label();
            this.lblFechaFinTitulo = new System.Windows.Forms.Label();
            this.lblComensalesTitulo = new System.Windows.Forms.Label();
            this.lblRecetasTitulo = new System.Windows.Forms.Label();
            this.lblPrecioCalculado = new System.Windows.Forms.Label();
            this.btnCobrada = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblComensales = new System.Windows.Forms.Label();
            this.lblRecetas = new System.Windows.Forms.Label();
            this.lblFechaTitulo = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPesos = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblFacturas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grvFacturas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grvFacturas
            // 
            this.grvFacturas.AllowUserToAddRows = false;
            this.grvFacturas.AllowUserToDeleteRows = false;
            this.grvFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvFacturas.Dock = System.Windows.Forms.DockStyle.Top;
            this.grvFacturas.Location = new System.Drawing.Point(0, 0);
            this.grvFacturas.MultiSelect = false;
            this.grvFacturas.Name = "grvFacturas";
            this.grvFacturas.ReadOnly = true;
            this.grvFacturas.RowHeadersWidth = 82;
            this.grvFacturas.RowTemplate.Height = 33;
            this.grvFacturas.Size = new System.Drawing.Size(1469, 414);
            this.grvFacturas.TabIndex = 24;
            // 
            // lblClienteTitulo
            // 
            this.lblClienteTitulo.AutoSize = true;
            this.lblClienteTitulo.Location = new System.Drawing.Point(272, 18);
            this.lblClienteTitulo.Name = "lblClienteTitulo";
            this.lblClienteTitulo.Size = new System.Drawing.Size(79, 25);
            this.lblClienteTitulo.TabIndex = 0;
            this.lblClienteTitulo.Text = "Cliente";
            // 
            // lblFechaInicioTitulo
            // 
            this.lblFechaInicioTitulo.AutoSize = true;
            this.lblFechaInicioTitulo.Location = new System.Drawing.Point(671, 18);
            this.lblFechaInicioTitulo.Name = "lblFechaInicioTitulo";
            this.lblFechaInicioTitulo.Size = new System.Drawing.Size(74, 25);
            this.lblFechaInicioTitulo.TabIndex = 2;
            this.lblFechaInicioTitulo.Text = "Desde";
            // 
            // lblFechaFinTitulo
            // 
            this.lblFechaFinTitulo.AutoSize = true;
            this.lblFechaFinTitulo.Location = new System.Drawing.Point(902, 18);
            this.lblFechaFinTitulo.Name = "lblFechaFinTitulo";
            this.lblFechaFinTitulo.Size = new System.Drawing.Size(68, 25);
            this.lblFechaFinTitulo.TabIndex = 14;
            this.lblFechaFinTitulo.Text = "Hasta";
            // 
            // lblComensalesTitulo
            // 
            this.lblComensalesTitulo.AutoSize = true;
            this.lblComensalesTitulo.Location = new System.Drawing.Point(1132, 18);
            this.lblComensalesTitulo.Name = "lblComensalesTitulo";
            this.lblComensalesTitulo.Size = new System.Drawing.Size(131, 25);
            this.lblComensalesTitulo.TabIndex = 15;
            this.lblComensalesTitulo.Text = "Comensales";
            // 
            // lblRecetasTitulo
            // 
            this.lblRecetasTitulo.AutoSize = true;
            this.lblRecetasTitulo.Location = new System.Drawing.Point(19, 109);
            this.lblRecetasTitulo.Name = "lblRecetasTitulo";
            this.lblRecetasTitulo.Size = new System.Drawing.Size(91, 25);
            this.lblRecetasTitulo.TabIndex = 24;
            this.lblRecetasTitulo.Text = "Recetas";
            // 
            // lblPrecioCalculado
            // 
            this.lblPrecioCalculado.AutoSize = true;
            this.lblPrecioCalculado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioCalculado.Location = new System.Drawing.Point(127, 256);
            this.lblPrecioCalculado.Name = "lblPrecioCalculado";
            this.lblPrecioCalculado.Size = new System.Drawing.Size(0, 31);
            this.lblPrecioCalculado.TabIndex = 27;
            // 
            // btnCobrada
            // 
            this.btnCobrada.ForeColor = System.Drawing.Color.Black;
            this.btnCobrada.Location = new System.Drawing.Point(1271, 238);
            this.btnCobrada.Name = "btnCobrada";
            this.btnCobrada.Size = new System.Drawing.Size(148, 50);
            this.btnCobrada.TabIndex = 30;
            this.btnCobrada.Text = "Cobrada";
            this.btnCobrada.UseVisualStyleBackColor = true;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(272, 62);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(0, 25);
            this.lblCliente.TabIndex = 31;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.Location = new System.Drawing.Point(671, 62);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(0, 25);
            this.lblFechaInicio.TabIndex = 32;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.Location = new System.Drawing.Point(902, 62);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(0, 25);
            this.lblFechaFin.TabIndex = 33;
            // 
            // lblComensales
            // 
            this.lblComensales.AutoSize = true;
            this.lblComensales.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComensales.Location = new System.Drawing.Point(1132, 62);
            this.lblComensales.Name = "lblComensales";
            this.lblComensales.Size = new System.Drawing.Size(0, 25);
            this.lblComensales.TabIndex = 34;
            // 
            // lblRecetas
            // 
            this.lblRecetas.AutoSize = true;
            this.lblRecetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecetas.Location = new System.Drawing.Point(19, 153);
            this.lblRecetas.Name = "lblRecetas";
            this.lblRecetas.Size = new System.Drawing.Size(0, 25);
            this.lblRecetas.TabIndex = 35;
            // 
            // lblFechaTitulo
            // 
            this.lblFechaTitulo.AutoSize = true;
            this.lblFechaTitulo.Location = new System.Drawing.Point(21, 18);
            this.lblFechaTitulo.Name = "lblFechaTitulo";
            this.lblFechaTitulo.Size = new System.Drawing.Size(72, 25);
            this.lblFechaTitulo.TabIndex = 36;
            this.lblFechaTitulo.Text = "Fecha";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(21, 62);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 25);
            this.lblFecha.TabIndex = 37;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Controls.Add(this.lblFechaTitulo);
            this.panel1.Controls.Add(this.lblRecetas);
            this.panel1.Controls.Add(this.lblComensales);
            this.panel1.Controls.Add(this.lblFechaFin);
            this.panel1.Controls.Add(this.lblFechaInicio);
            this.panel1.Controls.Add(this.lblCliente);
            this.panel1.Controls.Add(this.btnCobrada);
            this.panel1.Controls.Add(this.lblPesos);
            this.panel1.Controls.Add(this.lblPrecioCalculado);
            this.panel1.Controls.Add(this.lblPrecio);
            this.panel1.Controls.Add(this.lblRecetasTitulo);
            this.panel1.Controls.Add(this.lblComensalesTitulo);
            this.panel1.Controls.Add(this.lblFechaFinTitulo);
            this.panel1.Controls.Add(this.lblFechaInicioTitulo);
            this.panel1.Controls.Add(this.lblClienteTitulo);
            this.panel1.Location = new System.Drawing.Point(12, 495);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1433, 307);
            this.panel1.TabIndex = 26;
            // 
            // lblPesos
            // 
            this.lblPesos.AutoSize = true;
            this.lblPesos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesos.Location = new System.Drawing.Point(98, 257);
            this.lblPesos.Name = "lblPesos";
            this.lblPesos.Size = new System.Drawing.Size(30, 31);
            this.lblPesos.TabIndex = 29;
            this.lblPesos.Text = "$";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(19, 262);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(73, 25);
            this.lblPrecio.TabIndex = 26;
            this.lblPrecio.Text = "Precio";
            // 
            // lblFacturas
            // 
            this.lblFacturas.AutoSize = true;
            this.lblFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacturas.ForeColor = System.Drawing.Color.Black;
            this.lblFacturas.Location = new System.Drawing.Point(12, 443);
            this.lblFacturas.Name = "lblFacturas";
            this.lblFacturas.Size = new System.Drawing.Size(104, 25);
            this.lblFacturas.TabIndex = 25;
            this.lblFacturas.Text = "Facturas";
            // 
            // FacturasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1469, 827);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblFacturas);
            this.Controls.Add(this.grvFacturas);
            this.Name = "FacturasForm";
            this.Text = "Facturas";
            this.Load += new System.EventHandler(this.FacturasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvFacturas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView grvFacturas;
        private System.Windows.Forms.Label lblClienteTitulo;
        private System.Windows.Forms.Label lblFechaInicioTitulo;
        private System.Windows.Forms.Label lblFechaFinTitulo;
        private System.Windows.Forms.Label lblComensalesTitulo;
        private System.Windows.Forms.Label lblRecetasTitulo;
        private System.Windows.Forms.Label lblPrecioCalculado;
        private System.Windows.Forms.Button btnCobrada;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblComensales;
        private System.Windows.Forms.Label lblRecetas;
        private System.Windows.Forms.Label lblFechaTitulo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPesos;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblFacturas;
    }
}