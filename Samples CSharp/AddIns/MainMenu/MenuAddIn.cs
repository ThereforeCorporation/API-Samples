using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Therefore.API;

namespace AddInSamples
{
    [Guid("EC1DB05D-D4CA-4e60-B12A-BF4A6289EA12"), ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class MenuAddIn : ITheAddIn
    {
        public void GetHandledEvents(TheClientType clientType, TheEventSet eventSet)
        {
            // Sign up for the InitMenu and MenuClick events
            eventSet.Add(TheEventType.InitMenu);
            eventSet.Add(TheEventType.MenuClick);
        }

        public int HandleEvent(TheEvent e)
        {
            string[] titles = {"Canon &Europe", "Canon &Deutschland", "Canon &Italia", "Canon &United Kingdom"};
            string[] urls = {"http://www.canon-europe.com/", "http://www.canon.de/", "http://www.canon.it/", "http://www.canon.co.uk/"};
            const int offset = 1;
            switch (e.EventType)
            {
                case TheEventType.InitMenu:
                    // Insert a new entry into the help menu
                    e.Menu.Add("On the Web", 50);
                    TheMenu helpMenu = e.Menu.Find("On the Web");
                    for (int i = 0; i < titles.Length ; i++)
                         helpMenu.Add(titles[i], offset + i);
                    return 0;
 
                case TheEventType.MenuClick:
                    if (e.Menu.ID >= offset && e.Menu.ID < offset + urls.Length)
                        System.Diagnostics.Process.Start(urls[e.Menu.ID - offset]);//executing a URL starts the default browser
                    return 0;
            }
            return -1; // This should never happen. Returning -1 unregisters the incoming event type
        }
    }
}
