using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DeptosEmpleados.AccesoDatos
{
    internal class ConexionAccesoDatos
        {                                          //DESKTOP-4I2957H\\SQLEXPRESS PC CASA
                                                   //DESKTOP-L2TDMQF\SQLEXPRESS01
        private string cadenaConexion = "Data Source=DESKTOP-L2TDMQF\\SQLEXPRESS01; Initial Catalog=bdEmpleaDepto;Integrated Security=true";
        SqlConnection Conexion;

        public SqlConnection establecerConexion()
        {
            this.Conexion = new SqlConnection(this.cadenaConexion);
            return Conexion;  
        }

        //Metodo INSERT , DELETE , UPDATE
        public bool ejecutarComandoSinRetornoDatos(string strComando)
        {
            try {
               
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = strComando;
                Comando.Connection = this.establecerConexion();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch {
                return false;

            }
           
        }
        //Metodo SELECT (retorna datos)
        public DataSet ejecutarSentencia(SqlCommand sqlComando)
        {
            DataSet DS = new DataSet();
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando = sqlComando;
                Adaptador.SelectCommand = Comando;
                Comando.Connection = this.establecerConexion();
                Conexion.Open();
                Adaptador.Fill(DS);
                Comando.ExecuteNonQuery();
                Conexion.Close();
                return DS;
            }
            catch
            {
                return DS;

            }

        }

        // sobrecarga Metodo INSERT , DELETE , UPDATE
        public bool ejecutarComandoSinRetornoDatos(SqlCommand SQLcomando)
        {
            try
            {
                SqlCommand Comando = SQLcomando;
                Comando.Connection = this.establecerConexion();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch
            {
                return false;

            }

        }

    }
}
