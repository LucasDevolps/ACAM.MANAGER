namespace ACAM.Management.Presentation
{
    partial class frmImportarBaseRestrita
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
            listFileAcams = new CheckedListBox();
            btnProcessar = new Button();
            chkSelTodos = new CheckBox();
            SuspendLayout();
            // 
            // listFileAcams
            // 
            listFileAcams.BackColor = SystemColors.InactiveCaption;
            listFileAcams.FormattingEnabled = true;
            listFileAcams.Location = new Point(12, 12);
            listFileAcams.Name = "listFileAcams";
            listFileAcams.Size = new Size(863, 94);
            listFileAcams.TabIndex = 1;
            // 
            // btnProcessar
            // 
            btnProcessar.BackgroundImageLayout = ImageLayout.Stretch;
            btnProcessar.Image = Properties.Resources.CHECKMRK;
            btnProcessar.ImageAlign = ContentAlignment.MiddleLeft;
            btnProcessar.Location = new Point(775, 112);
            btnProcessar.Name = "btnProcessar";
            btnProcessar.Size = new Size(100, 25);
            btnProcessar.TabIndex = 5;
            btnProcessar.Text = "Processar Importação";
            btnProcessar.UseVisualStyleBackColor = true;
            btnProcessar.Click += btnProcessar_Click;
            // 
            // chkSelTodos
            // 
            chkSelTodos.AutoSize = true;
            chkSelTodos.Location = new Point(12, 116);
            chkSelTodos.Name = "chkSelTodos";
            chkSelTodos.Size = new Size(114, 19);
            chkSelTodos.TabIndex = 6;
            chkSelTodos.Text = "Selecionar Todos";
            chkSelTodos.UseVisualStyleBackColor = true;
            chkSelTodos.CheckedChanged += chkSelTodos_CheckedChanged;
            // 
            // frmImportarBaseRestrita
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 150);
            Controls.Add(chkSelTodos);
            Controls.Add(btnProcessar);
            Controls.Add(listFileAcams);
            Name = "frmImportarBaseRestrita";
            Text = "frmImportarBaseRestrita";
            Load += frmImportarBaseRestrita_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox listFileAcams;
        private Button btnProcessar;
        private CheckBox chkSelTodos;
    }
}