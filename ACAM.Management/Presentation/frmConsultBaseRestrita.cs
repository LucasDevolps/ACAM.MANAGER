using ACAM.Domain.Interface.Service;
using ACAM.Service;
using Microsoft.Extensions.Configuration;

namespace ACAM.Management.Presentation
{
    public partial class frmConsultBaseRestrita : Form
    {
        public static ConfigurationBuilder _builder = new ConfigurationBuilder();
        public static IConfiguration _configuration;
        public static IServicesRegistros _servicesRegistros = new ServicesRegistros();

        public frmConsultBaseRestrita()
        {
            _builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = _builder.Build();

            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDataInicial.Text == "" && txtDataFinal.Text == "" && txtDocumento.Text == "")
                {
                    MessageBox.Show("Favor informar ao menos um dos filtros");
                    return;
                }

                if (txtDataInicial.Text != "" && txtDataFinal.Text != "")
                {
                    if (DateTime.Parse(txtDataInicial.Text.ToString()) > DateTime.Parse(txtDataFinal.Text.ToString()))
                    {
                        MessageBox.Show("Data final não pode ser menor que a inicial");
                        return;
                    }
                }
                var dados = _servicesRegistros.ConsultaBaseRestritra(txtDataInicial.Text.ToString(), txtDataFinal.Text.ToString(), txtDocumento.Text);

                grdTabela.DataSource = null;
                grdTabela.DataSource = dados;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void rdbCPF_CheckedChanged(object sender, EventArgs e)
        {
            txtDocumento.Text = "";
            txtDocumento.Mask = @"000\.000\.000\-00";
            txtDocumento.Focus();
        }

        private void rdbCNPJ_CheckedChanged(object sender, EventArgs e)
        {
            txtDocumento.Text = "";
            txtDocumento.Mask = @"00\.000\.000\/0000\-00";
            txtDocumento.Focus();
        }
    }
}
