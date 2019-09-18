namespace BatallaNaval
{
    partial class Game
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
            this.btnUbicarBarcos = new System.Windows.Forms.Button();
            this.btnIniciarBatalla = new System.Windows.Forms.Button();
            this.btnLimpiarBarcos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblEstrategiaB = new System.Windows.Forms.Label();
            this.lblCantTirosB = new System.Windows.Forms.Label();
            this.lblAciertosB = new System.Windows.Forms.Label();
            this.lblAciertosA = new System.Windows.Forms.Label();
            this.lblCantTirosA = new System.Windows.Forms.Label();
            this.lblEstrategiaA = new System.Windows.Forms.Label();
            this.lblGanadorA = new System.Windows.Forms.Label();
            this.lblGanadorB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUbicarBarcos
            // 
            this.btnUbicarBarcos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUbicarBarcos.Location = new System.Drawing.Point(632, 31);
            this.btnUbicarBarcos.Name = "btnUbicarBarcos";
            this.btnUbicarBarcos.Size = new System.Drawing.Size(215, 53);
            this.btnUbicarBarcos.TabIndex = 0;
            this.btnUbicarBarcos.Text = "Ubicar barcos";
            this.btnUbicarBarcos.UseVisualStyleBackColor = true;
            this.btnUbicarBarcos.Click += new System.EventHandler(this.BtnUbicarBarcos_Click);
            // 
            // btnIniciarBatalla
            // 
            this.btnIniciarBatalla.Enabled = false;
            this.btnIniciarBatalla.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarBatalla.Location = new System.Drawing.Point(632, 117);
            this.btnIniciarBatalla.Name = "btnIniciarBatalla";
            this.btnIniciarBatalla.Size = new System.Drawing.Size(215, 53);
            this.btnIniciarBatalla.TabIndex = 1;
            this.btnIniciarBatalla.Text = "Iniciar batalla";
            this.btnIniciarBatalla.UseVisualStyleBackColor = true;
            this.btnIniciarBatalla.Click += new System.EventHandler(this.BtnIniciarBatalla_Click);
            // 
            // btnLimpiarBarcos
            // 
            this.btnLimpiarBarcos.Enabled = false;
            this.btnLimpiarBarcos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarBarcos.Location = new System.Drawing.Point(877, 31);
            this.btnLimpiarBarcos.Name = "btnLimpiarBarcos";
            this.btnLimpiarBarcos.Size = new System.Drawing.Size(215, 53);
            this.btnLimpiarBarcos.TabIndex = 2;
            this.btnLimpiarBarcos.Text = "Limpiar tableros";
            this.btnLimpiarBarcos.UseVisualStyleBackColor = true;
            this.btnLimpiarBarcos.Click += new System.EventHandler(this.BtnLimpiarBarcos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(291, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Jugador A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1241, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Jugador B";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(193, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 30);
            this.label3.TabIndex = 5;
            this.label3.Text = "Estrategia: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(193, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 30);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cant tiros:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(193, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 30);
            this.label5.TabIndex = 7;
            this.label5.Text = "Cant aciertos:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1174, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 30);
            this.label6.TabIndex = 8;
            this.label6.Text = "Estrategia: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1174, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 30);
            this.label7.TabIndex = 9;
            this.label7.Text = "Cant tiros:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1174, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 30);
            this.label8.TabIndex = 10;
            this.label8.Text = "Cant aciertos:";
            // 
            // lblEstrategiaB
            // 
            this.lblEstrategiaB.AutoSize = true;
            this.lblEstrategiaB.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstrategiaB.Location = new System.Drawing.Point(1322, 79);
            this.lblEstrategiaB.Name = "lblEstrategiaB";
            this.lblEstrategiaB.Size = new System.Drawing.Size(58, 30);
            this.lblEstrategiaB.TabIndex = 11;
            this.lblEstrategiaB.Text = "Caza";
            // 
            // lblCantTirosB
            // 
            this.lblCantTirosB.AutoSize = true;
            this.lblCantTirosB.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantTirosB.Location = new System.Drawing.Point(1322, 117);
            this.lblCantTirosB.Name = "lblCantTirosB";
            this.lblCantTirosB.Size = new System.Drawing.Size(0, 30);
            this.lblCantTirosB.TabIndex = 12;
            // 
            // lblAciertosB
            // 
            this.lblAciertosB.AutoSize = true;
            this.lblAciertosB.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAciertosB.Location = new System.Drawing.Point(1322, 157);
            this.lblAciertosB.Name = "lblAciertosB";
            this.lblAciertosB.Size = new System.Drawing.Size(0, 30);
            this.lblAciertosB.TabIndex = 13;
            // 
            // lblAciertosA
            // 
            this.lblAciertosA.AutoSize = true;
            this.lblAciertosA.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAciertosA.Location = new System.Drawing.Point(365, 157);
            this.lblAciertosA.Name = "lblAciertosA";
            this.lblAciertosA.Size = new System.Drawing.Size(0, 30);
            this.lblAciertosA.TabIndex = 16;
            // 
            // lblCantTirosA
            // 
            this.lblCantTirosA.AutoSize = true;
            this.lblCantTirosA.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantTirosA.Location = new System.Drawing.Point(365, 117);
            this.lblCantTirosA.Name = "lblCantTirosA";
            this.lblCantTirosA.Size = new System.Drawing.Size(0, 30);
            this.lblCantTirosA.TabIndex = 15;
            // 
            // lblEstrategiaA
            // 
            this.lblEstrategiaA.AutoSize = true;
            this.lblEstrategiaA.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstrategiaA.Location = new System.Drawing.Point(365, 79);
            this.lblEstrategiaA.Name = "lblEstrategiaA";
            this.lblEstrategiaA.Size = new System.Drawing.Size(91, 30);
            this.lblEstrategiaA.TabIndex = 14;
            this.lblEstrategiaA.Text = "Random";
            // 
            // lblGanadorA
            // 
            this.lblGanadorA.AutoSize = true;
            this.lblGanadorA.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGanadorA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblGanadorA.Location = new System.Drawing.Point(303, 6);
            this.lblGanadorA.Name = "lblGanadorA";
            this.lblGanadorA.Size = new System.Drawing.Size(121, 32);
            this.lblGanadorA.TabIndex = 17;
            this.lblGanadorA.Text = "Ganador!";
            this.lblGanadorA.Visible = false;
            // 
            // lblGanadorB
            // 
            this.lblGanadorB.AutoSize = true;
            this.lblGanadorB.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGanadorB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblGanadorB.Location = new System.Drawing.Point(1241, 6);
            this.lblGanadorB.Name = "lblGanadorB";
            this.lblGanadorB.Size = new System.Drawing.Size(121, 32);
            this.lblGanadorB.TabIndex = 18;
            this.lblGanadorB.Text = "Ganador!";
            this.lblGanadorB.Visible = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.lblGanadorB);
            this.Controls.Add(this.lblGanadorA);
            this.Controls.Add(this.lblAciertosA);
            this.Controls.Add(this.lblCantTirosA);
            this.Controls.Add(this.lblEstrategiaA);
            this.Controls.Add(this.lblAciertosB);
            this.Controls.Add(this.lblCantTirosB);
            this.Controls.Add(this.lblEstrategiaB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLimpiarBarcos);
            this.Controls.Add(this.btnIniciarBatalla);
            this.Controls.Add(this.btnUbicarBarcos);
            this.Name = "Game";
            this.Text = "Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUbicarBarcos;
        private System.Windows.Forms.Button btnIniciarBatalla;
        private System.Windows.Forms.Button btnLimpiarBarcos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblEstrategiaB;
        private System.Windows.Forms.Label lblCantTirosB;
        private System.Windows.Forms.Label lblAciertosB;
        private System.Windows.Forms.Label lblAciertosA;
        private System.Windows.Forms.Label lblCantTirosA;
        private System.Windows.Forms.Label lblEstrategiaA;
        private System.Windows.Forms.Label lblGanadorA;
        private System.Windows.Forms.Label lblGanadorB;
    }
}