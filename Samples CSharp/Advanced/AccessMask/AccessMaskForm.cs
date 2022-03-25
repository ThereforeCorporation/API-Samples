using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Therefore.API;

namespace AccessMask
{
    public partial class AccessMaskForm : Form
    {
        private TheServer _server;

        public AccessMaskForm()
        {
            InitializeComponent();
            _server = new TheServer();
            _server.Connect();
        }

        ~AccessMaskForm()
        {
            if (_server.Connected)
                _server.Disconnect();
        }

        private void AccesMaskForm_Load(object sender, EventArgs e)
        {
            try
            {
                String[] types = Enum.GetNames(typeof(TheObjectType));
                cmb_objtype.Items.AddRange(types);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            try
            {
                //load an object and perform 
                TheObjectType type = (TheObjectType)Enum.Parse(typeof(TheObjectType), (String)cmb_objtype.SelectedItem);
                int id = Convert.ToInt32(txt_objno.Text);
                int subid = Convert.ToInt32(txt_subobjno.Text);

                TheAccessMask mask = new TheAccessMask();
                mask = _server.GetObjectRightsEx(type, id, subid);
                
                txt_output.Text = mask.ToString() + "\r\n";
                txt_output.Text += "Has Manage Link permission: " + mask.ContainsPermission(mask.PermissionConstants.DocumentManageLink).ToString() + "\r\n";
                mask.AddPermission(mask.PermissionConstants.DocumentManageLink);
                mask.RemovePermission(mask.PermissionConstants.DocumentPrint);
                txt_output.Text += mask.ToString() + "\r\n";
                txt_output.Text += "Has Manage Link permission: " + mask.ContainsPermission(mask.PermissionConstants.DocumentManageLink).ToString() + "\r\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_am2pl_Click(object sender, EventArgs e)
        {
            try
            {
                TheObjectType type = (TheObjectType)Enum.Parse(typeof(TheObjectType), (String)cmb_objtype.SelectedItem);
                int id = Convert.ToInt32(txt_objno.Text);
                int subid = Convert.ToInt32(txt_subobjno.Text);

                TheAccessMask mask = new TheAccessMask();
                mask = _server.GetObjectRightsEx(type, id, subid);
                IThePermissionList permlist = new ThePermissionList();
                permlist.AddAccessMask(mask, true, false);

                txt_output.Text = permlist.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_pl2am_Click(object sender, EventArgs e)
        {
            try
            {
                TheObjectType type = (TheObjectType)Enum.Parse(typeof(TheObjectType), (String)cmb_objtype.SelectedItem);
                int id = Convert.ToInt32(txt_objno.Text);
                int subid = Convert.ToInt32(txt_subobjno.Text);

                TheSecurity sec = new TheSecurity();
                sec.LoadObject(type, id, subid, _server);
                TheUser user = _server.GetConnectedUser(false);
                ThePermissionList permlist = sec.GetPermissions(user);
                if (permlist == null)
                {
                    txt_output.Text = "No permission list for logged in user.";
                    return;
                }
                txt_output.Text = permlist.ToString() + "\r\n\r\n";

                TheAccessMask allowmask = permlist.GetAsAccessMask(true, false);
                TheAccessMask denymask = permlist.GetAsAccessMask(false, true);
                TheAccessMask combinedmask = permlist.GetAsAccessMask(true, true);
                txt_output.Text += "Allow " + allowmask.ToString() + "\r\n";
                txt_output.Text += "Deny " + denymask.ToString() + "\r\n";
                txt_output.Text += "Combined " + combinedmask.ToString() + "\r\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_getobjects_Click(object sender, EventArgs e)
        {
            try
            {
                TheObjectType type = (TheObjectType)Enum.Parse(typeof(TheObjectType), (String)cmb_objtype.SelectedItem);
                int id = Convert.ToInt32(txt_objno.Text);
                int subid = Convert.ToInt32(txt_subobjno.Text);
                TheFolderItemList itemlist = new TheFolderItemList();
                TheFolderList folderlist = new TheFolderList();
                TheAccessMask mask = new TheAccessMask();
                mask.AddPermission(mask.PermissionConstants.DocumentManageLink);
                _server.GetObjects(type, mask, TheGetObjectFlags.GetNoFolders, out itemlist, out folderlist);

                txt_output.Text = itemlist.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
