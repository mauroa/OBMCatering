﻿namespace OBMCatering.Presentacion
{
    partial class OrdenesVentaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdenesVentaForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPesos = new System.Windows.Forms.Label();
            this.btnCalcularPrecio = new System.Windows.Forms.Button();
            this.lblPrecioCalculado = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblRecetas = new System.Windows.Forms.Label();
            this.lstRecetas = new System.Windows.Forms.ListBox();
            this.chkAprobada = new System.Windows.Forms.CheckBox();
            this.txtComensales = new System.Windows.Forms.TextBox();
            this.lblComensales = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.cboClientes = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.grvPedidos = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblPesos);
            this.panel1.Controls.Add(this.btnCalcularPrecio);
            this.panel1.Controls.Add(this.lblPrecioCalculado);
            this.panel1.Controls.Add(this.lblPrecio);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.lblRecetas);
            this.panel1.Controls.Add(this.lstRecetas);
            this.panel1.Controls.Add(this.chkAprobada);
            this.panel1.Controls.Add(this.txtComensales);
            this.panel1.Controls.Add(this.lblComensales);
            this.panel1.Controls.Add(this.lblFechaFin);
            this.panel1.Controls.Add(this.dtpFechaFin);
            this.panel1.Controls.Add(this.dtpFechaInicio);
            this.panel1.Controls.Add(this.lblFechaInicio);
            this.panel1.Controls.Add(this.cboClientes);
            this.panel1.Controls.Add(this.lblCliente);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(927, 437);
            this.panel1.TabIndex = 0;
            // 
            // lblPesos
            // 
            this.lblPesos.AutoSize = true;
            this.lblPesos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesos.Location = new System.Drawing.Point(99, 373);
            this.lblPesos.Name = "lblPesos";
            this.lblPesos.Size = new System.Drawing.Size(30, 31);
            this.lblPesos.TabIndex = 29;
            this.lblPesos.Text = "$";
            // 
            // btnCalcularPrecio
            // 
            this.btnCalcularPrecio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalcularPrecio.ForeColor = System.Drawing.Color.Black;
            this.btnCalcularPrecio.Location = new System.Drawing.Point(546, 367);
            this.btnCalcularPrecio.Name = "btnCalcularPrecio";
            this.btnCalcularPrecio.Size = new System.Drawing.Size(193, 50);
            this.btnCalcularPrecio.TabIndex = 6;
            this.btnCalcularPrecio.Text = "Calcular Precio";
            this.btnCalcularPrecio.UseVisualStyleBackColor = true;
            // 
            // lblPrecioCalculado
            // 
            this.lblPrecioCalculado.AutoSize = true;
            this.lblPrecioCalculado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioCalculado.Location = new System.Drawing.Point(135, 374);
            this.lblPrecioCalculado.Name = "lblPrecioCalculado";
            this.lblPrecioCalculado.Size = new System.Drawing.Size(0, 31);
            this.lblPrecioCalculado.TabIndex = 27;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(25, 377);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(73, 25);
            this.lblPrecio.TabIndex = 26;
            this.lblPrecio.Text = "Precio";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(753, 366);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(148, 51);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // lblRecetas
            // 
            this.lblRecetas.AutoSize = true;
            this.lblRecetas.Location = new System.Drawing.Point(19, 157);
            this.lblRecetas.Name = "lblRecetas";
            this.lblRecetas.Size = new System.Drawing.Size(91, 25);
            this.lblRecetas.TabIndex = 24;
            this.lblRecetas.Text = "Recetas";
            // 
            // lstRecetas
            // 
            this.lstRecetas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRecetas.ColumnWidth = 100;
            this.lstRecetas.FormattingEnabled = true;
            this.lstRecetas.ItemHeight = 25;
            this.lstRecetas.Location = new System.Drawing.Point(24, 196);
            this.lstRecetas.MultiColumn = true;
            this.lstRecetas.Name = "lstRecetas";
            this.lstRecetas.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstRecetas.Size = new System.Drawing.Size(877, 154);
            this.lstRecetas.TabIndex = 5;
            // 
            // chkAprobada
            // 
            this.chkAprobada.AutoSize = true;
            this.chkAprobada.ForeColor = System.Drawing.Color.Black;
            this.chkAprobada.Location = new System.Drawing.Point(24, 106);
            this.chkAprobada.Name = "chkAprobada";
            this.chkAprobada.Size = new System.Drawing.Size(137, 29);
            this.chkAprobada.TabIndex = 4;
            this.chkAprobada.Text = "Aprobada";
            this.chkAprobada.UseVisualStyleBackColor = true;
            // 
            // txtComensales
            // 
            this.txtComensales.Location = new System.Drawing.Point(758, 52);
            this.txtComensales.Name = "txtComensales";
            this.txtComensales.Size = new System.Drawing.Size(143, 31);
            this.txtComensales.TabIndex = 3;
            // 
            // lblComensales
            // 
            this.lblComensales.AutoSize = true;
            this.lblComensales.Location = new System.Drawing.Point(753, 19);
            this.lblComensales.Name = "lblComensales";
            this.lblComensales.Size = new System.Drawing.Size(131, 25);
            this.lblComensales.TabIndex = 15;
            this.lblComensales.Text = "Comensales";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(523, 19);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(68, 25);
            this.lblFechaFin.TabIndex = 14;
            this.lblFechaFin.Text = "Hasta";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(528, 52);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(211, 31);
            this.dtpFechaFin.TabIndex = 2;
            this.dtpFechaFin.Value = new System.DateTime(2019, 12, 4, 10, 31, 39, 0);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(296, 52);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(211, 31);
            this.dtpFechaInicio.TabIndex = 1;
            this.dtpFechaInicio.Value = new System.DateTime(2019, 12, 4, 10, 31, 39, 0);
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(291, 19);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(74, 25);
            this.lblFechaInicio.TabIndex = 2;
            this.lblFechaInicio.Text = "Desde";
            // 
            // cboClientes
            // 
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(24, 50);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(252, 33);
            this.cboClientes.TabIndex = 0;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(19, 19);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(79, 25);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente";
            // 
            // grvPedidos
            // 
            this.grvPedidos.AllowUserToAddRows = false;
            this.grvPedidos.AllowUserToDeleteRows = false;
            this.grvPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvPedidos.Location = new System.Drawing.Point(0, 437);
            this.grvPedidos.MultiSelect = false;
            this.grvPedidos.Name = "grvPedidos";
            this.grvPedidos.ReadOnly = true;
            this.grvPedidos.RowHeadersWidth = 82;
            this.grvPedidos.RowTemplate.Height = 33;
            this.grvPedidos.Size = new System.Drawing.Size(927, 392);
            this.grvPedidos.TabIndex = 2;
            // 
            // OrdenesVentaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 829);
            this.Controls.Add(this.grvPedidos);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrdenesVentaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenes de Venta";
            this.Load += new System.EventHandler(this.OrdenesVentaForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvPedidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboClientes;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblComensales;
        private System.Windows.Forms.TextBox txtComensales;
        private System.Windows.Forms.CheckBox chkAprobada;
        private System.Windows.Forms.Label lblRecetas;
        private System.Windows.Forms.ListBox lstRecetas;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblPrecioCalculado;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Button btnCalcularPrecio;
        private System.Windows.Forms.DataGridView grvPedidos;
        private System.Windows.Forms.Label lblPesos;
    }
}