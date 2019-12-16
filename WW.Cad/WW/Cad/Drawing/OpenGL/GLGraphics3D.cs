// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.OpenGL.GLGraphics3D
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns38;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using WW.Cad.Base;
using WW.Cad.Drawing.Surface;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;
using WW.OpenGL;

namespace WW.Cad.Drawing.OpenGL
{
  public class GLGraphics3D : GLGraphics, IDisposable, ISurfaceGraphicsFactory
  {
    private bool bool_0 = true;
    private GraphicsConfig graphicsConfig_0 = new GraphicsConfig();
    private CharTriangulationCache charTriangulationCache_0 = new CharTriangulationCache();
    private Dictionary<byte[], GLGraphics3D.Class569> dictionary_0 = new Dictionary<byte[], GLGraphics3D.Class569>();
    private List<GLGraphics3D.Class577> list_0 = new List<GLGraphics3D.Class577>();
    private DisplayList displayList_0;
    private GLGraphics3D.Class577 class577_0;
    private bool bool_1;
    private bool bool_2;
    private ArgbColor argbColor_0;
    private bool bool_3;
    private ArgbColor argbColor_1;

    public GLGraphics3D()
    {
      this.AntiAliasingDegree = 4;
      this.method_2();
    }

    public GLGraphics3D(RenderingContext renderingContext)
      : this()
    {
      this.method_2();
      this.Initialize(renderingContext);
    }

    public GraphicsConfig GraphicsConfig
    {
      get
      {
        return this.graphicsConfig_0;
      }
      set
      {
        this.graphicsConfig_0 = value;
      }
    }

    public bool LightEnabled
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

    public bool LightEnabledForLines
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public CharTriangulationCache CharTriangulationCache
    {
      get
      {
        return this.charTriangulationCache_0;
      }
      set
      {
        this.charTriangulationCache_0 = value;
      }
    }

    public void BeginDrawableCreation(bool clearOldDrawables)
    {
      this.RenderingContext.MakeCurrent();
      if (clearOldDrawables || this.displayList_0 == null)
      {
        this.ClearDrawables();
        this.displayList_0 = new DisplayList();
      }
      this.method_0();
    }

    private void method_0()
    {
      this.bool_2 = this.graphicsConfig_0.CorrectColorForBackgroundColor;
      this.argbColor_0 = this.graphicsConfig_0.BackColor;
      this.bool_3 = this.graphicsConfig_0.FixedForegroundColor.HasValue;
      if (this.bool_3)
        this.argbColor_1 = this.graphicsConfig_0.FixedForegroundColor.Value;
      if (this.bool_0)
        GL.Enable(Capability.Lighting);
      else
        GL.Disable(Capability.Lighting);
    }

    public void EndDrawableCreation()
    {
      this.displayList_0.EndList();
    }

    public void CreateDrawables(DxfModel model, Matrix4D modelTransform)
    {
      this.CreateDrawables(model, modelTransform, true);
    }

    public void CreateDrawables(DxfModel model, Matrix4D modelTransform, bool clearOldDrawables)
    {
      DrawContext.Surface context = this.method_3(model, modelTransform, clearOldDrawables);
      model.Draw(context, (ISurfaceGraphicsFactory) this);
    }

    public void CreateDrawables(DxfModel model, IList<DxfEntity> entities, Matrix4D modelTransform)
    {
      DrawContext.Surface context = this.method_3(model, modelTransform, false);
      foreach (DxfEntity entity in (IEnumerable<DxfEntity>) entities)
        entity.Draw(context, (ISurfaceGraphicsFactory) this);
    }

    internal void CreateDrawables(IGraphicElementBlock graphicElementBlock)
    {
      this.method_0();
      GLGraphics3D.Class576 class576 = new GLGraphics3D.Class576(graphicElementBlock);
      GLGraphics3D.Class570 converter = new GLGraphics3D.Class570(this);
      class576.method_0(converter);
      this.displayList_0 = class576.DisplayList;
      this.class577_0 = (GLGraphics3D.Class577) null;
    }

    public void CreateDrawables(ProcessedGraphicElementBlock graphicElementBlock)
    {
      this.method_5();
      this.method_0();
      this.class577_0 = new GLGraphics3D.Class577(graphicElementBlock);
      this.class577_0.method_0(new GLGraphics3D.Class570(this));
      if (this.displayList_0 != null)
        this.displayList_0.Delete();
      this.displayList_0 = new DisplayList();
      GL.Enable(Capability.Normalize);
      GL.MatrixMode(MatrixMode.ModelView);
      this.class577_0.Draw(Matrix4D.Identity, Matrix4D.Identity);
      this.displayList_0.EndList();
    }

    public void ClearDrawables()
    {
      if (this.RenderingContext == null)
        return;
      this.RenderingContext.MakeCurrent();
      if (this.displayList_0 == null)
        return;
      this.displayList_0.Delete();
      this.displayList_0 = (DisplayList) null;
      this.class577_0 = (GLGraphics3D.Class577) null;
    }

    protected override void OnDrawScene(EventArgs e)
    {
      base.OnDrawScene(e);
      if (this.displayList_0 == null)
        return;
      GL.MatrixMode(MatrixMode.ModelView);
      this.displayList_0.Draw();
    }

    public override void Dispose()
    {
      this.method_5();
      base.Dispose();
    }

    private void method_1(Matrix4D m)
    {
      GL.LoadMatrixd(new double[16]
      {
        m.M00,
        m.M10,
        m.M20,
        m.M30,
        m.M01,
        m.M11,
        m.M21,
        m.M31,
        m.M02,
        m.M12,
        m.M22,
        m.M32,
        m.M03,
        m.M13,
        m.M23,
        m.M33
      });
    }

    public void BeginNode(DxfEntity entity, DrawContext.Surface drawContext)
    {
    }

    public void EndNode()
    {
    }

    public void SetColor(ArgbColor color)
    {
      if (this.bool_3)
        GL.Color4ub(this.argbColor_1.R, this.argbColor_1.G, this.argbColor_1.B, this.argbColor_1.A);
      else if (this.bool_2 && color == this.argbColor_0)
        GL.Color4ub((byte) ((uint) byte.MaxValue - (uint) color.R), (byte) ((uint) byte.MaxValue - (uint) color.G), (byte) ((uint) byte.MaxValue - (uint) color.B), color.A);
      else
        GL.Color4ub(color.R, color.G, color.B, color.A);
    }

    public void CreatePoint(Vector4D point)
    {
      GL.Begin(Mode.Points);
      GL.Vertex4f((float) point.X, (float) point.Y, (float) point.Z, (float) point.W);
      GL.End();
    }

    public void CreateSegment(Vector4D start, Vector4D end)
    {
      if (this.bool_0 && !this.bool_1)
        GL.Disable(Capability.Lighting);
      GL.Begin(Mode.Lines);
      GL.Vertex4f((float) start.X, (float) start.Y, (float) start.Z, (float) start.W);
      GL.Vertex4f((float) end.X, (float) end.Y, (float) end.Z, (float) end.W);
      GL.End();
      if (!this.bool_0 || this.bool_1)
        return;
      GL.Enable(Capability.Lighting);
    }

    public void CreatePolyline(IList<Vector4D> polyline, bool closed)
    {
      if (this.bool_0 && !this.bool_1)
        GL.Disable(Capability.Lighting);
      if (closed)
        GL.Begin(Mode.LineLoop);
      else
        GL.Begin(Mode.LineStrip);
      for (int index = 0; index < polyline.Count; ++index)
      {
        Vector4D vector4D = polyline[index];
        GL.Vertex4f((float) vector4D.X, (float) vector4D.Y, (float) vector4D.Z, (float) vector4D.W);
      }
      GL.End();
      if (!this.bool_0 || this.bool_1)
        return;
      GL.Enable(Capability.Lighting);
    }

    public void CreateTriangle(Vector4D v0, Vector4D v1, Vector4D v2, IList<bool> edgeVisible)
    {
      GL.Begin(Mode.Triangles);
      Vector3D unit = Vector3D.CrossProduct((Vector3D) (v1 - v0), (Vector3D) (v2 - v0)).GetUnit();
      GL.Normal3f((float) unit.X, (float) unit.Y, (float) unit.Z);
      if (edgeVisible != null)
        GL.EdgeFlag(edgeVisible[0]);
      GL.Vertex4f((float) v0.X, (float) v0.Y, (float) v0.Z, (float) v0.W);
      if (edgeVisible != null)
        GL.EdgeFlag(edgeVisible[1]);
      GL.Vertex4f((float) v1.X, (float) v1.Y, (float) v1.Z, (float) v1.W);
      if (edgeVisible != null)
        GL.EdgeFlag(edgeVisible[2]);
      GL.Vertex4f((float) v2.X, (float) v2.Y, (float) v2.Z, (float) v2.W);
      GL.End();
    }

    public void CreateQuad(IList<Vector4D> polygon, IList<bool> edgeVisible)
    {
      Vector4D vector4D1 = polygon[0];
      Vector4D vector4D2 = polygon[1];
      Vector4D vector4D3 = polygon[2];
      Vector4D vector4D4 = polygon[3];
      if (vector4D1 == vector4D2)
      {
        Vector3D unit = Vector3D.CrossProduct((Vector3D) (vector4D3 - vector4D1), (Vector3D) (vector4D4 - vector4D1)).GetUnit();
        GL.Begin(Mode.Triangles);
        GL.Normal3f((float) unit.X, (float) unit.Y, (float) unit.Z);
        if (edgeVisible != null)
          GL.EdgeFlag(edgeVisible[1]);
        GL.Vertex4f((float) vector4D2.X, (float) vector4D2.Y, (float) vector4D2.Z, (float) vector4D2.W);
        if (edgeVisible != null)
          GL.EdgeFlag(edgeVisible[2]);
        GL.Vertex4f((float) vector4D3.X, (float) vector4D3.Y, (float) vector4D3.Z, (float) vector4D3.W);
        if (edgeVisible != null)
          GL.EdgeFlag(edgeVisible[3]);
        GL.Vertex4f((float) vector4D4.X, (float) vector4D4.Y, (float) vector4D4.Z, (float) vector4D4.W);
        GL.End();
      }
      else if (vector4D2 == vector4D3)
      {
        Vector3D unit = Vector3D.CrossProduct((Vector3D) (vector4D2 - vector4D1), (Vector3D) (vector4D4 - vector4D1)).GetUnit();
        GL.Begin(Mode.Triangles);
        GL.Normal3f((float) unit.X, (float) unit.Y, (float) unit.Z);
        if (edgeVisible != null)
          GL.EdgeFlag(edgeVisible[0]);
        GL.Vertex4f((float) vector4D1.X, (float) vector4D1.Y, (float) vector4D1.Z, (float) vector4D1.W);
        if (edgeVisible != null)
          GL.EdgeFlag(edgeVisible[2]);
        GL.Vertex4f((float) vector4D3.X, (float) vector4D3.Y, (float) vector4D3.Z, (float) vector4D3.W);
        if (edgeVisible != null)
          GL.EdgeFlag(edgeVisible[3]);
        GL.Vertex4f((float) vector4D4.X, (float) vector4D4.Y, (float) vector4D4.Z, (float) vector4D4.W);
        GL.End();
      }
      else if (vector4D1 == vector4D3)
      {
        Vector3D unit = Vector3D.CrossProduct((Vector3D) (vector4D2 - vector4D1), (Vector3D) (vector4D4 - vector4D1)).GetUnit();
        GL.Begin(Mode.Triangles);
        GL.Normal3f((float) unit.X, (float) unit.Y, (float) unit.Z);
        if (edgeVisible != null)
          GL.EdgeFlag(edgeVisible[0]);
        GL.Vertex4f((float) vector4D1.X, (float) vector4D1.Y, (float) vector4D1.Z, (float) vector4D1.W);
        if (edgeVisible != null)
          GL.EdgeFlag(edgeVisible[1]);
        GL.Vertex4f((float) vector4D2.X, (float) vector4D2.Y, (float) vector4D2.Z, (float) vector4D2.W);
        if (edgeVisible != null)
          GL.EdgeFlag(edgeVisible[3]);
        GL.Vertex4f((float) vector4D4.X, (float) vector4D4.Y, (float) vector4D4.Z, (float) vector4D4.W);
        GL.End();
      }
      else
      {
        Vector3D unit = Vector3D.CrossProduct((Vector3D) (vector4D2 - vector4D1), (Vector3D) (vector4D3 - vector4D1)).GetUnit();
        GL.Begin(Mode.Quads);
        GL.Normal3f((float) unit.X, (float) unit.Y, (float) unit.Z);
        for (int index = 0; index < polygon.Count; ++index)
        {
          Vector4D vector4D5 = polygon[index];
          if (edgeVisible != null)
            GL.EdgeFlag(edgeVisible[index]);
          GL.Vertex4f((float) vector4D5.X, (float) vector4D5.Y, (float) vector4D5.Z, (float) vector4D5.W);
        }
        GL.End();
      }
    }

    public void CreateQuadStrip(
      IList<Vector4D> polygon1,
      IList<Vector4D> polygon2,
      Vector3D normal,
      bool close)
    {
      GL.Begin(Mode.QuadStrip);
      GL.Normal3f((float) normal.X, (float) normal.Y, (float) normal.Z);
      for (int index = 0; index < polygon1.Count; ++index)
      {
        Vector4D vector4D1 = polygon1[index];
        GL.Vertex4f((float) vector4D1.X, (float) vector4D1.Y, (float) vector4D1.Z, (float) vector4D1.W);
        Vector4D vector4D2 = polygon2[index];
        GL.Vertex4f((float) vector4D2.X, (float) vector4D2.Y, (float) vector4D2.Z, (float) vector4D2.W);
      }
      if (close)
      {
        Vector4D vector4D1 = polygon1[0];
        GL.Vertex4f((float) vector4D1.X, (float) vector4D1.Y, (float) vector4D1.Z, (float) vector4D1.W);
        Vector4D vector4D2 = polygon2[0];
        GL.Vertex4f((float) vector4D2.X, (float) vector4D2.Y, (float) vector4D2.Z, (float) vector4D2.W);
      }
      GL.End();
    }

    public void CreateQuadStrip(
      IList<Vector4D> polyline1,
      IList<Vector4D> polyline2,
      IList<Vector3D> normals,
      int startVertexIndex,
      int endVertexIndex)
    {
      int count = polyline1.Count;
      GL.Begin(Mode.QuadStrip);
      if (endVertexIndex <= startVertexIndex)
      {
        int index1 = startVertexIndex;
        int index2 = 0;
        while (index1 < count)
        {
          Vector3D normal = normals[index2];
          GL.Normal3f((float) normal.X, (float) normal.Y, (float) normal.Z);
          Vector4D vector4D1 = polyline1[index1];
          GL.Vertex4f((float) vector4D1.X, (float) vector4D1.Y, (float) vector4D1.Z, (float) vector4D1.W);
          Vector4D vector4D2 = polyline2[index1];
          GL.Vertex4f((float) vector4D2.X, (float) vector4D2.Y, (float) vector4D2.Z, (float) vector4D2.W);
          ++index1;
          ++index2;
        }
        int index3 = 0;
        while (index3 <= endVertexIndex)
        {
          Vector3D normal = normals[index2];
          GL.Normal3f((float) normal.X, (float) normal.Y, (float) normal.Z);
          Vector4D vector4D1 = polyline1[index3];
          GL.Vertex4f((float) vector4D1.X, (float) vector4D1.Y, (float) vector4D1.Z, (float) vector4D1.W);
          Vector4D vector4D2 = polyline2[index3];
          GL.Vertex4f((float) vector4D2.X, (float) vector4D2.Y, (float) vector4D2.Z, (float) vector4D2.W);
          ++index3;
          ++index2;
        }
      }
      else
      {
        int index1 = startVertexIndex;
        int index2 = 0;
        while (index1 <= endVertexIndex)
        {
          Vector3D normal = normals[index2];
          GL.Normal3f((float) normal.X, (float) normal.Y, (float) normal.Z);
          Vector4D vector4D1 = polyline1[index1];
          GL.Vertex4f((float) vector4D1.X, (float) vector4D1.Y, (float) vector4D1.Z, (float) vector4D1.W);
          Vector4D vector4D2 = polyline2[index1];
          GL.Vertex4f((float) vector4D2.X, (float) vector4D2.Y, (float) vector4D2.Z, (float) vector4D2.W);
          ++index1;
          ++index2;
        }
      }
      GL.End();
    }

    public void CreatePolygonMesh(
      Vector4D[,] polygonMesh,
      bool closedInMDirection,
      bool closedInNDirection)
    {
      double[] numArray1 = new double[polygonMesh.Length * 4];
      int length1 = polygonMesh.GetLength(0);
      int length2 = polygonMesh.GetLength(1);
      int num1 = 0;
      for (int index1 = 0; index1 < length1; ++index1)
      {
        for (int index2 = 0; index2 < length2; ++index2)
        {
          Vector4D vector4D = polygonMesh[index1, index2];
          double[] numArray2 = numArray1;
          int index3 = num1;
          int num2 = index3 + 1;
          double x = vector4D.X;
          numArray2[index3] = x;
          double[] numArray3 = numArray1;
          int index4 = num2;
          int num3 = index4 + 1;
          double y = vector4D.Y;
          numArray3[index4] = y;
          double[] numArray4 = numArray1;
          int index5 = num3;
          int num4 = index5 + 1;
          double z = vector4D.Z;
          numArray4[index5] = z;
          double[] numArray5 = numArray1;
          int index6 = num4;
          num1 = index6 + 1;
          double w = vector4D.W;
          numArray5[index6] = w;
        }
      }
      int num5 = length1 - 1;
      if (closedInMDirection)
        ++num5;
      int num6 = length2 - 1;
      if (closedInNDirection)
        ++num6;
      uint[] numArray6 = new uint[num5 * num6 * 16];
      int num7 = 0;
      for (int index1 = 0; index1 < num5; ++index1)
      {
        for (int index2 = 0; index2 < num6; ++index2)
        {
          uint num2 = (uint) ((index1 % length1 * length2 + index2 % length2) * 4);
          uint[] numArray2 = numArray6;
          int index3 = num7;
          int num3 = index3 + 1;
          int num4 = (int) num2;
          uint num8 = (uint) (num4 + 1);
          numArray2[index3] = (uint) num4;
          uint[] numArray3 = numArray6;
          int index4 = num3;
          int num9 = index4 + 1;
          int num10 = (int) num8;
          uint num11 = (uint) (num10 + 1);
          numArray3[index4] = (uint) num10;
          uint[] numArray4 = numArray6;
          int index5 = num9;
          int num12 = index5 + 1;
          int num13 = (int) num11;
          uint num14 = (uint) (num13 + 1);
          numArray4[index5] = (uint) num13;
          uint[] numArray5 = numArray6;
          int index6 = num12;
          int num15 = index6 + 1;
          int num16 = (int) num14;
          numArray5[index6] = (uint) num16;
          uint num17 = (uint) (((index1 + 1) % length1 * length2 + index2 % length2) * 4);
          uint[] numArray7 = numArray6;
          int index7 = num15;
          int num18 = index7 + 1;
          int num19 = (int) num17;
          uint num20 = (uint) (num19 + 1);
          numArray7[index7] = (uint) num19;
          uint[] numArray8 = numArray6;
          int index8 = num18;
          int num21 = index8 + 1;
          int num22 = (int) num20;
          uint num23 = (uint) (num22 + 1);
          numArray8[index8] = (uint) num22;
          uint[] numArray9 = numArray6;
          int index9 = num21;
          int num24 = index9 + 1;
          int num25 = (int) num23;
          uint num26 = (uint) (num25 + 1);
          numArray9[index9] = (uint) num25;
          uint[] numArray10 = numArray6;
          int index10 = num24;
          int num27 = index10 + 1;
          int num28 = (int) num26;
          numArray10[index10] = (uint) num28;
          uint num29 = (uint) (((index1 + 1) % length1 * length2 + (index2 + 1) % length2) * 4);
          uint[] numArray11 = numArray6;
          int index11 = num27;
          int num30 = index11 + 1;
          int num31 = (int) num29;
          uint num32 = (uint) (num31 + 1);
          numArray11[index11] = (uint) num31;
          uint[] numArray12 = numArray6;
          int index12 = num30;
          int num33 = index12 + 1;
          int num34 = (int) num32;
          uint num35 = (uint) (num34 + 1);
          numArray12[index12] = (uint) num34;
          uint[] numArray13 = numArray6;
          int index13 = num33;
          int num36 = index13 + 1;
          int num37 = (int) num35;
          uint num38 = (uint) (num37 + 1);
          numArray13[index13] = (uint) num37;
          uint[] numArray14 = numArray6;
          int index14 = num36;
          int num39 = index14 + 1;
          int num40 = (int) num38;
          numArray14[index14] = (uint) num40;
          uint num41 = (uint) ((index1 % length1 * length2 + (index2 + 1) % length2) * 4);
          uint[] numArray15 = numArray6;
          int index15 = num39;
          int num42 = index15 + 1;
          int num43 = (int) num41;
          uint num44 = (uint) (num43 + 1);
          numArray15[index15] = (uint) num43;
          uint[] numArray16 = numArray6;
          int index16 = num42;
          int num45 = index16 + 1;
          int num46 = (int) num44;
          uint num47 = (uint) (num46 + 1);
          numArray16[index16] = (uint) num46;
          uint[] numArray17 = numArray6;
          int index17 = num45;
          int num48 = index17 + 1;
          int num49 = (int) num47;
          uint num50 = (uint) (num49 + 1);
          numArray17[index17] = (uint) num49;
          uint[] numArray18 = numArray6;
          int index18 = num48;
          num7 = index18 + 1;
          int num51 = (int) num50;
          numArray18[index18] = (uint) num51;
          uint num52 = (uint) ((index1 % length1 * length2 + index2 % length2) * 4);
          uint num53 = (uint) (((index1 + 1) % length1 * length2 + index2 % length2) * 4);
          uint num54 = (uint) (((index1 + 1) % length1 * length2 + (index2 + 1) % length2) * 4);
          uint num55 = (uint) ((index1 % length1 * length2 + (index2 + 1) % length2) * 4);
          Vector4D[] vector4DArray = new Vector4D[4];
          ref Vector4D local1 = ref vector4DArray[0];
          double[] numArray19 = numArray1;
          int num56 = (int) num52;
          uint num57 = (uint) (num56 + 1);
          uint num58 = (uint) num56;
          double x1 = numArray19[(IntPtr) num58];
          double[] numArray20 = numArray1;
          int num59 = (int) num57;
          uint num60 = (uint) (num59 + 1);
          uint num61 = (uint) num59;
          double y1 = numArray20[(IntPtr) num61];
          double[] numArray21 = numArray1;
          int num62 = (int) num60;
          uint num63 = (uint) (num62 + 1);
          uint num64 = (uint) num62;
          double z1 = numArray21[(IntPtr) num64];
          double[] numArray22 = numArray1;
          int num65 = (int) num63;
          uint num66 = (uint) (num65 + 1);
          uint num67 = (uint) num65;
          double w1 = numArray22[(IntPtr) num67];
          Vector4D vector4D1 = new Vector4D(x1, y1, z1, w1);
          local1 = vector4D1;
          ref Vector4D local2 = ref vector4DArray[1];
          double[] numArray23 = numArray1;
          int num68 = (int) num53;
          uint num69 = (uint) (num68 + 1);
          uint num70 = (uint) num68;
          double x2 = numArray23[(IntPtr) num70];
          double[] numArray24 = numArray1;
          int num71 = (int) num69;
          uint num72 = (uint) (num71 + 1);
          uint num73 = (uint) num71;
          double y2 = numArray24[(IntPtr) num73];
          double[] numArray25 = numArray1;
          int num74 = (int) num72;
          uint num75 = (uint) (num74 + 1);
          uint num76 = (uint) num74;
          double z2 = numArray25[(IntPtr) num76];
          double[] numArray26 = numArray1;
          int num77 = (int) num75;
          uint num78 = (uint) (num77 + 1);
          uint num79 = (uint) num77;
          double w2 = numArray26[(IntPtr) num79];
          Vector4D vector4D2 = new Vector4D(x2, y2, z2, w2);
          local2 = vector4D2;
          ref Vector4D local3 = ref vector4DArray[2];
          double[] numArray27 = numArray1;
          int num80 = (int) num54;
          uint num81 = (uint) (num80 + 1);
          uint num82 = (uint) num80;
          double x3 = numArray27[(IntPtr) num82];
          double[] numArray28 = numArray1;
          int num83 = (int) num81;
          uint num84 = (uint) (num83 + 1);
          uint num85 = (uint) num83;
          double y3 = numArray28[(IntPtr) num85];
          double[] numArray29 = numArray1;
          int num86 = (int) num84;
          uint num87 = (uint) (num86 + 1);
          uint num88 = (uint) num86;
          double z3 = numArray29[(IntPtr) num88];
          double[] numArray30 = numArray1;
          int num89 = (int) num87;
          uint num90 = (uint) (num89 + 1);
          uint num91 = (uint) num89;
          double w3 = numArray30[(IntPtr) num91];
          Vector4D vector4D3 = new Vector4D(x3, y3, z3, w3);
          local3 = vector4D3;
          ref Vector4D local4 = ref vector4DArray[3];
          double[] numArray31 = numArray1;
          int num92 = (int) num55;
          uint num93 = (uint) (num92 + 1);
          uint num94 = (uint) num92;
          double x4 = numArray31[(IntPtr) num94];
          double[] numArray32 = numArray1;
          int num95 = (int) num93;
          uint num96 = (uint) (num95 + 1);
          uint num97 = (uint) num95;
          double y4 = numArray32[(IntPtr) num97];
          double[] numArray33 = numArray1;
          int num98 = (int) num96;
          uint num99 = (uint) (num98 + 1);
          uint num100 = (uint) num98;
          double z4 = numArray33[(IntPtr) num100];
          double[] numArray34 = numArray1;
          int num101 = (int) num99;
          uint num102 = (uint) (num101 + 1);
          uint num103 = (uint) num101;
          double w4 = numArray34[(IntPtr) num103];
          Vector4D vector4D4 = new Vector4D(x4, y4, z4, w4);
          local4 = vector4D4;
          this.CreateQuad((IList<Vector4D>) vector4DArray, (IList<bool>) null);
        }
      }
    }

    public void CreateTexturedTriangles(
      byte[] rgbaBytes,
      int width,
      int height,
      Vector3D normal,
      IList<Triangulator2D.Triangle> triangles,
      IList<WW.Math.Point2D> textureCoordinates,
      IList<Vector4D> points)
    {
      uint num = this.method_4(rgbaBytes, width, height);
      GL.Color3f(1f, 1f, 1f);
      GL.Enable(Capability.Texture2D);
      GL.BindTexture(TextureTarget.Texture2D, num);
      GL.Normal3f((float) normal.X, (float) normal.Y, (float) normal.Z);
      GL.Begin(Mode.Triangles);
      for (int index = triangles.Count - 1; index >= 0; --index)
      {
        Triangulator2D.Triangle triangle = triangles[index];
        WW.Math.Point2D textureCoordinate1 = textureCoordinates[triangle.I2];
        GL.TexCoord2f((float) textureCoordinate1.X, (float) textureCoordinate1.Y);
        Vector4D point1 = points[triangle.I2];
        GL.Vertex4f((float) point1.X, (float) point1.Y, (float) point1.Z, (float) point1.W);
        WW.Math.Point2D textureCoordinate2 = textureCoordinates[triangle.I1];
        GL.TexCoord2f((float) textureCoordinate2.X, (float) textureCoordinate2.Y);
        Vector4D point2 = points[triangle.I1];
        GL.Vertex4f((float) point2.X, (float) point2.Y, (float) point2.Z, (float) point2.W);
        WW.Math.Point2D textureCoordinate3 = textureCoordinates[triangle.I0];
        GL.TexCoord2f((float) textureCoordinate3.X, (float) textureCoordinate3.Y);
        Vector4D point3 = points[triangle.I0];
        GL.Vertex4f((float) point3.X, (float) point3.Y, (float) point3.Z, (float) point3.W);
      }
      GL.End();
      GL.BindTexture(TextureTarget.Texture2D, 0U);
      GL.Disable(Capability.Texture2D);
    }

    private void method_2()
    {
      Class809.smethod_0(Enum15.const_3);
      this.graphicsConfig_0.ShapeFlattenEpsilon = -0.1;
    }

    private DrawContext.Surface method_3(
      DxfModel model,
      Matrix4D modelTransform,
      bool clearOldDrawables)
    {
      this.BeginDrawableCreation(clearOldDrawables);
      return (DrawContext.Surface) new DrawContext.Surface.ModelSpace(model, this.graphicsConfig_0, modelTransform, this.charTriangulationCache_0);
    }

    private uint method_4(byte[] rgbaBytes, int width, int height)
    {
      this.RenderingContext.MakeCurrent();
      GLGraphics3D.Class569 class569;
      if (!this.dictionary_0.TryGetValue(rgbaBytes, out class569))
      {
        uint[] numArray = new uint[1];
        GL.GenTextures(1, numArray);
        uint textureId = numArray[0];
        GL.BindTexture(TextureTarget.Texture2D, textureId);
        GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.WrapS, TextureWrapMode.Repeat);
        GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.WrapT, TextureWrapMode.Repeat);
        GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.MagnificationFilter, TextureMagFilter.Linear);
        GL.TexParameteri(TextureTarget.Texture2D, TextureParameterName.MinificationFilter, TextureMagFilter.Linear);
        class569 = new GLGraphics3D.Class569(textureId, (BitmapData) null);
        this.dictionary_0[rgbaBytes] = class569;
        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelFormatInternal.Rgba, width, height, 0, WW.OpenGL.PixelFormat.Rgba, DataType.UnsignedByte, rgbaBytes);
      }
      return class569.TextureId;
    }

    private void method_5()
    {
      if (this.displayList_0 != null)
      {
        this.displayList_0.Delete();
        this.displayList_0 = (DisplayList) null;
      }
      foreach (GLGraphics3D.Class577 class577 in this.list_0)
        class577.Dispose();
      this.list_0.Clear();
    }

    private static Matrix4D smethod_0(Matrix4D m)
    {
      return new Matrix4D(1.0, 0.0, 0.0, m.M03, 0.0, 1.0, 0.0, m.M13, 0.0, 0.0, 1.0, m.M23, 0.0, 0.0, 0.0, m.M33);
    }

    private class Class569 : IDisposable
    {
      private uint uint_0;
      private BitmapData bitmapData_0;

      public Class569(uint textureId, BitmapData bitmapData)
      {
        this.uint_0 = textureId;
        this.bitmapData_0 = bitmapData;
      }

      public uint TextureId
      {
        get
        {
          return this.uint_0;
        }
      }

      public void Dispose()
      {
        if (this.uint_0 == 0U)
          return;
        GL.DeleteTextures(1, new uint[1]{ this.uint_0 });
        this.uint_0 = 0U;
      }
    }

    private class Class570
    {
      private Dictionary<IGraphicElementBlock, GLGraphics3D.Class576> dictionary_0 = new Dictionary<IGraphicElementBlock, GLGraphics3D.Class576>();
      private Dictionary<ProcessedGraphicElementBlock, GLGraphics3D.Class577> dictionary_1 = new Dictionary<ProcessedGraphicElementBlock, GLGraphics3D.Class577>();
      private GLGraphics3D glgraphics3D_0;
      private IPrimitiveVisitor iprimitiveVisitor_0;
      private GLGraphics3D.Class580 class580_0;

      public Class570(GLGraphics3D context)
      {
        this.glgraphics3D_0 = context;
        this.iprimitiveVisitor_0 = (IPrimitiveVisitor) new GLGraphics3D.Class579(context);
        this.class580_0 = new GLGraphics3D.Class580(context);
      }

      public GLGraphics3D Context
      {
        get
        {
          return this.glgraphics3D_0;
        }
      }

      public GLGraphics3D.Class576 method_0(IGraphicElementBlock graphicElementBlock)
      {
        if (graphicElementBlock == null)
          return (GLGraphics3D.Class576) null;
        GLGraphics3D.Class576 class576;
        if (!this.dictionary_0.TryGetValue(graphicElementBlock, out class576))
        {
          class576 = new GLGraphics3D.Class576(graphicElementBlock);
          this.dictionary_0.Add(graphicElementBlock, class576);
        }
        return class576;
      }

      public GLGraphics3D.Class577 method_1(
        ProcessedGraphicElementBlock graphicElementBlock)
      {
        if (graphicElementBlock == null)
          return (GLGraphics3D.Class577) null;
        GLGraphics3D.Class577 class577;
        if (!this.dictionary_1.TryGetValue(graphicElementBlock, out class577))
        {
          class577 = new GLGraphics3D.Class577(graphicElementBlock);
          this.dictionary_1.Add(graphicElementBlock, class577);
          this.glgraphics3D_0.list_0.Add(class577);
        }
        return class577;
      }

      public IPrimitiveVisitor method_2(WW.Cad.Drawing.Surface.Geometry geometry)
      {
        if (!geometry.HasExtrusion)
          return this.iprimitiveVisitor_0;
        this.class580_0.Extrusion = geometry.Extrusion;
        return (IPrimitiveVisitor) this.class580_0;
      }
    }

    private abstract class Class571
    {
      public abstract bool HasChildren { get; }

      public virtual void vmethod_0(GLGraphics3D.Class570 converter)
      {
      }

      public virtual void Draw(GLGraphics3D.Class570 converter)
      {
      }
    }

    private class Class572 : GLGraphics3D.Class571
    {
      private GraphicElement1 graphicElement1_0;

      public Class572(GraphicElement1 wrappee)
      {
        this.graphicElement1_0 = wrappee;
      }

      public override bool HasChildren
      {
        get
        {
          return false;
        }
      }

      public override void vmethod_0(GLGraphics3D.Class570 converter)
      {
      }

      public override void Draw(GLGraphics3D.Class570 converter)
      {
        converter.Context.SetColor(this.graphicElement1_0.Color);
        IPrimitiveVisitor visitor = converter.method_2(this.graphicElement1_0.Geometry);
        foreach (IPrimitive primitive in (List<IPrimitive>) this.graphicElement1_0.Geometry)
          primitive.Accept(visitor);
      }
    }

    private class Class573 : GLGraphics3D.Class571
    {
      private GraphicElement2 graphicElement2_0;

      public Class573(GraphicElement2 wrappee)
      {
        this.graphicElement2_0 = wrappee;
      }

      public override bool HasChildren
      {
        get
        {
          return false;
        }
      }

      public override void Draw(GLGraphics3D.Class570 converter)
      {
        converter.Context.SetColor(this.graphicElement2_0.Color);
        IPrimitiveVisitor visitor = converter.method_2(this.graphicElement2_0.Geometry);
        foreach (IPrimitive primitive in (List<IPrimitive>) this.graphicElement2_0.Geometry)
          primitive.Accept(visitor);
      }
    }

    private class Class574 : GLGraphics3D.Class571
    {
      private GraphicElementInsert graphicElementInsert_0;
      private GLGraphics3D.Class576 class576_0;
      private GLGraphics3D.Class576 class576_1;

      public Class574(GLGraphics3D.Class570 converter, GraphicElementInsert wrappee)
      {
        this.graphicElementInsert_0 = wrappee;
        this.class576_0 = converter.method_0((IGraphicElementBlock) wrappee.UnclippedBlock);
        this.class576_1 = converter.method_0((IGraphicElementBlock) wrappee.AttributeBlock);
      }

      public override bool HasChildren
      {
        get
        {
          return true;
        }
      }

      public override void vmethod_0(GLGraphics3D.Class570 converter)
      {
        if (this.class576_0 != null)
          this.class576_0.method_0(converter);
        if (this.class576_1 == null)
          return;
        this.class576_1.method_0(converter);
      }

      public override void Draw(GLGraphics3D.Class570 converter)
      {
        if (this.class576_0 != null)
        {
          GraphicElementInsert.InsertCell[,] insertCells = this.graphicElementInsert_0.InsertCells;
          int upperBound1 = insertCells.GetUpperBound(0);
          int upperBound2 = insertCells.GetUpperBound(1);
          for (int lowerBound1 = insertCells.GetLowerBound(0); lowerBound1 <= upperBound1; ++lowerBound1)
          {
            for (int lowerBound2 = insertCells.GetLowerBound(1); lowerBound2 <= upperBound2; ++lowerBound2)
            {
              GraphicElementInsert.InsertCell insertCell = insertCells[lowerBound1, lowerBound2];
              GL.PushMatrix();
              Matrix4D transform = insertCell.Transform;
              GL.MultMatrixd(ref transform);
              this.class576_0.DisplayList.Draw();
              GL.PopMatrix();
            }
          }
        }
        if (this.class576_1 == null)
          return;
        Matrix4D[,] attributeBlockCells = this.graphicElementInsert_0.AttributeBlockCells;
        int upperBound3 = attributeBlockCells.GetUpperBound(0);
        int upperBound4 = attributeBlockCells.GetUpperBound(1);
        for (int lowerBound1 = attributeBlockCells.GetLowerBound(0); lowerBound1 <= upperBound3; ++lowerBound1)
        {
          for (int lowerBound2 = attributeBlockCells.GetLowerBound(1); lowerBound2 <= upperBound4; ++lowerBound2)
          {
            Matrix4D matrix4D1 = attributeBlockCells[lowerBound1, lowerBound2];
            GL.PushMatrix();
            Matrix4D matrix4D2 = matrix4D1;
            GL.MultMatrixd(ref matrix4D2);
            this.class576_1.DisplayList.Draw();
            GL.PopMatrix();
          }
        }
      }
    }

    private class Class576
    {
      private IGraphicElementBlock igraphicElementBlock_0;
      private DisplayList displayList_0;

      public Class576(IGraphicElementBlock wrappee)
      {
        this.igraphicElementBlock_0 = wrappee;
      }

      public DisplayList DisplayList
      {
        get
        {
          return this.displayList_0;
        }
        set
        {
          this.displayList_0 = value;
        }
      }

      public void method_0(GLGraphics3D.Class570 converter)
      {
        if (this.DisplayList != null)
          return;
        List<GLGraphics3D.Class571> wrappers = new List<GLGraphics3D.Class571>();
        GLGraphics3D.Class578 class578 = new GLGraphics3D.Class578(converter, wrappers);
        foreach (IGraphicElement graphicElement in this.igraphicElementBlock_0.GraphicElements)
          graphicElement.Accept((IGraphicElementVisitor) class578);
        foreach (GLGraphics3D.Class571 class571 in wrappers)
          class571.vmethod_0(converter);
        this.DisplayList = new DisplayList();
        GL.PushMatrix();
        Matrix4D transform = this.igraphicElementBlock_0.Transform;
        GL.MultMatrixd(ref transform);
        foreach (GLGraphics3D.Class571 class571 in wrappers)
          class571.Draw(converter);
        GL.PopMatrix();
        this.DisplayList.EndList();
      }
    }

    private class Class575 : GLGraphics3D.Class571
    {
      private ProcessedGraphicElementInsert processedGraphicElementInsert_0;
      private GLGraphics3D.Class577 class577_0;
      private GLGraphics3D.Class577 class577_1;

      public Class575(GLGraphics3D.Class570 converter, ProcessedGraphicElementInsert wrappee)
      {
        this.processedGraphicElementInsert_0 = wrappee;
        this.class577_0 = converter.method_1(wrappee.UnclippedBlock);
        this.class577_1 = converter.method_1(wrappee.AttributeBlock);
      }

      public override bool HasChildren
      {
        get
        {
          return true;
        }
      }

      public override void vmethod_0(GLGraphics3D.Class570 converter)
      {
        if (this.class577_0 != null)
          this.class577_0.method_0(converter);
        if (this.class577_1 == null)
          return;
        this.class577_1.method_0(converter);
      }

      public void Draw(Matrix4D rootModelViewTransform)
      {
        if (this.class577_0 != null)
        {
          ProcessedGraphicElementInsert.InsertCell[,] insertCells = this.processedGraphicElementInsert_0.InsertCells;
          int upperBound1 = insertCells.GetUpperBound(0);
          int upperBound2 = insertCells.GetUpperBound(1);
          for (int lowerBound1 = insertCells.GetLowerBound(0); lowerBound1 <= upperBound1; ++lowerBound1)
          {
            for (int lowerBound2 = insertCells.GetLowerBound(1); lowerBound2 <= upperBound2; ++lowerBound2)
            {
              ProcessedGraphicElementInsert.InsertCell insertCell = insertCells[lowerBound1, lowerBound2];
              this.class577_0.Draw(rootModelViewTransform, insertCell.Transform);
            }
          }
        }
        if (this.class577_1 == null)
          return;
        Matrix4D[,] attributeBlockCells = this.processedGraphicElementInsert_0.AttributeBlockCells;
        int upperBound3 = attributeBlockCells.GetUpperBound(0);
        int upperBound4 = attributeBlockCells.GetUpperBound(1);
        for (int lowerBound1 = attributeBlockCells.GetLowerBound(0); lowerBound1 <= upperBound3; ++lowerBound1)
        {
          for (int lowerBound2 = attributeBlockCells.GetLowerBound(1); lowerBound2 <= upperBound4; ++lowerBound2)
          {
            Matrix4D parentTransform = attributeBlockCells[lowerBound1, lowerBound2];
            this.class577_1.Draw(rootModelViewTransform, parentTransform);
          }
        }
      }
    }

    private class Class577 : IDisposable
    {
      private ProcessedGraphicElementBlock processedGraphicElementBlock_0;
      private bool bool_0;
      private DisplayList displayList_0;
      private List<GLGraphics3D.Class575> list_0;

      public Class577(ProcessedGraphicElementBlock wrappee)
      {
        this.processedGraphicElementBlock_0 = wrappee;
      }

      public void method_0(GLGraphics3D.Class570 converter)
      {
        if (this.bool_0)
          return;
        this.bool_0 = true;
        List<GLGraphics3D.Class571> wrappers = new List<GLGraphics3D.Class571>();
        GLGraphics3D.Class578 class578 = new GLGraphics3D.Class578(converter, wrappers);
        foreach (IGraphicElement graphicElement in this.processedGraphicElementBlock_0.GraphicElements)
          graphicElement.Accept((IGraphicElementVisitor) class578);
        foreach (GLGraphics3D.Class571 class571 in wrappers)
          class571.vmethod_0(converter);
        this.list_0 = new List<GLGraphics3D.Class575>();
        foreach (ProcessedGraphicElementInsert insert in this.processedGraphicElementBlock_0.Inserts)
        {
          GLGraphics3D.Class575 class575 = new GLGraphics3D.Class575(converter, insert);
          this.list_0.Add(class575);
          class575.vmethod_0(converter);
        }
        if (wrappers.Count <= 0)
          return;
        this.displayList_0 = new DisplayList();
        foreach (GLGraphics3D.Class571 class571 in wrappers)
          class571.Draw(converter);
        this.displayList_0.EndList();
      }

      public void Draw(Matrix4D rootModelViewTransform, Matrix4D parentTransform)
      {
        Matrix4D matrix4D1 = parentTransform * this.processedGraphicElementBlock_0.Transform;
        GL.PushMatrix();
        GL.MultMatrixd(ref matrix4D1);
        Matrix4D matrix4D2 = rootModelViewTransform * matrix4D1;
        this.method_1(matrix4D2);
        if (this.displayList_0 != null)
          this.displayList_0.Draw();
        foreach (GLGraphics3D.Class575 class575 in this.list_0)
          class575.Draw(matrix4D2);
        GL.PopMatrix();
      }

      private void method_1(Matrix4D transform)
      {
        GL.FrontFace(Vector3D.DotProduct(Vector3D.CrossProduct(new Vector3D(transform.M00, transform.M01, transform.M02), new Vector3D(transform.M10, transform.M11, transform.M12)), new Vector3D(transform.M20, transform.M21, transform.M22)) < 0.0 ? RotationalDirection.Clockwise : RotationalDirection.CounterClockwise);
      }

      public void Dispose()
      {
        if (this.displayList_0 == null)
          return;
        this.displayList_0.Delete();
        this.displayList_0 = (DisplayList) null;
      }
    }

    private class Class578 : IGraphicElementVisitor
    {
      private GLGraphics3D.Class570 class570_0;
      private List<GLGraphics3D.Class571> list_0;

      public Class578(GLGraphics3D.Class570 converter, List<GLGraphics3D.Class571> wrappers)
      {
        this.class570_0 = converter;
        this.list_0 = wrappers;
      }

      public void Visit(NullGraphicElement visitee)
      {
      }

      public void Visit(GraphicElement1 visitee)
      {
        this.list_0.Add((GLGraphics3D.Class571) new GLGraphics3D.Class572(visitee));
      }

      public void Visit(GraphicElement1Node visitee)
      {
        this.list_0.Add((GLGraphics3D.Class571) new GLGraphics3D.Class572((GraphicElement1) visitee));
        for (GraphicElement1Node next = visitee.Next; next != null; next = next.Next)
          this.list_0.Add((GLGraphics3D.Class571) new GLGraphics3D.Class572((GraphicElement1) next));
      }

      public void Visit(GraphicElement2 visitee)
      {
        this.list_0.Add((GLGraphics3D.Class571) new GLGraphics3D.Class573(visitee));
      }

      public void Visit(GraphicElementInsert visitee)
      {
        this.list_0.Add((GLGraphics3D.Class571) new GLGraphics3D.Class574(this.class570_0, visitee));
      }
    }

    private class Class579 : IPrimitiveVisitor
    {
      private GLGraphics3D glgraphics3D_0;

      public Class579(GLGraphics3D context)
      {
        this.glgraphics3D_0 = context;
      }

      public virtual void Visit(WW.Cad.Drawing.Surface.Point visitee)
      {
        this.method_2(visitee.Position);
      }

      public void Visit(PolygonMesh visitee)
      {
        int length1 = visitee.Mesh.GetLength(0);
        int length2 = visitee.Mesh.GetLength(1);
        int num1 = length1 - 1;
        if (visitee.ClosedInMDirection)
          ++num1;
        int num2 = length2 - 1;
        if (visitee.ClosedInNDirection)
          ++num2;
        for (int index1 = 0; index1 < num1; ++index1)
        {
          for (int index2 = 0; index2 < num2; ++index2)
          {
            int index3 = (index1 + 1) % length1;
            int index4 = (index2 + 1) % length2;
            this.Visit(new Quad(visitee.Mesh[index1, index2], visitee.Mesh[index3, index2], visitee.Mesh[index3, index4], visitee.Mesh[index1, index4]));
          }
        }
      }

      public virtual void Visit(WW.Cad.Drawing.Surface.Polyline2DE visitee)
      {
        Matrix4D transform = visitee.Transform;
        GL.PushMatrix();
        GL.MultMatrixd(ref transform);
        this.method_7<Point2DE, WW.Cad.Drawing.Polyline2DE>(visitee.Wrappee);
        GL.PopMatrix();
      }

      public virtual void Visit(WW.Cad.Drawing.Surface.Polyline2D2N visitee)
      {
        Matrix4D transform = visitee.Transform;
        GL.PushMatrix();
        GL.MultMatrixd(ref transform);
        this.method_7<Point2D2N, WW.Cad.Drawing.Polyline2D2N>(visitee.Wrappee);
        GL.PopMatrix();
      }

      public virtual void Visit(WW.Cad.Drawing.Surface.Polyline3D visitee)
      {
        if (this.glgraphics3D_0.bool_0 && !this.glgraphics3D_0.bool_1)
          GL.Disable(Capability.Lighting);
        if (visitee.Closed)
          GL.Begin(Mode.LineLoop);
        else
          GL.Begin(Mode.LineStrip);
        for (int index = 0; index < visitee.Points.Count; ++index)
        {
          WW.Math.Point3D point = visitee.Points[index];
          GL.Vertex3f((float) point.X, (float) point.Y, (float) point.Z);
        }
        GL.End();
        if (!this.glgraphics3D_0.bool_0 || this.glgraphics3D_0.bool_1)
          return;
        GL.Enable(Capability.Lighting);
      }

      public virtual void Visit(WW.Cad.Drawing.Surface.Polyline2D2WN visitee)
      {
        Matrix4D transform = visitee.Transform;
        GL.PushMatrix();
        GL.MultMatrixd(ref transform);
        List<Polyline2D> polyline2DList1 = new List<Polyline2D>();
        List<Polyline2D> polyline2DList2 = new List<Polyline2D>();
        DxfUtil.smethod_29(visitee.Wrappee, (IList<Polyline2D>) polyline2DList1, (IList<Polyline2D>) polyline2DList2);
        for (int index = 0; index < polyline2DList1.Count; ++index)
          this.method_0(polyline2DList1[index], polyline2DList2[index], visitee.Fill);
        GL.PopMatrix();
      }

      public void Visit(Quad visitee)
      {
        GLGraphics3D.Class579.smethod_2(visitee.V0, visitee.V1, visitee.V2, visitee.V3);
      }

      public void Visit(QuadWithEdges visitee)
      {
        WW.Math.Point3D v0 = visitee.V0;
        WW.Math.Point3D v1 = visitee.V1;
        WW.Math.Point3D v2 = visitee.V2;
        WW.Math.Point3D v3 = visitee.V3;
        if (v0 == v1)
        {
          Vector3D unit = Vector3D.CrossProduct(WW.Math.Point3D.Subtract(v2, v0), WW.Math.Point3D.Subtract(v3, v0)).GetUnit();
          GL.Begin(Mode.Triangles);
          GL.Normal3f((float) unit.X, (float) unit.Y, (float) unit.Z);
          GL.EdgeFlag(visitee.Edge1Visible);
          GL.Vertex3f((float) v1.X, (float) v1.Y, (float) v1.Z);
          GL.EdgeFlag(visitee.Edge2Visible);
          GL.Vertex3f((float) v2.X, (float) v2.Y, (float) v2.Z);
          GL.EdgeFlag(visitee.Edge3Visible);
          GL.Vertex3f((float) v3.X, (float) v3.Y, (float) v3.Z);
          GL.End();
        }
        else if (v1 == v2)
        {
          Vector3D unit = Vector3D.CrossProduct(WW.Math.Point3D.Subtract(v1, v0), WW.Math.Point3D.Subtract(v3, v0)).GetUnit();
          GL.Begin(Mode.Triangles);
          GL.Normal3f((float) unit.X, (float) unit.Y, (float) unit.Z);
          GL.EdgeFlag(visitee.Edge0Visible);
          GL.Vertex3f((float) v0.X, (float) v0.Y, (float) v0.Z);
          GL.EdgeFlag(visitee.Edge2Visible);
          GL.Vertex3f((float) v2.X, (float) v2.Y, (float) v2.Z);
          GL.EdgeFlag(visitee.Edge3Visible);
          GL.Vertex3f((float) v3.X, (float) v3.Y, (float) v3.Z);
          GL.End();
        }
        else if (v0 == v2)
        {
          Vector3D unit = Vector3D.CrossProduct(WW.Math.Point3D.Subtract(v1, v0), WW.Math.Point3D.Subtract(v3, v0)).GetUnit();
          GL.Begin(Mode.Triangles);
          GL.Normal3f((float) unit.X, (float) unit.Y, (float) unit.Z);
          GL.EdgeFlag(visitee.Edge0Visible);
          GL.Vertex3f((float) v0.X, (float) v0.Y, (float) v0.Z);
          GL.EdgeFlag(visitee.Edge1Visible);
          GL.Vertex3f((float) v1.X, (float) v1.Y, (float) v1.Z);
          GL.EdgeFlag(visitee.Edge3Visible);
          GL.Vertex3f((float) v3.X, (float) v3.Y, (float) v3.Z);
          GL.End();
        }
        else
        {
          Vector3D unit = Vector3D.CrossProduct(WW.Math.Point3D.Subtract(v1, v0), WW.Math.Point3D.Subtract(v2, v0)).GetUnit();
          GL.Begin(Mode.Quads);
          GL.Normal3f((float) unit.X, (float) unit.Y, (float) unit.Z);
          GL.EdgeFlag(visitee.Edge0Visible);
          GL.Vertex3f((float) v0.X, (float) v0.Y, (float) v0.Z);
          GL.EdgeFlag(visitee.Edge1Visible);
          GL.Vertex3f((float) v1.X, (float) v1.Y, (float) v1.Z);
          GL.EdgeFlag(visitee.Edge2Visible);
          GL.Vertex3f((float) v2.X, (float) v2.Y, (float) v2.Z);
          GL.EdgeFlag(visitee.Edge3Visible);
          GL.Vertex3f((float) v3.X, (float) v3.Y, (float) v3.Z);
          GL.End();
        }
      }

      public void Visit(QuadStrip1 visitee)
      {
        GL.Begin(Mode.QuadStrip);
        Vector3D zaxis = visitee.Normal;
        Matrix3D transpose = Transformation3D.GetArbitraryCoordSystem(zaxis).GetTranspose();
        if (Polygon2D.IsClockwise(transpose.TransformTo2D(visitee.Polyline1[0]), transpose.TransformTo2D(visitee.Polyline2[0]), transpose.TransformTo2D(visitee.Polyline2[1]), transpose.TransformTo2D(visitee.Polyline1[1])))
          zaxis = -zaxis;
        GL.Normal3f((float) zaxis.X, (float) zaxis.Y, (float) zaxis.Z);
        for (int index = 0; index < visitee.Polyline1.Count; ++index)
        {
          WW.Math.Point3D point3D1 = visitee.Polyline1[index];
          GL.Vertex3f((float) point3D1.X, (float) point3D1.Y, (float) point3D1.Z);
          WW.Math.Point3D point3D2 = visitee.Polyline2[index];
          GL.Vertex3f((float) point3D2.X, (float) point3D2.Y, (float) point3D2.Z);
        }
        if (visitee.Closed)
        {
          WW.Math.Point3D point3D1 = visitee.Polyline1[0];
          GL.Vertex3f((float) point3D1.X, (float) point3D1.Y, (float) point3D1.Z);
          WW.Math.Point3D point3D2 = visitee.Polyline2[0];
          GL.Vertex3f((float) point3D2.X, (float) point3D2.Y, (float) point3D2.Z);
        }
        GL.End();
      }

      public void Visit(QuadStrip2 visitee)
      {
        int count = visitee.Polyline1.Count;
        GL.Begin(Mode.QuadStrip);
        double num = 1.0;
        Matrix3D transpose = Transformation3D.GetArbitraryCoordSystem(visitee.Normals[0]).GetTranspose();
        if (Polygon2D.IsClockwise(transpose.TransformTo2D(visitee.Polyline1[0]), transpose.TransformTo2D(visitee.Polyline2[0]), transpose.TransformTo2D(visitee.Polyline2[1]), transpose.TransformTo2D(visitee.Polyline1[1])))
          num = -1.0;
        if (visitee.EndVertexIndex <= visitee.StartVertexIndex)
        {
          int startVertexIndex = visitee.StartVertexIndex;
          int index1 = 0;
          while (startVertexIndex < count)
          {
            Vector3D vector3D = num * visitee.Normals[index1];
            GL.Normal3f((float) vector3D.X, (float) vector3D.Y, (float) vector3D.Z);
            WW.Math.Point3D point3D1 = visitee.Polyline1[startVertexIndex];
            GL.Vertex3f((float) point3D1.X, (float) point3D1.Y, (float) point3D1.Z);
            WW.Math.Point3D point3D2 = visitee.Polyline2[startVertexIndex];
            GL.Vertex3f((float) point3D2.X, (float) point3D2.Y, (float) point3D2.Z);
            ++startVertexIndex;
            ++index1;
          }
          int index2 = 0;
          while (index2 <= visitee.EndVertexIndex)
          {
            Vector3D vector3D = num * visitee.Normals[index1];
            GL.Normal3f((float) vector3D.X, (float) vector3D.Y, (float) vector3D.Z);
            WW.Math.Point3D point3D1 = visitee.Polyline1[index2];
            GL.Vertex3f((float) point3D1.X, (float) point3D1.Y, (float) point3D1.Z);
            WW.Math.Point3D point3D2 = visitee.Polyline2[index2];
            GL.Vertex3f((float) point3D2.X, (float) point3D2.Y, (float) point3D2.Z);
            ++index2;
            ++index1;
          }
        }
        else
        {
          int startVertexIndex = visitee.StartVertexIndex;
          int index = 0;
          while (startVertexIndex <= visitee.EndVertexIndex)
          {
            Vector3D vector3D = num * visitee.Normals[index];
            GL.Normal3f((float) vector3D.X, (float) vector3D.Y, (float) vector3D.Z);
            WW.Math.Point3D point3D1 = visitee.Polyline1[startVertexIndex];
            GL.Vertex3f((float) point3D1.X, (float) point3D1.Y, (float) point3D1.Z);
            WW.Math.Point3D point3D2 = visitee.Polyline2[startVertexIndex];
            GL.Vertex3f((float) point3D2.X, (float) point3D2.Y, (float) point3D2.Z);
            ++startVertexIndex;
            ++index;
          }
        }
        GL.End();
      }

      public virtual void Visit(WW.Cad.Drawing.Surface.Segment visitee)
      {
        this.method_4(visitee.Start, visitee.End);
      }

      public void Visit(TexturedTriangleList visitee)
      {
        uint num = this.glgraphics3D_0.method_4(visitee.RgbaBytes, visitee.Width, visitee.Height);
        GL.Color3f(1f, 1f, 1f);
        GL.Enable(Capability.Texture2D);
        GL.Normal3f((float) visitee.Normal.X, (float) visitee.Normal.Y, (float) visitee.Normal.Z);
        GL.BindTexture(TextureTarget.Texture2D, num);
        GL.Begin(Mode.Triangles);
        for (int index = visitee.Triangles.Count - 1; index >= 0; --index)
        {
          Triangulator2D.Triangle triangle = visitee.Triangles[index];
          WW.Math.Point2D textureCoordinate1 = visitee.TextureCoordinates[triangle.I2];
          GL.TexCoord2f((float) textureCoordinate1.X, (float) textureCoordinate1.Y);
          WW.Math.Point3D point1 = visitee.Points[triangle.I2];
          GL.Vertex3f((float) point1.X, (float) point1.Y, (float) point1.Z);
          WW.Math.Point2D textureCoordinate2 = visitee.TextureCoordinates[triangle.I1];
          GL.TexCoord2f((float) textureCoordinate2.X, (float) textureCoordinate2.Y);
          WW.Math.Point3D point2 = visitee.Points[triangle.I1];
          GL.Vertex3f((float) point2.X, (float) point2.Y, (float) point2.Z);
          WW.Math.Point2D textureCoordinate3 = visitee.TextureCoordinates[triangle.I0];
          GL.TexCoord2f((float) textureCoordinate3.X, (float) textureCoordinate3.Y);
          WW.Math.Point3D point3 = visitee.Points[triangle.I0];
          GL.Vertex3f((float) point3.X, (float) point3.Y, (float) point3.Z);
        }
        GL.End();
        GL.BindTexture(TextureTarget.Texture2D, 0U);
        GL.Disable(Capability.Texture2D);
      }

      public void Visit(WW.Cad.Drawing.Surface.Triangle visitee)
      {
        WW.Math.Point3D v0 = visitee.V0;
        WW.Math.Point3D v1 = visitee.V1;
        WW.Math.Point3D v2 = visitee.V2;
        GL.Begin(Mode.Triangles);
        Vector3D unit = Vector3D.CrossProduct(WW.Math.Point3D.Subtract(v1, v0), WW.Math.Point3D.Subtract(v2, v0)).GetUnit();
        GL.Normal3f((float) unit.X, (float) unit.Y, (float) unit.Z);
        GL.Vertex3f((float) v0.X, (float) v0.Y, (float) v0.Z);
        GL.Vertex3f((float) v1.X, (float) v1.Y, (float) v1.Z);
        GL.Vertex3f((float) v2.X, (float) v2.Y, (float) v2.Z);
        GL.End();
      }

      public void Visit(TriangleWithEdges visitee)
      {
        WW.Math.Point3D v0 = visitee.V0;
        WW.Math.Point3D v1 = visitee.V1;
        WW.Math.Point3D v2 = visitee.V2;
        GL.Begin(Mode.Triangles);
        Vector3D unit = Vector3D.CrossProduct(WW.Math.Point3D.Subtract(visitee.V1, visitee.V0), WW.Math.Point3D.Subtract(visitee.V2, visitee.V0)).GetUnit();
        GL.Normal3f((float) unit.X, (float) unit.Y, (float) unit.Z);
        GL.EdgeFlag(visitee.Edge0Visible);
        GL.Vertex3f((float) v0.X, (float) v0.Y, (float) v0.Z);
        GL.EdgeFlag(visitee.Edge1Visible);
        GL.Vertex3f((float) v1.X, (float) v1.Y, (float) v1.Z);
        GL.EdgeFlag(visitee.Edge2Visible);
        GL.Vertex3f((float) v2.X, (float) v2.Y, (float) v2.Z);
        GL.End();
      }

      protected void method_0(Polyline2D polylineA, Polyline2D polylineB, bool fill)
      {
        if (polylineA.Count == 1)
        {
          WW.Math.Point2D point2D = polylineA[0];
          WW.Math.Point2D b = polylineB[0];
          if (point2D == b)
            this.method_1(point2D);
          else
            this.method_3(point2D, b);
        }
        else if (polylineA.Count == 2)
        {
          WW.Math.Point2D p0 = polylineA[0];
          WW.Math.Point2D p1 = polylineA[1];
          WW.Math.Point2D p3 = polylineB[0];
          WW.Math.Point2D p2 = polylineB[1];
          if (fill)
            GLGraphics3D.Class579.smethod_1(p0, p1, p2, p3);
          else
            this.method_5((IList<WW.Math.Point2D>) new WW.Math.Point2D[4]
            {
              p0,
              p1,
              p2,
              p3
            }, true);
        }
        else
        {
          int count = polylineA.Count;
          bool closed = polylineA.Closed;
          if (polylineB == null)
            this.method_6(polylineA);
          else if (fill)
          {
            GLGraphics3D.Class579.smethod_4((IList<WW.Math.Point2D>) polylineA, (IList<WW.Math.Point2D>) polylineB, closed);
          }
          else
          {
            for (int index = 0; index < count; ++index)
              this.method_3(polylineA[index], polylineB[index]);
            this.method_6(polylineA);
            this.method_6(polylineB);
          }
        }
      }

      protected void method_1(WW.Math.Point2D p)
      {
        GL.Begin(Mode.Points);
        GL.Vertex2f((float) p.X, (float) p.Y);
        GL.End();
      }

      protected void method_2(WW.Math.Point3D p)
      {
        GL.Begin(Mode.Points);
        GL.Vertex3f((float) p.X, (float) p.Y, (float) p.Z);
        GL.End();
      }

      protected void method_3(WW.Math.Point2D a, WW.Math.Point2D b)
      {
        if (this.glgraphics3D_0.bool_0 && !this.glgraphics3D_0.bool_1)
          GL.Disable(Capability.Lighting);
        GL.Begin(Mode.Lines);
        GL.Vertex2f((float) a.X, (float) a.Y);
        GL.Vertex2f((float) b.X, (float) b.Y);
        GL.End();
        if (!this.glgraphics3D_0.bool_0 || this.glgraphics3D_0.bool_1)
          return;
        GL.Enable(Capability.Lighting);
      }

      protected void method_4(WW.Math.Point3D p0, WW.Math.Point3D p1)
      {
        if (this.glgraphics3D_0.bool_0 && !this.glgraphics3D_0.bool_1)
          GL.Disable(Capability.Lighting);
        GL.Begin(Mode.Lines);
        GL.Vertex3f((float) p0.X, (float) p0.Y, (float) p0.Z);
        GL.Vertex3f((float) p1.X, (float) p1.Y, (float) p1.Z);
        GL.End();
        if (!this.glgraphics3D_0.bool_0 || this.glgraphics3D_0.bool_1)
          return;
        GL.Enable(Capability.Lighting);
      }

      protected static void smethod_0(WW.Math.Point2D p0, WW.Math.Point2D p1, WW.Math.Point2D p2)
      {
        GL.Begin(Mode.Triangles);
        GLGraphics3D.Class579.smethod_3(p1 - p0, p2 - p0);
        GL.Vertex2f((float) p0.X, (float) p0.Y);
        GL.Vertex2f((float) p1.X, (float) p1.Y);
        GL.Vertex2f((float) p2.X, (float) p2.Y);
        GL.End();
      }

      protected static void smethod_1(WW.Math.Point2D p0, WW.Math.Point2D p1, WW.Math.Point2D p2, WW.Math.Point2D p3)
      {
        if (p0 == p1)
        {
          GL.Begin(Mode.Triangles);
          GLGraphics3D.Class579.smethod_3(p2 - p0, p3 - p0);
          GL.Vertex2f((float) p1.X, (float) p1.Y);
          GL.Vertex2f((float) p2.X, (float) p2.Y);
          GL.Vertex2f((float) p3.X, (float) p3.Y);
          GL.End();
        }
        else if (p1 == p2)
        {
          GL.Begin(Mode.Triangles);
          GLGraphics3D.Class579.smethod_3(p2 - p0, p3 - p0);
          GL.Vertex2f((float) p0.X, (float) p0.Y);
          GL.Vertex2f((float) p2.X, (float) p2.Y);
          GL.Vertex2f((float) p3.X, (float) p3.Y);
          GL.End();
        }
        else if (p0 == p2)
        {
          GL.Begin(Mode.Triangles);
          GLGraphics3D.Class579.smethod_3(p1 - p0, p3 - p0);
          GL.Vertex2f((float) p0.X, (float) p0.Y);
          GL.Vertex2f((float) p1.X, (float) p1.Y);
          GL.Vertex2f((float) p3.X, (float) p3.Y);
          GL.End();
        }
        else
        {
          GL.Begin(Mode.Quads);
          GL.Normal3f(0.0f, 0.0f, Polygon2D.IsClockwise(p0, p1, p2, p3) ? -1f : 1f);
          GL.Vertex2f((float) p0.X, (float) p0.Y);
          GL.Vertex2f((float) p1.X, (float) p1.Y);
          GL.Vertex2f((float) p2.X, (float) p2.Y);
          GL.Vertex2f((float) p3.X, (float) p3.Y);
          GL.End();
        }
      }

      protected static void smethod_2(WW.Math.Point3D p0, WW.Math.Point3D p1, WW.Math.Point3D p2, WW.Math.Point3D p3)
      {
        if (p0 == p1)
        {
          Vector3D unit = Vector3D.CrossProduct(p2 - p0, p3 - p0).GetUnit();
          GL.Begin(Mode.Triangles);
          GL.Normal3f((float) unit.X, (float) unit.Y, (float) unit.Z);
          GL.Vertex3f((float) p1.X, (float) p1.Y, (float) p1.Z);
          GL.Vertex3f((float) p2.X, (float) p2.Y, (float) p2.Z);
          GL.Vertex3f((float) p3.X, (float) p3.Y, (float) p3.Z);
          GL.End();
        }
        else if (p1 == p2)
        {
          Vector3D unit = Vector3D.CrossProduct(p2 - p0, p3 - p0).GetUnit();
          GL.Begin(Mode.Triangles);
          GL.Normal3f((float) unit.X, (float) unit.Y, (float) unit.Z);
          GL.Vertex3f((float) p0.X, (float) p0.Y, (float) p0.Z);
          GL.Vertex3f((float) p2.X, (float) p2.Y, (float) p2.Z);
          GL.Vertex3f((float) p3.X, (float) p3.Y, (float) p3.Z);
          GL.End();
        }
        else if (p0 == p2)
        {
          Vector3D unit = Vector3D.CrossProduct(p1 - p0, p3 - p0).GetUnit();
          GL.Begin(Mode.Triangles);
          GL.Normal3f((float) unit.X, (float) unit.Y, (float) unit.Z);
          GL.Vertex3f((float) p0.X, (float) p0.Y, (float) p0.Z);
          GL.Vertex3f((float) p1.X, (float) p1.Y, (float) p1.Z);
          GL.Vertex3f((float) p3.X, (float) p3.Y, (float) p3.Z);
          GL.End();
        }
        else
        {
          Vector3D unit = Vector3D.CrossProduct(p1 - p0, p2 - p0).GetUnit();
          GL.Begin(Mode.Quads);
          GL.Normal3f((float) unit.X, (float) unit.Y, (float) unit.Z);
          GL.Vertex3f((float) p0.X, (float) p0.Y, (float) p0.Z);
          GL.Vertex3f((float) p1.X, (float) p1.Y, (float) p1.Z);
          GL.Vertex3f((float) p2.X, (float) p2.Y, (float) p2.Z);
          GL.Vertex3f((float) p3.X, (float) p3.Y, (float) p3.Z);
          GL.End();
        }
      }

      protected static void smethod_3(Vector2D a, Vector2D b)
      {
        GL.Normal3f(0.0f, 0.0f, Vector2D.CrossProduct(a, b) >= 0.0 ? 1f : -1f);
      }

      protected static void smethod_4(
        IList<WW.Math.Point2D> polylineA,
        IList<WW.Math.Point2D> polylineB,
        bool closed)
      {
        GL.Begin(Mode.QuadStrip);
        GL.Normal3f(0.0f, 0.0f, (float) (Polygon2D.IsClockwise((IList<WW.Math.Point2D>) new WW.Math.Point2D[4]
        {
          polylineA[0],
          polylineB[0],
          polylineB[1],
          polylineA[1]
        }) ? -1.0 : 1.0));
        for (int index = 0; index < polylineA.Count; ++index)
        {
          WW.Math.Point2D point2D1 = polylineA[index];
          GL.Vertex2f((float) point2D1.X, (float) point2D1.Y);
          WW.Math.Point2D point2D2 = polylineB[index];
          GL.Vertex2f((float) point2D2.X, (float) point2D2.Y);
        }
        if (closed)
        {
          WW.Math.Point2D point2D1 = polylineA[0];
          GL.Vertex2f((float) point2D1.X, (float) point2D1.Y);
          WW.Math.Point2D point2D2 = polylineB[0];
          GL.Vertex2f((float) point2D2.X, (float) point2D2.Y);
        }
        GL.End();
      }

      protected void method_5(IList<WW.Math.Point2D> polyline, bool closed)
      {
        if (this.glgraphics3D_0.bool_0 && !this.glgraphics3D_0.bool_1)
          GL.Disable(Capability.Lighting);
        if (closed)
          GL.Begin(Mode.LineLoop);
        else
          GL.Begin(Mode.LineStrip);
        for (int index = 0; index < polyline.Count; ++index)
        {
          WW.Math.Point2D point2D = polyline[index];
          GL.Vertex2f((float) point2D.X, (float) point2D.Y);
        }
        GL.End();
        if (!this.glgraphics3D_0.bool_0 || this.glgraphics3D_0.bool_1)
          return;
        GL.Enable(Capability.Lighting);
      }

      protected void method_6(Polyline2D polyline)
      {
        this.method_5((IList<WW.Math.Point2D>) polyline, polyline.Closed);
      }

      protected void method_7<T, U>(U polyline)
        where T : IExtendedPoint2D<T>, new()
        where U : WW.Math.Geometry.Polyline<T>
      {
        if (this.glgraphics3D_0.bool_0 && !this.glgraphics3D_0.bool_1)
          GL.Disable(Capability.Lighting);
        if (polyline.Closed)
          GL.Begin(Mode.LineLoop);
        else
          GL.Begin(Mode.LineStrip);
        for (int index = 0; index < polyline.Count; ++index)
        {
          WW.Math.Point2D position = polyline[index].Position;
          GL.Vertex2f((float) position.X, (float) position.Y);
        }
        GL.End();
        if (!this.glgraphics3D_0.bool_0 || this.glgraphics3D_0.bool_1)
          return;
        GL.Enable(Capability.Lighting);
      }

      protected void method_8(IList<WW.Math.Point2D> boundary)
      {
        if (boundary.Count == 0)
          return;
        if (boundary.Count == 1)
          this.method_1(boundary[0]);
        else if (boundary.Count == 2)
          this.method_3(boundary[0], boundary[1]);
        else if (boundary.Count == 3)
          GLGraphics3D.Class579.smethod_0(boundary[0], boundary[1], boundary[2]);
        else if (boundary.Count == 4)
        {
          GLGraphics3D.Class579.smethod_1(boundary[0], boundary[1], boundary[2], boundary[3]);
        }
        else
        {
          List<Triangulator2D.Triangle> triangleList = new List<Triangulator2D.Triangle>();
          List<WW.Math.Point2D> point2DList = new List<WW.Math.Point2D>();
          Triangulator2D.Triangulate((IList<IList<WW.Math.Point2D>>) new IList<WW.Math.Point2D>[1]
          {
            boundary
          }, (IList<Triangulator2D.Triangle>) triangleList, (IList<WW.Math.Point2D>) point2DList);
          GL.Begin(Mode.Triangles);
          foreach (Triangulator2D.Triangle triangle in triangleList)
          {
            WW.Math.Point2D point2D1 = point2DList[triangle.I0];
            WW.Math.Point2D point2D2 = point2DList[triangle.I1];
            WW.Math.Point2D point2D3 = point2DList[triangle.I2];
            GLGraphics3D.Class579.smethod_3(point2D2 - point2D1, point2D3 - point2D1);
            GL.Vertex2f((float) point2D1.X, (float) point2D1.Y);
            GL.Vertex2f((float) point2D2.X, (float) point2D2.Y);
            GL.Vertex2f((float) point2D3.X, (float) point2D3.Y);
          }
          GL.End();
        }
      }

      protected static void smethod_5(WW.Math.Point3D origin, Vector3D normal)
      {
        GL.Color3f(1f, 1f, 0.0f);
        GL.Begin(Mode.Lines);
        GL.Vertex3f((float) origin.X, (float) origin.Y, (float) origin.Z);
        WW.Math.Point3D point3D = origin + normal;
        GL.Vertex3f((float) point3D.X, (float) point3D.Y, (float) point3D.Z);
        GL.End();
      }
    }

    private class Class580 : GLGraphics3D.Class579
    {
      private Vector3D vector3D_0;

      public Vector3D Extrusion
      {
        get
        {
          return this.vector3D_0;
        }
        set
        {
          this.vector3D_0 = value;
        }
      }

      public Class580(GLGraphics3D context)
        : base(context)
      {
      }

      public override void Visit(WW.Cad.Drawing.Surface.Point visitee)
      {
        this.method_4(visitee.Position, visitee.Position + this.vector3D_0);
      }

      public override void Visit(WW.Cad.Drawing.Surface.Segment visitee)
      {
        GLGraphics3D.Class579.smethod_2(visitee.Start, visitee.End, visitee.End + this.vector3D_0, visitee.Start + this.vector3D_0);
      }

      public override void Visit(WW.Cad.Drawing.Surface.Polyline2D2N visitee)
      {
        Matrix4D transform = visitee.Transform;
        GL.PushMatrix();
        GL.MultMatrixd(ref transform);
        this.method_11(visitee.Wrappee, false);
        GL.PopMatrix();
      }

      public override void Visit(WW.Cad.Drawing.Surface.Polyline2D2WN visitee)
      {
        Matrix4D transform = visitee.Transform;
        GL.PushMatrix();
        GL.MultMatrixd(ref transform);
        List<WW.Cad.Drawing.Polyline2D2N> polyline2D2NList1 = new List<WW.Cad.Drawing.Polyline2D2N>();
        List<WW.Cad.Drawing.Polyline2D2N> polyline2D2NList2 = new List<WW.Cad.Drawing.Polyline2D2N>();
        DxfUtil.smethod_34(visitee.Wrappee, (IList<WW.Cad.Drawing.Polyline2D2N>) polyline2D2NList1, (IList<WW.Cad.Drawing.Polyline2D2N>) polyline2D2NList2);
        for (int index = 0; index < polyline2D2NList1.Count; ++index)
          this.method_9(polyline2D2NList1[index], polyline2D2NList2[index], visitee.Fill);
        GL.PopMatrix();
      }

      protected void method_9(WW.Cad.Drawing.Polyline2D2N polylineA, WW.Cad.Drawing.Polyline2D2N polylineB, bool fill)
      {
        if (polylineA.Count == 1)
        {
          Point2D2N point2D2N1 = polylineA[0];
          Point2D2N point2D2N2 = polylineB[0];
          if (point2D2N1.Position == point2D2N2.Position)
          {
            WW.Math.Point3D position = (WW.Math.Point3D) point2D2N1.Position;
            this.method_4(position, position + this.vector3D_0);
          }
          else
          {
            WW.Math.Point3D position1 = (WW.Math.Point3D) point2D2N1.Position;
            WW.Math.Point3D position2 = (WW.Math.Point3D) point2D2N2.Position;
            GLGraphics3D.Class579.smethod_2(position1, position2, position2 + this.vector3D_0, position1 + this.vector3D_0);
          }
        }
        else if (polylineA.Count == 2)
        {
          Point2D2N point2D2N1 = polylineA[0];
          Point2D2N point2D2N2 = polylineA[1];
          Point2D2N point2D2N3 = polylineB[0];
          Point2D2N point2D2N4 = polylineB[1];
          WW.Math.Point3D position1 = (WW.Math.Point3D) polylineA[0].Position;
          WW.Math.Point3D position2 = (WW.Math.Point3D) polylineA[1].Position;
          WW.Math.Point3D position3 = (WW.Math.Point3D) polylineB[0].Position;
          WW.Math.Point3D position4 = (WW.Math.Point3D) polylineB[1].Position;
          WW.Math.Point3D point3D1 = position1 + this.vector3D_0;
          WW.Math.Point3D point3D2 = position2 + this.vector3D_0;
          WW.Math.Point3D point3D3 = position3 + this.vector3D_0;
          WW.Math.Point3D p2 = position4 + this.vector3D_0;
          if (fill)
          {
            GLGraphics3D.Class579.smethod_1(point2D2N1.Position, point2D2N2.Position, point2D2N4.Position, point2D2N3.Position);
            GLGraphics3D.Class579.smethod_2(point3D1, point3D2, p2, point3D3);
          }
          GLGraphics3D.Class579.smethod_2(position1, position3, point3D3, point3D1);
          GLGraphics3D.Class579.smethod_2(position2, position4, p2, point3D2);
          this.method_12(position1, point3D1, point3D2, position2, point2D2N1.StartNormal, point2D2N1.EndNormal, false);
          this.method_12(position3, point3D3, p2, position4, point2D2N3.StartNormal, point2D2N3.EndNormal, true);
        }
        else
        {
          bool closed = polylineA.Closed;
          this.method_10(polylineA, polylineB, closed, fill);
        }
      }

      protected void method_10(
        WW.Cad.Drawing.Polyline2D2N polylineA,
        WW.Cad.Drawing.Polyline2D2N polylineB,
        bool closed,
        bool fill)
      {
        if (fill)
        {
          GL.Begin(Mode.QuadStrip);
          GL.Normal3f(0.0f, 0.0f, (float) (Polygon2D.IsClockwise((IList<WW.Math.Point2D>) new WW.Math.Point2D[4]
          {
            polylineA[0].Position,
            polylineB[0].Position,
            polylineB[1].Position,
            polylineA[1].Position
          }) ? -1.0 : 1.0));
          for (int index = 0; index < polylineA.Count; ++index)
          {
            WW.Math.Point2D position1 = polylineA[index].Position;
            GL.Vertex2f((float) position1.X, (float) position1.Y);
            WW.Math.Point2D position2 = polylineB[index].Position;
            GL.Vertex2f((float) position2.X, (float) position2.Y);
          }
          if (closed)
          {
            WW.Math.Point2D position1 = polylineA[0].Position;
            GL.Vertex2f((float) position1.X, (float) position1.Y);
            WW.Math.Point2D position2 = polylineB[0].Position;
            GL.Vertex2f((float) position2.X, (float) position2.Y);
          }
          GL.End();
          GL.Begin(Mode.QuadStrip);
          Vector3F vector3D0 = (Vector3F) this.vector3D_0;
          for (int index = 0; index < polylineA.Count; ++index)
          {
            WW.Math.Point2D position1 = polylineA[index].Position;
            GL.Vertex3f((float) position1.X + vector3D0.X, (float) position1.Y + vector3D0.Y, vector3D0.Z);
            WW.Math.Point2D position2 = polylineB[index].Position;
            GL.Vertex3f((float) position2.X + vector3D0.X, (float) position2.Y + vector3D0.Y, vector3D0.Z);
          }
          if (closed)
          {
            WW.Math.Point2D position1 = polylineA[0].Position;
            GL.Vertex3f((float) position1.X + vector3D0.X, (float) position1.Y + vector3D0.Y, vector3D0.Z);
            WW.Math.Point2D position2 = polylineB[0].Position;
            GL.Vertex3f((float) position2.X + vector3D0.X, (float) position2.Y + vector3D0.Y, vector3D0.Z);
          }
          GL.End();
        }
        this.method_11(polylineA, false);
        this.method_11(polylineB, true);
        if (closed)
          return;
        this.method_13((IList<Point2D2N>) polylineA, (IList<Point2D2N>) polylineB, 0);
        this.method_13((IList<Point2D2N>) polylineA, (IList<Point2D2N>) polylineB, polylineA.Count - 1);
      }

      private void method_11(WW.Cad.Drawing.Polyline2D2N polyline, bool negateNormals)
      {
        int count = polyline.Count;
        int index1 = polyline.Closed ? count - 1 : 0;
        Point2D2N point2D2N1 = polyline[index1];
        WW.Math.Point3D p0 = (WW.Math.Point3D) point2D2N1.Position;
        WW.Math.Point3D p1 = p0 + this.vector3D_0;
        for (int index2 = polyline.Closed ? 0 : 1; index2 < count; ++index2)
        {
          Point2D2N point2D2N2 = polyline[index2];
          WW.Math.Point3D position = (WW.Math.Point3D) point2D2N2.Position;
          WW.Math.Point3D p2 = position + this.vector3D_0;
          this.method_12(p0, p1, p2, position, point2D2N1.StartNormal, point2D2N1.EndNormal, negateNormals);
          p0 = position;
          p1 = p2;
          point2D2N1 = point2D2N2;
        }
      }

      private void method_12(
        WW.Math.Point3D p0,
        WW.Math.Point3D p1,
        WW.Math.Point3D p2,
        WW.Math.Point3D p3,
        Vector2D startNormal,
        Vector2D endNormal,
        bool negateNormals)
      {
        if (negateNormals ^ this.vector3D_0.Z < 0.0)
        {
          startNormal = -startNormal;
          endNormal = -endNormal;
        }
        GL.Begin(Mode.Quads);
        GL.Normal3f((float) startNormal.X, (float) startNormal.Y, 0.0f);
        GL.Vertex3f((float) p0.X, (float) p0.Y, (float) p0.Z);
        GL.Vertex3f((float) p1.X, (float) p1.Y, (float) p1.Z);
        GL.Normal3f((float) endNormal.X, (float) endNormal.Y, 0.0f);
        GL.Vertex3f((float) p2.X, (float) p2.Y, (float) p2.Z);
        GL.Vertex3f((float) p3.X, (float) p3.Y, (float) p3.Z);
        GL.End();
      }

      private void method_13(IList<Point2D2N> polylineA, IList<Point2D2N> polylineB, int index)
      {
        WW.Math.Point3D position1 = (WW.Math.Point3D) polylineA[index].Position;
        WW.Math.Point3D position2 = (WW.Math.Point3D) polylineB[index].Position;
        GLGraphics3D.Class579.smethod_2(position1, position1 + this.vector3D_0, position2 + this.vector3D_0, position2);
      }
    }
  }
}
