// Decompiled with JetBrains decompiler
// Type: WW.Windows.Forms.ViewControl
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.ComponentModel;
using System.Windows.Forms;
using WW.Actions;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Windows.Forms
{
  public class ViewControl : UserControl
  {
    private IContainer icontainer_0;
    private Matrix4D matrix4D_0;
    private System.Drawing.Point point_0;
    private bool bool_0;
    private bool bool_1;
    private SimpleTransformationProviderBase simpleTransformationProviderBase_0;
    private SimplePanInteractor simplePanInteractor_0;
    private SimpleRotateInteractor simpleRotateInteractor_0;
    private SimpleRectZoomInteractor simpleRectZoomInteractor_0;
    private SimpleZoomWheelInteractor simpleZoomWheelInteractor_0;
    private IInteractor iinteractor_0;
    private IInteractorWinFormsDrawable iinteractorWinFormsDrawable_0;
    private IInteractorWinFormsDrawable iinteractorWinFormsDrawable_1;
    private IInteractorWinFormsDrawable iinteractorWinFormsDrawable_2;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void method_0()
    {
      this.icontainer_0 = (IContainer) new Container();
      this.AutoScaleMode = AutoScaleMode.Font;
    }

    public ViewControl()
      : this((SimpleTransformationProviderBase) new SimpleTransformationProvider3D())
    {
    }

    public ViewControl(
      SimpleTransformationProviderBase transformationProvider)
    {
      this.method_0();
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetTransformationProvider(transformationProvider);
    }

    public void SetTransformationProvider(
      SimpleTransformationProviderBase transformationProvider)
    {
      if (this.simpleTransformationProviderBase_0 != null)
        this.simpleTransformationProviderBase_0.TransformsChanged -= new EventHandler(this.method_3);
      this.simpleTransformationProviderBase_0 = transformationProvider;
      transformationProvider.TransformsChanged += new EventHandler(this.method_3);
      this.simplePanInteractor_0 = new SimplePanInteractor(transformationProvider);
      this.simpleRotateInteractor_0 = new SimpleRotateInteractor(transformationProvider);
      this.simpleRectZoomInteractor_0 = new SimpleRectZoomInteractor(transformationProvider);
      this.simpleZoomWheelInteractor_0 = new SimpleZoomWheelInteractor(transformationProvider);
      this.iinteractorWinFormsDrawable_0 = (IInteractorWinFormsDrawable) new SimpleRectZoomInteractor.WinFormsDrawable(this.simpleRectZoomInteractor_0);
      this.iinteractorWinFormsDrawable_1 = (IInteractorWinFormsDrawable) new SimpleRotateInteractor.WinFormsDrawable(this.simpleRotateInteractor_0);
    }

    public Matrix4D From2DTransform
    {
      get
      {
        return this.matrix4D_0;
      }
    }

    public SimpleTransformationProviderBase TransformationProvider
    {
      get
      {
        return this.simpleTransformationProviderBase_0;
      }
    }

    public SimplePanInteractor PanInteractor
    {
      get
      {
        return this.simplePanInteractor_0;
      }
      set
      {
        this.simplePanInteractor_0 = value;
      }
    }

    public SimpleRotateInteractor RotateInteractor
    {
      get
      {
        return this.simpleRotateInteractor_0;
      }
    }

    public SimpleRectZoomInteractor RectZoomInteractor
    {
      get
      {
        return this.simpleRectZoomInteractor_0;
      }
      set
      {
        this.simpleRectZoomInteractor_0 = value;
      }
    }

    public SimpleZoomWheelInteractor ZoomWheelInteractor
    {
      get
      {
        return this.simpleZoomWheelInteractor_0;
      }
      set
      {
        this.simpleZoomWheelInteractor_0 = value;
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (this.iinteractorWinFormsDrawable_2 == null)
        return;
      this.iinteractorWinFormsDrawable_2.Draw(e, new GraphicsHelper(), this.method_4());
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      if (this.simpleTransformationProviderBase_0 == null)
        return;
      this.method_1();
      this.Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      this.point_0 = e.Location;
      this.bool_0 = true;
      this.bool_1 = Control.ModifierKeys == Keys.Shift;
      if (this.bool_1)
      {
        this.iinteractor_0 = (IInteractor) this.simpleRectZoomInteractor_0;
        this.iinteractorWinFormsDrawable_2 = this.iinteractorWinFormsDrawable_0;
      }
      else if (e.Button == MouseButtons.Middle)
      {
        this.iinteractor_0 = (IInteractor) this.simplePanInteractor_0;
      }
      else
      {
        this.iinteractor_0 = (IInteractor) this.simpleRotateInteractor_0;
        this.iinteractorWinFormsDrawable_2 = this.iinteractorWinFormsDrawable_1;
      }
      this.iinteractor_0.Activate();
      this.iinteractor_0.ProcessMouseButtonDown(new CanonicalMouseEventArgs(e), this.method_4());
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      if (this.iinteractor_0 == null)
        return;
      this.iinteractor_0.ProcessMouseMove(new CanonicalMouseEventArgs(e), this.method_4());
      this.Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      this.bool_0 = false;
      if (this.iinteractor_0 != null)
      {
        this.iinteractor_0.ProcessMouseButtonUp(new CanonicalMouseEventArgs(e), this.method_4());
        this.iinteractor_0.Deactivate();
        this.Invalidate();
        this.iinteractor_0 = (IInteractor) null;
      }
      this.iinteractorWinFormsDrawable_2 = (IInteractorWinFormsDrawable) null;
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
      base.OnMouseWheel(e);
      this.simpleZoomWheelInteractor_0.Activate();
      this.simpleZoomWheelInteractor_0.ProcessMouseWheel(new CanonicalMouseEventArgs(e), this.method_4());
      this.simpleZoomWheelInteractor_0.Deactivate();
      this.Invalidate();
    }

    private Matrix4D method_1()
    {
      this.simpleTransformationProviderBase_0.ViewWindow = this.method_2();
      Matrix4D completeTransform = this.simpleTransformationProviderBase_0.CompleteTransform;
      this.matrix4D_0 = completeTransform.GetInverse();
      return completeTransform;
    }

    private Rectangle2D method_2()
    {
      return new Rectangle2D((double) this.ClientRectangle.Left, (double) this.ClientRectangle.Top, (double) this.ClientRectangle.Right, (double) this.ClientRectangle.Bottom);
    }

    private void method_3(object sender, EventArgs e)
    {
      this.method_1();
      this.Invalidate();
    }

    private InteractionContext method_4()
    {
      return new InteractionContext(new Rectangle2D((double) this.ClientRectangle.Left, (double) this.ClientRectangle.Top, (double) this.ClientRectangle.Right, (double) this.ClientRectangle.Bottom), this.simpleTransformationProviderBase_0.CompleteTransform, true, (ArgbColor) this.BackColor);
    }
  }
}
