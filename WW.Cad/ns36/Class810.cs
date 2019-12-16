// Decompiled with JetBrains decompiler
// Type: ns36.Class810
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using WW;

namespace ns36
{
  [SecuritySafeCritical]
  internal class Class810
  {
    private static Dictionary<string, Class895> dictionary_0 = new Dictionary<string, Class895>();

    internal static Class895 smethod_0(string fontFileName)
    {
      lock (Class810.dictionary_0)
      {
        Class895 class895;
        if (Class810.dictionary_0.TryGetValue(fontFileName, out class895))
          return class895;
        Struct9 struct9 = new Struct9();
        Struct10 struct10 = new Struct10();
        Struct11 struct11 = new Struct11();
        Struct12 struct12 = new Struct12();
        string path = !Path.IsPathRooted(fontFileName) ? (!(Path.GetFileName(fontFileName) == fontFileName) ? fontFileName : Environment.ExpandEnvironmentVariables(Path.Combine("%WINDIR%\\Fonts", fontFileName))) : fontFileName;
        if (!File.Exists(path))
          return (Class895) null;
        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        try
        {
          BinaryReader r = new BinaryReader((Stream) fs);
          byte[] source1 = Class810.smethod_2(r.ReadBytes(Marshal.SizeOf((object) struct9)));
          IntPtr num1 = Marshal.AllocHGlobal(source1.Length);
          Marshal.Copy(source1, 0, num1, source1.Length);
          Struct9 structure1 = (Struct9) Marshal.PtrToStructure(num1, typeof (Struct9));
          Marshal.FreeHGlobal(num1);
          if (structure1.ushort_0 != (ushort) 1 || structure1.ushort_1 != (ushort) 0)
            return (Class895) null;
          bool flag = false;
          Struct10 tbName = new Struct10();
          for (int index = 0; index < (int) structure1.ushort_2; ++index)
          {
            byte[] source2 = r.ReadBytes(Marshal.SizeOf((object) struct10));
            IntPtr num2 = Marshal.AllocHGlobal(source2.Length);
            Marshal.Copy(source2, 0, num2, source2.Length);
            tbName = (Struct10) Marshal.PtrToStructure(num2, typeof (Struct10));
            Marshal.FreeHGlobal(num2);
            string str = tbName.char_0.ToString() + tbName.char_1.ToString() + tbName.char_2.ToString() + tbName.char_3.ToString();
            if (str != null && str.ToString() == "name")
            {
              flag = true;
              byte[] bytes1 = LittleEndianBitConverter.GetBytes(tbName.uint_2);
              byte[] bytes2 = LittleEndianBitConverter.GetBytes(tbName.uint_1);
              Array.Reverse((Array) bytes1);
              Array.Reverse((Array) bytes2);
              tbName.uint_2 = LittleEndianBitConverter.ToUInt32(bytes1);
              tbName.uint_1 = LittleEndianBitConverter.ToUInt32(bytes2);
              break;
            }
          }
          if (flag)
          {
            fs.Position = (long) tbName.uint_1;
            byte[] source2 = Class810.smethod_2(r.ReadBytes(Marshal.SizeOf((object) struct11)));
            IntPtr num2 = Marshal.AllocHGlobal(source2.Length);
            Marshal.Copy(source2, 0, num2, source2.Length);
            Struct11 structure2 = (Struct11) Marshal.PtrToStructure(num2, typeof (Struct11));
            Marshal.FreeHGlobal(num2);
            class895 = new Class895();
            for (int index = 0; index < (int) structure2.ushort_1; ++index)
            {
              byte[] source3 = Class810.smethod_2(r.ReadBytes(Marshal.SizeOf((object) struct12)));
              IntPtr num3 = Marshal.AllocHGlobal(source3.Length);
              Marshal.Copy(source3, 0, num3, source3.Length);
              Struct12 structure3 = (Struct12) Marshal.PtrToStructure(num3, typeof (Struct12));
              Marshal.FreeHGlobal(num3);
              if (structure3.ushort_0 == (ushort) 3 && structure3.ushort_2 == (ushort) 1033)
              {
                switch (structure3.ushort_3)
                {
                  case 1:
                    class895.FamilyName = Class810.smethod_1(fs, r, ref tbName, ref structure2, ref structure3);
                    continue;
                  case 2:
                    class895.SubFamilyName = Class810.smethod_1(fs, r, ref tbName, ref structure2, ref structure3);
                    continue;
                  case 3:
                    class895.UniqueFontIdentifier = Class810.smethod_1(fs, r, ref tbName, ref structure2, ref structure3);
                    continue;
                  case 4:
                    class895.FullFontName = Class810.smethod_1(fs, r, ref tbName, ref structure2, ref structure3);
                    continue;
                  default:
                    continue;
                }
              }
            }
          }
        }
        finally
        {
          fs.Close();
        }
        if (class895 != null)
        {
          class895.FullFilename = path;
          Class810.dictionary_0[fontFileName] = class895;
        }
        return class895;
      }
    }

    private static string smethod_1(
      FileStream fs,
      BinaryReader r,
      ref Struct10 tbName,
      ref Struct11 ttNTResult,
      ref Struct12 ttNMResult)
    {
      string empty = string.Empty;
      long position = fs.Position;
      fs.Position = (long) (tbName.uint_1 + (uint) ttNMResult.ushort_5 + (uint) ttNTResult.ushort_2);
      byte[] bytes = r.ReadBytes((int) ttNMResult.ushort_4);
      Encoding encoding = Encoding.ASCII;
      if (ttNMResult.ushort_0 == (ushort) 1)
      {
        switch (ttNMResult.ushort_1)
        {
          case 0:
            encoding = Encoding.GetEncoding(10000);
            break;
          case 1:
            encoding = Encoding.GetEncoding(10001);
            break;
        }
      }
      else if (ttNMResult.ushort_0 == (ushort) 3)
      {
        switch (ttNMResult.ushort_1)
        {
          case 0:
            encoding = Encoding.BigEndianUnicode;
            break;
          case 1:
            encoding = Encoding.BigEndianUnicode;
            break;
          case 2:
            encoding = Encoding.GetEncoding(932);
            break;
          case 4:
            encoding = Encoding.GetEncoding(950);
            break;
          case 5:
            encoding = Encoding.GetEncoding(20949);
            break;
          case 6:
            encoding = Encoding.GetEncoding(1361);
            break;
          case 10:
            encoding = Encoding.UTF32;
            break;
        }
      }
      string str = encoding.GetString(bytes);
      fs.Position = position;
      return str;
    }

    private static byte[] smethod_2(byte[] bLittle)
    {
      byte[] numArray = new byte[bLittle.Length];
      for (int index = 0; index < bLittle.Length - 1; index += 2)
      {
        byte num1 = bLittle[index];
        byte num2 = bLittle[index + 1];
        numArray[index] = num2;
        numArray[index + 1] = num1;
      }
      return numArray;
    }
  }
}
