using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeptosEmpleados.Presentacion;

namespace DeptosEmpleados
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            frmEmpleados fromularioEmpleados= new frmEmpleados();
            fromularioEmpleados.Show();
        }

        private void btnDepartamentos_Click(object sender, EventArgs e)
        {
            frm2 formularioDepartamentos = new frm2();
            formularioDepartamentos.Show();
        }
    }
}
