using Autodesk.Revit.UI;
using cbb.core;
using cbb.res;
using System;
namespace cbb.ui.Revit
{
    /// <summary>
    /// The Revit push button methods.
    /// </summary>
    public class RevitPushButton
    {
        /// <summary>
        /// Creates the push button based on data provided in <see cref="RevitPushButtonDataBase"/>
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static PushButton Create(RevitPushButtonDataBase data)
        {
            //The button name based on unique identifier.
            string btnDataName = Guid.NewGuid().ToString();

            //Sets the button Data
            var btnData = new PushButtonData(btnDataName, data.Label, CoreAssembly.GetAssemblyLocation(), data.CommandNamespacePath)
            {
                LargeImage = ResourceImage.GetIcon(data.IconImageName),
                ToolTipImage = ResourceImage.GetIcon(data.ToolTipImageName)
            };

            //Returb created Button and host it on panel provided in required data model.
            return data.Panel.AddItem(btnData) as PushButton;
        }
    }
}
