﻿namespace OBMCatering.Presentacion
{
    partial class IngredientesForm
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
            this.lblIngrediente = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboUnidad = new System.Windows.Forms.ComboBox();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtIngrediente = new System.Windows.Forms.TextBox();
            this.lblIngredientes = new System.Windows.Forms.Label();
            this.grvIngredientes = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvIngredientes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIngrediente
            // 
            this.lblIngrediente.AutoSize = true;
            this.lblIngrediente.Location = new System.Drawing.Point(25, 22);
            this.lblIngrediente.Name = "lblIngrediente";
            this.lblIngrediente.Size = new System.Drawing.Size(119, 25);
            this.lblIngrediente.TabIndex = 0;
            this.lblIngrediente.Text = "Ingrediente";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboUnidad);
            this.panel1.Controls.Add(this.lblUnidad);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.lblCantidad);
            this.panel1.Controls.Add(this.txtIngrediente);
            this.panel1.Controls.Add(this.lblIngrediente);
            this.panel1.Location = new System.Drawing.Point(25, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1063, 203);
            this.panel1.TabIndex = 1;
            // 
            // cboUnidad
            // 
            this.cboUnidad.FormattingEnabled = true;
            this.cboUnidad.Location = new System.Drawing.Point(809, 57);
            this.cboUnidad.Name = "cboUnidad";
            this.cboUnidad.Size = new System.Drawing.Size(225, 33);
            this.cboUnidad.TabIndex = 28;
            // 
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Location = new System.Drawing.Point(804, 22);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(80, 25);
            this.lblUnidad.TabIndex = 27;
            this.lblUnidad.Text = "Unidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(609, 57);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(166, 31);
            this.txtCantidad.TabIndex = 26;
            // 
            // btnGuardar
            // 
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(886, 118);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(148, 50);
            this.btnGuardar.TabIndex = 23;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(604, 22);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(98, 25);
            this.lblCantidad.TabIndex = 5;
            this.lblCantidad.Text = "Cantidad";
            // 
            // txtIngrediente
            // 
            this.txtIngrediente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtIngrediente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtIngrediente.Location = new System.Drawing.Point(30, 57);
            this.txtIngrediente.Name = "txtIngrediente";
            this.txtIngrediente.Size = new System.Drawing.Size(545, 31);
            this.txtIngrediente.TabIndex = 1;
            // 
            // lblIngredientes
            // 
            this.lblIngredientes.AutoSize = true;
            this.lblIngredientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngredientes.ForeColor = System.Drawing.Color.Black;
            this.lblIngredientes.Location = new System.Drawing.Point(20, 249);
            this.lblIngredientes.Name = "lblIngredientes";
            this.lblIngredientes.Size = new System.Drawing.Size(142, 25);
            this.lblIngredientes.TabIndex = 23;
            this.lblIngredientes.Text = "Ingredientes";
            // 
            // grvIngredientes
            // 
            this.grvIngredientes.AllowUserToAddRows = false;
            this.grvIngredientes.AllowUserToDeleteRows = false;
            this.grvIngredientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvIngredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvIngredientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grvIngredientes.Location = new System.Drawing.Point(0, 299);
            this.grvIngredientes.MultiSelect = false;
            this.grvIngredientes.Name = "grvIngredientes";
            this.grvIngredientes.ReadOnly = true;
            this.grvIngredientes.RowHeadersWidth = 82;
            this.grvIngredientes.RowTemplate.Height = 33;
            this.grvIngredientes.Size = new System.Drawing.Size(1116, 493);
            this.grvIngredientes.TabIndex = 24;
            // 
            // IngredientesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 792);
            this.Controls.Add(this.grvIngredientes);
            this.Controls.Add(this.lblIngredientes);
            this.Controls.Add(this.panel1);
            this.Name = "IngredientesForm";
            this.Load += new System.EventHandler(this.IngredientesForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvIngredientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIngrediente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtIngrediente;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblIngredientes;
        private System.Windows.Forms.DataGridView grvIngredientes;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.ComboBox cboUnidad;
    }
}