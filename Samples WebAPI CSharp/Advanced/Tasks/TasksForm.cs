using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using Common;
using SharedServiceReference.ServiceRef_Update_it;
using SharedServiceReference;

namespace Tasks
{
    public partial class TasksForm : Form
    {
        private WSTaskInfo taskInfo;
        private WSTask task;

        public TasksForm()
        {
            InitializeComponent();
        }

        private ThereforeServiceClient thereforeClient;

        private void btn_loadtaskinfo_Click(object sender, EventArgs e)
        {
            try
            {
                // 2. Create request parameters
                GetTaskInfoParams parameters = new GetTaskInfoParams();
                parameters.TaskNo = Convert.ToInt32(txt_taskID.Text);

                // 3. Execute method to get the task info
                GetTaskInfoResponse response = thereforeClient.GetTaskInfo(new GetTaskInfoRequest { parameters = parameters }).GetTaskInfoResult;
                taskInfo = response.TaskInfo;

                txt_docno_info.Text = response.TaskInfo.DocNo.ToString();
                txt_mode_info.Text = ((int)response.TaskInfo.Mode).ToString();
                txt_createdby.Text = response.TaskInfo.CreatedBy.ToString();
                txt_assignedto.Text = response.TaskInfo.AssignedToName.ToString();
                txt_lastupdate.Text = response.TaskInfo.LastUpdate.ToString();
                txt_createdbyuser.Text = response.TaskInfo.CreatedBy.ToString();
                txt_assignedtouser.Text = response.TaskInfo.IsAssignedToUser.ToString();
                txt_subject_info.Text = response.TaskInfo.Subject;
                txt_startdate_info.Text = response.TaskInfo.StartDate == null ? "" : response.TaskInfo.StartDate.ToString();
                txt_duedate_info.Text = response.TaskInfo.DueDate == null ? "" : response.TaskInfo.DueDate.ToString();
                txt_usernoassigned.Text = response.TaskInfo.AssignedToNumber.ToString();
                txt_instructions_info.Text = response.TaskInfo.Instructions;
                txt_comment.Text = response.TaskInfo.Comment;
                txt_status.Text = ((int)response.TaskInfo.Status).ToString();
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
                // 2. Create request parameters
                StartTaskParams parameters = new StartTaskParams();
                parameters.Task = new WSTask();

                parameters.Task.DocNo = Convert.ToInt32(txt_docno_def.Text);
                parameters.Task.Mode = (WSTaskMode)Convert.ToInt32(txt_mode_def.Text);
                parameters.Task.UserNo = Convert.ToInt32(txt_userno.Text);
                parameters.Task.Subject = txt_subject_def.Text;
                parameters.Task.StartDate = DateTime.SpecifyKind(Convert.ToDateTime(txt_startdate_def.Text), DateTimeKind.Unspecified);
                parameters.Task.DueDate = DateTime.SpecifyKind(Convert.ToDateTime(txt_duedate_def.Text), DateTimeKind.Unspecified);
                parameters.Task.Instructions = txt_instructions_def.Text;

                StartTaskResponse response = thereforeClient.StartTask(new StartTaskRequest { parameters = parameters }).StartTaskResult;

                MessageBox.Show("A new task has been created and started. New Task No = " + response.TaskNo);
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

                // 2. Create request parameters
                CompleteTaskParams parameters = new CompleteTaskParams();
                parameters.TaskNo = taskInfo.TaskNo;
                parameters.Comment = txt_comment.Text;
                parameters.TaskDecision = (WSTaskDecision)Enum.Parse(typeof(WSTaskDecision), txt_decision.Text);

                // 3. Execute method to complete the task
                thereforeClient.CompleteTask(new CompleteTaskRequest { parameters = parameters });

                MessageBox.Show("Task completed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_update_comment_Click(object sender, EventArgs e)
        {
            try
            {
                if (taskInfo == null)
                {
                    MessageBox.Show("A task info object has to be loaded for this operation.");
                    return;
                }

                // 2. Create request parameters
                UpdateTaskCommentParams parameters = new UpdateTaskCommentParams();

                parameters.TaskNo = taskInfo.TaskNo;
                parameters.Comment = txt_comment.Text;

                // 3. Execute method to update the task info
                thereforeClient.UpdateTaskComment(new UpdateTaskCommentRequest { parameters = parameters });
                MessageBox.Show("The task info has been updated.");
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
                // 2. Create request parameters
                GetTaskParams parameters = new GetTaskParams();
                parameters.TaskNo = Convert.ToInt32(txt_taskID.Text);

                // 3. Execute method to load the task
                GetTaskResponse response = thereforeClient.GetTask(new GetTaskRequest { parameters = parameters }).GetTaskResult;

                task = response.Task;

                txt_docno_def.Text = response.Task.DocNo.ToString();
                txt_mode_def.Text = ((int)response.Task.Mode).ToString();
                txt_userno.Text = response.Task.UserNo.ToString();
                txt_subject_def.Text = response.Task.Subject;
                txt_startdate_def.Text = response.Task.StartDate.ToString();
                txt_duedate_def.Text = response.Task.DueDate.ToString();
                txt_instructions_def.Text = response.Task.Instructions;
                chk_notifiyonupdate.Checked = response.Task.NotifyOnUpdate;
                chk_notifyusers.Checked = response.Task.NotifyOnAssign;
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

                // 2. Create request parameters
                UpdateTaskParams parameters = new UpdateTaskParams();
                
                task.TaskNo = Convert.ToInt32(txt_taskID.Text);
                task.DocNo = Convert.ToInt32(txt_docno_def.Text);
                task.Mode = (WSTaskMode)Convert.ToInt32(txt_mode_def.Text);
                task.UserNo = Convert.ToInt32(txt_userno.Text);
                task.Subject = txt_subject_def.Text;
                task.StartDate = DateTime.SpecifyKind(Convert.ToDateTime(txt_startdate_def.Text), DateTimeKind.Unspecified);
                task.DueDate = DateTime.SpecifyKind(Convert.ToDateTime(txt_duedate_def.Text), DateTimeKind.Unspecified);
                task.Instructions = txt_instructions_def.Text;

                parameters.Task = task;

                thereforeClient.UpdateTask(new UpdateTaskRequest { parameters = parameters });

                MessageBox.Show("The task definition has been updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_SetStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (taskInfo == null)
                {
                    MessageBox.Show("A task info object has to be loaded for this operation.");
                    return;
                }

                // 2. Create request parameters
                SetTaskStatusParams parameters = new SetTaskStatusParams();
                parameters.TaskNo = taskInfo.TaskNo;
                parameters.Comment = txt_comment.Text;
                parameters.TaskStatus = (WSTaskStatus)Convert.ToInt32(txt_status.Text);

                // 3. Execute method to complete the task
                thereforeClient.SetTaskStatus(new SetTaskStatusRequest { parameters = parameters });

                MessageBox.Show("Task status has been updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TasksForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Create a client of the web service endpoint.
                if (thereforeClient == null)
                    if (null == (thereforeClient = ClientConnection.CreateClient()))
                        this.Close();


                // Populate decision list
                txt_decision.Items.Add(WSTaskDecision.Negative);
                txt_decision.Items.Add(WSTaskDecision.Positive);
                txt_decision.Items.Add(WSTaskDecision.Undefined);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TasksForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thereforeClient != null)
                thereforeClient.Close();
        }
    }
}
