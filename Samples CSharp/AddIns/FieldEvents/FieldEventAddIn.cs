using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Therefore.API;

namespace AddInSamples
{
    [Guid("0EC3AD9D-2B17-4583-81A7-8255A4CF0863"), ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class FieldEventAddIn : ITheAddIn
    {

        public void GetHandledEvents(TheClientType nClient, TheEventSet pEventSet)
        {
            pEventSet.AddAll();
            MessageBox.Show("FieldEventsAddIn successfully registered.");
        }

        public int HandleEvent(TheEvent pEvent)
        {
            MessageBox.Show("FieldEventsAddIn handles event.\r\n" + pEvent.ToString());
            return 0;
        }
    }
}
