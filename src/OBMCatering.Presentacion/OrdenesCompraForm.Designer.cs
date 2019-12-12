﻿namespace OBMCatering.Presentacion
{
    partial class OrdenesCompraForm
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
            this.lblOrdenesCompra = new System.Windows.Forms.Label();
            this.grvOrdenesCompra = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblProveedorTitulo = new System.Windows.Forms.Label();
            this.cboProveedor = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblEstadoTitulo = new System.Windows.Forms.Label();
            this.grvIngredientes = new System.Windows.Forms.DataGridView();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblFechaTitulo = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblItems = new System.Windows.Forms.Label();
            this.lblClienteTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grvOrdenesCompra)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvIngredientes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOrdenesCompra
            // 
            this.lblOrdenesCompra.AutoSize = true;
            this.lblOrdenesCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenesCompra.ForeColor = System.Drawing.Color.Black;
            this.lblOrdenesCompra.Location = new System.Drawing.Point(12, 452);
            this.lblOrdenesCompra.Name = "lblOrdenesCompra";
            this.lblOrdenesCompra.Size = new System.Drawing.Size(222, 25);
            this.lblOrdenesCompra.TabIndex = 26;
            this.lblOrdenesCompra.Text = "Ordenes de Compra";
            // 
            // grvOrdenesCompra
            // 
            this.grvOrdenesCompra.AllowUserToAddRows = false;
            this.grvOrdenesCompra.AllowUserToDeleteRows = false;
            this.grvOrdenesCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grvOrdenesCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvOrdenesCompra.Dock = System.Windows.Forms.DockStyle.Top;
            this.grvOrdenesCompra.Location = new System.Drawing.Point(0, 0);
            this.grvOrdenesCompra.MultiSelect = false;
            this.grvOrdenesCompra.Name = "grvOrdenesCompra";
            this.grvOrdenesCompra.ReadOnly = true;
            this.grvOrdenesCompra.RowHeadersWidth = 82;
            this.grvOrdenesCompra.RowTemplate.Height = 33;
            this.grvOrdenesCompra.Size = new System.Drawing.Size(1169, 414);
            this.grvOrdenesCompra.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblProveedorTitulo);
            this.panel1.Controls.Add(this.cboProveedor);
            this.panel1.Controls.Add(this.lblEstado);
            this.panel1.Controls.Add(this.lblEstadoTitulo);
            this.panel1.Controls.Add(this.grvIngredientes);
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Controls.Add(this.lblFechaTitulo);
            this.panel1.Controls.Add(this.lblCliente);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.lblItems);
            this.panel1.Controls.Add(this.lblClienteTitulo);
            this.panel1.Location = new System.Drawing.Point(12, 498);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1145, 410);
            this.panel1.TabIndex = 28;
            // 
            // lblProveedorTitulo
            // 
            this.lblProveedorTitulo.AutoSize = true;
            this.lblProveedorTitulo.Location = new System.Drawing.Point(804, 18);
            this.lblProveedorTitulo.Name = "lblProveedorTitulo";
            this.lblProveedorTitulo.Size = new System.Drawing.Size(111, 25);
            this.lblProveedorTitulo.TabIndex = 41;
            this.lblProveedorTitulo.Text = "Proveedor";
            // 
            // cboProveedor
            // 
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.Location = new System.Drawing.Point(921, 18);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(219, 33);
            this.cboProveedor.TabIndex = 40;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(590, 62);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 25);
            this.lblEstado.TabIndex = 39;
            // 
            // lblEstadoTitulo
            // 
            this.lblEstadoTitulo.AutoSize = true;
            this.lblEstadoTitulo.Location = new System.Drawing.Point(587, 18);
            this.lblEstadoTitulo.Name = "lblEstadoTitulo";
            this.lblEstadoTitulo.Size = new System.Drawing.Size(79, 25);
            this.lblEstadoTitulo.TabIndex = 38;
            this.lblEstadoTitulo.Text = "Estado";
            // 
            // grvIngredientes
            // 
            this.grvIngredientes.AllowUserToAddRows = false;
            this.grvIngredientes.AllowUserToDeleteRows = false;
            this.grvIngredientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grvIngredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvIngredientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grvIngredientes.Location = new System.Drawing.Point(0, 179);
            this.grvIngredientes.MultiSelect = false;
            this.grvIngredientes.Name = "grvIngredientes";
            this.grvIngredientes.ReadOnly = true;
            this.grvIngredientes.RowHeadersWidth = 82;
            this.grvIngredientes.RowTemplate.Height = 33;
            this.grvIngredientes.Size = new System.Drawing.Size(1143, 229);
            this.grvIngredientes.TabIndex = 29;
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
            // lblFechaTitulo
            // 
            this.lblFechaTitulo.AutoSize = true;
            this.lblFechaTitulo.Location = new System.Drawing.Point(21, 18);
            this.lblFechaTitulo.Name = "lblFechaTitulo";
            this.lblFechaTitulo.Size = new System.Drawing.Size(72, 25);
            this.lblFechaTitulo.TabIndex = 36;
            this.lblFechaTitulo.Text = "Fecha";
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
            // btnGuardar
            // 
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(921, 123);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(219, 50);
            this.btnGuardar.TabIndex = 30;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(21, 136);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(63, 25);
            this.lblItems.TabIndex = 24;
            this.lblItems.Text = "Items";
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
            // OrdenesCompraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 930);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grvOrdenesCompra);
            this.Controls.Add(this.lblOrdenesCompra);
            this.Name = "OrdenesCompraForm";
            this.Text = "Ordenes de Compra";
            this.Load += new System.EventHandler(this.OrdenesCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvOrdenesCompra)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvIngredientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrdenesCompra;
        private System.Windows.Forms.DataGridView grvOrdenesCompra;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblFechaTitulo;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label lblClienteTitulo;
        private System.Windows.Forms.DataGridView grvIngredientes;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblEstadoTitulo;
        private System.Windows.Forms.Label lblProveedorTitulo;
        private System.Windows.Forms.ComboBox cboProveedor;
    }
}