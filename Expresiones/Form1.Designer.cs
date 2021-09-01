
namespace wfExpresionesArbolBinario
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
            this.lblExpresion = new System.Windows.Forms.Label();
            this.txbExpresion = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblExpresion
            // 
            this.lblExpresion.AutoSize = true;
            this.lblExpresion.Location = new System.Drawing.Point(32, 28);
            this.lblExpresion.Name = "lblExpresion";
            this.lblExpresion.Size = new System.Drawing.Size(103, 13);
            this.lblExpresion.TabIndex = 0;
            this.lblExpresion.Text = "Expresión a evaluar:";
            // 
            // txbExpresion
            // 
            this.txbExpresion.Location = new System.Drawing.Point(35, 60);
            this.txbExpresion.Name = "txbExpresion";
            this.txbExpresion.Size = new System.Drawing.Size(202, 20);
            this.txbExpresion.TabIndex = 1;
            this.txbExpresion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txbExpresion_KeyUp);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(253, 60);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
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
            this.Controls.Add(this.txbExpresion);
            this.Controls.Add(this.lblExpresion);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExpresion;
        private System.Windows.Forms.TextBox txbExpresion;
        private System.Windows.Forms.Button btnAceptar;
    }
}

