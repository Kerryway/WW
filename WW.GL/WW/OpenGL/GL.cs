// Decompiled with JetBrains decompiler
// Type: WW.OpenGL.GL
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security;
using WW.Math;

namespace WW.OpenGL
{
  [SuppressUnmanagedCodeSecurity]
  [SecuritySafeCritical]
  public static class GL
  {
    public const string GLDll = "opengl32";
    private static StringDictionary stringDictionary_0;

    [DllImport("opengl32")]
    public static extern void glAccum(AccumulationOperation op, float value);

    [DllImport("opengl32")]
    public static extern void glAlphaFunc(AlphaFunction func, float refx);

    [DllImport("opengl32")]
    public static extern uint glAreTexturesResident(int n, [In] uint[] textures, [Out] uint[] residences);

    [DllImport("opengl32")]
    public static extern void glArrayElement(int i);

    [DllImport("opengl32")]
    public static extern void glBegin(Mode mode);

    [DllImport("opengl32")]
    public static extern void glBindTexture(TextureTarget target, uint texture);

    [DllImport("opengl32")]
    public static extern void glBitmap(
      int width,
      int height,
      float xorigin,
      float yorigin,
      float xmove,
      float ymove,
      [In] byte[] bitmap);

    [DllImport("opengl32")]
    public static extern void glBlendFunc(
      BlendingFactorSource sourceFactor,
      BlendingFactorDestination destinationFactor);

    [DllImport("opengl32")]
    public static extern void glCallList(uint list);

    [DllImport("opengl32")]
    public static extern void glCallLists(int n, DataType dataType, [In] IntPtr lists);

    [DllImport("opengl32")]
    public static extern void glClear(ClearBufferFlags mask);

    [DllImport("opengl32")]
    public static extern void glClearAccum(float red, float green, float blue, float alpha);

    [DllImport("opengl32")]
    public static extern void glClearColor(float red, float green, float blue, float alpha);

    [DllImport("opengl32")]
    public static extern void glClearDepth(double depth);

    [DllImport("opengl32")]
    public static extern void glClearIndex(float c);

    [DllImport("opengl32")]
    public static extern void glClearStencil(int s);

    [DllImport("opengl32")]
    public static extern void glClipPlane(ClipPlaneName plane, [In] double[] equation);

    [DllImport("opengl32")]
    public static extern void glColor3b(sbyte red, sbyte green, sbyte blue);

    [DllImport("opengl32")]
    public static extern void glColor3bv([In] sbyte[] v);

    [DllImport("opengl32")]
    public static extern void glColor3d(double red, double green, double blue);

    [DllImport("opengl32")]
    public static extern void glColor3dv([In] double[] v);

    [DllImport("opengl32")]
    public static extern void glColor3f(float red, float green, float blue);

    [DllImport("opengl32")]
    public static extern void glColor3fv([In] float[] v);

    [DllImport("opengl32")]
    public static extern void glColor3i(int red, int green, int blue);

    [DllImport("opengl32")]
    public static extern void glColor3iv([In] int[] v);

    [DllImport("opengl32")]
    public static extern void glColor3s(short red, short green, short blue);

    [DllImport("opengl32")]
    public static extern void glColor3sv([In] short[] v);

    [DllImport("opengl32")]
    public static extern void glColor3ub(byte red, byte green, byte blue);

    [DllImport("opengl32")]
    public static extern void glColor3ubv([In] byte[] v);

    [DllImport("opengl32")]
    public static extern void glColor3ui(uint red, uint green, uint blue);

    [DllImport("opengl32")]
    public static extern void glColor3uiv([In] uint[] v);

    [DllImport("opengl32")]
    public static extern void glColor3us(ushort red, ushort green, ushort blue);

    [DllImport("opengl32")]
    public static extern void glColor3usv([In] ushort[] v);

    [DllImport("opengl32")]
    public static extern void glColor4b(sbyte red, sbyte green, sbyte blue, sbyte alpha);

    [DllImport("opengl32")]
    public static extern void glColor4bv([In] sbyte[] v);

    [DllImport("opengl32")]
    public static extern void glColor4d(double red, double green, double blue, double alpha);

    [DllImport("opengl32")]
    public static extern void glColor4dv([In] double[] v);

    [DllImport("opengl32")]
    public static extern void glColor4f(float red, float green, float blue, float alpha);

    [DllImport("opengl32")]
    public static extern void glColor4fv([In] float[] v);

    [DllImport("opengl32")]
    public static extern void glColor4i(int red, int green, int blue, int alpha);

    [DllImport("opengl32")]
    public static extern void glColor4iv([In] int[] v);

    [DllImport("opengl32")]
    public static extern void glColor4s(short red, short green, short blue, short alpha);

    [DllImport("opengl32")]
    public static extern void glColor4sv([In] short[] v);

    [DllImport("opengl32")]
    public static extern void glColor4ub(byte red, byte green, byte blue, byte alpha);

    [DllImport("opengl32")]
    public static extern void glColor4ubv([In] byte[] v);

    [DllImport("opengl32")]
    public static extern void glColor4ui(uint red, uint green, uint blue, uint alpha);

    [DllImport("opengl32")]
    public static extern void glColor4uiv([In] uint[] v);

    [DllImport("opengl32")]
    public static extern void glColor4us(ushort red, ushort green, ushort blue, ushort alpha);

    [DllImport("opengl32")]
    public static extern void glColor4usv([In] ushort[] v);

    [DllImport("opengl32")]
    public static extern void glColorMask(byte red, byte green, byte blue, byte alpha);

    [DllImport("opengl32")]
    public static extern void glColorMaterial(ColorMaterialFace face, ColorMaterialParameter mode);

    [DllImport("opengl32")]
    public static extern void glColorPointer(
      int size,
      DataType dataType,
      int stride,
      [In] IntPtr pointer);

    [DllImport("opengl32")]
    public static extern void glCopyPixels(
      int x,
      int y,
      int width,
      int height,
      PixelCopyType dataType);

    [DllImport("opengl32")]
    public static extern void glCopyTexImage1D(
      TextureTarget target,
      int level,
      PixelFormatInternal internalFormat,
      int x,
      int y,
      int width,
      int border);

    [DllImport("opengl32")]
    public static extern void glCopyTexImage2D(
      TextureTarget target,
      int level,
      PixelFormatInternal internalFormat,
      int x,
      int y,
      int width,
      int height,
      int border);

    [DllImport("opengl32")]
    public static extern void glCopyTexSubImage1D(
      TextureTarget target,
      int level,
      int xoffset,
      int x,
      int y,
      int width);

    [DllImport("opengl32")]
    public static extern void glCopyTexSubImage2D(
      TextureTarget target,
      int level,
      int xoffset,
      int yoffset,
      int x,
      int y,
      int width,
      int height);

    [DllImport("opengl32")]
    public static extern void glCullFace(CullFaceMode mode);

    [DllImport("opengl32")]
    public static extern void glDeleteLists(uint list, int range);

    [DllImport("opengl32")]
    public static extern void glDeleteTextures(int n, [In] uint[] textures);

    [DllImport("opengl32")]
    public static extern void glDepthFunc(ComparisonFunction func);

    [DllImport("opengl32")]
    public static extern void glDepthMask(byte flag);

    [DllImport("opengl32")]
    public static extern void glDepthRange(double zNear, double zFar);

    [DllImport("opengl32")]
    public static extern void glDisable(Capability cap);

    [DllImport("opengl32", EntryPoint = "glDisable")]
    public static extern void glDisable_1(LightName cap);

    [DllImport("opengl32", EntryPoint = "glDisable")]
    public static extern void glDisable_2(ClipPlaneName cap);

    [DllImport("opengl32", EntryPoint = "glDisable")]
    public static extern void glDisable_3(MapTarget cap);

    [DllImport("opengl32")]
    public static extern void glDisableClientState(ClientArrayType array);

    [DllImport("opengl32")]
    public static extern void glDrawArrays(Mode mode, int first, int count);

    [DllImport("opengl32")]
    public static extern void glDrawBuffer(DrawBufferMode mode);

    [DllImport("opengl32")]
    public static extern void glDrawElements(
      Mode mode,
      int count,
      DataType dataType,
      [In] uint[] indices);

    [DllImport("opengl32")]
    public static extern void glDrawPixels(
      int width,
      int height,
      PixelFormat format,
      DataType dataType,
      [In] IntPtr pixels);

    [DllImport("opengl32")]
    public static extern void glEdgeFlag([MarshalAs(UnmanagedType.U1)] bool flag);

    [DllImport("opengl32")]
    public static extern void glEdgeFlagPointer(int stride, [In] IntPtr pointer);

    [DllImport("opengl32")]
    public static extern void glEdgeFlagv([In] uint[] flag);

    [DllImport("opengl32")]
    public static extern void glEnable(Capability cap);

    [DllImport("opengl32", EntryPoint = "glEnable")]
    public static extern void glEnable_1(LightName cap);

    [DllImport("opengl32", EntryPoint = "glEnable")]
    public static extern void glEnable_2(ClipPlaneName cap);

    [DllImport("opengl32", EntryPoint = "glEnable")]
    public static extern void glEnable_3(MapTarget cap);

    [DllImport("opengl32", EntryPoint = "glEnable")]
    public static extern void glEnable_4(PolygonOffset cap);

    [DllImport("opengl32")]
    public static extern void glEnableClientState(ClientArrayType array);

    [DllImport("opengl32")]
    public static extern void glEnd();

    [DllImport("opengl32")]
    public static extern void glEndList();

    [DllImport("opengl32")]
    public static extern void glEvalCoord1d(double u);

    [DllImport("opengl32")]
    public static extern void glEvalCoord1dv([In] double[] u);

    [DllImport("opengl32")]
    public static extern void glEvalCoord1f(float u);

    [DllImport("opengl32")]
    public static extern void glEvalCoord1fv([In] float[] u);

    [DllImport("opengl32")]
    public static extern void glEvalCoord2d(double u, double v);

    [DllImport("opengl32")]
    public static extern void glEvalCoord2dv([In] double[] u);

    [DllImport("opengl32")]
    public static extern void glEvalCoord2f(float u, float v);

    [DllImport("opengl32")]
    public static extern void glEvalCoord2fv([In] float[] u);

    [DllImport("opengl32")]
    public static extern void glEvalMesh1(MeshMode1 mode, int i1, int i2);

    [DllImport("opengl32")]
    public static extern void glEvalMesh2(MeshMode2 mode, int i1, int i2, int j1, int j2);

    [DllImport("opengl32")]
    public static extern void glEvalPointu00201(int i);

    [DllImport("opengl32")]
    public static extern void glEvalPointu00202(int i, int j);

    [DllImport("opengl32")]
    public static extern void glFeedbackBuffer(int size, FeedBackMode mode, [Out] float[] buffer);

    [DllImport("opengl32")]
    public static extern void glFinish();

    [DllImport("opengl32")]
    public static extern void glFlush();

    [DllImport("opengl32")]
    public static extern void glFogCoordPointer(DataType type, int stride, [In] IntPtr pointer);

    [DllImport("opengl32")]
    public static extern void glFogf(FogParameter fogParameter, FogMode param);

    [DllImport("opengl32", EntryPoint = "glFogf")]
    public static extern void glFogf_1(FogParameter fogParameter, float param);

    [DllImport("opengl32")]
    public static extern void glFogfv(FogParameter fogParameter, [In] float[] parameters);

    [DllImport("opengl32")]
    public static extern void glFogi(FogParameter fogParameter, FogMode param);

    [DllImport("opengl32", EntryPoint = "glFogi")]
    public static extern void glFogi_1(FogParameter fogParameter, int param);

    [DllImport("opengl32")]
    public static extern void glFogiv(FogParameter fogParameter, [In] int[] parameters);

    [DllImport("opengl32")]
    public static extern void glFrontFace(RotationalDirection rotationalDirection);

    [DllImport("opengl32")]
    public static extern void glFrustum(
      double left,
      double right,
      double bottom,
      double top,
      double zNear,
      double zFar);

    [DllImport("opengl32")]
    public static extern uint glGenLists(int range);

    [DllImport("opengl32")]
    public static extern void glGenTextures(int n, [Out] uint[] textures);

    [DllImport("opengl32")]
    public static extern void glGetBooleanv(GetTarget target, [Out] uint[] parameters);

    [DllImport("opengl32")]
    public static extern void glGetColorTableParameterfvEXT(
      ColorTableParameterTarget target,
      ColorTableParameterName pname,
      [Out] float[] parameters);

    [DllImport("opengl32")]
    public static extern void glGetColorTableParameterivEXT(
      ColorTableParameterTarget target,
      ColorTableParameterName pname,
      [Out] int[] parameters);

    [DllImport("opengl32")]
    public static extern void glGetClipPlane(ClipPlaneName plane, [Out] double[] equation);

    [DllImport("opengl32")]
    public static extern void glGetDoublev(GetTarget target, [Out] double[] parameters);

    [DllImport("opengl32", EntryPoint = "glGetDoublev")]
    public static extern void glGetDoublev_1(GetTarget target, out Matrix4D parameters);

    [DllImport("opengl32")]
    public static extern uint glGetError();

    [DllImport("opengl32")]
    public static extern void glGetFloatv(GetTarget target, [Out] float[] parameters);

    [DllImport("opengl32", EntryPoint = "glGetFloatv")]
    public static extern void glGetFloatv_1(GetTarget target, out Matrix4F m);

    [DllImport("opengl32")]
    public static extern void glGetIntegerv(GetTarget target, [Out] int[] parameters);

    [DllImport("opengl32")]
    public static extern void glGetLightfv(
      LightName light,
      LightParameter parameter,
      [Out] float[] parameters);

    [DllImport("opengl32")]
    public static extern void glGetLightiv(
      LightName light,
      LightParameter parameter,
      [Out] int[] parameters);

    [DllImport("opengl32")]
    public static extern void glGetMapdv(MapTarget target, MapTargetParameter query, [Out] double[] v);

    [DllImport("opengl32")]
    public static extern void glGetMapfv(MapTarget target, MapTargetParameter query, [Out] float[] v);

    [DllImport("opengl32")]
    public static extern void glGetMapiv(MapTarget target, MapTargetParameter query, [Out] int[] v);

    [DllImport("opengl32")]
    public static extern void glGetMaterialfv(
      MaterialFace face,
      MaterialParameter pname,
      [Out] float[] parameters);

    [DllImport("opengl32")]
    public static extern void glGetMaterialiv(
      MaterialFace face,
      MaterialParameter pname,
      [Out] int[] parameters);

    [DllImport("opengl32")]
    public static extern void glGetPixelMapfv(PixelMapName map, [Out] float[] values);

    [DllImport("opengl32")]
    public static extern void glGetPixelMapuiv(PixelMapName map, [Out] uint[] values);

    [DllImport("opengl32")]
    public static extern void glGetPixelMapusv(PixelMapName map, [Out] ushort[] values);

    [DllImport("opengl32")]
    public static extern void glGetPointerv(ArrayPointerType pname, [Out] IntPtr parameters);

    [DllImport("opengl32")]
    public static extern void glGetPolygonStipple([Out] byte[] mask);

    [DllImport("opengl32")]
    public static extern IntPtr glGetString(StringName name);

    public static string GetString(StringName name)
    {
      return Marshal.PtrToStringAnsi(GL.glGetString(name));
    }

    [DllImport("opengl32")]
    public static extern void glGetTexEnvfv(
      TextureEnvironmentTarget target,
      TextureEnvironmentParameterName pname,
      [Out] float[] parameters);

    [DllImport("opengl32")]
    public static extern void glGetTexEnviv(
      TextureEnvironmentTarget target,
      TextureEnvironmentParameterName pname,
      [Out] int[] parameters);

    [DllImport("opengl32")]
    public static extern void glGetTexGendv(
      TextureCoordName coord,
      TextureGenParameter pname,
      [Out] double[] parameters);

    [DllImport("opengl32")]
    public static extern void glGetTexGenfv(
      TextureCoordName coord,
      TextureGenParameter pname,
      [Out] float[] parameters);

    [DllImport("opengl32")]
    public static extern void glGetTexGeniv(
      TextureCoordName coord,
      TextureGenParameter pname,
      [Out] int[] parameters);

    [DllImport("opengl32")]
    public static extern void glGetTexImage(
      TextureTarget target,
      int level,
      PixelFormat format,
      DataType dataType,
      [Out] IntPtr pixels);

    [DllImport("opengl32")]
    public static extern void glGetTexLevelParameterfv(
      TextureTarget target,
      int level,
      GetTextureLevelParameter pname,
      [Out] float[] parameters);

    [DllImport("opengl32")]
    public static extern void glGetTexLevelParameteriv(
      TextureTarget target,
      int level,
      GetTextureLevelParameter pname,
      [Out] int[] parameters);

    [DllImport("opengl32")]
    public static extern void glGetTexParameterfv(
      TextureTarget target,
      TextureParameterName pname,
      [Out] float[] parameters);

    [DllImport("opengl32")]
    public static extern void glGetTexParameteriv(
      TextureTarget target,
      TextureParameterName pname,
      [Out] int[] parameters);

    [DllImport("opengl32")]
    public static extern void glHint(HintTarget target, HintMode mode);

    [DllImport("opengl32")]
    public static extern void glIndexMask(uint mask);

    [DllImport("opengl32")]
    public static extern void glIndexPointer(DataType dataType, int stride, [In] IntPtr pointer);

    [DllImport("opengl32")]
    public static extern void glIndexd(double c);

    [DllImport("opengl32")]
    public static extern void glIndexdv([In] double[] c);

    [DllImport("opengl32")]
    public static extern void glIndexf(float c);

    [DllImport("opengl32")]
    public static extern void glIndexfv([In] float[] c);

    [DllImport("opengl32")]
    public static extern void glIndexi(int c);

    [DllImport("opengl32")]
    public static extern void glIndexiv([In] int[] c);

    [DllImport("opengl32")]
    public static extern void glIndexs(short c);

    [DllImport("opengl32")]
    public static extern void glIndexsv([In] short[] c);

    [DllImport("opengl32")]
    public static extern void glIndexub(byte c);

    [DllImport("opengl32")]
    public static extern void glIndexubv([In] byte[] c);

    [DllImport("opengl32")]
    public static extern void glInitNames();

    [DllImport("opengl32")]
    public static extern void glInterleavedArrays(
      InterleavedArrayFormat format,
      int stride,
      [In] IntPtr pointer);

    [DllImport("opengl32")]
    public static extern uint glIsEnabled(Capability cap);

    [DllImport("opengl32", EntryPoint = "glIsEnabled")]
    public static extern uint glIsEnabled_1(LightName cap);

    [DllImport("opengl32", EntryPoint = "glIsEnabled")]
    public static extern uint glIsEnabled_2(ClipPlaneName cap);

    [DllImport("opengl32", EntryPoint = "glIsEnabled")]
    public static extern uint glIsEnabled_3(MapTarget cap);

    [DllImport("opengl32")]
    public static extern uint glIsList(uint list);

    [DllImport("opengl32")]
    public static extern uint glIsTexture(uint texture);

    [DllImport("opengl32")]
    public static extern void glLightModelf(LightModelParameter pname, float param);

    [DllImport("opengl32")]
    public static extern void glLightModelfv(LightModelParameter pname, [In] float[] parameters);

    [DllImport("opengl32")]
    public static extern void glLightModeli(LightModelParameter pname, int param);

    [DllImport("opengl32", EntryPoint = "glLightModeli")]
    public static extern void glLightModeli_1(LightModelParameter pname, [MarshalAs(UnmanagedType.Bool)] bool param);

    [DllImport("opengl32")]
    public static extern void glLightModeliv(LightModelParameter pname, [In] int[] parameters);

    [DllImport("opengl32")]
    public static extern void glLightf(LightName light, LightParameter parameter, float param);

    [DllImport("opengl32")]
    public static extern void glLightfv(
      LightName light,
      LightParameter parameter,
      [In] params float[] parameters);

    [DllImport("opengl32")]
    public static extern void glLighti(LightName light, LightParameter parameter, int param);

    [DllImport("opengl32")]
    public static extern void glLightiv(
      LightName light,
      LightParameter parameter,
      [In] params int[] parameters);

    [DllImport("opengl32")]
    public static extern void glLineStipple(int factor, ushort pattern);

    [DllImport("opengl32")]
    public static extern void glLineWidth(float width);

    [DllImport("opengl32")]
    public static extern void glListBase(uint basex);

    [DllImport("opengl32")]
    public static extern void glLoadIdentity();

    [DllImport("opengl32")]
    public static extern void glLoadMatrixd([In] double[] m);

    [DllImport("opengl32", EntryPoint = "glLoadMatrixd")]
    public static extern void glLoadMatrixd_1([In] ref Matrix4D m);

    [DllImport("opengl32")]
    public static extern void glLoadMatrixf([In] float[] m);

    [DllImport("opengl32", EntryPoint = "glLoadMatrixf")]
    public static extern void glLoadMatrixf_1([In] ref Matrix4F m);

    [DllImport("opengl32")]
    public static extern void glLoadName(uint name);

    [DllImport("opengl32")]
    public static extern void glLogicOp(LogicalOperation opcode);

    [DllImport("opengl32")]
    public static extern void glMap1d(
      MapTarget target,
      double u1,
      double u2,
      int stride,
      int order,
      [In] double[] points);

    [DllImport("opengl32")]
    public static extern void glMap1f(
      MapTarget target,
      float u1,
      float u2,
      int stride,
      int order,
      [In] float[] points);

    [DllImport("opengl32")]
    public static extern void glMap2d(
      MapTarget target,
      double u1,
      double u2,
      int ustride,
      int uorder,
      double v1,
      double v2,
      int vstride,
      int vorder,
      [In] double[] points);

    [DllImport("opengl32")]
    public static extern void glMap2f(
      MapTarget target,
      float u1,
      float u2,
      int ustride,
      int uorder,
      float v1,
      float v2,
      int vstride,
      int vorder,
      [In] float[] points);

    [DllImport("opengl32")]
    public static extern void glMapGrid1d(int un, double u1, double u2);

    [DllImport("opengl32")]
    public static extern void glMapGrid1f(int un, float u1, float u2);

    [DllImport("opengl32")]
    public static extern void glMapGrid2d(
      int un,
      double u1,
      double u2,
      int vn,
      double v1,
      double v2);

    [DllImport("opengl32")]
    public static extern void glMapGrid2f(
      int un,
      float u1,
      float u2,
      int vn,
      float v1,
      float v2);

    [DllImport("opengl32")]
    public static extern void glMaterialf(
      MaterialFace face,
      MaterialParameter parameter,
      float param);

    [DllImport("opengl32")]
    public static extern void glMaterialfv(
      MaterialFace face,
      MaterialParameter parameter,
      [In] float[] parameters);

    [DllImport("opengl32")]
    public static extern void glMateriali(
      MaterialFace face,
      MaterialParameter parameter,
      int param);

    [DllImport("opengl32")]
    public static extern void glMaterialiv(
      MaterialFace face,
      MaterialParameter parameter,
      [In] int[] parameters);

    [DllImport("opengl32")]
    public static extern void glMatrixMode(MatrixMode mode);

    [DllImport("opengl32")]
    public static extern void glMultMatrixd([In] double[] m);

    [DllImport("opengl32", EntryPoint = "glMultMatrixd")]
    public static extern void glMultMatrixd_1([In] ref Matrix4D m);

    [DllImport("opengl32")]
    public static extern void glMultMatrixf([In] float[] m);

    [DllImport("opengl32", EntryPoint = "glMultMatrixf")]
    public static extern void glMultMatrixf_1([In] ref Matrix4F m);

    [DllImport("opengl32")]
    public static extern void glNewList(uint list, ListMode mode);

    [DllImport("opengl32")]
    public static extern void glNormal3b(sbyte nx, sbyte ny, sbyte nz);

    [DllImport("opengl32")]
    public static extern void glNormal3bv([In] sbyte[] v);

    [DllImport("opengl32")]
    public static extern void glNormal3d(double nx, double ny, double nz);

    public static void Normal3d(Vector3D n)
    {
      GL.glNormal3d(n.X, n.Y, n.Z);
    }

    [DllImport("opengl32")]
    public static extern void glNormal3dv([In] double[] v);

    [DllImport("opengl32")]
    public static extern void glNormal3f(float nx, float ny, float nz);

    public static void Normal3f(Vector3F n)
    {
      GL.glNormal3f(n.X, n.Y, n.Z);
    }

    [DllImport("opengl32")]
    public static extern void glNormal3fv([In] float[] v);

    [DllImport("opengl32")]
    public static extern void glNormal3i(int nx, int ny, int nz);

    [DllImport("opengl32")]
    public static extern void glNormal3iv([In] int[] v);

    [DllImport("opengl32")]
    public static extern void glNormal3s(short nx, short ny, short nz);

    [DllImport("opengl32")]
    public static extern void glNormal3sv([In] short[] v);

    [DllImport("opengl32")]
    public static extern void glNormalPointer(DataType dataType, int stride, [In] IntPtr pointer);

    [DllImport("opengl32")]
    public static extern void glOrtho(
      double left,
      double right,
      double bottom,
      double top,
      double zNear,
      double zFar);

    [DllImport("opengl32")]
    public static extern void glPassThrough(float token);

    [DllImport("opengl32")]
    public static extern void glPixelMapfv(PixelMapName map, int mapsize, [In] float[] values);

    [DllImport("opengl32")]
    public static extern void glPixelMapuiv(PixelMapName map, int mapsize, [In] uint[] values);

    [DllImport("opengl32")]
    public static extern void glPixelMapusv(PixelMapName map, int mapsize, [In] ushort[] values);

    [DllImport("opengl32")]
    public static extern void glPixelStoref(PixelStore pname, float param);

    [DllImport("opengl32")]
    public static extern void glPixelStorei(PixelStore pname, int param);

    [DllImport("opengl32")]
    public static extern void glPixelTransferf(PixelTransfer pname, float param);

    [DllImport("opengl32")]
    public static extern void glPixelTransferi(PixelTransfer pname, int param);

    [DllImport("opengl32")]
    public static extern void glPixelZoom(float xfactor, float yfactor);

    [DllImport("opengl32")]
    public static extern void glPointSize(float size);

    [DllImport("opengl32")]
    public static extern void glPolygonMode(CullFaceMode face, PolygonMode mode);

    [DllImport("opengl32")]
    public static extern void glPolygonOffset(float factor, float units);

    [DllImport("opengl32")]
    public static extern void glPolygonStipple([In] byte[] mask);

    [DllImport("opengl32")]
    public static extern void glPopAttrib();

    [DllImport("opengl32")]
    public static extern void glPopClientAttrib();

    [DllImport("opengl32")]
    public static extern void glPopMatrix();

    [DllImport("opengl32")]
    public static extern void glPopName();

    [DllImport("opengl32")]
    public static extern void glPrioritizeTextures(int n, [In] uint[] textures, [In] float[] priorities);

    [DllImport("opengl32")]
    public static extern void glPushAttrib(AttributeFlags mask);

    [DllImport("opengl32")]
    public static extern void glPushClientAttrib(ClientAttributeFlags mask);

    [DllImport("opengl32")]
    public static extern void glPushMatrix();

    [DllImport("opengl32")]
    public static extern void glPushName(uint name);

    [DllImport("opengl32")]
    public static extern void glRasterPos2d(double x, double y);

    [DllImport("opengl32")]
    public static extern void glRasterPos2dv([In] double[] v);

    [DllImport("opengl32")]
    public static extern void glRasterPos2f(float x, float y);

    [DllImport("opengl32")]
    public static extern void glRasterPos2fv([In] float[] v);

    [DllImport("opengl32")]
    public static extern void glRasterPos2i(int x, int y);

    [DllImport("opengl32")]
    public static extern void glRasterPos2iv([In] int[] v);

    [DllImport("opengl32")]
    public static extern void glRasterPos2s(short x, short y);

    [DllImport("opengl32")]
    public static extern void glRasterPos2sv([In] short[] v);

    [DllImport("opengl32")]
    public static extern void glRasterPos3d(double x, double y, double z);

    [DllImport("opengl32")]
    public static extern void glRasterPos3dv([In] double[] v);

    [DllImport("opengl32")]
    public static extern void glRasterPos3f(float x, float y, float z);

    [DllImport("opengl32")]
    public static extern void glRasterPos3fv([In] float[] v);

    [DllImport("opengl32")]
    public static extern void glRasterPos3i(int x, int y, int z);

    [DllImport("opengl32")]
    public static extern void glRasterPos3iv([In] int[] v);

    [DllImport("opengl32")]
    public static extern void glRasterPos3s(short x, short y, short z);

    [DllImport("opengl32")]
    public static extern void glRasterPos3sv([In] short[] v);

    [DllImport("opengl32")]
    public static extern void glRasterPos4d(double x, double y, double z, double w);

    [DllImport("opengl32")]
    public static extern void glRasterPos4dv([In] double[] v);

    [DllImport("opengl32")]
    public static extern void glRasterPos4f(float x, float y, float z, float w);

    [DllImport("opengl32")]
    public static extern void glRasterPos4fv([In] float[] v);

    [DllImport("opengl32")]
    public static extern void glRasterPos4i(int x, int y, int z, int w);

    [DllImport("opengl32")]
    public static extern void glRasterPos4iv([In] int[] v);

    [DllImport("opengl32")]
    public static extern void glRasterPos4s(short x, short y, short z, short w);

    [DllImport("opengl32")]
    public static extern void glRasterPos4sv([In] short[] v);

    [DllImport("opengl32")]
    public static extern void glReadBuffer(ReadBufferMode mode);

    [DllImport("opengl32")]
    public static extern void glReadPixels(
      int x,
      int y,
      int width,
      int height,
      PixelFormat format,
      DataType dataType,
      [Out] IntPtr pixels);

    [DllImport("opengl32", EntryPoint = "glReadPixels")]
    public static extern void glReadPixels_1(
      int x,
      int y,
      int width,
      int height,
      PixelFormat format,
      DataType dataType,
      [Out] byte[] pixels);

    [DllImport("opengl32", EntryPoint = "glReadPixels")]
    public static extern void glReadPixels_2(
      int x,
      int y,
      int width,
      int height,
      PixelFormat format,
      DataType dataType,
      [Out] float[] pixels);

    [DllImport("opengl32")]
    public static extern void glRectd(double x1, double y1, double x2, double y2);

    [DllImport("opengl32")]
    public static extern void glRectdv([In] double[] v1, [In] double[] v2);

    [DllImport("opengl32")]
    public static extern void glRectf(float x1, float y1, float x2, float y2);

    [DllImport("opengl32")]
    public static extern void glRectfv([In] float[] v1, [In] float[] v2);

    [DllImport("opengl32")]
    public static extern void glRecti(int x1, int y1, int x2, int y2);

    [DllImport("opengl32")]
    public static extern void glRectiv([In] int[] v1, [In] int[] v2);

    [DllImport("opengl32")]
    public static extern void glRects(short x1, short y1, short x2, short y2);

    [DllImport("opengl32")]
    public static extern void glRectsv([In] short[] v1, [In] short[] v2);

    [DllImport("opengl32")]
    public static extern uint glRenderMode(RenderingMode mode);

    [DllImport("opengl32")]
    public static extern void glRotated(double angle, double x, double y, double z);

    [DllImport("opengl32")]
    public static extern void glRotatef(float angle, float x, float y, float z);

    [DllImport("opengl32")]
    public static extern void glScaled(double x, double y, double z);

    [DllImport("opengl32")]
    public static extern void glScalef(float x, float y, float z);

    [DllImport("opengl32")]
    public static extern void glScissor(int x, int y, int width, int height);

    [DllImport("opengl32")]
    public static extern void glSecondaryColorPointer(
      int size,
      DataType dataType,
      int stride,
      [In] IntPtr pointer);

    [DllImport("opengl32")]
    public static extern void glSelectBuffer(int size, [Out] uint[] buffer);

    [DllImport("opengl32")]
    public static extern void glShadeModel(ShadingModel mode);

    [DllImport("opengl32")]
    public static extern void glStencilFunc(StencilFunction func, int refx, uint mask);

    [DllImport("opengl32")]
    public static extern void glStencilMask(uint mask);

    [DllImport("opengl32")]
    public static extern void glStencilOp(
      StencilOperation fail,
      StencilOperation zfail,
      StencilOperation zpass);

    [DllImport("opengl32")]
    public static extern void glTexCoord1d(double s);

    [DllImport("opengl32")]
    public static extern void glTexCoord1dv([In] double[] v);

    [DllImport("opengl32")]
    public static extern void glTexCoord1f(float s);

    [DllImport("opengl32")]
    public static extern void glTexCoord1fv([In] float[] v);

    [DllImport("opengl32")]
    public static extern void glTexCoord1i(int s);

    [DllImport("opengl32")]
    public static extern void glTexCoord1iv([In] int[] v);

    [DllImport("opengl32")]
    public static extern void glTexCoord1s(short s);

    [DllImport("opengl32")]
    public static extern void glTexCoord1sv([In] short[] v);

    [DllImport("opengl32")]
    public static extern void glTexCoord2d(double s, double t);

    public static void TexCoord2d(Point2D p)
    {
      GL.glTexCoord2d(p.X, p.Y);
    }

    [DllImport("opengl32")]
    public static extern void glTexCoord2dv([In] double[] v);

    [DllImport("opengl32")]
    public static extern void glTexCoord2f(float s, float t);

    [DllImport("opengl32", EntryPoint = "glTexCoord2f")]
    public static extern void glTexCoord2f_1(Point2F p);

    [DllImport("opengl32")]
    public static extern void glTexCoord2fv([In] float[] v);

    [DllImport("opengl32")]
    public static extern void glTexCoord2i(int s, int t);

    [DllImport("opengl32")]
    public static extern void glTexCoord2iv([In] int[] v);

    [DllImport("opengl32")]
    public static extern void glTexCoord2s(short s, short t);

    [DllImport("opengl32")]
    public static extern void glTexCoord2sv([In] short[] v);

    [DllImport("opengl32")]
    public static extern void glTexCoord3d(double s, double t, double r);

    [DllImport("opengl32")]
    public static extern void glTexCoord3dv([In] double[] v);

    [DllImport("opengl32")]
    public static extern void glTexCoord3f(float s, float t, float r);

    [DllImport("opengl32")]
    public static extern void glTexCoord3fv([In] float[] v);

    [DllImport("opengl32")]
    public static extern void glTexCoord3i(int s, int t, int r);

    [DllImport("opengl32")]
    public static extern void glTexCoord3iv([In] int[] v);

    [DllImport("opengl32")]
    public static extern void glTexCoord3s(short s, short t, short r);

    [DllImport("opengl32")]
    public static extern void glTexCoord3sv([In] short[] v);

    [DllImport("opengl32")]
    public static extern void glTexCoord4d(double s, double t, double r, double q);

    [DllImport("opengl32")]
    public static extern void glTexCoord4dv([In] double[] v);

    [DllImport("opengl32")]
    public static extern void glTexCoord4f(float s, float t, float r, float q);

    [DllImport("opengl32")]
    public static extern void glTexCoord4fv([In] float[] v);

    [DllImport("opengl32")]
    public static extern void glTexCoord4i(int s, int t, int r, int q);

    [DllImport("opengl32")]
    public static extern void glTexCoord4iv([In] int[] v);

    [DllImport("opengl32")]
    public static extern void glTexCoord4s(short s, short t, short r, short q);

    [DllImport("opengl32")]
    public static extern void glTexCoord4sv([In] short[] v);

    [DllImport("opengl32")]
    public static extern void glTexCoordPointer(
      int size,
      DataType dataType,
      int stride,
      [In] IntPtr pointer);

    [DllImport("opengl32")]
    public static extern void glTexEnvf(
      TextureEnvironmentTarget target,
      TextureEnvironmentParameterName pname,
      float param);

    [DllImport("opengl32", EntryPoint = "glTexEnvf")]
    public static extern void glTexEnvf_1(
      TextureEnvironmentTarget target,
      TextureEnvironmentParameterName pname,
      TextureEnvironmentMode param);

    [DllImport("opengl32")]
    public static extern void glTexEnvfv(
      TextureEnvironmentTarget target,
      TextureEnvironmentParameterName pname,
      [In] float[] parameters);

    [DllImport("opengl32")]
    public static extern void glTexEnvi(
      TextureEnvironmentTarget target,
      TextureEnvironmentParameterName pname,
      int param);

    [DllImport("opengl32", EntryPoint = "glTexEnvi")]
    public static extern void glTexEnvi_1(
      TextureEnvironmentTarget target,
      TextureEnvironmentParameterName pname,
      TextureEnvironmentMode param);

    [DllImport("opengl32")]
    public static extern void glTexEnviv(
      TextureEnvironmentTarget target,
      TextureEnvironmentParameterName pname,
      [In] int[] parameters);

    [DllImport("opengl32")]
    public static extern void glTexGend(
      TextureCoordName coord,
      TextureGenParameter pname,
      TextureGenMode param);

    [DllImport("opengl32")]
    public static extern void glTexGenf(
      TextureCoordName coord,
      TextureGenParameter pname,
      TextureGenMode param);

    [DllImport("opengl32")]
    public static extern void glTexGeni(
      TextureCoordName coord,
      TextureGenParameter pname,
      TextureGenMode param);

    [DllImport("opengl32", EntryPoint = "glTexGend")]
    public static extern void glTexGend_1(
      TextureCoordName coord,
      TextureGenParameter pname,
      double param);

    [DllImport("opengl32")]
    public static extern void glTexGendv(
      TextureCoordName coord,
      TextureGenParameter pname,
      [In] double[] parameters);

    [DllImport("opengl32", EntryPoint = "glTexGenf")]
    public static extern void glTexGenf_1(
      TextureCoordName coord,
      TextureGenParameter pname,
      float param);

    [DllImport("opengl32")]
    public static extern void glTexGenfv(
      TextureCoordName coord,
      TextureGenParameter pname,
      [In] float[] parameters);

    [DllImport("opengl32", EntryPoint = "glTexGeni")]
    public static extern void glTexGeni_1(
      TextureCoordName coord,
      TextureGenParameter pname,
      int param);

    [DllImport("opengl32")]
    public static extern void glTexGeniv(
      TextureCoordName coord,
      TextureGenParameter pname,
      [In] int[] parameters);

    [DllImport("opengl32")]
    public static extern void glTexImage1D(
      TextureTarget target,
      int level,
      PixelFormatInternal internalFormat,
      int width,
      int border,
      PixelFormat format,
      DataType dataType,
      [In] IntPtr pixels);

    [DllImport("opengl32")]
    public static extern void glTexImage2D(
      TextureTarget target,
      int level,
      PixelFormatInternal internalFormat,
      int width,
      int height,
      int border,
      PixelFormat format,
      DataType dataType,
      IntPtr pixels);

    [DllImport("opengl32", EntryPoint = "glTexImage2D")]
    public static extern void glTexImage2D_1(
      TextureTarget target,
      int level,
      PixelFormatInternal internalFormat,
      int width,
      int height,
      int border,
      PixelFormat format,
      DataType dataType,
      [In] byte[] pixels);

    [DllImport("opengl32")]
    public static extern void glTexParameterf(
      TextureTarget target,
      TextureParameterName pname,
      TextureWrapMode param);

    [DllImport("opengl32", EntryPoint = "glTexParameterf")]
    public static extern void glTexParameterf_1(
      TextureTarget target,
      TextureParameterName pname,
      TextureMagFilter param);

    [DllImport("opengl32", EntryPoint = "glTexParameterf")]
    public static extern void glTexParameterf_2(
      TextureTarget target,
      TextureParameterName pname,
      TextureMinFilter param);

    [DllImport("opengl32", EntryPoint = "glTexParameterf")]
    public static extern void glTexParameterf_3(
      TextureTarget target,
      TextureParameterName pname,
      ComparisonFunction param);

    [DllImport("opengl32", EntryPoint = "glTexParameterf")]
    public static extern void glTexParameterf_4(
      TextureTarget target,
      TextureParameterName pname,
      TextureCompareMode param);

    [DllImport("opengl32", EntryPoint = "glTexParameterf")]
    public static extern void glTexParameterf_5(
      TextureTarget target,
      TextureParameterName pname,
      DepthTextureMode param);

    [DllImport("opengl32", EntryPoint = "glTexParameterf")]
    public static extern void glTexParameterf_6(
      TextureTarget target,
      TextureParameterName pname,
      bool param);

    [DllImport("opengl32", EntryPoint = "glTexParameterf")]
    public static extern void glTexParameterf_7(
      TextureTarget target,
      TextureParameterName pname,
      float param);

    [DllImport("opengl32")]
    public static extern void glTexParameterfv(
      TextureTarget target,
      TextureParameterName pname,
      [In] float[] parameters);

    [DllImport("opengl32")]
    public static extern void glTexParameteri(
      TextureTarget target,
      TextureParameterName pname,
      TextureWrapMode param);

    [DllImport("opengl32", EntryPoint = "glTexParameteri")]
    public static extern void glTexParameteri_1(
      TextureTarget target,
      TextureParameterName pname,
      TextureMagFilter param);

    [DllImport("opengl32", EntryPoint = "glTexParameteri")]
    public static extern void glTexParameteri_2(
      TextureTarget target,
      TextureParameterName pname,
      TextureMinFilter param);

    [DllImport("opengl32", EntryPoint = "glTexParameteri")]
    public static extern void glTexParameteri_3(
      TextureTarget target,
      TextureParameterName pname,
      ComparisonFunction param);

    [DllImport("opengl32", EntryPoint = "glTexParameteri")]
    public static extern void glTexParameteri_4(
      TextureTarget target,
      TextureParameterName pname,
      TextureCompareMode param);

    [DllImport("opengl32", EntryPoint = "glTexParameteri")]
    public static extern void glTexParameteri_5(
      TextureTarget target,
      TextureParameterName pname,
      DepthTextureMode param);

    [DllImport("opengl32", EntryPoint = "glTexParameteri")]
    public static extern void glTexParameteri_6(
      TextureTarget target,
      TextureParameterName pname,
      bool param);

    [DllImport("opengl32", EntryPoint = "glTexParameteri")]
    public static extern void glTexParameteri_7(
      TextureTarget target,
      TextureParameterName pname,
      int param);

    [DllImport("opengl32")]
    public static extern void glTexParameteriv(
      TextureTarget target,
      TextureParameterName pname,
      [In] int[] parameters);

    [DllImport("opengl32")]
    public static extern void glTexSubImage1D(
      TextureTarget target,
      int level,
      int xoffset,
      int width,
      PixelFormat format,
      DataType dataType,
      [In] IntPtr pixels);

    [DllImport("opengl32")]
    public static extern void glTexSubImage2D(
      TextureTarget target,
      int level,
      int xoffset,
      int yoffset,
      int width,
      int height,
      PixelFormat format,
      DataType dataType,
      [In] IntPtr pixels);

    [DllImport("opengl32")]
    public static extern void glTranslated(double x, double y, double z);

    [DllImport("opengl32")]
    public static extern void glTranslatef(float x, float y, float z);

    [DllImport("opengl32")]
    public static extern void glVertex2d(double x, double y);

    [DllImport("opengl32")]
    public static extern void glVertex2dv([In] double[] v);

    [DllImport("opengl32")]
    public static extern void glVertex2f(float x, float y);

    [DllImport("opengl32")]
    public static extern void glVertex2fv([In] float[] v);

    [DllImport("opengl32")]
    public static extern void glVertex2i(int x, int y);

    [DllImport("opengl32")]
    public static extern void glVertex2iv([In] int[] v);

    [DllImport("opengl32")]
    public static extern void glVertex2s(short x, short y);

    [DllImport("opengl32")]
    public static extern void glVertex2sv([In] short[] v);

    [DllImport("opengl32")]
    public static extern void glVertex3d(double x, double y, double z);

    public static void Vertex3d(Point3D p)
    {
      GL.glVertex3d(p.X, p.Y, p.Z);
    }

    [DllImport("opengl32")]
    public static extern void glVertex3dv([In] double[] v);

    [DllImport("opengl32", EntryPoint = "glVertex3dv")]
    public static extern void glVertex3dv_1([In] ref Point3D p);

    [DllImport("opengl32")]
    public static extern void glVertex3f(float x, float y, float z);

    public static void Vertex3f(Point3F p)
    {
      GL.glVertex3f(p.X, p.Y, p.Z);
    }

    [DllImport("opengl32")]
    public static extern void glVertex3fv([In] float[] v);

    [DllImport("opengl32", EntryPoint = "glVertex3fv")]
    public static extern void glVertex3fv_1([In] ref Vector3F v);

    [DllImport("opengl32")]
    public static extern void glVertex3i(int x, int y, int z);

    [DllImport("opengl32")]
    public static extern void glVertex3iv([In] int[] v);

    [DllImport("opengl32")]
    public static extern void glVertex3s(short x, short y, short z);

    [DllImport("opengl32")]
    public static extern void glVertex3sv([In] short[] v);

    [DllImport("opengl32")]
    public static extern void glVertex4d(double x, double y, double z, double w);

    public static void Vertex4d(Vector4D v)
    {
      GL.glVertex4d(v.X, v.Y, v.Z, v.W);
    }

    [DllImport("opengl32")]
    public static extern void glVertex4dv([In] double[] v);

    [DllImport("opengl32", EntryPoint = "glVertex4dv")]
    public static extern void glVertex4dv_1([In] ref Vector4D v);

    [DllImport("opengl32")]
    public static extern void glVertex4f(float x, float y, float z, float w);

    public static void Vertex4f(Vector4F v)
    {
      GL.glVertex4f(v.X, v.Y, v.Z, v.W);
    }

    [DllImport("opengl32")]
    public static extern void glVertex4fv([In] float[] v);

    [DllImport("opengl32", EntryPoint = "glVertex4fv")]
    public static extern void glVertex4fv_1([In] ref Vector4F v);

    [DllImport("opengl32")]
    public static extern void glVertex4i(int x, int y, int z, int w);

    [DllImport("opengl32")]
    public static extern void glVertex4iv([In] int[] v);

    [DllImport("opengl32")]
    public static extern void glVertex4s(short x, short y, short z, short w);

    [DllImport("opengl32")]
    public static extern void glVertex4sv([In] short[] v);

    [DllImport("opengl32")]
    public static extern void glVertexPointer(
      int size,
      DataType dataType,
      int stride,
      IntPtr pointer);

    [DllImport("opengl32", EntryPoint = "glVertexPointer")]
    public static extern void glVertexPointer_1(
      int size,
      DataType dataType,
      int stride,
      double[] vertices);

    [DllImport("opengl32")]
    public static extern void glViewport(int x, int y, int width, int height);

    public static bool IsExtensionSupported(string extension)
    {
      GL.smethod_0();
      return GL.stringDictionary_0.ContainsKey(extension);
    }

    private static void smethod_0()
    {
      if (GL.stringDictionary_0 != null)
        return;
      string[] strArray = GL.GetString(StringName.Extensions).Split(new char[1]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
      GL.stringDictionary_0 = new StringDictionary();
      foreach (string key in strArray)
        GL.stringDictionary_0.Add(key, string.Empty);
    }

    public static string[] GetSupportedExtensions()
    {
      GL.smethod_0();
      List<string> stringList = new List<string>();
      foreach (string key in (IEnumerable) GL.stringDictionary_0.Keys)
        stringList.Add(key);
      stringList.Sort();
      return stringList.ToArray();
    }
  }
}
