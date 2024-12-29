using ACAM.Data;
using ACAM.Domain.DTOs;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System.Data;

namespace ACAM.Management.Presentation
{
    public partial class frmImportarEConverter : Form
    {
        public static ConfigurationBuilder _builder = new ConfigurationBuilder();
        public static IConfiguration _configuration;
        public string _caminhoImportacao;

        public frmImportarEConverter()
        {
            _builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = _builder.Build();

            _caminhoImportacao = Path.Combine(_configuration["Configuracoes:CaminhoLocal"], "Convertidos");

            InitializeComponent();
        }

        private void frmImportarEConverter_Load(object sender, EventArgs e)
        {
            try
            {
                string caminhoImportacao = _configuration["Configuracoes:CaminhoLocal"];

                listFileAcams.DisplayMember = "FileName";
                listFileAcams.ValueMember = "FilePath";

                if (Directory.Exists(caminhoImportacao))
                {
                    // Busca arquivos com extensões .csv, .xls e .xlsx
                    string[] arquivos = Directory.GetFiles(caminhoImportacao, "*.*")
                                                 .Where(file => file.EndsWith(".xls", StringComparison.OrdinalIgnoreCase) ||
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

        private void btnProcessar_Click(object sender, EventArgs e)
        {
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
                        ConvertExcelToCsv(inputFilePath, _caminhoImportacao);
                    }
                }

                MessageBox.Show("Arquivos convertidos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                var logger = new LoggerRepository();
                logger.Log(ex);

                MessageBox.Show($"Erro ao processar os arquivos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ConvertExcelToCsv(string inputFilePath, string outputDirectory)
        {
            using (var package = new OfficeOpenXml.ExcelPackage(new FileInfo(inputFilePath)))
            {
                foreach (var worksheet in package.Workbook.Worksheets)
                {
                    string sanitizedSheetName = string.Join("_", worksheet.Name.Split(Path.GetInvalidFileNameChars()));
                    string outputFilePath = Path.Combine(outputDirectory, $"{Path.GetFileNameWithoutExtension(inputFilePath)}_{sanitizedSheetName}.csv");

                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    using (var writer = new StreamWriter(outputFilePath))
                    {
                        for (int row = 1; row <= rowCount; row++)
                        {
                            var rowValues = new List<string>();

                            for (int col = 1; col <= colCount; col++)
                            {
                                string cellValue = worksheet.Cells[row, col].Text;

                                // Substituir ?column? por Amount
                                if (row == 1 && cellValue.Equals("?column?", StringComparison.OrdinalIgnoreCase))
                                {
                                    cellValue = "Amount";
                                }

                                rowValues.Add(cellValue);
                            }

                            writer.WriteLine(string.Join(",", rowValues)); // Escreve a linha no CSV
                        }
                    }
                }
            }
        }


    }
}
 