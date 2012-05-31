using System.IO;

namespace OrderImport
{
    public class XmlReader
    {
        public string Read(string filename)
        {
            var filestream = File.OpenText(filename);
            return filestream.ReadToEnd();
        }
    }
}
