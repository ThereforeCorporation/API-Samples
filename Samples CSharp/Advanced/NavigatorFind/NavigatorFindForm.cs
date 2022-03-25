using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Therefore.API;

namespace NavigatorFind
{
    public partial class NavigatorFindForm : Form
    {
        public NavigatorFindForm()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                TheServer server = new TheServer();
                server.Connect(TheClientType.NavigatorClient);

                TheIndexData ixData = new TheIndexData();
                ixData.SetCategory("Files", server);
                ixData["Extension"] = this.cmbExtension.SelectedItem.ToString();
                ixData["From_Folder"] = this.txtFolder.Text;

                TheApplication app = new TheApplication();
                app.NavigatorFind(ixData, TheNavigatorFindFlags.ExecuteQuery, 1);

                server.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
    }
}
