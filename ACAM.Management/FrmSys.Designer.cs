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
            lblImportarEConverter = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            btnImportaRetrita = new ToolStripMenuItem();
            mnuConsultaBaseCentral = new ToolStripMenuItem();
            mnuConsultaBaseRestrira = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            mnuGerarAcamProcessada = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            Configuracoes = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            sairToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripSeparator4 = new ToolStripSeparator();
            btnImportCAF = new ToolStripMenuItem();
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
            arquivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuImportarACAM, lblImportarEConverter, toolStripMenuItem1, btnImportaRetrita, btnImportCAF, toolStripSeparator4, mnuConsultaBaseCentral, mnuConsultaBaseRestrira, toolStripSeparator1, mnuGerarAcamProcessada, toolStripSeparator3, Configuracoes, toolStripSeparator2, sairToolStripMenuItem });
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
            // lblImportarEConverter
            // 
            lblImportarEConverter.Image = (Image)resources.GetObject("lblImportarEConverter.Image");
            lblImportarEConverter.ImageTransparentColor = Color.Magenta;
            lblImportarEConverter.Name = "lblImportarEConverter";
            lblImportarEConverter.Size = new Size(243, 22);
            lblImportarEConverter.Text = "Converter XLS";
            lblImportarEConverter.Click += lblImportarEConverter_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Image = (Image)resources.GetObject("toolStripMenuItem1.Image");
            toolStripMenuItem1.ImageTransparentColor = Color.Magenta;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(243, 22);
            toolStripMenuItem1.Text = "&Importar PPE";
            // 
            // btnImportaRetrita
            // 
            btnImportaRetrita.Image = (Image)resources.GetObject("btnImportaRetrita.Image");
            btnImportaRetrita.ImageTransparentColor = Color.Magenta;
            btnImportaRetrita.Name = "btnImportaRetrita";
            btnImportaRetrita.Size = new Size(243, 22);
            btnImportaRetrita.Text = "&Importar Base Restrita";
            btnImportaRetrita.Click += btnImportaRetrita_Click;
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
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(240, 6);
            // 
            // Configuracoes
            // 
            Configuracoes.Image = Properties.Resources.Operacional;
            Configuracoes.Name = "Configuracoes";
            Configuracoes.Size = new Size(243, 22);
            Configuracoes.Text = "Configurações";
            Configuracoes.Click += Configuracoes_Click;
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
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(240, 6);
            // 
            // btnImportCAF
            // 
            btnImportCAF.Image = (Image)resources.GetObject("btnImportCAF.Image");
            btnImportCAF.ImageTransparentColor = Color.Magenta;
            btnImportCAF.Name = "btnImportCAF";
            btnImportCAF.Size = new Size(243, 22);
            btnImportCAF.Text = "&Importar CAF";
            btnImportCAF.Click += btnImportCAF_Click;
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
        private ToolStripMenuItem mnuConsultaBaseCentral;
        private ToolStripMenuItem mnuConsultaBaseRestrira;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mnuGerarAcamProcessada;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem sairToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem Configuracoes;
        private ToolStripMenuItem lblImportarEConverter;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem btnImportaRetrita;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem btnImportCAF;
    }
}
