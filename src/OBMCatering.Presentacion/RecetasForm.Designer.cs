namespace OBMCatering.Presentacion
{
    partial class RecetasForm
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVer = new System.Windows.Forms.Button();
            this.chkNoDisponible = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblRecetas = new System.Windows.Forms.Label();
            this.grvRecetas = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvRecetas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(25, 22);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(87, 25);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnVer);
            this.panel1.Controls.Add(this.chkNoDisponible);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.lblDetalle);
            this.panel1.Controls.Add(this.txtDetalle);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Location = new System.Drawing.Point(25, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 431);
            this.panel1.TabIndex = 1;
            // 
            // btnVer
            // 
            this.btnVer.Enabled = false;
            this.btnVer.ForeColor = System.Drawing.Color.Black;
            this.btnVer.Location = new System.Drawing.Point(535, 359);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(148, 50);
            this.btnVer.TabIndex = 25;
            this.btnVer.Text = "Ver Detalle";
            this.btnVer.UseVisualStyleBackColor = true;
            // 
            // chkNoDisponible
            // 
            this.chkNoDisponible.AutoSize = true;
            this.chkNoDisponible.ForeColor = System.Drawing.Color.Black;
            this.chkNoDisponible.Location = new System.Drawing.Point(603, 59);
            this.chkNoDisponible.Name = "chkNoDisponible";
            this.chkNoDisponible.Size = new System.Drawing.Size(178, 29);
            this.chkNoDisponible.TabIndex = 24;
            this.chkNoDisponible.Text = "No Disponible";
            this.chkNoDisponible.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(700, 359);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(148, 50);
            this.btnGuardar.TabIndex = 23;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(25, 112);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(79, 25);
            this.lblDetalle.TabIndex = 5;
            this.lblDetalle.Text = "Detalle";
            // 
            // txtDetalle
            // 
            this.txtDetalle.Location = new System.Drawing.Point(30, 149);
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Size = new System.Drawing.Size(818, 188);
            this.txtDetalle.TabIndex = 4;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(30, 57);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(545, 31);
            this.txtNombre.TabIndex = 1;
            // 
            // lblRecetas
            // 
            this.lblRecetas.AutoSize = true;
            this.lblRecetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecetas.ForeColor = System.Drawing.Color.Black;
            this.lblRecetas.Location = new System.Drawing.Point(20, 479);
            this.lblRecetas.Name = "lblRecetas";
            this.lblRecetas.Size = new System.Drawing.Size(98, 25);
            this.lblRecetas.TabIndex = 23;
            this.lblRecetas.Text = "Recetas";
            // 
            // grvRecetas
            // 
            this.grvRecetas.AllowUserToAddRows = false;
            this.grvRecetas.AllowUserToDeleteRows = false;
            this.grvRecetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvRecetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvRecetas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grvRecetas.Location = new System.Drawing.Point(0, 528);
            this.grvRecetas.MultiSelect = false;
            this.grvRecetas.Name = "grvRecetas";
            this.grvRecetas.ReadOnly = true;
            this.grvRecetas.RowHeadersWidth = 82;
            this.grvRecetas.RowTemplate.Height = 33;
            this.grvRecetas.Size = new System.Drawing.Size(1421, 436);
            this.grvRecetas.TabIndex = 24;
            // 
            // RecetasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 964);
            this.Controls.Add(this.grvRecetas);
            this.Controls.Add(this.lblRecetas);
            this.Controls.Add(this.panel1);
            this.Name = "RecetasForm";
            this.Text = "Administracion de Recetas";
            this.Load += new System.EventHandler(this.RecetasForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvRecetas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblRecetas;
        private System.Windows.Forms.DataGridView grvRecetas;
        private System.Windows.Forms.CheckBox chkNoDisponible;
        private System.Windows.Forms.Button btnVer;
    }
}