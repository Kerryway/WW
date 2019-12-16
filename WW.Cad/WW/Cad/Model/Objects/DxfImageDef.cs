// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfImageDef
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using WW.Drawing;
using WW.Math;

namespace WW.Cad.Model.Objects
{
  public class DxfImageDef : DxfObject
  {
    private Size2D size2D_1 = new Size2D(1.0, 1.0);
    private string string_0;
    private Size2D size2D_0;
    private ResolutionUnits resolutionUnits_0;
    private bool bool_0;
    private int int_0;
    private readonly DxfModel dxfModel_0;
    private IBitmap ibitmap_0;
    private static int int_1;

    public DxfImageDef(DxfModel model)
    {
      this.dxfModel_0 = model;
    }

    public string Filename
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
        this.ibitmap_0 = (IBitmap) null;
      }
    }

    public IBitmap Bitmap
    {
      get
      {
        if (this.ibitmap_0 == null)
          this.ibitmap_0 = GdiBitmap.LoadBitmap(this.string_0, this.dxfModel_0.Filename, DxfImageDef.int_1);
        return this.ibitmap_0;
      }
    }

    public static int DownloadTimeoutMs
    {
      get
      {
        return DxfImageDef.int_1;
      }
      set
      {
        DxfImageDef.int_1 = value;
      }
    }

    public Size2D Size
    {
      get
      {
        return this.size2D_0;
      }
      set
      {
        this.size2D_0 = value;
      }
    }

    public Size2D DefaultPixelSize
    {
      get
      {
        return this.size2D_1;
      }
      set
      {
        this.size2D_1 = value;
      }
    }

    public ResolutionUnits ResolutionUnits
    {
      get
      {
        return this.resolutionUnits_0;
      }
      set
      {
        this.resolutionUnits_0 = value;
      }
    }

    public bool ImageIsLoaded
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public void SetBitmap(IBitmap bitmap)
    {
      this.ibitmap_0 = bitmap;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_12.ClassNumber;
    }

    internal override bool vmethod_5(DxfModel dxfModel)
    {
      return dxfModel.Header.Dxf13OrHigher;
    }

    public override string ObjectType
    {
      get
      {
        return "IMAGEDEF";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbRasterImageDef";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfImageDef dxfImageDef = (DxfImageDef) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfImageDef == null)
      {
        dxfImageDef = new DxfImageDef(cloneContext.TargetModel);
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfImageDef);
        dxfImageDef.CopyFrom((DxfHandledObject) this, cloneContext);
        cloneContext.TargetModel.Images.Add(dxfImageDef);
      }
      return (IGraphCloneable) dxfImageDef;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfImageDef dxfImageDef = (DxfImageDef) from;
      this.string_0 = dxfImageDef.string_0;
      this.size2D_0 = dxfImageDef.size2D_0;
      this.size2D_1 = dxfImageDef.size2D_1;
      this.resolutionUnits_0 = dxfImageDef.resolutionUnits_0;
      this.bool_0 = dxfImageDef.bool_0;
      this.int_0 = dxfImageDef.int_0;
      this.ibitmap_0 = dxfImageDef.ibitmap_0;
    }

    public override void Dispose()
    {
      base.Dispose();
      if (this.ibitmap_0 == null)
        return;
      this.ibitmap_0.Dispose();
      this.ibitmap_0 = (IBitmap) null;
    }

    internal int ClassVersion
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }
  }
}
