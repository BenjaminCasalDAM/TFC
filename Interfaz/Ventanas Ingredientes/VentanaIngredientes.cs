using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TFC_Benjamin
{
    /// <summary>
    /// 
    /// </summary>
    public partial class VentanaIngredientes : Form
    {
        string cadenaConexion = "Data Source=.\\sqlexpress;Initial Catalog=master;Integrated Security=True;";

        /// <summary>
        /// 
        /// </summary>
        public VentanaIngredientes()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VentanaIngredientes_Load(object sender, EventArgs e)
        {
            listView_listaIngredientes.View = View.Details;

            listView_listaIngredientes.Columns.Add("Ingrediente");
            listView_listaIngredientes.Columns.Add("Calorías");

            listView_listaIngredientes.Columns[0].Width = 220;
            listView_listaIngredientes.Columns[1].Width = 80;

            HashSet<IngredienteCalorias> listaIngredientes = new HashSet<IngredienteCalorias>();
            IngredienteCalorias datosIngr;
            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string consultaIngredientes = "USE[InformacionNutricional]; SELECT Nombre, Calorias " +
                        "FROM Ingredientes ing " +
                        "JOIN ValoresNutricionalesIngredientes vni " +
                        "ON ing.ID = vni.IngredienteID " +
                        "ORDER BY Nombre ASC;";
                    using (SqlCommand comandoConsIngr = new SqlCommand(consultaIngredientes, conn))
                    {
                        SqlDataReader lectorIngredientes = comandoConsIngr.ExecuteReader();
                        while (lectorIngredientes.Read())
                        {
                            datosIngr = new IngredienteCalorias();
                            datosIngr.nombre = lectorIngredientes.GetString(0);
                            datosIngr.calorias = (double)lectorIngredientes.GetDecimal(1);

                            listaIngredientes.Add(datosIngr);

                            ListViewItem item = new ListViewItem(new[] { lectorIngredientes.GetString(0), lectorIngredientes.GetDecimal(1).ToString() });
                            listView_listaIngredientes.Items.Add(item);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Anadir_Click(object sender, EventArgs e)
        {
            VentanaIngredientesAnadir vtaAnadirIngr = new VentanaIngredientesAnadir();
            this.Hide();
            vtaAnadirIngr.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Modificar_Click(object sender, EventArgs e)
        {
            VentanaIngredientesModificar vtaIngrMod = new VentanaIngredientesModificar();
            this.Hide();
            vtaIngrMod.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Eliminar_Click(object sender, EventArgs e)
        {
            EliminarIngrediente();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Volver_Click(object sender, EventArgs e)
        {
            VentanaPrincipal vtaMenu = new VentanaPrincipal();
            this.Hide();
            vtaMenu.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        private void EliminarIngrediente()
        {
            foreach (ListViewItem itemSeleccionado in listView_listaIngredientes.SelectedItems)
            {
                string nombreIngrediente = itemSeleccionado.SubItems[0].Text;
                int idIngrediente = ConsultaIDIngrediente(nombreIngrediente);
                Console.WriteLine(nombreIngrediente);

                try
                {
                    using (SqlConnection conn = new SqlConnection(cadenaConexion))
                    {
                        conn.Open();
                        string borrarIngredienteTabVNI = "USE[InformacionNutricional]; " +
                                                         "DELETE FROM ValoresNutricionalesIngredientes " +
                                                         "WHERE IngredienteID = @idIngr";
                        SqlCommand comandoBorrarTabVNI = new SqlCommand(borrarIngredienteTabVNI, conn);
                        comandoBorrarTabVNI.Parameters.AddWithValue("@idIngr", idIngrediente);
                        comandoBorrarTabVNI.ExecuteNonQuery();

                        string borrarIngredienteTabIngredientes = "DELETE FROM Ingredientes " +
                                                                  "WHERE Nombre = @nombre";
                        SqlCommand comandoBorrarTabIngr = new SqlCommand(borrarIngredienteTabIngredientes, conn);
                        comandoBorrarTabIngr.Parameters.AddWithValue("@nombre", nombreIngrediente);
                        comandoBorrarTabIngr.ExecuteNonQuery();
                    }

                    MessageBox.Show("Has borrado el ingrediente que querías", "Operación realizada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException sqlEX)
                {
                    Console.WriteLine(sqlEX.Message);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreIngrediente"></param>
        /// <returns></returns>
        private int ConsultaIDIngrediente(string nombreIngrediente)
        {
            int idIngrediente = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string consultaIDIngrediente = "USE[InformacionNutricional]; " +
                                                   "SELECT ID " +
                                                   "FROM INGREDIENTES " +
                                                   "WHERE Nombre = @ingrediente;";
                    SqlCommand comandoID = new SqlCommand(consultaIDIngrediente, conn);
                    comandoID.Parameters.AddWithValue("@ingrediente", nombreIngrediente);
                    SqlDataReader lectorID = comandoID.ExecuteReader();
                    while (lectorID.Read())
                    {
                        idIngrediente = lectorID.GetInt32(0);
                    }
                    lectorID.Close();
                }
            }
            catch (SqlException sqlEX)
            {
                Console.WriteLine(sqlEX.Message + " VentanaIngrediente/ConsultaIDIngrediente");
            }

            return idIngrediente;
        }

    }
}
