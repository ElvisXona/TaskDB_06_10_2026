using System;
using System.Windows.Forms;

namespace TaskDB
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                DatabaseConnection.EnsureDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo inicializar la base de datos LocalDB:\n" + ex.Message,
                    "TaskDB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.Run(new FrmListadoTareas());
        }
    }
}
