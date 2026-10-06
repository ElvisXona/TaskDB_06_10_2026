using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TaskDB
{ 
    public partial class FrmListadoTareas : Form
    {
        public FrmListadoTareas()
        {
            InitializeComponent();
            cboFiltro.SelectedIndex = 0;
            dgvTareas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Load += (s, e) => CargarTareas();
        }
        private void CargarTareas()
        {
            string sql = "SELECT Id, Titulo, Estado, FechaCreacion FROM Tareas";
            string filtro = cboFiltro.Text;
            bool filtrar = filtro == "Pendiente" || filtro == "Completada";
            if (filtrar) sql += " WHERE Estado = @Estado";
            sql += " ORDER BY Id";

            try
            {
                using (var cn = DatabaseConnection.GetConnection())
                using (var da = new SqlDataAdapter(sql, cn))
                {
                    if (filtrar) da.SelectCommand.Parameters.AddWithValue("@Estado", filtro);
                    var dt = new DataTable();
                    da.Fill(dt);
                    dgvTareas.DataSource = dt;
                }
                ConfigurarGrilla();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al leer las tareas:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // RNF3.1: encabezados limpios
        private void ConfigurarGrilla()
        {
            if (dgvTareas.Columns.Count < 4) return;
            dgvTareas.Columns["Id"].HeaderText = "ID";
            dgvTareas.Columns["Titulo"].HeaderText = "Título";
            dgvTareas.Columns["Estado"].HeaderText = "Estado";
            dgvTareas.Columns["FechaCreacion"].HeaderText = "Fecha Creación";
            dgvTareas.Columns["FechaCreacion"].DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvTareas.Columns["Id"].FillWeight = 10;
            dgvTareas.Columns["Titulo"].FillWeight = 50;
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarTareas();
        }
        private void btnNuevaTarea_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmAgregarTarea())
            {
                if (frm.ShowDialog(this) == DialogResult.OK) CargarTareas();
            }
        }
        private void btnCompletar_Click(object sender, EventArgs e)
        {
            if (dgvTareas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una tarea.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvTareas.CurrentRow.Cells["Id"].Value);
            try
            {
                using (var cn = DatabaseConnection.GetConnection())
                using (var cmd = new SqlCommand(
                    "UPDATE Tareas SET Estado = 'Completada' WHERE Id = @Id", cn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                CargarTareas();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al actualizar la tarea:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
