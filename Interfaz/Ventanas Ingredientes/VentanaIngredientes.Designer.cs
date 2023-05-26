
namespace TFC_Benjamin
{
    partial class VentanaIngredientes
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
            this.listView_listaIngredientes = new System.Windows.Forms.ListView();
            this.button_Anadir = new System.Windows.Forms.Button();
            this.button_Modificar = new System.Windows.Forms.Button();
            this.button_Eliminar = new System.Windows.Forms.Button();
            this.button_Volver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView_listaIngredientes
            // 
            this.listView_listaIngredientes.HideSelection = false;
            this.listView_listaIngredientes.Location = new System.Drawing.Point(38, 43);
            this.listView_listaIngredientes.Name = "listView_listaIngredientes";
            this.listView_listaIngredientes.Size = new System.Drawing.Size(322, 393);
            this.listView_listaIngredientes.TabIndex = 12;
            this.listView_listaIngredientes.UseCompatibleStateImageBehavior = false;
            // 
            // button_Anadir
            // 
            this.button_Anadir.Location = new System.Drawing.Point(512, 43);
            this.button_Anadir.Name = "button_Anadir";
            this.button_Anadir.Size = new System.Drawing.Size(118, 45);
            this.button_Anadir.TabIndex = 13;
            this.button_Anadir.Text = "Añadir ingrediente";
            this.button_Anadir.UseVisualStyleBackColor = true;
            this.button_Anadir.Click += new System.EventHandler(this.button_Anadir_Click);
            // 
            // button_Modificar
            // 
            this.button_Modificar.Location = new System.Drawing.Point(512, 152);
            this.button_Modificar.Name = "button_Modificar";
            this.button_Modificar.Size = new System.Drawing.Size(118, 45);
            this.button_Modificar.TabIndex = 14;
            this.button_Modificar.Text = "Modificar datos del ingrediente";
            this.button_Modificar.UseVisualStyleBackColor = true;
            this.button_Modificar.Click += new System.EventHandler(this.button_Modificar_Click);
            // 
            // button_Eliminar
            // 
            this.button_Eliminar.Location = new System.Drawing.Point(512, 265);
            this.button_Eliminar.Name = "button_Eliminar";
            this.button_Eliminar.Size = new System.Drawing.Size(118, 45);
            this.button_Eliminar.TabIndex = 15;
            this.button_Eliminar.Text = "Eliminar ingrediente";
            this.button_Eliminar.UseVisualStyleBackColor = true;
            this.button_Eliminar.Click += new System.EventHandler(this.button_Eliminar_Click);
            // 
            // button_Volver
            // 
            this.button_Volver.Location = new System.Drawing.Point(512, 391);
            this.button_Volver.Name = "button_Volver";
            this.button_Volver.Size = new System.Drawing.Size(118, 45);
            this.button_Volver.TabIndex = 16;
            this.button_Volver.Text = "Volver";
            this.button_Volver.UseVisualStyleBackColor = true;
            this.button_Volver.Click += new System.EventHandler(this.button_Volver_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 453);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 7);
            this.label1.TabIndex = 17;
            this.label1.Text = "*Las calorías corresponden a porciones de 100 grs";
            // 
            // VentanaIngredientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 496);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Volver);
            this.Controls.Add(this.button_Eliminar);
            this.Controls.Add(this.button_Modificar);
            this.Controls.Add(this.button_Anadir);
            this.Controls.Add(this.listView_listaIngredientes);
            this.Name = "VentanaIngredientes";
            this.Text = "Ingredientes";
            this.Load += new System.EventHandler(this.VentanaIngredientes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_listaIngredientes;
        private System.Windows.Forms.Button button_Anadir;
        private System.Windows.Forms.Button button_Modificar;
        private System.Windows.Forms.Button button_Eliminar;
        private System.Windows.Forms.Button button_Volver;
        private System.Windows.Forms.Label label1;
    }
}