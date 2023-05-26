
namespace TFC_Benjamin
{
    partial class VentanaPlatos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_nombrePlato = new System.Windows.Forms.Label();
            this.textBox_introPlato = new System.Windows.Forms.TextBox();
            this.richTextBox_comentarioPlato = new System.Windows.Forms.RichTextBox();
            this.label_comentPlato = new System.Windows.Forms.Label();
            this.label_listaIngredientes = new System.Windows.Forms.Label();
            this.button_Volver = new System.Windows.Forms.Button();
            this.button_Quitar = new System.Windows.Forms.Button();
            this.button_listadoPlatos = new System.Windows.Forms.Button();
            this.listView_listaIngredientes = new System.Windows.Forms.ListView();
            this.dataGridView_ingredientesDefinitivos = new System.Windows.Forms.DataGridView();
            this.Ingredientes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_guardarPlato = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ingredientesDefinitivos)).BeginInit();
            this.SuspendLayout();
            // 
            // label_nombrePlato
            // 
            this.label_nombrePlato.AutoSize = true;
            this.label_nombrePlato.Location = new System.Drawing.Point(48, 42);
            this.label_nombrePlato.Name = "label_nombrePlato";
            this.label_nombrePlato.Size = new System.Drawing.Size(85, 13);
            this.label_nombrePlato.TabIndex = 0;
            this.label_nombrePlato.Text = "Nombra tu plato:";
            // 
            // textBox_introPlato
            // 
            this.textBox_introPlato.Location = new System.Drawing.Point(51, 71);
            this.textBox_introPlato.Name = "textBox_introPlato";
            this.textBox_introPlato.Size = new System.Drawing.Size(366, 20);
            this.textBox_introPlato.TabIndex = 1;
            // 
            // richTextBox_comentarioPlato
            // 
            this.richTextBox_comentarioPlato.Location = new System.Drawing.Point(51, 141);
            this.richTextBox_comentarioPlato.Name = "richTextBox_comentarioPlato";
            this.richTextBox_comentarioPlato.Size = new System.Drawing.Size(366, 109);
            this.richTextBox_comentarioPlato.TabIndex = 2;
            this.richTextBox_comentarioPlato.Text = "";
            // 
            // label_comentPlato
            // 
            this.label_comentPlato.AutoSize = true;
            this.label_comentPlato.Location = new System.Drawing.Point(48, 114);
            this.label_comentPlato.Name = "label_comentPlato";
            this.label_comentPlato.Size = new System.Drawing.Size(100, 13);
            this.label_comentPlato.TabIndex = 3;
            this.label_comentPlato.Text = "¿Algo que apuntar?";
            // 
            // label_listaIngredientes
            // 
            this.label_listaIngredientes.AutoSize = true;
            this.label_listaIngredientes.Location = new System.Drawing.Point(544, 42);
            this.label_listaIngredientes.Name = "label_listaIngredientes";
            this.label_listaIngredientes.Size = new System.Drawing.Size(66, 13);
            this.label_listaIngredientes.TabIndex = 5;
            this.label_listaIngredientes.Text = "Ponle sabor:";
            // 
            // button_Volver
            // 
            this.button_Volver.Location = new System.Drawing.Point(806, 519);
            this.button_Volver.Name = "button_Volver";
            this.button_Volver.Size = new System.Drawing.Size(81, 37);
            this.button_Volver.TabIndex = 7;
            this.button_Volver.Text = "Menú";
            this.button_Volver.UseVisualStyleBackColor = true;
            this.button_Volver.Click += new System.EventHandler(this.button_Volver_Click);
            // 
            // button_Quitar
            // 
            this.button_Quitar.Location = new System.Drawing.Point(447, 285);
            this.button_Quitar.Name = "button_Quitar";
            this.button_Quitar.Size = new System.Drawing.Size(75, 23);
            this.button_Quitar.TabIndex = 9;
            this.button_Quitar.Text = "Quitar";
            this.button_Quitar.UseVisualStyleBackColor = true;
            this.button_Quitar.Click += new System.EventHandler(this.button_Quitar_Click);
            // 
            // button_listadoPlatos
            // 
            this.button_listadoPlatos.Location = new System.Drawing.Point(662, 519);
            this.button_listadoPlatos.Name = "button_listadoPlatos";
            this.button_listadoPlatos.Size = new System.Drawing.Size(117, 37);
            this.button_listadoPlatos.TabIndex = 10;
            this.button_listadoPlatos.Text = "Lista de todos tus platos";
            this.button_listadoPlatos.UseVisualStyleBackColor = true;
            this.button_listadoPlatos.Click += new System.EventHandler(this.button_listadoPlatos_Click);
            // 
            // listView_listaIngredientes
            // 
            this.listView_listaIngredientes.HideSelection = false;
            this.listView_listaIngredientes.Location = new System.Drawing.Point(547, 71);
            this.listView_listaIngredientes.Name = "listView_listaIngredientes";
            this.listView_listaIngredientes.Size = new System.Drawing.Size(340, 393);
            this.listView_listaIngredientes.TabIndex = 11;
            this.listView_listaIngredientes.UseCompatibleStateImageBehavior = false;
            this.listView_listaIngredientes.SelectedIndexChanged += new System.EventHandler(this.listView_listaIngredientes_SelectedIndexChanged_1);
            // 
            // dataGridView_ingredientesDefinitivos
            // 
            this.dataGridView_ingredientesDefinitivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ingredientesDefinitivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ingredientes,
            this.Cantidades});
            this.dataGridView_ingredientesDefinitivos.Location = new System.Drawing.Point(51, 285);
            this.dataGridView_ingredientesDefinitivos.Name = "dataGridView_ingredientesDefinitivos";
            this.dataGridView_ingredientesDefinitivos.Size = new System.Drawing.Size(366, 179);
            this.dataGridView_ingredientesDefinitivos.TabIndex = 12;
            // 
            // Ingredientes
            // 
            this.Ingredientes.HeaderText = "Ingredientes";
            this.Ingredientes.Name = "Ingredientes";
            this.Ingredientes.ReadOnly = true;
            this.Ingredientes.Width = 220;
            // 
            // Cantidades
            // 
            this.Cantidades.HeaderText = "Cantidades (introducir en gramos)";
            this.Cantidades.Name = "Cantidades";
            this.Cantidades.Width = 107;
            // 
            // button_guardarPlato
            // 
            this.button_guardarPlato.Location = new System.Drawing.Point(547, 519);
            this.button_guardarPlato.Name = "button_guardarPlato";
            this.button_guardarPlato.Size = new System.Drawing.Size(85, 37);
            this.button_guardarPlato.TabIndex = 13;
            this.button_guardarPlato.Text = "Guardar plato";
            this.button_guardarPlato.UseVisualStyleBackColor = true;
            this.button_guardarPlato.Click += new System.EventHandler(this.button_guardarPlato_Click);
            // 
            // VentanaPlatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 577);
            this.Controls.Add(this.button_guardarPlato);
            this.Controls.Add(this.dataGridView_ingredientesDefinitivos);
            this.Controls.Add(this.listView_listaIngredientes);
            this.Controls.Add(this.button_listadoPlatos);
            this.Controls.Add(this.button_Quitar);
            this.Controls.Add(this.button_Volver);
            this.Controls.Add(this.label_listaIngredientes);
            this.Controls.Add(this.label_comentPlato);
            this.Controls.Add(this.richTextBox_comentarioPlato);
            this.Controls.Add(this.textBox_introPlato);
            this.Controls.Add(this.label_nombrePlato);
            this.Name = "VentanaPlatos";
            this.Text = "VentanaPlatos";
            this.Load += new System.EventHandler(this.VentanaPlatos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ingredientesDefinitivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_nombrePlato;
        private System.Windows.Forms.TextBox textBox_introPlato;
        private System.Windows.Forms.RichTextBox richTextBox_comentarioPlato;
        private System.Windows.Forms.Label label_comentPlato;
        private System.Windows.Forms.Label label_listaIngredientes;
        private System.Windows.Forms.Button button_Volver;
        private System.Windows.Forms.Button button_Quitar;
        private System.Windows.Forms.Button button_listadoPlatos;
        private System.Windows.Forms.ListView listView_listaIngredientes;
        private System.Windows.Forms.DataGridView dataGridView_ingredientesDefinitivos;
        private System.Windows.Forms.Button button_guardarPlato;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingredientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidades;
    }
}