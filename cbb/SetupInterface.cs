using Autodesk.Revit.UI;
using cbb.core;
using cbb.res;
using cbb.ui.Revit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbb
{
    /// <summary>
    /// Setup whole plugin interface with tabs, panels, buttons, etc...
    /// </summary>
    public class SetupInterface
    {
        #region constructor

        public SetupInterface()
        {
        }

        #endregion

        #region public methods
        /// <summary>
        /// Initializes all interface elements on custom created Revit Tab.
        /// </summary>
        /// <param name="uiapp"></param>
        public void Initialize(UIControlledApplication app)
        {
            //Create ribbon tab
            string tabName = "Circle's BIM Blog";
            app.CreateRibbonTab(tabName);

            //Create the annotat commands panel
            RibbonPanel panel = app.CreateRibbonPanel(tabName, "Annotation Commands");

            //Populate button data model
            var TagWallButtonData = new RevitPushButtonDataBase()
            {
                Label = "Tag Wall",
                Panel = panel,
                ToolTip = "This is some semple tooltip",
                IconImageName = "icons8-futurama-bender-32.png",
                CommandNamespacePath = TagWallLayersCommand.GetPath(),
                ToolTipImageName = "icons8-futurama-bender-320.png"
            };

            //Create button from provided data.
            RevitPushButton.Create(TagWallButtonData);
        }
        #endregion
    }
}
