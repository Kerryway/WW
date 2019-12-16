// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.Annotations.DxfScale
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using ns3;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model.Tables;

namespace WW.Cad.Model.Objects.Annotations
{
  public class DxfScale : DxfObject
  {
    private string string_0 = string.Empty;
    private double double_0 = 1.0;
    private double double_1 = 1.0;
    private bool bool_0;
    private bool bool_1;

    public DxfScale()
    {
    }

    public DxfScale(
      string name,
      double paperUnits,
      double drawingUnits,
      bool isTemporaryScale,
      bool isUnitScale)
    {
      this.string_0 = name;
      this.double_0 = paperUnits;
      this.double_1 = drawingUnits;
      this.bool_0 = isTemporaryScale;
      this.bool_1 = isUnitScale;
    }

    public string Name
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value ?? string.Empty;
      }
    }

    public double PaperUnits
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

    public double DrawingUnits
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

    public bool IsTemporaryScale
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

    public bool IsUnitScale
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

    public double ScaleFactor
    {
      get
      {
        return this.PaperUnits / this.DrawingUnits;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "SCALE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbScale";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf18OrHigher;
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfScale dxfScale = (DxfScale) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfScale == null)
      {
        dxfScale = new DxfScale();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfScale);
        dxfScale.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfScale;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfScale dxfScale = (DxfScale) from;
      this.string_0 = dxfScale.string_0;
      this.double_0 = dxfScale.double_0;
      this.double_1 = dxfScale.double_1;
      this.bool_0 = dxfScale.bool_0;
      this.bool_1 = dxfScale.bool_1;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_15.ClassNumber;
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      ow.ObjectWriter.imethod_32((short) 0);
      ow.ObjectWriter.imethod_4(this.string_0);
      ow.ObjectWriter.imethod_16(this.double_0);
      ow.ObjectWriter.imethod_16(this.double_1);
      ow.ObjectWriter.imethod_14(this.bool_1);
    }

    internal override void Read(Class434 or, Class259 ob)
    {
      base.Read(or, ob);
      Interface30 objectBitStream = or.ObjectBitStream;
      this.bool_0 = objectBitStream.imethod_14() == (short) 1;
      this.string_0 = objectBitStream.ReadString();
      if (this.string_0 == "")
        throw new DxfException("Invalid scale name");
      this.double_0 = objectBitStream.imethod_8();
      this.double_1 = objectBitStream.imethod_8();
      this.bool_1 = objectBitStream.imethod_6();
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.method_234("AcDbScale");
      w.method_219(70, (short) 0);
      w.Write(300, (object) this.string_0);
      w.Write(140, (object) this.double_0);
      w.Write(141, (object) this.double_1);
      w.Write(290, (object) this.bool_1);
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      while (r.CurrentGroup.Code != 0)
      {
        if (r.CurrentGroup.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) r.CurrentGroup.Value)
        {
          case "AcDbScale":
            this.method_8(r, objectBuilder);
            continue;
          default:
            r.method_85();
            continue;
        }
      }
    }

    private void method_8(DxfReader r, Class259 objectBuilder)
    {
      r.method_91("AcDbScale");
      r.method_85();
      while (!r.method_92("AcDbScale"))
      {
        if (!this.method_9(r, objectBuilder))
          r.method_85();
      }
    }

    private bool method_9(DxfReader r, Class259 objectBuilder)
    {
      switch (r.CurrentGroup.Code)
      {
        case 70:
          r.method_85();
          return true;
        case 140:
          this.double_0 = (double) r.CurrentGroup.Value;
          goto case 70;
        case 141:
          this.double_1 = (double) r.CurrentGroup.Value;
          goto case 70;
        case 290:
          this.bool_1 = (bool) r.CurrentGroup.Value;
          goto case 70;
        case 300:
          this.Name = (string) r.CurrentGroup.Value;
          if (this.string_0 == "")
            throw new DxfException("Invalid scale name");
          goto case 70;
        default:
          return this.method_6(r, objectBuilder);
      }
    }

    public override string ToString()
    {
      return this.string_0;
    }

    internal static DxfExtendedData smethod_2(DxfLayer layer)
    {
      if (layer == null || !layer.HasExtendedData)
        return (DxfExtendedData) null;
      DxfModel model = layer.Model;
      if (model == null)
        return (DxfExtendedData) null;
      DxfExtendedData extendedData;
      if (!layer.ExtendedDataCollection.TryGetValue(model, "AcadAnnotativeDecomposition", out extendedData))
        return (DxfExtendedData) null;
      return extendedData;
    }

    internal static DxfExtendedData smethod_3(DxfHandledObject o)
    {
      if (!o.HasExtendedData)
        return (DxfExtendedData) null;
      DxfModel model = o.Model;
      if (model == null)
        return (DxfExtendedData) null;
      DxfExtendedData extendedData;
      if ((o.ExtendedDataCollection.TryGetValue(model, "AcadAnnotativeDecomposition", out extendedData) || o.ExtendedDataCollection.TryGetValue(model, "AcadAnnotativeMTextDecomposition", out extendedData) ? 1 : (o.ExtendedDataCollection.TryGetValue(model, "AcadNonAnnoHatchDecomposition", out extendedData) ? 1 : 0)) == 0)
        return (DxfExtendedData) null;
      return extendedData;
    }

    internal static DxfScale smethod_4(DxfLayer layer, out DxfLayer oldLayer)
    {
      oldLayer = (DxfLayer) null;
      if (layer.ExtensionDictionary == null)
        return (DxfScale) null;
      IDictionaryEntry first = layer.ExtensionDictionary.Entries.GetFirst("ASDK_XREC_ANNO_SCALE_INFO");
      if (first == null)
        return (DxfScale) null;
      DxfXRecord dxfXrecord = first.Value as DxfXRecord;
      if (dxfXrecord == null)
        return (DxfScale) null;
      if (dxfXrecord.Values.Count < 2)
        return (DxfScale) null;
      DxfScale dxfScale = dxfXrecord.Values[1].Value as DxfScale;
      if (dxfXrecord.Values.Count > 2)
        oldLayer = dxfXrecord.Values[2].Value as DxfLayer;
      return dxfScale;
    }
  }
}
