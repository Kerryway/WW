// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockLinearConstraintParameter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using ns3;
using WW.Cad.IO;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockLinearConstraintParameter : DxfBlockConstraintParameter
  {
    private DxfBlockParametersValueSet dxfBlockParametersValueSet_0;
    private double double_0;
    private string string_1;

    public DxfBlockParametersValueSet ValueSet
    {
      get
      {
        return this.dxfBlockParametersValueSet_0;
      }
      set
      {
        this.dxfBlockParametersValueSet_0 = value;
      }
    }

    public double Value
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
      }
    }

    public string Description
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

    public override string ObjectType
    {
      get
      {
        return "BLOCKLINEARCONSTRAINTPARAMETER";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockLinearConstraintParameter";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockLinearConstraintParameter constraintParameter = (DxfBlockLinearConstraintParameter) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (constraintParameter == null)
      {
        constraintParameter = new DxfBlockLinearConstraintParameter();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) constraintParameter);
        constraintParameter.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) constraintParameter;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockLinearConstraintParameter constraintParameter = (DxfBlockLinearConstraintParameter) from;
      this.ValueSet = (DxfBlockParametersValueSet) cloneContext.Clone((IGraphCloneable) constraintParameter.ValueSet);
      this.Value = constraintParameter.Value;
      this.Description = constraintParameter.Description;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_33.ClassNumber;
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      Interface29 objectWriter = ow.ObjectWriter;
      objectWriter.imethod_4(this.Name);
      objectWriter.imethod_4(this.Description);
      objectWriter.imethod_16(this.Value);
      this.dxfBlockParametersValueSet_0.Write(objectWriter);
    }

    internal override void Read(Class434 or, Class259 ob)
    {
      base.Read(or, ob);
      Interface30 objectBitStream = or.ObjectBitStream;
      this.Name = objectBitStream.ReadString();
      this.Description = objectBitStream.ReadString();
      this.Value = objectBitStream.imethod_8();
      this.dxfBlockParametersValueSet_0 = or.method_5();
    }

    internal void method_8(DxfWriter w)
    {
      w.Write(305, (object) this.Name);
      w.Write(306, (object) this.Description);
      w.Write(140, (object) this.Value);
      w.method_33(this.dxfBlockParametersValueSet_0, (short) 96, (short) 141, (short) 175, (short) 307);
    }

    internal virtual void vmethod_11(DxfWriter w)
    {
      w.method_234("AcDbBlockLinearConstraintParameter");
      this.method_8(w);
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      this.vmethod_11(w);
    }

    internal void method_9(DxfReader r, string subclass)
    {
      while (!r.method_92(subclass))
      {
        switch (r.CurrentGroup.Code)
        {
          case 140:
            this.Value = (double) r.CurrentGroup.Value;
            break;
          case 305:
            this.Name = (string) r.CurrentGroup.Value;
            break;
          case 306:
            this.Description = (string) r.CurrentGroup.Value;
            break;
          case 307:
            this.ValueSet = r.method_37((short) 96, (short) 141, (short) 175, (short) 307);
            break;
        }
        r.method_85();
      }
    }

    internal virtual void vmethod_12(DxfReader r, Class259 objectBuilder)
    {
      this.method_9(r, "AcDbBlockLinearConstraintParameter");
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      base.Read(r, objectBuilder);
      this.vmethod_12(r, objectBuilder);
    }
  }
}
