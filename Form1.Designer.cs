namespace WinFormBulkInsert
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
            this.btnInsert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudRegistros = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTiempoBulk = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegistros)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(12, 52);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(149, 23);
            this.btnInsert.TabIndex = 0;
            this.btnInsert.Text = "Insert Bulk";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Registros";
            // 
            // nudRegistros
            // 
            this.nudRegistros.Location = new System.Drawing.Point(66, 16);
            this.nudRegistros.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudRegistros.Name = "nudRegistros";
            this.nudRegistros.Size = new System.Drawing.Size(120, 20);
            this.nudRegistros.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tiempo";
            // 
            // lblTiempoBulk
            // 
            this.lblTiempoBulk.AutoSize = true;
            this.lblTiempoBulk.Location = new System.Drawing.Point(63, 88);
            this.lblTiempoBulk.Name = "lblTiempoBulk";
            this.lblTiempoBulk.Size = new System.Drawing.Size(13, 13);
            this.lblTiempoBulk.TabIndex = 5;
            this.lblTiempoBulk.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Insert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(215, 88);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(13, 13);
            this.lblTiempo.TabIndex = 8;
            this.lblTiempo.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tiempo";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 194);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTiempoBulk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudRegistros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInsert);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nudRegistros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudRegistros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTiempoBulk;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Label label4;
    }
}

