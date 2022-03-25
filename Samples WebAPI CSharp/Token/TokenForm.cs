using SharedServiceReference;
using SharedServiceReference.ServiceRef_Update_it;
using System;
using System.Windows.Forms;

namespace Token
{
    public partial class TokenForm : Form
    {
        public TokenForm()
        {
            InitializeComponent();
        }

        private void btnRequestToken_Click(object sender, EventArgs e)
        {
            // 1. Create a client of the web service endpoint.
            ThereforeServiceClient thereforeClient = ClientConnection.CreateClient();

            if (thereforeClient == null)
                return;

            try
            {
                //take user name to reuse.
                txtUserName.Text = thereforeClient.ClientCredentials.UserName.UserName;

                // 2. Create request parameters
                GetConnectionTokenParams parameters = new GetConnectionTokenParams();

                // 3. Execute the query and get result
                GetConnectionTokenResponse response = thereforeClient.GetConnectionToken(new GetConnectionTokenRequest { parameters = parameters }).GetConnectionTokenResult;

                string token = response.Token;
                txtGet.Text = token;
                txtUse.Text = token;

                txtLog.Text += string.Format("{0}: Token has been created{1}", DateTime.Now, Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (thereforeClient != null)
                    thereforeClient.Close();
            }
        }

        private void btnUseToken_Click(object sender, EventArgs e)
        {
            ThereforeServiceClient thereforeTokenClient = ClientConnection.CreateClient(txtUserName.Text, txtUse.Text);

            try
            {
                // 2. Create request parameters
                GetConnectedUserParams parameters = new GetConnectedUserParams();

                // 3. Execute the query and get result
                GetConnectedUserResponse response = thereforeTokenClient.GetConnectedUser(new GetConnectedUserRequest { parameters = parameters }).GetConnectedUserResult;
                txtLog.Text += string.Format("{0}: Token was used. Connected user name: {1}, user type: {2}.{3}", DateTime.Now, response.User.UserName, response.User.UserType, Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
