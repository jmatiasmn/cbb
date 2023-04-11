using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace cbb.res
{
    /// <summary>
    /// Gets the embedded resource image from the cbb.res assembly based on user provided file name with extendion.
    /// Helper methods
    /// </summary>
    public static class ResourceImage
    {
        #region public Methods
        /// <summary>
        /// Gets the icon image frfom resource assmbly
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static BitmapImage GetIcon(string name)
        {
            //Create the resource reader stream.
            var stream = ResourceAssembly.GetAssembly().
                GetManifestResourceStream(ResourceAssembly.GetNamespace() + "Images.Icons." + name);

            var image = new BitmapImage();

            //Construct and retrn image.
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();

            //return new constructed BitMapImage;
            return image;
        }
        #endregion

    }
}
