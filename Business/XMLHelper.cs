using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace BHair.Business
{
    public class XMLHelper
    {
        public static string strGetConnectString()
        {
            string strLocalAdd = ".\\config.xml";
            string strResult = "";
            if (File.Exists(strLocalAdd))
            {
                try
                {
                    XmlDocument xmlCon = new XmlDocument();
                    xmlCon.Load(strLocalAdd);
                    XmlNode xnCon = xmlCon.SelectSingleNode("Config");
                    strResult = xnCon.SelectSingleNode("LinkString").InnerText;
                }
                catch
                {
                    strResult = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\\转货数据库.accdb";
                }
            }
            else
            {
                strResult = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\\转货数据库.accdb";
            }
            return strResult;
        }
    }
}
