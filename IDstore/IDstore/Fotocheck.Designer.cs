namespace IDstore
{
    partial class Fotocheck
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
            this.colaboradoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS_Colaboradores = new DS_Colaboradores();
            this.colaboradoresTableAdapter = new DS_ColaboradoresTableAdapters.colaboradoresTableAdapter();
            this.tableAdapterManager = new DS_ColaboradoresTableAdapters.TableAdapterManager();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.colaboradoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_Colaboradores)).BeginInit();
            this.SuspendLayout();
            // 
            // colaboradoresBindingSource
            // 
            this.colaboradoresBindingSource.DataMember = "colaboradores";
            this.colaboradoresBindingSource.DataSource = this.dS_Colaboradores;
            // 
            // dS_Colaboradores
            // 
            this.dS_Colaboradores.DataSetName = "DS_Colaboradores";
            this.dS_Colaboradores.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // colaboradoresTableAdapter
            // 
            this.colaboradoresTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.colaboradoresTableAdapter = this.colaboradoresTableAdapter;
            this.tableAdapterManager.UpdateOrder = DS_ColaboradoresTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.colaboradoresBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "IDstore.RPT_Fotocheck.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1035, 797);
            this.reportViewer1.TabIndex = 0;
            // 
            // Fotocheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 797);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Fotocheck";
            this.Text = "Fotocheck";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Fotocheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.colaboradoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_Colaboradores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DS_Colaboradores dS_Colaboradores;
        private System.Windows.Forms.BindingSource colaboradoresBindingSource;
        private DS_ColaboradoresTableAdapters.colaboradoresTableAdapter colaboradoresTableAdapter;
        private DS_ColaboradoresTableAdapters.TableAdapterManager tableAdapterManager;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}