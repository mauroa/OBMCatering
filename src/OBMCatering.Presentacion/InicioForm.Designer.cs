namespace OBMCatering.Presentacion
{
    partial class InicioForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsAdministrar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiEmpleados = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCocina = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiRecetas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiPrecios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiPedidos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiFacturas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiOrdenesCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAdministrar,
            this.tsCocina,
            this.tsVentas,
            this.tsCompras});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1286, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsAdministrar
            // 
            this.tsAdministrar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiClientes,
            this.tsiProveedores,
            this.tsiEmpleados});
            this.tsAdministrar.Name = "tsAdministrar";
            this.tsAdministrar.Size = new System.Drawing.Size(157, 38);
            this.tsAdministrar.Text = "Administrar";
            // 
            // tsiClientes
            // 
            this.tsiClientes.Name = "tsiClientes";
            this.tsiClientes.Size = new System.Drawing.Size(281, 44);
            this.tsiClientes.Text = "Clientes";
            // 
            // tsiProveedores
            // 
            this.tsiProveedores.Name = "tsiProveedores";
            this.tsiProveedores.Size = new System.Drawing.Size(281, 44);
            this.tsiProveedores.Text = "Proveedores";
            // 
            // tsiEmpleados
            // 
            this.tsiEmpleados.Name = "tsiEmpleados";
            this.tsiEmpleados.Size = new System.Drawing.Size(281, 44);
            this.tsiEmpleados.Text = "Empleados";
            // 
            // tsCocina
            // 
            this.tsCocina.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiRecetas,
            this.tsiPrecios});
            this.tsCocina.Name = "tsCocina";
            this.tsCocina.Size = new System.Drawing.Size(107, 38);
            this.tsCocina.Text = "Cocina";
            // 
            // tsiRecetas
            // 
            this.tsiRecetas.Name = "tsiRecetas";
            this.tsiRecetas.Size = new System.Drawing.Size(229, 44);
            this.tsiRecetas.Text = "Recetas";
            // 
            // tsiPrecios
            // 
            this.tsiPrecios.Name = "tsiPrecios";
            this.tsiPrecios.Size = new System.Drawing.Size(229, 44);
            this.tsiPrecios.Text = "Precios";
            // 
            // tsVentas
            // 
            this.tsVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiPedidos,
            this.tsiFacturas});
            this.tsVentas.Name = "tsVentas";
            this.tsVentas.Size = new System.Drawing.Size(105, 38);
            this.tsVentas.Text = "Ventas";
            // 
            // tsiPedidos
            // 
            this.tsiPedidos.Name = "tsiPedidos";
            this.tsiPedidos.Size = new System.Drawing.Size(359, 44);
            this.tsiPedidos.Text = "Pedidos";
            // 
            // tsiFacturas
            // 
            this.tsiFacturas.Name = "tsiFacturas";
            this.tsiFacturas.Size = new System.Drawing.Size(359, 44);
            this.tsiFacturas.Text = "Facturas";
            // 
            // tsCompras
            // 
            this.tsCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiOrdenesCompra});
            this.tsCompras.Name = "tsCompras";
            this.tsCompras.Size = new System.Drawing.Size(129, 38);
            this.tsCompras.Text = "Compras";
            // 
            // tsiOrdenesCompra
            // 
            this.tsiOrdenesCompra.Name = "tsiOrdenesCompra";
            this.tsiOrdenesCompra.Size = new System.Drawing.Size(359, 44);
            this.tsiOrdenesCompra.Text = "Ordenes";
            // 
            // InicioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 752);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "InicioForm";
            this.Text = "OBM Catering";
            this.Load += new System.EventHandler(this.InicioForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsAdministrar;
        private System.Windows.Forms.ToolStripMenuItem tsiClientes;
        private System.Windows.Forms.ToolStripMenuItem tsiProveedores;
        private System.Windows.Forms.ToolStripMenuItem tsiEmpleados;
        private System.Windows.Forms.ToolStripMenuItem tsCocina;
        private System.Windows.Forms.ToolStripMenuItem tsiRecetas;
        private System.Windows.Forms.ToolStripMenuItem tsiPrecios;
        private System.Windows.Forms.ToolStripMenuItem tsVentas;
        private System.Windows.Forms.ToolStripMenuItem tsiPedidos;
        private System.Windows.Forms.ToolStripMenuItem tsiFacturas;
        private System.Windows.Forms.ToolStripMenuItem tsCompras;
        private System.Windows.Forms.ToolStripMenuItem tsiOrdenesCompra;
    }
}