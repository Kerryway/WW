// Decompiled with JetBrains decompiler
// Type: ns36.Class1043
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ns36
{
  internal class Class1043
  {
    private const char char_0 = '"';

    private static string smethod_0(string filename)
    {
      if (string.IsNullOrEmpty(filename))
        return (string) null;
      if (filename[0] == '"' && filename[filename.Length - 1] == '"')
        filename = filename.Trim('"');
      if (filename.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
        return (string) null;
      return filename;
    }

    internal static string smethod_1(string filename, string[] path)
    {
      filename = Class1043.smethod_0(filename);
      if (filename == null)
        return (string) null;
      string str = (string) null;
      if (!Path.IsPathRooted(filename) && path != null)
      {
        foreach (string path1 in path)
        {
          string path2 = Path.Combine(path1, filename);
          if (File.Exists(path2))
          {
            str = path2;
            break;
          }
        }
      }
      if (str == null && File.Exists(filename))
        str = filename;
      return str;
    }

    internal static string[] smethod_2(string filename)
    {
      string str = (string) null;
      try
      {
        str = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      }
      catch (Exception ex)
      {
      }
      List<string> stringList = new List<string>();
      filename = Class1043.smethod_0(filename);
      if (!string.IsNullOrEmpty(filename))
        stringList.Add(Path.GetDirectoryName(filename));
      if (!string.IsNullOrEmpty(str))
        stringList.Add(str);
      return stringList.ToArray();
    }
  }
}
