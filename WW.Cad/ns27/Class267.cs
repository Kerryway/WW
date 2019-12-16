// Decompiled with JetBrains decompiler
// Type: ns27.Class267
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
  internal class Class267 : Class265
  {
    private ulong[] ulong_2;
    private ulong[][] ulong_3;
    private ulong[][] ulong_4;

    public Class267(DxfBlockVisibilityParameter obj)
      : base((DxfEvalGraphExpression) obj)
    {
    }

    public ulong[][] SelectionSet1
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

    public ulong[][] SelectionSet2
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

    public ulong[] HandleSet
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
      DxfBlockVisibilityParameter visibilityParameter = this.Object as DxfBlockVisibilityParameter;
      if (visibilityParameter == null)
        return;
      if (this.ulong_2 != null && this.ulong_2.Length != 0)
      {
        visibilityParameter.HandleSet = new DxfHandledObjectCollection<DxfHandledObject>(this.ulong_2.Length);
        for (int index = 0; index < this.ulong_2.Length; ++index)
        {
          if (this.ulong_2[index] != 0UL)
          {
            DxfHandledObject dxfHandledObject = modelBuilder.method_3(this.ulong_2[index]);
            if (dxfHandledObject == null)
              throw new Exception("Cannot resolve handle.");
            visibilityParameter.HandleSet.Add(dxfHandledObject);
          }
        }
      }
      else
        visibilityParameter.HandleSet = (DxfHandledObjectCollection<DxfHandledObject>) null;
      for (int index1 = 0; index1 < visibilityParameter.VisibilityStates.Length; ++index1)
      {
        if (this.ulong_3[index1] != null && this.ulong_3[index1].Length != 0)
        {
          int length = this.ulong_3[index1].Length;
          visibilityParameter.VisibilityStates[index1].SelectionSet1 = new DxfHandledObjectCollection<DxfHandledObject>(length);
          for (int index2 = 0; index2 < length; ++index2)
          {
            if (this.ulong_3[index1][index2] != 0UL)
            {
              DxfHandledObject dxfHandledObject = modelBuilder.method_3(this.ulong_3[index1][index2]);
              if (dxfHandledObject == null)
                throw new Exception("Cannot resolve handle.");
              visibilityParameter.VisibilityStates[index1].SelectionSet1.Add(dxfHandledObject);
            }
          }
        }
        else
          visibilityParameter.VisibilityStates[index1].SelectionSet1 = (DxfHandledObjectCollection<DxfHandledObject>) null;
      }
      for (int index1 = 0; index1 < visibilityParameter.VisibilityStates.Length; ++index1)
      {
        if (this.ulong_4[index1] != null && this.ulong_4[index1].Length != 0)
        {
          int length = this.ulong_4[index1].Length;
          visibilityParameter.VisibilityStates[index1].SelectionSet2 = new DxfHandledObjectCollection<DxfHandledObject>(length);
          for (int index2 = 0; index2 < length; ++index2)
          {
            if (this.ulong_4[index1][index2] != 0UL)
            {
              DxfHandledObject dxfHandledObject = modelBuilder.method_3(this.ulong_4[index1][index2]);
              if (dxfHandledObject == null)
                throw new Exception("Cannot resolve handle.");
              visibilityParameter.VisibilityStates[index1].SelectionSet2.Add(dxfHandledObject);
            }
          }
        }
        else
          visibilityParameter.VisibilityStates[index1].SelectionSet2 = (DxfHandledObjectCollection<DxfHandledObject>) null;
      }
      if (visibilityParameter.HandleSet != null)
      {
        foreach (DxfHandledObject handle in visibilityParameter.HandleSet)
        {
          if (handle == null)
          {
            Class740.smethod_14(visibilityParameter.OwnerObjectSoftReference as DxfEvalGraph);
            return;
          }
        }
      }
      if (visibilityParameter.VisibilityStates == null || visibilityParameter.VisibilityStates == null)
        return;
      for (int index = 0; index < visibilityParameter.VisibilityStates.Length; ++index)
      {
        if (visibilityParameter.VisibilityStates[index].SelectionSet1 != null)
        {
          foreach (DxfHandledObject dxfHandledObject in visibilityParameter.VisibilityStates[index].SelectionSet1)
          {
            if (dxfHandledObject == null)
            {
              Class740.smethod_14(visibilityParameter.OwnerObjectSoftReference as DxfEvalGraph);
              return;
            }
          }
        }
        if (visibilityParameter.VisibilityStates[index].SelectionSet2 != null)
        {
          foreach (DxfHandledObject dxfHandledObject in visibilityParameter.VisibilityStates[index].SelectionSet2)
          {
            if (dxfHandledObject == null)
            {
              Class740.smethod_14(visibilityParameter.OwnerObjectSoftReference as DxfEvalGraph);
              return;
            }
          }
        }
      }
    }
  }
}
