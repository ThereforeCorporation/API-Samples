using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.InteropServices;
using Therefore.API;

namespace AddInSamples
{
    [Guid("CC500130-1236-4a6b-A98E-F5375506F5A4"), ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class VerifyAddIn : ITheAddIn
    {
        private const string regexNonDigits = @"[^0-9]";
        private const string regexEmailAddress = @"^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$";

        private bool validInvoiceNo = true;
        private bool validInvDate = true;
        private bool validInfo = true;

        public void GetHandledEvents(TheClientType clientType, TheEventSet eventSet)
        {
            // Register to receive the CategoryFieldChanged event
            eventSet.Add(TheEventType.CategoryFieldChanged);
        }

        public int HandleEvent(TheEvent e)
        {
            // Extract necessary info from the event (for convenience only)
            TheCategoryDialog dlg = e.CategoryDialog;
            int fieldNo = e.ObjectID;
            string fieldName = e.ObjectName;
            object val = e.IndexData.GetValueByFieldNo(fieldNo);

            if (fieldName == "InvoiceNo") // InvoiceNo field has changed
            {
                // The InvoiceNo must be empty or contain only digits
                validInvoiceNo = (val == null || !(val is string) || Regex.Match((string)val, regexNonDigits).Length == 0);

                // update the background color of the field, set/reset the tool tip and enable/disable the "Execute" button
                MarkValid(dlg, fieldNo, validInvoiceNo, "InvoiceNo can only contain digits (0-9)");
            }
            else if (fieldName == "InvDate") // Date field has changed
            {
                // The Date field must not contain a date in the future
                validInvDate = (val == null || !(val is DateTime) || (DateTime)val <= DateTime.Now);

                // update the background color of the field, set/reset the tool tip and enable/disable the "Execute" button
                MarkValid(dlg, fieldNo, validInvDate, "Date must not be in the future");
            }
            else if (fieldName == "Info") // Info field has changed
            {
                // The Info field must be empty or contain a valid email address
                validInfo = (val == null || !(val is string) || Regex.Match((string)val, regexEmailAddress).Length > 0);

                // update the background color of the field, set/reset the tool tip and enable/disable the "Execute" button
                MarkValid(dlg, fieldNo, validInfo, "Info must be empty or contain a valid email address");
            }

            return 0;
        }

        private void MarkValid(TheCategoryDialog dlg, int fieldNo, bool valid, string errMsg)
        {
            if (valid) // Field is valid
            {
                // Remove the red marks from all fields (if any)
                dlg.ResetBackgroundColor(fieldNo);

                // Remove the error tool tip (if any)
                dlg.ResetToolTip(fieldNo);
            }
            else // Field is invalid
            {
                // Mark the field red
                dlg.SetBackgroundColor(fieldNo, 255, 0, 0);

                // Set the tool tip for the field (to explain why it is invalid)
                dlg.SetToolTip(fieldNo, errMsg);
            }

            // Enable the "Execute" button if (and only if) all checked fields are valid
            dlg.EnableButton(TheButtonID.ExecuteButton, (validInvDate && validInvoiceNo && validInfo));
        }
    }
}
