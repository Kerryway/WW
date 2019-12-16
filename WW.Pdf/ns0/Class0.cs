// Decompiled with JetBrains decompiler
// Type: ns0.Class0
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns2;
using ns3;

namespace ns0
{
  internal abstract class Class0
  {
    private Class41 class41_0;

    protected Class0(Class41 entry)
    {
      this.class41_0 = entry;
    }

    public Class41 Entry
    {
      get
      {
        return this.class41_0;
      }
      set
      {
        this.class41_0 = value;
      }
    }

    protected internal abstract void vmethod_0(Class80 reader);

    protected internal abstract void vmethod_1(Class79 writer);

    public string Name
    {
      get
      {
        return this.class41_0.TableName;
      }
    }

    public uint Tag
    {
      get
      {
        return this.class41_0.Tag;
      }
    }
  }
}
