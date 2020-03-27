namespace appBanco
{
    partial class verDatosPersona
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
            this.dgvMostrarClientes = new System.Windows.Forms.DataGridView();
            this.btnConsulClient = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrarClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMostrarClientes
            // 
            this.dgvMostrarClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMostrarClientes.Location = new System.Drawing.Point(10, 44);
            this.dgvMostrarClientes.Name = "dgvMostrarClientes";
            this.dgvMostrarClientes.Size = new System.Drawing.Size(349, 250);
            this.dgvMostrarClientes.TabIndex = 0;
            // 
            // btnConsulClient
            // 
            this.btnConsulClient.Location = new System.Drawing.Point(80, 10);
            this.btnConsulClient.Name = "btnConsulClient";
            this.btnConsulClient.Size = new System.Drawing.Size(67, 24);
            this.btnConsulClient.TabIndex = 1;
            this.btnConsulClient.Text = "Consultar";
            this.btnConsulClient.UseVisualStyleBackColor = true;
            this.btnConsulClient.Click += new System.EventHandler(this.btnConsulClient_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(244, 10);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(72, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Cerrar";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // verDatosClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 303);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConsulClient);
            this.Controls.Add(this.dgvMostrarClientes);
            this.Name = "verDatosClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "verDatosClientes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrarClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMostrarClientes;
        private System.Windows.Forms.Button btnConsulClient;
        private System.Windows.Forms.Button btnSalir;
    }
}