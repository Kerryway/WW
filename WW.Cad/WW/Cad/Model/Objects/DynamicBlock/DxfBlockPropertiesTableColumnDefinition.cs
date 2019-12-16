// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockPropertiesTableColumnDefinition
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockPropertiesTableColumnDefinition : IGraphCloneable
  {
    private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
    private short short_1 = -1;
    private DxfConnectionPoint dxfConnectionPoint_0 = new DxfConnectionPoint();
    private bool bool_1 = true;
    private bool bool_2 = true;
    private DxfObjectReference dxfObjectReference_1 = DxfObjectReference.Null;
    private short short_0;
    private string string_0;
    private DxfXRecordValue dxfXRecordValue_0;
    private DxfXRecordValue dxfXRecordValue_1;
    private bool bool_0;
    private bool bool_3;
    private bool bool_4;
    private string string_1;

    public DxfObject Parameter
    {
      get
      {
        return (DxfObject) this.dxfObjectReference_0.Value;
      }
      set
      {
        this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfObject UnknownObject1
    {
      get
      {
        return (DxfObject) this.dxfObjectReference_1.Value;
      }
      set
      {
        this.dxfObjectReference_1 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public short UnknownInt1
    {
      get
      {
        return this.short_0;
      }
      set
      {
        this.short_0 = value;
      }
    }

    public short UnknownInt2
    {
      get
      {
        return this.short_1;
      }
      set
      {
        this.short_1 = value;
      }
    }

    public string UnknownString1
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

    public string UnknownString2
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
      }
    }

    public DxfConnectionPoint ConnectionPoint
    {
      get
      {
        return this.dxfConnectionPoint_0;
      }
      set
      {
        this.dxfConnectionPoint_0 = value;
      }
    }

    public DxfXRecordValue DefaultDoNotMatchValue
    {
      get
      {
        return this.dxfXRecordValue_1;
      }
      set
      {
        this.dxfXRecordValue_1 = value;
      }
    }

    public DxfXRecordValue UnknownValue1
    {
      get
      {
        return this.dxfXRecordValue_0;
      }
      set
      {
        this.dxfXRecordValue_0 = value;
      }
    }

    public bool UnknownFlag1
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public bool UnknownFlag2
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public bool UnknownFlag3
    {
      get
      {
        return this.bool_2;
      }
      set
      {
        this.bool_2 = value;
      }
    }

    public bool UnknownFlag4
    {
      get
      {
        return this.bool_3;
      }
      set
      {
        this.bool_3 = value;
      }
    }

    public bool UnknownFlag5
    {
      get
      {
        return this.bool_4;
      }
      set
      {
        this.bool_4 = value;
      }
    }

    public IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockPropertiesTableColumnDefinition columnDefinition = (DxfBlockPropertiesTableColumnDefinition) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (columnDefinition == null)
      {
        columnDefinition = new DxfBlockPropertiesTableColumnDefinition();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) columnDefinition);
        columnDefinition.Parameter = this.Parameter.Clone(cloneContext) as DxfObject;
        columnDefinition.UnknownInt1 = (short) 0;
        columnDefinition.UnknownInt2 = (short) -1;
        columnDefinition.UnknownString1 = this.UnknownString1;
        columnDefinition.ConnectionPoint = (DxfConnectionPoint) cloneContext.Clone((IGraphCloneable) this.ConnectionPoint);
        columnDefinition.UnknownValue1 = (DxfXRecordValue) cloneContext.Clone((IGraphCloneable) this.UnknownValue1);
        columnDefinition.DefaultDoNotMatchValue = (DxfXRecordValue) cloneContext.Clone((IGraphCloneable) this.DefaultDoNotMatchValue);
        columnDefinition.UnknownFlag1 = this.UnknownFlag1;
        columnDefinition.UnknownFlag2 = this.UnknownFlag2;
        columnDefinition.UnknownFlag3 = this.UnknownFlag3;
        columnDefinition.UnknownFlag4 = this.UnknownFlag4;
        columnDefinition.UnknownFlag5 = this.UnknownFlag5;
        columnDefinition.UnknownString2 = this.UnknownString2;
        columnDefinition.UnknownObject1 = this.UnknownObject1.Clone(cloneContext) as DxfObject;
      }
      return (IGraphCloneable) columnDefinition;
    }
  }
}
