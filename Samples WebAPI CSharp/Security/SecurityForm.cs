using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using Therefore.WebAPI.Service.Contract.v0001.Services;
using Therefore.WebAPI.Service.Contract.v0001.Messages;
using Therefore.WebAPI.Service.Contract.v0001.Enums;
using Common;

namespace Security
{
    public partial class SecurityForm : Form
    {
        public SecurityForm()
        {
            InitializeComponent();
        }

        private ChannelFactory<IThereforeService> thereforeService;

        private void btn_get_rights_Click(object sender, EventArgs e)
        {
            try
            {
                // 1B. Create a channel to the web service endpoint
                IThereforeService service = thereforeService.CreateChannel();

                // 2. Create request parameters
                GetObjectRightsParams parameters = new GetObjectRightsParams();
                parameters.ObjectType = WSObjectType.CategoryObject;
                parameters.ObjectNo = CategoryIds.FilesCategory;
                parameters.SubObjNo = 0; //default value

                // 3. Get rights for an object
                GetPermissionConstantsResponse premconst = service.GetPermissionConstants(new GetPermissionConstantsParams());
                GetObjectRightsResponse response = service.GetObjectRights(parameters);

                // 4. Print the each user and his/her permissions on the loaded object
                MessageBox.Show(String.Format("Object rights mask: {0}.\nAccess permissions: {1}\nHas Admin permissions: {2}", 
                    Convert.ToString(response.AccessMask.Value),
                    (response.AccessMask.Value & premconst.PermissionConstants.Access) != 0,
                    (response.AccessMask.Value & premconst.PermissionConstants.Administrator) != 0));
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void SecurityForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 1A. Get user credentials
                if (thereforeService == null)
                    if (null == (thereforeService = ThereforeServiceConnection.CreateChannelFactory()))
                        this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SecurityForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thereforeService != null)
                thereforeService.Close();
        }
    }     
}