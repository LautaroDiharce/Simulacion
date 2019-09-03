namespace TP3SIM
{
    partial class Main
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
            this.rbDistNormal = new System.Windows.Forms.RadioButton();
            this.rbDistUniforme = new System.Windows.Forms.RadioButton();
            this.rbDistExp = new System.Windows.Forms.RadioButton();
            this.rbPoisson = new System.Windows.Forms.RadioButton();
            this.txtUniformeA = new System.Windows.Forms.TextBox();
            this.txtUniformeB = new System.Windows.Forms.TextBox();
            this.txtCantValores = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDesvEstandar = new System.Windows.Forms.TextBox();
            this.txtMedia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLambdaExp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLambdaPoisson = new System.Windows.Forms.TextBox();
            this.lstValores = new System.Windows.Forms.ListBox();
            this.btnGenerarValores = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbDistNormal
            // 
            this.rbDistNormal.AutoSize = true;
            this.rbDistNormal.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDistNormal.Location = new System.Drawing.Point(55, 161);
            this.rbDistNormal.Name = "rbDistNormal";
            this.rbDistNormal.Size = new System.Drawing.Size(231, 34);
            this.rbDistNormal.TabIndex = 1;
            this.rbDistNormal.TabStop = true;
            this.rbDistNormal.Text = "Distribucion Normal";
            this.rbDistNormal.UseVisualStyleBackColor = true;
            this.rbDistNormal.CheckedChanged += new System.EventHandler(this.RbDistNormal_CheckedChanged);
            // 
            // rbDistUniforme
            // 
            this.rbDistUniforme.AutoSize = true;
            this.rbDistUniforme.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDistUniforme.Location = new System.Drawing.Point(55, 30);
            this.rbDistUniforme.Name = "rbDistUniforme";
            this.rbDistUniforme.Size = new System.Drawing.Size(250, 34);
            this.rbDistUniforme.TabIndex = 2;
            this.rbDistUniforme.TabStop = true;
            this.rbDistUniforme.Text = "Distribucion Uniforme";
            this.rbDistUniforme.UseVisualStyleBackColor = true;
            this.rbDistUniforme.CheckedChanged += new System.EventHandler(this.RbDistUniforme_CheckedChanged);
            // 
            // rbDistExp
            // 
            this.rbDistExp.AutoSize = true;
            this.rbDistExp.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDistExp.Location = new System.Drawing.Point(55, 291);
            this.rbDistExp.Name = "rbDistExp";
            this.rbDistExp.Size = new System.Drawing.Size(366, 34);
            this.rbDistExp.TabIndex = 3;
            this.rbDistExp.TabStop = true;
            this.rbDistExp.Text = "Distribucion exponencial negativa";
            this.rbDistExp.UseVisualStyleBackColor = true;
            this.rbDistExp.CheckedChanged += new System.EventHandler(this.RbDistExp_CheckedChanged);
            // 
            // rbPoisson
            // 
            this.rbPoisson.AutoSize = true;
            this.rbPoisson.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPoisson.Location = new System.Drawing.Point(55, 385);
            this.rbPoisson.Name = "rbPoisson";
            this.rbPoisson.Size = new System.Drawing.Size(232, 34);
            this.rbPoisson.TabIndex = 4;
            this.rbPoisson.TabStop = true;
            this.rbPoisson.Text = "Distribucion Poisson";
            this.rbPoisson.UseVisualStyleBackColor = true;
            this.rbPoisson.CheckedChanged += new System.EventHandler(this.RbPoisson_CheckedChanged);
            // 
            // txtUniformeA
            // 
            this.txtUniformeA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUniformeA.Location = new System.Drawing.Point(271, 70);
            this.txtUniformeA.Name = "txtUniformeA";
            this.txtUniformeA.Size = new System.Drawing.Size(100, 29);
            this.txtUniformeA.TabIndex = 5;
            // 
            // txtUniformeB
            // 
            this.txtUniformeB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUniformeB.Location = new System.Drawing.Point(271, 105);
            this.txtUniformeB.Name = "txtUniformeB";
            this.txtUniformeB.Size = new System.Drawing.Size(100, 29);
            this.txtUniformeB.TabIndex = 6;
            // 
            // txtCantValores
            // 
            this.txtCantValores.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantValores.Location = new System.Drawing.Point(271, 497);
            this.txtCantValores.Name = "txtCantValores";
            this.txtCantValores.Size = new System.Drawing.Size(100, 29);
            this.txtCantValores.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Valor para A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Valor para B";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 497);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 30);
            this.label3.TabIndex = 10;
            this.label3.Text = "Cantidad de valores";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(64, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 21);
            this.label4.TabIndex = 14;
            this.label4.Text = "Valor para Desv. Estandar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(64, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "Valor para Media";
            // 
            // txtDesvEstandar
            // 
            this.txtDesvEstandar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesvEstandar.Location = new System.Drawing.Point(271, 236);
            this.txtDesvEstandar.Name = "txtDesvEstandar";
            this.txtDesvEstandar.Size = new System.Drawing.Size(100, 29);
            this.txtDesvEstandar.TabIndex = 12;
            // 
            // txtMedia
            // 
            this.txtMedia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedia.Location = new System.Drawing.Point(271, 201);
            this.txtMedia.Name = "txtMedia";
            this.txtMedia.Size = new System.Drawing.Size(100, 29);
            this.txtMedia.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(64, 339);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 21);
            this.label6.TabIndex = 16;
            this.label6.Text = "Valor para Lambda";
            // 
            // txtLambdaExp
            // 
            this.txtLambdaExp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLambdaExp.Location = new System.Drawing.Point(271, 331);
            this.txtLambdaExp.Name = "txtLambdaExp";
            this.txtLambdaExp.Size = new System.Drawing.Size(100, 29);
            this.txtLambdaExp.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(70, 433);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 21);
            this.label7.TabIndex = 18;
            this.label7.Text = "Valor para Lambda";
            // 
            // txtLambdaPoisson
            // 
            this.txtLambdaPoisson.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLambdaPoisson.Location = new System.Drawing.Point(271, 425);
            this.txtLambdaPoisson.Name = "txtLambdaPoisson";
            this.txtLambdaPoisson.Size = new System.Drawing.Size(100, 29);
            this.txtLambdaPoisson.TabIndex = 17;
            // 
            // lstValores
            // 
            this.lstValores.FormattingEnabled = true;
            this.lstValores.Location = new System.Drawing.Point(480, 42);
            this.lstValores.Name = "lstValores";
            this.lstValores.Size = new System.Drawing.Size(247, 485);
            this.lstValores.TabIndex = 19;
            // 
            // btnGenerarValores
            // 
            this.btnGenerarValores.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarValores.Location = new System.Drawing.Point(64, 564);
            this.btnGenerarValores.Name = "btnGenerarValores";
            this.btnGenerarValores.Size = new System.Drawing.Size(152, 33);
            this.btnGenerarValores.TabIndex = 20;
            this.btnGenerarValores.Text = "Generar valores";
            this.btnGenerarValores.UseVisualStyleBackColor = true;
            this.btnGenerarValores.Click += new System.EventHandler(this.BtnGenerarValores_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(232, 564);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(119, 33);
            this.btnLimpiar.TabIndex = 21;
            this.btnLimpiar.Text = "Limpiar lista";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Location = new System.Drawing.Point(527, 564);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(152, 33);
            this.btnExcel.TabIndex = 22;
            this.btnExcel.Text = "Generar grafico";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 637);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGenerarValores);
            this.Controls.Add(this.lstValores);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLambdaPoisson);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLambdaExp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDesvEstandar);
            this.Controls.Add(this.txtMedia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCantValores);
            this.Controls.Add(this.txtUniformeB);
            this.Controls.Add(this.txtUniformeA);
            this.Controls.Add(this.rbPoisson);
            this.Controls.Add(this.rbDistExp);
            this.Controls.Add(this.rbDistUniforme);
            this.Controls.Add(this.rbDistNormal);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbDistNormal;
        private System.Windows.Forms.RadioButton rbDistUniforme;
        private System.Windows.Forms.RadioButton rbDistExp;
        private System.Windows.Forms.RadioButton rbPoisson;
        private System.Windows.Forms.TextBox txtUniformeA;
        private System.Windows.Forms.TextBox txtUniformeB;
        private System.Windows.Forms.TextBox txtCantValores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDesvEstandar;
        private System.Windows.Forms.TextBox txtMedia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLambdaExp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLambdaPoisson;
        private System.Windows.Forms.ListBox lstValores;
        private System.Windows.Forms.Button btnGenerarValores;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnExcel;
    }
}

