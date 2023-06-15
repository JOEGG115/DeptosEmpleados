using DeptosEmpleados.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptosEmpleados.AccesoDatos
{
    internal class EmpleadosAccesoDatos
    {
        ConexionAccesoDatos conexion;

        public EmpleadosAccesoDatos() 
        {
            conexion = new ConexionAccesoDatos();
        }

        public bool agregar(EmpleadosNegocio oEmpleadosNegocio)
        {
            SqlCommand SQLComandoEmpleado = new SqlCommand("INSERT INTO Empleados VALUES(@Nombres, @PrimerApellido, @SegundoApellido,@Correo, @foto)");
            SQLComandoEmpleado.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = oEmpleadosNegocio.NombreEmpleado;
            SQLComandoEmpleado.Parameters.Add("@PrimerApellido", SqlDbType.VarChar).Value = oEmpleadosNegocio.PrimerApellido;
            SQLComandoEmpleado.Parameters.Add("@SegundoApellido", SqlDbType.VarChar).Value = oEmpleadosNegocio.SegundoApellido;
            SQLComandoEmpleado.Parameters.Add("@Correo", SqlDbType.VarChar).Value = oEmpleadosNegocio.Correo;
            SQLComandoEmpleado.Parameters.Add("@Foto", SqlDbType.Image).Value = oEmpleadosNegocio.FotoEmpleado;
            return conexion.ejecutarComandoSinRetornoDatos(SQLComandoEmpleado);
        }

        public bool agregarEmpDep(EmpleadosNegocio oEmpleadosNegocio)
        {
            SqlCommand SQLCommandoEmplea = new SqlCommand("INSERT INTO EmpleadoDepartamento VALUES (@idDepartamento, @idEmpleado)");
            SQLCommandoEmplea.Parameters.Add("@idDepartamento", SqlDbType.Int).Value = oEmpleadosNegocio.Departamento;
            SQLCommandoEmplea.Parameters.Add("@idEmpleado", SqlDbType.Int).Value = oEmpleadosNegocio.ID;

            return conexion.ejecutarComandoSinRetornoDatos(SQLCommandoEmplea);
        }

        internal bool eliminar(EmpleadosNegocio oEmpleadosNegocio)
        {
            SqlCommand SQLComandoEmpleado = new SqlCommand("DELETE FROM Empleados WHERE ID=@NombreEmpleado");
            SQLComandoEmpleado.Parameters.Add("@NombreEmpleado", SqlDbType.Int).Value = oEmpleadosNegocio.ID;
            return conexion.ejecutarComandoSinRetornoDatos(SQLComandoEmpleado);
        }

        internal bool modificar(EmpleadosNegocio oEmpleadosNegocio)
        {
            SqlCommand SQLComandoEmpleado = new SqlCommand("UPDATE Empleados SET Nombres = @Nombres, PrimerApellido = @PrimerApellido, SegundoApellido = @SegundoApellido, Correo = @Correo, foto = @Foto WHERE ID = @ID");
            SQLComandoEmpleado.Parameters.Add("@ID", SqlDbType.Int).Value = oEmpleadosNegocio.ID;
            SQLComandoEmpleado.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = oEmpleadosNegocio.NombreEmpleado;
            SQLComandoEmpleado.Parameters.Add("@PrimerApellido", SqlDbType.VarChar).Value = oEmpleadosNegocio.PrimerApellido;
            SQLComandoEmpleado.Parameters.Add("@SegundoApellido", SqlDbType.VarChar).Value = oEmpleadosNegocio.SegundoApellido;
            SQLComandoEmpleado.Parameters.Add("@Correo", SqlDbType.VarChar).Value = oEmpleadosNegocio.Correo;
            SQLComandoEmpleado.Parameters.Add("@Foto", SqlDbType.Image).Value = oEmpleadosNegocio.FotoEmpleado;
            return conexion.ejecutarComandoSinRetornoDatos(SQLComandoEmpleado);

        }


        public DataSet mostrarEmpleados()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Empleados");
            return conexion.ejecutarSentencia(sentencia);

        }

        public DataSet mostrarInformacion()
        {
            SqlCommand sentencia = new SqlCommand("SELECT MAX(ID) FROM Empleados");
            return conexion.ejecutarSentencia(sentencia);
        }

        internal string nombreDelDepartamento(int idEmpleado)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT Departamento FROM Departamentos INNER JOIN EmpleadoDepartamento ON Departamentos.ID = EmpleadoDepartamento.idDepartamento WHERE EmpleadoDepartamento.idEmpleado = @idEmpleado");
            sqlCommand.Parameters.Add("@idEmpleado", SqlDbType.Int).Value = idEmpleado;
            DataSet resultado = conexion.ejecutarSentencia(sqlCommand);

            if (resultado.Tables.Count > 0 && resultado.Tables[0].Rows.Count > 0)
            {
                return resultado.Tables[0].Rows[0]["Departamento"].ToString();
            }

            return string.Empty;
        }
    }

}
