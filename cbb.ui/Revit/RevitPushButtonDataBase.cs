using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbb.ui.Revit
{
    /// <summary>
    /// Represents Revit push button data model.
    /// </summary>
    public class RevitPushButtonDataBase
    {
        #region properties
        /// <summary>
        /// Gets os sets the label of the button
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// Gets or sets the panel on wich button is hosted.
        /// </summary>
        public RibbonPanel Panel { get; set; }
        /// <summary>
        /// Gets or sets the command namespace path.
        /// </summary>
        public string CommandNamespacePath { get; set; }
        /// <summary>
        /// Gets or sets the name of the tooltip image.
        /// </summary>
        public string ToolTip { get; set; }
        /// <summary>
        /// Gets or sets the panel on wich button is hosted.
        /// </summary>
        public string IconImageName { get; set; }
        /// <summary>
        /// The name of Tool Tip Image
        /// </summary>
        public string ToolTipImageName { get; set; }

        #endregion

        #region public Methods

        #endregion

        #region constructor

        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of 
        /// </summary>
        public RevitPushButtonDataBase()
        {
        }
        #endregion
    }
}
