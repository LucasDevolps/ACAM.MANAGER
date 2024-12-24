using ACAM.Data;
using ACAM.Domain.Interface.Service;
using ACAM.Service;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACAM.Management.Presentation
{
    public partial class FrmConsultBaseCentral : Form
    {
        public static ConfigurationBuilder _builder = new ConfigurationBuilder();
        public static IConfiguration _configuration;
        public static IServiceArquivo _serviceArquivo = new ServiceArquivo();
        public static IServicesRegistros _servicesRegistros = new ServicesRegistros();

        public FrmConsultBaseCentral()
        {
            _builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = _builder.Build();

            InitializeComponent();
        }

        public void FrmConsultBaseCentral_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = _servicesRegistros.ListarArquivosJaProcessadosDoBanco();

                dtInicial.Text = DateTime.Now.ToString("dd/MM/yyyy");
                dtFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");


                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    comboBox1.DataSource = dataTable;

                    comboBox1.DisplayMember = "Nome_arquivo";
                    comboBox1.ValueMember = "Id_arquivo";
                }
                else
                {
                    MessageBox.Show("Nenhum arquivo processado foi encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                var logger = new LoggerRepository();
                logger.Log(ex);

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                string dataIni = "";
                string datafim = "";
                string documento = "";

                if (dtInicial.Text == "  /  /" && dtFinal.Text == "  /  /" && comboBox1.Text == "   ,   ,   -")
                {
                    MessageBox.Show("Favor informar ao menos um dos filtros");
                    return;
                }

                if (dtInicial.Text != "  /  /" && dtFinal.Text != "  /  /")
                {
                    if (DateTime.Parse(dtInicial.Text.ToString()) > DateTime.Parse(dtFinal.Text.ToString()))
                    {
                        MessageBox.Show("Data final não pode ser menor que a inicial");
                        return;
                    }

                    dataIni = DateTime.Parse(dtInicial.Text).ToString("yyyyMMdd");
                    datafim = DateTime.Parse(dtFinal.Text).ToString("yyyyMMdd");
                }

                var dados = _servicesRegistros.ConsultaBaseGeral(dataIni, datafim, Convert.ToInt32(comboBox1.SelectedValue));

                grdTabela.DataSource = null;
                grdTabela.DataSource = dados;
                
                if(dados.Count() == 0)
                {
                    MessageBox.Show("Não foi encontrado nenhum registro com esses filtros!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void grdTabela_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
