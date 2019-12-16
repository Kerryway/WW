// Decompiled with JetBrains decompiler
// Type: WW.License
// Assembly: WW.License, Version=4.0.0.0, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: DD676BB3-9AAD-4555-ADFB-3D7D3FF47486
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.License.dll

using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace WW
{
  public class License
  {
    static License()
    {
      XmlDocument license = License.GetLicense();
      List<string> stringList = new List<string>();
      foreach (XmlNode xmlNode in license.GetElementsByTagName("product"))
      {
        bool flag = true;
        XmlAttribute attribute = xmlNode.Attributes["showTrialMessage"];
        if (attribute != null && attribute.Value == "false")
          flag = false;
        if (flag && xmlNode.Attributes["type"].Value == "trial")
        {
          stringList.Add(xmlNode.Attributes["name"].Value);
          break;
        }
      }
      if (stringList.Count <= 0)
        return;
      string str = "Wout Ware trial for components: " + stringList[0];
      for (int index = 1; index < stringList.Count; ++index)
        str = str + ", " + stringList[index];
      int num = (int) MessageBox.Show(str + ".", "Wout Ware trial");
    }

    public static XmlDocument GetLicense()
    {
      XmlDocument xmlDocument = (XmlDocument) null;
      using (Stream manifestResourceStream = typeof (License).Assembly.GetManifestResourceStream("WW.License.WW.License.xml"))
      {
        xmlDocument = new XmlDocument();
        xmlDocument.Load(manifestResourceStream);
      }
      return xmlDocument;
    }
  }
}
