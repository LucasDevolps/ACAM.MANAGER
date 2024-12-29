namespace ACAM.Management.Presentation
{
    partial class frmImportarEConverter
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
            btnProcessar = new Button();
            progressBar = new ProgressBar();
            SuspendLayout();
            // 
            // listFileAcams
            // 
            listFileAcams.BackColor = SystemColors.InactiveCaption;
            listFileAcams.FormattingEnabled = true;
            listFileAcams.Location = new Point(12, 12);
            listFileAcams.Name = "listFileAcams";
            listFileAcams.Size = new Size(776, 94);
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
            // btnProcessar
            // 
            btnProcessar.BackgroundImageLayout = ImageLayout.Stretch;
            btnProcessar.Image = Properties.Resources.CHECKMRK;
            btnProcessar.ImageAlign = ContentAlignment.MiddleLeft;
            btnProcessar.Location = new Point(688, 112);
            btnProcessar.Name = "btnProcessar";
            btnProcessar.Size = new Size(100, 25);
            btnProcessar.TabIndex = 4;
            btnProcessar.Text = "Processar Importação";
            btnProcessar.UseVisualStyleBackColor = true;
            btnProcessar.Click += btnProcessar_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(582, 112);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(100, 23);
            progressBar.TabIndex = 5;
            progressBar.Visible = false;
            // 
            // frmImportarEConverter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 148);
            Controls.Add(progressBar);
            Controls.Add(btnProcessar);
            Controls.Add(chkSelTodos);
            Controls.Add(listFileAcams);
            Name = "frmImportarEConverter";
            Text = "frmImportarEConverter";
            Load += frmImportarEConverter_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox listFileAcams;
        private CheckBox chkSelTodos;
        private Button btnProcessar;
        private ProgressBar progressBar;
    }
}