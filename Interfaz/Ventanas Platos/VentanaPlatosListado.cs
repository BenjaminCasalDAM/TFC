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
using Microsoft.VisualBasic;

namespace TFC_Benjamin
{
    public partial class VentanaPlatosListado : Form
    {
        string cadenaConexion = "Data Source=.\\sqlexpress;Initial Catalog=master;Integrated Security=True;";
        private string nombrePlatoSeleccionado;
        private string descripcionActual;

        public VentanaPlatosListado()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        /// <summary>
        /// Calcula los macronutrientes presentes en un plato a traves de la suma de los ingredientes
        /// </summary>
        /// <param name="plato"></param>
        /// <returns></returns>
        /// 
        private (decimal, decimal, decimal) ConsultaMacronutrientesPlato(string plato)
        {
            decimal proteinas = 0;
            decimal carbohidratos = 0;
            decimal grasas = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string consultaIngredientesPlato = "USE[InformacionNutricional] SELECT Cantidad, ProteinasGrs, Carbohidratos, Grasas " +
                                                       "FROM ValoresNutricionalesIngredientes vni " +
                                                       "JOIN Ingredientes ingr ON vni.IngredienteID = ingr.ID " +
                                                       "JOIN IngredientesPorPlato ipp ON vni.IngredienteID = ipp.IngredienteID " +
                                                       "JOIN Platos pl ON ipp.NombrePlato = pl.Nombre " +
                                                       "WHERE pl.Nombre = @plato;";
                    SqlCommand comandoIngredientesPlato = new SqlCommand(consultaIngredientesPlato, conn);
                    comandoIngredientesPlato.Parameters.AddWithValue("@plato",plato);

                    SqlDataReader lectorMacroN = comandoIngredientesPlato.ExecuteReader();
                    while (lectorMacroN.Read())
                    {
                        decimal cantidad = lectorMacroN.GetDecimal(0);
                        decimal proteinasPorIngrediente = lectorMacroN.GetDecimal(1);
                        decimal carbohidratosPorIngrediente = lectorMacroN.GetDecimal(2);
                        decimal grasasPorIngrediente = lectorMacroN.GetDecimal(3);

                        decimal proteinaPorcion = (cantidad * proteinasPorIngrediente/ 100);
                        decimal carbohidratosPorcion = (cantidad * carbohidratosPorIngrediente) / 100;
                        decimal grasasPorcion = (cantidad * grasasPorIngrediente) / 100;

                        proteinas += Math.Round(proteinaPorcion, 2);
                        carbohidratos += Math.Round(carbohidratosPorcion, 2);
                        grasas += Math.Round(grasasPorcion, 2);
                    }
                }
            }
            catch (SqlException sqlEX)
            {
                Console.WriteLine(sqlEX.Message);
            }
            return (proteinas, carbohidratos, grasas);
        }

        /// <summary>
        /// Genera filas en el DataGridView a partir de una consulta 
        /// Las filas contienen los datos de macronutrientes presentes en cada plato
        /// </summary>
        private void CargarListado()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();

                    string consultaPlatos = "USE[InformacionNutricional] SELECT Nombre, Descripcion, CaloriasPlato " +
                                            "FROM Platos;";
                    SqlCommand comandoConsultaPlatos = new SqlCommand(consultaPlatos, conn);
                    SqlDataReader lectorPlatos = comandoConsultaPlatos.ExecuteReader();

                    while (lectorPlatos.Read())
                    {
                        string plato = lectorPlatos.GetString(0);
                        string descripcion = lectorPlatos.GetString(1);
                        decimal calorias = lectorPlatos.GetDecimal(2);
                        (decimal proteinas, decimal carbohidratos, decimal grasas) = ConsultaMacronutrientesPlato(plato);

                        DataGridViewRow linea = new DataGridViewRow();

                        DataGridViewTextBoxCell platoCell = new DataGridViewTextBoxCell();
                        platoCell.Value = plato;

                        DataGridViewTextBoxCell comentarioCell = new DataGridViewTextBoxCell();
                        comentarioCell.Value = descripcion;

                        DataGridViewTextBoxCell caloriasCell = new DataGridViewTextBoxCell();
                        caloriasCell.Value = calorias;

                        DataGridViewTextBoxCell proteinasCell = new DataGridViewTextBoxCell();
                        proteinasCell.Value = proteinas;

                        DataGridViewTextBoxCell hidratosCell = new DataGridViewTextBoxCell();
                        hidratosCell.Value = carbohidratos;

                        DataGridViewTextBoxCell grasasCell = new DataGridViewTextBoxCell();
                        grasasCell.Value = grasas;

                        linea.Cells.Add(platoCell);
                        linea.Cells.Add(comentarioCell);
                        linea.Cells.Add(caloriasCell);
                        linea.Cells.Add(proteinasCell);
                        linea.Cells.Add(hidratosCell);
                        linea.Cells.Add(grasasCell);

                        dataGridView_listaPlatos.Rows.Add(linea);
                    }
                }
            }
            catch (SqlException sqlEX)
            {
                Console.WriteLine(sqlEX.Message);
            }
        }

        /// <summary>
        /// Carga los datos automaticos de la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VentanaPlatosListado_Load(object sender, EventArgs e)
        {
            CargarListado();
        }


        /// <summary>
        /// Controlador de evento para manejar la seleccion de filas del usuario en la lista de platos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_listaPlatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener los valores de la fila seleccionada
                nombrePlatoSeleccionado = dataGridView_listaPlatos.Rows[e.RowIndex].Cells["Plato"].Value.ToString();
                descripcionActual = dataGridView_listaPlatos.Rows[e.RowIndex].Cells["Comentarios"].Value.ToString();
            }
        }

        /// <summary>
        /// Ejecuta la modificacion en la tabla "Platos" 
        /// Recibe los parametros del metodo EjecutarModificaciones()
        /// </summary>
        /// <param name="nombrePlato"></param>
        /// <param name="nuevaDescripcion"></param>
        private void ActualizarDescripcionPlato(string nombrePlato, string nuevaDescripcion)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string consultaUpdate = "USE[InformacionNutricional]; " +
                                            "UPDATE Platos SET Descripcion = @descripcion WHERE Nombre = @nombre;";
                    SqlCommand comandoUpdate = new SqlCommand(consultaUpdate, conn);
                    comandoUpdate.Parameters.AddWithValue("@descripcion", nuevaDescripcion);
                    comandoUpdate.Parameters.AddWithValue("@nombre", nombrePlato);

                    int filasActualizadas = comandoUpdate.ExecuteNonQuery();

                    if (filasActualizadas > 0)
                    {
                        MessageBox.Show("La descripción del plato se ha actualizado correctamente.", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el plato en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException sqlEX)
            {
                Console.WriteLine(sqlEX.Message);
                MessageBox.Show("Se produjo un error al actualizar la descripción del plato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Elimina el plato seleccionado de todas las tablas en las que esta presente
        /// -Tabla FichaHorasConsumos
        /// -Tabla IngredientesPorPlato
        /// -Tabla Platos
        /// </summary>
        /// <param name="nombrePlatoSeleccionado"></param>
        private void EliminarPlato(string nombrePlatoSeleccionado)
        {
            try
            {
                using (SqlConnection conn  = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    bool platoExistenteEnFHC = false;

                    string consultaFHC = "USE[InformacionNutricional]; SELECT Plato " +
                                         "FROM FichaHorasConsumos " +
                                         "WHERE Plato = @plato";
                    SqlCommand comandoFHC = new SqlCommand(consultaFHC, conn);
                    comandoFHC.Parameters.AddWithValue("@plato", nombrePlatoSeleccionado);
                    SqlDataReader lectorFHC = comandoFHC.ExecuteReader();
                    while (lectorFHC.Read())
                    {
                        if (!string.IsNullOrWhiteSpace(lectorFHC.GetString(0)))
                        {
                            platoExistenteEnFHC = true;
                        }
                    }
                    lectorFHC.Close();

                    string eliminarPlatoIPP = "USE[InformacionNutricional]; " +
                                           "DELETE FROM IngredientesPorPlato WHERE NombrePlato = @plato";
                    SqlCommand comandoEliminarPlatoIPP = new SqlCommand(eliminarPlatoIPP, conn);
                    comandoEliminarPlatoIPP.Parameters.AddWithValue("@plato", nombrePlatoSeleccionado);

                    string eliminarPlatoPL = "USE[InformacionNutricional]; " +
                                             "DELETE FROM Platos WHERE Nombre = @plato";
                    SqlCommand comandoEliminarPlatoPL = new SqlCommand(eliminarPlatoPL, conn);
                    comandoEliminarPlatoPL.Parameters.AddWithValue("@plato", nombrePlatoSeleccionado);

                    if (platoExistenteEnFHC == true)
                    {
                        string eliminarPlatoFHC = "USE[InformacionNutricional]; " +
                                                  "DELETE FROM FichaHorasConsumos WHERE Plato = @plato";
                        SqlCommand comandoEliminarPlatoFHC = new SqlCommand(eliminarPlatoFHC, conn);
                        comandoEliminarPlatoFHC.Parameters.AddWithValue("@plato", nombrePlatoSeleccionado);

                        int filasActualizadasFHC = comandoEliminarPlatoFHC.ExecuteNonQuery();

                        if (filasActualizadasFHC > 0)
                        {
                            MessageBox.Show("El plato se ha eliminado correctamente.", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Console.Write("No se encontró el plato en la tabla FichaHorasConsumos.");
                            MessageBox.Show("No se encontró el plato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    int filasActualizadasIPP = comandoEliminarPlatoIPP.ExecuteNonQuery();
                    int filasActualizadasPL = comandoEliminarPlatoPL.ExecuteNonQuery();

                    if (filasActualizadasIPP > 0 && filasActualizadasPL > 0) 
                    {
                        MessageBox.Show("El plato se ha eliminado correctamente.", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (filasActualizadasIPP == 0)
                        {
                            Console.WriteLine("No se encontró el plato en la tabla IngredientesPorPlato.");
                            MessageBox.Show("No se encontró el plato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if(filasActualizadasPL == 0)
                        {
                            Console.WriteLine("No se encontró el plato en la tabla Platos.");
                            MessageBox.Show("No se encontró el plato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException sqlEX)
            {
                Console.WriteLine(sqlEX.Message);
            }

            dataGridView_listaPlatos.Rows.Clear();
            CargarListado();
        }

        /// <summary>
        /// Permite al usuario modificar la descripcion del plato que elija
        /// </summary>
        private void EjecutarModificaciones()
        {
            string nuevaDescripcion = Interaction.InputBox("Modificar descripción", "Ingrese la nueva descripción:", descripcionActual);

            if (!string.IsNullOrEmpty(nuevaDescripcion))
            {
                ActualizarDescripcionPlato(nombrePlatoSeleccionado, nuevaDescripcion);
            }

            dataGridView_listaPlatos.Rows.Clear();
            CargarListado();
        }

        /// <summary>
        /// Controlador de evento del boton "Modificar "para manejar la modificacion de una descripcion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Modificar_Click(object sender, EventArgs e)
        {
            EjecutarModificaciones();
        }

        private void button_Eliminar_Click(object sender, EventArgs e)
        {
            EliminarPlato(nombrePlatoSeleccionado);
        }

        private void button_Volver_Click(object sender, EventArgs e)
        {
            VentanaPlatos vtaPlatos = new VentanaPlatos();
            this.Hide();
            vtaPlatos.ShowDialog();
            this.Close();
        }
    }
}
