// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfAttribute
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using WW.Cad.Drawing;
using WW.Cad.Model.Objects.Annotations;

namespace WW.Cad.Model.Entities
{
  public class DxfAttribute : DxfAttributeBase, IAnnotative
  {
    private byte byte_0;

    public DxfAttribute()
    {
    }

    public DxfAttribute(string text, WW.Math.Point3D alignmentPoint1)
      : base(text, alignmentPoint1)
    {
    }

    public DxfAttribute(string text, WW.Math.Point3D alignmentPoint1, double height)
      : base(text, alignmentPoint1, height)
    {
    }

    public DxfAttribute(DxfAttributeDefinition attributeDefinition)
      : base((DxfAttributeBase) attributeDefinition)
    {
      this.byte_0 = attributeDefinition.Unknown0;
    }

    public DxfAttribute(DxfAttributeDefinition attributeDefinition, string textValue)
      : this(attributeDefinition)
    {
      this.Text = textValue;
    }

    public override string EntityType
    {
      get
      {
        return "ATTRIB";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbAttribute";
      }
    }

    public override bool IsVisible(DrawContext context)
    {
      if (!this.IsVisibleMultiLine(context.Config) || context.Model.Header.AttributeVisibility == AttributeVisibility.None)
        return false;
      if (context.Model.Header.AttributeVisibility != AttributeVisibility.All)
        return (this.Flags & AttributeFlags.Invisible) == AttributeFlags.None;
      return true;
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfAttribute dxfAttribute = (DxfAttribute) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfAttribute == null)
      {
        dxfAttribute = new DxfAttribute();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfAttribute);
        dxfAttribute.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfAttribute;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      this.byte_0 = ((DxfAttribute) from).byte_0;
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal byte Unknown0
    {
      get
      {
        return this.byte_0;
      }
      set
      {
        this.byte_0 = value;
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return 2;
    }

    public new DxfAnnotationScaleObjectContextData CreateContextData(
      DxfScale scale)
    {
      return (DxfAnnotationScaleObjectContextData) new DxfAttributeObjectContextData(this, scale);
    }
  }
}
