// Decompiled with JetBrains decompiler
// Type: ns38.Class809
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using Microsoft.Win32;
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

namespace ns38
{
  internal sealed class Class809
  {
    private const string string_0 = "{F07847F9-0CED-4e2f-8771-9BEA3D1D10CC}";
    private const int int_0 = 30;

    static Class809()
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

    internal static void smethod_0(Enum15 edition)
    {
    }

    internal static Class522 smethod_1(Enum15 requiredEdition)
    {
      Assembly executingAssembly = Assembly.GetExecutingAssembly();
      Attribute0 customAttribute = (Attribute0) executingAssembly.GetCustomAttributes(typeof (Attribute0), true)[0];
      Class522 licenseInfo = new Class522(customAttribute.ProductName);
      Class809.smethod_2(licenseInfo, executingAssembly, customAttribute, requiredEdition);
      return licenseInfo;
    }

    private static Class522 smethod_2(
      Class522 licenseInfo,
      Assembly assembly,
      Attribute0 productAttribute,
      Enum15 requiredEdition)
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
        Enum15 enum15 = Enum15.const_0;
        switch (xmlNode1.Attributes["edition"].Value)
        {
          case "basic":
            enum15 = Enum15.const_1;
            break;
          case "standard":
            enum15 = Enum15.const_2;
            break;
          case "professional":
            enum15 = Enum15.const_3;
            break;
        }
        if (requiredEdition > enum15)
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
          licenseInfo.LicensedEdition = enum15;
          XmlNodeList elementsByTagName2 = license.GetElementsByTagName("licensee");
          licenseInfo.Licensee = elementsByTagName2[0].InnerText;
          return licenseInfo;
        }
        if (str == "trial")
        {
          licenseInfo.IsTrial = true;
          DateTime firstUsedDate;
          DateTime lastUsedDate;
          if (Class809.smethod_4(productAttribute, out firstUsedDate, out lastUsedDate))
          {
            DateTime t1 = firstUsedDate.AddDays(31.0);
            DateTime utcNow = DateTime.UtcNow;
            if (lastUsedDate.Ticks > utcNow.Ticks)
            {
              licenseInfo.Message = "Licence check error.";
              return licenseInfo;
            }
            Class809.smethod_5(productAttribute, firstUsedDate, utcNow);
            if (DateTime.Compare(t1, utcNow) >= 0)
            {
              licenseInfo.TrialDaysLeft = Math.Max(0, t1.Subtract(utcNow).Days);
              licenseInfo.LicensedEdition = enum15;
              return licenseInfo;
            }
            licenseInfo.Message = "Trial period of 30 days expired.";
            return licenseInfo;
          }
          licenseInfo.TrialDaysLeft = 30;
          Class809.smethod_5(productAttribute, DateTime.UtcNow, DateTime.UtcNow);
          licenseInfo.LicensedEdition = enum15;
          return licenseInfo;
        }
        licenseInfo.Message = "Wrong license type.";
        return licenseInfo;
      }
      licenseInfo.Message = "Invalid license.";
      return licenseInfo;
    }

    internal static void smethod_3(Class522 licenseInfo)
    {
      int num = (int) MessageBox.Show("This is a trial version of Wout Ware's " + licenseInfo.ProductName + " (" + licenseInfo.TrialDaysLeft.ToString() + " days left).", licenseInfo.ProductName + " Trial");
    }

    private static bool smethod_4(
      Attribute0 productAttribute,
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
            str = Encoding.Unicode.GetString(Class750.Decrypt(Class750.smethod_1(s1)));
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
      Attribute0 productAttribute,
      DateTime firstUsedDate,
      DateTime lastUsedDate)
    {
      DateTime now = DateTime.Now;
      RegistryKey subKey = Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("WW").CreateSubKey("{F07847F9-0CED-4e2f-8771-9BEA3D1D10CC}");
      string str = Class750.smethod_0(Class750.Encrypt(Encoding.Unicode.GetBytes(string.Format("{0},{1},{2}", (object) Assembly.GetExecutingAssembly().GetName().Version.ToString(), (object) firstUsedDate.ToString(CultureInfo.InvariantCulture.DateTimeFormat.SortableDateTimePattern, (IFormatProvider) CultureInfo.InvariantCulture), (object) lastUsedDate.ToString(CultureInfo.InvariantCulture.DateTimeFormat.SortableDateTimePattern, (IFormatProvider) CultureInfo.InvariantCulture)))));
      subKey.SetValue(productAttribute.RegistryKey, (object) str);
    }

    internal enum Enum32
    {
      const_0,
      const_1,
      const_2,
      const_3,
    }
  }
}
