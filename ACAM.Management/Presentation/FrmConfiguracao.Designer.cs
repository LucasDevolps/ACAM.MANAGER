namespace ACAM.Management.Presentation
{
    partial class FrmConfiguracao
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
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            vlMaximo = new Label();
            numericUpDown1 = new NumericUpDown();
            cmbConexao = new ComboBox();
            strConexao = new Label();
            lblCaminhoArquivos = new Label();
            txtArquivo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // vlMaximo
            // 
            vlMaximo.AutoSize = true;
            vlMaximo.Location = new Point(12, 9);
            vlMaximo.Name = "vlMaximo";
            vlMaximo.Size = new Size(80, 15);
            vlMaximo.TabIndex = 1;
            vlMaximo.Text = "Valor Máximo";
            vlMaximo.Click += label1_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(153, 7);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 2;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // cmbConexao
            // 
            cmbConexao.FormattingEnabled = true;
            cmbConexao.Location = new Point(153, 36);
            cmbConexao.Name = "cmbConexao";
            cmbConexao.Size = new Size(327, 23);
            cmbConexao.TabIndex = 3;
            cmbConexao.SelectedIndexChanged += cbmConexao_SelectedIndexChanged;
            // 
            // strConexao
            // 
            strConexao.AutoSize = true;
            strConexao.Location = new Point(12, 39);
            strConexao.Name = "strConexao";
            strConexao.Size = new Size(127, 15);
            strConexao.TabIndex = 4;
            strConexao.Text = "Conexão com o banco";
            strConexao.Click += strConexao_Click;
            // 
            // lblCaminhoArquivos
            // 
            lblCaminhoArquivos.AutoSize = true;
            lblCaminhoArquivos.Location = new Point(12, 70);
            lblCaminhoArquivos.Name = "lblCaminhoArquivos";
            lblCaminhoArquivos.Size = new Size(131, 15);
            lblCaminhoArquivos.TabIndex = 5;
            lblCaminhoArquivos.Text = "Caminho dos Arquivos ";
            lblCaminhoArquivos.Click += label1_Click_1;
            // 
            // txtArquivo
            // 
            txtArquivo.Location = new Point(153, 67);
            txtArquivo.Name = "txtArquivo";
            txtArquivo.Size = new Size(327, 23);
            txtArquivo.TabIndex = 6;
            // 
            // FrmConfiguracao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 155);
            Controls.Add(txtArquivo);
            Controls.Add(lblCaminhoArquivos);
            Controls.Add(strConexao);
            Controls.Add(cmbConexao);
            Controls.Add(numericUpDown1);
            Controls.Add(vlMaximo);
            Name = "FrmConfiguracao";
            Text = "FrmConfiguracao";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private Label vlMaximo;
        private NumericUpDown numericUpDown1;
        private ComboBox cmbConexao;
        private Label strConexao;
        private Label lblCaminhoArquivos;
        private TextBox txtArquivo;
    }
}