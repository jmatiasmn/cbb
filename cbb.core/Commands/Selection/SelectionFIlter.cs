using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbb.core.Commands.Selection
{
    /// <summary>
    /// Selection filter based on the user provided category
    /// </summary>
    public class SelectionFIlter : ISelectionFilter
    {

        private string _category = "";
        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectionFilter"> ckass/see>/>
        /// </summary>
        /// <param name="category"></param>
        public SelectionFIlter(string category)
        {
            _category = category;
        }
        
        #endregion


        public bool AllowElement(Element elem)
        {
            return elem.Category.Name == _category;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
