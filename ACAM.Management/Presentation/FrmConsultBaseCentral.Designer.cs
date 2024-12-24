namespace ACAM.Management.Presentation
{
    partial class FrmConsultBaseCentral
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
            grdTabela = new DataGridView();
            acamDTOBindingSource = new BindingSource(components);
            groupBox1 = new GroupBox();
            btnConsultar = new Button();
            rdbCNPJ = new RadioButton();
            rdbCPF = new RadioButton();
            maskedTextBox3 = new MaskedTextBox();
            label3 = new Label();
            label2 = new Label();
            dtFinal = new MaskedTextBox();
            dtInicial = new MaskedTextBox();
            label1 = new Label();
            comboBox1 = new ComboBox();
            clientDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pixKeyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cpfnameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            amountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            trnDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idfileDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            restritoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)grdTabela).BeginInit();
            ((System.ComponentModel.ISupportInitialize)acamDTOBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // grdTabela
            // 
            grdTabela.AutoGenerateColumns = false;
            grdTabela.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdTabela.Columns.AddRange(new DataGridViewColumn[] { clientDataGridViewTextBoxColumn, pixKeyDataGridViewTextBoxColumn, cpfnameDataGridViewTextBoxColumn, amountDataGridViewTextBoxColumn, trnDateDataGridViewTextBoxColumn, idfileDataGridViewTextBoxColumn, restritoDataGridViewTextBoxColumn });
            grdTabela.DataSource = acamDTOBindingSource;
            grdTabela.Location = new Point(12, 97);
            grdTabela.Name = "grdTabela";
            grdTabela.Size = new Size(876, 425);
            grdTabela.TabIndex = 0;
            grdTabela.CellContentClick += grdTabela_CellContentClick;
            // 
            // acamDTOBindingSource
            // 
            acamDTOBindingSource.DataSource = typeof(Domain.DTOs.AcamDTO);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnConsultar);
            groupBox1.Controls.Add(rdbCNPJ);
            groupBox1.Controls.Add(rdbCPF);
            groupBox1.Controls.Add(maskedTextBox3);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dtFinal);
            groupBox1.Controls.Add(dtInicial);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Location = new Point(12, 7);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(876, 79);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // btnConsultar
            // 
            btnConsultar.BackgroundImage = Properties.Resources.Find;
            btnConsultar.BackgroundImageLayout = ImageLayout.Stretch;
            btnConsultar.Location = new Point(794, 28);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(30, 29);
            btnConsultar.TabIndex = 9;
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // rdbCNPJ
            // 
            rdbCNPJ.AutoSize = true;
            rdbCNPJ.Location = new Point(704, 14);
            rdbCNPJ.Name = "rdbCNPJ";
            rdbCNPJ.Size = new Size(52, 19);
            rdbCNPJ.TabIndex = 8;
            rdbCNPJ.Text = "CNPJ";
            rdbCNPJ.UseVisualStyleBackColor = true;
            // 
            // rdbCPF
            // 
            rdbCPF.AutoSize = true;
            rdbCPF.Checked = true;
            rdbCPF.Location = new Point(652, 14);
            rdbCPF.Name = "rdbCPF";
            rdbCPF.Size = new Size(46, 19);
            rdbCPF.TabIndex = 7;
            rdbCPF.TabStop = true;
            rdbCPF.Text = "CPF";
            rdbCPF.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox3
            // 
            maskedTextBox3.Location = new Point(652, 34);
            maskedTextBox3.Mask = "000.000.000-00";
            maskedTextBox3.Name = "maskedTextBox3";
            maskedTextBox3.Size = new Size(136, 23);
            maskedTextBox3.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(553, 18);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 5;
            label3.Text = "Data Final";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(445, 16);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 4;
            label2.Text = "Data Inicial";
            // 
            // dtFinal
            // 
            dtFinal.Location = new Point(553, 34);
            dtFinal.Mask = "00/00/0000";
            dtFinal.Name = "dtFinal";
            dtFinal.Size = new Size(95, 23);
            dtFinal.TabIndex = 3;
            dtFinal.ValidatingType = typeof(DateTime);
            // 
            // dtInicial
            // 
            dtInicial.Location = new Point(445, 34);
            dtInicial.Mask = "00/00/0000";
            dtInicial.Name = "dtInicial";
            dtInicial.Size = new Size(100, 23);
            dtInicial.TabIndex = 2;
            dtInicial.ValidatingType = typeof(DateTime);
            dtInicial.MaskInputRejected += maskedTextBox1_MaskInputRejected;
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
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(6, 34);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(435, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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
            // 
            // restritoDataGridViewTextBoxColumn
            // 
            restritoDataGridViewTextBoxColumn.DataPropertyName = "restrito";
            restritoDataGridViewTextBoxColumn.HeaderText = "restrito";
            restritoDataGridViewTextBoxColumn.Name = "restritoDataGridViewTextBoxColumn";
            // 
            // FrmConsultBaseCentral
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(900, 534);
            Controls.Add(groupBox1);
            Controls.Add(grdTabela);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmConsultBaseCentral";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consultar Base Central de ACAMs Importadas";
            Load += FrmConsultBaseCentral_Load;
            ((System.ComponentModel.ISupportInitialize)grdTabela).EndInit();
            ((System.ComponentModel.ISupportInitialize)acamDTOBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView grdTabela;
        private GroupBox groupBox1;
        private MaskedTextBox dtFinal;
        private MaskedTextBox dtInicial;
        private Label label1;
        private MaskedTextBox maskedTextBox3;
        private Label label3;
        private Label label2;
        private RadioButton rdbCPF;
        private RadioButton rdbCNPJ;
        private Button btnConsultar;
        private BindingSource acamDTOBindingSource;
        private ComboBox comboBox1;
        private DataGridViewTextBoxColumn clientDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pixKeyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cpfnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn trnDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idfileDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn restritoDataGridViewTextBoxColumn;
    }
}