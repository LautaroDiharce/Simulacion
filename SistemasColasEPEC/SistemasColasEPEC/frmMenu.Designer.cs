namespace SistemasColasEPEC
{
    partial class frmMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPrimerSistema = new System.Windows.Forms.Button();
            this.btnSegundoSistema = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPrimerSistema
            // 
            this.btnPrimerSistema.Location = new System.Drawing.Point(29, 38);
            this.btnPrimerSistema.Name = "btnPrimerSistema";
            this.btnPrimerSistema.Size = new System.Drawing.Size(122, 23);
            this.btnPrimerSistema.TabIndex = 0;
            this.btnPrimerSistema.Text = "Primer Sistema";
            this.btnPrimerSistema.UseVisualStyleBackColor = true;
            this.btnPrimerSistema.Click += new System.EventHandler(this.btnPrimerSistema_Click);
            // 
            // btnSegundoSistema
            // 
            this.btnSegundoSistema.Location = new System.Drawing.Point(212, 38);
            this.btnSegundoSistema.Name = "btnSegundoSistema";
            this.btnSegundoSistema.Size = new System.Drawing.Size(135, 23);
            this.btnSegundoSistema.TabIndex = 1;
            this.btnSegundoSistema.Text = "Segundo Sistema";
            this.btnSegundoSistema.UseVisualStyleBackColor = true;
            this.btnSegundoSistema.Click += new System.EventHandler(this.btnSegundoSistema_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 123);
            this.Controls.Add(this.btnSegundoSistema);
            this.Controls.Add(this.btnPrimerSistema);
            this.Name = "frmMenu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrimerSistema;
        private System.Windows.Forms.Button btnSegundoSistema;
    }
}

