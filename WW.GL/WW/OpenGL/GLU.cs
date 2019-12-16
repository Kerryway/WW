// Decompiled with JetBrains decompiler
// Type: WW.OpenGL.GLU
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using System;
using System.Runtime.InteropServices;
using System.Security;
using WW.Math;

namespace WW.OpenGL
{
  [SecuritySafeCritical]
  [SuppressUnmanagedCodeSecurity]
  public class GLU
  {
    public const string GLUDll = "glu32";
    public const uint Version_1_1 = 1;
    public const uint Version_1_2 = 1;
    public const double TessellationMaxCoord = 1E+150;

    [DllImport("glu32")]
    [return: MarshalAs(UnmanagedType.LPStr)]
    public static extern string gluErrorString(uint errCode);

    [DllImport("glu32", EntryPoint = "gluErrorString")]
    [return: MarshalAs(UnmanagedType.LPStr)]
    public static extern string gluErrorString_1(GLUErrorCode errCode);

    [DllImport("glu32", EntryPoint = "gluErrorString")]
    [return: MarshalAs(UnmanagedType.LPStr)]
    public static extern string gluErrorString_2(TessellationErrorCode errCode);

    [DllImport("glu32", EntryPoint = "gluErrorString")]
    [return: MarshalAs(UnmanagedType.LPStr)]
    public static extern string gluErrorString_3(NurbsErrorCode errCode);

    [DllImport("glu32")]
    public static extern IntPtr gluGetString(GLUStringName name);

    public static string GetString(GLUStringName name)
    {
      return Marshal.PtrToStringAnsi(GLU.gluGetString(name));
    }

    [DllImport("glu32")]
    public static extern void gluOrtho2D(double left, double right, double bottom, double top);

    [DllImport("glu32")]
    public static extern void gluPerspective(
      double fovy,
      double aspect,
      double zNear,
      double zFar);

    [DllImport("glu32")]
    public static extern void gluPickMatrix(
      double x,
      double y,
      double width,
      double height,
      [In] int[] viewport);

    [DllImport("glu32")]
    public static extern void gluLookAt(
      double eyex,
      double eyey,
      double eyez,
      double centerx,
      double centery,
      double centerz,
      double upx,
      double upy,
      double upz);

    [DllImport("glu32")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool gluProject(
      double objx,
      double objy,
      double objz,
      [In] double[] modelMatrix,
      [In] double[] projectionMatrix,
      [In] int[] viewport,
      out double winx,
      out double winy,
      out double winz);

    [DllImport("glu32", EntryPoint = "gluProject")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool gluProject_1(
      double objx,
      double objy,
      double objz,
      [In] ref Matrix4D modelMatrix,
      [In] ref Matrix4D projectionMatrix,
      [In] int[] viewport,
      out double winx,
      out double winy,
      out double winz);

    [DllImport("glu32")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool gluUnProject(
      double winx,
      double winy,
      double winz,
      [In] double[] modelMatrix,
      [In] double[] projectionMatrix,
      [In] int[] viewport,
      out double objx,
      out double objy,
      out double objz);

    [DllImport("glu32", EntryPoint = "gluUnProject")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool gluUnProject_1(
      double winx,
      double winy,
      double winz,
      [In] ref Matrix4D modelMatrix,
      [In] ref Matrix4D projectionMatrix,
      [In] int[] viewport,
      out double objx,
      out double objy,
      out double objz);

    [DllImport("glu32")]
    public static extern int gluScaleImage(
      PixelFormat format,
      int widthIn,
      int heightIn,
      DataType typeIn,
      IntPtr dataIn,
      int widthOut,
      int heightOut,
      DataType typeOut,
      IntPtr dataOut);

    [DllImport("glu32")]
    public static extern int gluBuild1DMipmaps(
      TextureTarget target,
      int components,
      int width,
      PixelFormat format,
      DataType type,
      IntPtr data);

    [DllImport("glu32")]
    public static extern int gluBuild2DMipmaps(
      TextureTarget target,
      int components,
      int width,
      int height,
      PixelFormat format,
      DataType type,
      IntPtr data);

    [DllImport("glu32", EntryPoint = "gluBuild2DMipmaps")]
    public static extern int gluBuild2DMipmaps_1(
      TextureTarget target,
      int components,
      int width,
      int height,
      PixelFormat format,
      DataType type,
      [In] byte[] data);

    [DllImport("glu32")]
    public static extern IntPtr gluNewQuadric();

    [DllImport("glu32")]
    public static extern void gluDeleteQuadric(IntPtr state);

    [DllImport("glu32")]
    public static extern void gluQuadricNormals(IntPtr quadObject, QuadricNormal normals);

    [DllImport("glu32")]
    public static extern void gluQuadricTexture(IntPtr quadObject, [MarshalAs(UnmanagedType.U1)] bool textureCoords);

    [DllImport("glu32")]
    public static extern void gluQuadricOrientation(
      IntPtr quadObject,
      QuadricOrientation orientation);

    [DllImport("glu32")]
    public static extern void gluQuadricDrawStyle(IntPtr quadObject, QuadricDrawStyle drawStyle);

    [DllImport("glu32")]
    public static extern void gluCylinder(
      IntPtr qobj,
      double baseRadius,
      double topRadius,
      double height,
      int slices,
      int stacks);

    [DllImport("glu32")]
    public static extern void gluDisk(
      IntPtr qobj,
      double innerRadius,
      double outerRadius,
      int slices,
      int loops);

    [DllImport("glu32")]
    public static extern void gluPartialDisk(
      IntPtr qobj,
      double innerRadius,
      double outerRadius,
      int slices,
      int loops,
      double startAngle,
      double sweepAngle);

    [DllImport("glu32")]
    public static extern void gluSphere(IntPtr qobj, double radius, int slices, int stacks);

    [DllImport("glu32")]
    public static extern void gluQuadricCallback(
      IntPtr qobj,
      CallbackType which,
      GLU.ErrorDelegate callback);

    [DllImport("glu32")]
    public static extern IntPtr gluNewTess();

    [DllImport("glu32")]
    public static extern void gluDeleteTess(IntPtr tess);

    [DllImport("glu32")]
    public static extern void gluTessBeginPolygon(IntPtr tess, IntPtr polygonData);

    [DllImport("glu32")]
    public static extern void gluTessBeginContour(IntPtr tess);

    [DllImport("glu32")]
    public static extern void gluTessVertex(IntPtr tess, [In] double[] coords, IntPtr data);

    [DllImport("glu32", EntryPoint = "gluTessVertex")]
    public static extern void gluTessVertex_1(IntPtr tess, IntPtr coords, IntPtr data);

    [DllImport("glu32")]
    public static extern void gluTessEndContour(IntPtr tess);

    [DllImport("glu32")]
    public static extern void gluTessEndPolygon(IntPtr tess);

    [DllImport("glu32")]
    public static extern void gluTessProperty(
      IntPtr tess,
      TessellationProperty which,
      double value);

    [DllImport("glu32", EntryPoint = "gluTessProperty")]
    public static extern void gluTessProperty_1(
      IntPtr tess,
      TessellationProperty which,
      TessellationWinding value);

    [DllImport("glu32")]
    public static extern void gluTessNormal(IntPtr tess, double x, double y, double z);

    [DllImport("glu32")]
    public static extern void gluTessCallback(
      IntPtr tess,
      TessellationCallbackType which,
      IntPtr fn);

    [DllImport("glu32", EntryPoint = "gluTessCallback")]
    public static extern void gluTessCallback_1(
      IntPtr tess,
      TessellationCallbackType which,
      GLU.TessellationBeginDelegate callback);

    [DllImport("glu32", EntryPoint = "gluTessCallback")]
    public static extern void gluTessCallback_2(
      IntPtr tess,
      TessellationCallbackType which,
      GLU.TessellationVertex3dvDelegate callback);

    [DllImport("glu32", EntryPoint = "gluTessCallback")]
    public static extern void gluTessCallback_3(
      IntPtr tess,
      TessellationCallbackType which,
      GLU.TessellationVertexDelegate callback);

    [DllImport("glu32", EntryPoint = "gluTessCallback")]
    public static extern void gluTessCallback_4(
      IntPtr tess,
      TessellationCallbackType which,
      GLU.TessellationEndDelegate callback);

    [DllImport("glu32", EntryPoint = "gluTessCallback")]
    public static extern void gluTessCallback_5(
      IntPtr tess,
      TessellationCallbackType which,
      GLU.TessellationErrorDelegate callback);

    [DllImport("glu32", EntryPoint = "gluTessCallback")]
    public static extern void gluTessCallback_6(
      IntPtr tess,
      TessellationCallbackType which,
      GLU.TessellationEdgeFlagDelegate callback);

    [DllImport("glu32", EntryPoint = "gluTessCallback")]
    public static extern void gluTessCallback_7(
      IntPtr tess,
      TessellationCallbackType which,
      GLU.TessellationCombineDelegate callback);

    [DllImport("glu32", EntryPoint = "gluTessCallback")]
    public static extern void gluTessCallback_8(
      IntPtr tess,
      TessellationCallbackType which,
      GLU.TessellationBeginDataDelegate callback);

    [DllImport("glu32", EntryPoint = "gluTessCallback")]
    public static extern void gluTessCallback_9(
      IntPtr tess,
      TessellationCallbackType which,
      GLU.TessellationVertex3dvDataDelegate callback);

    [DllImport("glu32", EntryPoint = "gluTessCallback")]
    public static extern void gluTessCallback_10(
      IntPtr tess,
      TessellationCallbackType which,
      GLU.TessellationVertexDataDelegate callback);

    [DllImport("glu32", EntryPoint = "gluTessCallback")]
    public static extern void gluTessCallback_11(
      IntPtr tess,
      TessellationCallbackType which,
      GLU.TessellationEndDataDelegate callback);

    [DllImport("glu32", EntryPoint = "gluTessCallback")]
    public static extern void gluTessCallback_12(
      IntPtr tess,
      TessellationCallbackType which,
      GLU.TessellationErrorDataDelegate callback);

    [DllImport("glu32", EntryPoint = "gluTessCallback")]
    public static extern void gluTessCallback_13(
      IntPtr tess,
      TessellationCallbackType which,
      GLU.TessellationEdgeFlagDataDelegate callback);

    [DllImport("glu32", EntryPoint = "gluTessCallback")]
    public static extern void gluTessCallback_14(
      IntPtr tess,
      TessellationCallbackType which,
      GLU.TessellationCombineDataDelegate callback);

    [DllImport("glu32")]
    public static extern void gluGetTessProperty(
      IntPtr tess,
      TessellationProperty which,
      out double value);

    [DllImport("glu32", EntryPoint = "gluGetTessProperty")]
    public static extern void gluGetTessProperty_1(
      IntPtr tess,
      TessellationProperty which,
      out TessellationWinding value);

    [DllImport("glu32", EntryPoint = "gluGetTessProperty")]
    public static extern void gluGetTessProperty_2(
      IntPtr tess,
      TessellationProperty which,
      [MarshalAs(UnmanagedType.U8)] out bool value);

    [DllImport("glu32")]
    public static extern IntPtr gluNewNurbsRenderer();

    [DllImport("glu32")]
    public static extern void gluDeleteNurbsRenderer(IntPtr nobj);

    [DllImport("glu32")]
    public static extern void gluBeginSurface(IntPtr nobj);

    [DllImport("glu32")]
    public static extern void gluBeginCurve(IntPtr nobj);

    [DllImport("glu32")]
    public static extern void gluEndCurve(IntPtr nobj);

    [DllImport("glu32")]
    public static extern void gluEndSurface(IntPtr nobj);

    [DllImport("glu32")]
    public static extern void gluBeginTrim(IntPtr nobj);

    [DllImport("glu32")]
    public static extern void gluEndTrim(IntPtr nobj);

    [DllImport("glu32")]
    public static extern void gluPwlCurve(
      IntPtr nobj,
      int count,
      [In] float[] array,
      int stride,
      NurbsTrim type);

    [DllImport("glu32")]
    public static extern void gluNurbsCurve(
      IntPtr nobj,
      int nknots,
      [In] float[] knot,
      int stride,
      [In] float[] ctlarray,
      int order,
      NurbsTrim type);

    [DllImport("glu32", EntryPoint = "gluNurbsCurve")]
    public static extern void gluNurbsCurve_1(
      IntPtr nobj,
      int nknots,
      [In] float[] knot,
      int stride,
      [In] float[] ctlarray,
      int order,
      MapTarget type);

    [DllImport("glu32")]
    public static extern void gluNurbsSurface(
      IntPtr nobj,
      int sKnotCount,
      [In] float[] sKnots,
      int tKnotCount,
      [In] float[] tKnots,
      int sStride,
      int tStride,
      [In] float[] ctlArray,
      int sOrder,
      int tOrder,
      MapTarget type);

    [DllImport("glu32")]
    public static extern void gluLoadSamplingMatrices(
      IntPtr nobj,
      [In] float[] modelMatrix,
      [In] float[] projMatrix,
      [In] int[] viewport);

    [DllImport("glu32", EntryPoint = "gluLoadSamplingMatrices")]
    public static extern void gluLoadSamplingMatrices_1(
      IntPtr nobj,
      [In] ref Matrix4F modelMatrix,
      [In] ref Matrix4F projMatrix,
      [In] int[] viewport);

    [DllImport("glu32")]
    public static extern void gluNurbsProperty(IntPtr nobj, NurbsProperty property, float value);

    [DllImport("glu32", EntryPoint = "gluNurbsProperty")]
    public static extern void gluNurbsProperty_1(
      IntPtr nobj,
      NurbsProperty property,
      NurbsSampling value);

    [DllImport("glu32", EntryPoint = "gluNurbsProperty")]
    public static extern void gluNurbsProperty_2(
      IntPtr nobj,
      NurbsProperty property,
      NurbsDisplay value);

    [DllImport("glu32", EntryPoint = "gluNurbsProperty")]
    public static extern void gluNurbsProperty_3(IntPtr nobj, NurbsProperty property, [MarshalAs(UnmanagedType.Bool)] bool value);

    [DllImport("glu32")]
    public static extern void gluGetNurbsProperty(
      IntPtr nobj,
      NurbsProperty property,
      [Out] float[] value);

    [DllImport("glu32")]
    public static extern void gluNurbsCallback(
      IntPtr nobj,
      CallbackType which,
      GLU.ErrorDelegate callback);

    [DllImport("glu32")]
    public static extern void gluBeginPolygon(IntPtr tess);

    [DllImport("glu32")]
    public static extern void gluNextContour(IntPtr tess, ContourType type);

    [DllImport("glu32")]
    public static extern void gluEndPolygon(IntPtr tess);

    public delegate void ErrorDelegate(uint errorCode);

    public delegate void TessellationBeginDelegate(Mode mode);

    public delegate void TessellationVertex3dvDelegate([MarshalAs(UnmanagedType.LPArray, SizeConst = 3), In] double[] data);

    public delegate void TessellationVertexDelegate(IntPtr data);

    public delegate void TessellationEndDelegate();

    public delegate void TessellationErrorDelegate(TessellationErrorCode errorCode);

    public delegate void TessellationEdgeFlagDelegate([MarshalAs(UnmanagedType.U1)] bool edgeFlag);

    public delegate void TessellationCombineDelegate(
      [MarshalAs(UnmanagedType.LPArray, SizeConst = 3), In] double[] coords,
      [MarshalAs(UnmanagedType.LPArray, SizeConst = 4), In] IntPtr[] data,
      [MarshalAs(UnmanagedType.LPArray, SizeConst = 4), In] float[] weight,
      out IntPtr dataOut);

    public delegate void TessellationBeginDataDelegate(Mode mode, IntPtr polygonData);

    public delegate void TessellationVertex3dvDataDelegate([MarshalAs(UnmanagedType.LPArray, SizeConst = 3), In] double[] data, IntPtr polygonData);

    public delegate void TessellationVertexDataDelegate(IntPtr data, IntPtr polygonData);

    public delegate void TessellationEndDataDelegate(IntPtr polygonData);

    public delegate void TessellationErrorDataDelegate(
      TessellationErrorCode errorCode,
      IntPtr polygonData);

    public delegate void TessellationEdgeFlagDataDelegate([MarshalAs(UnmanagedType.U1)] bool edgeFlag, IntPtr polygonData);

    public delegate void TessellationCombineDataDelegate(
      [MarshalAs(UnmanagedType.LPArray, SizeConst = 3), In] double[] coords,
      [MarshalAs(UnmanagedType.LPArray, SizeConst = 4), In] IntPtr[] data,
      [MarshalAs(UnmanagedType.LPArray, SizeConst = 4), In] float[] weight,
      out IntPtr dataOut,
      IntPtr polygonData);
  }
}
