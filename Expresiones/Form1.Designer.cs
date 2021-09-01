
namespace Expresiones
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEntrada = new System.Windows.Forms.Label();
            this.tbExpresion = new System.Windows.Forms.TextBox();
            this.btnPruebas = new System.Windows.Forms.Button();
            this.lblPruebas = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEntrada
            // 
            this.lblEntrada.AutoSize = true;
            this.lblEntrada.Location = new System.Drawing.Point(22, 22);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(111, 13);
            this.lblEntrada.TabIndex = 0;
            this.lblEntrada.Text = "Ingresa una expresion";
            this.lblEntrada.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbExpresion
            // 
            this.tbExpresion.Location = new System.Drawing.Point(25, 55);
            this.tbExpresion.Name = "tbExpresion";
            this.tbExpresion.Size = new System.Drawing.Size(100, 20);
            this.tbExpresion.TabIndex = 1;
            // 
            // btnPruebas
            // 
            this.btnPruebas.Location = new System.Drawing.Point(439, 55);
            this.btnPruebas.Name = "btnPruebas";
            this.btnPruebas.Size = new System.Drawing.Size(75, 23);
            this.btnPruebas.TabIndex = 2;
            this.btnPruebas.Text = "button1";
            this.btnPruebas.UseVisualStyleBackColor = true;
            this.btnPruebas.Click += new System.EventHandler(this.btnPruebas_Click);
            // 
            // lblPruebas
            // 
            this.lblPruebas.AutoSize = true;
            this.lblPruebas.Location = new System.Drawing.Point(439, 22);
            this.lblPruebas.Name = "lblPruebas";
            this.lblPruebas.Size = new System.Drawing.Size(35, 13);
            this.lblPruebas.TabIndex = 3;
            this.lblPruebas.Text = "label1";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(145, 55);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblPruebas);
            this.Controls.Add(this.btnPruebas);
            this.Controls.Add(this.tbExpresion);
            this.Controls.Add(this.lblEntrada);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEntrada;
        private System.Windows.Forms.TextBox tbExpresion;
        private System.Windows.Forms.Button btnPruebas;
        private System.Windows.Forms.Label lblPruebas;
        private System.Windows.Forms.Button btnAceptar;
    }
}

