namespace OBMCatering.Presentacion
{
    partial class PedidosForm
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
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.grvPedidos = new System.Windows.Forms.DataGridView();
            this.lblPedidos = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboClientes = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnRecetas = new System.Windows.Forms.Button();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.grvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(30, 31);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(74, 25);
            this.lblDesde.TabIndex = 1;
            this.lblDesde.Text = "Desde";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(272, 31);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(68, 25);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta";
            // 
            // grvPedidos
            // 
            this.grvPedidos.AllowUserToAddRows = false;
            this.grvPedidos.AllowUserToDeleteRows = false;
            this.grvPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvPedidos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grvPedidos.Location = new System.Drawing.Point(0, 199);
            this.grvPedidos.MultiSelect = false;
            this.grvPedidos.Name = "grvPedidos";
            this.grvPedidos.ReadOnly = true;
            this.grvPedidos.RowHeadersWidth = 82;
            this.grvPedidos.RowTemplate.Height = 33;
            this.grvPedidos.Size = new System.Drawing.Size(1412, 585);
            this.grvPedidos.TabIndex = 4;
            // 
            // lblPedidos
            // 
            this.lblPedidos.AutoSize = true;
            this.lblPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedidos.ForeColor = System.Drawing.Color.Black;
            this.lblPedidos.Location = new System.Drawing.Point(30, 154);
            this.lblPedidos.Name = "lblPedidos";
            this.lblPedidos.Size = new System.Drawing.Size(97, 25);
            this.lblPedidos.TabIndex = 23;
            this.lblPedidos.Text = "Pedidos";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(513, 31);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(79, 25);
            this.lblCliente.TabIndex = 24;
            this.lblCliente.Text = "Cliente";
            // 
            // cboClientes
            // 
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(518, 72);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(272, 33);
            this.cboClientes.TabIndex = 25;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(827, 61);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(180, 53);
            this.btnFiltrar.TabIndex = 26;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // btnRecetas
            // 
            this.btnRecetas.Location = new System.Drawing.Point(1013, 61);
            this.btnRecetas.Name = "btnRecetas";
            this.btnRecetas.Size = new System.Drawing.Size(180, 53);
            this.btnRecetas.TabIndex = 27;
            this.btnRecetas.Text = "Recetas";
            this.btnRecetas.UseVisualStyleBackColor = true;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(35, 74);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(211, 31);
            this.dtpDesde.TabIndex = 28;
            this.dtpDesde.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(277, 74);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(211, 31);
            this.dtpHasta.TabIndex = 29;
            this.dtpHasta.Value = new System.DateTime(2019, 12, 4, 10, 31, 39, 0);
            // 
            // PedidosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1412, 784);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.btnRecetas);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.cboClientes);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblPedidos);
            this.Controls.Add(this.grvPedidos);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.lblDesde);
            this.Name = "PedidosForm";
            this.Text = "Listado de Pedidos";
            this.Load += new System.EventHandler(this.PedidosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DataGridView grvPedidos;
        private System.Windows.Forms.Label lblPedidos;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboClientes;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnRecetas;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
    }
}