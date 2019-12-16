// Decompiled with JetBrains decompiler
// Type: WW.Cad.IO.PdfPageConfiguration
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using System.Drawing.Printing;
using WW.Cad.Drawing;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.IO
{
  public class PdfPageConfiguration
  {
    private double double_0 = 1.0;
    private PaperSize paperSize_0 = PaperSizes.GetPaperSize(PaperKind.Letter);
    private DxfModel dxfModel_0;
    private GraphicsConfig graphicsConfig_0;
    private Matrix4D matrix4D_0;
    private DxfLayout dxfLayout_0;
    private ICollection<DxfViewport> icollection_0;
    private Rectangle2D? nullable_0;

    public PdfPageConfiguration(
      DxfModel model,
      GraphicsConfig graphicsConfig,
      Matrix4D transform,
      PaperSize paperSize)
    {
      this.dxfModel_0 = model;
      this.graphicsConfig_0 = graphicsConfig;
      this.matrix4D_0 = transform;
      this.paperSize_0 = paperSize;
    }

    public DxfModel Model
    {
      get
      {
        return this.dxfModel_0;
      }
    }

    public GraphicsConfig GraphicsConfig
    {
      get
      {
        return this.graphicsConfig_0;
      }
    }

    public Matrix4D Transform
    {
      get
      {
        return this.matrix4D_0;
      }
    }

    public double DrawingUnitsToPdfUnits
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
      }
    }

    public DxfLayout Layout
    {
      get
      {
        return this.dxfLayout_0;
      }
      set
      {
        this.dxfLayout_0 = value;
      }
    }

    public ICollection<DxfViewport> Viewports
    {
      get
      {
        return this.icollection_0;
      }
      set
      {
        this.icollection_0 = value;
      }
    }

    public PaperSize PaperSize
    {
      get
      {
        return this.paperSize_0;
      }
      set
      {
        this.paperSize_0 = value;
      }
    }

    public Rectangle2D? ClipRectangle
    {
      get
      {
        return this.nullable_0;
      }
      set
      {
        this.nullable_0 = value;
      }
    }
  }
}
