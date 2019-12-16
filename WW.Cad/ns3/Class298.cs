// Decompiled with JetBrains decompiler
// Type: ns3.Class298
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Model.Entities;

namespace ns3
{
  internal class Class298 : Class285
  {
    private List<Class659> list_1 = new List<Class659>();

    public Class298(DxfHatch hatch)
      : base((DxfEntity) hatch)
    {
    }

    public List<Class659> BoundaryPathBuilders
    {
      get
      {
        return this.list_1;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      foreach (Class659 class659 in this.list_1)
        class659.ResolveReferences(modelBuilder);
      DxfHatch handledObject = (DxfHatch) this.HandledObject;
      if (!handledObject.Associative)
        return;
      bool flag = false;
      foreach (DxfHatch.BoundaryPath boundaryPath in handledObject.BoundaryPaths)
      {
        if (boundaryPath.BoundaryObjects.Count > 0)
        {
          flag = true;
          break;
        }
      }
      if (flag)
        return;
      handledObject.Associative = false;
    }
  }
}
