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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdenesPagoForm));
            this.grvOrdenesPago = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkPagada = new System.Windows.Forms.CheckBox();
            this.lblItems = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblFechaTitulo = new System.Windows.Forms.Label();
            this.lblProveedorTitulo = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.grvItems = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grvOrdenesPago)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // grvOrdenesPago
            // 
            this.grvOrdenesPago.AllowUserToAddRows = false;
            this.grvOrdenesPago.AllowUserToDeleteRows = false;
            this.grvOrdenesPago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvOrdenesPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvOrdenesPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvOrdenesPago.Location = new System.Drawing.Point(0, 0);
            this.grvOrdenesPago.MultiSelect = false;
            this.grvOrdenesPago.Name = "grvOrdenesPago";
            this.grvOrdenesPago.ReadOnly = true;
            this.grvOrdenesPago.RowHeadersWidth = 82;
            this.grvOrdenesPago.RowTemplate.Height = 33;
            this.grvOrdenesPago.Size = new System.Drawing.Size(1311, 389);
            this.grvOrdenesPago.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1311, 199);
            this.panel1.TabIndex = 28;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkPagada);
            this.panel2.Controls.Add(this.lblItems);
            this.panel2.Controls.Add(this.btnGuardar);
            this.panel2.Controls.Add(this.lblFechaTitulo);
            this.panel2.Controls.Add(this.lblProveedorTitulo);
            this.panel2.Controls.Add(this.lblFecha);
            this.panel2.Controls.Add(this.lblProveedor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1309, 197);
            this.panel2.TabIndex = 39;
            // 
            // chkPagada
            // 
            this.chkPagada.AutoSize = true;
            this.chkPagada.Location = new System.Drawing.Point(957, 18);
            this.chkPagada.Name = "chkPagada";
            this.chkPagada.Size = new System.Drawing.Size(118, 29);
            this.chkPagada.TabIndex = 0;
            this.chkPagada.Text = "Pagada";
            this.chkPagada.UseVisualStyleBackColor = true;
            // 
            // lblItems
            // 
            this.lblItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(13, 152);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(63, 25);
            this.lblItems.TabIndex = 24;
            this.lblItems.Text = "Items";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(1149, 127);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(148, 50);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // lblFechaTitulo
            // 
            this.lblFechaTitulo.AutoSize = true;
            this.lblFechaTitulo.Location = new System.Drawing.Point(13, 18);
            this.lblFechaTitulo.Name = "lblFechaTitulo";
            this.lblFechaTitulo.Size = new System.Drawing.Size(72, 25);
            this.lblFechaTitulo.TabIndex = 36;
            this.lblFechaTitulo.Text = "Fecha";
            // 
            // lblProveedorTitulo
            // 
            this.lblProveedorTitulo.AutoSize = true;
            this.lblProveedorTitulo.Location = new System.Drawing.Point(264, 18);
            this.lblProveedorTitulo.Name = "lblProveedorTitulo";
            this.lblProveedorTitulo.Size = new System.Drawing.Size(111, 25);
            this.lblProveedorTitulo.TabIndex = 0;
            this.lblProveedorTitulo.Text = "Proveedor";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(13, 62);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 25);
            this.lblFecha.TabIndex = 37;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(264, 62);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(0, 25);
            this.lblProveedor.TabIndex = 31;
            // 
            // grvItems
            // 
            this.grvItems.AllowUserToAddRows = false;
            this.grvItems.AllowUserToDeleteRows = false;
            this.grvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvItems.Location = new System.Drawing.Point(0, 0);
            this.grvItems.MultiSelect = false;
            this.grvItems.Name = "grvItems";
            this.grvItems.ReadOnly = true;
            this.grvItems.RowHeadersWidth = 82;
            this.grvItems.RowTemplate.Height = 33;
            this.grvItems.Size = new System.Drawing.Size(1311, 391);
            this.grvItems.TabIndex = 29;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grvOrdenesPago);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1311, 389);
            this.panel3.TabIndex = 29;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.grvItems);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 588);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1311, 391);
            this.panel4.TabIndex = 30;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 389);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1311, 199);
            this.panel5.TabIndex = 31;
            // 
            // OrdenesPagoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 979);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrdenesPagoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenes de Pago";
            this.Load += new System.EventHandler(this.OrdenesPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvOrdenesPago)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}