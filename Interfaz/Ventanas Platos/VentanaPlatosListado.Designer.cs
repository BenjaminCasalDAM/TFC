
namespace TFC_Benjamin
{
    partial class VentanaPlatosListado
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
            this.dataGridView_listaPlatos = new System.Windows.Forms.DataGridView();
            this.Plato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calorias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proteinas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hidratos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grasas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Volver = new System.Windows.Forms.Button();
            this.button_Eliminar = new System.Windows.Forms.Button();
            this.button_Modificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listaPlatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_listaPlatos
            // 
            this.dataGridView_listaPlatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_listaPlatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView_listaPlatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_listaPlatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Plato,
            this.Comentarios,
            this.Calorias,
            this.Proteinas,
            this.Hidratos,
            this.Grasas});
            this.dataGridView_listaPlatos.Location = new System.Drawing.Point(26, 35);
            this.dataGridView_listaPlatos.Name = "dataGridView_listaPlatos";
            this.dataGridView_listaPlatos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView_listaPlatos.Size = new System.Drawing.Size(939, 328);
            this.dataGridView_listaPlatos.TabIndex = 0;
            this.dataGridView_listaPlatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_listaPlatos_CellClick);
            // 
            // Plato
            // 
            this.Plato.HeaderText = "Platos";
            this.Plato.Name = "Plato";
            this.Plato.ReadOnly = true;
            this.Plato.Width = 200;
            // 
            // Comentarios
            // 
            this.Comentarios.HeaderText = "Descripción";
            this.Comentarios.Name = "Comentarios";
            this.Comentarios.Width = 300;
            // 
            // Calorias
            // 
            this.Calorias.HeaderText = "Calorias";
            this.Calorias.Name = "Calorias";
            this.Calorias.ReadOnly = true;
            // 
            // Proteinas
            // 
            this.Proteinas.HeaderText = "Proteinas";
            this.Proteinas.Name = "Proteinas";
            this.Proteinas.ReadOnly = true;
            // 
            // Hidratos
            // 
            this.Hidratos.HeaderText = "Carbohidratos";
            this.Hidratos.Name = "Hidratos";
            this.Hidratos.ReadOnly = true;
            // 
            // Grasas
            // 
            this.Grasas.HeaderText = "Grasas";
            this.Grasas.Name = "Grasas";
            this.Grasas.ReadOnly = true;
            // 
            // button_Volver
            // 
            this.button_Volver.Location = new System.Drawing.Point(890, 398);
            this.button_Volver.Name = "button_Volver";
            this.button_Volver.Size = new System.Drawing.Size(75, 23);
            this.button_Volver.TabIndex = 1;
            this.button_Volver.Text = "Volver";
            this.button_Volver.UseVisualStyleBackColor = true;
            this.button_Volver.Click += new System.EventHandler(this.button_Volver_Click);
            // 
            // button_Eliminar
            // 
            this.button_Eliminar.Location = new System.Drawing.Point(792, 398);
            this.button_Eliminar.Name = "button_Eliminar";
            this.button_Eliminar.Size = new System.Drawing.Size(75, 23);
            this.button_Eliminar.TabIndex = 2;
            this.button_Eliminar.Text = "Eliminar";
            this.button_Eliminar.UseVisualStyleBackColor = true;
            this.button_Eliminar.Click += new System.EventHandler(this.button_Eliminar_Click);
            // 
            // button_Modificar
            // 
            this.button_Modificar.Location = new System.Drawing.Point(632, 398);
            this.button_Modificar.Name = "button_Modificar";
            this.button_Modificar.Size = new System.Drawing.Size(131, 23);
            this.button_Modificar.TabIndex = 3;
            this.button_Modificar.Text = "Modificar Descripción";
            this.button_Modificar.UseVisualStyleBackColor = true;
            this.button_Modificar.Click += new System.EventHandler(this.button_Modificar_Click);
            // 
            // VentanaPlatosListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 450);
            this.Controls.Add(this.button_Modificar);
            this.Controls.Add(this.button_Eliminar);
            this.Controls.Add(this.button_Volver);
            this.Controls.Add(this.dataGridView_listaPlatos);
            this.Name = "VentanaPlatosListado";
            this.Text = "VentanaPlatosListado";
            this.Load += new System.EventHandler(this.VentanaPlatosListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listaPlatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_listaPlatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plato;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Calorias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proteinas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hidratos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grasas;
        private System.Windows.Forms.Button button_Volver;
        private System.Windows.Forms.Button button_Eliminar;
        private System.Windows.Forms.Button button_Modificar;
    }
}