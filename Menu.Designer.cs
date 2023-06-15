namespace DeptosEmpleados
{
    partial class Menu
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
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnDepartamentos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.Image = global::DeptosEmpleados.Properties.Resources.empleados;
            this.btnEmpleados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpleados.Location = new System.Drawing.Point(468, 45);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(376, 206);
            this.btnEmpleados.TabIndex = 1;
            this.btnEmpleados.Text = "Empleados";
            this.btnEmpleados.UseVisualStyleBackColor = true;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // btnDepartamentos
            // 
            this.btnDepartamentos.Image = global::DeptosEmpleados.Properties.Resources.departamento;
            this.btnDepartamentos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepartamentos.Location = new System.Drawing.Point(35, 45);
            this.btnDepartamentos.Name = "btnDepartamentos";
            this.btnDepartamentos.Size = new System.Drawing.Size(376, 206);
            this.btnDepartamentos.TabIndex = 0;
            this.btnDepartamentos.Text = "Departamentos";
            this.btnDepartamentos.UseVisualStyleBackColor = true;
            this.btnDepartamentos.Click += new System.EventHandler(this.btnDepartamentos_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 340);
            this.Controls.Add(this.btnEmpleados);
            this.Controls.Add(this.btnDepartamentos);
            this.Name = "Menu";
            this.Text = "Administracion de Empleados";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDepartamentos;
        private System.Windows.Forms.Button btnEmpleados;
    }
}

