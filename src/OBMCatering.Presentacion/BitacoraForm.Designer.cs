namespace OBMCatering.Presentacion
{
    partial class BitacoraForm
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
            this.grvBitacora = new System.Windows.Forms.DataGridView();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.cboTipos = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.cboUsuarios = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblEventos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grvBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // grvBitacora
            // 
            this.grvBitacora.AllowUserToAddRows = false;
            this.grvBitacora.AllowUserToDeleteRows = false;
            this.grvBitacora.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvBitacora.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grvBitacora.Location = new System.Drawing.Point(0, 205);
            this.grvBitacora.Name = "grvBitacora";
            this.grvBitacora.ReadOnly = true;
            this.grvBitacora.RowHeadersWidth = 82;
            this.grvBitacora.RowTemplate.Height = 33;
            this.grvBitacora.Size = new System.Drawing.Size(1486, 664);
            this.grvBitacora.TabIndex = 0;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(263, 76);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(211, 31);
            this.dtpHasta.TabIndex = 36;
            this.dtpHasta.Value = new System.DateTime(2019, 12, 4, 10, 31, 39, 0);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(25, 76);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(211, 31);
            this.dtpDesde.TabIndex = 35;
            this.dtpDesde.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(1107, 63);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(180, 53);
            this.btnFiltrar.TabIndex = 34;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // cboTipos
            // 
            this.cboTipos.FormattingEnabled = true;
            this.cboTipos.Location = new System.Drawing.Point(502, 74);
            this.cboTipos.Name = "cboTipos";
            this.cboTipos.Size = new System.Drawing.Size(272, 33);
            this.cboTipos.TabIndex = 33;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(497, 33);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(54, 25);
            this.lblTipo.TabIndex = 32;
            this.lblTipo.Text = "Tipo";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(258, 33);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(68, 25);
            this.lblHasta.TabIndex = 31;
            this.lblHasta.Text = "Hasta";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(20, 33);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(74, 25);
            this.lblDesde.TabIndex = 30;
            this.lblDesde.Text = "Desde";
            // 
            // cboUsuarios
            // 
            this.cboUsuarios.FormattingEnabled = true;
            this.cboUsuarios.Location = new System.Drawing.Point(800, 74);
            this.cboUsuarios.Name = "cboUsuarios";
            this.cboUsuarios.Size = new System.Drawing.Size(272, 33);
            this.cboUsuarios.TabIndex = 38;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(795, 33);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(86, 25);
            this.lblUsuario.TabIndex = 37;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblEventos
            // 
            this.lblEventos.AutoSize = true;
            this.lblEventos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventos.ForeColor = System.Drawing.Color.Black;
            this.lblEventos.Location = new System.Drawing.Point(20, 151);
            this.lblEventos.Name = "lblEventos";
            this.lblEventos.Size = new System.Drawing.Size(97, 25);
            this.lblEventos.TabIndex = 39;
            this.lblEventos.Text = "Eventos";
            // 
            // BitacoraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1486, 869);
            this.Controls.Add(this.lblEventos);
            this.Controls.Add(this.cboUsuarios);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.cboTipos);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.grvBitacora);
            this.Name = "BitacoraForm";
            this.Text = "Bitacora del Sistema";
            this.Load += new System.EventHandler(this.BitacoraForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvBitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grvBitacora;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.ComboBox cboTipos;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.ComboBox cboUsuarios;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblEventos;
    }
}