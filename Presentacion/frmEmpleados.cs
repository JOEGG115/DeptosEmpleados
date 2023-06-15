using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeptosEmpleados.AccesoDatos;
using DeptosEmpleados.Negocio;


namespace DeptosEmpleados.Presentacion

{
    public partial class frmEmpleados : Form
    {
        byte[] imagenByte;
        Image picFotoCop;

        EmpleadosAccesoDatos oEmpleadosAccesoDatos;
        public frmEmpleados()
        {
            oEmpleadosAccesoDatos = new EmpleadosAccesoDatos();
            InitializeComponent();
            llenarGrid();
            inicio();
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            DepartamentosAccesoDatos objDepartamentos = new DepartamentosAccesoDatos();
            cbxDepartamento.DataSource = objDepartamentos.mostrarDepartamentos().Tables[0];
            cbxDepartamento.DisplayMember = "departamento";
            cbxDepartamento.ValueMember= "ID";
            llenarGrid();

            picFotoCop = picFoto.Image;
        }

        private EmpleadosNegocio recolectarDatos()
        {
            EmpleadosNegocio objEmpleados = new EmpleadosNegocio();

            int codigoEmpleado = 1;
            int.TryParse(txtID.Text, out codigoEmpleado);

            objEmpleados.ID = codigoEmpleado;
            objEmpleados.NombreEmpleado = txtNombre.Text;
            objEmpleados.PrimerApellido = txtPrimerApellido.Text;
            objEmpleados.SegundoApellido = txtSegundoApellido.Text;
            objEmpleados.Correo = txtCorreo.Text;

            int IDDepartamento = 0;
            int.TryParse(cbxDepartamento.SelectedValue.ToString(), out IDDepartamento);

            objEmpleados.Departamento = IDDepartamento;
            objEmpleados.FotoEmpleado = imagenByte;

            return objEmpleados;
        }

        private EmpleadosNegocio recolectarinformacionED()
        {
            EmpleadosNegocio objEmpleados = new EmpleadosNegocio();
            int codigoEmpleado = 1;
            int.TryParse(txtID.Text, out codigoEmpleado);
            objEmpleados.ID = codigoEmpleado;

            int IDDepartamento = 0;
            int.TryParse(cbxDepartamento.SelectedValue.ToString(), out IDDepartamento);
            objEmpleados.Departamento = IDDepartamento;

            return objEmpleados;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!picFoto.Image.Equals(picFotoCop))
            {
                oEmpleadosAccesoDatos.agregar(recolectarDatos());
                dgvEmpleados.DataSource = oEmpleadosAccesoDatos.mostrarInformacion().Tables[0];
                String valorID = dgvEmpleados.CurrentRow.Cells[0].Value.ToString();
                txtID.Text = valorID;
                oEmpleadosAccesoDatos.agregarEmpDep(recolectarinformacionED()); 
                llenarGrid();
                limpiarEntrada();
            }
            else if (txtNombre.Text.Equals("") || txtPrimerApellido.Text.Equals("") || txtSegundoApellido.Text.Equals("") || txtCorreo.Text.Equals(""))
            {
                MessageBox.Show("Favor de capturar foto/Llenar datos faltantes");
            }

        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectorImagen = new OpenFileDialog();
            selectorImagen.Title = "Seleccionar Imagen";

            if (selectorImagen.ShowDialog() == DialogResult.OK)
            {
                picFoto.Image = Image.FromStream(selectorImagen.OpenFile());

                //convertir la foto a un arreglo de byte
                MemoryStream memoria = new MemoryStream();
                picFoto.Image.Save(memoria, System.Drawing.Imaging.ImageFormat.Png);

                imagenByte = memoria.ToArray();

            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            oEmpleadosAccesoDatos.eliminar(recolectarDatos());
            llenarGrid();
            limpiarEntrada();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
                EmpleadosNegocio empleado = recolectarDatos();

                // Obtener el ID del empleado y el ID del departamento seleccionado en el ComboBox
                int idEmpleado = empleado.ID;
                int idDepartamento = Convert.ToInt32(cbxDepartamento.SelectedValue);

                // Crear una instancia de ConexionAccesoDatos
                ConexionAccesoDatos conexionAccesoDatos = new ConexionAccesoDatos();

                // Ejecutar la consulta SQL para actualizar el ID del departamento en la tabla EmpleadoDepartamento
                string consulta = "UPDATE EmpleadoDepartamento SET IdDepartamento = @IdDepartamento WHERE IdEmpleado = @IdEmpleado";
                SqlCommand comando = new SqlCommand(consulta);
                comando.Parameters.AddWithValue("@IdDepartamento", idDepartamento);
                comando.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                // Ejecutar el comando de actualización
                bool exito = conexionAccesoDatos.ejecutarComandoSinRetornoDatos(comando);

                if (exito)
                {
                    // La actualización se realizó correctamente
                    MessageBox.Show("Se ha modificado el departamento del empleado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Ocurrió un error al realizar la actualización
                    MessageBox.Show("Error al modificar el departamento del empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Continuar con la modificación de los demás campos del empleado
            oEmpleadosAccesoDatos.modificar(empleado);
            oEmpleadosAccesoDatos.modificar(recolectarDatos());
            llenarGrid();
            
        }

        public void llenarGrid()
        {
           
            dgvEmpleados.DataSource = oEmpleadosAccesoDatos.mostrarEmpleados().Tables[0];
           
        }
        public void limpiarEntrada()
        {

            txtID.Text = " ";
            txtNombre.Text = " ";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            txtCorreo.Text = "";
            picFoto.Image = picFotoCop;
            cbxDepartamento.Text = string.Empty;
            
            btnExaminar.Enabled = true;
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnBorrar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            if (indice >= 0)
            {
                txtID.Text = dgvEmpleados.Rows[indice].Cells[0].Value.ToString();
                txtNombre.Text = dgvEmpleados.Rows[indice].Cells[1].Value.ToString();
                txtPrimerApellido.Text = dgvEmpleados.Rows[indice].Cells[2].Value.ToString();
                txtSegundoApellido.Text = dgvEmpleados.Rows[indice].Cells[3].Value.ToString();
                txtCorreo.Text = dgvEmpleados.Rows[indice].Cells[4].Value.ToString();
                imagenByte = (byte[]) dgvEmpleados.Rows[indice].Cells[5].Value;
                Image newImage = byteArrayToImage(imagenByte);
                picFoto.Image = newImage;
                
                
                btnExaminar.Enabled = true;
                btnAgregar.Enabled = false;
                btnModificar.Enabled = true;
                btnBorrar.Enabled = true;
                btnCancelar.Enabled = true;

                String textId = dgvEmpleados.CurrentRow.Cells[0].Value.ToString();
                txtID.Text = textId;
                int idEmpleado = int.Parse(textId);
                EmpleadosAccesoDatos empleadoAccesoDatos = new EmpleadosAccesoDatos(); // Crear una instancia de la clase EmpleadoAccesoDatos
                string nombreDepartamento = empleadoAccesoDatos.nombreDelDepartamento(idEmpleado); // Llamar al método ObtenerNombreDepartamento
                cbxDepartamento.Text = nombreDepartamento; // Asignar el nombre del departamento al ComboBox

            }

        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
            ms.Write(byteArrayIn, 0, byteArrayIn.Length);
            Image returnImage = Image.FromStream(ms, true);
            return returnImage;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarEntrada();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {


        }
        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void inicio()
        {

            btnExaminar.Enabled = true;
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnBorrar.Enabled = false;
            btnCancelar.Enabled = false;
        }
        
    }
}
