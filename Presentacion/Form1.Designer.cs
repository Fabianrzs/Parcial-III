
namespace Presentacion
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
            this.CbxProyectos = new System.Windows.Forms.ComboBox();
            this.BtnCargar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtnCargarTabla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // CbxProyectos
            // 
            this.CbxProyectos.FormattingEnabled = true;
            this.CbxProyectos.Location = new System.Drawing.Point(190, 89);
            this.CbxProyectos.Name = "CbxProyectos";
            this.CbxProyectos.Size = new System.Drawing.Size(121, 21);
            this.CbxProyectos.TabIndex = 0;
            // 
            // BtnCargar
            // 
            this.BtnCargar.Location = new System.Drawing.Point(364, 89);
            this.BtnCargar.Name = "BtnCargar";
            this.BtnCargar.Size = new System.Drawing.Size(75, 23);
            this.BtnCargar.TabIndex = 1;
            this.BtnCargar.Text = "Cargar";
            this.BtnCargar.UseVisualStyleBackColor = true;
            this.BtnCargar.Click += new System.EventHandler(this.BtnCargar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 248);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(614, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // BtnCargarTabla
            // 
            this.BtnCargarTabla.Location = new System.Drawing.Point(675, 375);
            this.BtnCargarTabla.Name = "BtnCargarTabla";
            this.BtnCargarTabla.Size = new System.Drawing.Size(113, 23);
            this.BtnCargarTabla.TabIndex = 3;
            this.BtnCargarTabla.Text = "Cargar Tabla";
            this.BtnCargarTabla.UseVisualStyleBackColor = true;
            this.BtnCargarTabla.Click += new System.EventHandler(this.BtnCargarTabla_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnCargarTabla);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BtnCargar);
            this.Controls.Add(this.CbxProyectos);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CbxProyectos;
        private System.Windows.Forms.Button BtnCargar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtnCargarTabla;
    }
}

