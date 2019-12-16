// Decompiled with JetBrains decompiler
// Type: WW.OpenGL.Actions.SimpleRectZoomInteractorGLDrawable
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using System.Security;
using WW.Actions;
using WW.Drawing;
using WW.Math.Geometry;

namespace WW.OpenGL.Actions
{
  public class SimpleRectZoomInteractorGLDrawable : InteractorGLDrawable
  {
    private SimpleRectZoomInteractor simpleRectZoomInteractor_0;

    public SimpleRectZoomInteractorGLDrawable(SimpleRectZoomInteractor interactor)
    {
      this.simpleRectZoomInteractor_0 = interactor;
    }

    [SecuritySafeCritical]
    public override void Draw(GraphicsHelper graphicsHelper, InteractionContext context)
    {
      if (!this.simpleRectZoomInteractor_0.IsActive)
        return;
      GL.glDisable(Capability.Lighting);
      ArgbColor rectangleColor = SimpleRectZoomInteractor.RectangleColor;
      GL.glColor3ub(rectangleColor.R, rectangleColor.G, rectangleColor.B);
      Rectangle2D zoomRectangle = this.simpleRectZoomInteractor_0.ZoomRectangle;
      GL.glBegin(Mode.LineLoop);
      GL.glVertex2d(zoomRectangle.X1, zoomRectangle.Y1);
      GL.glVertex2d(zoomRectangle.X1 + zoomRectangle.Width, zoomRectangle.Y1);
      GL.glVertex2d(zoomRectangle.X1 + zoomRectangle.Width, zoomRectangle.Y1 + zoomRectangle.Height);
      GL.glVertex2d(zoomRectangle.X1, zoomRectangle.Y1 + zoomRectangle.Height);
      GL.glEnd();
    }
  }
}
