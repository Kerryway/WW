// Decompiled with JetBrains decompiler
// Type: ns5.Class46
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System;

namespace ns5
{
  internal static class Class46
  {
    public const string string_0 = "ttcf";
    public const string string_1 = "cmap";
    public const string string_2 = "head";
    public const string string_3 = "hhea";
    public const string string_4 = "hmtx";
    public const string string_5 = "maxp";
    public const string string_6 = "name";
    public const string string_7 = "OS/2";
    public const string string_8 = "post";
    public const string string_9 = "cvt ";
    public const string string_10 = "fpgm";
    public const string string_11 = "glyf";
    public const string string_12 = "loca";
    public const string string_13 = "prep";
    public const string string_14 = "CFF ";
    public const string string_15 = "VORG";
    public const string string_16 = "BASE";
    public const string string_17 = "GDEF";
    public const string string_18 = "GPOS";
    public const string string_19 = "GSUB";
    public const string string_20 = "JSTF";
    public const string string_21 = "DSIG";
    public const string string_22 = "gasp";
    public const string string_23 = "hdmx";
    public const string string_24 = "kern";
    public const string string_25 = "LTSH";
    public const string string_26 = "PCLT";
    public const string string_27 = "VDMX";
    public const string string_28 = "vhea";
    public const string string_29 = "vmtx";

    public static uint smethod_0(string tableName)
    {
      if (tableName == null)
        throw new ArgumentNullException(nameof (tableName), "tableName cannot be null.");
      if (tableName.Length != 4)
        throw new ArgumentException("tableName must be 4 characters in length.");
      return (uint) ((int) (byte) tableName[3] << 24 | (int) (byte) tableName[2] << 16 | (int) (byte) tableName[1] << 8) | (uint) (byte) tableName[0];
    }
  }
}
