using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using Therefore.API;

namespace RoleBasedSecurity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private TheServer _server = null;
        private TheFolderItemList _roles = null;        

        public event PropertyChangedEventHandler PropertyChanged;

        private TheRoleAssignments _RoleAssignments { get; set; }
        public ObservableCollection<TheRoleAssignment> RoleAssignments { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            RoleAssignments = new ObservableCollection<TheRoleAssignment>();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _server = new TheServer();
                _server.Connect();

                TheFolderList folders = new TheFolderList();
                _roles = new TheFolderItemList();
                _server.GetObjects(TheObjectType.RoleObject, new TheAccessMask(), TheGetObjectFlags.GetNoFolders, out _roles, out folders);
                
                cmb_role.ItemsSource = _roles;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_server != null && _server.Connected)
                _server.Disconnect();
        }

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int categoryNo = Convert.ToInt32(txt_categoryno.Text);
                _RoleAssignments = new TheRoleAssignments();
                _RoleAssignments.Load(TheObjectType.CategoryObject, categoryNo, 0, _server);
                ckb_inheritance.IsChecked = _RoleAssignments.Inherit;
                UpdateRoleAssignments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_showdialog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckRoleAssignments();

                //the dialog loads all role assignments from the server and saves all changes directly on the server when clicking OK.
                //data in object will be reloaded.
                _RoleAssignments.ShowDialog(_server);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckRoleAssignments();

                TheFolderItem role = (TheFolderItem)cmb_role.SelectedItem;
                if (role == null)
                    throw new Exception("No role has been selected.");
                int userNo = Convert.ToInt32(txt_userno.Text);

                _RoleAssignments.Add(userNo, role.ID, txt_condition.Text, _server);
                UpdateRoleAssignments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckRoleAssignments()
        {
            if (_RoleAssignments == null)
                throw new Exception("Role assignments have to be loaded first.");
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckRoleAssignments();

                TheRoleAssignment assignment = (TheRoleAssignment)dg_roleassignments.SelectedItem;
                if (assignment == null)//nothing is selected
                    return;

                TheRoleAssignment a = _RoleAssignments.Get(assignment.UserNo, assignment.RoleNo);
                _RoleAssignments.Remove(assignment.UserNo, assignment.RoleNo);
                UpdateRoleAssignments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_condition_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckRoleAssignments();

                TheRoleAssignment assignment = (TheRoleAssignment)dg_roleassignments.SelectedItem;
                if (assignment == null)//nothing is selected
                    return;

                bool error = false;
                string tempCondition = assignment.Condition;
                do
                {
                    ChangeConditionWindow dlg = new ChangeConditionWindow(tempCondition);
                    dlg.Owner = this;
                    if (dlg.ShowDialog() != true)
                        break;
                    tempCondition = dlg.Condition;
                    try 
                    { 
                        assignment.SetCondition(dlg.Condition, _server); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        error = true;
                    }
                } while (error);
                dg_roleassignments.DataContext = null;
                dg_roleassignments.DataContext = this;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateRoleAssignments()
        {
            RoleAssignments.Clear();
            foreach (TheRoleAssignment a in _RoleAssignments)
                RoleAssignments.Add(a);
            PropertyChanged(this, new PropertyChangedEventArgs("RoleAssignments"));
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckRoleAssignments();
                _RoleAssignments.SaveChanges(_server);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ckb_inheritance_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckRoleAssignments();

                _RoleAssignments.EnableInheritance(_server);
                UpdateRoleAssignments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ckb_inheritance_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckRoleAssignments();

                _RoleAssignments.DisableInheritance(true);
                UpdateRoleAssignments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
