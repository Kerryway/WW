// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockAction
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockAction : DxfBlockElement
  {
    private DxfEvalGraph.GraphNodeId[] graphNodeId_1;
    private DxfHandledObjectCollection<DxfHandledObject> dxfHandledObjectCollection_1;
    private WW.Math.Point3D point3D_0;

    public WW.Math.Point3D Position
    {
      get
      {
        return this.point3D_0;
      }
      set
      {
        this.point3D_0 = value;
      }
    }

    public DxfEvalGraph.GraphNodeId[] AttachedElements
    {
      get
      {
        return this.graphNodeId_1;
      }
      set
      {
        this.graphNodeId_1 = value;
      }
    }

    public DxfHandledObjectCollection<DxfHandledObject> AttachedEntities
    {
      get
      {
        return this.dxfHandledObjectCollection_1;
      }
      set
      {
        this.dxfHandledObjectCollection_1 = value;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockAction";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      throw new Exception("This method shouldn't be called.");
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      throw new Exception("The class is base. Clone shouldn't be used.");
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockAction dxfBlockAction = from as DxfBlockAction;
      this.Position = dxfBlockAction.Position;
      this.AttachedElements = DxfEvalGraph.GraphNodeId.Clone(cloneContext, dxfBlockAction.AttachedElements);
      if (dxfBlockAction.AttachedEntities != null && dxfBlockAction.AttachedEntities.Count != 0)
      {
        int count = dxfBlockAction.AttachedEntities.Count;
        this.AttachedEntities = new DxfHandledObjectCollection<DxfHandledObject>(count);
        for (int index = 0; index < count; ++index)
        {
          if (dxfBlockAction.AttachedEntities[index] == null)
            this.AttachedEntities.Add((DxfHandledObject) null);
          else if (cloneContext.SourceModel == cloneContext.TargetModel)
            this.AttachedEntities.Add(dxfBlockAction.AttachedEntities[index]);
          else
            this.AttachedEntities.Add(dxfBlockAction.AttachedEntities[index].Clone(cloneContext) as DxfHandledObject);
        }
      }
      else
        this.AttachedEntities = (DxfHandledObjectCollection<DxfHandledObject>) null;
    }

    public enum ScaleTypeXY : byte
    {
      XY,
      X,
      Y,
    }
  }
}
