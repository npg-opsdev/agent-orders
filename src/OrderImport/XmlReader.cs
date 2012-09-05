using System.IO;
 using System.Text.RegularExpressions;

namespace OrderImport
{
    public class XmlReader
    {
        public string Read(string filename)
        {
            var filestream = File.OpenText(filename);

            //check the entity reference (&) and replace it 
            
            string content = Regex.Replace(filestream.ReadToEnd(), "&(?!(amp|apos|quot|lt|gt);)", "&amp;");

            filestream.Close();
            return content;
        }
    }
}