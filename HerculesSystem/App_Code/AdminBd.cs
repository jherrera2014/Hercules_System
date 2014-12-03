using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Hercules.App_Code
{
    public class AdminBd
    {
        public SqlConnection Abrir_Conexion_BD()
        {

            SqlConnection Con = null;
            string conString = null;
            conString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            Con = new SqlConnection(conString);


            Con.Open();
            conString = null;
            return Con;

        }

        public Boolean list_alert_logger(ref DataTable tab_in, ArrayList datos)
        {
            //if (datos.Count == 0)
            //{
                SqlConnection MyConnection = null;
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter();
                System.Data.DataTable tabla = new System.Data.DataTable();

                MyConnection = Abrir_Conexion_BD();

                MyCommand = new SqlCommand();
                MyCommand.CommandTimeout = 20000;
                MyCommand.CommandText = @"SELECT LoggerSmSNumber, AlarmText, MessageID
                FROM   alarms";
                MyCommand.CommandType = System.Data.CommandType.Text;
                MyCommand.Connection = MyConnection;

                try
                {
                    MyDataAdapter.SelectCommand = MyCommand;
                    tabla.Clear();
                    MyDataAdapter.Fill(tabla);
                    tab_in = tabla;
                    tabla = null;
                    MyConnection.Close();
                }
                catch (Exception ex)
                {
                    //logError.WriteError(ex.Message);
                    MyConnection.Close();
                    return false;
                }
                return true;
            //}
            //else return false;
        }
    }
}