// Decompiled with JetBrains decompiler
// Type: ns27.Class268
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns46;
using WW.Cad.Model;
using WW.Cad.Model.Objects.DynamicBlock;

namespace ns27
{
  internal class Class268 : Class265
  {
    private ulong[] ulong_2;

    public Class268(DxfBlockAction obj)
      : base((DxfEvalGraphExpression) obj)
    {
    }

    public ulong[] AttachedEntities
    {
      get
      {
        return this.ulong_2;
      }
      set
      {
        this.ulong_2 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfBlockAction dxfBlockAction = this.Object as DxfBlockAction;
      if (dxfBlockAction == null)
        return;
      if (this.ulong_2 != null && this.ulong_2.Length != 0)
      {
        dxfBlockAction.AttachedEntities = new DxfHandledObjectCollection<DxfHandledObject>(this.ulong_2.Length);
        for (int index = 0; index < this.ulong_2.Length; ++index)
          dxfBlockAction.AttachedEntities.Add(modelBuilder.method_3(this.ulong_2[index]));
      }
      else
        dxfBlockAction.AttachedEntities = (DxfHandledObjectCollection<DxfHandledObject>) null;
      if (dxfBlockAction.AttachedEntities == null)
        return;
      foreach (DxfHandledObject attachedEntity in dxfBlockAction.AttachedEntities)
      {
        if (attachedEntity == null)
        {
          Class740.smethod_14(dxfBlockAction.OwnerObjectSoftReference as DxfEvalGraph);
          break;
        }
      }
    }
  }
}
