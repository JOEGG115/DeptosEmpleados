namespace DeptosEmpleados.Presentacion
{
    partial class frm2
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
            this.ID = new System.Windows.Forms.Label();
            this.fsdfds = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvDepartamento = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamento)).BeginInit();
            this.SuspendLayout();
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.Location = new System.Drawing.Point(41, 19);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(23, 16);
            this.ID.TabIndex = 0;
            this.ID.Text = "ID";
            this.ID.Click += new System.EventHandler(this.label1_Click);
            // 
            // fsdfds
            // 
            this.fsdfds.AutoSize = true;
            this.fsdfds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fsdfds.Location = new System.Drawing.Point(241, 9);
            this.fsdfds.Name = "fsdfds";
            this.fsdfds.Size = new System.Drawing.Size(165, 16);
            this.fsdfds.TabIndex = 1;
            this.fsdfds.Text = "Nombre Departamento";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(44, 35);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(147, 20);
            this.txtID.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(244, 35);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(468, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Image = global::DeptosEmpleados.Properties.Resources._285657_floppy_guardar_save_icon;
            this.btnAgregar.Location = new System.Drawing.Point(44, 61);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(147, 84);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Image = global::DeptosEmpleados.Properties.Resources._285638_pencil_icon;
            this.btnModificar.Location = new System.Drawing.Point(220, 61);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(141, 84);
            this.btnModificar.TabIndex = 5;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.Image = global::DeptosEmpleados.Properties.Resources._299045_sign_error_icon;
            this.btnBorrar.Location = new System.Drawing.Point(389, 61);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(134, 84);
            this.btnBorrar.TabIndex = 6;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::DeptosEmpleados.Properties.Resources._285688_file_empty_icon;
            this.btnCancelar.Location = new System.Drawing.Point(563, 61);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(149, 84);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dgvDepartamento
            // 
            this.dgvDepartamento.AllowUserToAddRows = false;
            this.dgvDepartamento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepartamento.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDepartamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartamento.Location = new System.Drawing.Point(44, 151);
            this.dgvDepartamento.Name = "dgvDepartamento";
            this.dgvDepartamento.Size = new System.Drawing.Size(668, 287);
            this.dgvDepartamento.TabIndex = 8;
            this.dgvDepartamento.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.seleccionar);
            // 
            // frm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvDepartamento);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.fsdfds);
            this.Controls.Add(this.ID);
            this.Name = "frm2";
            this.Text = "frmDepartamentos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Label fsdfds;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvDepartamento;
    }
}