﻿namespace OBMCatering.Presentacion
{
    partial class PreciosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreciosForm));
            this.lblIngredienteTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboUnidad = new System.Windows.Forms.ComboBox();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblIngrediente = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.grvPrecios = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvPrecios)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIngredienteTitulo
            // 
            this.lblIngredienteTitulo.AutoSize = true;
            this.lblIngredienteTitulo.Location = new System.Drawing.Point(25, 22);
            this.lblIngredienteTitulo.Name = "lblIngredienteTitulo";
            this.lblIngredienteTitulo.Size = new System.Drawing.Size(119, 25);
            this.lblIngredienteTitulo.TabIndex = 0;
            this.lblIngredienteTitulo.Text = "Ingrediente";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboUnidad);
            this.panel1.Controls.Add(this.lblUnidad);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.lblCantidad);
            this.panel1.Controls.Add(this.lblPrecio);
            this.panel1.Controls.Add(this.lblIngrediente);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.txtPrecio);
            this.panel1.Controls.Add(this.lblIngredienteTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 172);
            this.panel1.TabIndex = 2;
            // 
            // cboUnidad
            // 
            this.cboUnidad.FormattingEnabled = true;
            this.cboUnidad.Location = new System.Drawing.Point(751, 53);
            this.cboUnidad.Name = "cboUnidad";
            this.cboUnidad.Size = new System.Drawing.Size(136, 33);
            this.cboUnidad.TabIndex = 2;
            // 
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Location = new System.Drawing.Point(746, 22);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(80, 25);
            this.lblUnidad.TabIndex = 28;
            this.lblUnidad.Text = "Unidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(641, 53);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(93, 31);
            this.txtCantidad.TabIndex = 1;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(636, 22);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(98, 25);
            this.lblCantidad.TabIndex = 26;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(431, 22);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(73, 25);
            this.lblPrecio.TabIndex = 25;
            this.lblPrecio.Text = "Precio";
            // 
            // lblIngrediente
            // 
            this.lblIngrediente.AutoSize = true;
            this.lblIngrediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngrediente.Location = new System.Drawing.Point(25, 59);
            this.lblIngrediente.Name = "lblIngrediente";
            this.lblIngrediente.Size = new System.Drawing.Size(0, 40);
            this.lblIngrediente.TabIndex = 24;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(739, 103);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(148, 50);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(436, 53);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(186, 31);
            this.txtPrecio.TabIndex = 0;
            // 
            // grvPrecios
            // 
            this.grvPrecios.AllowUserToAddRows = false;
            this.grvPrecios.AllowUserToDeleteRows = false;
            this.grvPrecios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvPrecios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvPrecios.Location = new System.Drawing.Point(0, 172);
            this.grvPrecios.MultiSelect = false;
            this.grvPrecios.Name = "grvPrecios";
            this.grvPrecios.ReadOnly = true;
            this.grvPrecios.RowHeadersWidth = 82;
            this.grvPrecios.RowTemplate.Height = 33;
            this.grvPrecios.Size = new System.Drawing.Size(907, 579);
            this.grvPrecios.TabIndex = 25;
            // 
            // PreciosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 751);
            this.Controls.Add(this.grvPrecios);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreciosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Precios";
            this.Load += new System.EventHandler(this.PreciosForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvPrecios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblIngredienteTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblIngrediente;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.ComboBox cboUnidad;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.DataGridView grvPrecios;
    }
}