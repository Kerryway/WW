// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.GraphicElement1
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using WW.Cad.Model.Entities;
using WW.Drawing;

namespace WW.Cad.Drawing.Surface
{
  public class GraphicElement1 : IGraphicElement
  {
    private Geometry geometry_0;
    private ArgbColor argbColor_0;

    public GraphicElement1()
    {
      this.geometry_0 = new Geometry();
    }

    public GraphicElement1(ArgbColor color)
    {
      this.argbColor_0 = color;
      this.geometry_0 = new Geometry();
    }

    public GraphicElement1(Geometry geometry, ArgbColor color)
    {
      if (geometry == null)
        throw new ArgumentNullException(nameof (geometry));
      this.geometry_0 = geometry;
      this.argbColor_0 = color;
    }

    public Geometry Geometry
    {
      get
      {
        return this.geometry_0;
      }
    }

    public ArgbColor Color
    {
      get
      {
        return this.argbColor_0;
      }
    }

    public bool Matches(ArgbColor color)
    {
      return color == this.argbColor_0;
    }

    public virtual void Accept(IGraphicElementVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal class Class939
    {
      private DxfEntity dxfEntity_0;
      private ArgbColor argbColor_0;

      public Class939(DxfEntity entity, ArgbColor color)
      {
        this.dxfEntity_0 = entity;
        this.argbColor_0 = color;
      }

      public DxfEntity Entity
      {
        get
        {
          return this.dxfEntity_0;
        }
      }

      public ArgbColor Color
      {
        get
        {
          return this.argbColor_0;
        }
      }

      public override int GetHashCode()
      {
        return this.dxfEntity_0.GetHashCode() ^ this.argbColor_0.GetHashCode();
      }

      public override bool Equals(object obj)
      {
        GraphicElement1.Class939 class939 = obj as GraphicElement1.Class939;
        if (class939 == null || this.dxfEntity_0 != class939.dxfEntity_0)
          return false;
        return this.argbColor_0 == class939.argbColor_0;
      }
    }
  }
}
