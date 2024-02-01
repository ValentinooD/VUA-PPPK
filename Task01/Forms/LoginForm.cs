using Task01.Dal;
using Task01.Forms;
using Task01.Models;

namespace Task01
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            SetError(null);


            // it's very annoying to be typing it every time I open it
            // hopefully I remember to remove this before committing
            tbServer.Text = "pppkdb3.database.windows.net";
            tbUsername.Text = "sas";
            tbPassword.Text = "MyPa$$w0rd";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Repository.Login(
                        tbServer.Text,
                        tbUsername.Text,
                        tbPassword.Text
                    );

                new MainForm().Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                SetError("Could not login. Please try again");
            }
        }

        private void SetError(string? error)
        {
            lbError.Visible = error != null;
            lbError.Text = error;
        }
    }
}