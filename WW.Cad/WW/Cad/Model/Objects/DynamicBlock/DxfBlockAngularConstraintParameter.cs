// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockAngularConstraintParameter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using ns3;
using WW.Cad.IO;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockAngularConstraintParameter : DxfBlockConstraintParameter
  {
    private WW.Math.Point3D point3D_2;
    private WW.Math.Point3D point3D_3;
    private bool bool_2;
    private DxfBlockParametersValueSet dxfBlockParametersValueSet_0;
    private double double_0;
    private string string_1;

    public WW.Math.Point3D BasePointAngular
    {
      get
      {
        return this.point3D_2;
      }
      set
      {
        this.point3D_2 = value;
      }
    }

    public WW.Math.Point3D TextPosition
    {
      get
      {
        return this.point3D_3;
      }
      set
      {
        this.point3D_3 = value;
      }
    }

    public bool Unknown1
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
        return "BLOCKANGULARCONSTRAINTPARAMETER";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockAngularConstraintParameter";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockAngularConstraintParameter constraintParameter = (DxfBlockAngularConstraintParameter) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (constraintParameter == null)
      {
        constraintParameter = new DxfBlockAngularConstraintParameter();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) constraintParameter);
        constraintParameter.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) constraintParameter;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockAngularConstraintParameter constraintParameter = (DxfBlockAngularConstraintParameter) from;
      this.BasePointAngular = constraintParameter.BasePointAngular;
      this.TextPosition = constraintParameter.TextPosition;
      this.ValueSet = (DxfBlockParametersValueSet) cloneContext.Clone((IGraphCloneable) constraintParameter.ValueSet);
      this.Value = constraintParameter.Value;
      this.Description = constraintParameter.Description;
      this.Unknown1 = constraintParameter.Unknown1;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_37.ClassNumber;
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      Interface29 objectWriter = ow.ObjectWriter;
      objectWriter.imethod_24(this.point3D_2);
      objectWriter.imethod_24(this.point3D_3);
      objectWriter.imethod_4(this.Name);
      objectWriter.imethod_4(this.Description);
      objectWriter.imethod_16(this.Value);
      objectWriter.imethod_14(this.bool_2);
      this.dxfBlockParametersValueSet_0.Write(objectWriter);
    }

    internal override void Read(Class434 or, Class259 ob)
    {
      base.Read(or, ob);
      Interface30 objectBitStream = or.ObjectBitStream;
      this.BasePointAngular = objectBitStream.imethod_39();
      this.TextPosition = objectBitStream.imethod_39();
      this.Name = objectBitStream.ReadString();
      this.Description = objectBitStream.ReadString();
      this.Value = objectBitStream.imethod_8();
      this.Unknown1 = objectBitStream.imethod_6();
      this.dxfBlockParametersValueSet_0 = or.method_5();
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.method_234("AcDbBlockAngularConstraintParameter");
      w.Write(305, (object) this.Name);
      w.Write(306, (object) this.Description);
      w.Write(1011, this.BasePointAngular);
      w.Write(1012, this.TextPosition);
      w.Write(140, (object) this.Value);
      w.Write(280, (object) this.Unknown1);
      w.method_33(this.dxfBlockParametersValueSet_0, (short) 96, (short) 141, (short) 175, (short) 307);
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      base.Read(r, objectBuilder);
      while (!r.method_92("AcDbBlockAngularConstraintParameter"))
      {
        switch (r.CurrentGroup.Code)
        {
          case 140:
            this.Value = (double) r.CurrentGroup.Value;
            break;
          case 290:
            this.Unknown1 = (bool) r.CurrentGroup.Value;
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
          case 1011:
            this.point3D_2.X = (double) r.CurrentGroup.Value;
            break;
          case 1012:
            this.point3D_3.X = (double) r.CurrentGroup.Value;
            break;
          case 1021:
            this.point3D_2.Y = (double) r.CurrentGroup.Value;
            break;
          case 1022:
            this.point3D_3.Y = (double) r.CurrentGroup.Value;
            break;
          case 1031:
            this.point3D_2.Z = (double) r.CurrentGroup.Value;
            break;
          case 1032:
            this.point3D_3.Z = (double) r.CurrentGroup.Value;
            break;
        }
        r.method_85();
      }
    }
  }
}
