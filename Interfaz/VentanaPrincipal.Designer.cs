
namespace TFC_Benjamin
{
    partial class VentanaPrincipal
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
            this.button_Platos = new System.Windows.Forms.Button();
            this.button_Seguimiento = new System.Windows.Forms.Button();
            this.button_Ingredientes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Platos
            // 
            this.button_Platos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Platos.Location = new System.Drawing.Point(77, 61);
            this.button_Platos.Name = "button_Platos";
            this.button_Platos.Size = new System.Drawing.Size(207, 86);
            this.button_Platos.TabIndex = 0;
            this.button_Platos.Text = "Platos";
            this.button_Platos.UseVisualStyleBackColor = true;
            this.button_Platos.Click += new System.EventHandler(this.button_Platos_Click);
            // 
            // button_Seguimiento
            // 
            this.button_Seguimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Seguimiento.Location = new System.Drawing.Point(84, 263);
            this.button_Seguimiento.Name = "button_Seguimiento";
            this.button_Seguimiento.Size = new System.Drawing.Size(207, 86);
            this.button_Seguimiento.TabIndex = 2;
            this.button_Seguimiento.Text = "Seguimiento";
            this.button_Seguimiento.UseVisualStyleBackColor = true;
            this.button_Seguimiento.Click += new System.EventHandler(this.button_Seguimiento_Click);
            // 
            // button_Ingredientes
            // 
            this.button_Ingredientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Ingredientes.Location = new System.Drawing.Point(473, 61);
            this.button_Ingredientes.Name = "button_Ingredientes";
            this.button_Ingredientes.Size = new System.Drawing.Size(207, 86);
            this.button_Ingredientes.TabIndex = 3;
            this.button_Ingredientes.Text = "Ingredientes";
            this.button_Ingredientes.UseVisualStyleBackColor = true;
            this.button_Ingredientes.Click += new System.EventHandler(this.button_Ingredientes_Click);
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_Ingredientes);
            this.Controls.Add(this.button_Seguimiento);
            this.Controls.Add(this.button_Platos);
            this.Name = "VentanaPrincipal";
            this.Text = "VentanaPrincipal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Platos;
        private System.Windows.Forms.Button button_Seguimiento;
        private System.Windows.Forms.Button button_Ingredientes;
    }
}