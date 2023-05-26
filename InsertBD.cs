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
        string cadenaConexion = "Data Source=.\\sqlexpress;Initial Catalog=master;Integrated Security=True;";

        public void InsertInfoIngrediente(InfoNutricionalIngrediente infoIngrediente)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    Console.WriteLine("Connection Open!");

                    string insertInfoIngrediente = "USE [InformacionNutricional]; INSERT INTO ValoresNutricionalesIngredientes (IngredienteID, Calorias, ProteinasGrs, Carbohidratos, Grasas) " +
                                                   "VALUES(40, @kcal, @prot, @carbs, @grasa);";

                    using (SqlCommand comandoInsertInfoIngrediente = new SqlCommand(insertInfoIngrediente, conn))
                    {
                        comandoInsertInfoIngrediente.Parameters.AddWithValue("@kcal", infoIngrediente.calorias);
                        comandoInsertInfoIngrediente.Parameters.AddWithValue("@prot", infoIngrediente.proteinas);
                        comandoInsertInfoIngrediente.Parameters.AddWithValue("@carbs", infoIngrediente.carbohidratos);
                        comandoInsertInfoIngrediente.Parameters.AddWithValue("@grasa", infoIngrediente.grasas);

                        Console.WriteLine(infoIngrediente.calorias);

                        comandoInsertInfoIngrediente.ExecuteNonQuery();

                        Console.WriteLine(infoIngrediente.calorias);
                    }

                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine(sqlex.Message);
            }
        }
    }
}
