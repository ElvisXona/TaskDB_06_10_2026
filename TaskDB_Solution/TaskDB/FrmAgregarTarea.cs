using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TaskDB
{
    public partial class FrmAgregarTarea : Form
    {
        public FrmAgregarTarea()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("El campo Título es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return;
            }
            
            const string sql =
                "INSERT INTO Tareas (Titulo, Descripcion, Estado, FechaCreacion) " +
                "VALUES (@Titulo, @Descripcion, @Estado, GETDATE())";
            try
            {
                using (var cn = DatabaseConnection.GetConnection())
                using (var cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Titulo", txtTitulo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text.Trim());
                    cmd.Parameters.AddWithValue("@Estado", cboEstado.Text);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al guardar la tarea:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
