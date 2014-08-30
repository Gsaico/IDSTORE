namespace IDstore
{
    partial class CodigodeAbastecimiento
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rbActivo = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.MaskedTextBox();
            this.lbldatoscolaborador = new System.Windows.Forms.Label();
            this.txtIdplacavehiculo = new System.Windows.Forms.TextBox();
            this.txtVolumenAutorizado = new System.Windows.Forms.TextBox();
            this.txtIdtanque = new System.Windows.Forms.TextBox();
            this.txtCodigodeAbastecimiento = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 260);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Almacenes";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(15, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(383, 225);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rbActivo);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtDNI);
            this.tabPage1.Controls.Add(this.lbldatoscolaborador);
            this.tabPage1.Controls.Add(this.txtIdplacavehiculo);
            this.tabPage1.Controls.Add(this.txtVolumenAutorizado);
            this.tabPage1.Controls.Add(this.txtIdtanque);
            this.tabPage1.Controls.Add(this.txtCodigodeAbastecimiento);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(375, 199);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Autorizar Nuevo Tanque";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            this.rbActivo.AutoSize = true;
            this.rbActivo.Location = new System.Drawing.Point(150, 156);
            this.rbActivo.Name = "rbActivo";
            this.rbActivo.Size = new System.Drawing.Size(14, 13);
            this.rbActivo.TabIndex = 25;
            this.rbActivo.TabStop = true;
            this.rbActivo.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Estado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "DNI";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(150, 44);
            this.txtDNI.Mask = "99999999";
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(51, 20);
            this.txtDNI.TabIndex = 10;
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDNI_KeyPress);
            // 
            // lbldatoscolaborador
            // 
            this.lbldatoscolaborador.AutoSize = true;
            this.lbldatoscolaborador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldatoscolaborador.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbldatoscolaborador.Location = new System.Drawing.Point(207, 47);
            this.lbldatoscolaborador.Name = "lbldatoscolaborador";
            this.lbldatoscolaborador.Size = new System.Drawing.Size(19, 13);
            this.lbldatoscolaborador.TabIndex = 11;
            this.lbldatoscolaborador.Text = "...";
            // 
            // txtIdplacavehiculo
            // 
            this.txtIdplacavehiculo.Location = new System.Drawing.Point(150, 122);
            this.txtIdplacavehiculo.Name = "txtIdplacavehiculo";
            this.txtIdplacavehiculo.Size = new System.Drawing.Size(100, 20);
            this.txtIdplacavehiculo.TabIndex = 7;
            // 
            // txtVolumenAutorizado
            // 
            this.txtVolumenAutorizado.Location = new System.Drawing.Point(150, 96);
            this.txtVolumenAutorizado.Name = "txtVolumenAutorizado";
            this.txtVolumenAutorizado.Size = new System.Drawing.Size(100, 20);
            this.txtVolumenAutorizado.TabIndex = 6;
            // 
            // txtIdtanque
            // 
            this.txtIdtanque.Location = new System.Drawing.Point(150, 70);
            this.txtIdtanque.Name = "txtIdtanque";
            this.txtIdtanque.Size = new System.Drawing.Size(100, 20);
            this.txtIdtanque.TabIndex = 5;
            // 
            // txtCodigodeAbastecimiento
            // 
            this.txtCodigodeAbastecimiento.Location = new System.Drawing.Point(150, 18);
            this.txtCodigodeAbastecimiento.Name = "txtCodigodeAbastecimiento";
            this.txtCodigodeAbastecimiento.Size = new System.Drawing.Size(100, 20);
            this.txtCodigodeAbastecimiento.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "N° Placa de vehiculo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Volumen Autorizado:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "N° Tanque:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Codigo de Abastecimiento:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(375, 199);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Historico de Autorizaciones";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(363, 137);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Image = global::IDstore.Properties.Resources.document_save;
            this.btnGuardar.Location = new System.Drawing.Point(12, 287);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(52, 34);
            this.btnGuardar.TabIndex = 38;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevo.Image = global::IDstore.Properties.Resources.add;
            this.btnNuevo.Location = new System.Drawing.Point(70, 287);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(52, 34);
            this.btnNuevo.TabIndex = 39;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // CodigodeAbastecimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 333);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.groupBox2);
            this.Name = "CodigodeAbastecimiento";
            this.Text = "CodigodeAbastecimiento";
            this.Load += new System.EventHandler(this.CodigodeAbastecimiento_Load);
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtIdplacavehiculo;
        private System.Windows.Forms.TextBox txtVolumenAutorizado;
        private System.Windows.Forms.TextBox txtIdtanque;
        private System.Windows.Forms.TextBox txtCodigodeAbastecimiento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtDNI;
        private System.Windows.Forms.Label lbldatoscolaborador;
        private System.Windows.Forms.RadioButton rbActivo;
        private System.Windows.Forms.Label label10;
    }
}