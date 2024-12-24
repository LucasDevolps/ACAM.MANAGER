namespace ACAM.Management.Presentation
{
    partial class FrmGerarACAMSaida
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
            groupBox1 = new GroupBox();
            btnConsultar = new Button();
            label1 = new Label();
            cmbArquivo = new ComboBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnConsultar);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbArquivo);
            groupBox1.Location = new Point(3, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(515, 79);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // btnConsultar
            // 
            btnConsultar.BackgroundImage = Properties.Resources.save;
            btnConsultar.BackgroundImageLayout = ImageLayout.Stretch;
            btnConsultar.Location = new Point(447, 28);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(30, 29);
            btnConsultar.TabIndex = 9;
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 18);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 1;
            label1.Text = "Arquivo";
            // 
            // cmbArquivo
            // 
            cmbArquivo.FormattingEnabled = true;
            cmbArquivo.Location = new Point(6, 34);
            cmbArquivo.Name = "cmbArquivo";
            cmbArquivo.Size = new Size(435, 23);
            cmbArquivo.TabIndex = 0;
            // 
            // FrmGerarACAMSaida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(535, 114);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmGerarACAMSaida";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerar ACAM de Saída";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnConsultar;
        private Label label1;
        private ComboBox cmbArquivo;
    }
}