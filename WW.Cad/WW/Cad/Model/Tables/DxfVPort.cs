// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.DxfVPort
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using System;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Tables
{
  public class DxfVPort : DxfTableRecord
  {
    private WW.Math.Point2D point2D_0 = WW.Math.Point2D.Zero;
    private WW.Math.Point2D point2D_1 = new WW.Math.Point2D(1.0, 1.0);
    private Vector2D vector2D_0 = new Vector2D(1.0, 1.0);
    private WW.Math.Vector3D vector3D_0 = WW.Math.Vector3D.ZAxis;
    private double double_1 = 1.0;
    private double double_2 = 50.0;
    private StandardFlags standardFlags_0 = StandardFlags.IsReferenced;
    private short short_0 = 1000;
    private bool bool_2 = true;
    private bool bool_3 = true;
    private DxfObjectReference dxfObjectReference_3 = new DxfUcs().Reference;
    private bool bool_4 = true;
    private DefaultLightingType defaultLightingType_0 = DefaultLightingType.TwoDistantLights;
    private Color color_0 = Color.CreateFromRgb(3355443);
    private Enum17 enum17_0 = Enum17.flag_2;
    private short short_3 = 5;
    private DxfObjectReference dxfObjectReference_4 = DxfObjectReference.Null;
    public const string ActiveVPortName = "*Active";
    private string string_0;
    private WW.Math.Point2D point2D_2;
    private WW.Math.Point2D point2D_3;
    private Vector2D vector2D_1;
    private WW.Math.Point3D point3D_0;
    private double double_0;
    private double double_3;
    private double double_4;
    private double double_5;
    private double double_6;
    private ViewMode viewMode_0;
    private short short_1;
    private bool bool_0;
    private bool bool_1;
    private SnapStyle snapStyle_0;
    private short short_2;
    private RenderMode renderMode_0;
    private OrthographicType orthographicType_0;
    private double double_7;
    private double double_8;
    private bool bool_5;
    private bool bool_6;
    private bool bool_7;

    public DxfVPort()
    {
    }

    public DxfVPort(string name)
      : this()
    {
      this.string_0 = name;
    }

    public double AspectRatio
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

    public double BackClippingPlane
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

    public bool BackClippingActive
    {
      get
      {
        return this.bool_6;
      }
      set
      {
        if (value)
          this.ViewMode |= ViewMode.ClipBack;
        else
          this.ViewMode &= ~ViewMode.ClipBack;
      }
    }

    public double FrontClippingPlane
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

    public bool FrontClippingActive
    {
      get
      {
        return this.bool_5;
      }
      set
      {
        if (value)
          this.ViewMode |= ViewMode.ClipFront;
        else
          this.ViewMode &= ~ViewMode.ClipFront;
      }
    }

    public WW.Math.Point2D BottomLeft
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

    public WW.Math.Point2D Center
    {
      get
      {
        return this.point2D_2;
      }
      set
      {
        this.point2D_2 = value;
      }
    }

    public short CircleZoomPercent
    {
      get
      {
        return this.short_0;
      }
      set
      {
        if (value < (short) 1)
          throw new ArgumentOutOfRangeException("The minimum CircleZoomPercent value is 1.");
        if (value > (short) 20000)
          throw new ArgumentOutOfRangeException("The maximum CircleZoomPercent value is 20000.");
        this.short_0 = value;
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

    public short FastZoomPercent
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

    public double Height
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

    public double LensLength
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

    public override string Name
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
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
        if (value)
          this.ViewMode |= ViewMode.PerspectiveMode;
        else
          this.ViewMode &= ~ViewMode.PerspectiveMode;
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

    public bool ShowGrid
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

    public bool Snap
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

    public WW.Math.Point2D SnapBasePoint
    {
      get
      {
        return this.point2D_3;
      }
      set
      {
        this.point2D_3 = value;
      }
    }

    public short SnapIsoPair
    {
      get
      {
        return this.short_2;
      }
      set
      {
        this.short_2 = value;
      }
    }

    public double SnapRotationAngle
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

    public SnapStyle SnapStyle
    {
      get
      {
        return this.snapStyle_0;
      }
      set
      {
        this.snapStyle_0 = value;
      }
    }

    public WW.Math.Point3D Target
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

    public WW.Math.Point2D TopRight
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

    public DxfUcs Ucs
    {
      get
      {
        return (DxfUcs) this.dxfObjectReference_3.Value;
      }
      set
      {
        this.dxfObjectReference_3 = DxfObjectReference.GetReference((IDxfHandledObject) value);
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

    public bool DisplayUcs
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

    public override bool IsExternallyDependent
    {
      get
      {
        return (this.standardFlags_0 & StandardFlags.IsExternallyDependent) != StandardFlags.None;
      }
      set
      {
        if (value)
          this.standardFlags_0 |= StandardFlags.IsExternallyDependent;
        else
          this.standardFlags_0 &= ~StandardFlags.IsExternallyDependent;
      }
    }

    public override bool IsResolvedExternalRef
    {
      get
      {
        return (this.standardFlags_0 & StandardFlags.IsResolvedExternalRef) != StandardFlags.None;
      }
      set
      {
        if (value)
          this.standardFlags_0 |= StandardFlags.IsResolvedExternalRef;
        else
          this.standardFlags_0 &= ~StandardFlags.IsResolvedExternalRef;
      }
    }

    public override bool IsReferenced
    {
      get
      {
        return (this.standardFlags_0 & StandardFlags.IsReferenced) != StandardFlags.None;
      }
      set
      {
        if (value)
          this.standardFlags_0 |= StandardFlags.IsReferenced;
        else
          this.standardFlags_0 &= ~StandardFlags.IsReferenced;
      }
    }

    public ViewMode ViewMode
    {
      get
      {
        return this.viewMode_0;
      }
      set
      {
        this.viewMode_0 = value;
        this.bool_5 = (this.viewMode_0 & ViewMode.ClipFront) != ViewMode.None;
        this.bool_6 = (this.viewMode_0 & ViewMode.ClipBack) != ViewMode.None;
        this.bool_7 = (this.viewMode_0 & ViewMode.PerspectiveMode) != ViewMode.None;
      }
    }

    public bool FollowUCS
    {
      get
      {
        return (this.viewMode_0 & ViewMode.FollowUCS) != ViewMode.None;
      }
      set
      {
        if (value)
          this.viewMode_0 |= ViewMode.FollowUCS;
        else
          this.viewMode_0 &= ~ViewMode.FollowUCS;
      }
    }

    public bool ClipFrontNotAtEye
    {
      get
      {
        return (this.viewMode_0 & ViewMode.ClipFrontNotAtEye) != ViewMode.None;
      }
      set
      {
        if (value)
          this.viewMode_0 |= ViewMode.ClipFrontNotAtEye;
        else
          this.viewMode_0 &= ~ViewMode.ClipFrontNotAtEye;
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

    public DefaultLightingType DefaultLightingType
    {
      get
      {
        return this.defaultLightingType_0;
      }
      set
      {
        this.defaultLightingType_0 = value;
      }
    }

    public double Brightness
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

    public double Contrast
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

    public Color AmbientColor
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

    public bool GridDisplayBeyondLimits
    {
      get
      {
        return (this.enum17_0 & Enum17.flag_1) != Enum17.flag_0;
      }
      set
      {
        if (value)
          this.enum17_0 |= Enum17.flag_1;
        else
          this.enum17_0 &= ~Enum17.flag_1;
      }
    }

    public bool GridIsAdaptive
    {
      get
      {
        return (this.enum17_0 & Enum17.flag_2) != Enum17.flag_0;
      }
      set
      {
        if (value)
          this.enum17_0 |= Enum17.flag_2;
        else
          this.enum17_0 &= ~Enum17.flag_2;
      }
    }

    public bool GridAllowSubdivision
    {
      get
      {
        return (this.enum17_0 & Enum17.flag_3) != Enum17.flag_0;
      }
      set
      {
        if (value)
          this.enum17_0 |= Enum17.flag_3;
        else
          this.enum17_0 &= ~Enum17.flag_3;
      }
    }

    public bool GridFollowsDynamicUcs
    {
      get
      {
        return (this.enum17_0 & Enum17.flag_4) != Enum17.flag_0;
      }
      set
      {
        if (value)
          this.enum17_0 |= Enum17.flag_4;
        else
          this.enum17_0 &= ~Enum17.flag_4;
      }
    }

    public short MinorGridLinesPerMajorGridLine
    {
      get
      {
        return this.short_3;
      }
      set
      {
        this.short_3 = value;
      }
    }

    public DxfVisualStyle VisualStyle
    {
      get
      {
        return (DxfVisualStyle) this.dxfObjectReference_4.Value;
      }
      set
      {
        this.dxfObjectReference_4 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public WW.Cad.Model.Objects.GeoMapMode? GeoMapMode
    {
      get
      {
        if (this.ExtensionDictionary == null)
          return new WW.Cad.Model.Objects.GeoMapMode?();
        DxfDictionary valueByName1 = this.ExtensionDictionary.GetValueByName("AcDbVariableDictionary") as DxfDictionary;
        if (valueByName1 == null)
          return new WW.Cad.Model.Objects.GeoMapMode?();
        DxfDictionaryVariable valueByName2 = valueByName1.GetValueByName("GEOMAPMODE") as DxfDictionaryVariable;
        WW.Cad.Model.Objects.GeoMapMode? nullable = new WW.Cad.Model.Objects.GeoMapMode?();
        int result;
        if (int.TryParse(valueByName2.Value, out result))
          nullable = new WW.Cad.Model.Objects.GeoMapMode?((WW.Cad.Model.Objects.GeoMapMode) result);
        return nullable;
      }
      set
      {
        if (value.HasValue)
        {
          DxfDictionary dxfDictionary = (DxfDictionary) null;
          DxfDictionaryVariable dictionaryVariable = (DxfDictionaryVariable) null;
          if (this.ExtensionDictionary == null)
            this.ExtensionDictionary = new DxfDictionary();
          else
            dxfDictionary = this.ExtensionDictionary.GetValueByName("AcDbVariableDictionary") as DxfDictionary;
          if (dxfDictionary == null)
          {
            dxfDictionary = new DxfDictionary();
            this.ExtensionDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("AcDbVariableDictionary", (DxfObject) dxfDictionary, true));
          }
          else
            dictionaryVariable = dxfDictionary.GetValueByName("GEOMAPMODE") as DxfDictionaryVariable;
          if (dictionaryVariable == null)
          {
            dictionaryVariable = new DxfDictionaryVariable();
            dxfDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("GEOMAPMODE", (DxfObject) dictionaryVariable, true));
          }
          dictionaryVariable.Value = ((int) value.Value).ToString();
        }
        else
        {
          if (this.ExtensionDictionary == null)
            return;
          DxfDictionary valueByName = this.ExtensionDictionary.GetValueByName("AcDbVariableDictionary") as DxfDictionary;
          valueByName?.Entries.RemoveAll("GEOMAPMODE");
          if (valueByName.Entries.Count == 0)
          {
            for (int index = this.ExtensionDictionary.Entries.Count - 1; index >= 0; --index)
            {
              if (this.ExtensionDictionary.Entries[index].Value == valueByName)
              {
                this.ExtensionDictionary.Entries.RemoveAt(index);
                break;
              }
            }
          }
          if (this.ExtensionDictionary.Entries.Count != 0)
            return;
          this.ExtensionDictionary = (DxfDictionary) null;
        }
      }
    }

    public IViewDescription ViewDescription
    {
      get
      {
        return (IViewDescription) new DxfVPort.Class464(this);
      }
    }

    public override void Accept(ITableRecordVisitor visitor)
    {
      visitor.Visit(this);
    }

    public static DxfVPort CreateActiveVPort()
    {
      DxfVPort dxfVport = new DxfVPort();
      dxfVport.Name = "*Active";
      dxfVport.Height = 1.0;
      return dxfVport;
    }

    public override bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      bool flag = ValidateUtil.ValidateName((object) this, this.string_0, model, messages);
      if (this.double_0 <= 0.0)
        messages.Add(new DxfMessage(DxfStatus.InvalidVPortHeight, Severity.Warning, "target", (object) this));
      return flag;
    }

    public Matrix4D GetTransform(Size2D targetSize)
    {
      Matrix4D toWcsTransform = DxfUtil.GetToWCSTransform(this.vector3D_0);
      toWcsTransform.Transpose();
      Matrix4D matrix4D = Transformation4D.RotateZ(this.double_6) * toWcsTransform;
      return Transformation4D.Translation(this.point2D_2.X, this.point2D_2.Y, 0.0) * (!this.PerspectiveMode ? Matrix4D.Identity : new Matrix4D(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, -1.0 / this.double_2, 0.0, 0.0, -1.0 / this.double_2, 0.0) * Transformation4D.Translation(0.0, 0.0, -Class484.smethod_0(new Size2D(targetSize.X * this.double_1, targetSize.Y), this.double_2, this.double_0))) * matrix4D * Transformation4D.Translation(-this.point3D_0.X, -this.point3D_0.Y, -this.point3D_0.Z);
    }

    public Matrix4D GetMappingTransform(Rectangle2D targetRectangle, bool invertY)
    {
      return ViewUtil.GetTransform(this.ViewDescription, targetRectangle, invertY);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfVPort dxfVport = (DxfVPort) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfVport == null)
      {
        dxfVport = new DxfVPort();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfVport);
        dxfVport.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfVport;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfVPort dxfVport = (DxfVPort) from;
      this.string_0 = dxfVport.string_0;
      this.point2D_0 = dxfVport.point2D_0;
      this.point2D_1 = dxfVport.point2D_1;
      this.point2D_2 = dxfVport.point2D_2;
      this.point2D_3 = dxfVport.point2D_3;
      this.vector2D_0 = dxfVport.vector2D_0;
      this.vector2D_1 = dxfVport.vector2D_1;
      this.vector3D_0 = dxfVport.vector3D_0;
      this.point3D_0 = dxfVport.point3D_0;
      this.double_0 = dxfVport.double_0;
      this.double_1 = dxfVport.double_1;
      this.double_2 = dxfVport.double_2;
      this.double_3 = dxfVport.double_3;
      this.double_4 = dxfVport.double_4;
      this.double_5 = dxfVport.double_5;
      this.double_6 = dxfVport.double_6;
      this.standardFlags_0 = dxfVport.standardFlags_0;
      this.ViewMode = dxfVport.viewMode_0;
      this.short_0 = dxfVport.short_0;
      this.short_1 = dxfVport.short_1;
      this.bool_0 = dxfVport.bool_0;
      this.bool_1 = dxfVport.bool_1;
      this.snapStyle_0 = dxfVport.snapStyle_0;
      this.short_2 = dxfVport.short_2;
      this.renderMode_0 = dxfVport.renderMode_0;
      this.bool_2 = dxfVport.bool_2;
      this.bool_3 = dxfVport.bool_3;
      this.Ucs = Class906.smethod_2(cloneContext, dxfVport.Ucs);
      this.orthographicType_0 = dxfVport.orthographicType_0;
    }

    public override string ToString()
    {
      return this.string_0 ?? string.Empty;
    }

    internal void method_8(short circleZoomPercent)
    {
      if (circleZoomPercent == (short) 0)
        circleZoomPercent = (short) 100;
      this.short_0 = circleZoomPercent;
    }

    internal StandardFlags Flags
    {
      get
      {
        return this.standardFlags_0;
      }
      set
      {
        this.standardFlags_0 = value;
      }
    }

    internal override void vmethod_3(DxfModel modelContext)
    {
      base.vmethod_3(modelContext);
      this.vmethod_2((IDxfHandledObject) modelContext.VPortTable);
    }

    internal override void vmethod_4(DxfModel modelContext)
    {
      base.vmethod_4(modelContext);
      this.vmethod_2((IDxfHandledObject) null);
    }

    internal Enum17 GridFlags
    {
      get
      {
        return this.enum17_0;
      }
      set
      {
        this.enum17_0 = value;
      }
    }

    private class Class464 : IViewDescription
    {
      private readonly DxfVPort dxfVPort_0;

      public Class464(DxfVPort vport)
      {
        this.dxfVPort_0 = vport;
      }

      public ViewportStatusFlags ViewModeFlags
      {
        get
        {
          return (ViewportStatusFlags) this.dxfVPort_0.ViewMode;
        }
      }

      public WW.Math.Point3D ViewportCenter
      {
        get
        {
          WW.Math.Point2D bottomLeft = this.dxfVPort_0.BottomLeft;
          WW.Math.Point2D topRight = this.dxfVPort_0.TopRight;
          return new WW.Math.Point3D(0.5 * (bottomLeft.X + topRight.X), 0.5 * (bottomLeft.Y + topRight.Y), 0.0);
        }
      }

      public double ViewportWidth
      {
        get
        {
          return System.Math.Abs(this.dxfVPort_0.TopRight.X - this.dxfVPort_0.BottomLeft.X);
        }
      }

      public double ViewportHeight
      {
        get
        {
          return System.Math.Abs(this.dxfVPort_0.TopRight.Y - this.dxfVPort_0.BottomLeft.Y);
        }
      }

      public WW.Math.Point2D ViewCenter
      {
        get
        {
          return this.dxfVPort_0.Center;
        }
      }

      public WW.Math.Vector3D ViewDirection
      {
        get
        {
          return this.dxfVPort_0.Direction;
        }
      }

      public WW.Math.Point3D ViewTarget
      {
        get
        {
          return this.dxfVPort_0.Target;
        }
      }

      public double FocalLength
      {
        get
        {
          return this.dxfVPort_0.LensLength;
        }
      }

      public double FrontClipDistance
      {
        get
        {
          return this.dxfVPort_0.FrontClippingPlane;
        }
      }

      public double BackClipDistance
      {
        get
        {
          return this.dxfVPort_0.BackClippingPlane;
        }
      }

      public double ViewWidth
      {
        get
        {
          return this.dxfVPort_0.Height * this.dxfVPort_0.AspectRatio;
        }
      }

      public double ViewHeight
      {
        get
        {
          return this.dxfVPort_0.Height;
        }
      }

      public double ViewTwistAngle
      {
        get
        {
          return this.dxfVPort_0.TwistAngle;
        }
      }

      public DxfEntity ClippingBoundaryEntity
      {
        get
        {
          return (DxfEntity) null;
        }
      }

      public RenderMode RenderMode
      {
        get
        {
          return this.dxfVPort_0.RenderMode;
        }
      }

      public bool IsTargetPaper
      {
        get
        {
          return false;
        }
      }

      public IList<DxfLayer> FrozenLayers
      {
        get
        {
          return (IList<DxfLayer>) null;
        }
      }
    }
  }
}
