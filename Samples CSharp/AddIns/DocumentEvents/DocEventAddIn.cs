using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Therefore.API;

namespace AddInSamples
{
    [Guid("9DDC5D67-A86F-4b57-A862-C75F7F51B124"), ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class DocEventAddIn : ITheAddIn
    {
        public void GetHandledEvents(TheClientType client, TheEventSet eventSet)
        {
            eventSet.Add(TheEventType.RetrieveDocument);
            eventSet.Add(TheEventType.DocumentRetrieved);
        }

        public int HandleEvent(TheEvent e)
        {
            // RetrieveDocument occurs BEFORE the document is being retrieved
            // Ask the user if he/she really wants to retrieve it
            if (e.EventType == TheEventType.RetrieveDocument)
            {
                DialogResult result = MessageBox.Show("Do you really want to retrieve the document from Therefore™?", "Retrieve Document", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    return 0;
                else if (result == DialogResult.No)
                    return 1;
            }
            // DocumentRetrieved occurs AFTER the document has been retrieved
            // Display a success message
            else if (e.EventType == TheEventType.DocumentRetrieved)
            {
                MessageBox.Show("Document successfully retrieved from Therefore™.");
            }

            return 0;
        }
    }
}
