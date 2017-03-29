using System.IO;
using System.Web;

namespace Ganesha.Common.Tools {
    public class ImageConverter {
        /// <summary>
        /// Convertir une Image en type Byte []
        ///
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static byte[] ConvertToBytes(HttpPostedFileBase image) {

            byte[] imagesBytes = null;
            var reader = new BinaryReader(image.InputStream);
            imagesBytes = reader.ReadBytes((int)image.ContentLength);
            return imagesBytes;
        }


    }
}