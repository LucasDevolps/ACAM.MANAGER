namespace ACAM.Management
{
    partial class FrmSys
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSys));
            mnuSystem = new MenuStrip();
            arquivoToolStripMenuItem = new ToolStripMenuItem();
            mnuImportarACAM = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            mnuConsultaBaseCentral = new ToolStripMenuItem();
            mnuConsultaBaseRestrira = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            mnuGerarAcamProcessada = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            sairToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            mnuSystem.SuspendLayout();
            SuspendLayout();
            // 
            // mnuSystem
            // 
            mnuSystem.Items.AddRange(new ToolStripItem[] { arquivoToolStripMenuItem });
            mnuSystem.Location = new Point(0, 0);
            mnuSystem.Name = "mnuSystem";
            mnuSystem.Size = new Size(900, 24);
            mnuSystem.TabIndex = 0;
            mnuSystem.Text = "Sistema";
            // 
            // arquivoToolStripMenuItem
            // 
            arquivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuImportarACAM, toolStripSeparator, mnuConsultaBaseCentral, mnuConsultaBaseRestrira, toolStripSeparator1, mnuGerarAcamProcessada, toolStripSeparator2, sairToolStripMenuItem });
            arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            arquivoToolStripMenuItem.Size = new Size(60, 20);
            arquivoToolStripMenuItem.Text = "&Sistema";
            // 
            // mnuImportarACAM
            // 
            mnuImportarACAM.Image = (Image)resources.GetObject("mnuImportarACAM.Image");
            mnuImportarACAM.ImageTransparentColor = Color.Magenta;
            mnuImportarACAM.Name = "mnuImportarACAM";
            mnuImportarACAM.ShortcutKeys = Keys.Control | Keys.S;
            mnuImportarACAM.Size = new Size(243, 22);
            mnuImportarACAM.Text = "&Importar";
            mnuImportarACAM.Click += mnuImportarACAM_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(240, 6);
            // 
            // mnuConsultaBaseCentral
            // 
            mnuConsultaBaseCentral.Image = (Image)resources.GetObject("mnuConsultaBaseCentral.Image");
            mnuConsultaBaseCentral.ImageTransparentColor = Color.Magenta;
            mnuConsultaBaseCentral.Name = "mnuConsultaBaseCentral";
            mnuConsultaBaseCentral.Size = new Size(243, 22);
            mnuConsultaBaseCentral.Text = "Consultar Base Central";
            mnuConsultaBaseCentral.Click += mnuConsultaBaseCentral_Click;
            // 
            // mnuConsultaBaseRestrira
            // 
            mnuConsultaBaseRestrira.Image = Properties.Resources.Contato;
            mnuConsultaBaseRestrira.Name = "mnuConsultaBaseRestrira";
            mnuConsultaBaseRestrira.Size = new Size(243, 22);
            mnuConsultaBaseRestrira.Text = "Consultar Base Restrita";
            mnuConsultaBaseRestrira.Click += mnuConsultaBaseRestrira_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(240, 6);
            // 
            // mnuGerarAcamProcessada
            // 
            mnuGerarAcamProcessada.Image = Properties.Resources.Produto;
            mnuGerarAcamProcessada.ImageTransparentColor = Color.Magenta;
            mnuGerarAcamProcessada.Name = "mnuGerarAcamProcessada";
            mnuGerarAcamProcessada.ShortcutKeys = Keys.Control | Keys.P;
            mnuGerarAcamProcessada.Size = new Size(243, 22);
            mnuGerarAcamProcessada.Text = "&Gerar ACAM Processada";
            mnuGerarAcamProcessada.Click += mnuGerarAcamProcessada_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(240, 6);
            // 
            // sairToolStripMenuItem
            // 
            sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            sairToolStripMenuItem.Size = new Size(243, 22);
            sairToolStripMenuItem.Text = "S&air";
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 512);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(900, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // FrmSys
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(900, 534);
            Controls.Add(statusStrip1);
            Controls.Add(mnuSystem);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = mnuSystem;
            MaximizeBox = false;
            Name = "FrmSys";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ACAM - Management";
            mnuSystem.ResumeLayout(false);
            mnuSystem.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuSystem;
        private ToolStripMenuItem arquivoToolStripMenuItem;
        private ToolStripMenuItem mnuImportarACAM;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem mnuConsultaBaseCentral;
        private ToolStripMenuItem mnuConsultaBaseRestrira;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mnuGerarAcamProcessada;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem sairToolStripMenuItem;
        private StatusStrip statusStrip1;
    }
}
