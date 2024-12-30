namespace ACAM.Management.Presentation
{
    partial class frmImportarCAF
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
            chkSelTodos = new CheckBox();
            progressBar1 = new ProgressBar();
            btnProcessar = new Button();
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
            // chkSelTodos
            // 
            chkSelTodos.AutoSize = true;
            chkSelTodos.Location = new Point(12, 112);
            chkSelTodos.Name = "chkSelTodos";
            chkSelTodos.Size = new Size(114, 19);
            chkSelTodos.TabIndex = 3;
            chkSelTodos.Text = "Selecionar Todos";
            chkSelTodos.UseVisualStyleBackColor = true;
            chkSelTodos.CheckedChanged += chkSelTodos_CheckedChanged;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(650, 114);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(100, 23);
            progressBar1.TabIndex = 5;
            // 
            // btnProcessar
            // 
            btnProcessar.BackgroundImageLayout = ImageLayout.Stretch;
            btnProcessar.Image = Properties.Resources.CHECKMRK;
            btnProcessar.ImageAlign = ContentAlignment.MiddleLeft;
            btnProcessar.Location = new Point(780, 112);
            btnProcessar.Name = "btnProcessar";
            btnProcessar.Size = new Size(100, 25);
            btnProcessar.TabIndex = 4;
            btnProcessar.Text = "Processar Importação";
            btnProcessar.UseVisualStyleBackColor = true;
            btnProcessar.Click += btnProcessar_Click;
            // 
            // frmImportarCAF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 178);
            Controls.Add(progressBar1);
            Controls.Add(btnProcessar);
            Controls.Add(chkSelTodos);
            Controls.Add(listFileAcams);
            Name = "frmImportarCAF";
            Text = "frmImportarCAF";
            Load += frmImportarCAF_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox listFileAcams;
        private CheckBox chkSelTodos;
        private ProgressBar progressBar1;
        private Button btnProcessar;
    }
}