// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.FaceStyle
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using WW.Cad.IO;

namespace WW.Cad.Model.Objects
{
  public class FaceStyle
  {
    private FaceLightingQuality faceLightingQuality_0 = FaceLightingQuality.PerVertexLighting;
    private FaceColorMode faceColorMode_0 = FaceColorMode.ObjectColor;
    private double double_0 = 0.6;
    private double double_1 = 30.0;
    private Color color_0 = Color.CreateFromColorIndex((short) 5);
    private Color color_1 = Color.CreateFromRgb(16777215);
    private FaceLightingModel faceLightingModel_0;
    private FaceModifierFlags faceModifierFlags_0;

    public FaceLightingModel LightingModel
    {
      get
      {
        return this.faceLightingModel_0;
      }
      set
      {
        this.faceLightingModel_0 = value;
      }
    }

    public FaceLightingQuality LightingQuality
    {
      get
      {
        return this.faceLightingQuality_0;
      }
      set
      {
        this.faceLightingQuality_0 = value;
      }
    }

    public FaceColorMode ColorMode
    {
      get
      {
        return this.faceColorMode_0;
      }
      set
      {
        this.faceColorMode_0 = value;
      }
    }

    public FaceModifierFlags FaceModifierFlags
    {
      get
      {
        return this.faceModifierFlags_0;
      }
      set
      {
        this.faceModifierFlags_0 = value;
      }
    }

    public double OpacityLevel
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

    public double SpecularLevel
    {
      get
      {
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
      }
    }

    public Color UnknownColor
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
      }
    }

    public Color MonoColor
    {
      get
      {
        return this.color_1;
      }
      set
      {
        this.color_1 = value;
      }
    }

    public void CopyFrom(FaceStyle from, CloneContext cloneContext)
    {
      this.faceLightingModel_0 = from.faceLightingModel_0;
      this.faceLightingQuality_0 = from.faceLightingQuality_0;
      this.faceColorMode_0 = from.faceColorMode_0;
      this.faceModifierFlags_0 = from.faceModifierFlags_0;
      this.double_0 = from.double_0;
      this.double_1 = from.double_1;
      this.color_0 = from.color_0;
      this.color_1 = from.color_1;
    }

    internal void Write(Class432 ow, DxfVisualStyle.Class488 pw)
    {
      if (ow.Version < DxfVersion.Dxf24)
      {
        pw.vmethod_4((int) this.faceLightingModel_0);
        pw.vmethod_4((int) this.faceLightingQuality_0);
        pw.vmethod_4((int) this.faceColorMode_0);
        pw.vmethod_5(this.double_0);
        pw.vmethod_5(this.double_1);
        pw.vmethod_6(this.color_1);
        pw.vmethod_4((int) this.faceModifierFlags_0);
      }
      else
      {
        pw.vmethod_4((int) this.faceLightingModel_0);
        pw.vmethod_4((int) this.faceLightingQuality_0);
        pw.vmethod_4((int) this.faceColorMode_0);
        pw.vmethod_4((int) this.faceModifierFlags_0);
        pw.vmethod_5(this.double_0);
        pw.vmethod_5(this.double_1);
        pw.vmethod_6(this.color_1);
      }
    }

    internal void Read(Class434 or, DxfVisualStyle.Class486 pr)
    {
      if (or.Version < DxfVersion.Dxf24)
      {
        this.faceLightingModel_0 = (FaceLightingModel) pr.vmethod_3();
        this.faceLightingQuality_0 = (FaceLightingQuality) pr.vmethod_3();
        this.faceColorMode_0 = (FaceColorMode) pr.vmethod_3();
        this.double_0 = pr.vmethod_4();
        this.double_1 = pr.vmethod_4();
        this.color_1 = pr.vmethod_5();
        this.faceModifierFlags_0 = (FaceModifierFlags) pr.vmethod_3();
      }
      else
      {
        this.faceLightingModel_0 = (FaceLightingModel) pr.vmethod_3();
        this.faceLightingQuality_0 = (FaceLightingQuality) pr.vmethod_3();
        this.faceColorMode_0 = (FaceColorMode) pr.vmethod_3();
        this.faceModifierFlags_0 = (FaceModifierFlags) pr.vmethod_3();
        this.double_0 = pr.vmethod_4();
        this.double_1 = pr.vmethod_4();
        this.color_1 = pr.vmethod_5();
      }
    }

    internal void Write(DxfWriter w, DxfVisualStyle.Class490 pw)
    {
      pw.Write(71, (object) (short) this.LightingModel);
      pw.Write(72, (object) (short) this.LightingQuality);
      pw.Write(73, (object) (short) this.ColorMode);
      pw.Write(90, (object) (int) this.FaceModifierFlags);
      pw.Write(40, (object) this.OpacityLevel);
      pw.Write(41, (object) this.SpecularLevel);
      if (w.Version < DxfVersion.Dxf27)
        w.method_230(62, this.UnknownColor);
      pw.vmethod_0(63, this.MonoColor);
    }
  }
}
