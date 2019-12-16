// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfIdBuffer
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects
{
  public class DxfIdBuffer : DxfObject
  {
    private DxfHandledObjectCollection<DxfHandledObject> dxfHandledObjectCollection_1 = new DxfHandledObjectCollection<DxfHandledObject>();
    private byte byte_0;

    public DxfHandledObjectCollection<DxfHandledObject> HandledObjects
    {
      get
      {
        return this.dxfHandledObjectCollection_1;
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_5.ClassNumber;
    }

    public override string ObjectType
    {
      get
      {
        return "IDBUFFER";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbIdBuffer";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf13OrHigher;
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfIdBuffer dxfIdBuffer = (DxfIdBuffer) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfIdBuffer == null)
      {
        dxfIdBuffer = new DxfIdBuffer();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfIdBuffer);
        dxfIdBuffer.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfIdBuffer;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfIdBuffer dxfIdBuffer = (DxfIdBuffer) from;
      this.byte_0 = dxfIdBuffer.byte_0;
      this.dxfHandledObjectCollection_1.Clear();
      if (cloneContext.SourceModel == cloneContext.TargetModel)
      {
        this.dxfHandledObjectCollection_1 = dxfIdBuffer.dxfHandledObjectCollection_1;
      }
      else
      {
        foreach (DxfHandledObject dxfHandledObject in dxfIdBuffer.dxfHandledObjectCollection_1)
          this.dxfHandledObjectCollection_1.Add((DxfHandledObject) cloneContext.Clone((IGraphCloneable) dxfHandledObject));
      }
    }

    internal byte Unknown1
    {
      get
      {
        return this.byte_0;
      }
      set
      {
        this.byte_0 = value;
      }
    }
  }
}
