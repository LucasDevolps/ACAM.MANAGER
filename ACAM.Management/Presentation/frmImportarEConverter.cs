using ACAM.Data;
using ACAM.Domain.DTOs;
using ACAM.Domain.Interface.Service;
using ACAM.Service;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System.Data;
using System.Windows.Forms;

namespace ACAM.Management.Presentation
{
    public partial class frmImportarEConverter : Form
    {
        public static ConfigurationBuilder _builder = new ConfigurationBuilder();
        public static IConfiguration _configuration;
        public string _caminhoImportacao;


        public static IServiceArquivo _serviceArquivo = new ServiceArquivo();
        public static IServicesRegistros _servicesRegistros = new ServicesRegistros();
        public frmImportarEConverter()
        {
            _builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = _builder.Build();

            _caminhoImportacao = Path.Combine(_configuration["Configuracoes:CaminhoLocal"], "V2","Convertidos");

            InitializeComponent();
        }

        private void frmImportarEConverter_Load(object sender, EventArgs e)
        {
            try
            {
                string caminhoImportacao = Path.Combine(_configuration["Configuracoes:CaminhoLocal"],"V2");

                listFileAcams.DisplayMember = "FileName";
                listFileAcams.ValueMember = "FilePath";

                if (Directory.Exists(caminhoImportacao))
                {
                    // Busca arquivos com extensões .csv, .xls e .xlsx
                    string[] arquivos = Directory.GetFiles(caminhoImportacao, "*.*", SearchOption.AllDirectories)
                                                 .Where(file => file.EndsWith(".csv", StringComparison.OrdinalIgnoreCase) ||
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
            progressBar.Visible = true; // Exibir o ProgressBar
            progressBar.Style = ProgressBarStyle.Marquee; // Indicador de progresso indeterminado
            btnProcessar.Enabled = false;
            int idArquivo = 0; 
            try
            {
                // Configura o contexto de licença da EPPlus
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                if (!Directory.Exists(_caminhoImportacao))
                {
                    Directory.CreateDirectory(_caminhoImportacao);
                }

                foreach (var item in listFileAcams.CheckedItems.Cast<ACAM.Domain.DTOs.AcamFilesDto>())
                {
                    string inputFilePath = item.FilePath;

                    if (inputFilePath.EndsWith(".xls", StringComparison.OrdinalIgnoreCase) ||
                        inputFilePath.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                    {
                        string convertedFilePath = ConvertExcelToCsv(inputFilePath, _caminhoImportacao);

                        try
                        {
                            idArquivo = await _serviceArquivo.InicioDoProcessoArquivo(inputFilePath);

                            await Task.Run(() =>
                            {
                                string directoryPath = Path.GetDirectoryName(convertedFilePath);

                                var csvFiles = Directory.GetFiles(directoryPath, "*.csv", SearchOption.TopDirectoryOnly);

                                foreach (var filePath in csvFiles)
                                {
                                    _servicesRegistros.ProcessarCsvPorStreaming(filePath, idArquivo);
                                }
                            });


                        }
                        catch (Exception ex)
                        {
                            var logger = new LoggerRepository();
                            logger.Log(ex);

                            MessageBox.Show($"Erro ao processar o arquivo {convertedFilePath}: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = new LoggerRepository();
                logger.Log(ex);

                MessageBox.Show($"Erro ao processar os arquivos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar.Visible = false;
                btnProcessar.Enabled = true;
            }
        }

        private string ConvertExcelToCsv(string inputFilePath, string outputDirectory)
        {
            bool linhasIgnoradas = false; // Flag para rastrear se houve linhas ignoradas
            string outputFilePath = string.Empty;


            using (var package = new OfficeOpenXml.ExcelPackage(new FileInfo(inputFilePath)))
            {
                foreach (var worksheet in package.Workbook.Worksheets)
                {
                    string sanitizedSheetName = string.Join("_", worksheet.Name.Split(Path.GetInvalidFileNameChars()));
                    outputFilePath = Path.Combine(outputDirectory, $"{Path.GetFileNameWithoutExtension(inputFilePath)}_{sanitizedSheetName}.csv");

                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    // Definir os nomes de colunas válidos com base no mapeamento
                    var validColumns = new[] { "Client", "pix_key", "pix key", "cpf_name", "amount", "trndate" };

                    using (var writer = new StreamWriter(outputFilePath))
                    {
                        for (int row = 1; row <= rowCount; row++)
                        {
                            var rowValues = new List<string>();
                            bool isValidRow = true;

                            for (int col = 1; col <= colCount; col++)
                            {
                                string cellValue = worksheet.Cells[row, col].Text;

                                // Substituir ?column? por Amount
                                if (row == 1 && cellValue.Equals("?column?", StringComparison.OrdinalIgnoreCase))
                                {
                                    cellValue = "Amount";
                                }

                                // Verificar cabeçalhos na primeira linha
                                if (row == 1 && !validColumns.Contains(cellValue, StringComparer.OrdinalIgnoreCase))
                                {
                                    isValidRow = false; // Coluna inválida no cabeçalho
                                    break;
                                }

                                // Substituir vírgula por ponto no Amount
                                if (row > 1 && validColumns.Contains("amount", StringComparer.OrdinalIgnoreCase) && col == Array.IndexOf(validColumns, "amount") + 1)
                                {
                                    cellValue = cellValue.Replace(",", ".");
                                }

                                rowValues.Add(cellValue.Replace(",","."));
                            }

                            // Se a linha não for válida, definir a flag e continuar
                            if (!isValidRow && row > 1) // Ignora linhas com cabeçalhos inválidos após a primeira linha
                            {
                                linhasIgnoradas = true;
                                continue;
                            }

                            writer.WriteLine(string.Join(",", rowValues)); // Escreve a linha no CSV
                        }
                    }
                }
            }
            // Conversão do Excel para CSV
            string fileName = Path.GetFileNameWithoutExtension(inputFilePath) + ".csv";

            return outputFilePath;
        }

    }
}
 