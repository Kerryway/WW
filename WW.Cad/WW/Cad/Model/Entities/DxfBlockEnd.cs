// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfBlockEnd
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using WW.Cad.Drawing;

namespace WW.Cad.Model.Entities
{
  public class DxfBlockEnd : DxfEntity
  {
    public override string EntityType
    {
      get
      {
        return "ENDBLK";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockEnd";
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
    }

    public override void Accept(IEntityVisitor visitor)
    {
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockEnd dxfBlockEnd = (DxfBlockEnd) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfBlockEnd == null)
      {
        dxfBlockEnd = new DxfBlockEnd();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfBlockEnd);
        dxfBlockEnd.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfBlockEnd;
    }

    internal override short vmethod_6(Class432 w)
    {
      return 5;
    }
  }
}
