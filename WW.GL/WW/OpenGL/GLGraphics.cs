// Decompiled with JetBrains decompiler
// Type: WW.OpenGL.GLGraphics
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using System;
using System.Collections.Generic;
using System.Security;
using WW.Math;
using WW.OpenGL.Win;

namespace WW.OpenGL
{
  [SecuritySafeCritical]
  public class GLGraphics : IDisposable
  {
    private int int_0 = 2;
    private RenderingContext renderingContext_0;
    private bool bool_0;
    private Vector2D[] vector2D_0;

    public event EventHandler DrawScene;

    public event EventHandler BeforeDrawScene;

    public event EventHandler AfterDrawScene;

    public GLGraphics()
    {
    }

    public GLGraphics(RenderingContext renderingContext)
      : this()
    {
      this.Initialize(renderingContext);
    }

    ~GLGraphics()
    {
      this.Dispose();
    }

    public RenderingContext RenderingContext
    {
      get
      {
        return this.renderingContext_0;
      }
    }

    public bool AntiAliasingEnabled
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public int AntiAliasingDegree
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
        double num1 = 2.0 / (double) this.int_0;
        double num2 = num1 / 2.0;
        List<Vector2D> vector2DList = new List<Vector2D>();
        for (int index1 = 0; index1 < this.int_0; ++index1)
        {
          for (int index2 = 0; index2 < this.int_0; ++index2)
          {
            Vector2D vector2D = new Vector2D(num2 - 1.0 + num1 * (double) index1, num2 - 1.0 + num1 * (double) index2);
            vector2DList.Add(vector2D);
          }
        }
        this.vector2D_0 = vector2DList.ToArray();
      }
    }

    public Vector2D[] AntiAliasJitterVectors
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

    public void Initialize(RenderingContext renderingContext)
    {
      this.renderingContext_0 = renderingContext;
      renderingContext.MakeCurrent();
    }

    public void Paint(int width, int height)
    {
      if (this.renderingContext_0 == null)
        return;
      this.Paint(this.renderingContext_0, width, height);
    }

    public void Paint(RenderingContext renderingContext, int width, int height)
    {
      if (renderingContext == null)
        return;
      renderingContext.MakeCurrent();
      if (this.bool_0)
      {
        GL.glMatrixMode(MatrixMode.Projection);
        GL.glClear(ClearBufferFlags.AccumBuffer);
        int length = this.vector2D_0.Length;
        Matrix4D parameters;
        GL.glGetDoublev_1(GetTarget.ProjectionMatrix, out parameters);
        for (int index = 0; index < length; ++index)
        {
          GL.glClear(ClearBufferFlags.ColorBuffer | ClearBufferFlags.DepthBuffer);
          Vector2D vector2D = this.vector2D_0[index];
          Matrix4D m = Transformation4D.Translation(vector2D.X / (double) width, vector2D.Y / (double) height, 0.0) * parameters;
          GL.glLoadMatrixd_1(ref m);
          this.DrawSceneHelper();
          GL.glAccum(index > 0 ? AccumulationOperation.Accumulate : AccumulationOperation.Load, 1f / (float) length);
          GL.glAccum(AccumulationOperation.Return, 1f);
        }
        GL.glLoadMatrixd_1(ref parameters);
      }
      else
      {
        GL.glClear(ClearBufferFlags.ColorBuffer | ClearBufferFlags.DepthBuffer);
        this.DrawSceneHelper();
      }
      GL.glFlush();
      WGL.wglSwapBuffers(renderingContext.HDC);
    }

    public void Resize(int width, int height)
    {
      if (this.renderingContext_0 == null || width == 0 || height == 0)
        return;
      this.renderingContext_0.MakeCurrent();
      GL.glViewport(0, 0, width, height);
    }

    public virtual void DrawSceneHelper()
    {
      this.OnBeforeDrawScene((EventArgs) null);
      this.OnDrawScene((EventArgs) null);
      this.OnAfterDrawScene((EventArgs) null);
    }

    protected virtual void OnDrawScene(EventArgs e)
    {
      if (this.DrawScene == null)
        return;
      this.DrawScene((object) this, e);
    }

    protected virtual void OnBeforeDrawScene(EventArgs e)
    {
      if (this.BeforeDrawScene == null)
        return;
      this.BeforeDrawScene((object) this, e);
    }

    protected virtual void OnAfterDrawScene(EventArgs e)
    {
      if (this.AfterDrawScene == null)
        return;
      this.AfterDrawScene((object) this, e);
    }

    public virtual void Dispose()
    {
      if (this.renderingContext_0 == null)
        return;
      this.renderingContext_0.Dispose();
      this.renderingContext_0 = (RenderingContext) null;
    }
  }
}
