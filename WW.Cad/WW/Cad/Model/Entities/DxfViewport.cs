// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfViewport
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns2;
using ns28;
using ns33;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.Annotations;
using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public class DxfViewport : DxfEntity
  {
    private WW.Math.Vector3D vector3D_0 = WW.Math.Vector3D.ZAxis;
    private double double_1 = 50.0;
    private double double_7 = 100.0;
    private readonly DxfHandledObjectCollection<DxfLayer> dxfHandledObjectCollection_1 = new DxfHandledObjectCollection<DxfLayer>();
    private ViewportStatusFlags viewportStatusFlags_0 = ViewportStatusFlags.Reserved;
    private DxfObjectReference dxfObjectReference_6 = DxfObjectReference.Null;
    private DxfUcs dxfUcs_0 = new DxfUcs();
    private short short_1 = 5;
    private bool bool_4 = true;
    private LightingType lightingType_0 = LightingType.TwoDistantLights;
    private Color color_0 = Color.CreateFromColorIndex((short) 250);
    public const int IdPaperView = 1;
    private const string string_0 = "ASDK_XREC_ANNOTATION_SCALE_INFO";
    private WW.Math.Point3D point3D_0;
    private Size2D size2D_0;
    private WW.Math.Point2D point2D_0;
    private WW.Math.Point2D point2D_1;
    private Vector2D vector2D_0;
    private Vector2D vector2D_1;
    private WW.Math.Point3D point3D_1;
    private double double_2;
    private double double_3;
    private double double_4;
    private double double_5;
    private double double_6;
    private string string_1;
    private RenderMode renderMode_0;
    private bool bool_2;
    private bool bool_3;
    private OrthographicType orthographicType_0;
    private ShadePlotMode shadePlotMode_0;
    private double double_8;
    private double double_9;
    private double double_10;
    private double double_11;
    private double double_12;
    private double double_13;
    private bool bool_5;
    private bool bool_6;
    private bool bool_7;
    private DxfViewportEntityHeader dxfViewportEntityHeader_0;

    public DxfViewport()
    {
      this.method_10(true);
    }

    public double BackClipPlaneZValue
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

    public bool BackClippingActive
    {
      get
      {
        return this.bool_6;
      }
      set
      {
        this.bool_6 = value;
        if (value)
          this.StatusFlags |= ViewportStatusFlags.ClipBack;
        else
          this.StatusFlags &= ~ViewportStatusFlags.ClipBack;
      }
    }

    public double FrontClipPlaneZValue
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

    public bool FrontClippingActive
    {
      get
      {
        return this.bool_5;
      }
      set
      {
        this.bool_5 = value;
        if (value)
          this.StatusFlags |= ViewportStatusFlags.ClipFront;
        else
          this.StatusFlags &= ~ViewportStatusFlags.ClipFront;
      }
    }

    public bool ClipFrontNotAtEye
    {
      get
      {
        return (this.viewportStatusFlags_0 & ViewportStatusFlags.ClipFrontNotAtEye) != ViewportStatusFlags.None;
      }
      set
      {
        if (value)
          this.StatusFlags |= ViewportStatusFlags.ClipFrontNotAtEye;
        else
          this.StatusFlags &= ~ViewportStatusFlags.ClipFrontNotAtEye;
      }
    }

    public bool PerspectiveMode
    {
      get
      {
        return this.bool_7;
      }
      set
      {
        this.bool_7 = value;
        if (value)
          this.StatusFlags |= ViewportStatusFlags.PerspectiveMode;
        else
          this.StatusFlags &= ~ViewportStatusFlags.PerspectiveMode;
      }
    }

    public bool UseNonRectangularClipBoundary
    {
      get
      {
        return (this.StatusFlags & ViewportStatusFlags.NonRectangularClip) != ViewportStatusFlags.None;
      }
      set
      {
        if (value)
          this.StatusFlags |= ViewportStatusFlags.NonRectangularClip;
        else
          this.StatusFlags &= ~ViewportStatusFlags.NonRectangularClip;
      }
    }

    public DxfEntity ClippingBoundaryEntity
    {
      get
      {
        return (DxfEntity) this.dxfObjectReference_6.Value;
      }
      set
      {
        this.dxfObjectReference_6 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public WW.Math.Point3D Center
    {
      get
      {
        return this.point3D_0;
      }
      set
      {
        this.point3D_0 = value;
        this.method_23();
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
        this.method_23();
      }
    }

    public double CircleZoomPercentage
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

    public IList<DxfLayer> FrozenLayers
    {
      get
      {
        return (IList<DxfLayer>) this.dxfHandledObjectCollection_1;
      }
    }

    public Vector2D GridSpacing
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

    public bool UcsPerViewport
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

    public DxfUcs Ucs
    {
      get
      {
        return this.dxfUcs_0;
      }
      set
      {
        this.dxfUcs_0 = value;
      }
    }

    public bool DisplayUcsIcon
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

    public short Id
    {
      get
      {
        short num = 0;
        DxfLayout layout = this.Layout;
        if (layout != null)
        {
          foreach (DxfViewport viewport in (DxfHandledObjectCollection<DxfViewport>) layout.Viewports)
          {
            ++num;
            if (viewport == this)
              break;
          }
        }
        return num;
      }
    }

    public OrthographicType UcsOrthographicType
    {
      get
      {
        return this.orthographicType_0;
      }
      set
      {
        this.orthographicType_0 = value;
      }
    }

    public double LensLength
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

    public string PlotStyleSheetName
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

    public RenderMode RenderMode
    {
      get
      {
        return this.renderMode_0;
      }
      set
      {
        this.renderMode_0 = value;
      }
    }

    public ShadePlotMode ShadePlotMode
    {
      get
      {
        return this.shadePlotMode_0;
      }
      set
      {
        this.shadePlotMode_0 = value;
      }
    }

    public short MajorGridLineFrequency
    {
      get
      {
        return this.short_1;
      }
      set
      {
        this.short_1 = value;
      }
    }

    public bool UseDefaultLighting
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

    public LightingType DefaultLightingType
    {
      get
      {
        return this.lightingType_0;
      }
      set
      {
        this.lightingType_0 = value;
      }
    }

    public double Brightness
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

    public double Constrast
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

    public Color AmbientLightColor
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

    public double SnapAngle
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

    public WW.Math.Point2D SnapBasePoint
    {
      get
      {
        return this.point2D_1;
      }
      set
      {
        this.point2D_1 = value;
      }
    }

    public Vector2D SnapSpacing
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

    public short Status
    {
      get
      {
        short num1 = 0;
        DxfLayout layout = this.Layout;
        if (layout != null)
        {
          DxfModel model = this.Model;
          if (model != null)
          {
            short num2 = 1;
            foreach (DxfViewport viewport in (DxfHandledObjectCollection<DxfViewport>) layout.Viewports)
            {
              if ((int) num2 <= (int) model.Header.MaxViewportCount)
              {
                if (!viewport.Disabled)
                {
                  if (viewport != this)
                    ++num2;
                  else
                    break;
                }
              }
              else
              {
                num2 = (short) -1;
                break;
              }
            }
            num1 = num2;
          }
        }
        return num1;
      }
    }

    public ViewportStatusFlags StatusFlags
    {
      get
      {
        return this.viewportStatusFlags_0;
      }
      set
      {
        this.viewportStatusFlags_0 = value;
        this.bool_5 = (this.viewportStatusFlags_0 & ViewportStatusFlags.ClipFront) != ViewportStatusFlags.None;
        this.bool_6 = (this.viewportStatusFlags_0 & ViewportStatusFlags.ClipBack) != ViewportStatusFlags.None;
        this.bool_7 = (this.viewportStatusFlags_0 & ViewportStatusFlags.PerspectiveMode) != ViewportStatusFlags.None;
      }
    }

    public bool Disabled
    {
      get
      {
        return (this.viewportStatusFlags_0 & ViewportStatusFlags.DisableViewPort) != ViewportStatusFlags.None;
      }
      set
      {
        if (value)
          this.viewportStatusFlags_0 |= ViewportStatusFlags.DisableViewPort;
        else
          this.viewportStatusFlags_0 &= ~ViewportStatusFlags.DisableViewPort;
      }
    }

    public WW.Math.Point2D ViewCenter
    {
      get
      {
        return this.point2D_0;
      }
      set
      {
        this.point2D_0 = value;
      }
    }

    public WW.Math.Vector3D Direction
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

    public double ViewHeight
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

    public WW.Math.Point3D Target
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

    public double TwistAngle
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

    public bool ModelSpaceVisible
    {
      get
      {
        if (this.Status > (short) 0 && this.PaperSpace && this.Id != (short) 1)
          return !this.Disabled;
        return false;
      }
    }

    public DxfLayout Layout
    {
      get
      {
        DxfLayout dxfLayout = (DxfLayout) null;
        DxfBlock objectSoftReference = this.OwnerObjectSoftReference as DxfBlock;
        if (objectSoftReference != null)
          dxfLayout = objectSoftReference.Layout;
        return dxfLayout;
      }
    }

    internal DxfViewportEntityHeader ViewportEntityHeader
    {
      get
      {
        return this.dxfViewportEntityHeader_0;
      }
      set
      {
        DxfModel model = this.Model;
        if (this.dxfViewportEntityHeader_0 != null)
        {
          this.dxfViewportEntityHeader_0.Viewport = (DxfViewport) null;
          if (model != null && model.ViewportEntityHeaders.Contains(this.dxfViewportEntityHeader_0))
            model.ViewportEntityHeaders.Remove(this.dxfViewportEntityHeader_0);
        }
        this.dxfViewportEntityHeader_0 = value;
        if (this.dxfViewportEntityHeader_0 == null)
          return;
        this.dxfViewportEntityHeader_0.Viewport = this;
        if (model == null || model.ViewportEntityHeaders.Contains(this.dxfViewportEntityHeader_0))
          return;
        model.ViewportEntityHeaders.Add(this.dxfViewportEntityHeader_0);
      }
    }

    internal void method_13(DxfViewportEntityHeader value)
    {
      this.dxfViewportEntityHeader_0 = value;
    }

    public override string EntityType
    {
      get
      {
        return "VIEWPORT";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbViewport";
      }
    }

    public DxfScale AnnotationScale
    {
      get
      {
        if (this.ExtensionDictionary == null)
          return (DxfScale) null;
        DxfXRecord valueByName = this.ExtensionDictionary.GetValueByName("ASDK_XREC_ANNOTATION_SCALE_INFO") as DxfXRecord;
        if (valueByName == null)
          return (DxfScale) null;
        foreach (DxfXRecordValue dxfXrecordValue in (List<DxfXRecordValue>) valueByName.Values)
        {
          if (dxfXrecordValue.Code == (short) 340)
            return dxfXrecordValue.Value as DxfScale;
        }
        return (DxfScale) null;
      }
      set
      {
        if (value == null)
        {
          if (this.ExtensionDictionary == null)
            return;
          for (int index = this.ExtensionDictionary.Entries.Count - 1; index >= 0; --index)
          {
            if (this.ExtensionDictionary.Entries[index].Name == "ASDK_XREC_ANNOTATION_SCALE_INFO")
              this.ExtensionDictionary.Entries.RemoveAt(index);
          }
          if (this.ExtensionDictionary.Entries.Count != 0)
            return;
          this.ExtensionDictionary = (DxfDictionary) null;
        }
        else
        {
          if (this.ExtensionDictionary == null)
            this.ExtensionDictionary = new DxfDictionary();
          DxfXRecord dxfXrecord = this.ExtensionDictionary.GetValueByName("ASDK_XREC_ANNOTATION_SCALE_INFO") as DxfXRecord ?? new DxfXRecord();
          dxfXrecord.Values.Clear();
          dxfXrecord.Values.Add(new DxfXRecordValue((short) 340, (object) value));
        }
      }
    }

    public IViewDescription ViewDescription
    {
      get
      {
        return (IViewDescription) new DxfViewport.Class428(this);
      }
    }

    internal double Bottom
    {
      get
      {
        return this.double_13;
      }
    }

    internal double Left
    {
      get
      {
        return this.double_10;
      }
    }

    internal double Right
    {
      get
      {
        return this.double_11;
      }
    }

    internal double Top
    {
      get
      {
        return this.double_12;
      }
    }

    internal override short EffectiveLineWeight
    {
      get
      {
        return 0;
      }
    }

    internal Matrix4D method_14()
    {
      Matrix4D toWcsTransform = DxfUtil.GetToWCSTransform(this.vector3D_0);
      toWcsTransform.Transpose();
      Matrix4D matrix4D1 = Transformation4D.RotateZ(this.double_6) * toWcsTransform;
      Matrix4D matrix4D2;
      Matrix4D matrix4D3;
      Matrix4D matrix4D4;
      if (this.PerspectiveMode)
      {
        double num1 = Class484.smethod_0(this.size2D_0, this.double_1, this.double_4);
        matrix4D2 = this.method_24();
        matrix4D3 = new Matrix4D(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, -1.0 / this.double_1, 0.0, 0.0, -1.0 / this.double_1, 0.0) * Transformation4D.Translation(0.0, 0.0, -num1);
        double num2 = System.Math.Sqrt(this.size2D_0.X * this.size2D_0.X + this.size2D_0.Y * this.size2D_0.Y) / 42.0;
        matrix4D4 = Transformation4D.Scaling(num2, num2, 1.0);
      }
      else
      {
        matrix4D2 = this.method_25();
        matrix4D3 = Matrix4D.Identity;
        double num = this.size2D_0.Y / this.double_4;
        matrix4D4 = Transformation4D.Scaling(num, num, 1.0);
      }
      Matrix4D matrix4D5 = Transformation4D.Translation(-this.point2D_0.X, -this.point2D_0.Y, 0.0);
      return matrix4D2 * matrix4D4 * matrix4D5 * matrix4D3 * matrix4D1 * Transformation4D.Translation(-(WW.Math.Vector3D) this.point3D_1);
    }

    internal Matrix4D method_15()
    {
      return Transformation4D.Translation((WW.Math.Vector3D) this.point3D_0) * (!this.PerspectiveMode ? this.method_25().GetInverse() : this.method_24().GetInverse());
    }

    internal Matrix3D method_16()
    {
      Matrix3D toWcsTransform3D = DxfUtil.GetToWCSTransform3D(this.vector3D_0);
      toWcsTransform3D.Transpose();
      Matrix3D matrix3D1 = Transformation3D.RotateZ(this.double_6) * toWcsTransform3D;
      Matrix3D matrix3D2;
      if (this.PerspectiveMode)
      {
        Class484.smethod_0(this.size2D_0, this.double_1, this.double_4);
        double num = System.Math.Sqrt(this.size2D_0.X * this.size2D_0.X + this.size2D_0.Y * this.size2D_0.Y) / 42.0;
        matrix3D2 = Transformation3D.Scaling(num, num, num);
      }
      else
      {
        double num = this.size2D_0.Y / this.double_4;
        matrix3D2 = Transformation3D.Scaling(num, num, num);
      }
      return matrix3D2 * matrix3D1;
    }

    internal IClippingTransformer method_17(
      DxfModel model,
      GraphicsConfig graphicsConfig,
      Matrix4D postTransform)
    {
      IClippingTransformer clippingTransformer = (IClippingTransformer) null;
      IClipBoundaryProvider clippingBoundaryEntity = this.ClippingBoundaryEntity as IClipBoundaryProvider;
      if (this.UseNonRectangularClipBoundary && clippingBoundaryEntity != null)
      {
        IList<Polygon2D> clipBoundary = clippingBoundaryEntity.GetClipBoundary(graphicsConfig);
        if (clipBoundary.Count == 1)
        {
          Matrix4D transform = this.GetTransform();
          clippingTransformer = (IClippingTransformer) new ModelSpaceClippingTransformer(postTransform * transform, new Matrix3D(transform.M00, transform.M01, transform.M02, transform.M10, transform.M11, transform.M12, transform.M20, transform.M21, transform.M22), (Interface32) new Class455(transform.GetInverse(), clipBoundary[0], false), graphicsConfig.ShapeFlattenEpsilon, graphicsConfig.ShapeFlattenEpsilonForBoundsCalculation);
        }
      }
      if (clippingTransformer == null)
        clippingTransformer = (IClippingTransformer) new Class938(this, postTransform, graphicsConfig.ShapeFlattenEpsilon, graphicsConfig.ShapeFlattenEpsilonForBoundsCalculation, model.Header.PaperSpaceAnnotationScalingEnabled);
      return clippingTransformer;
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      if (this.Model.Header.AcadVersion >= DxfVersion.Dxf12 && this.Model.Header.AcadVersion <= DxfVersion.Dxf14)
      {
        DxfExtendedData extendedData;
        if (this.ExtendedDataCollection.TryGetValue(this.Model.AppIdAcad, out extendedData))
        {
          extendedData.Values.Clear();
        }
        else
        {
          extendedData = new DxfExtendedData(this.Model.AppIdAcad);
          this.ExtendedDataCollection.Add(extendedData);
        }
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.String("MVIEW"));
        DxfExtendedData.ValueCollection valueCollection1 = new DxfExtendedData.ValueCollection();
        extendedData.Values.Add((IExtendedDataValue) valueCollection1);
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Int16((short) 16));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.PointOrVector(this.point3D_1.X, this.point3D_1.Y, this.point3D_1.Z));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.PointOrVector(this.vector3D_0.X, this.vector3D_0.Y, this.vector3D_0.Z));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Double(this.double_6));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Double(this.double_4));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Double(this.point2D_0.X));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Double(this.point2D_0.Y));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Double(this.double_1));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Double(this.double_2));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Double(this.double_3));
        ViewMode viewMode = (ViewMode) (this.viewportStatusFlags_0 & (ViewportStatusFlags.PerspectiveMode | ViewportStatusFlags.ClipFront | ViewportStatusFlags.ClipBack | ViewportStatusFlags.FollowUcs | ViewportStatusFlags.ClipFrontNotAtEye));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Int16((short) viewMode));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Int16((short) this.double_7));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Int16((this.viewportStatusFlags_0 & ViewportStatusFlags.FastZoom) != ViewportStatusFlags.None ? (short) 1 : (short) 0));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Int16((this.viewportStatusFlags_0 & ViewportStatusFlags.UcsIconVisible) != ViewportStatusFlags.None ? (short) 1 : (short) 0));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Int16((this.viewportStatusFlags_0 & ViewportStatusFlags.SnapMode) != ViewportStatusFlags.None ? (short) 1 : (short) 0));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Int16((this.viewportStatusFlags_0 & ViewportStatusFlags.GridMode) != ViewportStatusFlags.None ? (short) 1 : (short) 0));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Int16((this.viewportStatusFlags_0 & ViewportStatusFlags.IsometricSnapStyle) != ViewportStatusFlags.None ? (short) 1 : (short) 0));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Int16((short) (((this.viewportStatusFlags_0 & ViewportStatusFlags.KIsoPairTop) != ViewportStatusFlags.None ? 1 : 0) + ((this.viewportStatusFlags_0 & ViewportStatusFlags.KIsoPairRight) != ViewportStatusFlags.None ? 2 : 0))));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Double(this.double_5));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Double(this.point2D_1.X));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Double(this.point2D_1.Y));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Double(this.vector2D_0.X));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Double(this.vector2D_0.Y));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Double(this.vector2D_1.X));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Double(this.vector2D_1.Y));
        valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Int16((this.viewportStatusFlags_0 & ViewportStatusFlags.HidePlot) != ViewportStatusFlags.None ? (short) 1 : (short) 0));
        DxfExtendedData.ValueCollection valueCollection2 = new DxfExtendedData.ValueCollection();
        valueCollection1.Add((IExtendedDataValue) valueCollection2);
        foreach (DxfLayer dxfLayer in this.dxfHandledObjectCollection_1)
          valueCollection2.Add((IExtendedDataValue) new DxfExtendedData.LayerReference(dxfLayer));
      }
      else
        this.ExtendedDataCollection.Remove(this.Model.AppIdAcad);
    }

    internal void method_18(DxfModel model)
    {
      DxfExtendedData extendedData;
      if (!this.ExtendedDataCollection.TryGetValue(model.AppIdAcad, out extendedData) || extendedData.Values.Count != 2)
        return;
      DxfExtendedData.ValueCollection valueCollection = (DxfExtendedData.ValueCollection) extendedData.Values[1];
      if (valueCollection.Count != 27)
        return;
      this.point3D_1 = ((DxfExtendedData.PointOrVector) valueCollection[1]).GetPoint3D();
      this.vector3D_0 = ((DxfExtendedData.PointOrVector) valueCollection[2]).GetVector3D();
      this.double_6 = ((DxfExtendedData.Double) valueCollection[3]).Value;
      this.double_4 = ((DxfExtendedData.Double) valueCollection[4]).Value;
      this.point2D_0.X = ((DxfExtendedData.Double) valueCollection[5]).Value;
      this.point2D_0.Y = ((DxfExtendedData.Double) valueCollection[6]).Value;
      this.double_1 = ((DxfExtendedData.Double) valueCollection[7]).Value;
      this.double_2 = ((DxfExtendedData.Double) valueCollection[8]).Value;
      this.double_3 = ((DxfExtendedData.Double) valueCollection[9]).Value;
      this.StatusFlags |= (ViewportStatusFlags) ((DxfExtendedData.Int16) valueCollection[10]).Value;
      this.double_7 = (double) ((DxfExtendedData.Int16) valueCollection[11]).Value;
      if (((DxfExtendedData.Int16) valueCollection[12]).Value == (short) 1)
        this.StatusFlags |= ViewportStatusFlags.FastZoom;
      this.bool_3 = ((DxfExtendedData.Int16) valueCollection[13]).Value == (short) 1;
      if (((DxfExtendedData.Int16) valueCollection[14]).Value == (short) 1)
        this.StatusFlags |= ViewportStatusFlags.SnapMode;
      if (((DxfExtendedData.Int16) valueCollection[15]).Value == (short) 1)
        this.StatusFlags |= ViewportStatusFlags.GridMode;
      if (((DxfExtendedData.Int16) valueCollection[16]).Value == (short) 1)
        this.StatusFlags |= ViewportStatusFlags.IsometricSnapStyle;
      short num = ((DxfExtendedData.Int16) valueCollection[17]).Value;
      if (((int) num & 1) != 0)
        this.StatusFlags |= ViewportStatusFlags.KIsoPairTop;
      if (((int) num & 2) != 0)
        this.StatusFlags |= ViewportStatusFlags.KIsoPairRight;
      this.double_5 = ((DxfExtendedData.Double) valueCollection[18]).Value;
      this.point2D_1.X = ((DxfExtendedData.Double) valueCollection[19]).Value;
      this.point2D_1.Y = ((DxfExtendedData.Double) valueCollection[20]).Value;
      this.vector2D_0.X = ((DxfExtendedData.Double) valueCollection[21]).Value;
      this.vector2D_0.Y = ((DxfExtendedData.Double) valueCollection[22]).Value;
      this.vector2D_1.X = ((DxfExtendedData.Double) valueCollection[23]).Value;
      this.vector2D_1.Y = ((DxfExtendedData.Double) valueCollection[24]).Value;
      if (((DxfExtendedData.Int16) valueCollection[25]).Value == (short) 1)
        this.StatusFlags |= ViewportStatusFlags.HidePlot;
      foreach (IExtendedDataValue extendedDataValue in (List<IExtendedDataValue>) valueCollection[26])
      {
        DxfExtendedData.LayerReference layerReference = extendedDataValue as DxfExtendedData.LayerReference;
        if (layerReference != null)
        {
          this.dxfHandledObjectCollection_1.Add(layerReference.Value);
        }
        else
        {
          DxfExtendedData.String @string = extendedDataValue as DxfExtendedData.String;
          if (@string == null)
            throw new DxfException("Illegal frozen layer value. Expected layer reference or layer reference name string.");
          this.dxfHandledObjectCollection_1.Add(model.Layers[@string.Value]);
        }
      }
    }

    internal void method_19()
    {
      if (this.dxfViewportEntityHeader_0 != null)
        return;
      this.ViewportEntityHeader = new DxfViewportEntityHeader();
      this.ViewportEntityHeader.IsReferenced = true;
      this.ViewportEntityHeader.IsViewportOn = true;
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      if (!this.PaperSpace || !(context is DrawContext.Wireframe.PaperToPaperSpace) || (!this.method_22((DrawContext) context) || this.UseNonRectangularClipBoundary))
        return;
      IList<Polyline4D> polylines = this.method_21((DrawContext) context, context.GetTransformer());
      if (polylines.Count <= 0)
        return;
      graphicsFactory.CreatePath((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), false, polylines, false, true);
    }

    internal void method_20(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      ArgbColor[] argbColorArray = new ArgbColor[10]{ ArgbColors.Red, ArgbColors.Green, ArgbColors.Blue, ArgbColors.Magenta, ArgbColors.Cyan, ArgbColors.Violet, ArgbColors.Orange, ArgbColors.YellowGreen, ArgbColors.Purple, ArgbColors.DarkOrchid };
      ArgbColor color = argbColorArray[(int) this.Id % argbColorArray.Length];
      IList<Polyline4D> polylines = this.method_21((DrawContext) context, context.GetTransformer());
      if (polylines.Count <= 0)
        return;
      graphicsFactory.CreatePath((DxfEntity) this, context, color, false, polylines, false, true);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      if (!this.PaperSpace || !(context is DrawContext.Wireframe.PaperToPaperSpace) || (!this.method_22((DrawContext) context) || this.UseNonRectangularClipBoundary))
        return;
      foreach (Polyline4D polyline in (IEnumerable<Polyline4D>) this.method_21((DrawContext) context, context.GetTransformer()))
        Class940.smethod_1((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this), false, false, true, polyline);
    }

    public Matrix4D GetTransform()
    {
      return this.method_15() * this.method_14();
    }

    public Matrix4D GetMappingTransform(Rectangle2D targetRectangle, bool invertY)
    {
      return ViewUtil.GetTransform(this.ViewDescription, targetRectangle, invertY);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfViewport dxfViewport = (DxfViewport) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfViewport == null)
      {
        dxfViewport = new DxfViewport();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfViewport);
        dxfViewport.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfViewport;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfViewport dxfViewport = (DxfViewport) from;
      this.point3D_0 = dxfViewport.point3D_0;
      this.size2D_0 = dxfViewport.size2D_0;
      this.point2D_0 = dxfViewport.point2D_0;
      this.point2D_1 = dxfViewport.point2D_1;
      this.vector2D_0 = dxfViewport.vector2D_0;
      this.vector2D_1 = dxfViewport.vector2D_1;
      this.vector3D_0 = dxfViewport.vector3D_0;
      this.point3D_1 = dxfViewport.point3D_1;
      this.double_1 = dxfViewport.double_1;
      this.double_2 = dxfViewport.double_2;
      this.double_3 = dxfViewport.double_3;
      this.double_4 = dxfViewport.double_4;
      this.double_5 = dxfViewport.double_5;
      this.double_6 = dxfViewport.double_6;
      this.double_7 = dxfViewport.double_7;
      foreach (DxfLayer from1 in dxfViewport.dxfHandledObjectCollection_1)
      {
        DxfLayer layer = Class906.GetLayer(cloneContext, from1);
        if (!this.dxfHandledObjectCollection_1.Contains(layer))
          this.dxfHandledObjectCollection_1.Add(layer);
      }
      this.StatusFlags = dxfViewport.viewportStatusFlags_0;
      this.dxfObjectReference_6 = DxfObjectReference.Null;
      this.string_1 = dxfViewport.string_1;
      this.renderMode_0 = dxfViewport.renderMode_0;
      this.bool_2 = dxfViewport.bool_2;
      this.bool_3 = dxfViewport.bool_3;
      this.dxfUcs_0 = Class906.smethod_2(cloneContext, dxfViewport.dxfUcs_0);
      this.orthographicType_0 = dxfViewport.orthographicType_0;
      this.shadePlotMode_0 = dxfViewport.shadePlotMode_0;
      this.short_1 = dxfViewport.short_1;
      this.bool_4 = dxfViewport.bool_4;
      this.lightingType_0 = dxfViewport.lightingType_0;
      this.double_8 = dxfViewport.double_8;
      this.double_9 = dxfViewport.double_9;
      this.color_0 = dxfViewport.color_0;
      this.ViewportEntityHeader = dxfViewport.dxfViewportEntityHeader_0 != null ? (DxfViewportEntityHeader) dxfViewport.dxfViewportEntityHeader_0.Clone(cloneContext) : (DxfViewportEntityHeader) null;
      this.method_23();
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override short vmethod_6(Class432 w)
    {
      return 34;
    }

    internal override bool vmethod_13(bool blockContextIsPaperSpace)
    {
      return this.PaperSpace;
    }

    private IList<Polyline4D> method_21(
      DrawContext context,
      IClippingTransformer transformer)
    {
      Polyline3D polyline = new Polyline3D(true, new WW.Math.Point3D[4]{ new WW.Math.Point3D(this.point3D_0.X - this.size2D_0.X * 0.5, this.point3D_0.Y - this.size2D_0.Y * 0.5, 0.0), new WW.Math.Point3D(this.point3D_0.X + this.size2D_0.X * 0.5, this.point3D_0.Y - this.size2D_0.Y * 0.5, 0.0), new WW.Math.Point3D(this.point3D_0.X + this.size2D_0.X * 0.5, this.point3D_0.Y + this.size2D_0.Y * 0.5, 0.0), new WW.Math.Point3D(this.point3D_0.X - this.size2D_0.X * 0.5, this.point3D_0.Y + this.size2D_0.Y * 0.5, 0.0) });
      return transformer.Transform(polyline, false);
    }

    private bool method_22(DrawContext context)
    {
      bool flag = true;
      if (this.Id == (short) 1)
        flag = false;
      else if (context.Layer != null && (context.Layer.Flags & LayerFlags.Frozen) != LayerFlags.None)
        flag = false;
      return flag;
    }

    private void method_23()
    {
      this.double_10 = this.point3D_0.X - this.size2D_0.X * 0.5;
      this.double_11 = this.point3D_0.X + this.size2D_0.X * 0.5;
      this.double_12 = this.point3D_0.Y + this.size2D_0.Y * 0.5;
      this.double_13 = this.point3D_0.Y - this.size2D_0.Y * 0.5;
    }

    private Matrix4D method_24()
    {
      double num1 = Class484.smethod_0(this.size2D_0, this.double_1, this.double_4);
      double num2 = this.double_3 - num1;
      double num3 = this.double_2 - num1;
      double num4 = this.bool_6 ? 1.0 / num2 : 0.0;
      return Transformation4D.Scaling(1.0 / this.size2D_0.X, 1.0 / this.size2D_0.Y, !this.bool_5 ? -1.0 : 1.0 / (1.0 / num3 - num4)) * Transformation4D.Translation(this.size2D_0.X * 0.5, this.size2D_0.Y * 0.5, -num4);
    }

    private Matrix4D method_25()
    {
      return Transformation4D.Scaling(1.0 / this.size2D_0.X, 1.0 / this.size2D_0.Y, !this.bool_5 ? 1.0 : 1.0 / (this.double_2 - this.double_3)) * Transformation4D.Translation(this.size2D_0.X * 0.5, this.size2D_0.Y * 0.5, -this.double_3);
    }

    private class Class428 : IViewDescription
    {
      private readonly DxfViewport dxfViewport_0;

      public Class428(DxfViewport viewport)
      {
        this.dxfViewport_0 = viewport;
      }

      public ViewportStatusFlags ViewModeFlags
      {
        get
        {
          return this.dxfViewport_0.StatusFlags;
        }
      }

      public WW.Math.Point3D ViewportCenter
      {
        get
        {
          return this.dxfViewport_0.Center;
        }
      }

      public double ViewportWidth
      {
        get
        {
          return this.dxfViewport_0.Size.X;
        }
      }

      public double ViewportHeight
      {
        get
        {
          return this.dxfViewport_0.Size.Y;
        }
      }

      public WW.Math.Point2D ViewCenter
      {
        get
        {
          return this.dxfViewport_0.ViewCenter;
        }
      }

      public WW.Math.Vector3D ViewDirection
      {
        get
        {
          return this.dxfViewport_0.Direction;
        }
      }

      public WW.Math.Point3D ViewTarget
      {
        get
        {
          return this.dxfViewport_0.Target;
        }
      }

      public double FocalLength
      {
        get
        {
          return this.dxfViewport_0.LensLength;
        }
      }

      public double FrontClipDistance
      {
        get
        {
          return this.dxfViewport_0.FrontClipPlaneZValue;
        }
      }

      public double BackClipDistance
      {
        get
        {
          return this.dxfViewport_0.BackClipPlaneZValue;
        }
      }

      public double ViewWidth
      {
        get
        {
          return this.dxfViewport_0.ViewHeight * this.dxfViewport_0.Size.X / this.dxfViewport_0.Size.Y;
        }
      }

      public double ViewHeight
      {
        get
        {
          return this.dxfViewport_0.ViewHeight;
        }
      }

      public double ViewTwistAngle
      {
        get
        {
          return this.dxfViewport_0.TwistAngle;
        }
      }

      public DxfEntity ClippingBoundaryEntity
      {
        get
        {
          return this.dxfViewport_0.ClippingBoundaryEntity;
        }
      }

      public RenderMode RenderMode
      {
        get
        {
          return this.dxfViewport_0.RenderMode;
        }
      }

      public bool IsTargetPaper
      {
        get
        {
          return this.dxfViewport_0.Id == (short) 1;
        }
      }

      public IList<DxfLayer> FrozenLayers
      {
        get
        {
          return this.dxfViewport_0.FrozenLayers;
        }
      }
    }
  }
}
