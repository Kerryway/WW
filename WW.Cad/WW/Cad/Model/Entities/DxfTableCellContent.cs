// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfTableCellContent
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using WW.Actions;
using WW.Cad.Drawing;
using WW.Cad.IO;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;
using WW.Math;

namespace WW.Cad.Model.Entities
{
  public class DxfTableCellContent
  {
    private TableCellContentType tableCellContentType_0 = TableCellContentType.Value;
    private DxfValue dxfValue_0 = new DxfValue();
    private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
    private DxfContentFormat dxfContentFormat_0 = new DxfContentFormat();
    private DxfTableAttributeCollection dxfTableAttributeCollection_0 = new DxfTableAttributeCollection();

    public DxfTableCellContent()
    {
    }

    public DxfTableCellContent(DxfValueFormat format)
      : this()
    {
      this.dxfContentFormat_0.method_4(format.Clone());
      this.dxfValue_0.Format = format;
    }

    public DxfTableCellContent(DxfBlock block)
      : this()
    {
      this.ValueObject = (DxfHandledObject) block;
      this.tableCellContentType_0 = TableCellContentType.Block;
    }

    public DxfTableCellContent(DxfValueFormat format, int value)
      : this(format)
    {
      this.dxfValue_0.SetValue(value);
    }

    public DxfTableCellContent(DxfValueFormat format, double value)
      : this(format)
    {
      this.dxfValue_0.SetValue(value);
    }

    public DxfTableCellContent(DxfValueFormat format, WW.Math.Point2D value)
      : this(format)
    {
      this.dxfValue_0.SetValue(value);
    }

    public DxfTableCellContent(DxfValueFormat format, WW.Math.Point3D value)
      : this(format)
    {
      this.dxfValue_0.SetValue(value);
    }

    public DxfTableCellContent(DxfValueFormat format, string value)
      : this(format)
    {
      this.dxfValue_0.SetValue(value);
    }

    public DxfTableCellContent(DxfValueFormat format, DateTime value)
      : this(format)
    {
      this.dxfValue_0.SetValue(value);
    }

    public DxfTableCellContent(DxfValueFormat format, DxfHandledObject value)
      : this(format)
    {
      this.dxfValue_0.SetValue(value);
    }

    public TableCellContentType ContentType
    {
      get
      {
        return this.tableCellContentType_0;
      }
      set
      {
        this.tableCellContentType_0 = value;
      }
    }

    public DxfValue Value
    {
      get
      {
        return this.dxfValue_0;
      }
    }

    public DxfHandledObject ValueObject
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_0.Value;
      }
      set
      {
        if (value != null && !(value is DxfBlock) && !(value is DxfField))
          throw new ArgumentException("Value must be a block or field.");
        this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfContentFormat Format
    {
      get
      {
        return this.dxfContentFormat_0;
      }
    }

    public DxfTableAttributeCollection Attributes
    {
      get
      {
        return this.dxfTableAttributeCollection_0;
      }
    }

    public void ScaleMe(DxfTableCellStyle cellStyle, double scaleFactor, CommandGroup undoGroup)
    {
      if (scaleFactor == 1.0)
        return;
      this.dxfContentFormat_0.ScaleMe(cellStyle, scaleFactor, undoGroup);
    }

    public DxfTableCellContent Clone(CloneContext cloneContext)
    {
      DxfTableCellContent tableCellContent = new DxfTableCellContent();
      tableCellContent.tableCellContentType_0 = this.tableCellContentType_0;
      tableCellContent.dxfValue_0 = this.dxfValue_0 != null ? this.dxfValue_0.Clone(cloneContext) : (DxfValue) null;
      tableCellContent.ValueObject = (DxfHandledObject) cloneContext.Clone((IGraphCloneable) this.ValueObject);
      tableCellContent.dxfContentFormat_0 = (DxfContentFormat) this.dxfContentFormat_0.Clone(cloneContext);
      foreach (DxfTableAttribute dxfTableAttribute in (List<DxfTableAttribute>) this.dxfTableAttributeCollection_0)
        tableCellContent.dxfTableAttributeCollection_0.Add(dxfTableAttribute.Clone(cloneContext));
      return tableCellContent;
    }

    public override string ToString()
    {
      if (this.dxfValue_0 != null)
        return this.dxfValue_0.ToString();
      return string.Empty;
    }

    internal void method_0(
      DxfTableContent tableContent,
      double width,
      double height,
      double rotation,
      double horizontalMargin,
      double verticalMargin)
    {
      DxfBlock valueObject = this.ValueObject as DxfBlock;
      if (valueObject == null)
      {
        this.dxfContentFormat_0.method_6(1.0);
      }
      else
      {
        DxfInsert dxfInsert = new DxfInsert(valueObject);
        foreach (DxfTableAttribute dxfTableAttribute in (List<DxfTableAttribute>) this.dxfTableAttributeCollection_0)
        {
          if (dxfTableAttribute.AttributeDefinition != null)
          {
            DxfAttribute dxfAttribute1 = new DxfAttribute(dxfTableAttribute.AttributeDefinition);
            dxfAttribute1.Text = dxfTableAttribute.Value;
            DxfAttribute dxfAttribute2 = dxfAttribute1;
            dxfAttribute2.AlignmentPoint1 = dxfAttribute2.AlignmentPoint1 - valueObject.BasePoint;
            if (dxfAttribute1.AlignmentPoint2.HasValue)
            {
              DxfAttribute dxfAttribute3 = dxfAttribute1;
              WW.Math.Point3D? alignmentPoint2 = dxfAttribute3.AlignmentPoint2;
              WW.Math.Vector3D basePoint = valueObject.BasePoint;
              dxfAttribute3.AlignmentPoint2 = alignmentPoint2.HasValue ? new WW.Math.Point3D?(alignmentPoint2.GetValueOrDefault() - basePoint) : new WW.Math.Point3D?();
            }
          }
        }
        BoundsCalculator boundsCalculator = new BoundsCalculator();
        boundsCalculator.GetBounds(tableContent.Model, (DxfEntity) dxfInsert);
        Bounds3D bounds = boundsCalculator.Bounds;
        Matrix4D transform = Transformation4D.Translation(valueObject.BasePoint) * Transformation4D.RotateZ(rotation) * Transformation4D.Translation(-valueObject.BasePoint);
        bounds.Transform(transform);
        Vector2D vector2D = new Vector2D((width - 2.0 * horizontalMargin) / bounds.Delta.X, (height - 2.0 * verticalMargin) / bounds.Delta.Y);
        this.dxfContentFormat_0.BlockScale = System.Math.Min(vector2D.X, vector2D.Y);
      }
    }

    internal Bounds3D method_1(DxfTable table)
    {
      DxfBlock valueObject = this.ValueObject as DxfBlock;
      if (valueObject == null)
        return (Bounds3D) null;
      DxfInsert dxfInsert = new DxfInsert(valueObject);
      foreach (DxfTableAttribute dxfTableAttribute in (List<DxfTableAttribute>) this.dxfTableAttributeCollection_0)
      {
        if (dxfTableAttribute.AttributeDefinition != null)
        {
          DxfAttribute dxfAttribute1 = new DxfAttribute(dxfTableAttribute.AttributeDefinition);
          dxfAttribute1.Text = dxfTableAttribute.Value;
          DxfAttribute dxfAttribute2 = dxfAttribute1;
          dxfAttribute2.AlignmentPoint1 = dxfAttribute2.AlignmentPoint1 - valueObject.BasePoint;
          if (dxfAttribute1.AlignmentPoint2.HasValue)
          {
            DxfAttribute dxfAttribute3 = dxfAttribute1;
            WW.Math.Point3D? alignmentPoint2 = dxfAttribute3.AlignmentPoint2;
            WW.Math.Vector3D basePoint = valueObject.BasePoint;
            dxfAttribute3.AlignmentPoint2 = alignmentPoint2.HasValue ? new WW.Math.Point3D?(alignmentPoint2.GetValueOrDefault() - basePoint) : new WW.Math.Point3D?();
          }
        }
      }
      BoundsCalculator boundsCalculator = new BoundsCalculator();
      boundsCalculator.GetBounds(table.Content.Model, (DxfEntity) dxfInsert);
      Bounds3D bounds = boundsCalculator.Bounds;
      Matrix4D transform = Transformation4D.Translation(valueObject.BasePoint) * Transformation4D.RotateZ(this.dxfContentFormat_0.Rotation) * Transformation4D.Translation(-valueObject.BasePoint);
      bounds.Transform(transform);
      return bounds;
    }

    internal void Write(DxfWriter w)
    {
      w.Write(302, (object) "CONTENT");
      w.Write(1, (object) "CELLCONTENT_BEGIN");
      w.Write(90, (object) (int) this.tableCellContentType_0);
      switch (this.tableCellContentType_0)
      {
        case TableCellContentType.Value:
          w.Write(300, (object) "VALUE");
          this.dxfValue_0.Write(w);
          break;
        case TableCellContentType.Field:
        case TableCellContentType.Block:
          w.method_218(340, this.ValueObject);
          break;
      }
      w.Write(91, (object) this.dxfTableAttributeCollection_0.Count);
      int index = 1;
      foreach (DxfTableAttribute dxfTableAttribute in (List<DxfTableAttribute>) this.dxfTableAttributeCollection_0)
      {
        dxfTableAttribute.Write(w, index);
        ++index;
      }
      w.Write(309, (object) "CELLCONTENT_END");
      w.Write(1, (object) "FORMATTEDCELLCONTENT_BEGIN");
      w.Write(170, (object) this.dxfContentFormat_0.DataFlags);
      if (this.dxfContentFormat_0.HasData)
        this.dxfContentFormat_0.method_7(w);
      w.Write(309, (object) "FORMATTEDCELLCONTENT_END");
    }
  }
}
