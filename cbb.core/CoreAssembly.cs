using System.Reflection;

namespace cbb.core
{
    public class CoreAssembly
    {
        #region public methods

        /// <summary>
        /// Gets the current resource assembly.
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyLocation()
        {
            return Assembly.GetExecutingAssembly().Location;
        }

        /// <summary>
        /// Gets t he namespace of the currently running assembly
        /// </summary>
        /// <returns></returns>
        public static string GetNamespace()
        {
            return typeof(CoreAssembly).Namespace + ".";
        }

        #endregion
    }
}
