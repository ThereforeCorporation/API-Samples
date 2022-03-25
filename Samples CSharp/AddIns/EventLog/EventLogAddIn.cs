using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using Therefore.API;

namespace AddInSamples
{
    [Guid("781D8934-FCDC-4594-9696-A3ED28B32849"), ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class EventLogAddIn : ITheAddIn
    {
        private string eventLog;

        public void GetHandledEvents(TheClientType client, TheEventSet eventSet)
        {
            // Register for all events
            eventSet.AddAll();
        }

        public int HandleEvent(TheEvent e)
        {
            // Append the current event to a string
            eventLog += DateTime.Now.ToString() + " ... " + e.ToString() + "\r\n";

            // Write the event log to a file when the application exits
            if (e.EventType == TheEventType.ExitApplication)
            {
                //this file can be found in the Therefore install directory
                StreamWriter writer = new StreamWriter("eventLog.txt");
                writer.WriteLine(eventLog);
                writer.Flush();
                writer.Close();
            }

            return 0;
        }
    }
}
