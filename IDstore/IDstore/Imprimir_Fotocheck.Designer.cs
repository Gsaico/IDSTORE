namespace IDstore
{
    partial class Imprimir_Fotocheck
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.COLABORADORESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsColaborador = new dsColaborador();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.COLABORADORESTableAdapter = new dsColaboradorTableAdapters.COLABORADORESTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.COLABORADORESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsColaborador)).BeginInit();
            this.SuspendLayout();
            // 
            // COLABORADORESBindingSource
            // 
            this.COLABORADORESBindingSource.DataMember = "COLABORADORES";
            this.COLABORADORESBindingSource.DataSource = this.dsColaborador;
            // 
            // dsColaborador
            // 
            this.dsColaborador.DataSetName = "dsColaborador";
            this.dsColaborador.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.COLABORADORESBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "IDstore.rptFotocheck.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1084, 873);
            this.reportViewer1.TabIndex = 0;
            // 
            // COLABORADORESTableAdapter
            // 
            this.COLABORADORESTableAdapter.ClearBeforeFill = true;
            // 
            // Imprimir_Fotocheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1084, 873);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Imprimir_Fotocheck";
            this.Text = "Imprimir_Fotocheck";
            this.Load += new System.EventHandler(this.Imprimir_Fotocheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.COLABORADORESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsColaborador)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource COLABORADORESBindingSource;
        private dsColaborador dsColaborador;
        private dsColaboradorTableAdapters.COLABORADORESTableAdapter COLABORADORESTableAdapter;
    }
}