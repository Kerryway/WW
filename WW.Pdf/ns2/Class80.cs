// Decompiled with JetBrains decompiler
// Type: ns2.Class80
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns1;
using ns3;
using ns4;
using ns5;
using ns6;
using ns7;
using ns8;
using System;
using System.Collections.Generic;
using System.IO;
using WW.Text;

namespace ns2
{
  internal class Class80
  {
    private readonly IDictionary<string, Class0> idictionary_0 = (IDictionary<string, Class0>) new Dictionary<string, Class0>();
    private readonly Class74 class74_0;
    private readonly string string_0;
    private Class50 class50_0;
    private Class48 class48_0;

    public Class80(MemoryStream stream)
      : this(stream, string.Empty)
    {
    }

    public Class80(MemoryStream stream, string fontName)
    {
      this.class74_0 = new Class74((System.IO.Stream) stream);
      this.string_0 = fontName;
      this.method_15();
      this.method_16();
    }

    public Class48 IndexMappings
    {
      get
      {
        return this.class48_0 ?? (this.class48_0 = new Class48());
      }
      set
      {
        this.class48_0 = value;
      }
    }

    internal Class74 Stream
    {
      get
      {
        return this.class74_0;
      }
    }

    public int TableCount
    {
      get
      {
        return this.class50_0.Count;
      }
    }

    public bool method_0(string tableName)
    {
      return this.class50_0.method_1(tableName);
    }

    internal Class0 method_1(string tableName)
    {
      return this.method_2(tableName, false);
    }

    internal Class0 method_2(string tableName, bool optional)
    {
      if (!this.method_0(tableName))
      {
        if (optional)
          return (Class0) null;
        throw new ArgumentException("Cannot locate table '" + tableName + "'", nameof (tableName));
      }
      if (this.idictionary_0.ContainsKey(tableName))
        return this.idictionary_0[tableName];
      Class41 entry = this.method_14(tableName);
      Class0 class0 = entry.method_0(this);
      if (class0 != null)
      {
        this.method_17(entry);
        class0.vmethod_0(this);
      }
      return class0;
    }

    internal Class2 method_3()
    {
      return (Class2) this.method_1("head");
    }

    internal Class11 method_4()
    {
      return (Class11) this.method_1("maxp");
    }

    internal Class8 method_5()
    {
      return (Class8) this.method_1("hhea");
    }

    internal Class6 method_6()
    {
      return (Class6) this.method_1("hmtx");
    }

    internal Class13 method_7(bool optional)
    {
      return (Class13) this.method_2("cvt ", optional);
    }

    internal Class3 method_8()
    {
      return (Class3) this.method_1("prep");
    }

    internal Class7 method_9(bool optional)
    {
      return (Class7) this.method_2("fpgm", optional);
    }

    internal Class9 method_10()
    {
      return (Class9) this.method_1("glyf");
    }

    internal Class5 method_11()
    {
      return (Class5) this.method_1("loca");
    }

    internal Class4 method_12()
    {
      return (Class4) this.method_1("OS/2");
    }

    internal Class10 method_13()
    {
      return (Class10) this.method_1("post");
    }

    internal Class41 method_14(string tableName)
    {
      if (!this.method_0(tableName))
        throw new ArgumentException("Cannot locate table named " + tableName, nameof (tableName));
      return this.class50_0[tableName];
    }

    protected void method_15()
    {
      byte[] bytes = this.class74_0.method_20();
      if (Encodings.Ascii.GetString(bytes, 0, bytes.Length) == "ttcf")
      {
        this.class74_0.method_25(4L);
        int num1 = (int) this.class74_0.method_14();
        bool flag = false;
        for (int index = 0; index < num1 && !flag; ++index)
        {
          uint num2 = this.class74_0.method_14();
          this.class74_0.method_26();
          this.class74_0.Position = (long) num2;
          this.class50_0 = new Class50();
          this.class50_0.method_0(this.class74_0);
          if (!this.class50_0.method_1("name"))
            throw new Exception("Unable to parse TrueType collection - missing 'head' table.");
          Class1 class1 = (Class1) this.method_1("name");
          if (this.string_0 == string.Empty || class1.FullName == this.string_0)
            flag = true;
          this.class74_0.method_27();
        }
        if (!flag)
          throw new Exception("Unable to locate font '" + this.string_0 + "' in TrueType collection");
      }
      else
      {
        this.class74_0.Position = 0L;
        this.class50_0 = new Class50();
        this.class50_0.method_0(this.class74_0);
      }
    }

    protected void method_16()
    {
      this.idictionary_0["head"] = this.method_1("head");
      this.idictionary_0["hhea"] = this.method_1("hhea");
      this.idictionary_0["maxp"] = this.method_1("maxp");
      this.idictionary_0["loca"] = this.method_1("loca");
    }

    private void method_17(Class41 entry)
    {
      this.class74_0.Position = (long) entry.Offset;
      if (this.class74_0.Position + (long) entry.Length > this.class74_0.Length)
        throw new ArgumentException(string.Format("Error reading table '{0}'.  Expected {1} bytes, current position {2}, stream length {3}", (object) entry.TableName, (object) entry.Length, (object) this.class74_0.Position, (object) this.class74_0.Length));
    }
  }
}
