namespace ACAM.Management.Presentation
{
    partial class frmConsultBaseRestrita
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
            groupBox1 = new GroupBox();
            btnConsultar = new Button();
            rdbCNPJ = new RadioButton();
            rdbCPF = new RadioButton();
            txtDocumento = new MaskedTextBox();
            label3 = new Label();
            label2 = new Label();
            txtDataFinal = new MaskedTextBox();
            txtDataInicial = new MaskedTextBox();
            grdTabela = new DataGridView();
            clientDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pixKeyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cpfnameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            amountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            trnDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idfileDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            restritoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            acamDTOBindingSource = new BindingSource(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdTabela).BeginInit();
            ((System.ComponentModel.ISupportInitialize)acamDTOBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnConsultar);
            groupBox1.Controls.Add(rdbCNPJ);
            groupBox1.Controls.Add(rdbCPF);
            groupBox1.Controls.Add(txtDocumento);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtDataFinal);
            groupBox1.Controls.Add(txtDataInicial);
            groupBox1.Location = new Point(12, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(876, 79);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // btnConsultar
            // 
            btnConsultar.BackgroundImage = Properties.Resources.Find;
            btnConsultar.BackgroundImageLayout = ImageLayout.Stretch;
            btnConsultar.Location = new Point(358, 34);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(30, 29);
            btnConsultar.TabIndex = 10;
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // rdbCNPJ
            // 
            rdbCNPJ.AutoSize = true;
            rdbCNPJ.Location = new Point(268, 17);
            rdbCNPJ.Name = "rdbCNPJ";
            rdbCNPJ.Size = new Size(52, 19);
            rdbCNPJ.TabIndex = 8;
            rdbCNPJ.Text = "CNPJ";
            rdbCNPJ.UseVisualStyleBackColor = true;
            rdbCNPJ.CheckedChanged += rdbCNPJ_CheckedChanged;
            // 
            // rdbCPF
            // 
            rdbCPF.AutoSize = true;
            rdbCPF.Checked = true;
            rdbCPF.Location = new Point(216, 17);
            rdbCPF.Name = "rdbCPF";
            rdbCPF.Size = new Size(46, 19);
            rdbCPF.TabIndex = 7;
            rdbCPF.TabStop = true;
            rdbCPF.Text = "CPF";
            rdbCPF.UseVisualStyleBackColor = true;
            rdbCPF.CheckedChanged += rdbCPF_CheckedChanged;
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(216, 38);
            txtDocumento.Mask = "000.000.000-00";
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(136, 23);
            txtDocumento.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(117, 22);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 5;
            label3.Text = "Data Final";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 20);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 4;
            label2.Text = "Data Inicial";
            // 
            // txtDataFinal
            // 
            txtDataFinal.Location = new Point(117, 38);
            txtDataFinal.Mask = "00/00/0000";
            txtDataFinal.Name = "txtDataFinal";
            txtDataFinal.Size = new Size(95, 23);
            txtDataFinal.TabIndex = 3;
            txtDataFinal.ValidatingType = typeof(DateTime);
            // 
            // txtDataInicial
            // 
            txtDataInicial.Location = new Point(9, 38);
            txtDataInicial.Mask = "00/00/0000";
            txtDataInicial.Name = "txtDataInicial";
            txtDataInicial.Size = new Size(100, 23);
            txtDataInicial.TabIndex = 2;
            txtDataInicial.ValidatingType = typeof(DateTime);
            // 
            // grdTabela
            // 
            grdTabela.AutoGenerateColumns = false;
            grdTabela.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdTabela.Columns.AddRange(new DataGridViewColumn[] { clientDataGridViewTextBoxColumn, pixKeyDataGridViewTextBoxColumn, cpfnameDataGridViewTextBoxColumn, amountDataGridViewTextBoxColumn, trnDateDataGridViewTextBoxColumn, idfileDataGridViewTextBoxColumn, restritoDataGridViewTextBoxColumn });
            grdTabela.DataSource = acamDTOBindingSource;
            grdTabela.Location = new Point(12, 100);
            grdTabela.Name = "grdTabela";
            grdTabela.Size = new Size(876, 425);
            grdTabela.TabIndex = 2;
            // 
            // clientDataGridViewTextBoxColumn
            // 
            clientDataGridViewTextBoxColumn.DataPropertyName = "Client";
            clientDataGridViewTextBoxColumn.HeaderText = "Client";
            clientDataGridViewTextBoxColumn.Name = "clientDataGridViewTextBoxColumn";
            // 
            // pixKeyDataGridViewTextBoxColumn
            // 
            pixKeyDataGridViewTextBoxColumn.DataPropertyName = "Pix_Key";
            pixKeyDataGridViewTextBoxColumn.HeaderText = "Pix_Key";
            pixKeyDataGridViewTextBoxColumn.Name = "pixKeyDataGridViewTextBoxColumn";
            // 
            // cpfnameDataGridViewTextBoxColumn
            // 
            cpfnameDataGridViewTextBoxColumn.DataPropertyName = "cpf_name";
            cpfnameDataGridViewTextBoxColumn.HeaderText = "cpf_name";
            cpfnameDataGridViewTextBoxColumn.Name = "cpfnameDataGridViewTextBoxColumn";
            // 
            // amountDataGridViewTextBoxColumn
            // 
            amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            // 
            // trnDateDataGridViewTextBoxColumn
            // 
            trnDateDataGridViewTextBoxColumn.DataPropertyName = "TrnDate";
            trnDateDataGridViewTextBoxColumn.HeaderText = "TrnDate";
            trnDateDataGridViewTextBoxColumn.Name = "trnDateDataGridViewTextBoxColumn";
            // 
            // idfileDataGridViewTextBoxColumn
            // 
            idfileDataGridViewTextBoxColumn.DataPropertyName = "Id_file";
            idfileDataGridViewTextBoxColumn.HeaderText = "Id_file";
            idfileDataGridViewTextBoxColumn.Name = "idfileDataGridViewTextBoxColumn";
            idfileDataGridViewTextBoxColumn.Visible = false;
            // 
            // restritoDataGridViewTextBoxColumn
            // 
            restritoDataGridViewTextBoxColumn.DataPropertyName = "restrito";
            restritoDataGridViewTextBoxColumn.HeaderText = "restrito";
            restritoDataGridViewTextBoxColumn.Name = "restritoDataGridViewTextBoxColumn";
            restritoDataGridViewTextBoxColumn.Visible = false;
            // 
            // acamDTOBindingSource
            // 
            acamDTOBindingSource.DataSource = typeof(Domain.DTOs.AcamDTO);
            // 
            // frmConsultBaseRestrita
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(900, 534);
            Controls.Add(groupBox1);
            Controls.Add(grdTabela);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmConsultBaseRestrita";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consultar Base Restrita de ACAMs Importadas";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdTabela).EndInit();
            ((System.ComponentModel.ISupportInitialize)acamDTOBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton rdbCNPJ;
        private RadioButton rdbCPF;
        private MaskedTextBox txtDocumento;
        private Label label3;
        private Label label2;
        private MaskedTextBox txtDataFinal;
        private MaskedTextBox txtDataInicial;
        private DataGridView grdTabela;
        private Button btnConsultar;
        private BindingSource acamDTOBindingSource;
        private DataGridViewTextBoxColumn clientDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pixKeyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cpfnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn trnDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idfileDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn restritoDataGridViewTextBoxColumn;
    }
}