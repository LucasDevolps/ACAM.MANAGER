using ACAM.Data;
using ACAM.Domain.Interface.Service;
using ACAM.Service;
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
    public partial class FrmGerarACAMSaida : Form
    {
        public static IServicesRegistros _servicesRegistros = new ServicesRegistros();

        public FrmGerarACAMSaida()
        {
            InitializeComponent();

            try
            {
                var dataTable = _servicesRegistros.ListarArquivosJaProcessadosDoBanco();

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    cmbArquivo.DataSource = dataTable;

                    cmbArquivo.DisplayMember = "Nome_arquivo";
                    cmbArquivo.ValueMember = "Id_arquivo";
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
        public void cmbArquivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

        }
    }
}
