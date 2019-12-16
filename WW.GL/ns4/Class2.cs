// Decompiled with JetBrains decompiler
// Type: ns4.Class2
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using Microsoft.Win32;
using ns1;
using ns2;
using ns5;
using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using WW;

namespace ns4
{
  internal sealed class Class2
  {
    private const string string_0 = "{F07847F9-0CED-4e2f-8771-9BEA3D1D10CC}";
    private const int int_0 = 30;

    static Class2()
    {
      try
      {
        System.Type type = typeof (CryptoConfig);
        type.GetProperty("DefaultOidHT", BindingFlags.Static | BindingFlags.NonPublic).GetValue((object) null, (object[]) null);
        Hashtable hashtable = type.GetField("defaultOidHT", BindingFlags.Static | BindingFlags.NonPublic).GetValue((object) null) as Hashtable;
        if (hashtable == null)
          return;
        foreach (DictionaryEntry dictionaryEntry in new Hashtable((IDictionary) hashtable))
        {
          if (!hashtable.ContainsKey(dictionaryEntry.Value))
            hashtable.Add(dictionaryEntry.Value, dictionaryEntry.Value);
        }
      }
      catch (Exception ex)
      {
      }
    }

    internal static void smethod_0(Enum0 edition)
    {
      Class0 class0 = Class2.smethod_1(edition);
      if (class0.LicensedEdition < edition)
      {
        string str;
        if (class0.IsTrial)
          str = "Trial period expired!";
        else
          str = class0.ProductName + " " + (object) class0.LicensedEdition + " is not licensed.";
        int num = (int) MessageBox.Show(class0.Message, str, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        throw new InternalException(str);
      }
    }

    internal static Class0 smethod_1(Enum0 requiredEdition)
    {
      Assembly executingAssembly = Assembly.GetExecutingAssembly();
      ns0.Attribute0 customAttribute = (ns0.Attribute0) executingAssembly.GetCustomAttributes(typeof (ns0.Attribute0), true)[0];
      Class0 licenseInfo = new Class0(customAttribute.ProductName);
      Class2.smethod_2(licenseInfo, executingAssembly, customAttribute, requiredEdition);
      return licenseInfo;
    }

    private static Class0 smethod_2(
      Class0 licenseInfo,
      Assembly assembly,
      ns0.Attribute0 productAttribute,
      Enum0 requiredEdition)
    {
      string xmlString = "<RSAKeyValue><Modulus>5tmp6YoXLdKEUTC0PvXQmgM9V+jtb2LBV/6nCO8l/4StX9muFDQRSrtJAEH8sXcHu5Fgr7Y00oddMMSwfjXgiAG0b4WMhfF3s2/Cpw9MqFJXVnoeMr8dKHCr2Dp6cue6yCb3rIwjbRCYavYCHFmywBhrfztx6m125PD6TuDYDN0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
      RSACryptoServiceProvider cryptoServiceProvider = new RSACryptoServiceProvider(new CspParameters() { Flags = CspProviderFlags.UseMachineKeyStore });
      cryptoServiceProvider.FromXmlString(xmlString);
      XmlDocument license = License.GetLicense();
      SignedXml signedXml = new SignedXml(license);
      try
      {
        XmlNode xmlNode = license.GetElementsByTagName("Signature", "http://www.w3.org/2000/09/xmldsig#")[0];
        signedXml.LoadXml((XmlElement) xmlNode);
      }
      catch (Exception ex)
      {
        licenseInfo.Message = "Error: no signature found.";
        licenseInfo.Exception = ex;
        return licenseInfo;
      }
      if (signedXml.CheckSignature((AsymmetricAlgorithm) cryptoServiceProvider))
      {
        XmlNodeList elementsByTagName1 = license.GetElementsByTagName("product");
        XmlNode xmlNode1 = (XmlNode) null;
        foreach (XmlNode xmlNode2 in elementsByTagName1)
        {
          if (xmlNode2.Attributes["name"].Value == licenseInfo.ProductName)
          {
            xmlNode1 = xmlNode2;
            break;
          }
        }
        if (xmlNode1 == null)
        {
          licenseInfo.Message = "Wrong license.";
          return licenseInfo;
        }
        Version version1 = assembly.GetName().Version;
        string[] strArray = xmlNode1.Attributes["version"].Value.Split('.');
        Version version2 = new Version(strArray[0] == "*" ? (int) byte.MaxValue : int.Parse(strArray[0], (IFormatProvider) CultureInfo.InvariantCulture), strArray[1] == "*" ? (int) byte.MaxValue : int.Parse(strArray[1], (IFormatProvider) CultureInfo.InvariantCulture), strArray[2] == "*" ? (int) byte.MaxValue : int.Parse(strArray[2], (IFormatProvider) CultureInfo.InvariantCulture));
        if (version1.CompareTo(version2) > 0)
        {
          licenseInfo.Message = "Wrong license version.";
          return licenseInfo;
        }
        Enum0 enum0 = Enum0.const_0;
        switch (xmlNode1.Attributes["edition"].Value)
        {
          case "basic":
            enum0 = Enum0.const_1;
            break;
          case "standard":
            enum0 = Enum0.const_2;
            break;
          case "professional":
            enum0 = Enum0.const_3;
            break;
        }
        if (requiredEdition > enum0)
        {
          licenseInfo.Message = "Insufficient license edition.";
          return licenseInfo;
        }
        if (DateTime.Parse(xmlNode1.Attributes["expirationDate"].Value, (IFormatProvider) CultureInfo.InvariantCulture) < productAttribute.ReleaseDate)
        {
          licenseInfo.Message = "The license is not valid for this release of " + licenseInfo.ProductName + ", renew your license.";
          return licenseInfo;
        }
        string str = xmlNode1.Attributes["type"].Value;
        if (str == "runtime")
        {
          licenseInfo.LicensedEdition = enum0;
          XmlNodeList elementsByTagName2 = license.GetElementsByTagName("licensee");
          licenseInfo.Licensee = elementsByTagName2[0].InnerText;
          return licenseInfo;
        }
        if (str == "trial")
        {
          licenseInfo.IsTrial = true;
          DateTime firstUsedDate;
          DateTime lastUsedDate;
          if (Class2.smethod_4(productAttribute, out firstUsedDate, out lastUsedDate))
          {
            DateTime t1 = firstUsedDate.AddDays(31.0);
            DateTime utcNow = DateTime.UtcNow;
            if (lastUsedDate.Ticks > utcNow.Ticks)
            {
              licenseInfo.Message = "Licence check error.";
              return licenseInfo;
            }
            Class2.smethod_5(productAttribute, firstUsedDate, utcNow);
            if (DateTime.Compare(t1, utcNow) >= 0)
            {
              licenseInfo.TrialDaysLeft = Math.Max(0, t1.Subtract(utcNow).Days);
              licenseInfo.LicensedEdition = enum0;
              return licenseInfo;
            }
            licenseInfo.Message = "Trial period of 30 days expired.";
            return licenseInfo;
          }
          licenseInfo.TrialDaysLeft = 30;
          Class2.smethod_5(productAttribute, DateTime.UtcNow, DateTime.UtcNow);
          licenseInfo.LicensedEdition = enum0;
          return licenseInfo;
        }
        licenseInfo.Message = "Wrong license type.";
        return licenseInfo;
      }
      licenseInfo.Message = "Invalid license.";
      return licenseInfo;
    }

    internal static void smethod_3(Class0 licenseInfo)
    {
      int num = (int) MessageBox.Show("This is a trial version of Wout Ware's " + licenseInfo.ProductName + " (" + licenseInfo.TrialDaysLeft.ToString() + " days left).", licenseInfo.ProductName + " Trial");
    }

    private static bool smethod_4(
      ns0.Attribute0 productAttribute,
      out DateTime firstUsedDate,
      out DateTime lastUsedDate)
    {
      firstUsedDate = DateTime.MinValue;
      lastUsedDate = DateTime.MinValue;
      RegistryKey registryKey1 = Registry.CurrentUser.OpenSubKey("Software", true);
      if (registryKey1 == null)
        return false;
      RegistryKey registryKey2 = registryKey1.OpenSubKey("WW", true);
      if (registryKey2 == null)
        return false;
      RegistryKey registryKey3 = registryKey2.OpenSubKey("{F07847F9-0CED-4e2f-8771-9BEA3D1D10CC}");
      if (registryKey3 == null)
        return false;
      string s1 = (string) registryKey3.GetValue(productAttribute.RegistryKey);
      if (s1 != null)
      {
        if (!(s1 == string.Empty))
        {
          string str;
          try
          {
            str = Encoding.Unicode.GetString(Class1.smethod_1(Class1.smethod_3(s1)));
          }
          catch (Exception ex)
          {
            return false;
          }
          string[] strArray = str.Split(',');
          if (strArray == null || strArray.Length != 3)
            return false;
          string version1 = strArray[0];
          if (version1 == null || version1 == string.Empty)
            return false;
          Version version2 = new Version(version1);
          string s2 = strArray[1];
          if (s2 == null || s2 == string.Empty)
            return false;
          firstUsedDate = DateTime.Parse(s2, (IFormatProvider) CultureInfo.InvariantCulture);
          string s3 = strArray[2];
          if (s3 == null || s3 == string.Empty)
            return false;
          lastUsedDate = DateTime.Parse(s3, (IFormatProvider) CultureInfo.InvariantCulture);
          Version version3 = Assembly.GetExecutingAssembly().GetName().Version;
          return new Version(version3.Major, version3.Minor, version3.Build).CompareTo(new Version(version2.Major, version2.Minor, version2.Build)) <= 0;
        }
      }
      return false;
    }

    private static void smethod_5(
      ns0.Attribute0 productAttribute,
      DateTime firstUsedDate,
      DateTime lastUsedDate)
    {
      DateTime now = DateTime.Now;
      RegistryKey subKey = Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("WW").CreateSubKey("{F07847F9-0CED-4e2f-8771-9BEA3D1D10CC}");
      string str = Class1.smethod_2(Class1.smethod_0(Encoding.Unicode.GetBytes(string.Format("{0},{1},{2}", (object) Assembly.GetExecutingAssembly().GetName().Version.ToString(), (object) firstUsedDate.ToString(CultureInfo.InvariantCulture.DateTimeFormat.SortableDateTimePattern, (IFormatProvider) CultureInfo.InvariantCulture), (object) lastUsedDate.ToString(CultureInfo.InvariantCulture.DateTimeFormat.SortableDateTimePattern, (IFormatProvider) CultureInfo.InvariantCulture)))));
      subKey.SetValue(productAttribute.RegistryKey, (object) str);
    }

    internal enum Enum1
    {
      const_0,
      const_1,
      const_2,
      const_3,
    }
  }
}
