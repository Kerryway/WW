// Decompiled with JetBrains decompiler
// Type: ns2.Class720
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.IO;
using WW.Cad.Model.Objects;

namespace ns2
{
  internal class Class720 : Interface33
  {
    private int int_0;
    private readonly List<Struct18> list_0;
    private readonly Struct18 struct18_0;

    public Class720(Struct18 endGroup, IEnumerable<DxfXRecordValue> values)
    {
      this.struct18_0 = endGroup;
      this.list_0 = new List<Struct18>();
      foreach (DxfXRecordValue dxfXrecordValue in values)
        this.list_0.AddRange((IEnumerable<Struct18>) dxfXrecordValue.method_0());
    }

    public Struct18 imethod_0(DxfReader dxfReader)
    {
      if (this.int_0 < this.list_0.Count)
        return this.list_0[this.int_0++];
      return this.struct18_0;
    }

    public Struct18 imethod_1(DxfReader dxfReader, int baseGroupCode)
    {
      if (this.int_0 < this.list_0.Count)
        return this.list_0[this.int_0++];
      return this.struct18_0;
    }

    public Struct18 imethod_2(DxfReader dxfReader)
    {
      return this.imethod_0(dxfReader);
    }

    public void imethod_3(bool close)
    {
      this.int_0 = this.list_0.Count;
    }

    public string Position
    {
      get
      {
        return "XRecordValuesGroupReader at " + (object) this.int_0 + "/" + (object) this.list_0.Count;
      }
    }
  }
}
