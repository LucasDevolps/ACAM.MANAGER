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
    public partial class FrmConfiguracao : Form
    {
        public static ConfigurationBuilder _builder = new ConfigurationBuilder();
        public static IConfiguration _configuration;

        public FrmConfiguracao()
        {
            _builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = _builder.Build();

            InitializeComponent();
        }

        public void FrmConfiguracao_Load(object sender, EventArgs e)
        {
            vlMaximo.Text = _configuration["Configuracoes:ValorMaximoAcam01"];
            // Lê o arquivo appsettings.json e carrega as ConnectionStrings
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Obtém as ConnectionStrings como dicionário
            var connectionStrings = configuration.GetSection("ConnectionStrings").GetChildren()
                                                  .ToDictionary(x => x.Key, x => x.Value);

            // Define o DataSource do ComboBox
            cmbConexao.DataSource = new BindingSource(connectionStrings, null);
            cmbConexao.DisplayMember = "Key";   // Exibe os nomes (Lucas, Vinicius, etc.)
            cmbConexao.ValueMember = "Value";   // Define os valores correspondentes

            txtArquivo.Text = _configuration["Configuracoes:CaminhoLocal"];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbmConexao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void strConexao_Click(object sender, EventArgs e)
        {

        }
    }
}
