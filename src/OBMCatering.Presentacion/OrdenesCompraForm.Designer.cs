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
            this.grvIngredientes = new System.Windows.Forms.DataGridView();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblFechaTitulo = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnAprobar = new System.Windows.Forms.Button();
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
            this.lblOrdenesCompra.Location = new System.Drawing.Point(22, 447);
            this.lblOrdenesCompra.Name = "lblOrdenesCompra";
            this.lblOrdenesCompra.Size = new System.Drawing.Size(222, 25);
            this.lblOrdenesCompra.TabIndex = 26;
            this.lblOrdenesCompra.Text = "Ordenes de Compra";
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
            this.grvOrdenesCompra.Size = new System.Drawing.Size(1169, 414);
            this.grvOrdenesCompra.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.grvIngredientes);
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Controls.Add(this.lblFechaTitulo);
            this.panel1.Controls.Add(this.lblCliente);
            this.panel1.Controls.Add(this.btnAprobar);
            this.panel1.Controls.Add(this.lblItems);
            this.panel1.Controls.Add(this.lblClienteTitulo);
            this.panel1.Location = new System.Drawing.Point(27, 498);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1115, 410);
            this.panel1.TabIndex = 28;
            // 
            // grvIngredientes
            // 
            this.grvIngredientes.AllowUserToAddRows = false;
            this.grvIngredientes.AllowUserToDeleteRows = false;
            this.grvIngredientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvIngredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvIngredientes.Location = new System.Drawing.Point(26, 153);
            this.grvIngredientes.MultiSelect = false;
            this.grvIngredientes.Name = "grvIngredientes";
            this.grvIngredientes.ReadOnly = true;
            this.grvIngredientes.RowHeadersWidth = 82;
            this.grvIngredientes.RowTemplate.Height = 33;
            this.grvIngredientes.Size = new System.Drawing.Size(1063, 229);
            this.grvIngredientes.TabIndex = 29;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(21, 62);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(83, 25);
            this.lblFecha.TabIndex = 37;
            this.lblFecha.Text = "fdfsdfs";
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
            this.lblCliente.Size = new System.Drawing.Size(83, 25);
            this.lblCliente.TabIndex = 31;
            this.lblCliente.Text = "fdfsdfs";
            // 
            // btnAprobar
            // 
            this.btnAprobar.ForeColor = System.Drawing.Color.Black;
            this.btnAprobar.Location = new System.Drawing.Point(941, 37);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(148, 50);
            this.btnAprobar.TabIndex = 30;
            this.btnAprobar.Text = "Aprobar";
            this.btnAprobar.UseVisualStyleBackColor = true;
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(19, 109);
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
        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label lblClienteTitulo;
        private System.Windows.Forms.DataGridView grvIngredientes;
    }
}