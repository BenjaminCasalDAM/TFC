using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFC_Benjamin
{
    class InsertBD
    {
        string cadenaConexion = "Data Source=nune-dpos022\\sqlexpress;Initial Catalog=master;Integrated Security=True;";

        public void CrearBD(InfoNutricionalIngrediente infoIngrediente)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    Console.WriteLine("Connection Open!");

                    

                }
            }
            catch (SqlException sqlex)
            {

            }
        }
    }
}
