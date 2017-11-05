using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageTransformer.FileStreams
{
    public class FileStreams
    {
        public static void SaveFileStream(String path, Stream stream)
        {
            var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            stream.CopyTo(fileStream);
            fileStream.Dispose();
        }

        public static Boolean WriteToDisk(byte[] data, string path, string name, string extension)
        {
            string _path = String.Format("{0}\\{1}.{2}", path, name, extension);
            try
            {
                System.IO.File.WriteAllBytes(_path, data);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;

        }
    }
}
