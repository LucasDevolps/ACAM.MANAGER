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
            progressBar1.Visible = false;

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

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnProcessar_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Visible = true; // Exibir o ProgressBar
                progressBar1.Style = ProgressBarStyle.Marquee; // Indicador de progresso indeterminado
                btnProcessar.Enabled = false; // Desabilitar o botão durante o processamento

                string connectionString = _configuration["ConnectionStrings:DefaultConnection"];

                for (int i = 0; i < listFileAcams.Items.Count; i++)
                {
                    if (listFileAcams.GetItemChecked(i))
                    {
                        var filePath = (AcamFilesDto)listFileAcams.Items[i];

                        try
                        {
                            // Iniciar o processamento do arquivo e obter o ID
                            int idArquivo = await _serviceArquivo.InicioDoProcessoArquivo(filePath.FilePath);

                            // Processar os arquivos de forma assíncrona
                            await Task.Run(() =>
                            {
                                _servicesRegistros.ProcessarCsvPorStreaming(filePath.FilePath, idArquivo);
                                _servicesRegistros.SalvarNaTabelaRestritiva(45000, idArquivo);
                                _servicesRegistros.GerarRelatorioSaidaProcessamento(idArquivo);
                            });

                            // Atualizar os DataGrids após o processamento
                            var relatorioTotal = await Task.Run(() => _servicesRegistros.GerarRelatorioVisualTotal(idArquivo));
                            var relatorioNaoProcessados = await Task.Run(() => _servicesRegistros.GerarRelatorioVisualNaoProcessados(idArquivo));

                            dataGridView1.DataSource = relatorioTotal;
                            dataGridView2.DataSource = relatorioNaoProcessados;

                            // Mover arquivos processados para a pasta "PROCESSADOS"
                            string pastaProcessados = Path.Combine(Path.GetDirectoryName(filePath.FilePath) ?? string.Empty, "PROCESSADOS");

                            if (!Directory.Exists(pastaProcessados))
                            {
                                Directory.CreateDirectory(pastaProcessados);
                            }

                            string nomeArquivo = Path.GetFileName(filePath.FilePath);
                            string destino = Path.Combine(pastaProcessados, nomeArquivo);

                            try
                            {
                                File.Move(filePath.FilePath, destino, true);
                                Console.WriteLine($"Arquivo movido para: {destino}");

                                listFileAcams.Items.RemoveAt(i);
                                i--; 
                            }
                            catch (IOException ex)
                            {
                                Console.WriteLine($"Erro ao mover o arquivo {nomeArquivo}: {ex.Message}");
                            }

                            
                        }
                        catch (Exception ex)
                        {
                            var logger = new LoggerRepository();
                            logger.Log(ex);

                            MessageBox.Show($"Erro ao processar o arquivo {filePath.FilePath}: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                MessageBox.Show("Arquivo processado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                var logger = new LoggerRepository();
                logger.Log(ex);

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ocultar o ProgressBar e reativar o botão ao final do processo
                progressBar1.Visible = false;
                btnProcessar.Enabled = true;
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

                var logger = new LoggerRepository();
                logger.Log(ex);

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
