using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbb.core.Commands.Helpers.Type
{
    /// <summary>
    /// Specific window message type
    /// </summary>
    public enum WindowType
    {
        /// <summary>
        /// The window to show information.
        /// </summary>
        Information,
        /// <summary>
        /// The window to show warning message
        /// </summary>
        Warning,
        /// <summary>
        /// The window to shor errror message.
        /// </summary>
        Error
    }
}
