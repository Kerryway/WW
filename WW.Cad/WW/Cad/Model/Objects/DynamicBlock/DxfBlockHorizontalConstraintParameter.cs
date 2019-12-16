// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockHorizontalConstraintParameter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using ns3;
using WW.Cad.IO;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockHorizontalConstraintParameter : DxfBlockLinearConstraintParameter
  {
    public override string ObjectType
    {
      get
      {
        return "BLOCKHORIZONTALCONSTRAINTPARAMETER";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockHorizontalConstraintParameter";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockHorizontalConstraintParameter constraintParameter = (DxfBlockHorizontalConstraintParameter) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (constraintParameter == null)
      {
        constraintParameter = new DxfBlockHorizontalConstraintParameter();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) constraintParameter);
        constraintParameter.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) constraintParameter;
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.method_234("AcDbBlockHorizontalConstraintParameter");
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      base.Read(r, objectBuilder);
      r.method_85();
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_34.ClassNumber;
    }
  }
}
