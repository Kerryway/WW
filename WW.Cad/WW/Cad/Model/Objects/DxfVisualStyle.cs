// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfVisualStyle
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using ns3;
using System;
using WW.Cad.Base;
using WW.Cad.IO;

namespace WW.Cad.Model.Objects
{
  public class DxfVisualStyle : DxfObject, INamedObject
  {
    private string string_0 = "2dWireframe";
    private VisualStyleType visualStyleType_0 = VisualStyleType.Wireframe2D;
    private FaceStyle faceStyle_0 = new FaceStyle();
    private EdgeStyle edgeStyle_0 = new EdgeStyle();
    private DisplayStyle displayStyle_0 = new DisplayStyle();
    private DxfVisualStyle.Operation[] operation_0 = new DxfVisualStyle.Operation[Enum.GetValues(typeof (DxfVisualStyle.Enum14)).Length];
    private bool bool_1 = true;
    private bool bool_2 = true;
    private int int_0 = 50;
    private double double_2 = 1.0;
    private Color color_0 = Color.CreateFromRgb(0);
    private int int_2 = 50;
    private int int_3 = 3;
    private Color color_1 = Color.CreateFromRgb((int) byte.MaxValue);
    private int int_4 = 50;
    private int int_5 = 50;
    private int int_6 = 50;
    private int int_7 = 50;
    private Color color_2 = Color.ByLayer;
    private double double_3 = 1.0;
    private string string_1 = "strokes_ogs.tif";
    private double double_4 = 1.0;
    private double double_5 = 1.0;
    private bool bool_0;
    private double double_0;
    private short short_0;
    private bool bool_3;
    private bool bool_4;
    private bool bool_5;
    private bool bool_6;
    private bool bool_7;
    private bool bool_8;
    private bool bool_9;
    private double double_1;
    private int int_1;
    private bool bool_10;
    private bool bool_11;
    private bool bool_12;

    public DxfVisualStyle()
    {
      int num = 0;
      foreach (DxfVisualStyle.Enum14 enum14 in Enum.GetValues(typeof (DxfVisualStyle.Enum14)))
        this.operation_0[num++] = DxfVisualStyle.Operation.Set;
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

    public VisualStyleType Type
    {
      get
      {
        return this.visualStyleType_0;
      }
      set
      {
        this.visualStyleType_0 = value;
      }
    }

    public FaceStyle FaceStyle
    {
      get
      {
        return this.faceStyle_0;
      }
    }

    public EdgeStyle EdgeStyle
    {
      get
      {
        return this.edgeStyle_0;
      }
    }

    public DisplayStyle DisplayStyle
    {
      get
      {
        return this.displayStyle_0;
      }
    }

    public bool InternalUseOnlyFlag
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

    public double Unknown
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

    public short Version
    {
      get
      {
        return this.short_0;
      }
      set
      {
        this.short_0 = value;
      }
    }

    public DxfVisualStyle.Operation[] PropertyOperations
    {
      get
      {
        return this.operation_0;
      }
    }

    public bool UseDrawOrder
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

    public bool ViewportTransparencyEnabled
    {
      get
      {
        return this.bool_2;
      }
      set
      {
        this.bool_2 = value;
      }
    }

    public bool LightingEnabled
    {
      get
      {
        return this.bool_3;
      }
      set
      {
        this.bool_3 = value;
      }
    }

    public bool PosterizeEffectEnabled
    {
      get
      {
        return this.bool_4;
      }
      set
      {
        this.bool_4 = value;
      }
    }

    public bool MonoEffectEnabled
    {
      get
      {
        return this.bool_5;
      }
      set
      {
        this.bool_5 = value;
      }
    }

    public bool BlurEffectEnabled
    {
      get
      {
        return this.bool_6;
      }
      set
      {
        this.bool_6 = value;
      }
    }

    public bool PencilEffectEnabled
    {
      get
      {
        return this.bool_7;
      }
      set
      {
        this.bool_7 = value;
      }
    }

    public bool BloomEffectEnabled
    {
      get
      {
        return this.bool_8;
      }
      set
      {
        this.bool_8 = value;
      }
    }

    public bool PastelEffectEnabled
    {
      get
      {
        return this.bool_9;
      }
      set
      {
        this.bool_9 = value;
      }
    }

    public int BlurAmount
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

    public double PencilAngle
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

    public double PencilScale
    {
      get
      {
        return this.double_2;
      }
      set
      {
        this.double_2 = value;
      }
    }

    public int PencilPattern
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
      }
    }

    public Color PencilColor
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

    public int BloomThreshold
    {
      get
      {
        return this.int_2;
      }
      set
      {
        this.int_2 = value;
      }
    }

    public int BloomRadius
    {
      get
      {
        return this.int_3;
      }
      set
      {
        this.int_3 = value;
      }
    }

    public Color TintColor
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

    public bool FaceAdjustmentEnabled
    {
      get
      {
        return this.bool_10;
      }
      set
      {
        this.bool_10 = value;
      }
    }

    public int PostContrast
    {
      get
      {
        return this.int_4;
      }
      set
      {
        this.int_4 = value;
      }
    }

    public int PostBrightness
    {
      get
      {
        return this.int_5;
      }
      set
      {
        this.int_5 = value;
      }
    }

    public int PostPower
    {
      get
      {
        return this.int_6;
      }
      set
      {
        this.int_6 = value;
      }
    }

    public bool TintEffectEnabled
    {
      get
      {
        return this.bool_11;
      }
      set
      {
        this.bool_11 = value;
      }
    }

    public int BloomIntensity
    {
      get
      {
        return this.int_7;
      }
      set
      {
        this.int_7 = value;
      }
    }

    public Color Color
    {
      get
      {
        return this.color_2;
      }
      set
      {
        this.color_2 = value;
      }
    }

    public double Transparency
    {
      get
      {
        return this.double_3;
      }
      set
      {
        this.double_3 = value;
      }
    }

    public string EdgeTexturePath
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value ?? string.Empty;
      }
    }

    public bool DepthOfFieldEnabled
    {
      get
      {
        return this.bool_12;
      }
      set
      {
        this.bool_12 = value;
      }
    }

    public double FocusDistance
    {
      get
      {
        return this.double_4;
      }
      set
      {
        this.double_4 = value;
      }
    }

    public double FocusWidth
    {
      get
      {
        return this.double_5;
      }
      set
      {
        this.double_5 = value;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "VISUALSTYLE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbVisualStyle";
      }
    }

    public static DxfVisualStyle Create2DWireframeVisualStyle()
    {
      return new DxfVisualStyle();
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfVisualStyle dxfVisualStyle = (DxfVisualStyle) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfVisualStyle == null)
      {
        dxfVisualStyle = new DxfVisualStyle();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfVisualStyle);
        dxfVisualStyle.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfVisualStyle;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfVisualStyle dxfVisualStyle = (DxfVisualStyle) from;
      this.string_0 = dxfVisualStyle.string_0;
      this.visualStyleType_0 = dxfVisualStyle.visualStyleType_0;
      dxfVisualStyle.faceStyle_0.CopyFrom(dxfVisualStyle.faceStyle_0, cloneContext);
      dxfVisualStyle.edgeStyle_0.CopyFrom(dxfVisualStyle.edgeStyle_0, cloneContext);
      dxfVisualStyle.displayStyle_0.CopyFrom(dxfVisualStyle.displayStyle_0, cloneContext);
      this.bool_0 = dxfVisualStyle.bool_0;
      this.double_0 = dxfVisualStyle.double_0;
      this.short_0 = dxfVisualStyle.short_0;
      for (int index = 0; index < this.operation_0.Length; ++index)
        this.operation_0[index] = dxfVisualStyle.operation_0[index];
      this.bool_1 = dxfVisualStyle.bool_1;
      this.bool_2 = dxfVisualStyle.bool_2;
      this.bool_3 = dxfVisualStyle.bool_3;
      this.bool_4 = dxfVisualStyle.bool_4;
      this.bool_5 = dxfVisualStyle.bool_5;
      this.bool_6 = dxfVisualStyle.bool_6;
      this.bool_7 = dxfVisualStyle.bool_7;
      this.bool_8 = dxfVisualStyle.bool_8;
      this.bool_9 = dxfVisualStyle.bool_9;
      this.int_0 = dxfVisualStyle.int_0;
      this.double_1 = dxfVisualStyle.double_1;
      this.double_2 = dxfVisualStyle.double_2;
      this.int_1 = dxfVisualStyle.int_1;
      this.color_0 = dxfVisualStyle.color_0;
      this.int_2 = dxfVisualStyle.int_2;
      this.int_3 = dxfVisualStyle.int_3;
      this.color_1 = dxfVisualStyle.color_1;
      this.bool_10 = dxfVisualStyle.bool_10;
      this.int_4 = dxfVisualStyle.int_4;
      this.int_5 = dxfVisualStyle.int_5;
      this.int_6 = dxfVisualStyle.int_6;
      this.bool_11 = dxfVisualStyle.bool_11;
      this.int_7 = dxfVisualStyle.int_7;
      this.color_2 = dxfVisualStyle.color_2;
      this.double_3 = dxfVisualStyle.double_3;
      this.string_1 = dxfVisualStyle.string_1;
      this.bool_12 = dxfVisualStyle.bool_12;
      this.double_4 = dxfVisualStyle.double_4;
      this.double_5 = dxfVisualStyle.double_5;
    }

    internal static DxfClass smethod_2(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "VISUALSTYLE");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1021;
        dxfClass.MaintenanceVersion = (short) 0;
        dxfClass.ProxyFlags = (ProxyFlags) 4095;
        dxfClass.CPlusPlusClassName = "AcDbVisualStyle";
        dxfClass.DxfName = "VISUALSTYLE";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_22.ClassNumber;
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.AcadVersion >= DxfVersion.Dxf21;
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      Interface29 objectWriter = ow.ObjectWriter;
      objectWriter.imethod_4(this.string_0);
      objectWriter.imethod_33((int) this.visualStyleType_0);
      DxfVisualStyle.Class488 pw;
      if (ow.Version < DxfVersion.Dxf24)
      {
        pw = new DxfVisualStyle.Class488(this, objectWriter);
      }
      else
      {
        pw = (DxfVisualStyle.Class488) new DxfVisualStyle.Class489(this, objectWriter);
        objectWriter.imethod_32((short) 2);
        objectWriter.imethod_14(this.bool_0);
      }
      this.faceStyle_0.Write(ow, pw);
      this.edgeStyle_0.Write(ow, pw);
      this.displayStyle_0.Write(ow, pw);
      if (ow.Version == DxfVersion.Dxf21)
        objectWriter.imethod_16(this.double_0);
      if (ow.Version < DxfVersion.Dxf24)
        objectWriter.imethod_14(this.bool_0);
      if (ow.Version <= DxfVersion.Dxf24)
        return;
      pw.vmethod_0(this.bool_1);
      pw.vmethod_0(this.bool_2);
      pw.vmethod_0(this.bool_3);
      pw.vmethod_0(this.bool_4);
      pw.vmethod_0(this.bool_5);
      pw.vmethod_0(this.bool_6);
      pw.vmethod_0(this.bool_7);
      pw.vmethod_0(this.bool_8);
      pw.vmethod_0(this.bool_9);
      pw.vmethod_4(this.int_0);
      pw.vmethod_5(this.double_1);
      pw.vmethod_5(this.double_2);
      pw.vmethod_4(this.int_1);
      pw.vmethod_6(this.color_0);
      pw.vmethod_4(this.int_2);
      pw.vmethod_4(this.int_3);
      pw.vmethod_6(this.color_1);
      pw.vmethod_0(this.bool_10);
      pw.vmethod_4(this.int_4);
      pw.vmethod_4(this.int_5);
      pw.vmethod_4(this.int_6);
      pw.vmethod_0(this.bool_11);
      pw.vmethod_4(this.int_7);
      pw.vmethod_6(this.color_2);
      pw.vmethod_5(this.double_3);
      pw.vmethod_4((int) this.edgeStyle_0.WiggleAmount);
      pw.WriteString(this.string_1);
      pw.vmethod_0(this.bool_12);
      pw.vmethod_5(this.double_4);
      pw.vmethod_5(this.double_5);
    }

    internal override void Read(Class434 or, Class259 objectBuilder)
    {
      base.Read(or, objectBuilder);
      Interface30 objectBitStream = or.ObjectBitStream;
      this.string_0 = objectBitStream.ReadString();
      this.visualStyleType_0 = (VisualStyleType) objectBitStream.imethod_11();
      DxfVisualStyle.Class486 pr;
      if (or.Version < DxfVersion.Dxf24)
      {
        pr = new DxfVisualStyle.Class486(this, objectBitStream);
      }
      else
      {
        pr = (DxfVisualStyle.Class486) new DxfVisualStyle.Class487(this, objectBitStream);
        this.short_0 = objectBitStream.imethod_14();
        this.bool_0 = objectBitStream.imethod_6();
      }
      this.faceStyle_0.Read(or, pr);
      this.edgeStyle_0.Read(or, pr);
      this.displayStyle_0.Read(or, pr);
      if (or.Version == DxfVersion.Dxf21)
        this.double_0 = objectBitStream.imethod_8();
      if (or.Version < DxfVersion.Dxf24)
        this.bool_0 = objectBitStream.imethod_6();
      if (or.Version <= DxfVersion.Dxf24)
        return;
      this.bool_1 = pr.vmethod_0();
      this.bool_2 = pr.vmethod_0();
      this.bool_3 = pr.vmethod_0();
      this.bool_4 = pr.vmethod_0();
      this.bool_5 = pr.vmethod_0();
      this.bool_6 = pr.vmethod_0();
      this.bool_7 = pr.vmethod_0();
      this.bool_8 = pr.vmethod_0();
      this.bool_9 = pr.vmethod_0();
      this.int_0 = pr.vmethod_3();
      this.double_1 = pr.vmethod_4();
      this.double_2 = pr.vmethod_4();
      this.int_1 = pr.vmethod_3();
      this.color_0 = pr.vmethod_5();
      this.int_2 = pr.vmethod_3();
      this.int_3 = pr.vmethod_3();
      this.color_1 = pr.vmethod_5();
      this.bool_10 = pr.vmethod_0();
      this.int_4 = pr.vmethod_3();
      this.int_5 = pr.vmethod_3();
      this.int_6 = pr.vmethod_3();
      this.bool_11 = pr.vmethod_0();
      this.int_7 = pr.vmethod_3();
      this.color_2 = pr.vmethod_5();
      this.double_3 = pr.vmethod_4();
      this.edgeStyle_0.WiggleAmount = (WiggleAmount) pr.vmethod_3();
      this.string_1 = pr.ReadString();
      this.bool_12 = pr.vmethod_0();
      this.double_4 = pr.vmethod_4();
      this.double_5 = pr.vmethod_4();
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.method_234("AcDbVisualStyle");
      w.Write(2, (object) this.string_0);
      w.method_219(70, (short) this.visualStyleType_0);
      if (w.Version <= DxfVersion.Dxf21)
      {
        DxfVisualStyle.Class490 pw = new DxfVisualStyle.Class490(this, w);
        this.faceStyle_0.Write(w, pw);
        this.edgeStyle_0.Write(w, pw);
        this.displayStyle_0.Write(w, pw);
        w.Write(291, (object) this.bool_0);
        w.Write(45, (object) this.double_0);
      }
      else
      {
        w.Write(177, (object) (short) (w.Version > DxfVersion.Dxf24 ? 3 : 2));
        w.Write(291, (object) this.bool_0);
        if (w.Version > DxfVersion.Dxf24)
        {
          w.Write(70, (object) (short) this.operation_0.Length);
          DxfVisualStyle.Class492 class492 = new DxfVisualStyle.Class492(this, w);
          this.faceStyle_0.Write(w, (DxfVisualStyle.Class490) class492);
          this.edgeStyle_0.Write(w, (DxfVisualStyle.Class490) class492);
          this.displayStyle_0.Write(w, (DxfVisualStyle.Class490) class492);
          class492.Write(-1, (object) this.bool_1);
          class492.Write(-1, (object) this.bool_2);
          class492.Write(-1, (object) this.bool_3);
          class492.Write(-1, (object) this.bool_4);
          class492.Write(-1, (object) this.bool_5);
          class492.Write(-1, (object) this.bool_6);
          class492.Write(-1, (object) this.bool_7);
          class492.Write(-1, (object) this.bool_8);
          class492.Write(-1, (object) this.bool_9);
          class492.Write(-1, (object) this.int_0);
          class492.Write(-1, (object) (180.0 / Math.PI * this.double_1));
          class492.Write(-1, (object) this.double_2);
          class492.Write(-1, (object) this.int_1);
          class492.Write(-1, (object) this.color_0);
          class492.Write(-1, (object) this.int_2);
          class492.Write(-1, (object) this.int_3);
          class492.Write(-1, (object) this.color_1);
          class492.Write(-1, (object) this.bool_10);
          class492.Write(-1, (object) this.int_4);
          class492.Write(-1, (object) this.int_5);
          class492.Write(-1, (object) this.int_6);
          class492.Write(-1, (object) this.bool_11);
          class492.Write(-1, (object) this.int_7);
          class492.Write(-1, (object) this.color_2);
          class492.Write(-1, (object) this.double_3);
          class492.Write(-1, (object) (int) this.edgeStyle_0.WiggleAmount);
          class492.Write(-1, (object) this.string_1);
          class492.Write(-1, (object) this.bool_12);
          class492.Write(-1, (object) this.double_4);
          class492.Write(-1, (object) this.double_5);
        }
        else
        {
          DxfVisualStyle.Class491 class491 = new DxfVisualStyle.Class491(this, w);
          this.faceStyle_0.Write(w, (DxfVisualStyle.Class490) class491);
          this.edgeStyle_0.Write(w, (DxfVisualStyle.Class490) class491);
          this.displayStyle_0.Write(w, (DxfVisualStyle.Class490) class491);
        }
      }
    }

    private object method_8(DxfVisualStyle.Enum14 prop)
    {
      switch (prop)
      {
        case DxfVisualStyle.Enum14.const_1:
          return (object) (int) this.faceStyle_0.LightingModel;
        case DxfVisualStyle.Enum14.const_2:
          return (object) (int) this.faceStyle_0.LightingQuality;
        case DxfVisualStyle.Enum14.const_3:
          return (object) (int) this.faceStyle_0.ColorMode;
        case DxfVisualStyle.Enum14.const_4:
          return (object) (int) this.faceStyle_0.FaceModifierFlags;
        case DxfVisualStyle.Enum14.const_5:
          return (object) this.faceStyle_0.OpacityLevel;
        case DxfVisualStyle.Enum14.const_6:
          return (object) this.faceStyle_0.SpecularLevel;
        case DxfVisualStyle.Enum14.const_8:
          return (object) (int) this.edgeStyle_0.EdgeModel;
        case DxfVisualStyle.Enum14.const_9:
          return (object) (int) this.edgeStyle_0.EdgeStyleFlags;
        case DxfVisualStyle.Enum14.const_10:
          return (object) this.edgeStyle_0.IntersectionColor;
        case DxfVisualStyle.Enum14.const_11:
          return (object) this.edgeStyle_0.ObscuredColor;
        case DxfVisualStyle.Enum14.const_12:
          return (object) (int) this.edgeStyle_0.ObscuredLineType;
        case DxfVisualStyle.Enum14.const_13:
          return (object) (int) this.edgeStyle_0.IntersectionLineType;
        case DxfVisualStyle.Enum14.const_14:
          return (object) (this.edgeStyle_0.CreaseAngle * (180.0 / Math.PI));
        case DxfVisualStyle.Enum14.const_15:
          return (object) (int) this.edgeStyle_0.EdgeModifierFlags;
        case DxfVisualStyle.Enum14.const_16:
          return (object) this.edgeStyle_0.EdgeColor;
        case DxfVisualStyle.Enum14.const_17:
          return (object) this.edgeStyle_0.OpacityLevel;
        case DxfVisualStyle.Enum14.const_18:
          return (object) this.edgeStyle_0.EdgeWidth;
        case DxfVisualStyle.Enum14.const_19:
          return (object) this.edgeStyle_0.OverhangAmount;
        case DxfVisualStyle.Enum14.const_20:
          return (object) (int) this.edgeStyle_0.JitterAmount;
        case DxfVisualStyle.Enum14.const_21:
          return (object) this.edgeStyle_0.SilhouetteColor;
        case DxfVisualStyle.Enum14.const_22:
          return (object) this.edgeStyle_0.SilhouetteWidth;
        case DxfVisualStyle.Enum14.const_23:
          return (object) this.edgeStyle_0.HaloGap;
        case DxfVisualStyle.Enum14.const_24:
          return (object) this.edgeStyle_0.IsolineCount;
        case DxfVisualStyle.Enum14.const_25:
          return (object) this.edgeStyle_0.EdgePrecisionHidden;
        case DxfVisualStyle.Enum14.const_26:
          return (object) this.displayStyle_0.DisplayFlags;
        case DxfVisualStyle.Enum14.const_27:
          return (object) this.displayStyle_0.Brightness;
        case DxfVisualStyle.Enum14.const_28:
          return (object) (int) this.displayStyle_0.ShadowType;
        case DxfVisualStyle.Enum14.const_29:
          return (object) this.bool_1;
        case DxfVisualStyle.Enum14.const_30:
          return (object) this.bool_2;
        case DxfVisualStyle.Enum14.const_31:
          return (object) this.bool_3;
        case DxfVisualStyle.Enum14.const_32:
          return (object) this.bool_4;
        case DxfVisualStyle.Enum14.const_33:
          return (object) this.bool_5;
        case DxfVisualStyle.Enum14.const_34:
          return (object) this.bool_6;
        case DxfVisualStyle.Enum14.const_35:
          return (object) this.bool_7;
        case DxfVisualStyle.Enum14.const_36:
          return (object) this.bool_8;
        case DxfVisualStyle.Enum14.const_37:
          return (object) this.bool_9;
        case DxfVisualStyle.Enum14.const_38:
          return (object) this.int_0;
        case DxfVisualStyle.Enum14.const_39:
          return (object) this.double_1;
        case DxfVisualStyle.Enum14.const_40:
          return (object) this.double_2;
        case DxfVisualStyle.Enum14.const_41:
          return (object) this.int_1;
        case DxfVisualStyle.Enum14.const_42:
          return (object) this.color_0;
        case DxfVisualStyle.Enum14.const_43:
          return (object) this.int_2;
        case DxfVisualStyle.Enum14.const_44:
          return (object) this.int_3;
        case DxfVisualStyle.Enum14.const_45:
          return (object) this.color_1;
        case DxfVisualStyle.Enum14.const_46:
          return (object) this.bool_10;
        case DxfVisualStyle.Enum14.const_47:
          return (object) this.int_4;
        case DxfVisualStyle.Enum14.const_48:
          return (object) this.int_5;
        case DxfVisualStyle.Enum14.const_49:
          return (object) this.int_6;
        case DxfVisualStyle.Enum14.const_50:
          return (object) this.bool_11;
        case DxfVisualStyle.Enum14.const_51:
          return (object) this.int_7;
        case DxfVisualStyle.Enum14.const_52:
          return (object) this.color_2;
        case DxfVisualStyle.Enum14.const_53:
          return (object) this.double_3;
        case DxfVisualStyle.Enum14.const_54:
          return (object) this.edgeStyle_0.WiggleAmount;
        case DxfVisualStyle.Enum14.const_55:
          return (object) this.string_1;
        case DxfVisualStyle.Enum14.const_56:
          return (object) this.bool_12;
        case DxfVisualStyle.Enum14.const_57:
          return (object) this.double_4;
        case DxfVisualStyle.Enum14.const_58:
          return (object) this.double_5;
        default:
          throw new ArgumentException("Unknown property " + (object) prop + ".");
      }
    }

    private void method_9(DxfVisualStyle.Enum14 prop, object value)
    {
      switch (prop)
      {
        case DxfVisualStyle.Enum14.const_1:
          this.faceStyle_0.LightingModel = (FaceLightingModel) Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_2:
          this.faceStyle_0.LightingQuality = (FaceLightingQuality) Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_3:
          this.faceStyle_0.ColorMode = (FaceColorMode) Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_4:
          this.faceStyle_0.FaceModifierFlags = (FaceModifierFlags) Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_5:
          this.faceStyle_0.OpacityLevel = (double) value;
          break;
        case DxfVisualStyle.Enum14.const_6:
          this.faceStyle_0.SpecularLevel = (double) value;
          break;
        case DxfVisualStyle.Enum14.const_7:
          this.faceStyle_0.MonoColor = (Color) value;
          break;
        case DxfVisualStyle.Enum14.const_8:
          this.edgeStyle_0.EdgeModel = (EdgeModel) Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_9:
          this.edgeStyle_0.EdgeStyleFlags = (EdgeStyleFlags) Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_10:
          this.edgeStyle_0.IntersectionColor = (Color) value;
          break;
        case DxfVisualStyle.Enum14.const_11:
          this.edgeStyle_0.ObscuredColor = (Color) value;
          break;
        case DxfVisualStyle.Enum14.const_12:
          this.edgeStyle_0.ObscuredLineType = (LineType) Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_13:
          this.edgeStyle_0.IntersectionLineType = (LineType) Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_14:
          this.edgeStyle_0.CreaseAngle = Math.PI / 180.0 * (double) value;
          break;
        case DxfVisualStyle.Enum14.const_15:
          this.edgeStyle_0.EdgeModifierFlags = (EdgeModifierFlags) Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_16:
          this.edgeStyle_0.EdgeColor = (Color) value;
          break;
        case DxfVisualStyle.Enum14.const_17:
          this.edgeStyle_0.OpacityLevel = (double) value;
          break;
        case DxfVisualStyle.Enum14.const_18:
          this.edgeStyle_0.EdgeWidth = (int) Convert.ToInt16(value);
          break;
        case DxfVisualStyle.Enum14.const_19:
          this.edgeStyle_0.OverhangAmount = (int) Convert.ToInt16(value);
          break;
        case DxfVisualStyle.Enum14.const_20:
          this.edgeStyle_0.JitterAmount = (JitterAmount) Convert.ToUInt16(value);
          break;
        case DxfVisualStyle.Enum14.const_21:
          this.edgeStyle_0.SilhouetteColor = (Color) value;
          break;
        case DxfVisualStyle.Enum14.const_22:
          this.edgeStyle_0.SilhouetteWidth = (int) Convert.ToInt16(value);
          break;
        case DxfVisualStyle.Enum14.const_23:
          this.edgeStyle_0.HaloGap = (int) Convert.ToInt16(value);
          break;
        case DxfVisualStyle.Enum14.const_24:
          this.edgeStyle_0.IsolineCount = (int) Convert.ToInt16(value);
          break;
        case DxfVisualStyle.Enum14.const_25:
          this.edgeStyle_0.EdgePrecisionHidden = (bool) value;
          break;
        case DxfVisualStyle.Enum14.const_26:
          this.displayStyle_0.DisplayFlags = (DisplayFlags) Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_27:
          this.displayStyle_0.Brightness = (double) value;
          break;
        case DxfVisualStyle.Enum14.const_28:
          this.displayStyle_0.ShadowType = (ShadowType) Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_29:
          this.bool_1 = (bool) value;
          break;
        case DxfVisualStyle.Enum14.const_30:
          this.bool_2 = (bool) value;
          break;
        case DxfVisualStyle.Enum14.const_31:
          this.bool_3 = (bool) value;
          break;
        case DxfVisualStyle.Enum14.const_32:
          this.bool_4 = (bool) value;
          break;
        case DxfVisualStyle.Enum14.const_33:
          this.bool_5 = (bool) value;
          break;
        case DxfVisualStyle.Enum14.const_34:
          this.bool_6 = (bool) value;
          break;
        case DxfVisualStyle.Enum14.const_35:
          this.bool_7 = (bool) value;
          break;
        case DxfVisualStyle.Enum14.const_36:
          this.bool_8 = (bool) value;
          break;
        case DxfVisualStyle.Enum14.const_37:
          this.bool_9 = (bool) value;
          break;
        case DxfVisualStyle.Enum14.const_38:
          this.int_0 = Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_39:
          this.double_1 = (double) value;
          break;
        case DxfVisualStyle.Enum14.const_40:
          this.double_2 = (double) value;
          break;
        case DxfVisualStyle.Enum14.const_41:
          this.int_1 = Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_42:
          this.color_0 = (Color) value;
          break;
        case DxfVisualStyle.Enum14.const_43:
          this.int_2 = Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_44:
          this.int_3 = Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_45:
          this.color_1 = (Color) value;
          break;
        case DxfVisualStyle.Enum14.const_46:
          this.bool_10 = (bool) value;
          break;
        case DxfVisualStyle.Enum14.const_47:
          this.int_4 = Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_48:
          this.int_5 = Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_49:
          this.int_6 = Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_50:
          this.bool_11 = (bool) value;
          break;
        case DxfVisualStyle.Enum14.const_51:
          this.int_7 = Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_52:
          this.color_2 = (Color) value;
          break;
        case DxfVisualStyle.Enum14.const_53:
          this.double_3 = (double) value;
          break;
        case DxfVisualStyle.Enum14.const_54:
          this.edgeStyle_0.WiggleAmount = (WiggleAmount) Convert.ToInt32(value);
          break;
        case DxfVisualStyle.Enum14.const_55:
          this.string_1 = (string) value;
          break;
        case DxfVisualStyle.Enum14.const_56:
          this.bool_12 = (bool) value;
          break;
        case DxfVisualStyle.Enum14.const_57:
          this.double_4 = (double) value;
          break;
        case DxfVisualStyle.Enum14.const_58:
          this.double_5 = (double) value;
          break;
        default:
          throw new ArgumentException("Unknown property " + (object) prop + ".");
      }
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      while (r.CurrentGroup.Code != 0)
      {
        if (r.CurrentGroup.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) r.CurrentGroup.Value)
        {
          case "AcDbVisualStyle":
            if (r.ModelBuilder.Version > DxfVersion.Dxf24)
            {
              this.method_15(r, objectBuilder);
              continue;
            }
            if (r.ModelBuilder.Version > DxfVersion.Dxf21)
            {
              this.method_13(r, objectBuilder);
              continue;
            }
            this.method_10(r, objectBuilder);
            continue;
          default:
            r.method_85();
            continue;
        }
      }
    }

    private void method_10(DxfReader r, Class259 objectBuilder)
    {
      r.method_91("AcDbVisualStyle");
      r.method_85();
      while (!r.method_92("AcDbVisualStyle"))
      {
        if (!this.method_12(r, objectBuilder))
          r.method_85();
      }
    }

    private bool method_11(DxfReader r, Class259 objectBuilder)
    {
      switch (r.CurrentGroup.Code)
      {
        case 40:
          this.faceStyle_0.OpacityLevel = (double) r.CurrentGroup.Value;
          break;
        case 41:
          this.faceStyle_0.SpecularLevel = (double) r.CurrentGroup.Value;
          break;
        case 42:
          this.edgeStyle_0.CreaseAngle = Math.PI / 180.0 * (double) r.CurrentGroup.Value;
          break;
        case 43:
          this.edgeStyle_0.OpacityLevel = (double) r.CurrentGroup.Value;
          break;
        case 44:
          this.displayStyle_0.Brightness = (double) r.CurrentGroup.Value;
          break;
        case 62:
          this.faceStyle_0.UnknownColor = Color.CreateFromColorIndex((short) r.CurrentGroup.Value);
          break;
        case 63:
          this.faceStyle_0.MonoColor = Color.CreateFromColorIndex((short) r.CurrentGroup.Value);
          break;
        case 64:
          this.edgeStyle_0.IntersectionColor = Color.CreateFromColorIndex((short) r.CurrentGroup.Value);
          break;
        case 65:
          this.edgeStyle_0.ObscuredColor = Color.CreateFromColorIndex((short) r.CurrentGroup.Value);
          break;
        case 66:
          this.edgeStyle_0.EdgeColor = Color.CreateFromColorIndex((short) r.CurrentGroup.Value);
          break;
        case 67:
          this.edgeStyle_0.SilhouetteColor = Color.CreateFromColorIndex((short) r.CurrentGroup.Value);
          break;
        case 71:
          this.faceStyle_0.LightingModel = (FaceLightingModel) r.CurrentGroup.Value;
          break;
        case 72:
          this.faceStyle_0.LightingQuality = (FaceLightingQuality) r.CurrentGroup.Value;
          break;
        case 73:
          this.faceStyle_0.ColorMode = (FaceColorMode) r.CurrentGroup.Value;
          break;
        case 74:
          this.edgeStyle_0.EdgeModel = (EdgeModel) (short) r.CurrentGroup.Value;
          break;
        case 75:
          this.edgeStyle_0.ObscuredLineType = (LineType) (short) r.CurrentGroup.Value;
          break;
        case 76:
          this.edgeStyle_0.EdgeWidth = (int) (short) r.CurrentGroup.Value;
          break;
        case 77:
          this.edgeStyle_0.OverhangAmount = (int) (short) r.CurrentGroup.Value;
          break;
        case 78:
          this.edgeStyle_0.JitterAmount = (JitterAmount) (short) r.CurrentGroup.Value;
          break;
        case 79:
          this.edgeStyle_0.SilhouetteWidth = (int) (short) r.CurrentGroup.Value;
          break;
        case 90:
          this.faceStyle_0.FaceModifierFlags = (FaceModifierFlags) (int) r.CurrentGroup.Value;
          break;
        case 91:
          this.edgeStyle_0.EdgeStyleFlags = (EdgeStyleFlags) r.CurrentGroup.Value;
          break;
        case 92:
          this.edgeStyle_0.EdgeModifierFlags = (EdgeModifierFlags) r.CurrentGroup.Value;
          break;
        case 93:
          this.displayStyle_0.DisplayFlags = (DisplayFlags) r.CurrentGroup.Value;
          break;
        case 170:
          this.edgeStyle_0.HaloGap = (int) (short) r.CurrentGroup.Value;
          break;
        case 171:
          this.edgeStyle_0.IsolineCount = (int) (short) r.CurrentGroup.Value;
          break;
        case 173:
          this.displayStyle_0.ShadowType = (ShadowType) r.CurrentGroup.Value;
          break;
        case 175:
          this.edgeStyle_0.IntersectionLineType = (LineType) (short) r.CurrentGroup.Value;
          break;
        case 290:
          this.edgeStyle_0.EdgePrecisionHidden = (bool) r.CurrentGroup.Value;
          break;
        case 420:
          this.faceStyle_0.UnknownColor = Color.CreateFromRgb((int) r.CurrentGroup.Value);
          break;
        case 421:
          this.faceStyle_0.MonoColor = Color.CreateFromRgb((int) r.CurrentGroup.Value);
          break;
        case 422:
          this.edgeStyle_0.IntersectionColor = Color.CreateFromRgb((int) r.CurrentGroup.Value);
          break;
        case 423:
          this.edgeStyle_0.ObscuredColor = Color.CreateFromRgb((int) r.CurrentGroup.Value);
          break;
        case 424:
          this.edgeStyle_0.EdgeColor = Color.CreateFromRgb((int) r.CurrentGroup.Value);
          break;
        case 425:
          this.edgeStyle_0.SilhouetteColor = Color.CreateFromRgb((int) r.CurrentGroup.Value);
          break;
        default:
          return this.method_6(r, objectBuilder);
      }
      r.method_85();
      return true;
    }

    private bool method_12(DxfReader r, Class259 objectBuilder)
    {
      if (r.CurrentGroup.Code != 174)
        return this.method_11(r, objectBuilder);
      this.edgeStyle_0.EdgeStyleApplication = (EdgeStyleApplication) (short) r.CurrentGroup.Value;
      r.method_85();
      return true;
    }

    private void method_13(DxfReader r, Class259 objectBuilder)
    {
      r.method_91("AcDbVisualStyle");
      r.method_85();
      int propertyIndex = 0;
      while (!r.method_92("AcDbVisualStyle"))
      {
        if (!this.method_14(r, objectBuilder, ref propertyIndex))
          r.method_85();
      }
    }

    private bool method_14(DxfReader r, Class259 objectBuilder, ref int propertyIndex)
    {
      if (r.CurrentGroup.Code != 176)
        return this.method_11(r, objectBuilder);
      this.operation_0[propertyIndex++] = (DxfVisualStyle.Operation) r.CurrentGroup.Value;
      r.method_85();
      return true;
    }

    private void method_15(DxfReader r, Class259 objectBuilder)
    {
      r.method_91("AcDbVisualStyle");
      r.method_85();
      int propertyIndex = 0;
      while (!r.method_92("AcDbVisualStyle"))
      {
        if (!this.method_16(r, objectBuilder, ref propertyIndex))
          r.method_85();
      }
    }

    private bool method_16(DxfReader r, Class259 objectBuilder, ref int propertyIndex)
    {
      switch (r.CurrentGroup.Code)
      {
        case 1:
        case 40:
        case 90:
        case 290:
          this.method_9((DxfVisualStyle.Enum14) propertyIndex, r.CurrentGroup.Value);
          break;
        case 62:
          this.method_9((DxfVisualStyle.Enum14) propertyIndex, (object) Color.CreateFromColorIndex((short) r.CurrentGroup.Value));
          break;
        case 176:
          this.operation_0[propertyIndex++] = (DxfVisualStyle.Operation) r.CurrentGroup.Value;
          break;
        case 420:
          this.method_9((DxfVisualStyle.Enum14) propertyIndex, (object) Color.CreateFromRgb((int) r.CurrentGroup.Value));
          break;
        default:
          return this.method_6(r, objectBuilder);
      }
      r.method_85();
      return true;
    }

    public class Names
    {
      public const string _2dWireframe = "2dWireframe";
      public const string Basic = "Basic";
      public const string Brighten = "Brighten";
      public const string ColorChange = "ColorChange";
      public const string Conceptual = "Conceptual";
      public const string Dim = "Dim";
      public const string EdgeColorOff = "EdgeColorOff";
      public const string Facepattern = "Facepattern";
      public const string Flat = "Flat";
      public const string FlatWithEdges = "FlatWithEdges";
      public const string Gouraud = "Gouraud";
      public const string GouraudWithEdges = "GouraudWithEdges";
      public const string Hidden = "Hidden";
      public const string JitterOff = "JitterOff";
      public const string Linepattern = "Linepattern";
      public const string OverhangOff = "OverhangOff";
      public const string Realistic = "Realistic";
      public const string Shaded = "Shaded";
      public const string ShadedWithEdges = "Shaded with edges";
      public const string ShadesOfGray = "Shades of Gray";
      public const string Sketchy = "Sketchy";
      public const string Thicken = "Thicken";
      public const string Wireframe = "Wireframe";
      public const string XRay = "X-Ray";
    }

    internal enum Enum14
    {
      const_0 = -1,
      const_1 = 0,
      const_2 = 1,
      const_3 = 2,
      const_4 = 3,
      const_5 = 4,
      const_6 = 5,
      const_7 = 6,
      const_8 = 7,
      const_9 = 8,
      const_10 = 9,
      const_11 = 10, // 0x0000000A
      const_12 = 11, // 0x0000000B
      const_13 = 12, // 0x0000000C
      const_14 = 13, // 0x0000000D
      const_15 = 14, // 0x0000000E
      const_16 = 15, // 0x0000000F
      const_17 = 16, // 0x00000010
      const_18 = 17, // 0x00000011
      const_19 = 18, // 0x00000012
      const_20 = 19, // 0x00000013
      const_21 = 20, // 0x00000014
      const_22 = 21, // 0x00000015
      const_23 = 22, // 0x00000016
      const_24 = 23, // 0x00000017
      const_25 = 24, // 0x00000018
      const_26 = 25, // 0x00000019
      const_27 = 26, // 0x0000001A
      const_28 = 27, // 0x0000001B
      const_29 = 28, // 0x0000001C
      const_30 = 29, // 0x0000001D
      const_31 = 30, // 0x0000001E
      const_32 = 31, // 0x0000001F
      const_33 = 32, // 0x00000020
      const_34 = 33, // 0x00000021
      const_35 = 34, // 0x00000022
      const_36 = 35, // 0x00000023
      const_37 = 36, // 0x00000024
      const_38 = 37, // 0x00000025
      const_39 = 38, // 0x00000026
      const_40 = 39, // 0x00000027
      const_41 = 40, // 0x00000028
      const_42 = 41, // 0x00000029
      const_43 = 42, // 0x0000002A
      const_44 = 43, // 0x0000002B
      const_45 = 44, // 0x0000002C
      const_46 = 45, // 0x0000002D
      const_47 = 46, // 0x0000002E
      const_48 = 47, // 0x0000002F
      const_49 = 48, // 0x00000030
      const_50 = 49, // 0x00000031
      const_51 = 50, // 0x00000032
      const_52 = 51, // 0x00000033
      const_53 = 52, // 0x00000034
      const_54 = 53, // 0x00000035
      const_55 = 54, // 0x00000036
      const_56 = 55, // 0x00000037
      const_57 = 56, // 0x00000038
      const_58 = 57, // 0x00000039
    }

    public enum Operation : short
    {
      InvalidOperation = -1,
      Inherit = 0,
      Set = 1,
      Disable = 2,
      Enable = 3,
    }

    internal class Class486
    {
      protected DxfVisualStyle dxfVisualStyle_0;
      protected Interface30 interface30_0;

      public Class486(DxfVisualStyle visualStyle, Interface30 r)
      {
        this.dxfVisualStyle_0 = visualStyle;
        this.interface30_0 = r;
      }

      public virtual bool vmethod_0()
      {
        bool flag = this.interface30_0.imethod_6();
        this.vmethod_6();
        return flag;
      }

      public virtual byte vmethod_1()
      {
        byte num = this.interface30_0.imethod_18();
        this.vmethod_6();
        return num;
      }

      public virtual short vmethod_2()
      {
        short num = this.interface30_0.imethod_14();
        this.vmethod_6();
        return num;
      }

      public virtual int vmethod_3()
      {
        int num = this.interface30_0.imethod_11();
        this.vmethod_6();
        return num;
      }

      public virtual double vmethod_4()
      {
        double num = this.interface30_0.imethod_8();
        this.vmethod_6();
        return num;
      }

      public virtual string ReadString()
      {
        string str = this.interface30_0.ReadString();
        this.vmethod_6();
        return str;
      }

      public virtual Color vmethod_5()
      {
        Color color = this.interface30_0.imethod_22();
        this.vmethod_6();
        return color;
      }

      protected virtual void vmethod_6()
      {
      }
    }

    internal class Class487 : DxfVisualStyle.Class486
    {
      private int int_0;

      public Class487(DxfVisualStyle visualStyle, Interface30 r)
        : base(visualStyle, r)
      {
      }

      public int Prop
      {
        get
        {
          return this.int_0;
        }
      }

      protected override void vmethod_6()
      {
        this.dxfVisualStyle_0.operation_0[this.int_0++] = (DxfVisualStyle.Operation) this.interface30_0.imethod_14();
      }
    }

    internal class Class488
    {
      protected DxfVisualStyle dxfVisualStyle_0;
      protected Interface29 interface29_0;

      public Class488(DxfVisualStyle visualStyle, Interface29 w)
      {
        this.dxfVisualStyle_0 = visualStyle;
        this.interface29_0 = w;
      }

      public virtual void vmethod_0(bool value)
      {
        this.interface29_0.imethod_14(value);
        this.vmethod_7();
      }

      public virtual void vmethod_1(byte value)
      {
        this.interface29_0.imethod_11(value);
        this.vmethod_7();
      }

      public virtual void vmethod_2(ushort value)
      {
        this.interface29_0.imethod_32((short) value);
        this.vmethod_7();
      }

      public virtual void vmethod_3(short value)
      {
        this.interface29_0.imethod_32(value);
        this.vmethod_7();
      }

      public virtual void vmethod_4(int value)
      {
        this.interface29_0.imethod_33(value);
        this.vmethod_7();
      }

      public virtual void vmethod_5(double value)
      {
        this.interface29_0.imethod_16(value);
        this.vmethod_7();
      }

      public virtual void WriteString(string value)
      {
        this.interface29_0.imethod_4(value);
        this.vmethod_7();
      }

      public virtual void vmethod_6(Color value)
      {
        this.interface29_0.imethod_6(value);
        this.vmethod_7();
      }

      protected virtual void vmethod_7()
      {
      }
    }

    internal class Class489 : DxfVisualStyle.Class488
    {
      private int int_0;

      public Class489(DxfVisualStyle visualStyle, Interface29 w)
        : base(visualStyle, w)
      {
      }

      public int Prop
      {
        get
        {
          return this.int_0;
        }
      }

      protected override void vmethod_7()
      {
        this.interface29_0.imethod_32((short) this.dxfVisualStyle_0.operation_0[this.int_0++]);
      }
    }

    internal class Class490
    {
      protected DxfVisualStyle dxfVisualStyle_0;
      protected DxfWriter dxfWriter_0;

      public Class490(DxfVisualStyle visualStyle, DxfWriter w)
      {
        this.dxfVisualStyle_0 = visualStyle;
        this.dxfWriter_0 = w;
      }

      public virtual void Write(int group, object value)
      {
        this.dxfWriter_0.Write(group, value);
        this.vmethod_1();
      }

      public virtual void vmethod_0(int group, Color value)
      {
        this.dxfWriter_0.method_231(group, value, true);
        this.vmethod_1();
      }

      protected virtual void vmethod_1()
      {
      }
    }

    internal class Class491 : DxfVisualStyle.Class490
    {
      private int int_0;

      public Class491(DxfVisualStyle visualStyle, DxfWriter w)
        : base(visualStyle, w)
      {
      }

      public int Prop
      {
        get
        {
          return this.int_0;
        }
      }

      protected override void vmethod_1()
      {
        this.dxfWriter_0.Write(176, (object) this.dxfVisualStyle_0.operation_0[this.int_0++]);
      }
    }

    internal class Class492 : DxfVisualStyle.Class491
    {
      public Class492(DxfVisualStyle visualStyle, DxfWriter w)
        : base(visualStyle, w)
      {
      }

      public override void Write(int group, object value)
      {
        if (value is bool)
          this.dxfWriter_0.Write(290, (object) (bool) value);
        else if (value is int)
          this.dxfWriter_0.Write(90, (object) (int) value);
        else if (value is uint)
          this.dxfWriter_0.Write(90, (object) (int) (uint) value);
        else if (value is short)
          this.dxfWriter_0.Write(90, (object) (int) (short) value);
        else if (value is ushort)
          this.dxfWriter_0.Write(90, (object) (int) (ushort) value);
        else if (value is double)
          this.dxfWriter_0.Write(40, (object) (double) value);
        else if (value is string)
          this.dxfWriter_0.Write(1, (object) (string) value);
        else if (value is Color)
        {
          this.dxfWriter_0.method_231(62, (Color) value, true);
        }
        else
        {
          if (value == null)
            throw new Exception("Value is null");
          throw new Exception("Unknown value type for value of type " + (object) value.GetType() + ".");
        }
        this.vmethod_1();
      }

      public override void vmethod_0(int group, Color value)
      {
        this.dxfWriter_0.method_231(62, value, true);
        this.vmethod_1();
      }
    }
  }
}
