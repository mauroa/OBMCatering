namespace OBMCatering.Presentacion
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
            this.lblClienteTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblItems = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grvOrdenesCompra)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvIngredientes)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOrdenesCompra
            // 
            this.lblOrdenesCompra.AutoSize = true;
            this.lblOrdenesCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenesCompra.ForeColor = System.Drawing.Color.Black;
            this.lblOrdenesCompra.Location = new System.Drawing.Point(12, 452);
            this.lblOrdenesCompra.Name = "lblOrdenesCompra";
            this.lblOrdenesCompra.Size = new System.Drawing.Size(0, 25);
            this.lblOrdenesCompra.TabIndex = 26;
            // 
            // grvOrdenesCompra
            // 
            this.grvOrdenesCompra.AllowUserToAddRows = false;
            this.grvOrdenesCompra.AllowUserToDeleteRows = false;
            this.grvOrdenesCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvOrdenesCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvOrdenesCompra.Dock = System.Windows.Forms.DockStyle.Top;
            this.grvOrdenesCompra.Location = new System.Drawing.Point(0, 0);
            this.grvOrdenesCompra.MultiSelect = false;
            this.grvOrdenesCompra.Name = "grvOrdenesCompra";
            this.grvOrdenesCompra.ReadOnly = true;
            this.grvOrdenesCompra.RowHeadersWidth = 82;
            this.grvOrdenesCompra.RowTemplate.Height = 33;
            this.grvOrdenesCompra.Size = new System.Drawing.Size(1169, 433);
            this.grvOrdenesCompra.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.grvIngredientes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 433);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1169, 562);
            this.panel1.TabIndex = 28;
            // 
            // lblProveedorTitulo
            // 
            this.lblProveedorTitulo.AutoSize = true;
            this.lblProveedorTitulo.Location = new System.Drawing.Point(781, 21);
            this.lblProveedorTitulo.Name = "lblProveedorTitulo";
            this.lblProveedorTitulo.Size = new System.Drawing.Size(111, 25);
            this.lblProveedorTitulo.TabIndex = 41;
            this.lblProveedorTitulo.Text = "Proveedor";
            // 
            // cboProveedor
            // 
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.Location = new System.Drawing.Point(898, 21);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(219, 33);
            this.cboProveedor.TabIndex = 40;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(586, 65);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 25);
            this.lblEstado.TabIndex = 39;
            // 
            // lblEstadoTitulo
            // 
            this.lblEstadoTitulo.AutoSize = true;
            this.lblEstadoTitulo.Location = new System.Drawing.Point(583, 21);
            this.lblEstadoTitulo.Name = "lblEstadoTitulo";
            this.lblEstadoTitulo.Size = new System.Drawing.Size(79, 25);
            this.lblEstadoTitulo.TabIndex = 38;
            this.lblEstadoTitulo.Text = "Estado";
            // 
            // grvIngredientes
            // 
            this.grvIngredientes.AllowUserToAddRows = false;
            this.grvIngredientes.AllowUserToDeleteRows = false;
            this.grvIngredientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvIngredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvIngredientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvIngredientes.Location = new System.Drawing.Point(0, 0);
            this.grvIngredientes.MultiSelect = false;
            this.grvIngredientes.Name = "grvIngredientes";
            this.grvIngredientes.ReadOnly = true;
            this.grvIngredientes.RowHeadersWidth = 82;
            this.grvIngredientes.RowTemplate.Height = 33;
            this.grvIngredientes.Size = new System.Drawing.Size(1167, 560);
            this.grvIngredientes.TabIndex = 29;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(17, 65);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 25);
            this.lblFecha.TabIndex = 37;
            // 
            // lblFechaTitulo
            // 
            this.lblFechaTitulo.AutoSize = true;
            this.lblFechaTitulo.Location = new System.Drawing.Point(17, 21);
            this.lblFechaTitulo.Name = "lblFechaTitulo";
            this.lblFechaTitulo.Size = new System.Drawing.Size(72, 25);
            this.lblFechaTitulo.TabIndex = 36;
            this.lblFechaTitulo.Text = "Fecha";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(268, 65);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(0, 25);
            this.lblCliente.TabIndex = 31;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(937, 166);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(219, 50);
            this.btnGuardar.TabIndex = 30;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // lblClienteTitulo
            // 
            this.lblClienteTitulo.AutoSize = true;
            this.lblClienteTitulo.Location = new System.Drawing.Point(268, 21);
            this.lblClienteTitulo.Name = "lblClienteTitulo";
            this.lblClienteTitulo.Size = new System.Drawing.Size(79, 25);
            this.lblClienteTitulo.TabIndex = 0;
            this.lblClienteTitulo.Text = "Cliente";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblFechaTitulo);
            this.panel2.Controls.Add(this.lblProveedorTitulo);
            this.panel2.Controls.Add(this.lblItems);
            this.panel2.Controls.Add(this.btnGuardar);
            this.panel2.Controls.Add(this.lblClienteTitulo);
            this.panel2.Controls.Add(this.cboProveedor);
            this.panel2.Controls.Add(this.lblCliente);
            this.panel2.Controls.Add(this.lblEstado);
            this.panel2.Controls.Add(this.lblFecha);
            this.panel2.Controls.Add(this.lblEstadoTitulo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1167, 229);
            this.panel2.TabIndex = 42;
            // 
            // lblItems
            // 
            this.lblItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(17, 191);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(63, 25);
            this.lblItems.TabIndex = 24;
            this.lblItems.Text = "Items";
            // 
            // OrdenesCompraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 995);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grvOrdenesCompra);
            this.Controls.Add(this.lblOrdenesCompra);
            this.Name = "OrdenesCompraForm";
            this.Text = "Ordenes de Compra";
            this.Load += new System.EventHandler(this.OrdenesCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvOrdenesCompra)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvIngredientes)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Label lblClienteTitulo;
        private System.Windows.Forms.DataGridView grvIngredientes;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblEstadoTitulo;
        private System.Windows.Forms.Label lblProveedorTitulo;
        private System.Windows.Forms.ComboBox cboProveedor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblItems;
    }
}