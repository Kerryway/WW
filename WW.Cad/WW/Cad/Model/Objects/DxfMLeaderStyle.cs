// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfMLeaderStyle
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns28;
using ns3;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model.Tables;

namespace WW.Cad.Model.Objects
{
  public class DxfMLeaderStyle : DxfObject, INamedObject
  {
    private MLeader.ContentType contentType_0 = MLeader.ContentType.MText;
    private MLeader.DrawMLeaderOrder drawMLeaderOrder_0 = MLeader.DrawMLeaderOrder.DrawLeaderFirst;
    private int int_0 = 2;
    private MLeader.LeaderType leaderType_0 = MLeader.LeaderType.Straight;
    private Color color_0 = Color.ByBlock;
    private DxfObjectReference dxfObjectReference_3 = DxfObjectReference.Null;
    private int int_1 = -2;
    private bool bool_0 = true;
    private double double_2 = 0.09;
    private bool bool_1 = true;
    private double double_3 = 0.36;
    private string string_0 = string.Empty;
    private DxfObjectReference dxfObjectReference_4 = DxfObjectReference.Null;
    private double double_4 = 0.18;
    private string string_1 = string.Empty;
    private DxfObjectReference dxfObjectReference_5 = DxfObjectReference.Null;
    private MLeader.TextAttachment textAttachment_0 = MLeader.TextAttachment.MiddleOfTopTextLine;
    private MLeader.TextAttachment textAttachment_1 = MLeader.TextAttachment.MiddleOfTopTextLine;
    private MLeader.TextAngleType textAngleType_0 = MLeader.TextAngleType.Horizontal;
    private Color color_1 = Color.ByBlock;
    private double double_5 = 0.18;
    private DxfObjectReference dxfObjectReference_6 = DxfObjectReference.Null;
    private Color color_2 = Color.ByBlock;
    private WW.Math.Vector3D vector3D_0 = new WW.Math.Vector3D(1.0, 1.0, 1.0);
    private bool bool_4 = true;
    private bool bool_5 = true;
    private double double_8 = 1.0;
    private double double_9 = 0.125;
    private MLeader.TextAttachment textAttachment_2 = MLeader.TextAttachment.Center;
    private MLeader.TextAttachment textAttachment_3 = MLeader.TextAttachment.Center;
    private short short_0 = 2;
    private bool bool_8 = true;
    public const string DefaultName = "Standard";
    private MLeader.DrawLeaderOrder drawLeaderOrder_0;
    private double double_0;
    private double double_1;
    private MLeader.TextAlignment textAlignment_0;
    private bool bool_2;
    private bool bool_3;
    private double double_6;
    private double double_7;
    private MLeader.BlockConnectionType blockConnectionType_0;
    private bool bool_6;
    private bool bool_7;
    private MLeader.TextAttachmentDirection textAttachmentDirection_0;

    public DxfMLeaderStyle()
    {
    }

    public DxfMLeaderStyle(string name)
    {
      this.string_0 = name;
    }

    public MLeader.ContentType ContentType
    {
      get
      {
        return this.contentType_0;
      }
      set
      {
        this.contentType_0 = value;
      }
    }

    public MLeader.DrawMLeaderOrder DrawMLeaderOrder
    {
      get
      {
        return this.drawMLeaderOrder_0;
      }
      set
      {
        this.drawMLeaderOrder_0 = value;
      }
    }

    public MLeader.DrawLeaderOrder DrawLeaderOrder
    {
      get
      {
        return this.drawLeaderOrder_0;
      }
      set
      {
        this.drawLeaderOrder_0 = value;
      }
    }

    public int MaxLeaderSegmentPointCount
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

    public double FirstSegmentAngle
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

    public double SecondSegmentAngle
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

    public MLeader.LeaderType LeaderType
    {
      get
      {
        return this.leaderType_0;
      }
      set
      {
        this.leaderType_0 = value;
      }
    }

    public Color LeaderLineColor
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

    public DxfLineType LineType
    {
      get
      {
        return (DxfLineType) this.dxfObjectReference_3.Value;
      }
      set
      {
        this.dxfObjectReference_3 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public int LeaderLineWeight
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

    public bool LandingEnabled
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

    public double LandingGap
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

    public bool DogLegEnabled
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

    public double LandingDistance
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

    public DxfBlock ArrowHeadBlock
    {
      get
      {
        return (DxfBlock) this.dxfObjectReference_4.Value;
      }
      set
      {
        this.dxfObjectReference_4 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public double ArrowHeadSize
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

    public string DefaultText
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
      }
    }

    public DxfTextStyle TextStyle
    {
      get
      {
        return (DxfTextStyle) this.dxfObjectReference_5.Value;
      }
      set
      {
        this.dxfObjectReference_5 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public MLeader.TextAttachment TextLeftAttachment
    {
      get
      {
        return this.textAttachment_0;
      }
      set
      {
        this.textAttachment_0 = value;
      }
    }

    public MLeader.TextAttachment TextRightAttachment
    {
      get
      {
        return this.textAttachment_1;
      }
      set
      {
        this.textAttachment_1 = value;
      }
    }

    public MLeader.TextAngleType TextAngleType
    {
      get
      {
        return this.textAngleType_0;
      }
      set
      {
        this.textAngleType_0 = value;
      }
    }

    public MLeader.TextAlignment TextAlignment
    {
      get
      {
        return this.textAlignment_0;
      }
      set
      {
        this.textAlignment_0 = value;
      }
    }

    public Color TextColor
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

    public double TextHeight
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

    public bool TextFrameEnabled
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

    public bool TextAlignAlwaysLeft
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

    public double AlignSpace
    {
      get
      {
        return this.double_6;
      }
      set
      {
        this.double_6 = value;
      }
    }

    public DxfBlock Block
    {
      get
      {
        return (DxfBlock) this.dxfObjectReference_6.Value;
      }
      set
      {
        this.dxfObjectReference_6 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public Color BlockColor
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

    public WW.Math.Vector3D BlockScale
    {
      get
      {
        return this.vector3D_0;
      }
      set
      {
        this.vector3D_0 = value;
      }
    }

    public bool BlockScaleEnabled
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

    public double BlockRotation
    {
      get
      {
        return this.double_7;
      }
      set
      {
        this.double_7 = value;
      }
    }

    public bool BlockRotationEnabled
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

    public MLeader.BlockConnectionType BlockConnectionType
    {
      get
      {
        return this.blockConnectionType_0;
      }
      set
      {
        this.blockConnectionType_0 = value;
      }
    }

    public double Scale
    {
      get
      {
        return this.double_8;
      }
      set
      {
        this.double_8 = value;
      }
    }

    public bool OverwritePropertyValue
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

    public bool IsAnnotative
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

    public double BreakGapSize
    {
      get
      {
        return this.double_9;
      }
      set
      {
        this.double_9 = value;
      }
    }

    public MLeader.TextAttachmentDirection TextAttachmentDirection
    {
      get
      {
        return this.textAttachmentDirection_0;
      }
      set
      {
        this.textAttachmentDirection_0 = value;
      }
    }

    public MLeader.TextAttachment TextBottomAttachment
    {
      get
      {
        return this.textAttachment_2;
      }
      set
      {
        this.textAttachment_2 = value;
      }
    }

    public MLeader.TextAttachment TextTopAttachment
    {
      get
      {
        return this.textAttachment_3;
      }
      set
      {
        this.textAttachment_3 = value;
      }
    }

    public bool ExtendLeaderToText
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

    public override string ObjectType
    {
      get
      {
        return "MLEADERSTYLE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbMLeaderStyle";
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfMLeaderStyle dxfMleaderStyle = (DxfMLeaderStyle) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfMleaderStyle == null)
      {
        dxfMleaderStyle = new DxfMLeaderStyle();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfMleaderStyle);
        dxfMleaderStyle.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfMleaderStyle;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      this.method_8(cloneContext, (DxfMLeaderStyle) from);
    }

    private void method_8(CloneContext context, DxfMLeaderStyle from)
    {
      this.contentType_0 = from.contentType_0;
      this.drawMLeaderOrder_0 = from.drawMLeaderOrder_0;
      this.drawLeaderOrder_0 = from.drawLeaderOrder_0;
      this.int_0 = from.int_0;
      this.double_0 = from.double_0;
      this.double_1 = from.double_1;
      this.leaderType_0 = from.leaderType_0;
      this.color_0 = from.color_0;
      this.LineType = Class906.GetLineType(context, from.LineType);
      this.int_1 = from.int_1;
      this.bool_0 = from.bool_0;
      this.double_2 = from.double_2;
      this.bool_1 = from.bool_1;
      this.double_3 = from.double_3;
      this.string_0 = from.string_0;
      this.ArrowHeadBlock = Class906.smethod_0(context, from.ArrowHeadBlock, false);
      this.double_4 = from.double_4;
      this.string_1 = from.string_1;
      this.TextStyle = Class906.GetTextStyle(context, from.TextStyle);
      this.textAttachment_0 = from.textAttachment_0;
      this.textAngleType_0 = from.textAngleType_0;
      this.textAlignment_0 = from.textAlignment_0;
      this.textAttachment_1 = from.textAttachment_1;
      this.color_1 = from.color_1;
      this.double_5 = from.double_5;
      this.bool_2 = from.bool_2;
      this.bool_3 = from.bool_3;
      this.double_6 = from.double_6;
      this.Block = Class906.smethod_0(context, from.Block, false);
      this.color_2 = from.color_2;
      this.vector3D_0 = from.vector3D_0;
      this.bool_4 = from.bool_4;
      this.double_7 = from.double_7;
      this.bool_5 = from.bool_5;
      this.blockConnectionType_0 = from.blockConnectionType_0;
      this.double_8 = from.double_8;
      this.bool_6 = from.bool_6;
      this.bool_7 = from.bool_7;
      this.double_9 = from.double_9;
      this.textAttachmentDirection_0 = from.textAttachmentDirection_0;
      this.textAttachment_2 = from.textAttachment_2;
      this.textAttachment_3 = from.textAttachment_3;
      this.bool_8 = from.bool_8;
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal static DxfMLeaderStyle smethod_2(DxfModel model, bool useFixedHandles)
    {
      return new DxfMLeaderStyle() { Name = "Standard" };
    }

    internal static DxfClass smethod_3(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "MLEADERSTYLE");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ACDB_MLEADERSTYLE_CLASS";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1021;
        dxfClass.MaintenanceVersion = (short) 25;
        dxfClass.ProxyFlags = (ProxyFlags) 4095;
        dxfClass.CPlusPlusClassName = "AcDbMLeaderStyle";
        dxfClass.DxfName = "MLEADERSTYLE";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_8.ClassNumber;
    }

    internal override void Read(Class434 or, Class259 objectBuilder)
    {
      base.Read(or, objectBuilder);
      Interface30 objectBitStream = or.ObjectBitStream;
      if (or.Builder.Version > DxfVersion.Dxf21)
        this.short_0 = objectBitStream.imethod_14();
      this.contentType_0 = (MLeader.ContentType) objectBitStream.imethod_14();
      this.drawMLeaderOrder_0 = (MLeader.DrawMLeaderOrder) objectBitStream.imethod_14();
      this.drawLeaderOrder_0 = (MLeader.DrawLeaderOrder) objectBitStream.imethod_14();
      this.int_0 = objectBitStream.imethod_11();
      this.double_0 = objectBitStream.imethod_8();
      this.double_1 = objectBitStream.imethod_8();
      this.leaderType_0 = (MLeader.LeaderType) objectBitStream.imethod_14();
      this.color_0 = objectBitStream.imethod_22();
      or.method_78((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_3 = o));
      this.int_1 = objectBitStream.imethod_11();
      this.bool_0 = objectBitStream.imethod_6();
      this.double_2 = objectBitStream.imethod_8();
      this.bool_1 = objectBitStream.imethod_6();
      this.double_3 = objectBitStream.imethod_8();
      this.string_0 = objectBitStream.ReadString();
      or.method_78((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_4 = o));
      this.double_4 = objectBitStream.imethod_8();
      this.string_1 = objectBitStream.ReadString();
      or.method_78((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_5 = o));
      this.textAttachment_0 = (MLeader.TextAttachment) objectBitStream.imethod_14();
      this.textAttachment_1 = (MLeader.TextAttachment) objectBitStream.imethod_14();
      this.textAngleType_0 = (MLeader.TextAngleType) objectBitStream.imethod_14();
      this.textAlignment_0 = (MLeader.TextAlignment) objectBitStream.imethod_14();
      this.color_1 = objectBitStream.imethod_22();
      this.double_5 = objectBitStream.imethod_8();
      this.bool_2 = objectBitStream.imethod_6();
      this.bool_3 = objectBitStream.imethod_6();
      this.double_6 = objectBitStream.imethod_8();
      or.method_78((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_6 = o));
      this.color_2 = objectBitStream.imethod_22();
      this.vector3D_0 = objectBitStream.imethod_51();
      this.bool_4 = objectBitStream.imethod_6();
      this.double_7 = objectBitStream.imethod_8();
      this.bool_5 = objectBitStream.imethod_6();
      this.blockConnectionType_0 = (MLeader.BlockConnectionType) objectBitStream.imethod_14();
      this.double_8 = objectBitStream.imethod_8();
      this.bool_7 = objectBitStream.imethod_6();
      this.bool_6 = objectBitStream.imethod_6();
      this.double_9 = objectBitStream.imethod_8();
      if (or.Builder.Version > DxfVersion.Dxf21)
      {
        this.textAttachmentDirection_0 = (MLeader.TextAttachmentDirection) objectBitStream.imethod_14();
        this.textAttachment_3 = (MLeader.TextAttachment) objectBitStream.imethod_14();
        this.textAttachment_2 = (MLeader.TextAttachment) objectBitStream.imethod_14();
      }
      if (or.Builder.Version <= DxfVersion.Dxf24)
        return;
      this.bool_8 = objectBitStream.imethod_6();
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      Interface29 objectWriter = ow.ObjectWriter;
      if (ow.Version > DxfVersion.Dxf21)
        objectWriter.imethod_32(this.short_0);
      objectWriter.imethod_32((short) this.contentType_0);
      objectWriter.imethod_32((short) this.drawMLeaderOrder_0);
      objectWriter.imethod_32((short) this.drawLeaderOrder_0);
      objectWriter.imethod_33(this.int_0);
      objectWriter.imethod_16(this.double_0 * (180.0 / System.Math.PI));
      objectWriter.imethod_16(this.double_1 * (180.0 / System.Math.PI));
      objectWriter.imethod_32((short) this.leaderType_0);
      objectWriter.imethod_6(this.color_0);
      objectWriter.imethod_41((DxfHandledObject) (this.LineType ?? ow.Model.ContinuousLineType));
      objectWriter.imethod_33(this.int_1);
      objectWriter.imethod_14(this.bool_0);
      objectWriter.imethod_16(this.double_2);
      objectWriter.imethod_14(this.bool_1);
      objectWriter.imethod_16(this.double_3);
      objectWriter.imethod_4(this.string_0);
      objectWriter.imethod_41((DxfHandledObject) this.ArrowHeadBlock);
      objectWriter.imethod_16(this.double_4);
      objectWriter.imethod_4(this.string_1);
      objectWriter.imethod_41((DxfHandledObject) (this.TextStyle ?? ow.Model.DefaultTextStyle));
      objectWriter.imethod_32((short) this.textAttachment_0);
      objectWriter.imethod_32((short) this.textAttachment_1);
      objectWriter.imethod_32((short) this.textAngleType_0);
      objectWriter.imethod_32((short) this.textAlignment_0);
      objectWriter.imethod_6(this.color_1);
      objectWriter.imethod_16(this.double_5);
      objectWriter.imethod_14(this.bool_2);
      objectWriter.imethod_14(this.bool_3);
      objectWriter.imethod_16(this.double_6);
      objectWriter.imethod_41((DxfHandledObject) this.Block);
      objectWriter.imethod_6(this.color_2);
      objectWriter.imethod_29(this.vector3D_0);
      objectWriter.imethod_14(this.bool_4);
      objectWriter.imethod_16(this.double_7 * (180.0 / System.Math.PI));
      objectWriter.imethod_14(this.bool_5);
      objectWriter.imethod_32((short) this.blockConnectionType_0);
      objectWriter.imethod_16(this.double_8);
      objectWriter.imethod_14(this.bool_7);
      objectWriter.imethod_14(this.bool_6);
      objectWriter.imethod_16(this.double_9);
      if (ow.Version > DxfVersion.Dxf21)
      {
        objectWriter.imethod_32((short) this.textAttachmentDirection_0);
        objectWriter.imethod_32((short) this.textAttachment_3);
        objectWriter.imethod_32((short) this.textAttachment_2);
      }
      if (ow.Version <= DxfVersion.Dxf24)
        return;
      objectWriter.imethod_14(this.bool_8);
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      while (r.CurrentGroup.Code != 0)
      {
        if (r.CurrentGroup.Code != 100)
          throw new DxfException("Expected subclass marker.");
        string str = (string) r.CurrentGroup.Value;
        if ((string) r.CurrentGroup.Value == this.AcClass)
          this.method_9(r, objectBuilder);
        else
          r.method_85();
      }
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
        case 3:
          this.string_0 = (string) r.CurrentGroup.Value;
          break;
        case 40:
          this.double_0 = (double) r.CurrentGroup.Value * (System.Math.PI / 180.0);
          break;
        case 41:
          this.double_1 = (double) r.CurrentGroup.Value * (System.Math.PI / 180.0);
          break;
        case 42:
          this.double_2 = (double) r.CurrentGroup.Value;
          break;
        case 43:
          this.double_3 = (double) r.CurrentGroup.Value;
          break;
        case 44:
          this.double_4 = (double) r.CurrentGroup.Value;
          break;
        case 45:
          this.double_5 = (double) r.CurrentGroup.Value;
          break;
        case 46:
          this.double_6 = (double) r.CurrentGroup.Value;
          break;
        case 47:
          this.vector3D_0.X = (double) r.CurrentGroup.Value;
          break;
        case 49:
          this.vector3D_0.Y = (double) r.CurrentGroup.Value;
          break;
        case 90:
          this.int_0 = (int) r.CurrentGroup.Value;
          break;
        case 91:
          this.color_0 = MLeader.smethod_0((int) r.CurrentGroup.Value);
          break;
        case 92:
          this.int_1 = (int) r.CurrentGroup.Value;
          break;
        case 93:
          this.color_1 = MLeader.smethod_0((int) r.CurrentGroup.Value);
          break;
        case 94:
          this.color_2 = MLeader.smethod_0((int) r.CurrentGroup.Value);
          break;
        case 140:
          this.vector3D_0.Z = (double) r.CurrentGroup.Value;
          break;
        case 141:
          this.double_7 = (double) r.CurrentGroup.Value * (System.Math.PI / 180.0);
          break;
        case 142:
          this.double_8 = (double) r.CurrentGroup.Value;
          break;
        case 143:
          this.double_9 = (double) r.CurrentGroup.Value;
          break;
        case 170:
          this.contentType_0 = (MLeader.ContentType) r.CurrentGroup.Value;
          break;
        case 171:
          this.drawMLeaderOrder_0 = (MLeader.DrawMLeaderOrder) r.CurrentGroup.Value;
          break;
        case 172:
          this.drawLeaderOrder_0 = (MLeader.DrawLeaderOrder) r.CurrentGroup.Value;
          break;
        case 173:
          this.leaderType_0 = (MLeader.LeaderType) r.CurrentGroup.Value;
          break;
        case 174:
          this.textAttachment_0 = (MLeader.TextAttachment) (short) r.CurrentGroup.Value;
          break;
        case 175:
          this.textAngleType_0 = (MLeader.TextAngleType) r.CurrentGroup.Value;
          break;
        case 176:
          this.textAlignment_0 = (MLeader.TextAlignment) r.CurrentGroup.Value;
          break;
        case 177:
          this.blockConnectionType_0 = (MLeader.BlockConnectionType) r.CurrentGroup.Value;
          break;
        case 178:
          this.textAttachment_1 = (MLeader.TextAttachment) (short) r.CurrentGroup.Value;
          break;
        case 179:
          this.short_0 = (short) r.CurrentGroup.Value;
          break;
        case 271:
          this.textAttachmentDirection_0 = (MLeader.TextAttachmentDirection) r.CurrentGroup.Value;
          break;
        case 272:
          this.textAttachment_2 = (MLeader.TextAttachment) (short) r.CurrentGroup.Value;
          break;
        case 273:
          this.textAttachment_3 = (MLeader.TextAttachment) (short) r.CurrentGroup.Value;
          break;
        case 290:
          this.bool_0 = (bool) r.CurrentGroup.Value;
          break;
        case 291:
          this.bool_1 = (bool) r.CurrentGroup.Value;
          break;
        case 292:
          this.bool_2 = (bool) r.CurrentGroup.Value;
          break;
        case 293:
          this.bool_4 = (bool) r.CurrentGroup.Value;
          break;
        case 294:
          this.bool_5 = (bool) r.CurrentGroup.Value;
          break;
        case 295:
          this.bool_6 = (bool) r.CurrentGroup.Value;
          break;
        case 296:
          this.bool_7 = (bool) r.CurrentGroup.Value;
          break;
        case 297:
          this.bool_3 = (bool) r.CurrentGroup.Value;
          break;
        case 298:
          this.bool_8 = (bool) r.CurrentGroup.Value;
          break;
        case 300:
          this.string_1 = (string) r.CurrentGroup.Value;
          break;
        case 340:
          r.method_90((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_3 = o));
          break;
        case 341:
          r.method_90((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_4 = o));
          break;
        case 342:
          r.method_90((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_5 = o));
          break;
        case 343:
          r.method_90((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_6 = o));
          break;
        default:
          return this.method_6(r, objectBuilder);
      }
      r.method_85();
      return true;
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.method_234("AcDbMLeaderStyle");
      if (w.Version > DxfVersion.Dxf21)
        w.Write(179, (object) this.short_0);
      w.method_219(170, (short) this.contentType_0);
      w.method_219(171, (short) this.drawMLeaderOrder_0);
      w.method_219(172, (short) this.drawLeaderOrder_0);
      w.Write(90, (object) this.int_0);
      w.Write(40, (object) this.double_0);
      w.Write(41, (object) this.double_1);
      w.method_219(173, (short) this.leaderType_0);
      w.method_230(91, this.color_0);
      w.method_218(340, (DxfHandledObject) this.LineType);
      w.Write(92, (object) this.int_1);
      w.Write(290, (object) this.bool_0);
      w.Write(42, (object) this.double_2);
      w.Write(292, (object) this.bool_1);
      w.Write(43, (object) this.double_3);
      w.Write(3, (object) this.string_0);
      w.method_218(341, (DxfHandledObject) this.ArrowHeadBlock);
      w.Write(44, (object) this.double_4);
      w.Write(300, (object) this.string_1);
      w.method_218(342, (DxfHandledObject) this.TextStyle);
      w.Write(174, (object) (short) this.textAttachment_0);
      w.Write(178, (object) (short) this.textAttachment_1);
      w.Write(175, (object) (short) this.textAngleType_0);
      w.Write(176, (object) (short) this.textAlignment_0);
      w.method_230(93, this.color_1);
      w.Write(45, (object) this.double_5);
      w.Write(292, (object) this.bool_2);
      w.Write(297, (object) this.bool_3);
      w.Write(46, (object) this.double_6);
      w.method_218(343, (DxfHandledObject) this.Block);
      w.method_230(94, this.color_2);
      w.Write(47, (object) this.vector3D_0.X);
      w.Write(49, (object) this.vector3D_0.Y);
      w.Write(140, (object) this.vector3D_0.Z);
      w.Write(293, (object) this.bool_4);
      w.Write(141, (object) (this.double_7 * (180.0 / System.Math.PI)));
      w.Write(294, (object) this.bool_5);
      w.Write(177, (object) (short) this.blockConnectionType_0);
      w.Write(142, (object) this.double_8);
      w.Write(295, (object) this.bool_6);
      w.Write(296, (object) this.bool_7);
      w.Write(143, (object) this.double_9);
      if (w.Version > DxfVersion.Dxf21)
      {
        w.Write(271, (object) (short) this.textAttachmentDirection_0);
        w.Write(272, (object) (short) this.textAttachment_2);
        w.Write(273, (object) (short) this.textAttachment_3);
      }
      if (w.Version <= DxfVersion.Dxf24)
        return;
      w.Write(298, (object) this.bool_8);
    }
  }
}
