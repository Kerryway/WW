// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfUnknownEntity
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns28;
using ns3;
using System.IO;
using WW.Actions;
using WW.Cad.Drawing;
using WW.Cad.IO;
using WW.IO;
using WW.Math;

namespace WW.Cad.Model.Entities
{
  public class DxfUnknownEntity : DxfEntity
  {
    private ProxyGraphics proxyGraphics_0;

    public ProxyGraphics ProxyGraphics
    {
      get
      {
        return this.proxyGraphics_0;
      }
      set
      {
        this.proxyGraphics_0 = value;
      }
    }

    public override string EntityType
    {
      get
      {
        return "Unknown";
      }
    }

    public override string AcClass
    {
      get
      {
        return "Unknown";
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      if (this.proxyGraphics_0 == null)
        return;
      this.proxyGraphics_0.Draw((DxfEntity) this, context.CreateChildContext((DxfEntity) this, Matrix4D.Identity), graphicsFactory);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      if (this.proxyGraphics_0 == null)
        return;
      this.proxyGraphics_0.Draw((DxfEntity) this, context.CreateChildContext((DxfEntity) this, Matrix4D.Identity), graphicsFactory);
    }

    public override void Accept(IEntityVisitor visitor)
    {
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfUnknownEntity dxfUnknownEntity = (DxfUnknownEntity) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfUnknownEntity == null)
      {
        dxfUnknownEntity = new DxfUnknownEntity();
        this.RegisterClone(cloneContext, (IGraphCloneable) dxfUnknownEntity);
        dxfUnknownEntity.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfUnknownEntity;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfUnknownEntity dxfUnknownEntity = (DxfUnknownEntity) from;
      if (dxfUnknownEntity.proxyGraphics_0 == null)
        this.proxyGraphics_0 = (ProxyGraphics) null;
      else
        this.proxyGraphics_0 = (ProxyGraphics) dxfUnknownEntity.proxyGraphics_0.Clone(cloneContext);
    }

    internal override void vmethod_11(Class434 or, Class285 entityBuilder, long imageSize)
    {
      PagedMemoryStream targetStream = new PagedMemoryStream((long) (int) imageSize, System.Math.Min((int) imageSize, 65536));
      or.ObjectBitStream.imethod_20((int) imageSize, targetStream);
      this.proxyGraphics_0 = new ProxyGraphics();
      ((DxfUnknownEntity.Class307) entityBuilder).ProxyGraphicsBuilder = this.proxyGraphics_0.Read((Stream) targetStream, or.Builder);
    }

    public override void TransformMe(TransformConfig config, Matrix4D matrix)
    {
      this.TransformMe(config, matrix, (CommandGroup) null);
    }

    public override void TransformMe(
      TransformConfig config,
      Matrix4D matrix,
      CommandGroup undoGroup)
    {
      if (this.proxyGraphics_0 == null)
        return;
      CommandGroup undoGroup1 = new CommandGroup((object) this);
      this.proxyGraphics_0.TransformMe(config, matrix, undoGroup1);
      undoGroup.UndoStack.Push((ICommand) undoGroup1);
    }

    internal override Class259 vmethod_9(FileFormat fileFormat)
    {
      return (Class259) new DxfUnknownEntity.Class307(this);
    }

    internal class Class307 : Class285
    {
      private ProxyGraphics.Class758 class758_0;

      public Class307(DxfUnknownEntity entity)
        : base((DxfEntity) entity)
      {
      }

      public ProxyGraphics.Class758 ProxyGraphicsBuilder
      {
        get
        {
          return this.class758_0;
        }
        set
        {
          this.class758_0 = value;
        }
      }

      public override void ResolveReferences(Class374 modelBuilder)
      {
        base.ResolveReferences(modelBuilder);
        if (this.class758_0 == null)
          return;
        this.class758_0.ResolveReferences(modelBuilder);
      }
    }
  }
}
