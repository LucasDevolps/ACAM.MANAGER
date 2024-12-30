using ACAM.Data;
using ACAM.Domain.DTOs;
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
    public partial class frmImportarCAF : Form
    {
        public static ConfigurationBuilder _builder = new ConfigurationBuilder();
        public static IConfiguration _configuration;
        public static IServiceArquivo _serviceArquivo = new ServiceArquivo();
        public static IServicesRegistros _servicesRegistros = new ServicesRegistros();

        public frmImportarCAF()
        {
            _builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = _builder.Build();

            InitializeComponent();
        }

        private void frmImportarCAF_Load(object sender, EventArgs e)
        {
            try
            {
                string caminhoImportacao = Path.Combine(_configuration["Configuracoes:CaminhoLocal"], "CAF");

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
                progressBar1.Visible = true; 
                progressBar1.Style = ProgressBarStyle.Marquee; 
                btnProcessar.Enabled = false; 

                for (int i = 0; i < listFileAcams.Items.Count; i++)
                {
                    if (listFileAcams.GetItemChecked(i))
                    {
                        var filePath = (AcamFilesDto)listFileAcams.Items[i];

                        int idArquivo = await _serviceArquivo.InicioDoProcessoArquivo(filePath.FilePath);

                        await Task.Run(() =>
                        {
                            _servicesRegistros.ProcessaCAFCSV(idArquivo, filePath.FilePath);
                        });
                    }
                }
                MessageBox.Show("Arquivo processado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                progressBar1.Visible = false;
                btnProcessar.Visible = true;

                var logger = new LoggerRepository();
                logger.Log(ex);

                MessageBox.Show($"Erro ao processar o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar1.Visible = false;
                btnProcessar.Visible = true;
            }
        }
    }
}
