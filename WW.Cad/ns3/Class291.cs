// Decompiled with JetBrains decompiler
// Type: ns3.Class291
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class291 : Class285
  {
    private ulong ulong_6;
    private ulong ulong_7;
    private double? nullable_3;
    private bool bool_1;

    public Class291(DxfLeader leader)
      : base((DxfEntity) leader)
    {
    }

    public ulong AssociatedAnnotationHandle
    {
      get
      {
        return this.ulong_6;
      }
      set
      {
        this.ulong_6 = value;
      }
    }

    public ulong DimensionStyleHandle
    {
      get
      {
        return this.ulong_7;
      }
      set
      {
        this.ulong_7 = value;
      }
    }

    public double? ArrowSizeTimesScaleOverride
    {
      get
      {
        return this.nullable_3;
      }
      set
      {
        this.nullable_3 = value;
      }
    }

    public bool CalculateHookLinePoint
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfLeader entity = (DxfLeader) this.Entity;
      if (this.ulong_7 != 0UL)
      {
        DxfDimensionStyle dxfDimensionStyle = modelBuilder.method_4<DxfDimensionStyle>(this.ulong_7);
        if (dxfDimensionStyle != null)
          entity.DimensionStyle = dxfDimensionStyle;
      }
      DxfExtendedData extendedData;
      if (entity.DimensionStyleOverrides != null && entity.ExtendedDataCollection.TryGetValue(modelBuilder.Model.AppIdAcad, out extendedData))
        Class309.smethod_0(entity.DimensionStyleOverrides, extendedData, modelBuilder);
      if (this.nullable_3.HasValue)
        entity.DimensionStyleOverrides.ArrowSize = this.nullable_3.Value / entity.DimensionStyleOverrides.ScaleFactor;
      if (this.ulong_6 != 0UL)
        entity.AssociatedAnnotation = modelBuilder.method_4<DxfEntity>(this.ulong_6);
      if (!this.CalculateHookLinePoint)
        return;
      int count = entity.Vertices.Count;
      entity.Vertices.Add(entity.Vertices[count - 1]);
      double num = entity.DimensionStyleOverrides == null ? 0.0 : entity.DimensionStyleOverrides.ArrowSize;
      if (entity.HookLineDirection != HookLineDirection.Same)
        num = -num;
      entity.Vertices[count - 1] += entity.HorizontalDirection * num;
    }
  }
}
