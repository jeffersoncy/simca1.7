﻿namespace appBanco
{
    partial class verFacultades
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConsultarDepartamentos = new System.Windows.Forms.Button();
            this.dgvVer = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnConsultarDepartamentos);
            this.panel1.Controls.Add(this.dgvVer);
            this.panel1.Location = new System.Drawing.Point(1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 423);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "facultades";
            // 
            // btnConsultarDepartamentos
            // 
            this.btnConsultarDepartamentos.Location = new System.Drawing.Point(159, 389);
            this.btnConsultarDepartamentos.Name = "btnConsultarDepartamentos";
            this.btnConsultarDepartamentos.Size = new System.Drawing.Size(139, 23);
            this.btnConsultarDepartamentos.TabIndex = 1;
            this.btnConsultarDepartamentos.Text = "Consultar facultades";
            this.btnConsultarDepartamentos.UseVisualStyleBackColor = true;
            this.btnConsultarDepartamentos.Click += new System.EventHandler(this.btnConsultarDepartamentos_Click);
            // 
            // dgvVer
            // 
            this.dgvVer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVer.Location = new System.Drawing.Point(19, 28);
            this.dgvVer.Name = "dgvVer";
            this.dgvVer.Size = new System.Drawing.Size(267, 355);
            this.dgvVer.TabIndex = 0;
            // 
            // verFacultades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 419);
            this.Controls.Add(this.panel1);
            this.Name = "verFacultades";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConsultarDepartamentos;
        private System.Windows.Forms.DataGridView dgvVer;
    }
}