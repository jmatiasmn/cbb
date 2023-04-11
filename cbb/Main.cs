using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbb
{
    public class Main : IExternalApplication
    {
        /// <summary>
        /// Calleed when revit Starts up
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Failed;
        }

        /// <summary>
        /// Calleed when revit Starts up
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Result OnStartup(UIControlledApplication application)
        {
            var ui = new SetupInterface();
            ui.Initialize(application);
            return Result.Succeeded;
        }
    }
}
