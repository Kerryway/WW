// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfTableAttribute
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.IO;

namespace WW.Cad.Model.Entities
{
  public class DxfTableAttribute
  {
    private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
    private string string_0 = string.Empty;

    public DxfAttributeDefinition AttributeDefinition
    {
      get
      {
        return (DxfAttributeDefinition) this.dxfObjectReference_0.Value;
      }
      set
      {
        this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public string Value
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value ?? string.Empty;
      }
    }

    internal DxfTableAttribute Clone(CloneContext cloneContext)
    {
      DxfTableAttribute dxfTableAttribute = new DxfTableAttribute();
      dxfTableAttribute.CopyFrom(this, cloneContext);
      return dxfTableAttribute;
    }

    private void CopyFrom(DxfTableAttribute from, CloneContext cloneContext)
    {
      if (from.AttributeDefinition != null)
        this.AttributeDefinition = cloneContext.SourceModel != cloneContext.TargetModel ? (DxfAttributeDefinition) from.AttributeDefinition.Clone(cloneContext) : from.AttributeDefinition;
      this.string_0 = from.string_0;
    }

    internal void Write(DxfWriter w, int index)
    {
      w.method_218(330, (DxfHandledObject) this.AttributeDefinition);
      w.Write(301, (object) this.string_0);
      w.Write(92, (object) index);
    }
  }
}
