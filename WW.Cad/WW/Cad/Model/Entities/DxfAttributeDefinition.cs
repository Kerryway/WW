// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfAttributeDefinition
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;

namespace WW.Cad.Model.Entities
{
  public class DxfAttributeDefinition : DxfAttributeBase
  {
    private string string_6 = string.Empty;
    private byte byte_0;
    private byte byte_1;

    public DxfAttributeDefinition()
    {
    }

    public DxfAttributeDefinition(string text, WW.Math.Point3D alignmentPoint1)
      : base(text, alignmentPoint1)
    {
    }

    public DxfAttributeDefinition(string text, WW.Math.Point3D alignmentPoint1, double height)
      : base(text, alignmentPoint1, height)
    {
    }

    public string PromptString
    {
      get
      {
        return this.string_6;
      }
      set
      {
        this.string_6 = value;
      }
    }

    public override string EntityType
    {
      get
      {
        return "ATTDEF";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbAttributeDefinition";
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      if (!this.IsVisible((DrawContext) context))
        return;
      DxfMText dxfMtext = this.method_21();
      if (dxfMtext != null)
        dxfMtext.DrawInternal(context, graphicsFactory);
      else
        base.DrawInternal(context, graphicsFactory);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      if (!this.IsVisible((DrawContext) context))
        return;
      DxfMText dxfMtext = this.method_21();
      if (dxfMtext != null)
        dxfMtext.DrawInternal(context, graphicsFactory);
      else
        base.DrawInternal(context, graphicsFactory);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      if (!this.IsVisible((DrawContext) context))
        return;
      DxfMText dxfMtext = this.method_21();
      if (dxfMtext != null)
        dxfMtext.DrawInternal(context, graphicsFactory);
      else
        base.DrawInternal(context, graphicsFactory);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      if (!this.IsVisible((DrawContext) context))
        return;
      DxfMText dxfMtext = this.method_21();
      if (dxfMtext != null)
        dxfMtext.DrawInternal(context, graphics, parentGraphicElementBlock);
      else
        base.DrawInternal(context, graphics, parentGraphicElementBlock);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfAttributeDefinition attributeDefinition = (DxfAttributeDefinition) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (attributeDefinition == null)
      {
        attributeDefinition = new DxfAttributeDefinition();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) attributeDefinition);
        attributeDefinition.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) attributeDefinition;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfAttributeDefinition attributeDefinition = (DxfAttributeDefinition) from;
      this.string_6 = attributeDefinition.string_6;
      this.byte_0 = attributeDefinition.byte_0;
      this.byte_1 = attributeDefinition.byte_1;
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override bool IsVisible(DrawContext context)
    {
      return this.IsVisibleMultiLine(context.Config) && context.Model.Header.AttributeVisibility != AttributeVisibility.None && (context.BlockContext == null || (this.Flags & AttributeFlags.Constant) != AttributeFlags.None) && (context.Model.Header.AttributeVisibility == AttributeVisibility.All || (this.Flags & AttributeFlags.Invisible) == AttributeFlags.None);
    }

    internal override string DisplayString
    {
      get
      {
        DxfModel model = this.Model;
        if (model == null)
          throw new NullReferenceException("The attribute definition must be part of a model to determine its DisplayString.");
        if (this.OwnerObjectSoftReference == null)
          throw new NullReferenceException("The attribute definition must be part of a model or block that is part of a model to determine its DisplayString.");
        if (this.OwnerObjectSoftReference == model.ModelSpaceBlock)
          return this.TagString;
        return this.Text;
      }
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

    internal byte Unknown1
    {
      get
      {
        return this.byte_1;
      }
      set
      {
        this.byte_1 = value;
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return 3;
    }
  }
}
