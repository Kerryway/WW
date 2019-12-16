// Decompiled with JetBrains decompiler
// Type: ns28.Class885
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using System;
using System.IO;
using System.Text;
using WW.Cad.Model;

namespace ns28
{
  internal static class Class885
  {
    private static readonly ushort[] ushort_0 = new ushort[4]{ (ushort) 42392, (ushort) 33025, (ushort) 15556, (ushort) 33889 };

    public static void smethod_0(Class949 appInfo, Stream stream, Encoding encoding)
    {
      Class889 byteStream = Class889.Create(stream, DxfVersion.Dxf21, Encoding.Unicode);
      Class921.smethod_0(appInfo, byteStream);
    }

    public static bool smethod_1(byte[] buffer, ulong start, ulong length)
    {
      bool flag = true;
      ulong num = start + length;
      for (ulong index = start; index < num; ++index)
      {
        if (buffer[index] != (byte) 0)
        {
          flag = false;
          break;
        }
      }
      return flag;
    }

    public static ushort smethod_2(int sectionCount)
    {
      return Class885.ushort_0[sectionCount - 3];
    }

    public static DwgVersion smethod_3(DxfVersion dxfVersion)
    {
      DwgVersion dwgVersion;
      switch (dxfVersion)
      {
        case DxfVersion.Dxf10:
          dwgVersion = DwgVersion.Dwg1010;
          break;
        case DxfVersion.Dxf10PlusUnofficial:
          dwgVersion = DwgVersion.Dwg1011;
          break;
        case DxfVersion.Dxf12:
          dwgVersion = DwgVersion.Dwg1012;
          break;
        case DxfVersion.Dxf13:
          dwgVersion = DwgVersion.Dwg1013;
          break;
        case DxfVersion.Dxf14:
          dwgVersion = DwgVersion.Dwg1014;
          break;
        case DxfVersion.Dxf15:
          dwgVersion = DwgVersion.Dwg1015;
          break;
        case DxfVersion.Dxf18:
          dwgVersion = DwgVersion.Dwg1018;
          break;
        case DxfVersion.Dxf21:
          dwgVersion = DwgVersion.Dwg1021;
          break;
        case DxfVersion.Dxf24:
          dwgVersion = DwgVersion.Dwg1024;
          break;
        case DxfVersion.Dxf27:
          dwgVersion = DwgVersion.Dwg1027;
          break;
        default:
          throw new NotSupportedException("Unknown DxfVersion " + (object) dxfVersion + ".");
      }
      return dwgVersion;
    }

    public static DxfVersion smethod_4(DwgVersion dwgVersion)
    {
      DxfVersion dxfVersion;
      switch (dwgVersion)
      {
        case DwgVersion.Dwg1010:
          dxfVersion = DxfVersion.Dxf10;
          break;
        case DwgVersion.Dwg1011:
          dxfVersion = DxfVersion.Dxf10PlusUnofficial;
          break;
        case DwgVersion.Dwg1012:
          dxfVersion = DxfVersion.Dxf12;
          break;
        case DwgVersion.Dwg1013:
          dxfVersion = DxfVersion.Dxf13;
          break;
        case DwgVersion.Dwg1014:
          dxfVersion = DxfVersion.Dxf14;
          break;
        case DwgVersion.Dwg1015Beta:
        case DwgVersion.Dwg1015:
          dxfVersion = DxfVersion.Dxf15;
          break;
        case DwgVersion.Dwg1018Beta:
        case DwgVersion.Dwg1018:
          dxfVersion = DxfVersion.Dxf18;
          break;
        case DwgVersion.Dwg1021Beta:
        case DwgVersion.Dwg1021:
          dxfVersion = DxfVersion.Dxf21;
          break;
        case DwgVersion.Dwg1024Beta:
        case DwgVersion.Dwg1024:
          dxfVersion = DxfVersion.Dxf24;
          break;
        case DwgVersion.Dwg1027Beta:
        case DwgVersion.Dwg1027:
          dxfVersion = DxfVersion.Dxf27;
          break;
        default:
          throw new NotSupportedException("Unknown DwgVersion " + (object) dwgVersion + ".");
      }
      return dxfVersion;
    }

    public static byte smethod_5(short lineWeight)
    {
      byte num = 0;
      switch (lineWeight)
      {
        case -3:
          num = (byte) 31;
          break;
        case -2:
          num = (byte) 30;
          break;
        case -1:
          num = (byte) 29;
          break;
        default:
          for (int index = 0; index < Class800.byte_5.Length; ++index)
          {
            if ((int) lineWeight == (int) Class800.byte_5[index])
              num = (byte) index;
          }
          break;
      }
      return num;
    }

    public static short GetLineWeight(short dwgLineWeight)
    {
      short num;
      switch (dwgLineWeight)
      {
        case 28:
        case 29:
          num = (short) -1;
          break;
        case 30:
          num = (short) -2;
          break;
        case 31:
          num = (short) -3;
          break;
        default:
          num = dwgLineWeight < (short) 0 || (int) dwgLineWeight >= Class800.byte_5.Length ? (short) -3 : (short) Class800.byte_5[(int) dwgLineWeight];
          break;
      }
      return num;
    }
  }
}
