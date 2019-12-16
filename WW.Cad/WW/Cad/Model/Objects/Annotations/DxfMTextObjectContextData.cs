// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.Annotations.DxfMTextObjectContextData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using ns3;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model.Entities;
using WW.Math;

namespace WW.Cad.Model.Objects.Annotations
{
  public class DxfMTextObjectContextData : DxfAnnotationScaleObjectContextData
  {
    private Size2D size2D_0 = Size2D.Zero;
    private Size2D size2D_1 = Size2D.Zero;
    private WW.Math.Vector3D vector3D_0 = WW.Math.Vector3D.XAxis;
    private WW.Math.Point3D point3D_0 = WW.Math.Point3D.Zero;
    private AttachmentPoint attachmentPoint_0 = AttachmentPoint.TopLeft;
    private DxfMTextObjectContextData.ColumnsData columnsData_0;

    public DxfMTextObjectContextData()
    {
    }

    public DxfMTextObjectContextData(DxfMText mtext, DxfScale scale)
      : base(scale)
    {
      this.size2D_0.X = mtext.ReferenceRectangleWidth;
      this.size2D_0.Y = mtext.ReferenceRectangleHeight;
      this.size2D_1.X = mtext.BoxWidth;
      this.size2D_1.Y = mtext.BoxHeight;
      this.vector3D_0 = mtext.XAxis;
      this.point3D_0 = mtext.InsertionPoint;
      this.attachmentPoint_0 = mtext.AttachmentPoint;
    }

    public DxfMTextObjectContextData.ColumnsData Columns
    {
      get
      {
        return this.columnsData_0;
      }
      private set
      {
        this.columnsData_0 = value;
      }
    }

    public AttachmentPoint AttachmentPoint
    {
      get
      {
        return this.attachmentPoint_0;
      }
      set
      {
        this.attachmentPoint_0 = value;
      }
    }

    public WW.Math.Vector3D XDirection
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

    public WW.Math.Point3D Location
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

    public Size2D ReferenceSize
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

    public Size2D Size
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

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override string AcClass
    {
      get
      {
        return "AcDbMTextObjectContextData";
      }
    }

    public override string ObjectType
    {
      get
      {
        return "ACDB_MTEXTOBJECTCONTEXTDATA_CLASS";
      }
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfMTextObjectContextData objectContextData = (DxfMTextObjectContextData) from;
      this.AttachmentPoint = objectContextData.AttachmentPoint;
      this.XDirection = objectContextData.XDirection;
      this.Location = objectContextData.Location;
      this.ReferenceSize = objectContextData.ReferenceSize;
      this.Size = objectContextData.Size;
      this.Columns = (DxfMTextObjectContextData.ColumnsData) null;
      if (objectContextData.Columns == null)
        return;
      this.Columns = new DxfMTextObjectContextData.ColumnsData(objectContextData.Columns);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfMTextObjectContextData objectContextData = (DxfMTextObjectContextData) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (objectContextData == null)
      {
        objectContextData = new DxfMTextObjectContextData();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) objectContextData);
        objectContextData.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) objectContextData;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1031_0.dxfClass_1.ClassNumber;
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      Interface29 objectWriter = ow.ObjectWriter;
      objectWriter.imethod_33((int) this.AttachmentPoint);
      objectWriter.imethod_29(this.XDirection);
      objectWriter.imethod_24(this.Location);
      objectWriter.imethod_16(this.ReferenceSize.X);
      objectWriter.imethod_16(this.ReferenceSize.Y);
      objectWriter.imethod_16(this.Size.X);
      objectWriter.imethod_16(this.Size.Y);
      objectWriter.imethod_33(this.Columns != null ? (int) this.Columns.Type : 0);
      if (this.Columns == null)
        return;
      objectWriter.imethod_33(this.Columns.ColumnsCount);
      objectWriter.imethod_16(this.Columns.ColumnWidth);
      objectWriter.imethod_16(this.Columns.Gutter);
      objectWriter.imethod_14(this.Columns.IsAutoHeight);
      objectWriter.imethod_14(this.Columns.IsFlowReversed);
      if (this.Columns.IsAutoHeight || this.Columns.Type != DxfMTextObjectContextData.ColumnType.DynamicColumns)
        return;
      foreach (double columnHeight in this.Columns.ColumnHeights)
        objectWriter.imethod_16(columnHeight);
    }

    internal override void Read(Class434 or, Class259 ob)
    {
      base.Read(or, ob);
      Interface30 objectBitStream = or.ObjectBitStream;
      this.AttachmentPoint = (AttachmentPoint) objectBitStream.imethod_11();
      this.XDirection = objectBitStream.imethod_51();
      this.Location = objectBitStream.imethod_39();
      this.size2D_0.X = objectBitStream.imethod_8();
      this.size2D_0.Y = objectBitStream.imethod_8();
      this.size2D_1.X = objectBitStream.imethod_8();
      this.size2D_1.Y = objectBitStream.imethod_8();
      DxfMTextObjectContextData.ColumnType columnType = (DxfMTextObjectContextData.ColumnType) objectBitStream.imethod_11();
      if (columnType == DxfMTextObjectContextData.ColumnType.NoColumns)
      {
        this.Columns = (DxfMTextObjectContextData.ColumnsData) null;
      }
      else
      {
        this.Columns = new DxfMTextObjectContextData.ColumnsData()
        {
          Type = columnType,
          ColumnsCount = objectBitStream.imethod_11(),
          ColumnWidth = objectBitStream.imethod_8(),
          Gutter = objectBitStream.imethod_8(),
          IsAutoHeight = objectBitStream.imethod_6(),
          IsFlowReversed = objectBitStream.imethod_6()
        };
        if (this.Columns.IsAutoHeight || this.Columns.Type != DxfMTextObjectContextData.ColumnType.DynamicColumns || this.Columns.ColumnsCount == 0)
          return;
        this.Columns.ColumnHeights = new List<double>();
        for (int index = 0; index < this.Columns.ColumnsCount; ++index)
          this.Columns.ColumnHeights.Add(objectBitStream.imethod_8());
      }
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.method_219(70, (short) this.AttachmentPoint);
      w.Write(10, this.XDirection);
      w.Write(11, this.Location);
      w.Write(40, (object) this.ReferenceSize.X);
      w.Write(41, (object) this.ReferenceSize.Y);
      w.Write(42, (object) this.Size.X);
      w.Write(43, (object) this.Size.Y);
      w.method_219(71, this.Columns != null ? (short) this.Columns.Type : (short) 0);
      if (this.Columns == null)
        return;
      w.method_219(72, (short) this.Columns.ColumnsCount);
      w.Write(44, (object) this.Columns.ColumnWidth);
      w.Write(45, (object) this.Columns.Gutter);
      w.method_221(73, this.Columns.IsAutoHeight);
      w.method_221(74, this.Columns.IsFlowReversed);
      if (this.Columns.IsAutoHeight || this.Columns.Type != DxfMTextObjectContextData.ColumnType.DynamicColumns)
        return;
      foreach (double columnHeight in this.Columns.ColumnHeights)
        w.Write(46, (object) columnHeight);
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      base.Read(r, objectBuilder);
      while (!r.method_92("AcDbMTextObjectContextData"))
      {
        switch (r.CurrentGroup.Code)
        {
          case 10:
            this.vector3D_0.X = (double) r.CurrentGroup.Value;
            break;
          case 11:
            this.point3D_0.X = (double) r.CurrentGroup.Value;
            break;
          case 20:
            this.vector3D_0.Y = (double) r.CurrentGroup.Value;
            break;
          case 21:
            this.point3D_0.Y = (double) r.CurrentGroup.Value;
            break;
          case 30:
            this.vector3D_0.Z = (double) r.CurrentGroup.Value;
            break;
          case 31:
            this.point3D_0.Z = (double) r.CurrentGroup.Value;
            break;
          case 40:
            this.size2D_0.X = (double) r.CurrentGroup.Value;
            break;
          case 41:
            this.size2D_0.Y = (double) r.CurrentGroup.Value;
            break;
          case 42:
            this.size2D_1.X = (double) r.CurrentGroup.Value;
            break;
          case 43:
            this.size2D_1.Y = (double) r.CurrentGroup.Value;
            break;
          case 44:
            if (this.Columns == null)
              this.Columns = new DxfMTextObjectContextData.ColumnsData();
            this.Columns.ColumnWidth = (double) r.CurrentGroup.Value;
            break;
          case 45:
            if (this.Columns == null)
              this.Columns = new DxfMTextObjectContextData.ColumnsData();
            this.Columns.Gutter = (double) r.CurrentGroup.Value;
            break;
          case 46:
            if (this.Columns == null)
              this.Columns = new DxfMTextObjectContextData.ColumnsData();
            if (this.Columns.ColumnHeights == null)
              this.Columns.ColumnHeights = new List<double>();
            this.Columns.ColumnHeights.Add((double) r.CurrentGroup.Value);
            break;
          case 70:
            this.AttachmentPoint = (AttachmentPoint) r.CurrentGroup.Value;
            break;
          case 71:
            DxfMTextObjectContextData.ColumnType columnType = (DxfMTextObjectContextData.ColumnType) (short) r.CurrentGroup.Value;
            if (this.Columns == null && columnType != DxfMTextObjectContextData.ColumnType.NoColumns)
            {
              this.Columns = new DxfMTextObjectContextData.ColumnsData()
              {
                Type = columnType
              };
              break;
            }
            if (this.Columns != null)
            {
              this.Columns.Type = columnType;
              break;
            }
            break;
          case 72:
            if (this.Columns == null)
              this.Columns = new DxfMTextObjectContextData.ColumnsData();
            this.Columns.ColumnsCount = (int) (short) r.CurrentGroup.Value;
            break;
          case 73:
            if (this.Columns == null)
              this.Columns = new DxfMTextObjectContextData.ColumnsData();
            this.Columns.IsAutoHeight = (short) r.CurrentGroup.Value == (short) 1;
            break;
          case 74:
            if (this.Columns == null)
              this.Columns = new DxfMTextObjectContextData.ColumnsData();
            this.Columns.IsFlowReversed = (short) r.CurrentGroup.Value == (short) 1;
            break;
          default:
            throw new DxfException("Unexpected group code.");
        }
        r.method_85();
      }
      if (this.Columns == null || this.Columns.Type == DxfMTextObjectContextData.ColumnType.NoColumns || (this.Columns.IsAutoHeight || this.Columns.ColumnsCount == 0))
        return;
      if (this.Columns.ColumnHeights == null)
        this.Columns.ColumnHeights = new List<double>();
      while (this.Columns.ColumnHeights.Count < this.Columns.ColumnsCount)
        this.Columns.ColumnHeights.Add(this.size2D_0.Y);
    }

    public enum ColumnType
    {
      NoColumns,
      StaticColumns,
      DynamicColumns,
    }

    public class ColumnsData
    {
      public DxfMTextObjectContextData.ColumnType Type { get; set; }

      public bool IsAutoHeight { get; set; }

      public int ColumnsCount { get; set; }

      public bool IsFlowReversed { get; set; }

      public double Gutter { get; set; }

      public double ColumnWidth { get; set; }

      public List<double> ColumnHeights { get; set; }

      public ColumnsData()
      {
        this.Type = DxfMTextObjectContextData.ColumnType.NoColumns;
        this.IsAutoHeight = false;
        this.ColumnsCount = 0;
        this.IsFlowReversed = false;
        this.Gutter = 0.0;
        this.ColumnWidth = 0.0;
        this.ColumnHeights = (List<double>) null;
      }

      public ColumnsData(DxfMTextObjectContextData.ColumnsData o)
      {
        this.Type = o.Type;
        this.IsAutoHeight = o.IsAutoHeight;
        this.ColumnsCount = o.ColumnsCount;
        this.IsFlowReversed = o.IsFlowReversed;
        this.Gutter = o.Gutter;
        this.ColumnWidth = o.ColumnWidth;
        this.ColumnHeights = o.ColumnHeights != null ? new List<double>((IEnumerable<double>) o.ColumnHeights) : (List<double>) null;
      }
    }
  }
}
