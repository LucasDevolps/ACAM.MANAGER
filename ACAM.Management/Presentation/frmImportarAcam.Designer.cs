namespace ACAM.Management.Presentation
{
    partial class frmImportAcam
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
            chkSelTodos = new CheckBox();
            btnProcessar = new Button();
            listFileAcams = new CheckedListBox();
            tabImport = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            dataGridView1 = new DataGridView();
            acamDTOBindingSource = new BindingSource(components);
            clientDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pixKeyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cpfnameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            amountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            trnDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idfileDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            restritoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridView2 = new DataGridView();
            acamDTOBindingSource1 = new BindingSource(components);
            clientDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            pixKeyDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            cpfnameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            amountDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            trnDateDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            idfileDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            restritoDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            tabImport.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)acamDTOBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)acamDTOBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkSelTodos);
            groupBox1.Controls.Add(btnProcessar);
            groupBox1.Controls.Add(listFileAcams);
            groupBox1.Location = new Point(13, -3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(875, 145);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // chkSelTodos
            // 
            chkSelTodos.AutoSize = true;
            chkSelTodos.Location = new Point(8, 115);
            chkSelTodos.Name = "chkSelTodos";
            chkSelTodos.Size = new Size(114, 19);
            chkSelTodos.TabIndex = 2;
            chkSelTodos.Text = "Selecionar Todos";
            chkSelTodos.UseVisualStyleBackColor = true;
            chkSelTodos.CheckedChanged += chkSelTodos_CheckedChanged;
            // 
            // btnProcessar
            // 
            btnProcessar.BackgroundImageLayout = ImageLayout.Stretch;
            btnProcessar.Image = Properties.Resources.CHECKMRK;
            btnProcessar.ImageAlign = ContentAlignment.MiddleLeft;
            btnProcessar.Location = new Point(769, 115);
            btnProcessar.Name = "btnProcessar";
            btnProcessar.Size = new Size(100, 25);
            btnProcessar.TabIndex = 1;
            btnProcessar.Text = "Processar Importação";
            btnProcessar.UseVisualStyleBackColor = true;
            btnProcessar.Click += btnProcessar_Click;
            // 
            // listFileAcams
            // 
            listFileAcams.BackColor = SystemColors.InactiveCaption;
            listFileAcams.FormattingEnabled = true;
            listFileAcams.Location = new Point(6, 17);
            listFileAcams.Name = "listFileAcams";
            listFileAcams.Size = new Size(863, 94);
            listFileAcams.TabIndex = 0;
            // 
            // tabImport
            // 
            tabImport.Controls.Add(tabPage1);
            tabImport.Controls.Add(tabPage2);
            tabImport.Location = new Point(12, 143);
            tabImport.Name = "tabImport";
            tabImport.SelectedIndex = 0;
            tabImport.Size = new Size(876, 386);
            tabImport.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.ActiveCaption;
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(868, 358);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Processadas";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.ActiveCaption;
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(868, 358);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Não Processadas";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { clientDataGridViewTextBoxColumn, pixKeyDataGridViewTextBoxColumn, cpfnameDataGridViewTextBoxColumn, amountDataGridViewTextBoxColumn, trnDateDataGridViewTextBoxColumn, idfileDataGridViewTextBoxColumn, restritoDataGridViewTextBoxColumn });
            dataGridView1.DataSource = acamDTOBindingSource;
            dataGridView1.Location = new Point(6, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(856, 349);
            dataGridView1.TabIndex = 0;
            // 
            // acamDTOBindingSource
            // 
            acamDTOBindingSource.DataSource = typeof(Domain.DTOs.AcamDTO);
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
            // dataGridView2
            // 
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { clientDataGridViewTextBoxColumn1, pixKeyDataGridViewTextBoxColumn1, cpfnameDataGridViewTextBoxColumn1, amountDataGridViewTextBoxColumn1, trnDateDataGridViewTextBoxColumn1, idfileDataGridViewTextBoxColumn1, restritoDataGridViewTextBoxColumn1 });
            dataGridView2.DataSource = acamDTOBindingSource1;
            dataGridView2.Location = new Point(6, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(856, 349);
            dataGridView2.TabIndex = 0;
            // 
            // acamDTOBindingSource1
            // 
            acamDTOBindingSource1.DataSource = typeof(Domain.DTOs.AcamDTO);
            // 
            // clientDataGridViewTextBoxColumn1
            // 
            clientDataGridViewTextBoxColumn1.DataPropertyName = "Client";
            clientDataGridViewTextBoxColumn1.HeaderText = "Client";
            clientDataGridViewTextBoxColumn1.Name = "clientDataGridViewTextBoxColumn1";
            // 
            // pixKeyDataGridViewTextBoxColumn1
            // 
            pixKeyDataGridViewTextBoxColumn1.DataPropertyName = "Pix_Key";
            pixKeyDataGridViewTextBoxColumn1.HeaderText = "Pix_Key";
            pixKeyDataGridViewTextBoxColumn1.Name = "pixKeyDataGridViewTextBoxColumn1";
            // 
            // cpfnameDataGridViewTextBoxColumn1
            // 
            cpfnameDataGridViewTextBoxColumn1.DataPropertyName = "cpf_name";
            cpfnameDataGridViewTextBoxColumn1.HeaderText = "cpf_name";
            cpfnameDataGridViewTextBoxColumn1.Name = "cpfnameDataGridViewTextBoxColumn1";
            // 
            // amountDataGridViewTextBoxColumn1
            // 
            amountDataGridViewTextBoxColumn1.DataPropertyName = "Amount";
            amountDataGridViewTextBoxColumn1.HeaderText = "Amount";
            amountDataGridViewTextBoxColumn1.Name = "amountDataGridViewTextBoxColumn1";
            // 
            // trnDateDataGridViewTextBoxColumn1
            // 
            trnDateDataGridViewTextBoxColumn1.DataPropertyName = "TrnDate";
            trnDateDataGridViewTextBoxColumn1.HeaderText = "TrnDate";
            trnDateDataGridViewTextBoxColumn1.Name = "trnDateDataGridViewTextBoxColumn1";
            // 
            // idfileDataGridViewTextBoxColumn1
            // 
            idfileDataGridViewTextBoxColumn1.DataPropertyName = "Id_file";
            idfileDataGridViewTextBoxColumn1.HeaderText = "Id_file";
            idfileDataGridViewTextBoxColumn1.Name = "idfileDataGridViewTextBoxColumn1";
            // 
            // restritoDataGridViewTextBoxColumn1
            // 
            restritoDataGridViewTextBoxColumn1.DataPropertyName = "restrito";
            restritoDataGridViewTextBoxColumn1.HeaderText = "restrito";
            restritoDataGridViewTextBoxColumn1.Name = "restritoDataGridViewTextBoxColumn1";
            // 
            // frmImportAcam
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(900, 534);
            Controls.Add(tabImport);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmImportAcam";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Importação de ACAMs";
            Load += frmImportAcam_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabImport.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)acamDTOBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)acamDTOBindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TabControl tabImport;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnProcessar;
        private CheckedListBox listFileAcams;
        private CheckBox chkSelTodos;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn clientDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pixKeyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cpfnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn trnDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idfileDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn restritoDataGridViewTextBoxColumn;
        private BindingSource acamDTOBindingSource;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn clientDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn pixKeyDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn cpfnameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn trnDateDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn idfileDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn restritoDataGridViewTextBoxColumn1;
        private BindingSource acamDTOBindingSource1;
    }
}