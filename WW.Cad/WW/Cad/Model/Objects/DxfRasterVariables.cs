// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfRasterVariables
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using ns3;
using WW.Cad.Base;
using WW.Cad.IO;

namespace WW.Cad.Model.Objects
{
  public class DxfRasterVariables : DxfObject
  {
    private ImageDisplayFrameFlag imageDisplayFrameFlag_0 = ImageDisplayFrameFlag.FrameAboveImage;
    private ImageDisplayQuality imageDisplayQuality_0 = ImageDisplayQuality.High;
    private int int_0;
    private ImageInsertionUnits imageInsertionUnits_0;

    public int ClassVersion
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

    public ImageDisplayFrameFlag ImageDisplayFrameFlag
    {
      get
      {
        return this.imageDisplayFrameFlag_0;
      }
      set
      {
        this.imageDisplayFrameFlag_0 = value;
      }
    }

    public ImageDisplayQuality ImageDisplayQuality
    {
      get
      {
        return this.imageDisplayQuality_0;
      }
      set
      {
        this.imageDisplayQuality_0 = value;
      }
    }

    public ImageInsertionUnits ImageInsertionUnits
    {
      get
      {
        return this.imageInsertionUnits_0;
      }
      set
      {
        this.imageInsertionUnits_0 = value;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "RASTERVARIABLES";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbRasterVariables";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfRasterVariables dxfRasterVariables = (DxfRasterVariables) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfRasterVariables == null)
      {
        dxfRasterVariables = new DxfRasterVariables();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfRasterVariables);
        dxfRasterVariables.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfRasterVariables;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfRasterVariables dxfRasterVariables = (DxfRasterVariables) from;
      this.int_0 = dxfRasterVariables.int_0;
      this.imageDisplayFrameFlag_0 = dxfRasterVariables.imageDisplayFrameFlag_0;
      this.imageDisplayQuality_0 = dxfRasterVariables.imageDisplayQuality_0;
      this.imageInsertionUnits_0 = dxfRasterVariables.imageInsertionUnits_0;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_14.ClassNumber;
    }

    internal void method_8(Class432 ow)
    {
      base.Write(ow);
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      ow.ObjectWriter.imethod_33(this.int_0);
      ow.ObjectWriter.imethod_32((short) this.imageDisplayFrameFlag_0);
      ow.ObjectWriter.imethod_32((short) this.imageDisplayQuality_0);
      ow.ObjectWriter.imethod_32((short) this.imageInsertionUnits_0);
    }

    internal override void Read(Class434 or, Class259 ob)
    {
      base.Read(or, ob);
      Interface30 objectBitStream = or.ObjectBitStream;
      this.int_0 = objectBitStream.imethod_11();
      this.imageDisplayFrameFlag_0 = (ImageDisplayFrameFlag) objectBitStream.imethod_14();
      this.imageDisplayQuality_0 = (ImageDisplayQuality) objectBitStream.imethod_14();
      this.imageInsertionUnits_0 = (ImageInsertionUnits) objectBitStream.imethod_14();
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.method_234(this.AcClass);
      w.Write(90, (object) this.int_0);
      w.method_219(70, (short) this.imageDisplayFrameFlag_0);
      w.method_219(71, (short) this.imageDisplayQuality_0);
      w.method_219(72, (short) this.imageInsertionUnits_0);
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      base.Read(r, objectBuilder);
      if (r.CurrentGroup.Code != 100)
        throw new DxfException("Expected subclass marker.");
      string str = (string) r.CurrentGroup.Value;
      if ((string) r.CurrentGroup.Value == this.AcClass)
        this.method_9(r, objectBuilder);
      else
        r.method_85();
    }

    private void method_9(DxfReader r, Class259 objectBuilder)
    {
      r.method_91(this.AcClass);
      r.method_85();
      while (!r.method_92(this.AcClass))
      {
        if (!this.method_10(r, objectBuilder))
          r.method_85();
      }
    }

    private bool method_10(DxfReader r, Class259 objectBuilder)
    {
      switch (r.CurrentGroup.Code)
      {
        case 70:
          this.ImageDisplayFrameFlag = (ImageDisplayFrameFlag) r.CurrentGroup.Value;
          break;
        case 71:
          this.ImageDisplayQuality = (ImageDisplayQuality) r.CurrentGroup.Value;
          break;
        case 72:
          this.ImageInsertionUnits = (ImageInsertionUnits) r.CurrentGroup.Value;
          break;
        case 90:
          this.int_0 = (int) r.CurrentGroup.Value;
          break;
        default:
          return this.method_6(r, objectBuilder);
      }
      r.method_85();
      return true;
    }
  }
}
