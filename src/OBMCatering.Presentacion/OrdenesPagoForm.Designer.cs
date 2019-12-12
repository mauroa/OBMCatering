namespace OBMCatering.Presentacion
{
    partial class OrdenesPagoForm
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
            this.lblOrdenesPago = new System.Windows.Forms.Label();
            this.grvOrdenesPago = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkPagada = new System.Windows.Forms.CheckBox();
            this.grvItems = new System.Windows.Forms.DataGridView();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblFechaTitulo = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblItems = new System.Windows.Forms.Label();
            this.lblProveedorTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grvOrdenesPago)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOrdenesPago
            // 
            this.lblOrdenesPago.AutoSize = true;
            this.lblOrdenesPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenesPago.ForeColor = System.Drawing.Color.Black;
            this.lblOrdenesPago.Location = new System.Drawing.Point(8, 456);
            this.lblOrdenesPago.Name = "lblOrdenesPago";
            this.lblOrdenesPago.Size = new System.Drawing.Size(195, 25);
            this.lblOrdenesPago.TabIndex = 26;
            this.lblOrdenesPago.Text = "Ordenes de Pago";
            // 
            // grvOrdenesPago
            // 
            this.grvOrdenesPago.AllowUserToAddRows = false;
            this.grvOrdenesPago.AllowUserToDeleteRows = false;
            this.grvOrdenesPago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grvOrdenesPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvOrdenesPago.Dock = System.Windows.Forms.DockStyle.Top;
            this.grvOrdenesPago.Location = new System.Drawing.Point(0, 0);
            this.grvOrdenesPago.MultiSelect = false;
            this.grvOrdenesPago.Name = "grvOrdenesPago";
            this.grvOrdenesPago.ReadOnly = true;
            this.grvOrdenesPago.RowHeadersWidth = 82;
            this.grvOrdenesPago.RowTemplate.Height = 33;
            this.grvOrdenesPago.Size = new System.Drawing.Size(1169, 414);
            this.grvOrdenesPago.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkPagada);
            this.panel1.Controls.Add(this.grvItems);
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Controls.Add(this.lblFechaTitulo);
            this.panel1.Controls.Add(this.lblProveedor);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.lblItems);
            this.panel1.Controls.Add(this.lblProveedorTitulo);
            this.panel1.Location = new System.Drawing.Point(12, 498);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1145, 389);
            this.panel1.TabIndex = 28;
            // 
            // chkPagada
            // 
            this.chkPagada.AutoSize = true;
            this.chkPagada.Location = new System.Drawing.Point(1022, 58);
            this.chkPagada.Name = "chkPagada";
            this.chkPagada.Size = new System.Drawing.Size(118, 29);
            this.chkPagada.TabIndex = 38;
            this.chkPagada.Text = "Pagada";
            this.chkPagada.UseVisualStyleBackColor = true;
            // 
            // grvItems
            // 
            this.grvItems.AllowUserToAddRows = false;
            this.grvItems.AllowUserToDeleteRows = false;
            this.grvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvItems.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grvItems.Location = new System.Drawing.Point(0, 158);
            this.grvItems.MultiSelect = false;
            this.grvItems.Name = "grvItems";
            this.grvItems.ReadOnly = true;
            this.grvItems.RowHeadersWidth = 82;
            this.grvItems.RowTemplate.Height = 33;
            this.grvItems.Size = new System.Drawing.Size(1143, 229);
            this.grvItems.TabIndex = 29;
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
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(272, 62);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(0, 25);
            this.lblProveedor.TabIndex = 31;
            // 
            // btnGuardar
            // 
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(992, 104);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(148, 50);
            this.btnGuardar.TabIndex = 30;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(21, 117);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(63, 25);
            this.lblItems.TabIndex = 24;
            this.lblItems.Text = "Items";
            // 
            // lblProveedorTitulo
            // 
            this.lblProveedorTitulo.AutoSize = true;
            this.lblProveedorTitulo.Location = new System.Drawing.Point(272, 18);
            this.lblProveedorTitulo.Name = "lblProveedorTitulo";
            this.lblProveedorTitulo.Size = new System.Drawing.Size(111, 25);
            this.lblProveedorTitulo.TabIndex = 0;
            this.lblProveedorTitulo.Text = "Proveedor";
            // 
            // OrdenesPagoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 901);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grvOrdenesPago);
            this.Controls.Add(this.lblOrdenesPago);
            this.Name = "OrdenesPagoForm";
            this.Text = "Ordenes de Pago";
            this.Load += new System.EventHandler(this.OrdenesPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvOrdenesPago)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrdenesPago;
        private System.Windows.Forms.DataGridView grvOrdenesPago;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblFechaTitulo;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label lblProveedorTitulo;
        private System.Windows.Forms.DataGridView grvItems;
        private System.Windows.Forms.CheckBox chkPagada;
    }
}