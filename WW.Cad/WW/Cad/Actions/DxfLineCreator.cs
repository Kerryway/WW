// Decompiled with JetBrains decompiler
// Type: WW.Cad.Actions.DxfLineCreator
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WW.Actions;
using WW.Cad.Drawing.GDI;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Drawing;
using WW.Math;

namespace WW.Cad.Actions
{
  public class DxfLineCreator : WW.Actions.Interactor
  {
    private readonly DxfLine dxfLine_0 = new DxfLine();
    private DxfModel dxfModel_0;
    private DxfLayout dxfLayout_0;
    private WW.Cad.Drawing.Node node_0;
    private readonly double double_0;

    public event EventHandler Changed;

    public DxfLineCreator(DxfModel model, double nodeSize)
    {
      this.dxfModel_0 = model;
      this.dxfLayout_0 = (DxfLayout) null;
      this.double_0 = nodeSize;
    }

    public DxfLineCreator(DxfModel model, DxfLayout layout, double nodeSize)
    {
      this.dxfModel_0 = model;
      this.dxfLayout_0 = layout;
      this.double_0 = nodeSize;
    }

    public DxfEntity Entity
    {
      get
      {
        return (DxfEntity) this.dxfLine_0;
      }
    }

    public override bool ProcessMouseButtonDown(
      CanonicalMouseEventArgs e,
      InteractionContext context)
    {
      this.OnChanged((EventArgs) null);
      return this.IsActive;
    }

    public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
    {
      if (this.node_0 != null)
        this.node_0.HighLighted = WW.Math.Point2D.AreApproxEqual(context.ProjectionTransform.TransformTo2D(this.node_0.Position), e.Position, 0.5 * this.double_0);
      this.dxfLine_0.End = context.InverseProjectionTransform.TransformTo3D(e.Position);
      this.OnChanged((EventArgs) null);
      return this.IsActive;
    }

    public override bool ProcessMouseButtonUp(CanonicalMouseEventArgs e, InteractionContext context)
    {
      bool isActive = this.IsActive;
      if (this.IsActive)
      {
        WW.Math.Point2D position1 = e.Position;
        WW.Math.Point3D position2 = context.InverseProjectionTransform.TransformTo3D(position1);
        if (this.node_0 == null)
        {
          this.dxfLine_0.Start = position2;
          this.node_0 = new WW.Cad.Drawing.Node(position2);
          this.OnChanged((EventArgs) null);
        }
        else
        {
          this.dxfLine_0.End = position2;
          this.Deactivate();
        }
      }
      return isActive;
    }

    protected virtual void OnChanged(EventArgs e)
    {
      if (this.eventHandler_0 == null)
        return;
      this.eventHandler_0((object) this, e);
    }

    protected override void OnActivated(EventArgs e)
    {
      this.OnChanged(e);
      base.OnActivated(e);
    }

    protected override void OnDeactivated(EventArgs e)
    {
      this.dxfModel_0 = (DxfModel) null;
      this.node_0 = (WW.Cad.Drawing.Node) null;
      base.OnDeactivated(e);
    }

    public class WinFormsDrawable : WW.Actions.Interactor.WinFormsDrawable
    {
      private readonly DxfLineCreator dxfLineCreator_0;
      private readonly GDIGraphics3D gdigraphics3D_0;

      public event EventHandler RepaintRequested;

      public WinFormsDrawable(DxfLineCreator interactor, GDIGraphics3D graphics)
      {
        this.dxfLineCreator_0 = interactor;
        this.gdigraphics3D_0 = graphics;
        interactor.Deactivated += new EventHandler(this.method_1);
        interactor.Changed += new EventHandler(this.method_0);
      }

      public override void Draw(
        PaintEventArgs e,
        GraphicsHelper graphicsHelper,
        InteractionContext context)
      {
        this.gdigraphics3D_0.Draw(e.Graphics, e.ClipRectangle);
      }

      protected virtual void OnRepaintRequested(EventArgs e)
      {
        if (this.eventHandler_0 == null)
          return;
        this.eventHandler_0((object) this, e);
      }

      private void UpdateDrawables()
      {
        this.gdigraphics3D_0.Clear();
        if (this.dxfLineCreator_0.node_0 != null)
        {
          this.gdigraphics3D_0.CreateDrawables(this.dxfLineCreator_0.dxfModel_0, this.dxfLineCreator_0.dxfLayout_0, (IList<DxfEntity>) new DxfEntity[1]
          {
            (DxfEntity) this.dxfLineCreator_0.dxfLine_0
          }, Matrix4D.Identity);
          this.gdigraphics3D_0.Nodes.Add(this.dxfLineCreator_0.node_0);
        }
        this.OnRepaintRequested((EventArgs) null);
      }

      private void method_0(object sender, EventArgs e)
      {
        this.UpdateDrawables();
      }

      private void method_1(object sender, EventArgs e)
      {
        this.dxfLineCreator_0.Changed -= new EventHandler(this.method_0);
        this.gdigraphics3D_0.Clear();
      }
    }
  }
}
