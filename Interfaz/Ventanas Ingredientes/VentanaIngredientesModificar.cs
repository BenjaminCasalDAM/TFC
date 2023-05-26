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
    public partial class VentanaIngredientesModificar : Form
    {
        string cadenaConexion = "Data Source=.\\sqlexpress;Initial Catalog=master;Integrated Security=True;";
        List<string> ingredientes = new List<string>();

        public VentanaIngredientesModificar()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {

                }
            }
            catch (SqlException sqlEX)
            {
                Console.WriteLine(sqlEX.Message);
            }
        }

        private void VentanaIngredientesModificar_Load(object sender, EventArgs e)
        {
            CargarListaIngredientes();
           
        }

        private void button_Modificar_Click(object sender, EventArgs e)
        {

        }

        private void button_Volver_Click(object sender, EventArgs e)
        {
            VentanaIngredientes vtaIngr = new VentanaIngredientes();
            this.Hide();
            vtaIngr.ShowDialog();
            this.Close();
        }

        private void CargarListaIngredientes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();

                    string consultaListaIngredientes = "USE[InformacionNutricional]; " +
                                                       "SELECT Nombre " +
                                                       "FROM Ingredientes " +
                                                       "ORDER BY Nombre asc;";
                    SqlCommand comandoListaIngredientes = new SqlCommand(consultaListaIngredientes, conn);
                    SqlDataReader lectorIngredientes = comandoListaIngredientes.ExecuteReader();
                    while (lectorIngredientes.Read())
                    {
                        ingredientes.Add(lectorIngredientes.GetString(0));
                    }
                    foreach (string item in ingredientes)
                    {
                        listBox_listaIngredientes.Items.Add(item);
                    }
                    lectorIngredientes.Close();
                }
            }
            catch (SqlException sqlEX)
            {
                Console.WriteLine(sqlEX.Message);
            }
        }

        private void textBox_introNombre_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBox_introNombre.Text.Substring(0, Math.Min(textBox_introNombre.Text.Length, 12));
            listBox_listaIngredientes.Items.Clear();

            foreach (string item in ingredientes)
            {
                if (item.StartsWith(filtro))
                {
                    listBox_listaIngredientes.Items.Add(item);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox_listaIngredientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ingredienteSeleccionado = listBox_listaIngredientes.SelectedItem?.ToString();
            CargarCategoriasYAptos();
            MostrarCategoriaYAptosIngrediente(ingredienteSeleccionado);
            CargarValoresNutricionales(ingredienteSeleccionado);
        }

        /// <summary>
        /// 
        /// </summary>
        private void CargarCategoriasYAptos()
        {
            comboBox_selecCategoria.Items.Clear();
            comboBox_Vegan.Items.Clear();
            comboBox_Vegetarian.Items.Clear();
            comboBox_Celiac.Items.Clear();
            comboBox_Lactosa.Items.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();

                    string cargarCategoria= "USE[InformacionNutricional]; " +
                                            "SELECT Nombre " +
                                            "FROM Categorias " +
                                            "ORDER BY Nombre asc;";
                    SqlCommand comandoCategoria = new SqlCommand(cargarCategoria, conn);
                    SqlDataReader lectorCategorias = comandoCategoria.ExecuteReader();

                    while (lectorCategorias.Read())
                    {
                        comboBox_selecCategoria.Items.Add(lectorCategorias.GetString(0));
                    }
                    lectorCategorias.Close();
                }
            }
            catch (SqlException sqlEX)
            {
                Console.WriteLine(sqlEX.Message + " VentanaIngredientesModificar/CargarCategorias");
            }

            List<string> listaOpciones = new List<string>();
            listaOpciones.Add("Sí");
            listaOpciones.Add("No");
            listaOpciones.Add("Consultar");

            foreach (string opcion in listaOpciones)
            {
                comboBox_Vegan.Items.Add(opcion);
                comboBox_Vegetarian.Items.Add(opcion);
                comboBox_Celiac.Items.Add(opcion);
                comboBox_Lactosa.Items.Add(opcion);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredienteSeleccionado"></param>
        private void MostrarCategoriaYAptosIngrediente(string ingredienteSeleccionado)
        {

            if (!string.IsNullOrWhiteSpace(ingredienteSeleccionado))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(cadenaConexion))
                    {
                        conn.Open();

                        string cargarCategoria = "USE[InformacionNutricional]; " +
                                                 "SELECT Categoria " +
                                                 "FROM Ingredientes " +
                                                 "WHERE Nombre = @ingrediente";
                        SqlCommand comandoCategoria = new SqlCommand(cargarCategoria, conn);
                        comandoCategoria.Parameters.AddWithValue("@ingrediente", ingredienteSeleccionado);
                        object resultadoCategoria = comandoCategoria.ExecuteScalar();

                        if (resultadoCategoria != null)
                        {
                            string categoriaSeleccionada = resultadoCategoria.ToString();
                            comboBox_selecCategoria.SelectedItem = categoriaSeleccionada;
                        }

                        string cargarVeganos = "USE[InformacionNutricional]; " +
                                               "SELECT ParaVeganos " +
                                               "FROM Ingredientes " +
                                               "WHERE Nombre = @ingrediente";
                        SqlCommand comandoVeganos = new SqlCommand(cargarVeganos, conn);
                        comandoVeganos.Parameters.AddWithValue("@ingrediente", ingredienteSeleccionado);
                        object resultadoVeganos = comandoVeganos.ExecuteScalar();

                        if (resultadoVeganos != null)
                        {
                            string resultadoAsociado = resultadoVeganos.ToString();
                            comboBox_Vegan.SelectedItem = resultadoAsociado;
                        }

                        string cargarVegetarianos = "USE[InformacionNutricional]; " +
                                                    "SELECT ParaVegetarianos " +
                                                    "FROM Ingredientes " +
                                                    "WHERE Nombre = @ingrediente";
                        SqlCommand comandoVegetarianos = new SqlCommand(cargarVegetarianos, conn);
                        comandoVegetarianos.Parameters.AddWithValue("@ingrediente", ingredienteSeleccionado);
                        object resultadoVegetarianos = comandoVegetarianos.ExecuteScalar();

                        if (resultadoVegetarianos != null)
                        {
                            string resultadoAsociado = resultadoVegetarianos.ToString();
                            comboBox_Vegetarian.SelectedItem = resultadoAsociado;
                        }

                        string cargarCelíacos = "USE[InformacionNutricional]; " +
                                                "SELECT ParaCeliacos " +
                                                "FROM Ingredientes " +
                                                "WHERE Nombre = @ingrediente";
                        SqlCommand comandoCeliacos = new SqlCommand(cargarCelíacos, conn);
                        comandoCeliacos.Parameters.AddWithValue("@ingrediente", ingredienteSeleccionado);
                        object resultadoCeliacos = comandoCeliacos.ExecuteScalar();

                        if (resultadoCeliacos != null)
                        {
                            string resultadoAsociado = resultadoCeliacos.ToString();
                            comboBox_Celiac.SelectedItem = resultadoAsociado;
                        }

                        string cargarLactosa = "USE[InformacionNutricional]; " +
                                                "SELECT ParaIntolerantesLactosa " +
                                                "FROM Ingredientes " +
                                                "WHERE Nombre = @ingrediente";
                        SqlCommand comandoLactosa = new SqlCommand(cargarLactosa, conn);
                        comandoLactosa.Parameters.AddWithValue("@ingrediente", ingredienteSeleccionado);
                        object resultadoLactosa = comandoLactosa.ExecuteScalar();

                        if (resultadoLactosa != null)
                        {
                            string resultadoAsociado = resultadoLactosa.ToString();
                            comboBox_Lactosa.SelectedItem = resultadoAsociado;
                        }
                    }
                }
                catch (SqlException sqlEX)
                {
                    Console.WriteLine(sqlEX.Message + " VentanaIngredientesModificar/MostrarCategoriaSeleccionada");
                }
            }
        }

        private void CargarValoresNutricionales(string ingredienteSeleccionado)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();

                    string cargarValores = "USE[InformacionNutricional]; " +
                                           "SELECT Calorias, ProteinasGrs, Carbohidratos, Grasas " +
                                           "FROM ValoresNutricionalesIngredientes vni " +
                                           "JOIN Ingredientes ingr ON vni.IngredienteID = ingr.ID " +
                                           "WHERE ingr.Nombre = @ingrediente";
                    SqlCommand comandoVNI = new SqlCommand(cargarValores, conn);
                    comandoVNI.Parameters.AddWithValue("@ingrediente", ingredienteSeleccionado);
                    SqlDataReader lectorVNI = comandoVNI.ExecuteReader();

                    while (lectorVNI.Read())
                    {
                        textBox_introCalorias.Text = lectorVNI.GetDecimal(0).ToString();
                        textBox_introProteinas.Text = lectorVNI.GetDecimal(1).ToString();
                        textBox_introHidratos.Text = lectorVNI.GetDecimal(2).ToString(); ;
                        textBox_introGrasas.Text = lectorVNI.GetDecimal(3).ToString();
                    }
                }
            }
            catch (SqlException sqlEX)
            {
                Console.WriteLine(sqlEX.Message);
            }
        }

    }
}
