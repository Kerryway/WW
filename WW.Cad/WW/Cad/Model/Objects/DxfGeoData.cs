// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfGeoData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns2;
using ns28;
using ns3;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model.Tables;
using WW.Math;

namespace WW.Cad.Model.Objects
{
  public class DxfGeoData : DxfObject
  {
    private int int_0 = 1;
    private DesignCoordinatesType designCoordinatesType_0 = DesignCoordinatesType.LocalGrid;
    private DxfObjectReference dxfObjectReference_3 = DxfObjectReference.Null;
    private Vector2D vector2D_0 = Vector2D.YAxis;
    private Vector2D vector2D_1 = new Vector2D(1.0, 1.0);
    private UnitsValue unitsValue_0 = UnitsValue.Inches;
    private UnitsValue unitsValue_1 = UnitsValue.Inches;
    private WW.Math.Vector3D vector3D_0 = WW.Math.Vector3D.ZAxis;
    private ScaleEstimationMethod scaleEstimationMethod_0 = ScaleEstimationMethod.None;
    private double double_0 = 1.0;
    private string string_0 = string.Empty;
    private string string_1 = string.Empty;
    private string string_2 = string.Empty;
    private string string_3 = string.Empty;
    private string string_4 = string.Empty;
    private List<GeoMeshPoint> list_0 = new List<GeoMeshPoint>();
    private List<GeoMeshFace> list_1 = new List<GeoMeshFace>();
    private WW.Math.Point3D point3D_0;
    private WW.Math.Point3D point3D_1;
    private bool bool_0;
    private double double_1;
    private double double_2;

    public int ObjectVersion
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

    public DesignCoordinatesType DesignCoordinatesType
    {
      get
      {
        return this.designCoordinatesType_0;
      }
      set
      {
        this.designCoordinatesType_0 = value;
      }
    }

    public DxfBlock HostBlock
    {
      get
      {
        return (DxfBlock) this.dxfObjectReference_3.Value;
      }
      set
      {
        this.dxfObjectReference_3 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public WW.Math.Point3D DesignPoint
    {
      get
      {
        return this.point3D_0;
      }
      set
      {
        this.point3D_0 = value;
      }
    }

    public WW.Math.Point3D ReferencePoint
    {
      get
      {
        return this.point3D_1;
      }
      set
      {
        this.point3D_1 = value;
      }
    }

    public Vector2D NorthDirection
    {
      get
      {
        return this.vector2D_0;
      }
      set
      {
        this.vector2D_0 = value;
      }
    }

    public Vector2D UnitsScaleFactor
    {
      get
      {
        return this.vector2D_1;
      }
      set
      {
        this.vector2D_1 = value;
      }
    }

    public UnitsValue UnitsValueHorizontal
    {
      get
      {
        return this.unitsValue_0;
      }
      set
      {
        this.unitsValue_0 = value;
      }
    }

    public UnitsValue UnitsValueVertical
    {
      get
      {
        return this.unitsValue_1;
      }
      set
      {
        this.unitsValue_1 = value;
      }
    }

    public WW.Math.Vector3D UpDirection
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

    public ScaleEstimationMethod ScaleEstimationMethod
    {
      get
      {
        return this.scaleEstimationMethod_0;
      }
      set
      {
        this.scaleEstimationMethod_0 = value;
      }
    }

    public bool SeaLevelCorrectionEnabled
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

    public double UserSpecifiedScaleFactor
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

    public double SeaLevelElevation
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

    public double CoordinateProjectionRadius
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

    public string CoordinateSystemDefinition
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

    public string GeoRssTag
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

    public string ObservationFromTag
    {
      get
      {
        return this.string_2;
      }
      set
      {
        this.string_2 = value ?? string.Empty;
      }
    }

    public string ObservationToTag
    {
      get
      {
        return this.string_3;
      }
      set
      {
        this.string_3 = value ?? string.Empty;
      }
    }

    public string ObservationCoverageTag
    {
      get
      {
        return this.string_4;
      }
      set
      {
        this.string_4 = value ?? string.Empty;
      }
    }

    public List<GeoMeshPoint> GeoMeshPoints
    {
      get
      {
        return this.list_0;
      }
    }

    public List<GeoMeshFace> GeoMeshFaces
    {
      get
      {
        return this.list_1;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "GEODATA";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbGeoData";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfGeoData dxfGeoData = (DxfGeoData) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfGeoData == null)
      {
        dxfGeoData = new DxfGeoData();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfGeoData);
        dxfGeoData.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfGeoData;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfGeoData dxfGeoData = (DxfGeoData) from;
      this.int_0 = dxfGeoData.int_0;
      this.designCoordinatesType_0 = dxfGeoData.designCoordinatesType_0;
      this.HostBlock = Class906.smethod_0(cloneContext, dxfGeoData.HostBlock, false);
      this.point3D_0 = dxfGeoData.point3D_0;
      this.point3D_1 = dxfGeoData.point3D_1;
      this.vector2D_0 = dxfGeoData.vector2D_0;
      this.vector2D_1 = dxfGeoData.vector2D_1;
      this.unitsValue_0 = dxfGeoData.unitsValue_0;
      this.unitsValue_1 = dxfGeoData.unitsValue_1;
      this.vector3D_0 = dxfGeoData.vector3D_0;
      this.scaleEstimationMethod_0 = dxfGeoData.scaleEstimationMethod_0;
      this.bool_0 = dxfGeoData.bool_0;
      this.double_0 = dxfGeoData.double_0;
      this.double_1 = dxfGeoData.double_1;
      this.double_2 = dxfGeoData.double_2;
      this.string_0 = dxfGeoData.string_0;
      this.string_1 = dxfGeoData.string_1;
      this.string_2 = dxfGeoData.string_2;
      this.string_3 = dxfGeoData.string_3;
      this.string_4 = dxfGeoData.string_4;
      this.list_0.Clear();
      foreach (GeoMeshPoint geoMeshPoint in dxfGeoData.list_0)
        this.list_0.Add(new GeoMeshPoint(geoMeshPoint.Source, geoMeshPoint.Destination));
      this.list_1.Clear();
      foreach (GeoMeshFace geoMeshFace in dxfGeoData.list_1)
        this.list_1.Add(new GeoMeshFace(geoMeshFace.FaceIndex1, geoMeshFace.FaceIndex2, geoMeshFace.FaceIndex3));
    }

    internal override bool vmethod_5(DxfModel model)
    {
      if (model.Header.AcadVersion == DxfVersion.Dxf21 && model.Header.AcadMaintenanceVersion >= 45)
        return true;
      return model.Header.Dxf24OrHigher;
    }

    internal static DxfClass smethod_2(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "PLOTSETTINGS");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1021;
        dxfClass.MaintenanceVersion = (short) 45;
        dxfClass.ProxyFlags = (ProxyFlags) 4095;
        dxfClass.CPlusPlusClassName = "AcDbGeoData";
        dxfClass.DxfName = "GEODATA";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_4.ClassNumber;
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      if (this.HostBlock != null)
        return;
      this.HostBlock = this.Model.ModelLayout.OwnerBlock;
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      Interface29 objectWriter = ow.ObjectWriter;
      if (ow.Version > DxfVersion.Dxf21)
      {
        objectWriter.imethod_33(ow.Version > DxfVersion.Dxf24 ? 3 : 2);
        objectWriter.imethod_40((DxfHandledObject) this.HostBlock);
        objectWriter.imethod_32((short) this.designCoordinatesType_0);
        objectWriter.imethod_24(this.point3D_0);
        objectWriter.imethod_24(this.point3D_1);
        objectWriter.imethod_16(this.vector2D_1.X);
        objectWriter.imethod_33((int) this.unitsValue_0);
        objectWriter.imethod_16(this.vector2D_1.Y);
        objectWriter.imethod_33((int) this.unitsValue_1);
        objectWriter.imethod_29(this.vector3D_0);
        objectWriter.imethod_28(this.vector2D_0);
        objectWriter.imethod_33((int) this.scaleEstimationMethod_0);
        objectWriter.imethod_16(this.double_0);
        objectWriter.imethod_14(this.bool_0);
        objectWriter.imethod_16(this.double_1);
        objectWriter.imethod_16(this.double_2);
        objectWriter.imethod_4(this.string_0);
        objectWriter.imethod_4(this.string_1);
      }
      else
      {
        objectWriter.imethod_33(1);
        objectWriter.imethod_40((DxfHandledObject) this.HostBlock);
        objectWriter.imethod_32((short) this.designCoordinatesType_0);
        objectWriter.imethod_24(this.point3D_1);
        objectWriter.imethod_33((int) this.unitsValue_0);
        objectWriter.imethod_24(this.point3D_0);
        objectWriter.imethod_24(WW.Math.Point3D.Zero);
        objectWriter.imethod_29(this.vector3D_0);
        objectWriter.imethod_16(System.Math.PI / 2.0 - this.vector2D_0.GetAngle());
        objectWriter.imethod_24(new WW.Math.Point3D(1.0, 1.0, 1.0));
        objectWriter.imethod_4(this.string_0);
        objectWriter.imethod_4(this.string_1);
        objectWriter.imethod_16(this.vector2D_1.X);
        objectWriter.imethod_4(string.Empty);
        objectWriter.imethod_4(string.Empty);
      }
      objectWriter.imethod_4(this.string_2);
      objectWriter.imethod_4(this.string_3);
      objectWriter.imethod_4(this.string_4);
      objectWriter.imethod_33(this.list_0.Count);
      foreach (GeoMeshPoint geoMeshPoint in this.list_0)
      {
        objectWriter.imethod_25(geoMeshPoint.Source);
        objectWriter.imethod_25(geoMeshPoint.Destination);
      }
      objectWriter.imethod_33(this.list_1.Count);
      foreach (GeoMeshFace geoMeshFace in this.list_1)
      {
        objectWriter.imethod_33(geoMeshFace.FaceIndex1);
        objectWriter.imethod_33(geoMeshFace.FaceIndex2);
        objectWriter.imethod_33(geoMeshFace.FaceIndex3);
      }
      if (ow.Version > DxfVersion.Dxf21)
        return;
      objectWriter.imethod_14(true);
      objectWriter.imethod_14(false);
      objectWriter.imethod_20(this.point3D_1.Y);
      objectWriter.imethod_20(this.point3D_1.X);
      objectWriter.imethod_20(this.point3D_1.Y);
      objectWriter.imethod_20(this.point3D_1.X);
      objectWriter.imethod_33(0);
      objectWriter.imethod_33(0);
      objectWriter.imethod_25(WW.Math.Point2D.Zero);
      objectWriter.imethod_25(WW.Math.Point2D.Zero);
      objectWriter.imethod_14(false);
      objectWriter.imethod_16(this.vector2D_0.GetAngle() * (180.0 / System.Math.PI));
      objectWriter.imethod_16(this.vector2D_0.GetAngle());
      objectWriter.imethod_33((int) this.scaleEstimationMethod_0);
      objectWriter.imethod_16(this.double_0);
      objectWriter.imethod_14(this.bool_0);
      objectWriter.imethod_16(this.double_1);
      objectWriter.imethod_16(this.double_2);
    }

    internal override void Read(Class434 or, Class259 ob)
    {
      base.Read(or, ob);
      Interface30 objectBitStream = or.ObjectBitStream;
      this.int_0 = objectBitStream.imethod_11();
      or.Builder.method_10(objectBitStream.imethod_32(true), (System.Action<DxfObjectReference>) (o => this.dxfObjectReference_3 = o));
      this.designCoordinatesType_0 = (DesignCoordinatesType) objectBitStream.imethod_14();
      switch (this.int_0)
      {
        case 1:
          this.point3D_1 = objectBitStream.imethod_39();
          this.unitsValue_0 = (UnitsValue) objectBitStream.imethod_11();
          this.unitsValue_1 = this.unitsValue_0;
          this.point3D_0 = objectBitStream.imethod_39();
          objectBitStream.imethod_39();
          this.vector3D_0 = objectBitStream.imethod_51();
          this.vector2D_0 = Vector2D.FromAngle(System.Math.PI / 2.0 - objectBitStream.imethod_8());
          objectBitStream.imethod_39();
          this.string_0 = objectBitStream.ReadString();
          this.string_1 = objectBitStream.ReadString();
          this.vector2D_1.X = objectBitStream.imethod_8();
          this.vector2D_1.Y = this.vector2D_1.X;
          objectBitStream.ReadString();
          objectBitStream.ReadString();
          break;
        case 2:
        case 3:
          this.point3D_0 = objectBitStream.imethod_39();
          this.point3D_1 = objectBitStream.imethod_39();
          this.vector2D_1.X = objectBitStream.imethod_8();
          this.unitsValue_0 = (UnitsValue) objectBitStream.imethod_11();
          this.vector2D_1.Y = objectBitStream.imethod_8();
          this.unitsValue_1 = (UnitsValue) objectBitStream.imethod_11();
          this.vector3D_0 = objectBitStream.imethod_51();
          this.vector2D_0 = objectBitStream.imethod_50();
          this.scaleEstimationMethod_0 = (ScaleEstimationMethod) objectBitStream.imethod_11();
          this.double_0 = objectBitStream.imethod_8();
          this.bool_0 = objectBitStream.imethod_6();
          this.double_1 = objectBitStream.imethod_8();
          this.double_2 = objectBitStream.imethod_8();
          this.string_0 = objectBitStream.ReadString();
          this.string_1 = objectBitStream.ReadString();
          break;
      }
      this.string_2 = objectBitStream.ReadString();
      this.string_3 = objectBitStream.ReadString();
      this.string_4 = objectBitStream.ReadString();
      int num1 = objectBitStream.imethod_11();
      for (int index = 0; index < num1; ++index)
        this.list_0.Add(new GeoMeshPoint(objectBitStream.imethod_38(), objectBitStream.imethod_38()));
      int num2 = objectBitStream.imethod_11();
      for (int index = 0; index < num2; ++index)
        this.list_1.Add(new GeoMeshFace(objectBitStream.imethod_11(), objectBitStream.imethod_11(), objectBitStream.imethod_11()));
      if (this.int_0 != 1 || !objectBitStream.imethod_6())
        return;
      objectBitStream.imethod_6();
      objectBitStream.imethod_38();
      objectBitStream.imethod_38();
      objectBitStream.imethod_11();
      objectBitStream.imethod_11();
      objectBitStream.imethod_38();
      objectBitStream.imethod_38();
      objectBitStream.imethod_6();
      objectBitStream.imethod_8();
      objectBitStream.imethod_8();
      this.scaleEstimationMethod_0 = (ScaleEstimationMethod) objectBitStream.imethod_11();
      this.double_0 = objectBitStream.imethod_8();
      this.bool_0 = objectBitStream.imethod_6();
      this.double_1 = objectBitStream.imethod_8();
      this.double_2 = objectBitStream.imethod_8();
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.method_234("AcDbGeoData");
      if (w.Version > DxfVersion.Dxf21)
      {
        w.Write(90, (object) (w.Version > DxfVersion.Dxf24 ? 3 : 2));
        if (this.HostBlock != null)
          w.Write(330, (object) this.HostBlock.Handle);
        w.Write(70, (object) (short) this.designCoordinatesType_0);
        w.Write(10, this.point3D_0);
        w.Write(11, this.point3D_1);
        w.Write(40, (object) this.vector2D_1.X);
        w.Write(91, (object) (int) this.unitsValue_0);
        w.Write(41, (object) this.vector2D_1.Y);
        w.Write(92, (object) (int) this.unitsValue_1);
        w.Write(210, this.vector3D_0);
        w.Write(12, this.vector2D_0);
        w.Write(95, (object) this.scaleEstimationMethod_0);
        w.Write(141, (object) this.double_0);
        w.Write(294, (object) this.bool_0);
        w.Write(142, (object) this.double_1);
        w.Write(143, (object) this.double_2);
        w.method_141(301, 303, this.string_0);
        w.Write(302, (object) this.string_1);
        w.Write(305, (object) this.string_2);
        w.Write(306, (object) this.string_3);
        w.Write(307, (object) this.string_4);
        w.Write(93, (object) this.list_0.Count);
        foreach (GeoMeshPoint geoMeshPoint in this.list_0)
        {
          w.Write(13, geoMeshPoint.Source);
          w.Write(14, geoMeshPoint.Destination);
        }
        w.Write(96, (object) this.list_1.Count);
        foreach (GeoMeshFace geoMeshFace in this.list_1)
        {
          w.Write(97, (object) geoMeshFace.FaceIndex1);
          w.Write(98, (object) geoMeshFace.FaceIndex2);
          w.Write(99, (object) geoMeshFace.FaceIndex3);
        }
      }
      else
      {
        w.Write(90, (object) 1);
        w.Write(70, (object) (short) this.designCoordinatesType_0);
        if (this.HostBlock != null)
          w.Write(330, (object) this.HostBlock.Handle);
        w.Write(40, (object) this.point3D_1.Y);
        w.Write(41, (object) this.point3D_1.X);
        w.Write(42, (object) this.point3D_1.Z);
        w.Write(91, (object) (int) this.unitsValue_0);
        w.Write(10, this.point3D_0);
        w.Write(11, WW.Math.Point3D.Zero);
        w.Write(210, this.vector3D_0);
        w.Write(52, (object) (MathUtil.NormalizeAngleTwoPi(System.Math.PI / 2.0 - this.vector2D_0.GetAngle()) * (180.0 / System.Math.PI)));
        w.Write(43, (object) 1.0);
        w.Write(44, (object) 1.0);
        w.Write(45, (object) 1.0);
        w.Write(301, (object) this.string_0);
        w.Write(302, (object) this.string_1);
        w.Write(46, (object) this.vector2D_1.X);
        w.Write(303, (object) string.Empty);
        w.Write(304, (object) string.Empty);
        w.Write(305, (object) this.string_2);
        w.Write(306, (object) this.string_3);
        w.Write(307, (object) this.string_4);
        w.Write(93, (object) this.list_0.Count);
        foreach (GeoMeshPoint geoMeshPoint in this.list_0)
        {
          w.Write(12, geoMeshPoint.Source);
          w.Write(13, geoMeshPoint.Destination);
        }
        w.Write(96, (object) this.list_1.Count);
        foreach (GeoMeshFace geoMeshFace in this.list_1)
        {
          w.Write(97, (object) geoMeshFace.FaceIndex1);
          w.Write(98, (object) geoMeshFace.FaceIndex2);
          w.Write(99, (object) geoMeshFace.FaceIndex3);
        }
        w.Write(3, (object) "CIVIL3D_DATA_BEGIN");
        w.Write(292, (object) false);
        w.Write(14, new WW.Math.Point2D(this.point3D_1.X, this.point3D_1.Y));
        w.Write(15, new WW.Math.Point2D(this.point3D_1.X, this.point3D_1.Y));
        w.Write(93, (object) 0);
        w.Write(94, (object) 0);
        w.Write(293, (object) false);
        w.Write(16, WW.Math.Point2D.Zero);
        w.Write(17, WW.Math.Point2D.Zero);
        w.Write(54, (object) ((System.Math.PI / 2.0 - this.vector2D_0.GetAngle()) * (180.0 / System.Math.PI)));
        w.Write(140, (object) (System.Math.PI / 2.0 - this.vector2D_0.GetAngle()));
        w.Write(95, (object) (int) this.scaleEstimationMethod_0);
        w.Write(141, (object) this.double_0);
        w.Write(294, (object) this.bool_0);
        w.Write(142, (object) this.double_1);
        w.Write(143, (object) this.double_2);
        w.Write(4, (object) "CIVIL3D_DATA_END");
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
          case "AcDbGeoData":
            if (r.ModelBuilder.Version > DxfVersion.Dxf21)
            {
              this.method_12(r, objectBuilder);
              continue;
            }
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
      r.method_91("AcDbGeoData");
      r.method_85();
      while (!r.method_92("AcDbGeoData"))
      {
        if (!this.method_9(r, objectBuilder))
          r.method_85();
      }
    }

    private bool method_9(DxfReader r, Class259 objectBuilder)
    {
      switch (r.CurrentGroup.Code)
      {
        case 3:
          string str1 = (string) r.CurrentGroup.Value;
          goto case 11;
        case 4:
          string str2 = (string) r.CurrentGroup.Value;
          goto case 11;
        case 10:
          this.point3D_0.X = (double) r.CurrentGroup.Value;
          goto case 11;
        case 11:
        case 21:
        case 31:
        case 43:
        case 44:
        case 45:
        case 93:
        case 96:
        case 303:
        case 304:
          r.method_85();
          return true;
        case 12:
          this.list_0.Add(new GeoMeshPoint(new WW.Math.Point2D((double) r.CurrentGroup.Value, 0.0), WW.Math.Point2D.Zero));
          goto case 11;
        case 13:
          if (this.list_0.Count > 0)
          {
            GeoMeshPoint geoMeshPoint = this.list_0[this.list_0.Count - 1];
            geoMeshPoint.Destination = new WW.Math.Point2D((double) r.CurrentGroup.Value, geoMeshPoint.Destination.Y);
            goto case 11;
          }
          else
          {
            this.list_0.Add(new GeoMeshPoint(WW.Math.Point2D.Zero, new WW.Math.Point2D((double) r.CurrentGroup.Value, 0.0)));
            goto case 11;
          }
        case 20:
          this.point3D_0.Y = (double) r.CurrentGroup.Value;
          goto case 11;
        case 22:
          if (this.list_0.Count > 0)
          {
            GeoMeshPoint geoMeshPoint = this.list_0[this.list_0.Count - 1];
            geoMeshPoint.Source = new WW.Math.Point2D(geoMeshPoint.Source.X, (double) r.CurrentGroup.Value);
            goto case 11;
          }
          else
          {
            this.list_0.Add(new GeoMeshPoint(new WW.Math.Point2D(0.0, (double) r.CurrentGroup.Value), WW.Math.Point2D.Zero));
            goto case 11;
          }
        case 23:
          if (this.list_0.Count > 0)
          {
            GeoMeshPoint geoMeshPoint = this.list_0[this.list_0.Count - 1];
            geoMeshPoint.Destination = new WW.Math.Point2D(geoMeshPoint.Destination.X, (double) r.CurrentGroup.Value);
            goto case 11;
          }
          else
          {
            this.list_0.Add(new GeoMeshPoint(WW.Math.Point2D.Zero, new WW.Math.Point2D(0.0, (double) r.CurrentGroup.Value)));
            goto case 11;
          }
        case 30:
          this.point3D_0.Z = (double) r.CurrentGroup.Value;
          goto case 11;
        case 40:
          this.point3D_1.Y = (double) r.CurrentGroup.Value;
          goto case 11;
        case 41:
          this.point3D_1.X = (double) r.CurrentGroup.Value;
          goto case 11;
        case 42:
          this.point3D_1.Z = (double) r.CurrentGroup.Value;
          goto case 11;
        case 46:
          this.vector2D_1.X = (double) r.CurrentGroup.Value;
          goto case 11;
        case 52:
          this.vector2D_0 = Vector2D.FromAngle(System.Math.PI / 2.0 - System.Math.PI / 180.0 * (double) r.CurrentGroup.Value);
          goto case 11;
        case 70:
          this.designCoordinatesType_0 = (DesignCoordinatesType) (short) r.CurrentGroup.Value;
          goto case 11;
        case 90:
          this.int_0 = (int) r.CurrentGroup.Value;
          goto case 11;
        case 91:
          this.unitsValue_0 = (UnitsValue) r.CurrentGroup.Value;
          goto case 11;
        case 97:
          this.list_1.Add(new GeoMeshFace()
          {
            FaceIndex1 = (int) r.CurrentGroup.Value
          });
          goto case 11;
        case 98:
          if (this.list_1.Count > 0)
          {
            this.list_1[this.list_1.Count - 1].FaceIndex2 = (int) r.CurrentGroup.Value;
            goto case 11;
          }
          else
          {
            this.list_1.Add(new GeoMeshFace()
            {
              FaceIndex2 = (int) r.CurrentGroup.Value
            });
            goto case 11;
          }
        case 99:
          if (this.list_1.Count > 0)
          {
            this.list_1[this.list_1.Count - 1].FaceIndex3 = (int) r.CurrentGroup.Value;
            goto case 11;
          }
          else
          {
            this.list_1.Add(new GeoMeshFace()
            {
              FaceIndex3 = (int) r.CurrentGroup.Value
            });
            goto case 11;
          }
        case 210:
          this.vector3D_0.X = (double) r.CurrentGroup.Value;
          goto case 11;
        case 220:
          this.vector3D_0.Y = (double) r.CurrentGroup.Value;
          goto case 11;
        case 230:
          this.vector3D_0.Z = (double) r.CurrentGroup.Value;
          goto case 11;
        case 292:
          if ((bool) r.CurrentGroup.Value)
          {
            this.method_10(r, objectBuilder);
            goto case 11;
          }
          else
            goto case 11;
        case 301:
          this.string_0 += ((string) r.CurrentGroup.Value).Replace("^J", "\n");
          goto case 11;
        case 302:
          this.GeoRssTag = (string) r.CurrentGroup.Value;
          goto case 11;
        case 305:
          this.ObservationFromTag = (string) r.CurrentGroup.Value;
          goto case 11;
        case 306:
          this.ObservationToTag = (string) r.CurrentGroup.Value;
          goto case 11;
        case 307:
          this.ObservationCoverageTag = (string) r.CurrentGroup.Value;
          goto case 11;
        case 330:
          r.ModelBuilder.method_10((ulong) r.CurrentGroup.Value, (System.Action<DxfObjectReference>) (o => this.dxfObjectReference_3 = o));
          goto case 11;
        default:
          return this.method_6(r, objectBuilder);
      }
    }

    private void method_10(DxfReader r, Class259 objectBuilder)
    {
      while (!r.method_92("AcDbGeoData") && r.CurrentGroup.Code != 4)
      {
        if (!this.method_11(r, objectBuilder))
          r.method_85();
      }
    }

    private bool method_11(DxfReader r, Class259 objectBuilder)
    {
      switch (r.CurrentGroup.Code)
      {
        case 14:
          this.point3D_1.Y = (double) r.CurrentGroup.Value;
          goto case 15;
        case 15:
        case 16:
        case 17:
        case 25:
        case 26:
        case 27:
        case 54:
        case 93:
        case 94:
        case 140:
        case 293:
          r.method_85();
          return true;
        case 24:
          this.point3D_1.X = (double) r.CurrentGroup.Value;
          goto case 15;
        case 95:
          this.scaleEstimationMethod_0 = (ScaleEstimationMethod) r.CurrentGroup.Value;
          goto case 15;
        case 141:
          this.double_0 = (double) r.CurrentGroup.Value;
          goto case 15;
        case 142:
          this.double_1 = (double) r.CurrentGroup.Value;
          goto case 15;
        case 143:
          this.double_2 = (double) r.CurrentGroup.Value;
          goto case 15;
        case 294:
          this.bool_0 = (bool) r.CurrentGroup.Value;
          goto case 15;
        default:
          return this.method_6(r, objectBuilder);
      }
    }

    private void method_12(DxfReader r, Class259 objectBuilder)
    {
      r.method_91("AcDbGeoData");
      r.method_85();
      while (!r.method_92("AcDbGeoData"))
      {
        if (!this.method_13(r, objectBuilder))
          r.method_85();
      }
    }

    private bool method_13(DxfReader r, Class259 objectBuilder)
    {
      switch (r.CurrentGroup.Code)
      {
        case 10:
          this.point3D_0.X = (double) r.CurrentGroup.Value;
          goto case 93;
        case 11:
          this.point3D_1.X = (double) r.CurrentGroup.Value;
          goto case 93;
        case 12:
          this.vector2D_0.X = (double) r.CurrentGroup.Value;
          goto case 93;
        case 13:
          this.list_0.Add(new GeoMeshPoint(new WW.Math.Point2D((double) r.CurrentGroup.Value, 0.0), WW.Math.Point2D.Zero));
          goto case 93;
        case 14:
          if (this.list_0.Count > 0)
          {
            GeoMeshPoint geoMeshPoint = this.list_0[this.list_0.Count - 1];
            geoMeshPoint.Destination = new WW.Math.Point2D((double) r.CurrentGroup.Value, geoMeshPoint.Destination.Y);
            goto case 93;
          }
          else
          {
            this.list_0.Add(new GeoMeshPoint(WW.Math.Point2D.Zero, new WW.Math.Point2D((double) r.CurrentGroup.Value, 0.0)));
            goto case 93;
          }
        case 20:
          this.point3D_0.Y = (double) r.CurrentGroup.Value;
          goto case 93;
        case 21:
          this.point3D_1.Y = (double) r.CurrentGroup.Value;
          goto case 93;
        case 22:
          this.vector2D_0.Y = (double) r.CurrentGroup.Value;
          goto case 93;
        case 23:
          if (this.list_0.Count > 0)
          {
            GeoMeshPoint geoMeshPoint = this.list_0[this.list_0.Count - 1];
            geoMeshPoint.Source = new WW.Math.Point2D(geoMeshPoint.Source.X, (double) r.CurrentGroup.Value);
            goto case 93;
          }
          else
          {
            this.list_0.Add(new GeoMeshPoint(new WW.Math.Point2D(0.0, (double) r.CurrentGroup.Value), WW.Math.Point2D.Zero));
            goto case 93;
          }
        case 24:
          if (this.list_0.Count > 0)
          {
            GeoMeshPoint geoMeshPoint = this.list_0[this.list_0.Count - 1];
            geoMeshPoint.Destination = new WW.Math.Point2D(geoMeshPoint.Destination.X, (double) r.CurrentGroup.Value);
            goto case 93;
          }
          else
          {
            this.list_0.Add(new GeoMeshPoint(WW.Math.Point2D.Zero, new WW.Math.Point2D(0.0, (double) r.CurrentGroup.Value)));
            goto case 93;
          }
        case 30:
          this.point3D_0.Z = (double) r.CurrentGroup.Value;
          goto case 93;
        case 31:
          this.point3D_1.Z = (double) r.CurrentGroup.Value;
          goto case 93;
        case 40:
          this.vector2D_1.X = (double) r.CurrentGroup.Value;
          goto case 93;
        case 41:
          this.vector2D_1.Y = (double) r.CurrentGroup.Value;
          goto case 93;
        case 70:
          this.designCoordinatesType_0 = (DesignCoordinatesType) (short) r.CurrentGroup.Value;
          goto case 93;
        case 90:
          this.int_0 = (int) r.CurrentGroup.Value;
          goto case 93;
        case 91:
          this.unitsValue_0 = (UnitsValue) r.CurrentGroup.Value;
          goto case 93;
        case 92:
          this.unitsValue_1 = (UnitsValue) r.CurrentGroup.Value;
          goto case 93;
        case 93:
        case 96:
          r.method_85();
          return true;
        case 95:
          this.scaleEstimationMethod_0 = (ScaleEstimationMethod) r.CurrentGroup.Value;
          goto case 93;
        case 97:
          this.list_1.Add(new GeoMeshFace()
          {
            FaceIndex1 = (int) r.CurrentGroup.Value
          });
          goto case 93;
        case 98:
          if (this.list_1.Count > 0)
          {
            this.list_1[this.list_1.Count - 1].FaceIndex2 = (int) r.CurrentGroup.Value;
            goto case 93;
          }
          else
          {
            this.list_1.Add(new GeoMeshFace()
            {
              FaceIndex2 = (int) r.CurrentGroup.Value
            });
            goto case 93;
          }
        case 99:
          if (this.list_1.Count > 0)
          {
            this.list_1[this.list_1.Count - 1].FaceIndex3 = (int) r.CurrentGroup.Value;
            goto case 93;
          }
          else
          {
            this.list_1.Add(new GeoMeshFace()
            {
              FaceIndex3 = (int) r.CurrentGroup.Value
            });
            goto case 93;
          }
        case 141:
          this.double_0 = (double) r.CurrentGroup.Value;
          goto case 93;
        case 142:
          this.double_1 = (double) r.CurrentGroup.Value;
          goto case 93;
        case 143:
          this.double_2 = (double) r.CurrentGroup.Value;
          goto case 93;
        case 210:
          this.vector3D_0.X = (double) r.CurrentGroup.Value;
          goto case 93;
        case 220:
          this.vector3D_0.Y = (double) r.CurrentGroup.Value;
          goto case 93;
        case 230:
          this.vector3D_0.Z = (double) r.CurrentGroup.Value;
          goto case 93;
        case 294:
          this.bool_0 = (bool) r.CurrentGroup.Value;
          goto case 93;
        case 301:
        case 303:
          this.string_0 += ((string) r.CurrentGroup.Value).Replace("^J", "\n");
          goto case 93;
        case 302:
          this.GeoRssTag = (string) r.CurrentGroup.Value;
          goto case 93;
        case 305:
          this.ObservationFromTag = (string) r.CurrentGroup.Value;
          goto case 93;
        case 306:
          this.ObservationToTag = (string) r.CurrentGroup.Value;
          goto case 93;
        case 307:
          this.ObservationCoverageTag = (string) r.CurrentGroup.Value;
          goto case 93;
        case 330:
          r.ModelBuilder.method_10((ulong) r.CurrentGroup.Value, (System.Action<DxfObjectReference>) (o => this.dxfObjectReference_3 = o));
          goto case 93;
        default:
          return this.method_6(r, objectBuilder);
      }
    }
  }
}
