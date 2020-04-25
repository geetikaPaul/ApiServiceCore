using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BlogApiServiceCore
{
    public class FileNameExtractor
    {
        public IEnumerable<string> Extractor(string xmlString)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            XmlElement root = doc.DocumentElement;
            List<string> fileNames = new List<string>();
            DisplayNodes(root, ref fileNames);

            return fileNames;
        }

        private static void DisplayNodes(XmlNode node, ref List<string> fileNames)
        {            
            if (node.Name.Equals("Key") && (node.InnerText.Contains("/") || node.InnerText.Contains(".")))
                fileNames.Add(node.InnerText);

            XmlNodeList children = node.ChildNodes;
            foreach (XmlNode child in children)
            {
                DisplayNodes(child, ref fileNames);
            }
        }
    }
}
