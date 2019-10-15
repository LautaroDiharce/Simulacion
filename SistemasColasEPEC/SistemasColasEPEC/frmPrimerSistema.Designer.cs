namespace SistemasColasEPEC
{
    partial class frmPrimerSistema
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
            this.dgvSimulaciones = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSimular = new System.Windows.Forms.Button();
            this.txtSimulaciones = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCamionesPromedioXDia = new System.Windows.Forms.TextBox();
            this.txtCamionesNoAtendidos = new System.Windows.Forms.TextBox();
            this.txtPromedioEnSistema = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCantidadSimulaciones = new System.Windows.Forms.TextBox();
            this.txtPromedioCamionesXdia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimulaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSimulaciones
            // 
            this.dgvSimulaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSimulaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgvSimulaciones.Location = new System.Drawing.Point(12, 137);
            this.dgvSimulaciones.Name = "dgvSimulaciones";
            this.dgvSimulaciones.Size = new System.Drawing.Size(1237, 150);
            this.dgvSimulaciones.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Fila";
            this.Column1.Name = "Column1";
            this.Column1.Width = 2500;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(655, 65);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 23;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSimular
            // 
            this.btnSimular.Location = new System.Drawing.Point(493, 65);
            this.btnSimular.Name = "btnSimular";
            this.btnSimular.Size = new System.Drawing.Size(75, 23);
            this.btnSimular.TabIndex = 22;
            this.btnSimular.Text = "Simular";
            this.btnSimular.UseVisualStyleBackColor = true;
            this.btnSimular.Click += new System.EventHandler(this.btnSimular_Click);
            // 
            // txtSimulaciones
            // 
            this.txtSimulaciones.Location = new System.Drawing.Point(192, 70);
            this.txtSimulaciones.Name = "txtSimulaciones";
            this.txtSimulaciones.Size = new System.Drawing.Size(100, 20);
            this.txtSimulaciones.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Dias a simular";
            // 
            // txtCamionesPromedioXDia
            // 
            this.txtCamionesPromedioXDia.Location = new System.Drawing.Point(77, 346);
            this.txtCamionesPromedioXDia.Name = "txtCamionesPromedioXDia";
            this.txtCamionesPromedioXDia.Size = new System.Drawing.Size(100, 20);
            this.txtCamionesPromedioXDia.TabIndex = 24;
            // 
            // txtCamionesNoAtendidos
            // 
            this.txtCamionesNoAtendidos.Location = new System.Drawing.Point(380, 346);
            this.txtCamionesNoAtendidos.Name = "txtCamionesNoAtendidos";
            this.txtCamionesNoAtendidos.Size = new System.Drawing.Size(100, 20);
            this.txtCamionesNoAtendidos.TabIndex = 25;
            // 
            // txtPromedioEnSistema
            // 
            this.txtPromedioEnSistema.Location = new System.Drawing.Point(986, 346);
            this.txtPromedioEnSistema.Name = "txtPromedioEnSistema";
            this.txtPromedioEnSistema.Size = new System.Drawing.Size(100, 20);
            this.txtPromedioEnSistema.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Tiempo Promedio en sistema";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Camiones que pasaron por el sistema";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(983, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Promedio de permanencia en predio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(849, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Cantidad de eventos";
            // 
            // txtCantidadSimulaciones
            // 
            this.txtCantidadSimulaciones.Location = new System.Drawing.Point(986, 65);
            this.txtCantidadSimulaciones.Name = "txtCantidadSimulaciones";
            this.txtCantidadSimulaciones.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadSimulaciones.TabIndex = 43;
            // 
            // txtPromedioCamionesXdia
            // 
            this.txtPromedioCamionesXdia.Location = new System.Drawing.Point(683, 346);
            this.txtPromedioCamionesXdia.Name = "txtPromedioCamionesXdia";
            this.txtPromedioCamionesXdia.Size = new System.Drawing.Size(100, 20);
            this.txtPromedioCamionesXdia.TabIndex = 46;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(680, 312);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Promedio de camiones por dia";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 349);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "minutos";
            // 
            // frmPrimerSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPromedioCamionesXdia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCantidadSimulaciones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPromedioEnSistema);
            this.Controls.Add(this.txtCamionesNoAtendidos);
            this.Controls.Add(this.txtCamionesPromedioXDia);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnSimular);
            this.Controls.Add(this.txtSimulaciones);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvSimulaciones);
            this.Name = "frmPrimerSistema";
            this.Text = "frmPrimerSistema";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimulaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSimulaciones;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSimular;
        private System.Windows.Forms.TextBox txtSimulaciones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCamionesPromedioXDia;
        private System.Windows.Forms.TextBox txtCamionesNoAtendidos;
        private System.Windows.Forms.TextBox txtPromedioEnSistema;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCantidadSimulaciones;
        private System.Windows.Forms.TextBox txtPromedioCamionesXdia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}