// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockConstraintParameter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns27;
using ns28;
using ns3;
using WW.Cad.Base;
using WW.Cad.IO;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockConstraintParameter : DxfBlockTwoPointsParameter
  {
    private DxfHandledObject dxfHandledObject_0;

    public DxfHandledObject Dependency
    {
      get
      {
        return this.dxfHandledObject_0;
      }
      set
      {
        this.dxfHandledObject_0 = value;
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockLinearConstraintParameter";
      }
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockConstraintParameter constraintParameter = (DxfBlockConstraintParameter) from;
      this.Dependency = (DxfHandledObject) cloneContext.Clone((IGraphCloneable) constraintParameter.Dependency);
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      ow.method_1((DxfBlockTwoPointsParameter) this);
      ow.ObjectWriter.imethod_40(this.dxfHandledObject_0);
    }

    internal override Class259 vmethod_9(FileFormat fileFormat)
    {
      return (Class259) new Class266(this);
    }

    internal override void Read(Class434 or, Class259 ob)
    {
      or.method_8((Class260) ob, false);
      ((Class266) ob).Dependency = or.method_100();
    }

    internal override void Write(DxfWriter w)
    {
      w.method_52((DxfBlockTwoPointsParameter) this, false);
      w.method_234("AcDbBlockConstraintParameter");
      w.method_218(330, this.Dependency);
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      r.method_67((Class265) objectBuilder, false);
      r.method_85();
      if (r.CurrentGroup.Code != 330)
        throw new DxfException("Expected GC 330 here.");
      ((Class266) objectBuilder).Dependency = (ulong) r.CurrentGroup.Value;
      r.method_85();
    }
  }
}
