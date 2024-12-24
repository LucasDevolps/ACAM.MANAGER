using ACAM.Data;
using ACAM.Domain.Interface.Repository;

namespace ACAM.Management.Presentation
{
    public partial class ErrorForm : Form
    {
        private readonly ILogger _logger;

        public ErrorForm(Exception exception)
        {
            InitializeComponent();

            lblErrorMessage.Text = exception.Message;

            _logger = new LoggerRepository();

            try
            {
                _logger.Log(exception);
            }
            catch (Exception logEx)
            {
                Console.WriteLine($"Erro ao salvar o log: {logEx.Message}");
            }
        }
    }
}
