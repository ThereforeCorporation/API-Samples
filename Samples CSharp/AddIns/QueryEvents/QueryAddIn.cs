using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Therefore.API;

namespace AddInSamples
{
    [Guid("37C6D4CE-3667-430a-934C-EA8B4DFA7861"), ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class QueryAddIn : ITheAddIn
    {
        public void GetHandledEvents(TheClientType client, TheEventSet eventSet)
        {
            if (client == TheClientType.NavigatorClient)
                eventSet.Add(TheEventType.QueryFinished);
        }

        public int HandleEvent(TheEvent e)
        {
            // When a query finishes display a message box with query definition and results
            if (e.EventType == TheEventType.QueryFinished)
            {
                MessageBox.Show(e.MultiQuery.ToString() + "\r\n" + e.MultiQueryResult.ToString());
            }

            return 0;
        }
    }
}
