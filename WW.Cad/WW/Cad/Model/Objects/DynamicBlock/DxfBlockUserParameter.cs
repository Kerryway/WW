// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockUserParameter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockUserParameter : DxfBlockSinglePointParameter
  {
    private DxfObjectReference dxfObjectReference_3 = DxfObjectReference.Null;
    private short short_0;
    private string string_1;
    private DxfXRecordValue dxfXRecordValue_1;
    private short short_1;

    public short UnknownInt16
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

    public DxfHandledObject Variable
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_3.Value;
      }
      set
      {
        this.dxfObjectReference_3 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public string UnknownString
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

    public DxfXRecordValue Unknown
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

    public short ValueType
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

    public override string ObjectType
    {
      get
      {
        return "BLOCKUSERPARAMETER";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockUserParameter";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockUserParameter blockUserParameter = (DxfBlockUserParameter) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (blockUserParameter == null)
      {
        blockUserParameter = new DxfBlockUserParameter();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) blockUserParameter);
        blockUserParameter.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) blockUserParameter;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockUserParameter blockUserParameter = (DxfBlockUserParameter) from;
      this.UnknownInt16 = blockUserParameter.UnknownInt16;
      this.Variable = cloneContext.SourceModel == cloneContext.TargetModel ? blockUserParameter.Variable : (DxfHandledObject) cloneContext.Clone((IGraphCloneable) blockUserParameter.Variable);
      this.UnknownString = blockUserParameter.UnknownString;
      this.Unknown = (DxfXRecordValue) cloneContext.Clone((IGraphCloneable) blockUserParameter.Unknown);
      this.ValueType = blockUserParameter.ValueType;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_1.ClassNumber;
    }

    public enum UserParamValueType : byte
    {
      Distance,
      Area,
      Volume,
      Real,
      Angle,
      String,
    }
  }
}
