﻿
using System.Reflection;

namespace cbb.res
{
    /// <summary>
    /// Resource assembly helpher methods.
    /// </summary>
    public class ResourceAssembly
    {
        #region public methods

        /// <summary>
        /// Gets the current resource assembly.
        /// </summary>
        /// <returns></returns>
        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }

        /// <summary>
        /// Gets t he namespace of the currently running assembly
        /// </summary>
        /// <returns></returns>
        public static string GetNamespace()
        {
            return typeof(ResourceAssembly).Namespace+".";
        }
        
        #endregion
    }
}
