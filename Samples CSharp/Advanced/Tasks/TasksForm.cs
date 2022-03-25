using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Therefore.API;

namespace Tasks
{
    public partial class TasksForm : Form
    {
        private TheServer   server;
        private TheTaskInfo taskInfo;
        private TheTask     task;

        public TasksForm()
        {
            InitializeComponent();
        }

        private void btn_loadtaskinfo_Click(object sender, EventArgs e)
        {
            try
            {
                taskInfo = new TheTaskInfo();
                taskInfo.Load(Server, Convert.ToInt32(txt_taskID.Text));

                txt_docno_info.Text = taskInfo.DocNo.ToString();
                txt_mode_info.Text = ((int)taskInfo.Mode).ToString();
                txt_createdby.Text = taskInfo.CreatedBy.ToString();
                txt_assignedto.Text = taskInfo.AssignedTo.ToString();
                txt_lastupdate.Text = taskInfo.LastUpdate.ToString();
                txt_createdbyuser.Text = taskInfo.CreatedByUser.ToString();
                txt_assignedtouser.Text = taskInfo.AssignedToUser.ToString();
                txt_subject_info.Text = taskInfo.Subject;
                txt_startdate_info.Text = taskInfo.StartDate.ToString();
                txt_duedate_info.Text = taskInfo.DueDate.ToString();
                txt_usernoassigned.Text = taskInfo.UserNoAssigned.ToString();
                txt_instructions_info.Text = taskInfo.Instructions;
                txt_comment.Text = taskInfo.Comment;
                txt_status.Text = ((int)taskInfo.Status).ToString(); 
                txt_decision.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_startnew_Click(object sender, EventArgs e)
        {
            try
            {
                if (task == null)
                    task = new TheTask();

                task.DocNo = Convert.ToInt32(txt_docno_def.Text);
                task.Mode = (TheTaskMode)Convert.ToInt32(txt_mode_def.Text);
                task.UserNo = Convert.ToInt32(txt_userno.Text);
                task.Subject = txt_subject_def.Text;
                task.StartDate = Convert.ToDateTime(txt_startdate_def.Text);
                task.DueDate = Convert.ToDateTime(txt_duedate_def.Text);
                task.Instructions = txt_instructions_def.Text;
                task.Start(Server);
                MessageBox.Show("A new task has been started.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_complete_Click(object sender, EventArgs e)
        {
            try
            {
                if (taskInfo == null)
                {
                    MessageBox.Show("A task info object has to be loaded for this operation.");
                    return;
                }

                taskInfo.Comment = txt_comment.Text;
                taskInfo.SetStatus((TheTaskStatus)Convert.ToInt32(txt_status.Text));
                taskInfo.Complete(Server, (TheTaskDecision)Convert.ToInt32(txt_decision.Text));
                MessageBox.Show("Task completed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_update_info_Click(object sender, EventArgs e)
        {
            try
            {
                if (taskInfo == null)
                {
                    MessageBox.Show("A task info object has to be loaded for this operation.");
                    return;
                }

                taskInfo.Comment = txt_comment.Text;
                taskInfo.SetStatus((TheTaskStatus)Convert.ToInt32(txt_status.Text));
                taskInfo.SaveChanges(Server);
                MessageBox.Show("The task info has been updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            try
            {
                if (taskInfo != null)
                    taskInfo.View(Server);
                else
                    MessageBox.Show("A task info object has to be loaded in order to view a task.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_loadtaskdefinition_Click(object sender, EventArgs e)
        {
            try
            {
                task = new TheTask();
                task.Load(Server, Convert.ToInt32(txt_taskID.Text));

                txt_docno_def.Text = task.DocNo.ToString();
                txt_mode_def.Text = ((int)task.Mode).ToString();
                txt_userno.Text = task.UserNo.ToString();
                putAssignTo(task.AssignTo);
                txt_subject_def.Text = task.Subject;
                txt_startdate_def.Text = task.StartDate.ToString();
                txt_duedate_def.Text = task.DueDate.ToString();
                txt_instructions_def.Text = task.Instructions;
                chk_notifiyonupdate.Checked = task.NotifyOnUpdate;
                chk_notifyusers.Checked = task.NotifyUsers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_addusers_Click(object sender, EventArgs e)
        {
            try
            {
                if (task == null)
                    task = new TheTask();
                TheUserList userlist = task.AssignTo;
                Server.ShowUserSelectionDialog(ref userlist, TheUserQueryFlags.FindAllUsers);
                task.AssignTo = userlist;
                putAssignTo(userlist);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_update_def_Click(object sender, EventArgs e)
        {
            try
            {
                if (task == null)
                {
                    MessageBox.Show("A task definition object has to be loaded for this operation.");
                    return;
                }

                task.DocNo = Convert.ToInt32(txt_docno_def.Text);
                task.Mode = (TheTaskMode)Convert.ToInt32(txt_mode_def.Text);
                task.UserNo = Convert.ToInt32(txt_userno.Text);
                task.Subject = txt_subject_def.Text;
                task.StartDate = Convert.ToDateTime(txt_startdate_def.Text);
                task.DueDate = Convert.ToDateTime(txt_duedate_def.Text);
                task.Instructions = txt_instructions_def.Text;
                task.SaveChanges(Server);
                MessageBox.Show("The task definition has been updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void putAssignTo(TheUserList userlist)
        {
            if (userlist == null)
                return;
            for(int i=0;i<userlist.Count;i++)
            {
                TheUser user = userlist[i];
                if(i>0)
                    txt_assignto.Text += ", ";
                txt_assignto.Text += user.DisplayName;
            }
        }

        private TheServer Server
        {
            get
            {
                if (server == null)
                    server = new TheServer();
                if (!server.Connected)
                    server.Connect();
                return server;
            }
        }
    }
}
