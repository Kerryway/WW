// Decompiled with JetBrains decompiler
// Type: ns1.Class75
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns2;
using ns3;
using ns4;
using ns5;
using ns6;
using ns7;
using ns8;
using System;

namespace ns1
{
  internal static class Class75
  {
    public static Class0 smethod_0(string tableName, Class80 reader)
    {
      Class41 entry = reader.method_14(tableName);
      switch (tableName)
      {
        case "head":
          return (Class0) new Class2(entry);
        case "hhea":
          return (Class0) new Class8(entry);
        case "hmtx":
          return (Class0) new Class6(entry);
        case "maxp":
          return (Class0) new Class11(entry);
        case "loca":
          return (Class0) new Class5(entry);
        case "glyf":
          return (Class0) new Class9(entry);
        case "cvt ":
          return (Class0) new Class13(entry);
        case "prep":
          return (Class0) new Class3(entry);
        case "fpgm":
          return (Class0) new Class7(entry);
        case "post":
          return (Class0) new Class10(entry);
        case "OS/2":
          return (Class0) new Class4(entry);
        case "name":
          return (Class0) new Class1(entry);
        case "kern":
          return (Class0) new Class12(entry);
        default:
          throw new ArgumentException("Unrecognised table name '" + tableName + "'", nameof (tableName));
      }
    }
  }
}
