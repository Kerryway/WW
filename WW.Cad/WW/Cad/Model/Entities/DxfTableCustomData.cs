// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfTableCustomData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.IO;

namespace WW.Cad.Model.Entities
{
  public class DxfTableCustomData
  {
    private string string_0 = string.Empty;
    private DxfValue dxfValue_0 = new DxfValue();

    public string Name
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }

    public DxfValue Value
    {
      get
      {
        return this.dxfValue_0;
      }
    }

    public DxfTableCustomData Clone(CloneContext cloneContext)
    {
      return new DxfTableCustomData() { string_0 = this.string_0, dxfValue_0 = this.dxfValue_0 != null ? this.dxfValue_0.Clone(cloneContext) : (DxfValue) null };
    }

    internal void Write(DxfWriter w)
    {
      w.Write(300, (object) this.string_0);
      w.Write(301, (object) "DATAMAP_VALUE");
      this.dxfValue_0.Write(w);
    }
  }
}
