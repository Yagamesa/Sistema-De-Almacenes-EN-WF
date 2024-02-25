namespace PedidosApp.Reportes
{
    partial class frmReporteTrabajadores
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsPrincipal = new PedidosApp.dsPrincipal();
            this.spreportetrabajadoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_reporte_trabajadoresTableAdapter = new PedidosApp.dsPrincipalTableAdapters.sp_reporte_trabajadoresTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spreportetrabajadoresBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "reporte_trabajadores";
            reportDataSource1.Value = this.spreportetrabajadoresBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PedidosApp.Reportes.rptTrabajador.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spreportetrabajadoresBindingSource
            // 
            this.spreportetrabajadoresBindingSource.DataMember = "sp_reporte_trabajadores";
            this.spreportetrabajadoresBindingSource.DataSource = this.dsPrincipal;
            // 
            // sp_reporte_trabajadoresTableAdapter
            // 
            this.sp_reporte_trabajadoresTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteTrabajadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteTrabajadores";
            this.Text = "frmReporteTrabajadores";
            this.Load += new System.EventHandler(this.frmReporteTrabajadores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spreportetrabajadoresBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dsPrincipal dsPrincipal;
        private System.Windows.Forms.BindingSource spreportetrabajadoresBindingSource;
        private dsPrincipalTableAdapters.sp_reporte_trabajadoresTableAdapter sp_reporte_trabajadoresTableAdapter;
    }
}