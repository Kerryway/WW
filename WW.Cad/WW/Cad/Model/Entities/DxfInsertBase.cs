// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfInsertBase
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns2;
using System.Collections.Generic;
using WW.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Model.Tables;
using WW.Collections.Generic;
using WW.Math;

namespace WW.Cad.Model.Entities
{
  public abstract class DxfInsertBase : DxfEntity
  {
    private DxfObjectReference dxfObjectReference_6 = DxfObjectReference.Null;
    private readonly ActiveDxfHandledObjectCollection<DxfAttribute> activeDxfHandledObjectCollection_0 = new ActiveDxfHandledObjectCollection<DxfAttribute>();
    protected WW.Math.Point3D insertionPoint = WW.Math.Point3D.Zero;
    protected Vector3D scaleFactor = new Vector3D(1.0, 1.0, 1.0);
    private Vector3D vector3D_0 = Vector3D.ZAxis;
    private DxfObjectReference dxfObjectReference_7 = new DxfSequenceEnd().Reference;
    protected double rotation;

    public DxfInsertBase()
      : this((DxfBlock) null)
    {
    }

    public DxfInsertBase(DxfBlock block)
      : this(block, WW.Math.Point3D.Zero)
    {
    }

    public DxfInsertBase(DxfBlock block, WW.Math.Point3D insertionPoint)
    {
      this.Block = block;
      this.insertionPoint = insertionPoint;
      this.activeDxfHandledObjectCollection_0.Added += new ItemEventHandler<DxfAttribute>(this.method_15);
      this.activeDxfHandledObjectCollection_0.Set += new ItemSetEventHandler<DxfAttribute>(this.method_14);
      this.activeDxfHandledObjectCollection_0.Removed += new ItemEventHandler<DxfAttribute>(this.method_13);
      this.AttributesSeqEnd.vmethod_2((IDxfHandledObject) this);
    }

    public DxfBlock Block
    {
      get
      {
        return (DxfBlock) this.dxfObjectReference_6.Value;
      }
      set
      {
        this.dxfObjectReference_6 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public IList<DxfAttribute> Attributes
    {
      get
      {
        return (IList<DxfAttribute>) this.activeDxfHandledObjectCollection_0;
      }
    }

    public virtual WW.Math.Point3D InsertionPoint
    {
      get
      {
        return this.insertionPoint;
      }
      set
      {
        this.insertionPoint = value;
      }
    }

    public virtual double Rotation
    {
      get
      {
        return this.rotation;
      }
      set
      {
        this.rotation = value;
      }
    }

    public virtual Vector3D ScaleFactor
    {
      get
      {
        return this.scaleFactor;
      }
      set
      {
        this.scaleFactor = value;
      }
    }

    public Vector3D ZAxis
    {
      get
      {
        return this.vector3D_0;
      }
      set
      {
        this.vector3D_0 = value;
      }
    }

    internal DxfSequenceEnd AttributesSeqEnd
    {
      get
      {
        return (DxfSequenceEnd) this.dxfObjectReference_7.Value;
      }
      set
      {
        this.dxfObjectReference_7 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    protected internal override bool UseLayerEnabled
    {
      get
      {
        return false;
      }
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfAttribute>) this.activeDxfHandledObjectCollection_0)
        dxfHandledObject.vmethod_1(context);
    }

    protected internal override void ExecuteDeepHelper(
      WW.Cad.Model.Action action,
      Stack<DxfHandledObject> callerStack)
    {
      base.ExecuteDeepHelper(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfAttribute>) this.activeDxfHandledObjectCollection_0)
        dxfHandledObject.vmethod_0(action, callerStack);
      this.AttributesSeqEnd.vmethod_0(action, callerStack);
    }

    internal override void Repair(DxfModelRepairer repairer)
    {
      base.Repair(repairer);
      List<DxfBlock> blockChain = new List<DxfBlock>();
      this.Repair(repairer, this, blockChain);
    }

    private void Repair(DxfModelRepairer repairer, DxfInsertBase insert, List<DxfBlock> blockChain)
    {
      repairer.method_1((DxfHandledObject) this, "InsertionPoint", ref this.insertionPoint);
      repairer.method_6((DxfHandledObject) this, "ZAxis", ref this.vector3D_0);
      repairer.method_3((DxfHandledObject) this, "Rotation", ref this.rotation);
      repairer.method_5((DxfHandledObject) this, "ScaleFactor", ref this.scaleFactor);
      DxfBlock block = insert.Block;
      List<int> intList;
      if (block == null || repairer.BlockToEntityRemovalIndices.TryGetValue(block, out intList))
        return;
      repairer.BlockToEntityRemovalIndices.Add(block, (List<int>) null);
      blockChain.Add(block);
      for (int index = 0; index < block.Entities.Count; ++index)
      {
        DxfInsertBase entity = block.Entities[index] as DxfInsertBase;
        if (entity != null)
        {
          if (blockChain.Contains(entity.Block))
          {
            if (intList == null)
              intList = new List<int>();
            intList.Add(index);
            repairer.Messages.Add(new DxfMessage(DxfStatus.RecursiveBlockInsertRemoved, Severity.Error)
            {
              Parameters = {
                {
                  "Block",
                  (object) block
                },
                {
                  "BlockName",
                  (object) block.Name
                }
              }
            });
          }
          else
            this.Repair(repairer, entity, blockChain);
        }
      }
      blockChain.RemoveAt(blockChain.Count - 1);
      if (intList == null)
        return;
      repairer.BlockToEntityRemovalIndices[block] = intList;
    }

    public void ApplyInsertionPointOffsetToAttributes()
    {
      Vector3D insertionPoint = (Vector3D) this.insertionPoint;
      foreach (DxfAttribute dxfAttribute1 in (DxfHandledObjectCollection<DxfAttribute>) this.activeDxfHandledObjectCollection_0)
      {
        DxfAttribute dxfAttribute2 = dxfAttribute1;
        dxfAttribute2.AlignmentPoint1 = dxfAttribute2.AlignmentPoint1 + insertionPoint;
        if (dxfAttribute1.AlignmentPoint2.HasValue)
        {
          DxfAttribute dxfAttribute3 = dxfAttribute1;
          WW.Math.Point3D? alignmentPoint2 = dxfAttribute3.AlignmentPoint2;
          Vector3D vector3D = insertionPoint;
          dxfAttribute3.AlignmentPoint2 = alignmentPoint2.HasValue ? new WW.Math.Point3D?(alignmentPoint2.GetValueOrDefault() + vector3D) : new WW.Math.Point3D?();
        }
      }
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      this.CopyFrom((DxfInsertBase) from, cloneContext);
    }

    private void CopyFrom(DxfInsertBase from, CloneContext cloneContext)
    {
      base.CopyFrom((DxfHandledObject) from, cloneContext);
      this.Block = Class906.smethod_0(cloneContext, from.Block, false);
      this.activeDxfHandledObjectCollection_0.Clear();
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfAttribute>) from.activeDxfHandledObjectCollection_0)
        this.activeDxfHandledObjectCollection_0.Add((DxfAttribute) dxfHandledObject.Clone(cloneContext));
      this.insertionPoint = from.insertionPoint;
      this.scaleFactor = from.scaleFactor;
      this.rotation = from.rotation;
      this.vector3D_0 = from.vector3D_0;
      this.AttributesSeqEnd.CopyFrom((DxfHandledObject) from.AttributesSeqEnd, cloneContext);
    }

    public override void TransformMe(TransformConfig config, Matrix4D matrix)
    {
      this.TransformMe(config, matrix, (CommandGroup) null);
    }

    public override void TransformMe(
      TransformConfig config,
      Matrix4D matrix,
      CommandGroup undoGroup)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfInsertBase.Class476 class476 = new DxfInsertBase.Class476();
      // ISSUE: reference to a compiler-generated field
      class476.dxfInsertBase_0 = this;
      // ISSUE: reference to a compiler-generated field
      class476.vector3D_0 = this.vector3D_0;
      // ISSUE: reference to a compiler-generated field
      class476.point3D_0 = this.insertionPoint;
      // ISSUE: reference to a compiler-generated field
      class476.double_0 = this.rotation;
      // ISSUE: reference to a compiler-generated field
      class476.vector3D_1 = this.scaleFactor;
      this.vector3D_0 = matrix.Transform(this.ZAxis).GetUnit();
      Matrix4D inverse = DxfUtil.GetToWCSTransform(this.ZAxis).GetInverse();
      // ISSUE: reference to a compiler-generated field
      Matrix4D toWcsTransform = DxfUtil.GetToWCSTransform(class476.vector3D_0);
      // ISSUE: reference to a compiler-generated field
      this.insertionPoint = inverse.Transform(matrix.Transform(toWcsTransform.Transform(class476.point3D_0)));
      // ISSUE: reference to a compiler-generated field
      Vector3D vector3D = inverse.Transform(matrix.Transform(toWcsTransform.Transform(Transformation4D.RotateZ(class476.double_0).Transform(Vector3D.XAxis))));
      this.rotation = System.Math.Atan2(vector3D.Y, vector3D.X);
      if (this.Rotation < 0.0)
        this.Rotation += 2.0 * System.Math.PI;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.scaleFactor = Transformation4D.RotateZ(-this.Rotation).Transform(inverse.Transform(matrix.Transform(toWcsTransform.Transform(Transformation4D.RotateZ(class476.double_0).Transform(class476.vector3D_1)))));
      CommandGroup undoGroup1 = (CommandGroup) null;
      if (undoGroup != null)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        DxfInsertBase.Class477 class477 = new DxfInsertBase.Class477();
        // ISSUE: reference to a compiler-generated field
        class477.class476_0 = class476;
        undoGroup1 = new CommandGroup((object) this);
        undoGroup.UndoStack.Push((ICommand) undoGroup1);
        // ISSUE: reference to a compiler-generated field
        class477.vector3D_0 = this.vector3D_0;
        // ISSUE: reference to a compiler-generated field
        class477.point3D_0 = this.insertionPoint;
        // ISSUE: reference to a compiler-generated field
        class477.double_0 = this.rotation;
        // ISSUE: reference to a compiler-generated field
        class477.vector3D_1 = this.scaleFactor;
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup1.UndoStack.Push((ICommand) new Command((object) this, new System.Action(class477.method_0), new System.Action(class476.method_0)));
      }
      foreach (DxfEntity dxfEntity in (DxfHandledObjectCollection<DxfAttribute>) this.activeDxfHandledObjectCollection_0)
        dxfEntity.TransformMe(config, matrix, undoGroup1);
    }

    public override string ToString()
    {
      return base.ToString() + ", Block = " + (this.Block == null ? "null" : this.Block.Name);
    }

    private void method_13(object sender, int index, DxfAttribute item)
    {
      item.vmethod_2((IDxfHandledObject) null);
    }

    private void method_14(object sender, int index, DxfAttribute oldItem, DxfAttribute newItem)
    {
      oldItem.vmethod_2((IDxfHandledObject) null);
      newItem.vmethod_2((IDxfHandledObject) this);
    }

    private void method_15(object sender, int index, DxfAttribute item)
    {
      item.vmethod_2((IDxfHandledObject) this);
    }
  }
}
