using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using Therefore.API;

namespace AddInSamples
{
    [Guid("A6E16D8F-F4CA-471f-A350-0589967A10F5"), ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class MouseEventAddIn : ITheAddIn
    {
        public void GetHandledEvents(TheClientType client, TheEventSet eventSet)
        {
            // Register for all events
            eventSet.Add(TheEventType.CategoryFieldLeftMouseDown);
            eventSet.Add(TheEventType.CategoryFieldLeftMouseUp);
            eventSet.Add(TheEventType.CategoryFieldLeftDoubleClick);
            eventSet.Add(TheEventType.CategoryFieldRightMouseDown);
            eventSet.Add(TheEventType.CategoryFieldRightMouseUp);
            eventSet.Add(TheEventType.CategoryFieldRightDoubleClick);
            eventSet.Add(TheEventType.CategoryFieldMiddleMouseDown);
            eventSet.Add(TheEventType.CategoryFieldMiddleMouseUp);
            eventSet.Add(TheEventType.CategoryFieldMiddleDoubleClick);
        }

        public int HandleEvent(TheEvent e)
        {
            if (e.ObjectName == "From Folder")
            {
                e.CategoryDialog.IndexData.SetValueByFieldNo(e.ObjectID, e.EventType.ToString());
                e.CategoryDialog.Update();
            }

            return 0;
        }
    }
}
