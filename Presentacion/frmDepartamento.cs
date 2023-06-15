using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeptosEmpleados.Negocio;
using DeptosEmpleados.AccesoDatos;

namespace DeptosEmpleados.Presentacion
{
    public partial class frm2 : Form
    {
        DepartamentosAccesoDatos oDepartamentosAccesoDatos;
        public frm2()
        {

            oDepartamentosAccesoDatos = new DepartamentosAccesoDatos();
            InitializeComponent();
            llenarGrid();
            limpiarEntrada();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // instruccion GUI (Obtener Informacion de la presentacion)
            oDepartamentosAccesoDatos.agregar(recuperarInformacion());
            llenarGrid();
            limpiarEntrada();
        }
        private DepartamentosNegocio recuperarInformacion()
        {
            DepartamentosNegocio oDepartamentosNegocio = new DepartamentosNegocio();
            int ID = 0;
            int.TryParse(txtID.Text, out ID);
            oDepartamentosNegocio.ID = ID;
            oDepartamentosNegocio.Departamento = txtNombre.Text;
            return oDepartamentosNegocio;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oDepartamentosAccesoDatos.modificar(recuperarInformacion());
            llenarGrid();
            limpiarEntrada();

        }

        public void llenarGrid()
        {
            dgvDepartamento.DataSource = oDepartamentosAccesoDatos.mostrarDepartamentos().Tables[0];
        }

        public void limpiarEntrada()
        {
            txtID.Text = " ";
            txtNombre.Text = " ";

            txtID.Enabled = true;
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnBorrar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            if(indice >= 0)
            {
                txtID.Text = dgvDepartamento.Rows[indice].Cells[0].Value.ToString();
                txtNombre.Text = dgvDepartamento.Rows[indice].Cells[1].Value.ToString();

                btnAgregar.Enabled = false;
                btnModificar.Enabled = true;
                btnBorrar.Enabled = true;
                btnCancelar.Enabled = true;
            }
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarEntrada();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            oDepartamentosAccesoDatos.eliminar(recuperarInformacion());
            llenarGrid();
            limpiarEntrada();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
