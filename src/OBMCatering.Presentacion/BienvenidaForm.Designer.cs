namespace OBMCatering.Presentacion
{
    partial class BienvenidaForm
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picPrincipal = new System.Windows.Forms.PictureBox();
            this.lblInicializando = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblTitulo.Location = new System.Drawing.Point(191, 35);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(333, 66);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "OBM Catering";
            // 
            // picPrincipal
            // 
            this.picPrincipal.Image = global::OBMCatering.Presentacion.Properties.Resources.Icon_32px;
            this.picPrincipal.Location = new System.Drawing.Point(325, 127);
            this.picPrincipal.Name = "picPrincipal";
            this.picPrincipal.Size = new System.Drawing.Size(60, 59);
            this.picPrincipal.TabIndex = 1;
            this.picPrincipal.TabStop = false;
            // 
            // lblInicializando
            // 
            this.lblInicializando.AutoSize = true;
            this.lblInicializando.ForeColor = System.Drawing.Color.Gray;
            this.lblInicializando.Location = new System.Drawing.Point(282, 299);
            this.lblInicializando.Name = "lblInicializando";
            this.lblInicializando.Size = new System.Drawing.Size(149, 25);
            this.lblInicializando.TabIndex = 2;
            this.lblInicializando.Text = "Inicializando...";
            // 
            // BienvenidaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 344);
            this.Controls.Add(this.lblInicializando);
            this.Controls.Add(this.picPrincipal);
            this.Controls.Add(this.lblTitulo);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BienvenidaForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenida";
            ((System.ComponentModel.ISupportInitialize)(this.picPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picPrincipal;
        private System.Windows.Forms.Label lblInicializando;
    }
}