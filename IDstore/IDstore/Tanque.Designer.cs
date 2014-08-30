namespace IDstore
{
    partial class Tanque
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdTanque = new System.Windows.Forms.TextBox();
            this.txtVolumenActual = new System.Windows.Forms.TextBox();
            this.txtVolumenMaximo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Volumen  Maximo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Volumen Actual:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "ID Tanque:";
            // 
            // txtIdTanque
            // 
            this.txtIdTanque.Location = new System.Drawing.Point(115, 37);
            this.txtIdTanque.Name = "txtIdTanque";
            this.txtIdTanque.Size = new System.Drawing.Size(100, 20);
            this.txtIdTanque.TabIndex = 3;
            this.txtIdTanque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdTanque_KeyPress);
            // 
            // txtVolumenActual
            // 
            this.txtVolumenActual.Location = new System.Drawing.Point(115, 76);
            this.txtVolumenActual.Name = "txtVolumenActual";
            this.txtVolumenActual.Size = new System.Drawing.Size(100, 20);
            this.txtVolumenActual.TabIndex = 4;
            // 
            // txtVolumenMaximo
            // 
            this.txtVolumenMaximo.Location = new System.Drawing.Point(115, 121);
            this.txtVolumenMaximo.Name = "txtVolumenMaximo";
            this.txtVolumenMaximo.Size = new System.Drawing.Size(100, 20);
            this.txtVolumenMaximo.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtVolumenMaximo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtIdTanque);
            this.groupBox1.Controls.Add(this.txtVolumenActual);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 172);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Tanque";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.Image = global::IDstore.Properties.Resources.document_save;
            this.btnGuardar.Location = new System.Drawing.Point(12, 199);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(41, 43);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Tanque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 254);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Name = "Tanque";
            this.Text = "Tanque";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdTanque;
        private System.Windows.Forms.TextBox txtVolumenActual;
        private System.Windows.Forms.TextBox txtVolumenMaximo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGuardar;
    }
}