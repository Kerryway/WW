// Decompiled with JetBrains decompiler
// Type: WW.Cad.Actions.DxfLwPolylineCreator
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
  public class DxfLwPolylineCreator : WW.Actions.Interactor
  {
    private DxfLwPolyline dxfLwPolyline_0 = new DxfLwPolyline();
    private DxfModel dxfModel_0;
    private DxfLayout dxfLayout_0;
    private WW.Cad.Drawing.Node node_0;
    private double double_0;

    public event EventHandler Changed;

    public DxfLwPolylineCreator(DxfModel model, double nodeSize)
    {
      this.dxfModel_0 = model;
      this.double_0 = nodeSize;
    }

    public DxfLwPolylineCreator(DxfModel model, DxfLayout layout, double nodeSize)
    {
      this.dxfModel_0 = model;
      this.dxfLayout_0 = layout;
      this.double_0 = nodeSize;
    }

    public DxfEntity Entity
    {
      get
      {
        return (DxfEntity) this.dxfLwPolyline_0;
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
      if (this.dxfLwPolyline_0.Vertices.Count > 1)
        this.dxfLwPolyline_0.Vertices[this.dxfLwPolyline_0.Vertices.Count - 1].Position = context.InverseProjectionTransform.TransformTo2D(e.Position);
      this.OnChanged((EventArgs) null);
      return this.IsActive;
    }

    public override bool ProcessMouseButtonUp(CanonicalMouseEventArgs e, InteractionContext context)
    {
      bool isActive = this.IsActive;
      if (this.IsActive)
      {
        WW.Math.Point2D position = e.Position;
        WW.Math.Point2D vertex = context.InverseProjectionTransform.TransformTo2D(position);
        if (this.dxfLwPolyline_0.Vertices.Count > 0 && WW.Math.Point2D.AreApproxEqual(context.ProjectionTransform.TransformTo2D(this.dxfLwPolyline_0.Vertices[0].Position), position, this.double_0))
        {
          this.dxfLwPolyline_0.Closed = true;
          this.Deactivate();
        }
        if (this.IsActive)
        {
          this.dxfLwPolyline_0.Vertices.Add(vertex);
          if (e.LeftButtonDown)
          {
            if (this.dxfLwPolyline_0.Vertices.Count == 1)
            {
              this.node_0 = new WW.Cad.Drawing.Node((WW.Math.Point3D) vertex);
              this.dxfLwPolyline_0.Vertices.Add(vertex);
            }
            this.OnChanged((EventArgs) null);
          }
          else if (e.RightButtonDown)
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
      private readonly DxfLwPolylineCreator dxfLwPolylineCreator_0;
      private readonly GDIGraphics3D gdigraphics3D_0;

      public event EventHandler RepaintRequested;

      public WinFormsDrawable(DxfLwPolylineCreator interactor, GDIGraphics3D graphics)
      {
        this.dxfLwPolylineCreator_0 = interactor;
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
        this.gdigraphics3D_0.CreateDrawables(this.dxfLwPolylineCreator_0.dxfModel_0, this.dxfLwPolylineCreator_0.dxfLayout_0, (IList<DxfEntity>) new DxfEntity[1]
        {
          (DxfEntity) this.dxfLwPolylineCreator_0.dxfLwPolyline_0
        }, Matrix4D.Identity);
        if (this.dxfLwPolylineCreator_0.node_0 != null)
          this.gdigraphics3D_0.Nodes.Add(this.dxfLwPolylineCreator_0.node_0);
        this.OnRepaintRequested((EventArgs) null);
      }

      private void method_0(object sender, EventArgs e)
      {
        this.UpdateDrawables();
      }

      private void method_1(object sender, EventArgs e)
      {
        this.dxfLwPolylineCreator_0.Changed -= new EventHandler(this.method_0);
        this.gdigraphics3D_0.Clear();
      }
    }
  }
}
