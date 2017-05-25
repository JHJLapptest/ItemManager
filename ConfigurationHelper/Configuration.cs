using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using System.IO;
using System.Xml;

namespace ConfigurationHelper
{
    public class Configuration
    {
        public static string GetConnectionString(string name)
        {
            string connstr = string.Empty;

            string path = Assembly.GetExecutingAssembly().GetName().CodeBase;
            path = Path.GetDirectoryName(path);
            path = Path.Combine(path, "DataSystems.config");

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(path);

            XmlNodeList nodeList = xmldoc.SelectNodes("/configuration/connectionStrings/add");
            foreach (XmlNode node in nodeList)
            {
                if (node.Attributes["name"].Value.ToString().ToUpper() == name.ToUpper())
                {
                    connstr = node.Attributes["connectionString"].Value;
                    break;
                }
            }
            return connstr;
        }
    }
}
