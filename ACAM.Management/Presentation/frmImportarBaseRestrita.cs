using ACAM.Data;
using ACAM.Domain.DTOs;
using ACAM.Domain.Interface.Service;
using ACAM.Service;
using Microsoft.Extensions.Configuration;

namespace ACAM.Management.Presentation
{
    public partial class frmImportarBaseRestrita : Form
    {
        public static ConfigurationBuilder _builder = new ConfigurationBuilder();
        public static IConfiguration _configuration;
        public string _caminhoImportacao;

        public static IServiceArquivo _serviceArquivo = new ServiceArquivo();
        public static IServicesRegistros _servicesRegistros = new ServicesRegistros();

        public frmImportarBaseRestrita()
        {

            _builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = _builder.Build();

            _caminhoImportacao = Path.Combine(_configuration["Configuracoes:CaminhoLocal"], "Restritos");

            InitializeComponent();
        }

        private void frmImportarBaseRestrita_Load(object sender, EventArgs e)
        {
            try
            {
                //string caminhoImportacao = _configuration["Configuracoes:CaminhoLocal"];

                listFileAcams.DisplayMember = "FileName";
                listFileAcams.ValueMember = "FilePath";

                if (Directory.Exists(_caminhoImportacao))
                {
                    // Busca arquivos com extensões .csv, .xls e .xlsx
                    string[] arquivos = Directory.GetFiles(_caminhoImportacao, "*.*")
                                                 .Where(file =>
                                                                file.EndsWith(".csv", StringComparison.OrdinalIgnoreCase) ||
                                                                file.EndsWith(".xls", StringComparison.OrdinalIgnoreCase) ||
                                                                file.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                                                 .ToArray();

                    listFileAcams.DataBindings.Clear();
                    listFileAcams.Items.Clear();

                    foreach (var item in arquivos)
                    {
                        AcamFilesDto fileAcam = new AcamFilesDto()
                        {
                            FileName = Path.GetFileName(item), // Exibe apenas o nome do arquivo
                            FilePath = item,                  // Caminho completo do arquivo
                        };

                        listFileAcams.Items.Insert(0, fileAcam);
                    }
                }

                // Ordena os itens por nome do arquivo
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

        private async void btnProcessar_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < listFileAcams.Items.Count; i++)
                {
                    if (listFileAcams.GetItemChecked(i))
                    {
                        var filePath = (AcamFilesDto)listFileAcams.Items[i];
                        int idArquivo = await _serviceArquivo.InicioDoProcessoArquivo(filePath.FilePath);


                        await Task.Run(() =>
                        {
                            _servicesRegistros.ProcessarCsvPorStreaming(filePath.FilePath, idArquivo);
                            _servicesRegistros.ForcaImportacaoRestritiva(idArquivo);
                            _servicesRegistros.GerarRelatorio(idArquivo, "Restritos");
                        });
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
        }
    }
}
