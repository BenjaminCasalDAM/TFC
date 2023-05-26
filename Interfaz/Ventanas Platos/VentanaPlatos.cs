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
    public partial class VentanaPlatos : Form
    {
        string cadenaConexion = "Data Source=.\\sqlexpress;Initial Catalog=master;Integrated Security=True;";
        bool cantidadValida = false;

        public VentanaPlatos()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Carga la configuración de las columnas del ListView que contiene la lista de todos los ingredientes
        /// Carga la lista de todos los ingredientes  en el ListView a partir de las tablas correspondientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VentanaPlatos_Load(object sender, EventArgs e)
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
        /// Devuelve las calorias totales de un plato y un diccionario que contiene cada ingrediente y la cantidad del mismo que se va a usar
        /// El usuario introduce el ingrediente y la cantidad para hacer el calculo de las calorias
        /// EL calculo se lleva a cabo en el metodo CaloriasPorIngrediente
        /// </summary>
        /// <returns>calorias, listaIngredientes</returns>
        private (decimal, Dictionary<string, decimal>) CalcularCalorias()
        {
            decimal calorias = 0;
            Dictionary<string, decimal> listaIngredientes = new Dictionary<string, decimal>();

            foreach (DataGridViewRow fila in dataGridView_ingredientesDefinitivos.Rows)
            {
                if (!fila.IsNewRow)
                {
                    DataGridViewCell valorIngrediente = fila.Cells[0];
                    DataGridViewCell valorCantidad = fila.Cells[1];
                    string ingrediente = valorIngrediente.Value.ToString();
                    decimal cantidad = 0;

                    try
                    {
                        cantidad = decimal.Parse(valorCantidad.Value.ToString());
                    }
                    catch (FormatException feEX)
                    {
                        Console.WriteLine(feEX.Message + " Tienes que introducir un número en la columna Cantidades");
                    }
                    
                    listaIngredientes.Add(ingrediente, cantidad);

                    if (valorCantidad.Value != null && decimal.TryParse(valorCantidad.Value.ToString(), out decimal kcalIngrediente))
                    {
                        kcalIngrediente = CaloriasPorIngrediente(ingrediente, cantidad);
                        calorias += kcalIngrediente;
                        cantidadValida = true;

                    }else if (valorCantidad == null)
                    {
                        MessageBox.Show("Tienes que introducir una cantidad para cada ingrediente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }else if (!decimal.TryParse(valorCantidad.Value.ToString(), out decimal kcalNoValido))
                    {
                        MessageBox.Show("Tienes que introducir una cantidad para cada ingrediente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return (Math.Round(calorias, 2), listaIngredientes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingrediente"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        private decimal CaloriasPorIngrediente(string ingrediente, decimal cantidad)
        {
            decimal caloriasIngrediente = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string consulta = "USE[InformacionNutricional]; " +
                                      "SELECT calorias " +
                                      "FROM ValoresNutricionalesIngredientes vni " +
                                      "JOIN Ingredientes ingr " +
                                      "ON vni.IngredienteID = ingr.ID " +
                                      "WHERE Nombre = @ingrediente;";
                    SqlCommand comandoCalorias = new SqlCommand(consulta, conn);
                    comandoCalorias.Parameters.AddWithValue("@ingrediente", ingrediente);

                    SqlDataReader lector = comandoCalorias.ExecuteReader();
                    while (lector.Read())
                    {
                        decimal calorias100gr = lector.GetDecimal(0);
                        caloriasIngrediente = (calorias100gr * cantidad) / 100;
                    }
                    lector.Close();
                }
            }
            catch (SqlException sqlEX)
            {
                Console.WriteLine(sqlEX.Message);
            }
            return caloriasIngrediente;
        }

        /// <summary>
        /// Crea el objeto Plato a partir de los datos obtenidos de los diferentes controles de la ventana
        /// </summary>
        /// <returns>nuevoPlato</returns>
        public void CrearPlato()
        {
            bool nombrePlato = false;
            Plato nuevoPlato = new Plato();
            if (!string.IsNullOrWhiteSpace(textBox_introPlato.Text))
            {
                nombrePlato = true;
            }
            nuevoPlato.nombre = textBox_introPlato.Text;
            nuevoPlato.descripcion = richTextBox_comentarioPlato.Text;
            (decimal calorias, Dictionary<string, decimal> listaIngredientes) = CalcularCalorias();
            nuevoPlato.ingredientes = listaIngredientes;

            try
            {
                if (nombrePlato == true)
                {
                    using (SqlConnection conn = new SqlConnection(cadenaConexion))
                    {
                        conn.Open();
                        string llenarPlatos = "USE [InformacionNutricional]; INSERT INTO Platos (Nombre, Descripcion, CaloriasPlato) VALUES (@nombre, @desc, @kcal);";
                        SqlCommand comandoLlenarPlatos = new SqlCommand(llenarPlatos, conn);
                        comandoLlenarPlatos.Parameters.AddWithValue("@nombre", nuevoPlato.nombre);
                        comandoLlenarPlatos.Parameters.AddWithValue("@desc", nuevoPlato.descripcion);
                        comandoLlenarPlatos.Parameters.AddWithValue("@kcal", calorias);

                        if (cantidadValida == true)
                        {
                            comandoLlenarPlatos.ExecuteNonQuery();
                        }

                        string llenarIngredientesPorPlato = "INSERT INTO IngredientesPorPlato (IngredienteID, NombrePlato, Cantidad) " +
                                                            "SELECT ID, @plato, @cantidad " +
                                                            "FROM Ingredientes " +
                                                            "WHERE Nombre = @ingrediente ";
                        foreach (KeyValuePair<string, decimal> ingrediente in nuevoPlato.ingredientes)
                        {
                            SqlCommand comandoIngredientesPlato = new SqlCommand(llenarIngredientesPorPlato, conn);
                            comandoIngredientesPlato.Parameters.AddWithValue("@plato", nuevoPlato.nombre);
                            comandoIngredientesPlato.Parameters.AddWithValue("@ingrediente", ingrediente.Key);
                            comandoIngredientesPlato.Parameters.AddWithValue("@cantidad", ingrediente.Value);

                            if (cantidadValida == true)
                            {
                                comandoIngredientesPlato.ExecuteNonQuery();
                            }


                        }
                    }

                    MessageBox.Show("Acabas de crear un plato!", "Operación realizado con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No puedes dejar vacío el nombre del plato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (SqlException sqlEX)
            {
                Console.WriteLine(sqlEX.Message);
            }

        }

        /// <summary>
        /// Envía los ingredientes seleccionados al DataGridView que muestra los ingredientes que componen el plato en cuestión
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_listaIngredientes_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            foreach (ListViewItem ingrediente in listView_listaIngredientes.SelectedItems)
            {
                string nombre = ingrediente.SubItems[0].Text;
                Console.WriteLine(nombre);
                DataGridViewRow linea = new DataGridViewRow();

                DataGridViewTextBoxCell ingredienteCell = new DataGridViewTextBoxCell();
                ingredienteCell.Value = nombre;
                DataGridViewTextBoxCell cantidadCell = new DataGridViewTextBoxCell();
                cantidadCell.Value = "";

                linea.Cells.Add(ingredienteCell);
                linea.Cells.Add(cantidadCell);

                dataGridView_ingredientesDefinitivos.Rows.Add(linea);
            }
        }

        /// <summary>
        /// Elimina los ingredientes seleccionados de la lista definitiva de ingredientes que componen un plato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Quitar_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> filasParaEliminar = new List<DataGridViewRow>();
            try
            {
                foreach (DataGridViewRow fila in dataGridView_ingredientesDefinitivos.SelectedRows)
                {
                    filasParaEliminar.Add(fila);
                }

                foreach (DataGridViewRow filaEliminar in filasParaEliminar)
                {
                    dataGridView_ingredientesDefinitivos.Rows.Remove(filaEliminar);
                }
            }
            catch (InvalidOperationException ioEX)
            {
                Console.WriteLine(ioEX.Message);
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_guardarPlato_Click(object sender, EventArgs e)
        {
            CrearPlato();
        }

        /// <summary>
        /// Boton que cierra esta ventana y vuelve a la principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Volver_Click(object sender, EventArgs e)
        {
            VentanaPrincipal vtaMain = new VentanaPrincipal();
            this.Hide();
            vtaMain.ShowDialog();
            this.Close();
        }

        private void button_listadoPlatos_Click(object sender, EventArgs e)
        {
            VentanaPlatosListado vtaPlatosList = new VentanaPlatosListado();
            this.Hide();
            vtaPlatosList.ShowDialog();
            this.Close();
        }

    }
}
