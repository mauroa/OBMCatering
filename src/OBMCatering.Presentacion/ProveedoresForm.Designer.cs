﻿namespace OBMCatering.Presentacion
{
    partial class ProveedoresForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProveedoresForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.dtpFechaBaja = new System.Windows.Forms.DateTimePicker();
            this.lblFechaBaja = new System.Windows.Forms.Label();
            this.dtpFechaAlta = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblActivo = new System.Windows.Forms.Label();
            this.lblFechaAlta = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtCP = new System.Windows.Forms.TextBox();
            this.lblCP = new System.Windows.Forms.Label();
            this.cboLocalidades = new System.Windows.Forms.ComboBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.cboProvincias = new System.Windows.Forms.ComboBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtCUIT = new System.Windows.Forms.TextBox();
            this.lblCUIT = new System.Windows.Forms.Label();
            this.grvProveedores = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkActivo);
            this.panel1.Controls.Add(this.dtpFechaBaja);
            this.panel1.Controls.Add(this.lblFechaBaja);
            this.panel1.Controls.Add(this.dtpFechaAlta);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.lblActivo);
            this.panel1.Controls.Add(this.lblFechaAlta);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.lblEmail);
            this.panel1.Controls.Add(this.txtTelefono);
            this.panel1.Controls.Add(this.lblTelefono);
            this.panel1.Controls.Add(this.txtCP);
            this.panel1.Controls.Add(this.lblCP);
            this.panel1.Controls.Add(this.cboLocalidades);
            this.panel1.Controls.Add(this.lblLocalidad);
            this.panel1.Controls.Add(this.cboProvincias);
            this.panel1.Controls.Add(this.lblProvincia);
            this.panel1.Controls.Add(this.txtDomicilio);
            this.panel1.Controls.Add(this.lblDomicilio);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.txtCUIT);
            this.panel1.Controls.Add(this.lblCUIT);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 400);
            this.panel1.TabIndex = 0;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Enabled = false;
            this.chkActivo.ForeColor = System.Drawing.Color.Black;
            this.chkActivo.Location = new System.Drawing.Point(25, 311);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(103, 29);
            this.chkActivo.TabIndex = 10;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // dtpFechaBaja
            // 
            this.dtpFechaBaja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaBaja.Location = new System.Drawing.Point(767, 246);
            this.dtpFechaBaja.Name = "dtpFechaBaja";
            this.dtpFechaBaja.Size = new System.Drawing.Size(179, 31);
            this.dtpFechaBaja.TabIndex = 9;
            this.dtpFechaBaja.Value = new System.DateTime(2019, 12, 4, 10, 31, 39, 0);
            // 
            // lblFechaBaja
            // 
            this.lblFechaBaja.AutoSize = true;
            this.lblFechaBaja.ForeColor = System.Drawing.Color.Black;
            this.lblFechaBaja.Location = new System.Drawing.Point(762, 207);
            this.lblFechaBaja.Name = "lblFechaBaja";
            this.lblFechaBaja.Size = new System.Drawing.Size(121, 25);
            this.lblFechaBaja.TabIndex = 24;
            this.lblFechaBaja.Text = "Fecha Baja";
            // 
            // dtpFechaAlta
            // 
            this.dtpFechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaAlta.Location = new System.Drawing.Point(559, 248);
            this.dtpFechaAlta.Name = "dtpFechaAlta";
            this.dtpFechaAlta.Size = new System.Drawing.Size(182, 31);
            this.dtpFechaAlta.TabIndex = 8;
            this.dtpFechaAlta.Value = new System.DateTime(2019, 12, 4, 10, 31, 39, 0);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(895, 311);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(148, 50);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // lblActivo
            // 
            this.lblActivo.AutoSize = true;
            this.lblActivo.Location = new System.Drawing.Point(972, 207);
            this.lblActivo.Name = "lblActivo";
            this.lblActivo.Size = new System.Drawing.Size(71, 25);
            this.lblActivo.TabIndex = 20;
            this.lblActivo.Text = "Activo";
            // 
            // lblFechaAlta
            // 
            this.lblFechaAlta.AutoSize = true;
            this.lblFechaAlta.ForeColor = System.Drawing.Color.Black;
            this.lblFechaAlta.Location = new System.Drawing.Point(554, 207);
            this.lblFechaAlta.Name = "lblFechaAlta";
            this.lblFechaAlta.Size = new System.Drawing.Size(115, 25);
            this.lblFechaAlta.TabIndex = 18;
            this.lblFechaAlta.Text = "Fecha Alta";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(245, 248);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(285, 31);
            this.txtEmail.TabIndex = 7;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.Black;
            this.lblEmail.Location = new System.Drawing.Point(240, 207);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(65, 25);
            this.lblEmail.TabIndex = 16;
            this.lblEmail.Text = "Email";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(25, 248);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(191, 31);
            this.txtTelefono.TabIndex = 6;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.ForeColor = System.Drawing.Color.Black;
            this.lblTelefono.Location = new System.Drawing.Point(23, 207);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(96, 25);
            this.lblTelefono.TabIndex = 14;
            this.lblTelefono.Text = "Telefono";
            // 
            // txtCP
            // 
            this.txtCP.Location = new System.Drawing.Point(902, 144);
            this.txtCP.Name = "txtCP";
            this.txtCP.Size = new System.Drawing.Size(141, 31);
            this.txtCP.TabIndex = 5;
            // 
            // lblCP
            // 
            this.lblCP.AutoSize = true;
            this.lblCP.ForeColor = System.Drawing.Color.Black;
            this.lblCP.Location = new System.Drawing.Point(897, 105);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(146, 25);
            this.lblCP.TabIndex = 12;
            this.lblCP.Text = "Codigo Postal";
            // 
            // cboLocalidades
            // 
            this.cboLocalidades.FormattingEnabled = true;
            this.cboLocalidades.Location = new System.Drawing.Point(612, 144);
            this.cboLocalidades.Name = "cboLocalidades";
            this.cboLocalidades.Size = new System.Drawing.Size(267, 33);
            this.cboLocalidades.TabIndex = 4;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.ForeColor = System.Drawing.Color.Black;
            this.lblLocalidad.Location = new System.Drawing.Point(607, 105);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(105, 25);
            this.lblLocalidad.TabIndex = 8;
            this.lblLocalidad.Text = "Localidad";
            // 
            // cboProvincias
            // 
            this.cboProvincias.FormattingEnabled = true;
            this.cboProvincias.Location = new System.Drawing.Point(320, 144);
            this.cboProvincias.Name = "cboProvincias";
            this.cboProvincias.Size = new System.Drawing.Size(270, 33);
            this.cboProvincias.TabIndex = 3;
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.ForeColor = System.Drawing.Color.Black;
            this.lblProvincia.Location = new System.Drawing.Point(315, 105);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(101, 25);
            this.lblProvincia.TabIndex = 6;
            this.lblProvincia.Text = "Provincia";
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(25, 144);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(268, 31);
            this.txtDomicilio.TabIndex = 2;
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.ForeColor = System.Drawing.Color.Black;
            this.lblDomicilio.Location = new System.Drawing.Point(20, 105);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(99, 25);
            this.lblDomicilio.TabIndex = 4;
            this.lblDomicilio.Text = "Domicilio";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(279, 50);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(311, 31);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(274, 13);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(87, 25);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            // 
            // txtCUIT
            // 
            this.txtCUIT.Location = new System.Drawing.Point(25, 50);
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Size = new System.Drawing.Size(224, 31);
            this.txtCUIT.TabIndex = 0;
            // 
            // lblCUIT
            // 
            this.lblCUIT.AutoSize = true;
            this.lblCUIT.ForeColor = System.Drawing.Color.Black;
            this.lblCUIT.Location = new System.Drawing.Point(20, 13);
            this.lblCUIT.Name = "lblCUIT";
            this.lblCUIT.Size = new System.Drawing.Size(60, 25);
            this.lblCUIT.TabIndex = 0;
            this.lblCUIT.Text = "CUIT";
            // 
            // grvProveedores
            // 
            this.grvProveedores.AllowUserToAddRows = false;
            this.grvProveedores.AllowUserToDeleteRows = false;
            this.grvProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvProveedores.Location = new System.Drawing.Point(0, 400);
            this.grvProveedores.MultiSelect = false;
            this.grvProveedores.Name = "grvProveedores";
            this.grvProveedores.ReadOnly = true;
            this.grvProveedores.RowHeadersWidth = 82;
            this.grvProveedores.RowTemplate.Height = 33;
            this.grvProveedores.Size = new System.Drawing.Size(1071, 371);
            this.grvProveedores.TabIndex = 1;
            // 
            // ProveedoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 771);
            this.Controls.Add(this.grvProveedores);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProveedoresForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administracion de Proveedores";
            this.Load += new System.EventHandler(this.ProveedoresForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvProveedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtCUIT;
        private System.Windows.Forms.Label lblCUIT;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.ComboBox cboLocalidades;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.ComboBox cboProvincias;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.TextBox txtCP;
        private System.Windows.Forms.Label lblCP;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblFechaAlta;
        private System.Windows.Forms.Label lblActivo;
        private System.Windows.Forms.DataGridView grvProveedores;
        private System.Windows.Forms.DateTimePicker dtpFechaBaja;
        private System.Windows.Forms.Label lblFechaBaja;
        private System.Windows.Forms.DateTimePicker dtpFechaAlta;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.CheckBox chkActivo;
    }
}

