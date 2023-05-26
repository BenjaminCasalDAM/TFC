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
    /// Clase que permite al usuario registrar un nuevo ingrediente
    /// </summary>
    public partial class VentanaIngredientesAnadir : Form
    {
        string cadenaConexion = "Data Source=.\\sqlexpress;Initial Catalog=master;Integrated Security=True;";

        public VentanaIngredientesAnadir()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void VentanaIngredientesAnadir_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }
        private void button_Anadir_Click(object sender, EventArgs e)
        {
            string nombre = textBox_introNombre.Text;

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                RegistrosEnTablaIngredientes(nombre);
                RegistrosEnTablaVNI(nombre);
            }
            else
            {
                MessageBox.Show("Tienes que introducir un nombre", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void button_Volver_Click(object sender, EventArgs e)
        {
            VentanaIngredientes vtaIngr = new VentanaIngredientes();
            this.Hide();
            vtaIngr.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Carga el comboBox de Categorías con los datos de la tabla Categorías
        /// </summary>
        private void CargarCategorias()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string consultaCategorias = "USE[InformacionNutricional];" +
                                                "SELECT Nombre " +
                                                "FROM Categorias;";
                    SqlCommand comandoCategorias = new SqlCommand(consultaCategorias, conn);
                    SqlDataReader lectorCategorias = comandoCategorias.ExecuteReader();

                    while (lectorCategorias.Read())
                    {
                        comboBox_selecCategoria.Items.Add(lectorCategorias.GetString(0));
                    }
                    lectorCategorias.Close();
                }
            }
            catch (SqlException sqlEX)
            {
                Console.WriteLine(sqlEX.Message);
            }

        }

        /// <summary>
        /// Al guardar los datos de un ingrediente estos se dividen en dos tablas
        /// En este método se guardan los datos correspondientes a la tabla Ingredientes
        /// </summary>
        private void RegistrosEnTablaIngredientes(string nombre)
        {
            try
            {
                string categoria = comboBox_selecCategoria.SelectedItem?.ToString();
                string opcVegan = comboBox_Vegan.SelectedItem?.ToString();
                string opcVeget = comboBox_Vegetarian.SelectedItem?.ToString();
                string opcCeliac = comboBox_Celiac.SelectedItem?.ToString();
                string opcLactosa = comboBox_Lactosa.SelectedItem?.ToString();

                if (!string.IsNullOrWhiteSpace(categoria) && categoria != null)
                {

                    Console.WriteLine("CATEGORÍA (dentro if): " + categoria);

                    try
                    {
                        using (SqlConnection conn = new SqlConnection(cadenaConexion))
                        {
                            conn.Open();

                            string guardarTablaIngredientes = "USE[InformacionNutricional]; " +
                                                              "INSERT INTO Ingredientes(Nombre, Categoria, ParaVeganos, ParaVegetarianos, ParaCeliacos, ParaIntolerantesLactosa) " +
                                                              "VALUES(@nombre, @cat, @veganos, @vegetarianos, @celiacos, @lactosa);";
                            SqlCommand comandoTablaIngredientes = new SqlCommand(guardarTablaIngredientes, conn);
                            comandoTablaIngredientes.Parameters.AddWithValue("@nombre", nombre);
                            comandoTablaIngredientes.Parameters.AddWithValue("@cat", categoria);
                            comandoTablaIngredientes.Parameters.AddWithValue("@veganos", opcVegan);
                            comandoTablaIngredientes.Parameters.AddWithValue("@vegetarianos", opcVeget);
                            comandoTablaIngredientes.Parameters.AddWithValue("@celiacos", opcCeliac);
                            comandoTablaIngredientes.Parameters.AddWithValue("@lactosa", opcLactosa);

                            comandoTablaIngredientes.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException sqlEX)
                    {
                        Console.WriteLine(sqlEX.Message);
                    }
                }
                else
                {
                    Console.WriteLine("CATEGORÍA (fuera if): " + categoria);
                    MessageBox.Show("Tienes que elegir una categoría", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (NullReferenceException nullEX)
            {
                Console.WriteLine(nullEX.Message);
            }
        }

        /// <summary>
        /// En este método se guardan los datos correspondientes a la tabla ValoresNutricionalesIngredientes
        /// </summary>
        private void RegistrosEnTablaVNI(string nombre)
        {
            decimal calorias = decimal.Parse(textBox_introCalorias.Text);
            decimal proteinas = decimal.Parse(textBox_introProteinas.Text);
            decimal hidratos = decimal.Parse(textBox_introHidratos.Text);
            decimal grasas = decimal.Parse(textBox_introGrasas.Text);

            if (calorias != 0)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(cadenaConexion))
                    {
                        conn.Open();

                        string guardarValoresNutricionales = "USE[InformacionNutricional]; " +
                                                             "INSERT INTO ValoresNutricionalesIngredientes(IngredienteID, Calorias, ProteinasGrs, Carbohidratos, Grasas) " +
                                                             "SELECT ID, @kcal, @prot, @carbs, @fat " +
                                                             "FROM Ingredientes " +
                                                             "WHERE Nombre = @nombre;";
                        SqlCommand comandoValoresNut = new SqlCommand(guardarValoresNutricionales, conn);
                        comandoValoresNut.Parameters.AddWithValue("@kcal", calorias);
                        comandoValoresNut.Parameters.AddWithValue("@prot", proteinas);
                        comandoValoresNut.Parameters.AddWithValue("@carbs", hidratos);
                        comandoValoresNut.Parameters.AddWithValue("@fat", grasas);
                        comandoValoresNut.Parameters.AddWithValue("@nombre", nombre);

                        comandoValoresNut.ExecuteNonQuery();
                    }
                }
                catch (SqlException sqlEX)
                {
                    Console.WriteLine(sqlEX.Message);
                }
                MessageBox.Show("Has introducido un nuevo ingrediente!", "Operación realizada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InitializeComponent();
            }
            else
            {
                MessageBox.Show("Tienes que llenar todos los campos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

    }
}
