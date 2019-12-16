// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DisplayStyle
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using WW.Cad.IO;

namespace WW.Cad.Model.Objects
{
  public class DisplayStyle
  {
    private DisplayFlags displayFlags_0 = DisplayFlags.Backgrounds;
    private double double_0;
    private ShadowType shadowType_0;

    public DisplayFlags DisplayFlags
    {
      get
      {
        return this.displayFlags_0;
      }
      set
      {
        this.displayFlags_0 = value;
      }
    }

    public double Brightness
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

    public ShadowType ShadowType
    {
      get
      {
        return this.shadowType_0;
      }
      set
      {
        this.shadowType_0 = value;
      }
    }

    public void CopyFrom(DisplayStyle from, CloneContext cloneContext)
    {
      this.displayFlags_0 = from.displayFlags_0;
      this.double_0 = from.double_0;
      this.shadowType_0 = from.shadowType_0;
    }

    internal void Write(Class432 ow, DxfVisualStyle.Class488 pw)
    {
      if (ow.Version < DxfVersion.Dxf24)
      {
        pw.vmethod_4((int) this.displayFlags_0);
        pw.vmethod_4((int) this.double_0);
        pw.vmethod_4((int) this.shadowType_0);
      }
      else
      {
        pw.vmethod_4((int) this.displayFlags_0);
        pw.vmethod_5(this.double_0);
        pw.vmethod_4((int) this.shadowType_0);
      }
    }

    internal void Read(Class434 or, DxfVisualStyle.Class486 pr)
    {
      if (or.Version < DxfVersion.Dxf24)
      {
        this.displayFlags_0 = (DisplayFlags) pr.vmethod_3();
        this.double_0 = (double) pr.vmethod_3();
        this.shadowType_0 = (ShadowType) pr.vmethod_3();
      }
      else
      {
        this.displayFlags_0 = (DisplayFlags) pr.vmethod_3();
        this.double_0 = pr.vmethod_4();
        this.shadowType_0 = (ShadowType) pr.vmethod_3();
      }
    }

    internal void Write(DxfWriter w, DxfVisualStyle.Class490 pw)
    {
      pw.Write(93, (object) (int) this.DisplayFlags);
      pw.Write(44, (object) this.Brightness);
      pw.Write(173, (object) (short) this.ShadowType);
    }
  }
}
