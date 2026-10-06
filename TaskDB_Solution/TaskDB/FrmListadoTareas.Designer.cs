namespace TaskDB
{
    partial class FrmListadoTareas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblFiltro = new System.Windows.Forms.Label();
            this.cboFiltro = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnNuevaTarea = new System.Windows.Forms.Button();
            this.dgvTareas = new System.Windows.Forms.DataGridView();
            this.btnCompletar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareas)).BeginInit();
            this.SuspendLayout();
            // lblFiltro
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(12, 17);
            this.lblFiltro.Text = "Filtrar Estado:";
            // cboFiltro
            this.cboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltro.Items.AddRange(new object[] { "Todas", "Pendiente", "Completada" });
            this.cboFiltro.Location = new System.Drawing.Point(95, 13);
            this.cboFiltro.Size = new System.Drawing.Size(130, 21);
            this.cboFiltro.TabIndex = 0;
            // btnFiltrar
            this.btnFiltrar.Location = new System.Drawing.Point(235, 11);
            this.btnFiltrar.Size = new System.Drawing.Size(80, 25);
            this.btnFiltrar.TabIndex = 1;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // btnNuevaTarea
            this.btnNuevaTarea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevaTarea.Location = new System.Drawing.Point(562, 11);
            this.btnNuevaTarea.Size = new System.Drawing.Size(110, 25);
            this.btnNuevaTarea.TabIndex = 2;
            this.btnNuevaTarea.Text = "+ Nueva Tarea";
            this.btnNuevaTarea.UseVisualStyleBackColor = true;
            this.btnNuevaTarea.Click += new System.EventHandler(this.btnNuevaTarea_Click);
            // dgvTareas
            this.dgvTareas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTareas.AllowUserToAddRows = false;
            this.dgvTareas.AllowUserToDeleteRows = false;
            this.dgvTareas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTareas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTareas.Location = new System.Drawing.Point(12, 48);
            this.dgvTareas.MultiSelect = false;
            this.dgvTareas.ReadOnly = true;
            this.dgvTareas.RowHeadersVisible = false;
            this.dgvTareas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTareas.Size = new System.Drawing.Size(660, 310);
            this.dgvTareas.TabIndex = 3;
            // btnCompletar
            this.btnCompletar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCompletar.Location = new System.Drawing.Point(12, 368);
            this.btnCompletar.Size = new System.Drawing.Size(160, 30);
            this.btnCompletar.TabIndex = 4;
            this.btnCompletar.Text = "Marcar como Completada";
            this.btnCompletar.UseVisualStyleBackColor = true;
            this.btnCompletar.Click += new System.EventHandler(this.btnCompletar_Click);
            // FrmListadoTareas
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 410);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.cboFiltro);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.btnNuevaTarea);
            this.Controls.Add(this.dgvTareas);
            this.Controls.Add(this.btnCompletar);
            this.MinimumSize = new System.Drawing.Size(520, 300);
            this.Name = "FrmListadoTareas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmListadoTareas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cboFiltro;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnNuevaTarea;
        private System.Windows.Forms.DataGridView dgvTareas;
        private System.Windows.Forms.Button btnCompletar;
    }
}
