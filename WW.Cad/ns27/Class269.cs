// Decompiled with JetBrains decompiler
// Type: ns27.Class269
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns46;
using WW.Cad.Model;
using WW.Cad.Model.Objects.DynamicBlock;

namespace ns27
{
  internal class Class269 : Class268
  {
    private ulong[] ulong_3;

    public Class269(DxfBlockStretchAction obj)
      : base((DxfBlockAction) obj)
    {
    }

    public ulong[] StretchEntities
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

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfBlockStretchAction blockStretchAction = this.Object as DxfBlockStretchAction;
      if (this.ulong_3 != null && this.ulong_3.Length != 0)
      {
        for (int index = 0; index < this.ulong_3.Length; ++index)
          blockStretchAction.StretchEntities[index].Entity = modelBuilder.method_4<DxfHandledObject>(this.ulong_3[index]);
      }
      else
        blockStretchAction.StretchEntities = (DxfBlockPolarStretchAction.StretchEntity[]) null;
      if (blockStretchAction.StretchEntities == null)
        return;
      foreach (DxfBlockPolarStretchAction.StretchEntity stretchEntity in blockStretchAction.StretchEntities)
      {
        if (stretchEntity.Entity == null)
        {
          Class740.smethod_14(blockStretchAction.OwnerObjectSoftReference as DxfEvalGraph);
          break;
        }
      }
    }
  }
}
