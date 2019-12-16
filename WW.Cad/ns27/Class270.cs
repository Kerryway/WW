// Decompiled with JetBrains decompiler
// Type: ns27.Class270
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns46;
using System;
using WW.Cad.Model;
using WW.Cad.Model.Objects.DynamicBlock;

namespace ns27
{
  internal class Class270 : Class268
  {
    private ulong[] ulong_3;
    private ulong[] ulong_4;

    public Class270(DxfBlockPolarStretchAction obj)
      : base((DxfBlockAction) obj)
    {
    }

    public ulong[] RotateSelection
    {
      get
      {
        return this.ulong_3;
      }
      set
      {
        this.ulong_3 = value;
      }
    }

    public ulong[] StretchEntities
    {
      get
      {
        return this.ulong_4;
      }
      set
      {
        this.ulong_4 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfBlockPolarStretchAction polarStretchAction = this.Object as DxfBlockPolarStretchAction;
      if (polarStretchAction == null)
        return;
      if (this.ulong_3 != null && this.ulong_3.Length != 0)
      {
        polarStretchAction.RotateSelection = new DxfHandledObjectCollection<DxfHandledObject>(this.ulong_3.Length);
        for (int index = 0; index < this.ulong_3.Length; ++index)
        {
          polarStretchAction.RotateSelection.Add(modelBuilder.method_3(this.ulong_3[index]));
          if (polarStretchAction.RotateSelection[index] == null)
            throw new Exception("Cannot resolve handle.");
        }
      }
      else
        polarStretchAction.RotateSelection = (DxfHandledObjectCollection<DxfHandledObject>) null;
      if (this.ulong_4 != null && this.ulong_4.Length != 0)
      {
        for (int index = 0; index < this.ulong_4.Length; ++index)
        {
          polarStretchAction.StretchEntities[index].Entity = modelBuilder.method_3(this.ulong_4[index]);
          if (polarStretchAction.StretchEntities[index].Entity == null)
            throw new Exception("Cannot resolve handle.");
        }
      }
      else
        polarStretchAction.StretchEntities = (DxfBlockPolarStretchAction.StretchEntity[]) null;
      if (polarStretchAction.RotateSelection != null)
      {
        foreach (DxfHandledObject dxfHandledObject in polarStretchAction.RotateSelection)
        {
          if (dxfHandledObject == null)
          {
            Class740.smethod_14(polarStretchAction.OwnerObjectSoftReference as DxfEvalGraph);
            return;
          }
        }
      }
      if (polarStretchAction.StretchEntities == null)
        return;
      foreach (DxfBlockPolarStretchAction.StretchEntity stretchEntity in polarStretchAction.StretchEntities)
      {
        if (stretchEntity.Entity == null)
        {
          Class740.smethod_14(polarStretchAction.OwnerObjectSoftReference as DxfEvalGraph);
          break;
        }
      }
    }
  }
}
