using ACAM.Management.Presentation;

namespace ACAM.Management
{
    public partial class FrmSys : Form
    {
        public FrmSys()
        {
            InitializeComponent();
        }

        private void mnuImportarACAM_Click(object sender, EventArgs e)
        {
            frmImportAcam objForm = new frmImportAcam();
            objForm.ShowDialog(this);
        }

        private void mnuConsultaBaseCentral_Click(object sender, EventArgs e)
        {
            FrmConsultBaseCentral ObjForm = new FrmConsultBaseCentral();
            ObjForm.ShowDialog(this);
        }

        private void mnuConsultaBaseRestrira_Click(object sender, EventArgs e)
        {
            frmConsultBaseRestrita objForm = new frmConsultBaseRestrita();
            objForm.ShowDialog(this);
        }

        private void mnuGerarAcamProcessada_Click(object sender, EventArgs e)
        {
            FrmGerarACAMSaida objForm = new FrmGerarACAMSaida();
            objForm.ShowDialog(this);
        }

        private void Configuracoes_Click(object sender, EventArgs e)
        {
            FrmConfiguracao objForm = new FrmConfiguracao();
            objForm.ShowDialog(this);
        }

        private void lblImportarEConverter_Click(object sender, EventArgs e)
        {
            frmImportarEConverter objForm = new frmImportarEConverter();
            objForm.ShowDialog(this);
        }

        private void btnImportaRetrita_Click(object sender, EventArgs e)
        {
            frmImportarBaseRestrita objForm = new frmImportarBaseRestrita();
            objForm.ShowDialog(this);
        }

        private void btnImportCAF_Click(object sender, EventArgs e)
        {
            frmImportarCAF objForm = new frmImportarCAF();
            objForm.ShowDialog(this);
        }
    }
}
