using System;
using System.Collections.Generic;
using System.Text;
using Therefore.API;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AddInSamples
{
    [Guid("02F95848-1E91-4061-AF7D-EC5727A86611"), ComVisible(true)]
    public class CustomWorkflowDialog : ITheAddIn
    {
        public void GetHandledEvents(TheClientType nClient,TheEventSet pEventSet)
        {
            //the OpenWorkflowInstance Event will be triggered when the workflow dialog 
            //is opened in TheNavigator
            pEventSet.Add(TheEventType.OpenWorkflowInstance);
        }

        public int HandleEvent(TheEvent pEvent)
        {
            //the ObjectID is the workflow Instance no. that can be seen in the Navigator
            int nInstanceNo = pEvent.ObjectID;
            int nTokenNo = pEvent.WFTokenNo;

            //connect to the server
            TheServer s = new TheServer();
            s.Connect(TheClientType.CustomApplication);

            //and load the workflow instance
            TheWFInstance wfInst = new TheWFInstance();
            wfInst.Load(s, nInstanceNo, nTokenNo);

            //check if the workflow instance belongs to a certain category
            //this can also be achieved by using the ProcessNo property
            //also check the current task of the workflow instance
            if (wfInst.ProcessName == "Files" && wfInst.CurrTaskName == "Test")
            {
                //create a workflow form and call it
                int nDocNo = wfInst.GetLinkedDocAt(0).DocNo;
                CustomWorkflowForm f = new CustomWorkflowForm(nDocNo);
                if(f.ShowDialog() == DialogResult.OK)
                {
                    if (f.bApproved)
                    {
                        //choose which task will be next
                        //each task can have multiple successors
                        //here you can decide which one will be called next
                        TheWFTask wfTask = wfInst.GetNextTaskAt(0);
                        wfInst.ClaimInstance(s);
                        wfInst.FinishCurrentTask(s, wfTask.TaskNo, "");
                        return 1;
                    }
                    else
                    {
                        TheWFTask wfTask = wfInst.GetNextTaskAt(1);
                        wfInst.ClaimInstance(s);
                        wfInst.FinishCurrentTask(s, wfTask.TaskNo, "");
                        return 1;
                    }
                }
                else
                    return 2;
            }
            return 0;
        }
    }
}
