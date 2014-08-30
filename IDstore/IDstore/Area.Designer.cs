namespace IDstore
{
    partial class Area
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
            this.dgvArea = new System.Windows.Forms.DataGridView();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArea
            // 
            this.dgvArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArea.Location = new System.Drawing.Point(12, 50);
            this.dgvArea.Name = "dgvArea";
            this.dgvArea.Size = new System.Drawing.Size(449, 316);
            this.dgvArea.TabIndex = 5;
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(12, 12);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(368, 20);
            this.txtArea.TabIndex = 4;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(386, 9);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // Area
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 383);
            this.Controls.Add(this.dgvArea);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.btnAgregar);
            this.Name = "Area";
            this.Text = "Area";
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArea;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Button btnAgregar;
    }
}