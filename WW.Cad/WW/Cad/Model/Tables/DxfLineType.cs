// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.DxfLineType
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns30;
using ns4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using WW.Cad.Base;
using WW.Cad.Model.Entities;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Tables
{
  [Editor(typeof (DxfLineType.WinFormsPicker), typeof (System.Drawing.Design.UITypeEditor))]
  public class DxfLineType : DxfTableRecord
  {
    private bool bool_0 = true;
    private StandardFlags standardFlags_0 = StandardFlags.IsReferenced;
    private readonly DxfLineType.ElementCollection elementCollection_0 = new DxfLineType.ElementCollection();
    public const string LineTypeNameContinuous = "Continuous";
    public const string LineTypeNameByBlock = "ByBlock";
    public const string LineTypeNameByLayer = "ByLayer";
    private string string_0;
    private string string_1;

    public DxfLineType()
    {
    }

    public DxfLineType(string name, params double[] lengths)
      : this(name, (string) null, true, lengths)
    {
    }

    public DxfLineType(string name, string description, params double[] lengths)
      : this(name, description, true, lengths)
    {
    }

    public DxfLineType(string name, string description, bool modifyable, params double[] lengths)
    {
      this.Name = name;
      this.string_1 = description;
      if (lengths != null)
      {
        for (int index = 0; index < lengths.Length; ++index)
          this.elementCollection_0.Add(new DxfLineType.Element(lengths[index]));
      }
      this.bool_0 = modifyable;
    }

    public override string Name
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.method_9();
        this.string_0 = value;
      }
    }

    public string Description
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.method_9();
        this.string_1 = value;
      }
    }

    public double TotalLength
    {
      get
      {
        double num = 0.0;
        foreach (DxfLineType.Element element in (List<DxfLineType.Element>) this.elementCollection_0)
          num += System.Math.Abs(element.Length);
        return num;
      }
    }

    public bool IsModifyable
    {
      get
      {
        return this.bool_0;
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

    public DxfLineType.ElementCollection Elements
    {
      get
      {
        return this.elementCollection_0;
      }
    }

    public bool ContainsElementWithPositiveLength
    {
      get
      {
        for (int index = 0; index < this.elementCollection_0.Count; ++index)
        {
          if (this.elementCollection_0[index].Length > 0.0)
            return true;
        }
        return false;
      }
    }

    public override void Accept(ITableRecordVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      return ValidateUtil.ValidateName((object) this, this.string_0, model, messages);
    }

    public override string ToString()
    {
      return this.string_0;
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfLineType dxfLineType = (DxfLineType) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfLineType == null)
      {
        dxfLineType = new DxfLineType();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfLineType);
        dxfLineType.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfLineType;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfLineType dxfLineType = (DxfLineType) from;
      this.string_0 = dxfLineType.string_0;
      this.string_1 = dxfLineType.string_1;
      this.bool_0 = dxfLineType.bool_0;
      this.standardFlags_0 = dxfLineType.standardFlags_0;
      this.elementCollection_0.Clear();
      foreach (DxfLineType.Element element in (List<DxfLineType.Element>) dxfLineType.elementCollection_0)
        this.elementCollection_0.Add(element.Clone(cloneContext));
      switch (dxfLineType.Handle)
      {
        case 20:
        case 21:
        case 22:
          this.SetHandle(dxfLineType.Handle);
          break;
      }
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

    internal void method_8(string name)
    {
      this.string_0 = name;
    }

    internal static DxfLineType smethod_2(bool useFixedHandles)
    {
      DxfLineType dxfLineType = new DxfLineType("Continuous", "Solid line", false, (double[]) null);
      if (useFixedHandles)
        dxfLineType.SetHandle(22UL);
      return dxfLineType;
    }

    internal static DxfLineType smethod_3(bool useFixedHandles)
    {
      DxfLineType dxfLineType = new DxfLineType("ByBlock", "", false, (double[]) null);
      if (useFixedHandles)
        dxfLineType.SetHandle(20UL);
      return dxfLineType;
    }

    internal static DxfLineType smethod_4(bool useFixedHandles)
    {
      DxfLineType dxfLineType = new DxfLineType("ByLayer", "", false, (double[]) null);
      if (useFixedHandles)
        dxfLineType.SetHandle(21UL);
      return dxfLineType;
    }

    internal override void vmethod_3(DxfModel modelContext)
    {
      base.vmethod_3(modelContext);
      this.vmethod_2((IDxfHandledObject) modelContext.LineTypeTable);
    }

    internal override void vmethod_4(DxfModel modelContext)
    {
      base.vmethod_4(modelContext);
      this.vmethod_2((IDxfHandledObject) null);
    }

    private void method_9()
    {
      if (!this.bool_0)
        throw new Exception("This line type (with name " + this.string_0 + " cannot be modified.");
    }

    internal double GetLength()
    {
      double num = 0.0;
      for (int index = this.elementCollection_0.Count - 1; index >= 0; --index)
        num += System.Math.Abs(this.elementCollection_0[index].Length);
      return num;
    }

    public class Element
    {
      private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
      private double double_1 = 1.0;
      private Vector2D vector2D_0 = Vector2D.Zero;
      private string string_0 = string.Empty;
      private double double_0;
      private DxfLineType.ElementType elementType_0;
      private short short_0;
      private double double_2;
      private FillableShape2D fillableShape2D_0;

      public Element()
      {
      }

      public Element(double length)
      {
        this.double_0 = length;
      }

      public double Length
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

      public DxfLineType.ElementType ElementType
      {
        get
        {
          return this.elementType_0;
        }
        set
        {
          this.elementType_0 = value;
        }
      }

      public bool RotationIsAbsolute
      {
        get
        {
          return (this.elementType_0 & DxfLineType.ElementType.RotationIsAbsolute) != DxfLineType.ElementType.None;
        }
        set
        {
          if (value)
            this.elementType_0 |= DxfLineType.ElementType.RotationIsAbsolute;
          else
            this.elementType_0 &= ~DxfLineType.ElementType.RotationIsAbsolute;
        }
      }

      public bool IsText
      {
        get
        {
          return (this.elementType_0 & DxfLineType.ElementType.IsText) != DxfLineType.ElementType.None;
        }
        set
        {
          if (value)
            this.elementType_0 |= DxfLineType.ElementType.IsText;
          else
            this.elementType_0 &= ~DxfLineType.ElementType.IsText;
        }
      }

      public bool IsShape
      {
        get
        {
          return (this.elementType_0 & DxfLineType.ElementType.IsShape) != DxfLineType.ElementType.None;
        }
        set
        {
          if (value)
            this.elementType_0 |= DxfLineType.ElementType.IsShape;
          else
            this.elementType_0 &= ~DxfLineType.ElementType.IsShape;
        }
      }

      public short ShapeNumber
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

      public DxfTextStyle TextStyle
      {
        get
        {
          return (DxfTextStyle) this.dxfObjectReference_0.Value;
        }
        set
        {
          this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        }
      }

      public double Scale
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

      public double Rotation
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

      public Vector2D Offset
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

      public string Text
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

      public FillableShape2D ExtendedShape
      {
        get
        {
          return this.fillableShape2D_0;
        }
      }

      public Matrix3D GetShapeInsertionTransformation(double ltScaling)
      {
        return Transformation3D.Scaling2D(ltScaling) * Transformation3D.Translation(this.vector2D_0) * Transformation3D.Rotate(this.double_2) * Transformation3D.Scaling2D(this.double_1);
      }

      public DxfLineType.Element Clone(CloneContext cloneContext)
      {
        DxfLineType.Element element = new DxfLineType.Element();
        element.CopyFrom(this, cloneContext);
        return element;
      }

      public void CopyFrom(DxfLineType.Element from, CloneContext cloneContext)
      {
        this.double_0 = from.double_0;
        this.elementType_0 = from.elementType_0;
        this.short_0 = from.short_0;
        this.TextStyle = Class906.GetTextStyle(cloneContext, from.TextStyle);
        this.double_1 = from.double_1;
        this.double_2 = from.double_2;
        this.vector2D_0 = from.vector2D_0;
        this.string_0 = from.string_0;
        cloneContext.CloneBuilders.Add((ICloneBuilder) new DxfLineType.Element.Class467(this));
      }

      public override string ToString()
      {
        return this.double_0.ToString();
      }

      internal void method_0(DxfModel model)
      {
        if ((this.elementType_0 & DxfLineType.ElementType.IsShape) != DxfLineType.ElementType.None)
        {
          if (this.TextStyle == null)
            return;
          ShxFile shxFile = this.TextStyle.GetShxFile();
          if (shxFile == null)
            return;
          ShxShape shapeByIndex = shxFile.GetShapeByIndex((ushort) this.short_0);
          if (shapeByIndex == null)
            return;
          WW.Math.Point2D endPoint;
          this.fillableShape2D_0 = new FillableShape2D(shapeByIndex.GetGlyphShape(this.TextStyle.IsVertical, out endPoint), false);
        }
        else
        {
          if ((this.elementType_0 & DxfLineType.ElementType.IsText) == DxfLineType.ElementType.None || this.TextStyle == null)
            return;
          Class425 class425 = Class594.smethod_10(this.string_0, 1.0, this.TextStyle.ObliqueAngle, this.TextStyle.WidthFactor, this.TextStyle, Colors.White);
          List<Class908> class908List = new List<Class908>();
          class425.imethod_3((ICollection<Class908>) class908List, Matrix4D.Identity, (short) 0);
          GeneralShape2D generalShape2D = new GeneralShape2D();
          bool filled = false;
          foreach (Class908 class908 in class908List)
          {
            generalShape2D.Append(class908.FontPath, false);
            if (class908.Font.Filled)
              filled = true;
          }
          if (!generalShape2D.HasSegments)
            return;
          generalShape2D.ShrinkWrap();
          this.fillableShape2D_0 = new FillableShape2D((IShape2D) new CachedBoundsShape2D((IShape2D) generalShape2D), filled);
        }
      }

      private class Class467 : ICloneBuilder
      {
        private readonly DxfLineType.Element element_0;

        public Class467(DxfLineType.Element element)
        {
          this.element_0 = element;
        }

        public void ResolveReferences(CloneContext context)
        {
          this.element_0.method_0(context.TargetModel);
        }
      }
    }

    public class ElementCollection : List<DxfLineType.Element>
    {
    }

    public class WinFormsPicker : System.Drawing.Design.UITypeEditor
    {
      private const int int_0 = 100;

      public override object EditValue(
        ITypeDescriptorContext context,
        System.IServiceProvider provider,
        object value)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        DxfLineType.WinFormsPicker.Class468 class468 = new DxfLineType.WinFormsPicker.Class468();
        // ISSUE: reference to a compiler-generated field
        class468.iwindowsFormsEditorService_0 = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
        // ISSUE: reference to a compiler-generated field
        if (class468.iwindowsFormsEditorService_0 == null)
          return (object) null;
        DxfLineType dxfLineType = value as DxfLineType;
        if (dxfLineType == null)
          return (object) null;
        ListBox listBox = new ListBox();
        // ISSUE: reference to a compiler-generated method
        listBox.SelectedIndexChanged += new EventHandler(class468.method_0);
        listBox.DrawMode = DrawMode.OwnerDrawFixed;
        listBox.DrawItem += new DrawItemEventHandler(this.method_0);
        DxfModel model = dxfLineType.Model;
        foreach (DxfLineType lineType in (KeyedDxfHandledObjectCollection<string, DxfLineType>) model.LineTypes)
          listBox.Items.Add((object) lineType);
        listBox.Size = new Size(400, 200);
        // ISSUE: reference to a compiler-generated field
        class468.iwindowsFormsEditorService_0.DropDownControl((Control) listBox);
        if (listBox.SelectedItems != null && listBox.SelectedItems.Count > 0)
          return listBox.SelectedItems[0];
        return (object) model.ContinuousLineType;
      }

      public override UITypeEditorEditStyle GetEditStyle(
        ITypeDescriptorContext context)
      {
        return UITypeEditorEditStyle.DropDown;
      }

      private void method_0(object sender, DrawItemEventArgs e)
      {
        DxfLineType dxfLineType = (DxfLineType) ((ListBox) sender).Items[e.Index];
        e.DrawBackground();
        int x1 = e.Bounds.Left + 1;
        int top = e.Bounds.Top;
        int num1 = 100;
        int height = e.Bounds.Height;
        int num2 = (e.Bounds.Top + e.Bounds.Bottom) / 2;
        if (dxfLineType.Elements.Count == 0)
        {
          e.Graphics.DrawLine(Pens.Black, x1, num2, x1 + num1, num2);
        }
        else
        {
          int num3 = 3;
          double num4 = (double) num1 / (3.0 * dxfLineType.TotalLength);
          double num5 = 0.0;
          for (int index = 0; index < num3; ++index)
          {
            foreach (DxfLineType.Element element in (List<DxfLineType.Element>) dxfLineType.Elements)
            {
              double num6 = num5 + System.Math.Abs(element.Length);
              if (element.Length == 0.0)
                Class735.smethod_3(e.Graphics, System.Drawing.Color.Black, x1 + (int) (num4 * num5), num2);
              else if (element.Length > 0.0)
                e.Graphics.DrawLine(Pens.Black, x1 + (int) (num4 * num5), num2, x1 + (int) (num4 * num6), num2);
              num5 = num6;
            }
          }
        }
        e.Graphics.DrawString(dxfLineType.ToString(), SystemFonts.DefaultFont, SystemBrushes.ControlText, new RectangleF((float) (x1 + num1 + 3), (float) e.Bounds.Top, (float) (e.Bounds.Right - (x1 + num1) - 3), (float) e.Bounds.Height));
        e.DrawFocusRectangle();
      }
    }

    [System.Flags]
    public enum ElementType : short
    {
      None = 0,
      RotationIsAbsolute = 1,
      IsText = 2,
      IsShape = 4,
    }
  }
}
