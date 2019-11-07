using System;
using System.Collections.Specialized;
using System.IO;
using System.Xml;

namespace Job_Book_Zebra_MK500_Micro_Kiosk
{
    public class Settings
    {
        private static NameValueCollection m_settings;
        private static string m_settingsPath;

        static Settings()
        {
            m_settingsPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            m_settingsPath += @"\Settings.xml";

            if (!File.Exists(m_settingsPath))
            {
                throw new FileNotFoundException(m_settingsPath + " could not be found.");
            }

            System.Xml.XmlDocument xdoc = new XmlDocument();
            xdoc.Load(m_settingsPath);
            XmlElement root = xdoc.DocumentElement;
            System.Xml.XmlNodeList nodeList = root.ChildNodes.Item(0).ChildNodes;

            // Add settings to the NameValueCollection.
            m_settings = new NameValueCollection();
            m_settings.Add("webServiceURL", nodeList.Item(0).Attributes["value"].Value);
        }

        public static string webServiceURL
        {
            get { return m_settings.Get("webServiceURL"); }
            set { m_settings.Set("webServiceURL", value); }
        }
    }
}
