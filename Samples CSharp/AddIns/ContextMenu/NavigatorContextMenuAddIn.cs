using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Therefore.API;

namespace AddInSamples
{
    [Guid("BC93DF7C-0E7A-4240-AA19-5858687409BB"), ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class NavigatorContextMenuAddIn : ITheAddIn
    {
        public void GetHandledEvents(TheClientType clientType, TheEventSet eventSet)
        {
            if (clientType == TheClientType.NavigatorClient)
            {
                eventSet.Add(TheEventType.InitContextMenu);
                eventSet.Add(TheEventType.ContextMenuClick);
            }
        }

        public int HandleEvent(TheEvent e)
        {
            switch (e.EventType)
            {
                case TheEventType.InitContextMenu:
                    // Insert a new entry into the help menu
                    e.Menu.AddSeparator();
                    e.Menu.Add("&Show index data message box", 1);
                    return 0;

                case TheEventType.ContextMenuClick:
                    if (e.Menu.ID == 1) // If our menu item was clicked
                    {
                        foreach (TheIndexData ix in e.IndexDataList)
                            MessageBox.Show(ix.ToString());
                    }
                    return 0;
            }

            return -1; // This should never happen; returning -1 unregisters the incoming event type
        }
    }
}
