using Autodesk.Revit.UI;
using cbb.core.Commands.Helpers.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbb.core.Commands.Helpers
{
    /// <summary>
    /// Display message helper methods.
    /// </summary>
    public static class Message
    {
        #region public methods
        /// <summary>
        /// Displayes the specified message.
        /// </summary>
        /// <param name="message"> The message to display in this window</param>
        /// <param name="type">the type of the message <see cref="WindowType"></param>
        public static void Display(string message, WindowType type)
        {
            string title = "";
            var  icon = TaskDialogIcon.TaskDialogIconNone;

            //Customize window based on type of message.
            switch (type)
            {
                case WindowType.Information:
                    title = "Information";
                    icon = TaskDialogIcon.TaskDialogIconInformation;
                    break;
                case WindowType.Warning:
                    title = "Waning";
                    icon |= TaskDialogIcon.TaskDialogIconWarning;
                    break;
                case WindowType.Error:
                    title = "Error";
                    icon |= TaskDialogIcon.TaskDialogIconError;
                    break;
                default:
                    break;
            }


            TaskDialog window = new TaskDialog(title)
            {
                MainContent = message,
                MainIcon = icon,
                CommonButtons = TaskDialogCommonButtons.Ok

            };
            window.Show();


        }
        #endregion
    }
}
