using Microsoft.Extensions.Configuration;
using ACAM.Domain.DTOs;
using System.Windows.Forms;
using ACAM.Domain.Interface.Service;
using ACAM.Service;
using ACAM.Data;
using System.Data;

namespace ACAM.Management.Presentation
{
    public partial class frmImportAcam : Form
    {
        public static ConfigurationBuilder _builder = new ConfigurationBuilder();
        public static IConfiguration _configuration;
        public static IServiceArquivo _serviceArquivo = new ServiceArquivo();
        public static IServicesRegistros _servicesRegistros = new ServicesRegistros();


        public frmImportAcam()
        {
            _builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = _builder.Build();

            InitializeComponent();
        }

        private void frmImportAcam_Load(object sender, EventArgs e)
        {
            try
            {
                string caminhoImportacao = _configuration["Configuracoes:CaminhoLocal"];

                listFileAcams.DisplayMember = "FileName";
                listFileAcams.ValueMember = "FilePath";

                if (Directory.Exists(caminhoImportacao))
                {
                    string[] arquivosCsv = Directory.GetFiles(caminhoImportacao, "*.csv");


                    listFileAcams.DataBindings.Clear();
                    listFileAcams.Items.Clear();

                    foreach (var item in arquivosCsv)
                    {
                        AcamFilesDto fileAcam = new AcamFilesDto()
                        {
                            FileName = item,
                            FilePath = item,
                        };

                        listFileAcams.Items.Insert(0, fileAcam);
                    }
                }

                var sortedItems = listFileAcams.Items
                    .Cast<ACAM.Domain.DTOs.AcamFilesDto>()
                    .OrderBy(item => item.FileName) 
                    .ToList();

                listFileAcams.Items.Clear();

                foreach (var item in sortedItems)
                {
                    listFileAcams.Items.Add(item);
                }


            }
            catch (Exception ex)
            {
                var logger = new LoggerRepository();
                logger.Log(ex);
            }
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = _configuration["ConnectionStrings:DefaultConnection"];

                for (int i = 0; i < listFileAcams.Items.Count; i++)
                {
                    if (listFileAcams.GetItemChecked(i) == true)
                    {
                        var filePath = (AcamFilesDto)listFileAcams.Items[i];

                        int idFile = _serviceArquivo.InicioDoProcessoArquivo(connectionString, filePath.FilePath);


                        _servicesRegistros.ProcessarCsvPorStreaming(filePath.FilePath, idFile);

                        _servicesRegistros.SalvarNaTabelaRestritiva(45000, idFile);

                        _servicesRegistros.GerarRelatorioSaidaProcessamento(idFile);

                        dataGridView1.DataSource = _servicesRegistros.GerarRelatorioVisualTotal(idFile);

                        dataGridView2.DataSource = _servicesRegistros.GerarRelatorioVisualNaoProcessados(idFile);

                        MessageBox.Show("Sucesso !","Sucesso",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                var logger = new LoggerRepository();
                logger.Log(ex);

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkSelTodos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < listFileAcams.Items.Count; i++)
                {
                    listFileAcams.SetItemChecked(i, chkSelTodos.Checked);
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
