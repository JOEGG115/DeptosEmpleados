using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DeptosEmpleados.Negocio;
using System.Windows.Forms;

namespace DeptosEmpleados.AccesoDatos
{
    internal class DepartamentosAccesoDatos
    {
        ConexionAccesoDatos conexion;
        
        public DepartamentosAccesoDatos()
        {
            conexion = new ConexionAccesoDatos();
        }

        public bool agregar(DepartamentosNegocio oDepartamentosNegocio)
        {
            SqlCommand SQLCommand = new SqlCommand("INSERT INTO Departamentos VALUES(@Departamento)");
            SQLCommand.Parameters.Add("@Departamento",SqlDbType.VarChar).Value = oDepartamentosNegocio.Departamento;
           return conexion.ejecutarComandoSinRetornoDatos(SQLCommand);

        }

        internal bool eliminar(DepartamentosNegocio oDepartamentosNegocio)
        {
            if (existenEmpleadosRegistrados(oDepartamentosNegocio.ID))
            {
                MessageBox.Show("No se puede eliminar ya que tiene registrados.");
                return false;
            }
            SqlCommand SQLcommand = new SqlCommand("DELETE FROM Departamentos WHERE ID=@Departamento");
            SQLcommand.Parameters.Add("@Departamento",SqlDbType.Int).Value = oDepartamentosNegocio.ID;
            return conexion.ejecutarComandoSinRetornoDatos(SQLcommand);
        }

        public bool modificar(DepartamentosNegocio oDepartamentosNegocio)
        {
            if (existenEmpleadosRegistrados(oDepartamentosNegocio.ID))
            {
                MessageBox.Show("No se puede modificar ya que tiene registrados.");
                return false;
            }
            SqlCommand SQLcommand = new SqlCommand("UPDATE Departamentos SET departamento = @Departamento WHERE ID=@ID");
            SQLcommand.Parameters.Add("@ID", SqlDbType.Int).Value = oDepartamentosNegocio.ID;
            SQLcommand.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = oDepartamentosNegocio.Departamento;
            return conexion.ejecutarComandoSinRetornoDatos(SQLcommand);
        }

        private bool existenEmpleadosRegistrados(int eDepartamentoID)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM EmpleadoDepartamento WHERE idDepartamento = @idDepartamento");
            sqlCommand.Parameters.Add("@idDepartamento", SqlDbType.Int).Value = eDepartamentoID;
            DataSet resultado = conexion.ejecutarSentencia(sqlCommand);
            int contadorEmpDep = 0; 

            if (resultado.Tables.Count > 0 && resultado.Tables[0].Rows.Count > 0) //Consulta de la tabla para checar a ver si tiene algun empleado en este departamento
            {
                contadorEmpDep = Convert.ToInt32(resultado.Tables[0].Rows[0][0]); // Convierte los registros de la tabla en enteros
            }

            return contadorEmpDep > 0; //regresa el valor de la variable poniendo la cantidad de los empleados registrados
        }

        public DataSet mostrarDepartamentos()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Departamentos ");
            return conexion.ejecutarSentencia(sentencia);
        }
    }
}
