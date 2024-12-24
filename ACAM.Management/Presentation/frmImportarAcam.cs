﻿using Microsoft.Extensions.Configuration;
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
                    if (listFileAcams.GetItemChecked(i) == true)
                    {
                        var filePath = (AcamFilesDto)listFileAcams.Items[i];

                        int idFile = await _serviceArquivo.InicioDoProcessoArquivo(connectionString, filePath.FilePath);

                        // Processar os arquivos de forma assíncrona
                        await Task.Run(() =>
                        {
                            _servicesRegistros.ProcessarCsvPorStreaming(filePath.FilePath, idFile);
                            _servicesRegistros.SalvarNaTabelaRestritiva(45000, idFile);
                            _servicesRegistros.GerarRelatorioSaidaProcessamento(idFile);
                        });

                        // Atualizar os DataGrids após o processamento
                        dataGridView1.DataSource = await Task.Run(() => _servicesRegistros.GerarRelatorioVisualTotal(idFile));
                        dataGridView2.DataSource = await Task.Run(() => _servicesRegistros.GerarRelatorioVisualNaoProcessados(idFile));

                        MessageBox.Show("Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
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

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}