// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.ProxyGraphics
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns2;
using ns28;
using ns3;
using ns33;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using WW.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.IO;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;
using WW.Cad.Model.Text;
using WW.Math;
using WW.Math.Geometry;
using WW.Text;

namespace WW.Cad.Model
{
  public class ProxyGraphics : IGraphCloneable
  {
    private static Func<ProxyGraphics.DrawCommand>[] func_0 = new Func<ProxyGraphics.DrawCommand>[39]{ new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_0), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_1), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.CreateCircle), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_2), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_3), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_4), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.CreatePolyline), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_5), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_6), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_7), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.CreateText), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_8), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.CreateXLine), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.CreateRay), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_9), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_10), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_11), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_12), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_13), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_14), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_15), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_16), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_17), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_18), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_19), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_20), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_21), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_22), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_23), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_24), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_25), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_26), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_27), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_28), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_29), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_30), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_31), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_32), new Func<ProxyGraphics.DrawCommand>(ProxyGraphics.smethod_33) };
    private readonly List<ProxyGraphics.DrawCommand> list_0 = new List<ProxyGraphics.DrawCommand>();
    internal const int int_0 = 4096;

    public IList<ProxyGraphics.DrawCommand> DrawCommands
    {
      get
      {
        return (IList<ProxyGraphics.DrawCommand>) this.list_0;
      }
    }

    public void Draw(
      DxfEntity entity,
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      new ProxyGraphics.WireframeGraphicsFactoryDrawer(entity, context, this).Draw(graphicsFactory);
    }

    public void Draw(
      DxfEntity entity,
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      new ProxyGraphics.WireframeGraphicsFactoryDrawer(entity, context, this).Draw(graphicsFactory);
    }

    public void TransformMe(TransformConfig config, Matrix4D matrix, CommandGroup undoGroup)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      ProxyGraphics.Class791 class791 = new ProxyGraphics.Class791();
      // ISSUE: reference to a compiler-generated field
      class791.proxyGraphics_0 = this;
      // ISSUE: reference to a compiler-generated field
      class791.pushModelTransformMatrix_0 = (ProxyGraphics.PushModelTransformMatrix) null;
      ProxyGraphics.PopModelTransform popModelTransform1 = (ProxyGraphics.PopModelTransform) null;
      int index;
      for (index = 0; index < this.list_0.Count; ++index)
      {
        ProxyGraphics.DrawCommand drawCommand = this.list_0[index];
        // ISSUE: reference to a compiler-generated field
        class791.pushModelTransformMatrix_0 = drawCommand as ProxyGraphics.PushModelTransformMatrix;
        // ISSUE: reference to a compiler-generated field
        if (class791.pushModelTransformMatrix_0 == null)
        {
          if (drawCommand.HasGeometricData)
            break;
        }
        else
        {
          ++index;
          break;
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (class791.pushModelTransformMatrix_0 != null)
      {
        int num = 1;
        for (; index < this.list_0.Count; ++index)
        {
          ProxyGraphics.DrawCommand drawCommand = this.list_0[index];
          if (drawCommand is ProxyGraphics.PushModelTransformMatrix || drawCommand is ProxyGraphics.PushModelTransformFromVector)
            ++num;
          ProxyGraphics.PopModelTransform popModelTransform2 = drawCommand as ProxyGraphics.PopModelTransform;
          if (popModelTransform2 != null)
          {
            --num;
            if (num == 0)
            {
              popModelTransform1 = popModelTransform2;
              ++index;
              break;
            }
          }
        }
        if (popModelTransform1 != null)
        {
          for (; index < this.list_0.Count; ++index)
          {
            if (this.list_0[index].HasGeometricData)
            {
              // ISSUE: reference to a compiler-generated field
              class791.pushModelTransformMatrix_0 = (ProxyGraphics.PushModelTransformMatrix) null;
              break;
            }
          }
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (class791.pushModelTransformMatrix_0 == null)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ProxyGraphics.Class792 class792 = new ProxyGraphics.Class792();
        // ISSUE: reference to a compiler-generated field
        class792.class791_0 = class791;
        // ISSUE: reference to a compiler-generated field
        class792.pushModelTransformMatrix_0 = new ProxyGraphics.PushModelTransformMatrix()
        {
          ModelTransform = matrix
        };
        // ISSUE: reference to a compiler-generated field
        class792.popModelTransform_0 = new ProxyGraphics.PopModelTransform();
        // ISSUE: reference to a compiler-generated field
        this.list_0.Insert(0, (ProxyGraphics.DrawCommand) class792.pushModelTransformMatrix_0);
        // ISSUE: reference to a compiler-generated field
        this.list_0.Add((ProxyGraphics.DrawCommand) class792.popModelTransform_0);
        // ISSUE: reference to a compiler-generated method
        undoGroup?.UndoStack.Push((ICommand) new Command(new System.Action(class792.method_0), (System.Action) (() =>
        {
          this.list_0.RemoveAt(this.list_0.Count - 1);
          this.list_0.RemoveAt(0);
        })));
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ProxyGraphics.Class793 class793 = new ProxyGraphics.Class793() { class791_0 = class791, matrix4D_0 = class791.pushModelTransformMatrix_0.ModelTransform };
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        class793.matrix4D_1 = class793.matrix4D_0 * matrix;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        class791.pushModelTransformMatrix_0.ModelTransform = class793.matrix4D_1;
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup?.UndoStack.Push((ICommand) new Command(new System.Action(class793.method_0), new System.Action(class793.method_1)));
      }
    }

    public IGraphCloneable Clone(CloneContext context)
    {
      ProxyGraphics proxyGraphics = (ProxyGraphics) context.GetExistingClone((IGraphCloneable) this);
      if (proxyGraphics == null)
      {
        proxyGraphics = new ProxyGraphics();
        context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) proxyGraphics);
        proxyGraphics.CopyFrom(context, this);
      }
      return (IGraphCloneable) proxyGraphics;
    }

    public void CopyFrom(CloneContext context, ProxyGraphics from)
    {
      this.list_0.Clear();
      foreach (ProxyGraphics.DrawCommand drawCommand in from.list_0)
        this.list_0.Add((ProxyGraphics.DrawCommand) drawCommand.Clone(context));
    }

    internal ProxyGraphics.Class758 Read(Stream stream, Class374 modelBuilder)
    {
      ProxyGraphics.Class758 builder = new ProxyGraphics.Class758();
      stream.Position = 0L;
      if (stream.Length > 0L)
      {
        ProxyGraphics.smethod_39(stream);
        ProxyGraphics.smethod_39(stream);
        while (stream.Position < stream.Length)
        {
          long num = stream.Position + (long) ProxyGraphics.smethod_39(stream);
          int index = ProxyGraphics.smethod_39(stream);
          if (index < ProxyGraphics.func_0.Length)
          {
            ProxyGraphics.DrawCommand drawCommand = ProxyGraphics.func_0[index]();
            drawCommand.Read(this, stream, Encodings.GetEncoding((int) modelBuilder.Model.Header.DrawingCodePage), modelBuilder, builder);
            this.list_0.Add(drawCommand);
          }
          if (stream.Position != num)
          {
            if (stream.Position > num)
              throw new Exception("Illegal graphics command.");
            stream.Position = num;
          }
        }
      }
      return builder;
    }

    internal void Write(Stream stream, DxfModel model)
    {
      long position1 = stream.Position;
      ProxyGraphics.smethod_60(stream, 0);
      int num = 0;
      foreach (ProxyGraphics.DrawCommand drawCommand in this.list_0)
      {
        if (drawCommand.CanWrite)
          ++num;
      }
      ProxyGraphics.smethod_60(stream, num);
      foreach (ProxyGraphics.DrawCommand drawCommand in this.list_0)
      {
        long position2 = stream.Position;
        ProxyGraphics.smethod_60(stream, 0);
        ProxyGraphics.smethod_60(stream, (int) drawCommand.DrawCommandCode);
        drawCommand.Write(this, stream, Encodings.GetEncoding((int) model.Header.DrawingCodePage), model);
        long position3 = stream.Position;
        stream.Position = position2;
        ProxyGraphics.smethod_60(stream, (int) (position3 - position2));
        stream.Position = position3;
      }
      long position4 = stream.Position;
      stream.Position = position1;
      ProxyGraphics.smethod_60(stream, (int) (position4 - position1));
      stream.Position = position4;
    }

    private static ProxyGraphics.DrawCommand smethod_0()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.Unknown0();
    }

    private static ProxyGraphics.DrawCommand smethod_1()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.Extents();
    }

    private static ProxyGraphics.DrawCommand CreateCircle()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.Circle();
    }

    private static ProxyGraphics.DrawCommand smethod_2()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.Circle3Point();
    }

    private static ProxyGraphics.DrawCommand smethod_3()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.CircleArc();
    }

    private static ProxyGraphics.DrawCommand smethod_4()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.CircleArc3Point();
    }

    private static ProxyGraphics.DrawCommand CreatePolyline()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.Polyline();
    }

    private static ProxyGraphics.DrawCommand smethod_5()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.Polygon();
    }

    private static ProxyGraphics.DrawCommand smethod_6()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.Mesh();
    }

    private static ProxyGraphics.DrawCommand smethod_7()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.Shell();
    }

    private static ProxyGraphics.DrawCommand CreateText()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.Text();
    }

    private static ProxyGraphics.DrawCommand smethod_8()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.Text2();
    }

    private static ProxyGraphics.DrawCommand CreateXLine()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.XLine();
    }

    private static ProxyGraphics.DrawCommand CreateRay()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.Ray();
    }

    private static ProxyGraphics.DrawCommand smethod_9()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.SetSubEntityColor();
    }

    private static ProxyGraphics.DrawCommand smethod_10()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.Unknown15();
    }

    private static ProxyGraphics.DrawCommand smethod_11()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.SetSubEntityLayer();
    }

    private static ProxyGraphics.DrawCommand smethod_12()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.Unknown17();
    }

    private static ProxyGraphics.DrawCommand smethod_13()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.SetSubEntityLineType();
    }

    private static ProxyGraphics.DrawCommand smethod_14()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.SetSubEntitySelectionMarker();
    }

    private static ProxyGraphics.DrawCommand smethod_15()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.SetSubEntityFillOn();
    }

    private static ProxyGraphics.DrawCommand smethod_16()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.Unknown21();
    }

    private static ProxyGraphics.DrawCommand smethod_17()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.SetSubEntityTrueColor();
    }

    private static ProxyGraphics.DrawCommand smethod_18()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.SetSubEntityLineWeight();
    }

    private static ProxyGraphics.DrawCommand smethod_19()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.SetSubEntityLineTypeScale();
    }

    private static ProxyGraphics.DrawCommand smethod_20()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.SetSubEntityThickness();
    }

    private static ProxyGraphics.DrawCommand smethod_21()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.SetSubEntityPlotStyleName();
    }

    private static ProxyGraphics.DrawCommand smethod_22()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.PushClip();
    }

    private static ProxyGraphics.DrawCommand smethod_23()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.PopClip();
    }

    private static ProxyGraphics.DrawCommand smethod_24()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.PushModelTransformMatrix();
    }

    private static ProxyGraphics.DrawCommand smethod_25()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.PushModelTransformFromVector();
    }

    private static ProxyGraphics.DrawCommand smethod_26()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.PopModelTransform();
    }

    private static ProxyGraphics.DrawCommand smethod_27()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.PolylineWithNormal();
    }

    private static ProxyGraphics.DrawCommand smethod_28()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.LwPolyline();
    }

    private static ProxyGraphics.DrawCommand smethod_29()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.SetSubEntityMaterial();
    }

    private static ProxyGraphics.DrawCommand smethod_30()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.SetSubEntityMapper();
    }

    private static ProxyGraphics.DrawCommand smethod_31()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.UnicodeText();
    }

    private static ProxyGraphics.DrawCommand smethod_32()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.Unknown37();
    }

    private static ProxyGraphics.DrawCommand smethod_33()
    {
      return (ProxyGraphics.DrawCommand) new ProxyGraphics.UnicodeText2();
    }

    internal static bool smethod_34(Stream stream)
    {
      return ProxyGraphics.smethod_39(stream) != 0;
    }

    internal static byte smethod_35(Stream stream)
    {
      return Class1045.smethod_2(stream);
    }

    internal static byte[] smethod_36(Stream stream, int n)
    {
      byte[] buffer = new byte[n];
      if (stream.Read(buffer, 0, n) < n)
        throw new Exception("Couldn't read " + (object) n + " bytes from stream.");
      return buffer;
    }

    internal static short smethod_37(Stream stream)
    {
      return Class1045.smethod_3(stream);
    }

    internal static ushort smethod_38(Stream stream)
    {
      return Class1045.smethod_5(stream);
    }

    internal static int smethod_39(Stream stream)
    {
      return Class1045.smethod_7(stream);
    }

    internal static uint smethod_40(Stream stream)
    {
      return Class1045.smethod_10(stream);
    }

    internal static long smethod_41(Stream stream)
    {
      return Class1045.smethod_12(stream);
    }

    internal static ulong smethod_42(Stream stream)
    {
      return Class1045.smethod_14(stream);
    }

    internal static ulong smethod_43(Stream stream)
    {
      return ProxyGraphics.smethod_42(stream);
    }

    internal static double smethod_44(Stream stream)
    {
      return Class1045.smethod_8(stream);
    }

    internal static WW.Math.Point2D smethod_45(Stream stream)
    {
      return new WW.Math.Point2D(ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream));
    }

    internal static WW.Math.Point3D smethod_46(Stream stream)
    {
      return new WW.Math.Point3D(ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream));
    }

    internal static Vector2D smethod_47(Stream stream)
    {
      return new Vector2D(ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream));
    }

    internal static Vector3D smethod_48(Stream stream)
    {
      return new Vector3D(ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream));
    }

    internal static Matrix4D smethod_49(Stream stream)
    {
      return new Matrix4D(ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream), ProxyGraphics.smethod_44(stream));
    }

    internal static ProxyGraphics.GraphicPropertyFlags smethod_50(Stream stream)
    {
      if (stream.Position >= stream.Length)
        return (ProxyGraphics.GraphicPropertyFlags) 0;
      return (ProxyGraphics.GraphicPropertyFlags) ProxyGraphics.smethod_39(stream);
    }

    internal static string smethod_51(Stream stream, Encoding encoding)
    {
      if (stream.Position >= stream.Length)
        return string.Empty;
      long position = stream.Position;
      List<byte> byteList = new List<byte>(10);
      for (byte index = ProxyGraphics.smethod_35(stream); index != (byte) 0 && stream.Position < stream.Length; index = ProxyGraphics.smethod_35(stream))
        byteList.Add(index);
      ProxyGraphics.smethod_54(stream, position);
      if (byteList.Count <= 0)
        return string.Empty;
      return encoding.GetString(byteList.ToArray());
    }

    internal static byte[] smethod_52(Stream stream)
    {
      long position = stream.Position;
      List<byte> byteList = new List<byte>(10);
      for (byte index = ProxyGraphics.smethod_35(stream); index != (byte) 0 && stream.Position < stream.Length; index = ProxyGraphics.smethod_35(stream))
        byteList.Add(index);
      ProxyGraphics.smethod_54(stream, position);
      return byteList.ToArray();
    }

    internal static int smethod_53(int n)
    {
      return 3 - (n - 1) % 4;
    }

    internal static void smethod_54(Stream stream, long streamObjectStartPosition)
    {
      int num1 = ProxyGraphics.smethod_53((int) (stream.Position - streamObjectStartPosition));
      for (int index = 0; index < num1; ++index)
      {
        int num2 = (int) ProxyGraphics.smethod_35(stream);
      }
    }

    internal static string ReadString(Stream stream)
    {
      if (stream.Position >= stream.Length)
        return string.Empty;
      long position = stream.Position;
      List<byte> byteList = new List<byte>(10);
      byte num1 = ProxyGraphics.smethod_35(stream);
      byte num2 = ProxyGraphics.smethod_35(stream);
      while ((num1 != (byte) 0 || num1 != (byte) 0) && stream.Position < stream.Length)
      {
        byteList.Add(num1);
        byteList.Add(num2);
        num1 = ProxyGraphics.smethod_35(stream);
        num2 = ProxyGraphics.smethod_35(stream);
      }
      ProxyGraphics.smethod_54(stream, position);
      if (byteList.Count <= 0)
        return string.Empty;
      return Encoding.Unicode.GetString(byteList.ToArray());
    }

    internal static void smethod_55(Stream stream, bool value)
    {
      ProxyGraphics.smethod_60(stream, value ? 1 : 0);
    }

    internal static void smethod_56(Stream stream, byte value)
    {
      stream.WriteByte(value);
    }

    internal static void smethod_57(Stream stream, byte[] buffer, int offset, int count)
    {
      stream.Write(buffer, offset, count);
    }

    internal static void smethod_58(Stream stream, short value)
    {
      Class1045.smethod_4(stream, value);
    }

    internal static void smethod_59(Stream stream, ushort value)
    {
      Class1045.smethod_6(stream, value);
    }

    internal static void smethod_60(Stream stream, int value)
    {
      Class1045.smethod_9(stream, value);
    }

    internal static void smethod_61(Stream stream, uint value)
    {
      Class1045.smethod_11(stream, value);
    }

    internal static void smethod_62(Stream stream, long value)
    {
      Class1045.smethod_13(stream, value);
    }

    internal static void smethod_63(Stream stream, ulong value)
    {
      Class1045.smethod_15(stream, value);
    }

    internal static void smethod_64(Stream stream, ulong value)
    {
      ProxyGraphics.smethod_63(stream, value);
    }

    internal static void smethod_65(Stream stream, double value)
    {
      Class1045.smethod_16(stream, value);
    }

    internal static void smethod_66(Stream stream, WW.Math.Point2D value)
    {
      ProxyGraphics.smethod_65(stream, value.X);
      ProxyGraphics.smethod_65(stream, value.Y);
    }

    internal static void smethod_67(Stream stream, WW.Math.Point3D value)
    {
      ProxyGraphics.smethod_65(stream, value.X);
      ProxyGraphics.smethod_65(stream, value.Y);
      ProxyGraphics.smethod_65(stream, value.Z);
    }

    internal static void smethod_68(Stream stream, Vector2D value)
    {
      ProxyGraphics.smethod_65(stream, value.X);
      ProxyGraphics.smethod_65(stream, value.Y);
    }

    internal static void smethod_69(Stream stream, Vector3D value)
    {
      ProxyGraphics.smethod_65(stream, value.X);
      ProxyGraphics.smethod_65(stream, value.Y);
      ProxyGraphics.smethod_65(stream, value.Z);
    }

    internal static void smethod_70(Stream stream, Matrix4D value)
    {
      ProxyGraphics.smethod_65(stream, value.M00);
      ProxyGraphics.smethod_65(stream, value.M01);
      ProxyGraphics.smethod_65(stream, value.M02);
      ProxyGraphics.smethod_65(stream, value.M03);
      ProxyGraphics.smethod_65(stream, value.M10);
      ProxyGraphics.smethod_65(stream, value.M11);
      ProxyGraphics.smethod_65(stream, value.M12);
      ProxyGraphics.smethod_65(stream, value.M13);
      ProxyGraphics.smethod_65(stream, value.M20);
      ProxyGraphics.smethod_65(stream, value.M21);
      ProxyGraphics.smethod_65(stream, value.M22);
      ProxyGraphics.smethod_65(stream, value.M23);
      ProxyGraphics.smethod_65(stream, value.M30);
      ProxyGraphics.smethod_65(stream, value.M31);
      ProxyGraphics.smethod_65(stream, value.M32);
      ProxyGraphics.smethod_65(stream, value.M33);
    }

    internal static void smethod_71(Stream stream, ProxyGraphics.GraphicPropertyFlags value)
    {
      ProxyGraphics.smethod_60(stream, (int) value);
    }

    internal static void smethod_72(Stream stream, Encoding encoding, string value)
    {
      long position = stream.Position;
      byte[] bytes = encoding.GetBytes(value);
      ProxyGraphics.smethod_57(stream, bytes, 0, bytes.Length);
      ProxyGraphics.smethod_56(stream, (byte) 0);
      ProxyGraphics.smethod_74(stream, position);
    }

    internal static void smethod_73(Stream stream, byte[] bytes)
    {
      long position = stream.Position;
      ProxyGraphics.smethod_57(stream, bytes, 0, bytes.Length);
      ProxyGraphics.smethod_56(stream, (byte) 0);
      ProxyGraphics.smethod_74(stream, position);
    }

    internal static void WriteString(Stream stream, string value)
    {
      long position = stream.Position;
      byte[] bytes = Encoding.Unicode.GetBytes(value);
      ProxyGraphics.smethod_57(stream, bytes, 0, bytes.Length);
      ProxyGraphics.smethod_56(stream, (byte) 0);
      ProxyGraphics.smethod_56(stream, (byte) 0);
      ProxyGraphics.smethod_74(stream, position);
    }

    internal static void smethod_74(Stream stream, long streamObjectStartPosition)
    {
      int num = ProxyGraphics.smethod_53((int) (stream.Position - streamObjectStartPosition));
      for (int index = 0; index < num; ++index)
        ProxyGraphics.smethod_56(stream, (byte) 0);
    }

    public class WireframeGraphicsFactoryDrawer
    {
      private DxfEntity dxfEntity_0;
      private DrawContext.Wireframe wireframe_0;
      private ProxyGraphics proxyGraphics_0;
      private DxfEntity dxfEntity_1;
      private ProxyGraphics.FillType fillType_0;
      private double double_0;

      public WireframeGraphicsFactoryDrawer(
        DxfEntity parentEntity,
        DrawContext.Wireframe drawContext,
        ProxyGraphics proxyGraphics)
      {
        this.dxfEntity_0 = parentEntity;
        this.wireframe_0 = drawContext;
        this.proxyGraphics_0 = proxyGraphics;
        DxfUnknownEntity dxfUnknownEntity = new DxfUnknownEntity();
        dxfUnknownEntity.PaperSpace = parentEntity.PaperSpace;
        this.dxfEntity_1 = (DxfEntity) dxfUnknownEntity;
      }

      public DxfEntity ParentEntity
      {
        get
        {
          return this.dxfEntity_0;
        }
      }

      public DxfEntity EntityContext
      {
        get
        {
          return this.dxfEntity_1;
        }
      }

      public ProxyGraphics ProxyGraphics
      {
        get
        {
          return this.proxyGraphics_0;
        }
      }

      public ProxyGraphics.FillType FillType
      {
        get
        {
          return this.fillType_0;
        }
        internal set
        {
          this.fillType_0 = value;
        }
      }

      public double Thickness
      {
        get
        {
          return this.double_0;
        }
        internal set
        {
          this.double_0 = value;
        }
      }

      public void Draw(IWireframeGraphicsFactory graphicsFactory)
      {
        foreach (ProxyGraphics.DrawCommand drawCommand in this.proxyGraphics_0.list_0)
          drawCommand.DrawInternal(this, this.wireframe_0, graphicsFactory);
      }

      public void Draw(IWireframeGraphicsFactory2 graphicsFactory)
      {
        foreach (ProxyGraphics.DrawCommand drawCommand in this.proxyGraphics_0.list_0)
          drawCommand.DrawInternal(this, this.wireframe_0, graphicsFactory);
      }

      internal void method_0(Matrix4D modelTransform)
      {
        ((ClippingTransformerChain) this.wireframe_0.GetTransformer()).Push((IClippingTransformer) new Class383(modelTransform));
      }

      internal void method_1(Vector3D modelTransform)
      {
        ((ClippingTransformerChain) this.wireframe_0.GetTransformer()).Push((IClippingTransformer) new Class383(Transformation4D.Scaling(modelTransform), Transformation3D.Scaling(modelTransform)));
      }

      internal void method_2()
      {
        ((ClippingTransformerChain) this.wireframe_0.GetTransformer()).Pop();
      }
    }

    internal class Class758 : Interface10
    {
      private LinkedList<Interface10> linkedList_0 = new LinkedList<Interface10>();

      public LinkedList<Interface10> Builders
      {
        get
        {
          return this.linkedList_0;
        }
      }

      public void ResolveReferences(Class374 modelBuilder)
      {
        foreach (Interface10 nterface10 in this.linkedList_0)
          nterface10.ResolveReferences(modelBuilder);
      }
    }

    public abstract class DrawCommand : IGraphCloneable
    {
      public virtual void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
      }

      public virtual void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
      }

      public abstract IGraphCloneable Clone(CloneContext context);

      internal virtual void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
      }

      internal virtual void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
      }

      internal abstract ProxyGraphics.Enum29 DrawCommandCode { get; }

      internal virtual bool CanWrite
      {
        get
        {
          return true;
        }
      }

      internal virtual void TransformMe(ProxyGraphics.Class790 context)
      {
      }

      internal virtual bool HasGeometricData
      {
        get
        {
          return false;
        }
      }
    }

    public class Unknown0 : ProxyGraphics.DrawCommand
    {
      public override IGraphCloneable Clone(CloneContext context)
      {
        IGraphCloneable clonedObject = context.GetExistingClone((IGraphCloneable) this);
        if (clonedObject == null)
        {
          clonedObject = (IGraphCloneable) new ProxyGraphics.Unknown0();
          context.RegisterClone((IGraphCloneable) this, clonedObject);
        }
        return clonedObject;
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_0;
        }
      }
    }

    public class Unknown15 : ProxyGraphics.DrawCommand
    {
      public override IGraphCloneable Clone(CloneContext context)
      {
        IGraphCloneable clonedObject = context.GetExistingClone((IGraphCloneable) this);
        if (clonedObject == null)
        {
          clonedObject = (IGraphCloneable) new ProxyGraphics.Unknown15();
          context.RegisterClone((IGraphCloneable) this, clonedObject);
        }
        return clonedObject;
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_15;
        }
      }
    }

    public class Unknown17 : ProxyGraphics.DrawCommand
    {
      public override IGraphCloneable Clone(CloneContext context)
      {
        IGraphCloneable clonedObject = context.GetExistingClone((IGraphCloneable) this);
        if (clonedObject == null)
        {
          clonedObject = (IGraphCloneable) new ProxyGraphics.Unknown17();
          context.RegisterClone((IGraphCloneable) this, clonedObject);
        }
        return clonedObject;
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_17;
        }
      }
    }

    public class Unknown21 : ProxyGraphics.DrawCommand
    {
      public override IGraphCloneable Clone(CloneContext context)
      {
        IGraphCloneable clonedObject = context.GetExistingClone((IGraphCloneable) this);
        if (clonedObject == null)
        {
          clonedObject = (IGraphCloneable) new ProxyGraphics.Unknown21();
          context.RegisterClone((IGraphCloneable) this, clonedObject);
        }
        return clonedObject;
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_21;
        }
      }
    }

    public class Unknown37 : ProxyGraphics.DrawCommand
    {
      public override IGraphCloneable Clone(CloneContext context)
      {
        IGraphCloneable clonedObject = context.GetExistingClone((IGraphCloneable) this);
        if (clonedObject == null)
        {
          clonedObject = (IGraphCloneable) new ProxyGraphics.Unknown37();
          context.RegisterClone((IGraphCloneable) this, clonedObject);
        }
        return clonedObject;
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_37;
        }
      }
    }

    public class Extents : ProxyGraphics.DrawCommand
    {
      private WW.Math.Point3D point3D_0;
      private WW.Math.Point3D point3D_1;

      public WW.Math.Point3D Min
      {
        get
        {
          return this.point3D_0;
        }
        set
        {
          this.point3D_0 = value;
        }
      }

      public WW.Math.Point3D Max
      {
        get
        {
          return this.point3D_1;
        }
        set
        {
          this.point3D_1 = value;
        }
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.Extents extents = (ProxyGraphics.Extents) context.GetExistingClone((IGraphCloneable) this);
        if (extents == null)
        {
          extents = new ProxyGraphics.Extents();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) extents);
          extents.CopyFrom(this);
        }
        return (IGraphCloneable) extents;
      }

      public void CopyFrom(ProxyGraphics.Extents from)
      {
        this.point3D_0 = from.point3D_0;
        this.point3D_1 = from.point3D_1;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        ProxyGraphics.smethod_46(stream);
        ProxyGraphics.smethod_46(stream);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_67(stream, this.point3D_0);
        ProxyGraphics.smethod_67(stream, this.point3D_1);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_1;
        }
      }

      internal override void TransformMe(ProxyGraphics.Class790 context)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ProxyGraphics.Extents.Class759 class759 = new ProxyGraphics.Extents.Class759();
        // ISSUE: reference to a compiler-generated field
        class759.extents_0 = this;
        // ISSUE: reference to a compiler-generated field
        class759.point3D_0 = this.point3D_0;
        // ISSUE: reference to a compiler-generated field
        class759.point3D_1 = this.point3D_1;
        this.point3D_0 = context.Transform.Transform(this.point3D_0);
        this.point3D_1 = context.Transform.Transform(this.point3D_1);
        if (context.UndoGroup == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        context.UndoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new ProxyGraphics.Extents.Class760()
        {
          class759_0 = class759,
          point3D_0 = this.point3D_0,
          point3D_1 = this.point3D_1
        }.method_0), new System.Action(class759.method_0)));
      }

      internal override bool HasGeometricData
      {
        get
        {
          return true;
        }
      }
    }

    public class Circle : ProxyGraphics.DrawCommand
    {
      private Vector3D vector3D_0 = Vector3D.ZAxis;
      private WW.Math.Point3D point3D_0;
      private double double_0;

      public WW.Math.Point3D Center
      {
        get
        {
          return this.point3D_0;
        }
        set
        {
          this.point3D_0 = value;
        }
      }

      public double Radius
      {
        get
        {
          return this.double_0;
        }
        set
        {
          this.double_0 = value;
        }
      }

      public Vector3D ZAxis
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

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        if (this.ZAxis == Vector3D.Zero)
          return;
        IList<Polyline4D> polylines4D;
        IList<FlatShape4D> shapes;
        ProxyGraphics.Circle.GetPolylines4D(drawer, (DrawContext) context, this.DenormalizationTransform, context.GetTransformer(), this.ZAxis, new ProxyGraphics.ArcType?(), 0.0, 2.0 * System.Math.PI, out polylines4D, out shapes);
        if (polylines4D.Count > 0)
          graphicsFactory.CreatePath(drawer.EntityContext, context, context.GetPlotColor(drawer.EntityContext), false, polylines4D, drawer.FillType == ProxyGraphics.FillType.Fill, true);
        if (shapes == null)
          return;
        Class940.smethod_23((IPathDrawer) new ns0.Class0(drawer.EntityContext, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, drawer.EntityContext.Color.ToColor(), context.GetLineWeight(drawer.EntityContext));
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        if (this.ZAxis == Vector3D.Zero)
          return;
        IList<Polyline4D> polylines4D;
        IList<FlatShape4D> shapes;
        ProxyGraphics.Circle.GetPolylines4D(drawer, (DrawContext) context, this.DenormalizationTransform, context.GetTransformer(), this.ZAxis, new ProxyGraphics.ArcType?(), 0.0, 2.0 * System.Math.PI, out polylines4D, out shapes);
        if (polylines4D.Count > 0)
          Class940.smethod_3(drawer.EntityContext, context, graphicsFactory, context.GetPlotColor(drawer.EntityContext), false, drawer.FillType == ProxyGraphics.FillType.Fill, drawer.FillType != ProxyGraphics.FillType.Fill, polylines4D);
        if (shapes == null)
          return;
        Class940.smethod_23((IPathDrawer) new Class396(drawer.EntityContext, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, drawer.EntityContext.Color.ToColor(), context.GetLineWeight(drawer.EntityContext));
      }

      public static void GetPolylines4D(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext context,
        Matrix4D denormalizationTransform,
        IClippingTransformer transformer,
        Vector3D zaxis,
        ProxyGraphics.ArcType? arcType,
        double startAngle,
        double endAngle,
        out IList<Polyline4D> polylines4D,
        out IList<FlatShape4D> shapes)
      {
        IList<Polyline3D> polylines;
        ProxyGraphics.Circle.GetPolylines(drawer, context, denormalizationTransform, transformer.LineTypeScaler, zaxis, arcType, startAngle, endAngle, out polylines, out shapes);
        if (drawer.Thickness != 0.0)
          DxfUtil.Extrude(polylines, drawer.Thickness, zaxis);
        polylines4D = DxfUtil.smethod_36(polylines, false, transformer);
      }

      public static void GetPolylines(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext context,
        Matrix4D denormalizationTransform,
        ILineTypeScaler lineTypeScaler,
        Vector3D zaxis,
        ProxyGraphics.ArcType? arcType,
        double startAngle,
        double endAngle,
        out IList<Polyline3D> polylines,
        out IList<FlatShape4D> shapes)
      {
        Polyline3D polyline = ProxyGraphics.Circle.smethod_0(context, denormalizationTransform, arcType, startAngle, endAngle);
        polylines = (IList<Polyline3D>) new List<Polyline3D>();
        if (context.Config.ApplyLineType)
        {
          shapes = (IList<FlatShape4D>) new List<FlatShape4D>();
          DxfUtil.smethod_4(context.Config, polylines, shapes, polyline, drawer.EntityContext.GetLineType(context), zaxis, context.TotalLineTypeScale * drawer.EntityContext.LineTypeScale, lineTypeScaler);
          if (shapes.Count != 0)
            return;
          shapes = (IList<FlatShape4D>) null;
        }
        else
        {
          polylines.Add(polyline);
          shapes = (IList<FlatShape4D>) null;
        }
      }

      private static Polyline3D smethod_0(
        DrawContext context,
        Matrix4D denormalizationTransform,
        ProxyGraphics.ArcType? arcType,
        double startAngle,
        double endAngle)
      {
        double num1 = 2.0 * System.Math.PI / (double) context.Config.NoOfArcLineSegments;
        double num2 = startAngle;
        Matrix4D matrix4D = denormalizationTransform;
        Polyline3D polyline3D = new Polyline3D(arcType.HasValue && (arcType.Value == ProxyGraphics.ArcType.Chord || arcType.Value == ProxyGraphics.ArcType.Sector));
        if (arcType.HasValue && arcType.Value == ProxyGraphics.ArcType.Sector)
          polyline3D.Add(denormalizationTransform.TransformTo3D(WW.Math.Point2D.Zero));
        for (; num2 <= endAngle; num2 += num1)
        {
          WW.Math.Point2D point = new WW.Math.Point2D(System.Math.Cos(num2), System.Math.Sin(num2));
          polyline3D.Add(matrix4D.TransformTo3D4x3(point));
        }
        polyline3D.Add(matrix4D.TransformTo3D4x3(new WW.Math.Point2D(System.Math.Cos(endAngle), System.Math.Sin(endAngle))));
        return polyline3D;
      }

      public Matrix4D Transform
      {
        get
        {
          return DxfUtil.GetToWCSTransform(this.ZAxis);
        }
      }

      protected Matrix4D DenormalizationTransform
      {
        get
        {
          return Transformation4D.Translation((Vector3D) this.Center) * Transformation4D.Scaling(this.Radius, this.Radius, this.Radius) * this.Transform;
        }
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.Circle circle = (ProxyGraphics.Circle) context.GetExistingClone((IGraphCloneable) this);
        if (circle == null)
        {
          circle = new ProxyGraphics.Circle();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) circle);
          circle.CopyFrom(this);
        }
        return (IGraphCloneable) circle;
      }

      public void CopyFrom(ProxyGraphics.Circle from)
      {
        this.point3D_0 = from.point3D_0;
        this.double_0 = from.double_0;
        this.vector3D_0 = from.vector3D_0;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.point3D_0 = ProxyGraphics.smethod_46(stream);
        this.double_0 = ProxyGraphics.smethod_44(stream);
        this.vector3D_0 = ProxyGraphics.smethod_48(stream);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_67(stream, this.point3D_0);
        ProxyGraphics.smethod_65(stream, this.double_0);
        ProxyGraphics.smethod_69(stream, this.vector3D_0);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_2;
        }
      }

      internal override void TransformMe(ProxyGraphics.Class790 context)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ProxyGraphics.Circle.Class761 class761 = new ProxyGraphics.Circle.Class761();
        // ISSUE: reference to a compiler-generated field
        class761.circle_0 = this;
        // ISSUE: reference to a compiler-generated field
        class761.vector3D_0 = this.vector3D_0;
        this.vector3D_0 = context.Transform.Transform(this.vector3D_0);
        Matrix4D transform = context.Transform;
        // ISSUE: reference to a compiler-generated field
        class761.point3D_0 = this.point3D_0;
        this.point3D_0 = transform.Transform(this.point3D_0);
        // ISSUE: reference to a compiler-generated field
        class761.double_0 = this.double_0;
        this.double_0 = transform.Transform(new Vector3D(this.double_0, 0.0, 0.0)).GetLength();
        if (context.UndoGroup == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        context.UndoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new ProxyGraphics.Circle.Class762()
        {
          class761_0 = class761,
          vector3D_0 = this.vector3D_0,
          point3D_0 = this.point3D_0,
          double_0 = this.double_0
        }.method_0), new System.Action(class761.method_0)));
      }

      internal override bool HasGeometricData
      {
        get
        {
          return true;
        }
      }
    }

    public class CircleArc : ProxyGraphics.Circle
    {
      private Vector3D vector3D_1;
      private double double_1;
      private ProxyGraphics.ArcType arcType_0;
      private double double_2;
      private double double_3;

      public Vector3D Start
      {
        get
        {
          return this.vector3D_1;
        }
        set
        {
          this.vector3D_1 = value;
          this.method_0();
        }
      }

      public double SweepAngle
      {
        get
        {
          return this.double_1;
        }
        set
        {
          this.double_1 = value;
          this.method_0();
        }
      }

      public ProxyGraphics.ArcType ArcType
      {
        get
        {
          return this.arcType_0;
        }
        set
        {
          this.arcType_0 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        if (this.ZAxis == Vector3D.Zero)
          return;
        IList<Polyline4D> polylines4D;
        IList<FlatShape4D> shapes;
        ProxyGraphics.Circle.GetPolylines4D(drawer, (DrawContext) context, this.DenormalizationTransform, context.GetTransformer(), this.ZAxis, new ProxyGraphics.ArcType?(this.arcType_0), this.double_2, this.double_3, out polylines4D, out shapes);
        if (polylines4D.Count > 0)
          graphicsFactory.CreatePath(drawer.EntityContext, context, context.GetPlotColor(drawer.EntityContext), false, polylines4D, drawer.FillType == ProxyGraphics.FillType.Fill || ProxyGraphics.CircleArc.Fill(this.arcType_0), true);
        if (shapes == null)
          return;
        Class940.smethod_23((IPathDrawer) new ns0.Class0(drawer.EntityContext, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, drawer.EntityContext.Color.ToColor(), context.GetLineWeight(drawer.EntityContext));
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        if (this.ZAxis == Vector3D.Zero)
          return;
        IList<Polyline4D> polylines4D;
        IList<FlatShape4D> shapes;
        ProxyGraphics.Circle.GetPolylines4D(drawer, (DrawContext) context, this.DenormalizationTransform, context.GetTransformer(), this.ZAxis, new ProxyGraphics.ArcType?(), this.double_2, this.double_3, out polylines4D, out shapes);
        if (polylines4D.Count > 0)
        {
          bool fill = drawer.FillType == ProxyGraphics.FillType.Fill || ProxyGraphics.CircleArc.Fill(this.arcType_0);
          Class940.smethod_3(drawer.EntityContext, context, graphicsFactory, context.GetPlotColor(drawer.EntityContext), false, fill, !fill, polylines4D);
        }
        if (shapes == null)
          return;
        Class940.smethod_23((IPathDrawer) new Class396(drawer.EntityContext, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, drawer.EntityContext.Color.ToColor(), context.GetLineWeight(drawer.EntityContext));
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.Center = ProxyGraphics.smethod_46(stream);
        this.Radius = ProxyGraphics.smethod_44(stream);
        this.ZAxis = ProxyGraphics.smethod_48(stream);
        this.vector3D_1 = ProxyGraphics.smethod_48(stream);
        this.double_1 = ProxyGraphics.smethod_44(stream);
        this.arcType_0 = (ProxyGraphics.ArcType) ProxyGraphics.smethod_39(stream);
        this.method_0();
      }

      private void method_0()
      {
        if (!(this.ZAxis != Vector3D.Zero))
          return;
        Vector3D unit = this.ZAxis.GetUnit();
        Vector3D wcsTransformXaxis = DxfUtil.GetToWcsTransformXAxis(unit);
        this.double_2 = System.Math.Atan2(Vector3D.DotProduct(this.vector3D_1, Vector3D.CrossProduct(unit, wcsTransformXaxis)), Vector3D.DotProduct(this.vector3D_1, wcsTransformXaxis));
        this.double_3 = this.double_2 + this.double_1;
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_67(stream, this.Center);
        ProxyGraphics.smethod_65(stream, this.Radius);
        ProxyGraphics.smethod_69(stream, this.ZAxis);
        ProxyGraphics.smethod_69(stream, this.vector3D_1);
        ProxyGraphics.smethod_65(stream, this.double_1);
        ProxyGraphics.smethod_60(stream, (int) this.arcType_0);
      }

      public static bool Fill(ProxyGraphics.ArcType arcType)
      {
        if (arcType != ProxyGraphics.ArcType.Chord)
          return arcType == ProxyGraphics.ArcType.Sector;
        return true;
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.CircleArc circleArc = (ProxyGraphics.CircleArc) context.GetExistingClone((IGraphCloneable) this);
        if (circleArc == null)
        {
          circleArc = new ProxyGraphics.CircleArc();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) circleArc);
          circleArc.CopyFrom(this);
        }
        return (IGraphCloneable) circleArc;
      }

      public void CopyFrom(ProxyGraphics.CircleArc from)
      {
        this.CopyFrom((ProxyGraphics.Circle) from);
        this.vector3D_1 = from.vector3D_1;
        this.double_1 = from.double_1;
        this.arcType_0 = from.arcType_0;
        this.double_2 = from.double_2;
        this.double_3 = from.double_3;
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_4;
        }
      }

      internal override void TransformMe(ProxyGraphics.Class790 context)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ProxyGraphics.CircleArc.Class763 class763 = new ProxyGraphics.CircleArc.Class763();
        // ISSUE: reference to a compiler-generated field
        class763.circleArc_0 = this;
        // ISSUE: reference to a compiler-generated field
        class763.vector3D_0 = this.ZAxis;
        this.ZAxis = context.Transform.Transform(this.ZAxis);
        Matrix4D transform = context.Transform;
        // ISSUE: reference to a compiler-generated field
        class763.point3D_0 = this.Center;
        this.Center = transform.Transform(this.Center);
        // ISSUE: reference to a compiler-generated field
        class763.double_0 = this.Radius;
        this.Radius = transform.Transform(new Vector3D(this.Radius, 0.0, 0.0)).GetLength();
        // ISSUE: reference to a compiler-generated field
        class763.vector3D_1 = this.vector3D_1;
        this.vector3D_1 = transform.Transform(this.vector3D_1);
        this.method_0();
        if (context.UndoGroup == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        context.UndoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new ProxyGraphics.CircleArc.Class764()
        {
          class763_0 = class763,
          vector3D_0 = this.ZAxis,
          point3D_0 = this.Center,
          double_0 = this.Radius,
          vector3D_1 = this.vector3D_1
        }.method_0), new System.Action(class763.method_0)));
      }
    }

    public class Circle3Point : ProxyGraphics.DrawCommand
    {
      private WW.Math.Point3D point3D_0;
      private WW.Math.Point3D point3D_1;
      private WW.Math.Point3D point3D_2;
      private WW.Math.Point3D? nullable_0;
      private double double_0;
      private Vector3D vector3D_0;

      public Circle3Point()
      {
      }

      public Circle3Point(WW.Math.Point3D point1, WW.Math.Point3D point2, WW.Math.Point3D point3)
      {
        this.point3D_0 = point1;
        this.point3D_1 = point2;
        this.point3D_2 = point3;
        this.CalculateDerivedFields();
      }

      public WW.Math.Point3D Point1
      {
        get
        {
          return this.point3D_0;
        }
        set
        {
          this.point3D_0 = value;
        }
      }

      public WW.Math.Point3D Point2
      {
        get
        {
          return this.point3D_1;
        }
        set
        {
          this.point3D_1 = value;
        }
      }

      public WW.Math.Point3D Point3
      {
        get
        {
          return this.point3D_2;
        }
        set
        {
          this.point3D_2 = value;
        }
      }

      protected internal WW.Math.Point3D? Center
      {
        get
        {
          return this.nullable_0;
        }
      }

      protected internal double Radius
      {
        get
        {
          return this.double_0;
        }
      }

      protected internal Vector3D ZAxis
      {
        get
        {
          return this.vector3D_0;
        }
      }

      protected internal virtual double StartAngle
      {
        get
        {
          return 0.0;
        }
      }

      protected internal virtual double EndAngle
      {
        get
        {
          return 2.0 * System.Math.PI;
        }
      }

      public void CalculateDerivedFields()
      {
        this.vector3D_0 = Vector3D.CrossProduct(this.point3D_1 - this.point3D_0, this.point3D_2 - this.point3D_0);
        if (this.vector3D_0 == Vector3D.Zero)
        {
          this.nullable_0 = new WW.Math.Point3D?();
          this.double_0 = 0.0;
        }
        else
        {
          this.vector3D_0.Normalize();
          Matrix3D arbitraryCoordSystem = Transformation3D.GetArbitraryCoordSystem(this.vector3D_0);
          Matrix3D transpose = arbitraryCoordSystem.GetTranspose();
          WW.Math.Point2D point2D1 = transpose.TransformTo2D(this.point3D_0);
          WW.Math.Point2D b = transpose.TransformTo2D(this.point3D_1);
          WW.Math.Point2D point2D2 = transpose.TransformTo2D(this.point3D_2);
          Vector2D vector2D1 = b - point2D1;
          Vector2D vector2D2 = point2D2 - point2D1;
          WW.Math.Point2D? intersection = Line2D.GetIntersection(new Line2D(WW.Math.Point2D.GetMidPoint(point2D1, b), new Vector2D(-vector2D1.Y, vector2D1.X)), new Line2D(WW.Math.Point2D.GetMidPoint(point2D1, point2D2), new Vector2D(-vector2D2.Y, vector2D2.X)));
          if (!intersection.HasValue)
            return;
          this.nullable_0 = new WW.Math.Point3D?(arbitraryCoordSystem.Transform((WW.Math.Point3D) intersection.Value));
          this.double_0 = (this.point3D_0 - this.nullable_0.Value).GetLength();
          this.CalculateAngles(new WW.Math.Point2D?(intersection.Value), point2D1, point2D2);
        }
      }

      protected virtual void CalculateAngles(WW.Math.Point2D? center, WW.Math.Point2D point1, WW.Math.Point2D point2)
      {
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        if (!this.nullable_0.HasValue)
          return;
        IList<Polyline4D> polylines4D;
        IList<FlatShape4D> shapes;
        ProxyGraphics.Circle.GetPolylines4D(drawer, (DrawContext) context, this.DenormalizationTransform, context.GetTransformer(), this.ZAxis, new ProxyGraphics.ArcType?(), this.StartAngle, this.EndAngle, out polylines4D, out shapes);
        if (polylines4D.Count > 0)
          graphicsFactory.CreatePath(drawer.EntityContext, context, context.GetPlotColor(drawer.EntityContext), false, polylines4D, drawer.FillType == ProxyGraphics.FillType.Fill, true);
        if (shapes == null)
          return;
        Class940.smethod_23((IPathDrawer) new ns0.Class0(drawer.EntityContext, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, drawer.EntityContext.Color.ToColor(), context.GetLineWeight(drawer.EntityContext));
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        if (!this.nullable_0.HasValue)
          return;
        IList<Polyline4D> polylines4D;
        IList<FlatShape4D> shapes;
        ProxyGraphics.Circle.GetPolylines4D(drawer, (DrawContext) context, this.DenormalizationTransform, context.GetTransformer(), this.ZAxis, new ProxyGraphics.ArcType?(), 0.0, 2.0 * System.Math.PI, out polylines4D, out shapes);
        if (polylines4D.Count > 0)
        {
          bool fill = drawer.FillType == ProxyGraphics.FillType.Fill;
          Class940.smethod_3(drawer.EntityContext, context, graphicsFactory, context.GetPlotColor(drawer.EntityContext), false, fill, !fill, polylines4D);
        }
        if (shapes == null)
          return;
        Class940.smethod_23((IPathDrawer) new Class396(drawer.EntityContext, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, drawer.EntityContext.Color.ToColor(), context.GetLineWeight(drawer.EntityContext));
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.Circle3Point circle3Point = (ProxyGraphics.Circle3Point) context.GetExistingClone((IGraphCloneable) this);
        if (circle3Point == null)
        {
          circle3Point = new ProxyGraphics.Circle3Point();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) circle3Point);
          circle3Point.CopyFrom(this);
        }
        return (IGraphCloneable) circle3Point;
      }

      public void CopyFrom(ProxyGraphics.Circle3Point from)
      {
        this.point3D_0 = from.point3D_0;
        this.point3D_1 = from.point3D_1;
        this.point3D_2 = from.point3D_2;
        this.nullable_0 = from.nullable_0;
        this.double_0 = from.double_0;
        this.vector3D_0 = from.vector3D_0;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.point3D_0 = ProxyGraphics.smethod_46(stream);
        this.point3D_1 = ProxyGraphics.smethod_46(stream);
        this.point3D_2 = ProxyGraphics.smethod_46(stream);
        this.CalculateDerivedFields();
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_67(stream, this.point3D_0);
        ProxyGraphics.smethod_67(stream, this.point3D_1);
        ProxyGraphics.smethod_67(stream, this.point3D_2);
      }

      public Matrix4D Transform
      {
        get
        {
          return Transformation4D.GetArbitraryCoordSystem(this.ZAxis);
        }
      }

      protected Matrix4D DenormalizationTransform
      {
        get
        {
          if (!this.nullable_0.HasValue)
            return Matrix4D.Identity;
          return Transformation4D.Translation((Vector3D) this.nullable_0.Value) * Transformation4D.Scaling(this.double_0, this.double_0, this.double_0) * this.Transform;
        }
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_3;
        }
      }

      internal override void TransformMe(ProxyGraphics.Class790 context)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ProxyGraphics.Circle3Point.Class765 class765 = new ProxyGraphics.Circle3Point.Class765();
        // ISSUE: reference to a compiler-generated field
        class765.circle3Point_0 = this;
        // ISSUE: reference to a compiler-generated field
        class765.point3D_0 = this.point3D_0;
        this.point3D_0 = context.Transform.Transform(this.point3D_0);
        // ISSUE: reference to a compiler-generated field
        class765.point3D_1 = this.point3D_1;
        this.point3D_1 = context.Transform.Transform(this.point3D_1);
        // ISSUE: reference to a compiler-generated field
        class765.point3D_2 = this.point3D_2;
        this.point3D_2 = context.Transform.Transform(this.point3D_2);
        this.CalculateDerivedFields();
        if (context.UndoGroup == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        context.UndoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new ProxyGraphics.Circle3Point.Class766()
        {
          class765_0 = class765,
          point3D_0 = this.point3D_0,
          point3D_1 = this.point3D_1,
          point3D_2 = this.point3D_2
        }.method_0), new System.Action(class765.method_0)));
      }

      internal override bool HasGeometricData
      {
        get
        {
          return true;
        }
      }
    }

    public class CircleArc3Point : ProxyGraphics.Circle3Point
    {
      private double double_1;
      private double double_2;
      private ProxyGraphics.ArcType arcType_0;

      public CircleArc3Point()
      {
      }

      public CircleArc3Point(WW.Math.Point3D point1, WW.Math.Point3D point2, WW.Math.Point3D point3)
        : base(point1, point2, point3)
      {
      }

      protected internal override double StartAngle
      {
        get
        {
          return this.double_1;
        }
      }

      protected internal override double EndAngle
      {
        get
        {
          return this.double_2;
        }
      }

      public ProxyGraphics.ArcType ArcType
      {
        get
        {
          return this.arcType_0;
        }
        set
        {
          this.arcType_0 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        if (!this.Center.HasValue)
          return;
        IList<Polyline4D> polylines4D;
        IList<FlatShape4D> shapes;
        ProxyGraphics.Circle.GetPolylines4D(drawer, (DrawContext) context, this.DenormalizationTransform, context.GetTransformer(), this.ZAxis, new ProxyGraphics.ArcType?(this.ArcType), this.StartAngle, this.EndAngle, out polylines4D, out shapes);
        if (polylines4D.Count > 0)
          graphicsFactory.CreatePath(drawer.EntityContext, context, context.GetPlotColor(drawer.EntityContext), false, polylines4D, drawer.FillType == ProxyGraphics.FillType.Fill || ProxyGraphics.CircleArc.Fill(this.arcType_0), true);
        if (shapes == null)
          return;
        Class940.smethod_23((IPathDrawer) new ns0.Class0(drawer.EntityContext, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, drawer.EntityContext.Color.ToColor(), context.GetLineWeight(drawer.EntityContext));
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        if (!this.Center.HasValue)
          return;
        IList<Polyline4D> polylines4D;
        IList<FlatShape4D> shapes;
        ProxyGraphics.Circle.GetPolylines4D(drawer, (DrawContext) context, this.DenormalizationTransform, context.GetTransformer(), this.ZAxis, new ProxyGraphics.ArcType?(this.ArcType), this.StartAngle, this.EndAngle, out polylines4D, out shapes);
        if (polylines4D.Count > 0)
        {
          bool fill = drawer.FillType == ProxyGraphics.FillType.Fill || ProxyGraphics.CircleArc.Fill(this.arcType_0);
          Class940.smethod_3(drawer.EntityContext, context, graphicsFactory, context.GetPlotColor(drawer.EntityContext), false, fill, !fill, polylines4D);
        }
        if (shapes == null)
          return;
        Class940.smethod_23((IPathDrawer) new Class396(drawer.EntityContext, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, drawer.EntityContext.Color.ToColor(), context.GetLineWeight(drawer.EntityContext));
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.CircleArc3Point circleArc3Point = (ProxyGraphics.CircleArc3Point) context.GetExistingClone((IGraphCloneable) this);
        if (circleArc3Point == null)
        {
          circleArc3Point = new ProxyGraphics.CircleArc3Point();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) circleArc3Point);
          circleArc3Point.CopyFrom(this);
        }
        return (IGraphCloneable) circleArc3Point;
      }

      public void CopyFrom(ProxyGraphics.CircleArc3Point from)
      {
        this.CopyFrom((ProxyGraphics.Circle3Point) from);
        this.double_1 = from.double_1;
        this.double_2 = from.double_2;
        this.arcType_0 = from.arcType_0;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.Point1 = ProxyGraphics.smethod_46(stream);
        this.Point2 = ProxyGraphics.smethod_46(stream);
        this.Point3 = ProxyGraphics.smethod_46(stream);
        this.arcType_0 = (ProxyGraphics.ArcType) ProxyGraphics.smethod_39(stream);
        this.CalculateDerivedFields();
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_67(stream, this.Point1);
        ProxyGraphics.smethod_67(stream, this.Point2);
        ProxyGraphics.smethod_67(stream, this.Point3);
        ProxyGraphics.smethod_60(stream, (int) this.arcType_0);
      }

      protected override void CalculateAngles(WW.Math.Point2D? center, WW.Math.Point2D point1, WW.Math.Point2D point2)
      {
        if (center.HasValue)
        {
          Vector2D vector2D1 = point1 - center.Value;
          Vector2D vector2D2 = point2 - center.Value;
          this.double_1 = System.Math.Atan2(vector2D1.Y, vector2D1.X);
          this.double_2 = System.Math.Atan2(vector2D2.Y, vector2D2.X);
        }
        else
        {
          this.double_1 = 0.0;
          this.double_2 = 0.0;
        }
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_5;
        }
      }
    }

    public class Polyline : ProxyGraphics.DrawCommand
    {
      private IList<WW.Math.Point3D> ilist_0 = (IList<WW.Math.Point3D>) new List<WW.Math.Point3D>();

      public IList<WW.Math.Point3D> Vertices
      {
        get
        {
          return this.ilist_0;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe drawContext,
        IWireframeGraphicsFactory graphicsFactory)
      {
        Polyline3D polyline1 = new Polyline3D(false, this.ilist_0);
        if (drawContext.Config.ApplyLineType)
        {
          List<Polyline3D> polyline3DList = (List<Polyline3D>) new WW.Math.Geometry.Polyline<Polyline3D>();
          List<FlatShape4D> flatShape4DList = new List<FlatShape4D>();
          DxfUtil.smethod_4(drawContext.Config, (IList<Polyline3D>) polyline3DList, (IList<FlatShape4D>) flatShape4DList, polyline1, drawer.EntityContext.GetLineType((DrawContext) drawContext), Vector3D.ZAxis, drawContext.TotalLineTypeScale * drawer.EntityContext.LineTypeScale, drawContext.GetTransformer().LineTypeScaler);
          foreach (Polyline3D polyline2 in polyline3DList)
          {
            IList<Polyline4D> polylines = drawContext.GetTransformer().Transform(polyline2, false);
            if (polylines.Count > 0)
              graphicsFactory.CreatePath(drawer.ParentEntity, drawContext, drawContext.GetPlotColor(drawer.EntityContext), false, polylines, false, true);
          }
          if (flatShape4DList == null || flatShape4DList.Count <= 0)
            return;
          Class940.smethod_23((IPathDrawer) new ns0.Class0(drawer.EntityContext, drawContext, graphicsFactory), (IEnumerable<IShape4D>) flatShape4DList, drawer.EntityContext.Color.ToColor(), drawContext.GetLineWeight(drawer.EntityContext));
        }
        else
        {
          IList<Polyline4D> polylines = drawContext.GetTransformer().Transform(polyline1, false);
          if (polylines.Count <= 0)
            return;
          graphicsFactory.CreatePath(drawer.ParentEntity, drawContext, drawContext.GetPlotColor(drawer.EntityContext), false, polylines, false, true);
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe drawContext,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        Polyline3D polyline1 = new Polyline3D(false, this.ilist_0);
        if (drawContext.Config.ApplyLineType)
        {
          List<Polyline3D> polyline3DList = (List<Polyline3D>) new WW.Math.Geometry.Polyline<Polyline3D>();
          List<FlatShape4D> flatShape4DList = new List<FlatShape4D>();
          DxfUtil.smethod_4(drawContext.Config, (IList<Polyline3D>) polyline3DList, (IList<FlatShape4D>) flatShape4DList, polyline1, drawer.EntityContext.GetLineType((DrawContext) drawContext), Vector3D.ZAxis, drawContext.TotalLineTypeScale * drawer.EntityContext.LineTypeScale, drawContext.GetTransformer().LineTypeScaler);
          foreach (Polyline3D polyline2 in polyline3DList)
          {
            IList<Polyline4D> polylines = drawContext.GetTransformer().Transform(polyline2, false);
            if (polylines.Count > 0)
              Class940.smethod_3(drawer.ParentEntity, drawContext, graphicsFactory, drawContext.GetPlotColor(drawer.EntityContext), false, false, true, polylines);
          }
          if (flatShape4DList == null || flatShape4DList.Count <= 0)
            return;
          Class940.smethod_23((IPathDrawer) new Class396(drawer.EntityContext, drawContext, graphicsFactory), (IEnumerable<IShape4D>) flatShape4DList, drawer.EntityContext.Color.ToColor(), drawContext.GetLineWeight(drawer.EntityContext));
        }
        else
        {
          IList<Polyline4D> polylines = drawContext.GetTransformer().Transform(polyline1, false);
          if (polylines.Count <= 0)
            return;
          Class940.smethod_3(drawer.ParentEntity, drawContext, graphicsFactory, drawContext.GetPlotColor(drawer.EntityContext), false, false, true, polylines);
        }
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.Polyline polyline = (ProxyGraphics.Polyline) context.GetExistingClone((IGraphCloneable) this);
        if (polyline == null)
        {
          polyline = new ProxyGraphics.Polyline();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) polyline);
          polyline.CopyFrom(this);
        }
        return (IGraphCloneable) polyline;
      }

      public void CopyFrom(ProxyGraphics.Polyline from)
      {
        this.ilist_0.Clear();
        foreach (WW.Math.Point3D point3D in (IEnumerable<WW.Math.Point3D>) from.ilist_0)
          this.ilist_0.Add(point3D);
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        int num = ProxyGraphics.smethod_39(stream);
        this.ilist_0.Clear();
        ((List<WW.Math.Point3D>) this.ilist_0).Capacity = num;
        for (int index = 0; index < num; ++index)
          this.ilist_0.Add(ProxyGraphics.smethod_46(stream));
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_60(stream, this.ilist_0.Count);
        foreach (WW.Math.Point3D point3D in (IEnumerable<WW.Math.Point3D>) this.ilist_0)
          ProxyGraphics.smethod_67(stream, point3D);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_6;
        }
      }

      internal override void TransformMe(ProxyGraphics.Class790 context)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ProxyGraphics.Polyline.Class767 class767 = new ProxyGraphics.Polyline.Class767();
        // ISSUE: reference to a compiler-generated field
        class767.polyline_0 = this;
        // ISSUE: reference to a compiler-generated field
        class767.list_0 = (List<WW.Math.Point3D>) null;
        if (context.UndoGroup != null)
        {
          // ISSUE: reference to a compiler-generated field
          class767.list_0 = new List<WW.Math.Point3D>((IEnumerable<WW.Math.Point3D>) this.ilist_0);
        }
        Matrix4D transform = context.Transform;
        for (int index = 0; index < this.ilist_0.Count; ++index)
          this.ilist_0[index] = transform.Transform(this.ilist_0[index]);
        if (context.UndoGroup == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        context.UndoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new ProxyGraphics.Polyline.Class768()
        {
          class767_0 = class767,
          list_0 = new List<WW.Math.Point3D>((IEnumerable<WW.Math.Point3D>) this.ilist_0)
        }.method_0), new System.Action(class767.method_0)));
      }

      internal override bool HasGeometricData
      {
        get
        {
          return true;
        }
      }
    }

    public class PolylineWithNormal : ProxyGraphics.Polyline
    {
      private Vector3D vector3D_0;

      public Vector3D Normal
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

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe drawContext,
        IWireframeGraphicsFactory graphicsFactory)
      {
        base.DrawInternal(drawer, drawContext, graphicsFactory);
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.PolylineWithNormal polylineWithNormal = (ProxyGraphics.PolylineWithNormal) context.GetExistingClone((IGraphCloneable) this);
        if (polylineWithNormal == null)
        {
          polylineWithNormal = new ProxyGraphics.PolylineWithNormal();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) polylineWithNormal);
          polylineWithNormal.CopyFrom(this);
        }
        return (IGraphCloneable) polylineWithNormal;
      }

      public void CopyFrom(ProxyGraphics.PolylineWithNormal from)
      {
        this.CopyFrom((ProxyGraphics.Polyline) from);
        this.vector3D_0 = from.vector3D_0;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        base.Read(proxyGraphics, stream, encoding, modelBuilder, builder);
        this.vector3D_0 = ProxyGraphics.smethod_48(stream);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        base.Write(proxyGraphics, stream, encoding, model);
        ProxyGraphics.smethod_69(stream, this.vector3D_0);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_32;
        }
      }

      internal override void TransformMe(ProxyGraphics.Class790 context)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ProxyGraphics.PolylineWithNormal.Class769 class769 = new ProxyGraphics.PolylineWithNormal.Class769();
        // ISSUE: reference to a compiler-generated field
        class769.polylineWithNormal_0 = this;
        base.TransformMe(context);
        // ISSUE: reference to a compiler-generated field
        class769.vector3D_0 = this.vector3D_0;
        this.vector3D_0 = context.Transform.Transform(this.vector3D_0);
        if (context.UndoGroup == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        context.UndoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new ProxyGraphics.PolylineWithNormal.Class770()
        {
          class769_0 = class769,
          vector3D_0 = this.vector3D_0
        }.method_0), new System.Action(class769.method_0)));
      }
    }

    public class Polygon : ProxyGraphics.DrawCommand
    {
      private IList<WW.Math.Point3D> ilist_0 = (IList<WW.Math.Point3D>) new List<WW.Math.Point3D>();

      public IList<WW.Math.Point3D> Vertices
      {
        get
        {
          return this.ilist_0;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe drawContext,
        IWireframeGraphicsFactory graphicsFactory)
      {
        Polyline3D polyline1 = new Polyline3D(true, this.ilist_0);
        if (drawContext.Config.ApplyLineType)
        {
          List<Polyline3D> polyline3DList = (List<Polyline3D>) new WW.Math.Geometry.Polyline<Polyline3D>();
          List<FlatShape4D> flatShape4DList = new List<FlatShape4D>();
          DxfUtil.smethod_4(drawContext.Config, (IList<Polyline3D>) polyline3DList, (IList<FlatShape4D>) flatShape4DList, polyline1, drawer.EntityContext.GetLineType((DrawContext) drawContext), Vector3D.ZAxis, drawContext.TotalLineTypeScale * drawer.EntityContext.LineTypeScale, drawContext.GetTransformer().LineTypeScaler);
          foreach (Polyline3D polyline2 in polyline3DList)
          {
            IList<Polyline4D> polylines = drawContext.GetTransformer().Transform(polyline2, false);
            if (polylines.Count > 0)
              graphicsFactory.CreatePath(drawer.ParentEntity, drawContext, drawContext.GetPlotColor(drawer.EntityContext), false, polylines, false, true);
          }
          if (flatShape4DList == null || flatShape4DList.Count <= 0)
            return;
          Class940.smethod_23((IPathDrawer) new ns0.Class0(drawer.EntityContext, drawContext, graphicsFactory), (IEnumerable<IShape4D>) flatShape4DList, drawer.EntityContext.Color.ToColor(), drawContext.GetLineWeight(drawer.EntityContext));
        }
        else
        {
          IList<Polyline4D> polylines = drawContext.GetTransformer().Transform(polyline1, false);
          if (polylines.Count <= 0)
            return;
          graphicsFactory.CreatePath(drawer.ParentEntity, drawContext, drawContext.GetPlotColor(drawer.EntityContext), false, polylines, false, true);
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe drawContext,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        Polyline3D polyline1 = new Polyline3D(true, this.ilist_0);
        if (drawContext.Config.ApplyLineType)
        {
          List<Polyline3D> polyline3DList = (List<Polyline3D>) new WW.Math.Geometry.Polyline<Polyline3D>();
          List<FlatShape4D> flatShape4DList = new List<FlatShape4D>();
          DxfUtil.smethod_4(drawContext.Config, (IList<Polyline3D>) polyline3DList, (IList<FlatShape4D>) flatShape4DList, polyline1, drawer.EntityContext.GetLineType((DrawContext) drawContext), Vector3D.ZAxis, drawContext.TotalLineTypeScale * drawer.EntityContext.LineTypeScale, drawContext.GetTransformer().LineTypeScaler);
          foreach (Polyline3D polyline2 in polyline3DList)
          {
            IList<Polyline4D> polylines = drawContext.GetTransformer().Transform(polyline2, false);
            if (polylines.Count > 0)
              Class940.smethod_3(drawer.ParentEntity, drawContext, graphicsFactory, drawContext.GetPlotColor(drawer.EntityContext), false, false, true, polylines);
          }
          if (flatShape4DList == null || flatShape4DList.Count <= 0)
            return;
          Class940.smethod_23((IPathDrawer) new Class396(drawer.EntityContext, drawContext, graphicsFactory), (IEnumerable<IShape4D>) flatShape4DList, drawer.EntityContext.Color.ToColor(), drawContext.GetLineWeight(drawer.EntityContext));
        }
        else
        {
          IList<Polyline4D> polylines = drawContext.GetTransformer().Transform(polyline1, false);
          if (polylines.Count <= 0)
            return;
          Class940.smethod_3(drawer.ParentEntity, drawContext, graphicsFactory, drawContext.GetPlotColor(drawer.EntityContext), false, false, true, polylines);
        }
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.Polygon polygon = (ProxyGraphics.Polygon) context.GetExistingClone((IGraphCloneable) this);
        if (polygon == null)
        {
          polygon = new ProxyGraphics.Polygon();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) polygon);
          polygon.CopyFrom(this);
        }
        return (IGraphCloneable) polygon;
      }

      public void CopyFrom(ProxyGraphics.Polygon from)
      {
        this.ilist_0.Clear();
        foreach (WW.Math.Point3D point3D in (IEnumerable<WW.Math.Point3D>) from.ilist_0)
          this.ilist_0.Add(point3D);
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        int num = ProxyGraphics.smethod_39(stream);
        this.ilist_0.Clear();
        ((List<WW.Math.Point3D>) this.ilist_0).Capacity = num;
        for (int index = 0; index < num; ++index)
          this.ilist_0.Add(ProxyGraphics.smethod_46(stream));
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_60(stream, this.ilist_0.Count);
        foreach (WW.Math.Point3D point3D in (IEnumerable<WW.Math.Point3D>) this.ilist_0)
          ProxyGraphics.smethod_67(stream, point3D);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_7;
        }
      }

      internal override void TransformMe(ProxyGraphics.Class790 context)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ProxyGraphics.Polygon.Class771 class771 = new ProxyGraphics.Polygon.Class771();
        // ISSUE: reference to a compiler-generated field
        class771.polygon_0 = this;
        // ISSUE: reference to a compiler-generated field
        class771.list_0 = (List<WW.Math.Point3D>) null;
        if (context.UndoGroup != null)
        {
          // ISSUE: reference to a compiler-generated field
          class771.list_0 = new List<WW.Math.Point3D>((IEnumerable<WW.Math.Point3D>) this.ilist_0);
        }
        Matrix4D transform = context.Transform;
        for (int index = 0; index < this.ilist_0.Count; ++index)
          this.ilist_0[index] = transform.Transform(this.ilist_0[index]);
        if (context.UndoGroup == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        context.UndoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new ProxyGraphics.Polygon.Class772()
        {
          class771_0 = class771,
          list_0 = new List<WW.Math.Point3D>((IEnumerable<WW.Math.Point3D>) this.ilist_0)
        }.method_0), new System.Action(class771.method_0)));
      }

      internal override bool HasGeometricData
      {
        get
        {
          return true;
        }
      }
    }

    public abstract class MeshBase : ProxyGraphics.DrawCommand
    {
      private uint uint_0;
      private uint uint_1;
      private uint uint_2;
      private IList<WW.Math.Point3D> ilist_0;
      private ProxyGraphics.EdgeData edgeData_0;
      private ProxyGraphics.FaceData faceData_0;
      private ProxyGraphics.VertexData vertexData_0;

      public uint VertexCount
      {
        get
        {
          return this.uint_0;
        }
        set
        {
          this.uint_0 = value;
        }
      }

      public uint FaceCount
      {
        get
        {
          return this.uint_1;
        }
        set
        {
          this.uint_1 = value;
        }
      }

      public uint EdgeCount
      {
        get
        {
          return this.uint_2;
        }
        set
        {
          this.uint_2 = value;
        }
      }

      public IList<WW.Math.Point3D> Points
      {
        get
        {
          return this.ilist_0;
        }
        set
        {
          this.ilist_0 = value;
        }
      }

      public ProxyGraphics.EdgeData EdgeData
      {
        get
        {
          return this.edgeData_0;
        }
        set
        {
          this.edgeData_0 = value;
        }
      }

      public ProxyGraphics.FaceData FaceData
      {
        get
        {
          return this.faceData_0;
        }
        set
        {
          this.faceData_0 = value;
        }
      }

      public ProxyGraphics.VertexData VertexData
      {
        get
        {
          return this.vertexData_0;
        }
        set
        {
          this.vertexData_0 = value;
        }
      }

      public void CopyFrom(CloneContext context, ProxyGraphics.MeshBase from)
      {
        this.uint_0 = from.uint_0;
        this.uint_1 = from.uint_1;
        this.uint_2 = from.uint_2;
        if (from.ilist_0 == null)
        {
          this.ilist_0 = (IList<WW.Math.Point3D>) null;
        }
        else
        {
          if (this.ilist_0 == null)
            this.ilist_0 = (IList<WW.Math.Point3D>) new List<WW.Math.Point3D>();
          else
            this.ilist_0.Clear();
          foreach (WW.Math.Point3D point3D in (IEnumerable<WW.Math.Point3D>) from.ilist_0)
            this.ilist_0.Add(point3D);
        }
        if (from.edgeData_0 == null)
        {
          this.edgeData_0 = (ProxyGraphics.EdgeData) null;
        }
        else
        {
          if (this.edgeData_0 == null)
            this.edgeData_0 = new ProxyGraphics.EdgeData();
          this.edgeData_0.CopyFrom(context, from.edgeData_0);
        }
        if (from.faceData_0 == null)
        {
          this.faceData_0 = (ProxyGraphics.FaceData) null;
        }
        else
        {
          if (this.faceData_0 == null)
            this.faceData_0 = new ProxyGraphics.FaceData();
          this.faceData_0.CopyFrom(context, from.faceData_0);
        }
        if (from.vertexData_0 == null)
        {
          this.vertexData_0 = (ProxyGraphics.VertexData) null;
        }
        else
        {
          if (this.vertexData_0 == null)
            this.vertexData_0 = new ProxyGraphics.VertexData();
          this.vertexData_0.CopyFrom(context, from.vertexData_0);
        }
      }

      internal void method_0(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder)
      {
        DxfModel model = modelBuilder.Model;
        this.edgeData_0 = (ProxyGraphics.EdgeData) null;
        ProxyGraphics.GraphicPropertyFlags graphicPropertyFlags1 = ProxyGraphics.smethod_50(stream);
        if (graphicPropertyFlags1 != (ProxyGraphics.GraphicPropertyFlags) 0)
        {
          this.edgeData_0 = new ProxyGraphics.EdgeData();
          if ((graphicPropertyFlags1 & ProxyGraphics.GraphicPropertyFlags.HasColors) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            long position = stream.Position;
            this.edgeData_0.Colors = (IList<ushort>) new ushort[(IntPtr) this.uint_2];
            for (int index = 0; (long) index < (long) this.uint_2; ++index)
              this.edgeData_0.Colors[index] = ProxyGraphics.smethod_38(stream);
            ProxyGraphics.smethod_54(stream, position);
          }
          if ((graphicPropertyFlags1 & ProxyGraphics.GraphicPropertyFlags.HasLayers) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            long position = stream.Position;
            this.edgeData_0.Layers = (IList<DxfLayer>) new DxfLayer[(IntPtr) this.uint_2];
            for (int index = 0; (long) index < (long) this.uint_2; ++index)
            {
              // ISSUE: object of a compiler-generated type is created
              // ISSUE: reference to a compiler-generated method
              modelBuilder.ObjectBuilders2.AddLast(new Delegate11(new ProxyGraphics.MeshBase.Class773()
              {
                meshBase_0 = this,
                short_0 = ProxyGraphics.smethod_37(stream),
                int_0 = index
              }.method_0));
            }
            ProxyGraphics.smethod_54(stream, position);
          }
          if ((graphicPropertyFlags1 & ProxyGraphics.GraphicPropertyFlags.HasLineTypes) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            long position = stream.Position;
            this.edgeData_0.LineTypes = (IList<DxfLineType>) new DxfLineType[(IntPtr) this.uint_2];
            for (int index = 0; (long) index < (long) this.uint_2; ++index)
            {
              // ISSUE: object of a compiler-generated type is created
              // ISSUE: reference to a compiler-generated method
              modelBuilder.ObjectBuilders2.AddLast(new Delegate11(new ProxyGraphics.MeshBase.Class774()
              {
                meshBase_0 = this,
                short_0 = ProxyGraphics.smethod_37(stream),
                int_0 = index
              }.method_0));
            }
            ProxyGraphics.smethod_54(stream, position);
          }
          if ((graphicPropertyFlags1 & ProxyGraphics.GraphicPropertyFlags.HasMarkers) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            this.edgeData_0.SelectionMarkers = (IList<int>) new int[(IntPtr) this.uint_2];
            for (int index = 0; (long) index < (long) this.uint_2; ++index)
              this.edgeData_0.SelectionMarkers[index] = ProxyGraphics.smethod_39(stream);
          }
          if ((graphicPropertyFlags1 & ProxyGraphics.GraphicPropertyFlags.HasVisibilities) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            this.edgeData_0.Visibilities = (IList<bool>) new bool[(IntPtr) this.uint_2];
            for (int index = 0; (long) index < (long) this.uint_2; ++index)
            {
              uint num = ProxyGraphics.smethod_40(stream);
              this.edgeData_0.Visibilities[index] = num != 0U;
            }
          }
        }
        this.faceData_0 = (ProxyGraphics.FaceData) null;
        ProxyGraphics.GraphicPropertyFlags graphicPropertyFlags2 = ProxyGraphics.smethod_50(stream);
        if (graphicPropertyFlags2 != (ProxyGraphics.GraphicPropertyFlags) 0)
        {
          this.faceData_0 = new ProxyGraphics.FaceData();
          if ((graphicPropertyFlags2 & ProxyGraphics.GraphicPropertyFlags.HasColors) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            long position = stream.Position;
            this.faceData_0.Colors = (IList<ushort>) new ushort[(IntPtr) this.uint_1];
            for (int index = 0; (long) index < (long) this.uint_1; ++index)
              this.faceData_0.Colors[index] = ProxyGraphics.smethod_38(stream);
            ProxyGraphics.smethod_54(stream, position);
          }
          if ((graphicPropertyFlags2 & ProxyGraphics.GraphicPropertyFlags.HasLayers) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            long position = stream.Position;
            this.faceData_0.Layers = (IList<DxfLayer>) new DxfLayer[(IntPtr) this.uint_1];
            for (int index = 0; (long) index < (long) this.uint_1; ++index)
            {
              // ISSUE: object of a compiler-generated type is created
              // ISSUE: reference to a compiler-generated method
              modelBuilder.ObjectBuilders2.AddLast(new Delegate11(new ProxyGraphics.MeshBase.Class775()
              {
                meshBase_0 = this,
                short_0 = ProxyGraphics.smethod_37(stream),
                int_0 = index
              }.method_0));
            }
            ProxyGraphics.smethod_54(stream, position);
          }
          if ((graphicPropertyFlags2 & ProxyGraphics.GraphicPropertyFlags.HasMarkers) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            this.faceData_0.SelectionMarkers = (IList<int>) new int[(IntPtr) this.uint_1];
            for (int index = 0; (long) index < (long) this.uint_1; ++index)
              this.faceData_0.SelectionMarkers[index] = ProxyGraphics.smethod_39(stream);
          }
          if ((graphicPropertyFlags2 & ProxyGraphics.GraphicPropertyFlags.HasNormals) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            this.faceData_0.Normals = (IList<Vector3D>) new Vector3D[(IntPtr) this.uint_1];
            for (int index = 0; (long) index < (long) this.uint_1; ++index)
              this.faceData_0.Normals[index] = ProxyGraphics.smethod_48(stream);
          }
          if ((graphicPropertyFlags2 & ProxyGraphics.GraphicPropertyFlags.HasVisibilities) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            this.faceData_0.Visibilities = (IList<bool>) new bool[(IntPtr) this.uint_1];
            for (int index = 0; (long) index < (long) this.uint_1; ++index)
            {
              uint num = ProxyGraphics.smethod_40(stream);
              this.faceData_0.Visibilities[index] = num != 0U;
            }
          }
        }
        this.vertexData_0 = (ProxyGraphics.VertexData) null;
        ProxyGraphics.GraphicPropertyFlags graphicPropertyFlags3 = ProxyGraphics.smethod_50(stream);
        if (graphicPropertyFlags3 == (ProxyGraphics.GraphicPropertyFlags) 0)
          return;
        this.vertexData_0 = new ProxyGraphics.VertexData();
        if ((graphicPropertyFlags3 & ProxyGraphics.GraphicPropertyFlags.HasNormals) != (ProxyGraphics.GraphicPropertyFlags) 0)
        {
          this.vertexData_0.Normals = (IList<Vector3D>) new Vector3D[(IntPtr) this.uint_0];
          for (int index = 0; (long) index < (long) this.uint_0; ++index)
            this.vertexData_0.Normals[index] = ProxyGraphics.smethod_48(stream);
        }
        if ((graphicPropertyFlags3 & ProxyGraphics.GraphicPropertyFlags.HasOrientation) == (ProxyGraphics.GraphicPropertyFlags) 0)
          return;
        this.vertexData_0.Orientation = (ProxyGraphics.Orientation) ProxyGraphics.smethod_39(stream);
      }

      internal void method_1(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        short num1 = (short) model.Layers.IndexOf(model.ZeroLayer);
        if (num1 < (short) 0)
          num1 = (short) 0;
        this.edgeData_0 = (ProxyGraphics.EdgeData) null;
        ProxyGraphics.GraphicPropertyFlags graphicPropertyFlags1 = (ProxyGraphics.GraphicPropertyFlags) 0;
        if (this.edgeData_0 != null)
        {
          if (this.edgeData_0.Colors != null && (long) this.edgeData_0.Colors.Count >= (long) this.uint_2)
            graphicPropertyFlags1 |= ProxyGraphics.GraphicPropertyFlags.HasColors;
          if (this.edgeData_0.Layers != null && (long) this.edgeData_0.Layers.Count >= (long) this.uint_2)
            graphicPropertyFlags1 |= ProxyGraphics.GraphicPropertyFlags.HasLayers;
          if (this.edgeData_0.LineTypes != null && (long) this.edgeData_0.LineTypes.Count >= (long) this.uint_2)
            graphicPropertyFlags1 |= ProxyGraphics.GraphicPropertyFlags.HasLineTypes;
          if (this.edgeData_0.SelectionMarkers != null && (long) this.edgeData_0.SelectionMarkers.Count >= (long) this.uint_2)
            graphicPropertyFlags1 |= ProxyGraphics.GraphicPropertyFlags.HasMarkers;
          if (this.edgeData_0.Visibilities != null && (long) this.edgeData_0.Visibilities.Count >= (long) this.uint_2)
            graphicPropertyFlags1 |= ProxyGraphics.GraphicPropertyFlags.HasVisibilities;
        }
        ProxyGraphics.smethod_71(stream, graphicPropertyFlags1);
        if (graphicPropertyFlags1 != (ProxyGraphics.GraphicPropertyFlags) 0)
        {
          if ((graphicPropertyFlags1 & ProxyGraphics.GraphicPropertyFlags.HasColors) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            long position = stream.Position;
            for (int index = 0; (long) index < (long) this.uint_2; ++index)
              ProxyGraphics.smethod_59(stream, this.edgeData_0.Colors[index]);
            ProxyGraphics.smethod_74(stream, position);
          }
          if ((graphicPropertyFlags1 & ProxyGraphics.GraphicPropertyFlags.HasLayers) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            long position = stream.Position;
            for (int index = 0; (long) index < (long) this.uint_2; ++index)
            {
              short num2 = (short) model.Layers.IndexOf(this.edgeData_0.Layers[index]);
              if (num2 < (short) 0)
                num2 = num1;
              ProxyGraphics.smethod_58(stream, num2);
            }
            ProxyGraphics.smethod_74(stream, position);
          }
          if ((graphicPropertyFlags1 & ProxyGraphics.GraphicPropertyFlags.HasLineTypes) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            long position = stream.Position;
            for (int index = 0; (long) index < (long) this.uint_2; ++index)
            {
              short num2 = ProxyGraphics.smethod_37(stream);
              DxfLineType dxfLineType = (int) num2 < model.LineTypes.Count ? model.LineTypes[(int) num2] : model.ByLayerLineType;
              this.edgeData_0.LineTypes[index] = dxfLineType;
            }
            ProxyGraphics.smethod_74(stream, position);
          }
          if ((graphicPropertyFlags1 & ProxyGraphics.GraphicPropertyFlags.HasMarkers) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            for (int index = 0; (long) index < (long) this.uint_2; ++index)
              ProxyGraphics.smethod_60(stream, this.edgeData_0.SelectionMarkers[index]);
          }
          if ((graphicPropertyFlags1 & ProxyGraphics.GraphicPropertyFlags.HasVisibilities) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            for (int index = 0; (long) index < (long) this.uint_2; ++index)
              ProxyGraphics.smethod_61(stream, this.edgeData_0.Visibilities[index] ? 1U : 0U);
          }
        }
        this.faceData_0 = (ProxyGraphics.FaceData) null;
        ProxyGraphics.GraphicPropertyFlags graphicPropertyFlags2 = (ProxyGraphics.GraphicPropertyFlags) 0;
        if (this.faceData_0 != null)
        {
          if (this.faceData_0.Colors != null && (long) this.faceData_0.Colors.Count >= (long) this.uint_1)
            graphicPropertyFlags2 |= ProxyGraphics.GraphicPropertyFlags.HasColors;
          if (this.faceData_0.Layers != null && (long) this.faceData_0.Layers.Count >= (long) this.uint_1)
            graphicPropertyFlags2 |= ProxyGraphics.GraphicPropertyFlags.HasLayers;
          if (this.faceData_0.SelectionMarkers != null && (long) this.faceData_0.SelectionMarkers.Count >= (long) this.uint_1)
            graphicPropertyFlags2 |= ProxyGraphics.GraphicPropertyFlags.HasMarkers;
          if (this.faceData_0.Normals != null && (long) this.faceData_0.Normals.Count >= (long) this.uint_1)
            graphicPropertyFlags2 |= ProxyGraphics.GraphicPropertyFlags.HasNormals;
          if (this.faceData_0.Visibilities != null && (long) this.faceData_0.Visibilities.Count >= (long) this.uint_1)
            graphicPropertyFlags2 |= ProxyGraphics.GraphicPropertyFlags.HasVisibilities;
        }
        ProxyGraphics.smethod_71(stream, graphicPropertyFlags2);
        if (graphicPropertyFlags2 != (ProxyGraphics.GraphicPropertyFlags) 0)
        {
          if ((graphicPropertyFlags2 & ProxyGraphics.GraphicPropertyFlags.HasColors) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            long position = stream.Position;
            for (int index = 0; (long) index < (long) this.uint_1; ++index)
              ProxyGraphics.smethod_59(stream, this.faceData_0.Colors[index]);
            ProxyGraphics.smethod_74(stream, position);
          }
          if ((graphicPropertyFlags2 & ProxyGraphics.GraphicPropertyFlags.HasLayers) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            long position = stream.Position;
            for (int index = 0; (long) index < (long) this.uint_1; ++index)
            {
              short num2 = (short) model.Layers.IndexOf(this.faceData_0.Layers[index]);
              if (num2 < (short) 0)
                num2 = num1;
              ProxyGraphics.smethod_58(stream, num2);
            }
            ProxyGraphics.smethod_74(stream, position);
          }
          if ((graphicPropertyFlags2 & ProxyGraphics.GraphicPropertyFlags.HasMarkers) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            for (int index = 0; (long) index < (long) this.uint_1; ++index)
              ProxyGraphics.smethod_60(stream, this.faceData_0.SelectionMarkers[index]);
          }
          if ((graphicPropertyFlags2 & ProxyGraphics.GraphicPropertyFlags.HasNormals) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            for (int index = 0; (long) index < (long) this.uint_1; ++index)
              ProxyGraphics.smethod_69(stream, this.faceData_0.Normals[index]);
          }
          if ((graphicPropertyFlags2 & ProxyGraphics.GraphicPropertyFlags.HasVisibilities) != (ProxyGraphics.GraphicPropertyFlags) 0)
          {
            for (int index = 0; (long) index < (long) this.uint_1; ++index)
              ProxyGraphics.smethod_61(stream, this.faceData_0.Visibilities[index] ? 1U : 0U);
          }
        }
        this.vertexData_0 = (ProxyGraphics.VertexData) null;
        ProxyGraphics.GraphicPropertyFlags graphicPropertyFlags3 = (ProxyGraphics.GraphicPropertyFlags) 0;
        if (this.vertexData_0 != null)
        {
          if (this.vertexData_0.Normals != null && (long) this.vertexData_0.Normals.Count >= (long) this.uint_0)
            graphicPropertyFlags3 |= ProxyGraphics.GraphicPropertyFlags.HasNormals;
          if (this.vertexData_0.Orientation != ProxyGraphics.Orientation.None)
            graphicPropertyFlags3 |= ProxyGraphics.GraphicPropertyFlags.HasOrientation;
        }
        ProxyGraphics.smethod_71(stream, graphicPropertyFlags3);
        if (graphicPropertyFlags3 == (ProxyGraphics.GraphicPropertyFlags) 0)
          return;
        this.vertexData_0 = new ProxyGraphics.VertexData();
        if ((graphicPropertyFlags3 & ProxyGraphics.GraphicPropertyFlags.HasNormals) != (ProxyGraphics.GraphicPropertyFlags) 0)
        {
          for (int index = 0; (long) index < (long) this.uint_0; ++index)
            ProxyGraphics.smethod_69(stream, this.vertexData_0.Normals[index]);
        }
        if ((graphicPropertyFlags3 & ProxyGraphics.GraphicPropertyFlags.HasOrientation) == (ProxyGraphics.GraphicPropertyFlags) 0)
          return;
        ProxyGraphics.smethod_60(stream, (int) this.vertexData_0.Orientation);
      }

      internal override void TransformMe(ProxyGraphics.Class790 context)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ProxyGraphics.MeshBase.Class776 class776 = new ProxyGraphics.MeshBase.Class776();
        // ISSUE: reference to a compiler-generated field
        class776.meshBase_0 = this;
        // ISSUE: reference to a compiler-generated field
        class776.list_0 = (List<WW.Math.Point3D>) null;
        if (context.UndoGroup != null)
        {
          // ISSUE: reference to a compiler-generated field
          class776.list_0 = new List<WW.Math.Point3D>((IEnumerable<WW.Math.Point3D>) this.ilist_0);
        }
        Matrix4D transform = context.Transform;
        for (int index = 0; index < this.ilist_0.Count; ++index)
          this.ilist_0[index] = transform.Transform(this.ilist_0[index]);
        if (context.UndoGroup != null)
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          context.UndoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new ProxyGraphics.MeshBase.Class777()
          {
            class776_0 = class776,
            list_0 = new List<WW.Math.Point3D>((IEnumerable<WW.Math.Point3D>) this.ilist_0)
          }.method_0), new System.Action(class776.method_0)));
        }
        if (this.vertexData_0 == null)
          return;
        this.vertexData_0.TransformMe(context);
      }

      internal override bool HasGeometricData
      {
        get
        {
          return true;
        }
      }
    }

    public class Mesh : ProxyGraphics.MeshBase
    {
      private uint uint_3;
      private uint uint_4;

      public uint RowCount
      {
        get
        {
          return this.uint_3;
        }
        set
        {
          this.uint_3 = value;
        }
      }

      public uint ColumnCount
      {
        get
        {
          return this.uint_4;
        }
        set
        {
          this.uint_4 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        this.method_2(drawer, context).DrawInternal(context, graphicsFactory);
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        this.method_2(drawer, context).DrawInternal(context, graphicsFactory);
      }

      private DxfPolygonMesh method_2(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context)
      {
        DxfPolygonMesh dxfPolygonMesh = new DxfPolygonMesh();
        dxfPolygonMesh.method_12(drawer.EntityContext);
        dxfPolygonMesh.vmethod_2((IDxfHandledObject) context.Model);
        for (int index = 0; index < this.Points.Count; ++index)
          dxfPolygonMesh.Vertices.Add(new DxfVertex3D(this.Points[index]));
        dxfPolygonMesh.MVertexCount = (ushort) this.RowCount;
        dxfPolygonMesh.NVertexCount = (ushort) this.ColumnCount;
        return dxfPolygonMesh;
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.Mesh mesh = (ProxyGraphics.Mesh) context.GetExistingClone((IGraphCloneable) this);
        if (mesh == null)
        {
          mesh = new ProxyGraphics.Mesh();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) mesh);
          mesh.CopyFrom(context, this);
        }
        return (IGraphCloneable) mesh;
      }

      public void CopyFrom(CloneContext context, ProxyGraphics.Mesh from)
      {
        this.CopyFrom(context, (ProxyGraphics.MeshBase) from);
        this.uint_3 = from.uint_3;
        this.uint_4 = from.uint_4;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.uint_3 = ProxyGraphics.smethod_40(stream);
        this.uint_4 = ProxyGraphics.smethod_40(stream);
        uint num = this.uint_3 * this.uint_4;
        this.Points = (IList<WW.Math.Point3D>) new WW.Math.Point3D[(IntPtr) num];
        for (uint index = 0; index < num; ++index)
          this.Points[(int) index] = ProxyGraphics.smethod_46(stream);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_61(stream, this.uint_3);
        ProxyGraphics.smethod_61(stream, this.uint_4);
        uint num = this.uint_3 * this.uint_4;
        for (uint index = 0; index < num; ++index)
          ProxyGraphics.smethod_67(stream, this.Points[(int) index]);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_8;
        }
      }
    }

    public class Shell : ProxyGraphics.MeshBase
    {
      private int[] int_0;

      public int[] Faces
      {
        get
        {
          return this.int_0;
        }
        set
        {
          this.int_0 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        int index1 = 0;
        int index2 = 0;
        while (index2 < this.int_0.Length)
        {
          int capacity = this.int_0[index2];
          ++index2;
          if (capacity >= 0)
          {
            Polyline3D polyline = new Polyline3D(capacity, true);
            int num = 0;
            while (num < capacity)
            {
              int index3 = this.int_0[index2];
              polyline.Add(this.Points[index3]);
              ++num;
              ++index2;
            }
            EntityColor color = drawer.EntityContext.Color;
            if (this.FaceData != null && this.FaceData.Colors != null)
              drawer.EntityContext.Color = EntityColor.CreateFromColorIndex((short) this.FaceData.Colors[index1]);
            graphicsFactory.CreatePath(drawer.EntityContext, context, drawer.EntityContext.GetColor((DrawContext) context), false, context.GetTransformer().Transform(polyline, true), true, true);
            if (color != drawer.EntityContext.Color || this.EdgeData != null && this.EdgeData.Colors != null)
            {
              EntityColor fromColorIndex = EntityColor.CreateFromColorIndex((short) this.EdgeData.Colors[index1]);
              if (fromColorIndex != drawer.EntityContext.Color)
              {
                drawer.EntityContext.Color = fromColorIndex;
                graphicsFactory.CreatePath(drawer.EntityContext, context, drawer.EntityContext.GetColor((DrawContext) context), false, context.GetTransformer().Transform(polyline, false), false, true);
              }
            }
            drawer.EntityContext.Color = color;
          }
          else
            index2 += -capacity;
          ++index1;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        int index1 = 0;
        int index2 = 0;
        while (index2 < this.int_0.Length)
        {
          int capacity = this.int_0[index2];
          ++index2;
          if (capacity >= 0)
          {
            Polyline3D polyline = new Polyline3D(capacity, true);
            int num = 0;
            while (num < capacity)
            {
              int index3 = this.int_0[index2];
              polyline.Add(this.Points[index3]);
              ++num;
              ++index2;
            }
            EntityColor color = drawer.EntityContext.Color;
            if (this.FaceData != null && this.FaceData.Colors != null)
              drawer.EntityContext.Color = EntityColor.CreateFromColorIndex((short) this.FaceData.Colors[index1]);
            Class940.smethod_3(drawer.EntityContext, context, graphicsFactory, drawer.EntityContext.GetColor((DrawContext) context), false, true, false, context.GetTransformer().Transform(polyline, false));
            if (color != drawer.EntityContext.Color || this.EdgeData != null && this.EdgeData.Colors != null)
            {
              EntityColor fromColorIndex = EntityColor.CreateFromColorIndex((short) this.EdgeData.Colors[index1]);
              if (fromColorIndex != drawer.EntityContext.Color)
              {
                drawer.EntityContext.Color = fromColorIndex;
                Class940.smethod_3(drawer.EntityContext, context, graphicsFactory, drawer.EntityContext.GetColor((DrawContext) context), false, false, true, context.GetTransformer().Transform(polyline, false));
              }
            }
            drawer.EntityContext.Color = color;
          }
          else
            index2 += -capacity;
          ++index1;
        }
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.Shell shell = (ProxyGraphics.Shell) context.GetExistingClone((IGraphCloneable) this);
        if (shell == null)
        {
          shell = new ProxyGraphics.Shell();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) shell);
          shell.CopyFrom(context, this);
        }
        return (IGraphCloneable) shell;
      }

      public void CopyFrom(CloneContext context, ProxyGraphics.Shell from)
      {
        this.CopyFrom(context, (ProxyGraphics.MeshBase) from);
        if (from.int_0 == null)
        {
          this.int_0 = (int[]) null;
        }
        else
        {
          if (this.int_0 == null)
            this.int_0 = new int[from.int_0.Length];
          from.int_0.CopyTo((Array) this.int_0, 0);
        }
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.VertexCount = ProxyGraphics.smethod_40(stream);
        this.Points = (IList<WW.Math.Point3D>) new WW.Math.Point3D[(IntPtr) this.VertexCount];
        for (uint index = 0; index < this.VertexCount; ++index)
          this.Points[(int) index] = ProxyGraphics.smethod_46(stream);
        uint num = ProxyGraphics.smethod_40(stream);
        this.Faces = new int[(IntPtr) num];
        for (uint index = 0; index < num; ++index)
          this.Faces[(IntPtr) index] = ProxyGraphics.smethod_39(stream);
        this.method_2();
        this.method_0(proxyGraphics, stream, encoding, modelBuilder);
      }

      private void method_2()
      {
        uint num1 = 0;
        this.EdgeCount = 0U;
        uint num2;
        for (uint index = 0; (long) index < (long) this.Faces.Length; index = index + num2 + 1U)
        {
          int face = this.Faces[(IntPtr) index];
          num2 = (uint) System.Math.Abs(face);
          if (face > 0)
            ++num1;
          this.EdgeCount += num2;
        }
        this.FaceCount = num1;
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_61(stream, (uint) this.Points.Count);
        for (uint index = 0; index < this.VertexCount; ++index)
          ProxyGraphics.smethod_67(stream, this.Points[(int) index]);
        ProxyGraphics.smethod_61(stream, (uint) this.Faces.Length);
        for (uint index = 0; (long) index < (long) this.Faces.Length; ++index)
          ProxyGraphics.smethod_60(stream, this.Faces[(IntPtr) index]);
        this.method_2();
        this.method_1(proxyGraphics, stream, encoding, model);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_9;
        }
      }
    }

    public class EdgeData
    {
      private IList<ushort> ilist_0;
      private IList<EntityColor> ilist_1;
      private IList<DxfLayer> ilist_2;
      private IList<DxfLineType> ilist_3;
      private IList<int> ilist_4;
      private IList<bool> ilist_5;

      public IList<ushort> Colors
      {
        get
        {
          return this.ilist_0;
        }
        set
        {
          this.ilist_0 = value;
        }
      }

      public IList<EntityColor> TrueColors
      {
        get
        {
          return this.ilist_1;
        }
        set
        {
          this.ilist_1 = value;
        }
      }

      public IList<DxfLayer> Layers
      {
        get
        {
          return this.ilist_2;
        }
        set
        {
          this.ilist_2 = value;
        }
      }

      public IList<DxfLineType> LineTypes
      {
        get
        {
          return this.ilist_3;
        }
        set
        {
          this.ilist_3 = value;
        }
      }

      public IList<int> SelectionMarkers
      {
        get
        {
          return this.ilist_4;
        }
        set
        {
          this.ilist_4 = value;
        }
      }

      public IList<bool> Visibilities
      {
        get
        {
          return this.ilist_5;
        }
        set
        {
          this.ilist_5 = value;
        }
      }

      public void CopyFrom(CloneContext context, ProxyGraphics.EdgeData from)
      {
        if (from.ilist_0 == null)
          this.ilist_0 = (IList<ushort>) null;
        else if (this.ilist_0 == null)
        {
          this.ilist_0 = (IList<ushort>) new List<ushort>((IEnumerable<ushort>) from.ilist_0);
        }
        else
        {
          foreach (ushort num in (IEnumerable<ushort>) from.ilist_0)
            this.ilist_0.Add(num);
        }
        if (from.ilist_1 == null)
          this.ilist_1 = (IList<EntityColor>) null;
        else if (this.ilist_1 == null)
        {
          this.ilist_1 = (IList<EntityColor>) new List<EntityColor>((IEnumerable<EntityColor>) from.ilist_1);
        }
        else
        {
          foreach (EntityColor entityColor in (IEnumerable<EntityColor>) from.ilist_1)
            this.ilist_1.Add(entityColor);
        }
        if (from.ilist_2 == null)
        {
          this.ilist_2 = (IList<DxfLayer>) null;
        }
        else
        {
          if (this.ilist_2 == null)
            this.ilist_2 = (IList<DxfLayer>) new List<DxfLayer>(from.ilist_2.Count);
          foreach (DxfLayer from1 in (IEnumerable<DxfLayer>) from.ilist_2)
            this.ilist_2.Add(Class906.GetLayer(context, from1));
        }
        if (from.ilist_3 == null)
        {
          this.ilist_3 = (IList<DxfLineType>) null;
        }
        else
        {
          if (this.ilist_3 == null)
            this.ilist_3 = (IList<DxfLineType>) new List<DxfLineType>(from.ilist_3.Count);
          foreach (DxfLineType from1 in (IEnumerable<DxfLineType>) from.ilist_3)
            this.ilist_3.Add(Class906.GetLineType(context, from1));
        }
        if (from.ilist_4 == null)
          this.ilist_4 = (IList<int>) null;
        else if (this.ilist_4 == null)
        {
          this.ilist_4 = (IList<int>) new List<int>((IEnumerable<int>) from.ilist_4);
        }
        else
        {
          foreach (int num in (IEnumerable<int>) from.ilist_4)
            this.ilist_4.Add(num);
        }
        if (from.ilist_5 == null)
          this.ilist_5 = (IList<bool>) null;
        else if (this.ilist_5 == null)
        {
          this.ilist_5 = (IList<bool>) new List<bool>((IEnumerable<bool>) from.ilist_5);
        }
        else
        {
          foreach (bool flag in (IEnumerable<bool>) from.ilist_5)
            this.ilist_5.Add(flag);
        }
      }
    }

    public class FaceData
    {
      private IList<ushort> ilist_0;
      private IList<EntityColor> ilist_1;
      private IList<DxfLayer> ilist_2;
      private IList<int> ilist_3;
      private IList<bool> ilist_4;
      private IList<Vector3D> ilist_5;
      private IList<short> ilist_6;
      private IList<object> ilist_7;
      private IList<Transparency> ilist_8;

      public IList<ushort> Colors
      {
        get
        {
          return this.ilist_0;
        }
        set
        {
          this.ilist_0 = value;
        }
      }

      public IList<EntityColor> TrueColors
      {
        get
        {
          return this.ilist_1;
        }
        set
        {
          this.ilist_1 = value;
        }
      }

      public IList<DxfLayer> Layers
      {
        get
        {
          return this.ilist_2;
        }
        set
        {
          this.ilist_2 = value;
        }
      }

      public IList<int> SelectionMarkers
      {
        get
        {
          return this.ilist_3;
        }
        set
        {
          this.ilist_3 = value;
        }
      }

      public IList<bool> Visibilities
      {
        get
        {
          return this.ilist_4;
        }
        set
        {
          this.ilist_4 = value;
        }
      }

      public IList<Vector3D> Normals
      {
        get
        {
          return this.ilist_5;
        }
        set
        {
          this.ilist_5 = value;
        }
      }

      public IList<short> MaterialIndexes
      {
        get
        {
          return this.ilist_6;
        }
        set
        {
          this.ilist_6 = value;
        }
      }

      public IList<object> Mappers
      {
        get
        {
          return this.ilist_7;
        }
        set
        {
          this.ilist_7 = value;
        }
      }

      public IList<Transparency> Transparencies
      {
        get
        {
          return this.ilist_8;
        }
        set
        {
          this.ilist_8 = value;
        }
      }

      public void CopyFrom(CloneContext context, ProxyGraphics.FaceData from)
      {
        if (from.ilist_0 == null)
          this.ilist_0 = (IList<ushort>) null;
        else if (this.ilist_0 == null)
        {
          this.ilist_0 = (IList<ushort>) new List<ushort>((IEnumerable<ushort>) from.ilist_0);
        }
        else
        {
          foreach (ushort num in (IEnumerable<ushort>) from.ilist_0)
            this.ilist_0.Add(num);
        }
        if (from.ilist_1 == null)
          this.ilist_1 = (IList<EntityColor>) null;
        else if (this.ilist_1 == null)
        {
          this.ilist_1 = (IList<EntityColor>) new List<EntityColor>((IEnumerable<EntityColor>) from.ilist_1);
        }
        else
        {
          foreach (EntityColor entityColor in (IEnumerable<EntityColor>) from.ilist_1)
            this.ilist_1.Add(entityColor);
        }
        if (from.ilist_2 == null)
        {
          this.ilist_2 = (IList<DxfLayer>) null;
        }
        else
        {
          if (this.ilist_2 == null)
            this.ilist_2 = (IList<DxfLayer>) new List<DxfLayer>(from.ilist_2.Count);
          foreach (DxfLayer from1 in (IEnumerable<DxfLayer>) from.ilist_2)
            this.ilist_2.Add(Class906.GetLayer(context, from1));
        }
        if (from.ilist_3 == null)
          this.ilist_3 = (IList<int>) null;
        else if (this.ilist_3 == null)
        {
          this.ilist_3 = (IList<int>) new List<int>((IEnumerable<int>) from.ilist_3);
        }
        else
        {
          foreach (int num in (IEnumerable<int>) from.ilist_3)
            this.ilist_3.Add(num);
        }
        if (from.ilist_4 == null)
          this.ilist_4 = (IList<bool>) null;
        else if (this.ilist_4 == null)
        {
          this.ilist_4 = (IList<bool>) new List<bool>((IEnumerable<bool>) from.ilist_4);
        }
        else
        {
          foreach (bool flag in (IEnumerable<bool>) from.ilist_4)
            this.ilist_4.Add(flag);
        }
        if (from.ilist_5 == null)
          this.ilist_5 = (IList<Vector3D>) null;
        else if (this.ilist_5 == null)
        {
          this.ilist_5 = (IList<Vector3D>) new List<Vector3D>((IEnumerable<Vector3D>) from.ilist_5);
        }
        else
        {
          foreach (Vector3D vector3D in (IEnumerable<Vector3D>) from.ilist_5)
            this.ilist_5.Add(vector3D);
        }
        if (from.ilist_6 == null)
          this.ilist_6 = (IList<short>) null;
        else if (this.ilist_6 == null)
        {
          this.ilist_6 = (IList<short>) new List<short>((IEnumerable<short>) from.ilist_6);
        }
        else
        {
          foreach (short num in (IEnumerable<short>) from.ilist_6)
            this.ilist_6.Add(num);
        }
        if (from.ilist_8 == null)
          this.ilist_8 = (IList<Transparency>) null;
        else if (this.ilist_8 == null)
        {
          this.ilist_8 = (IList<Transparency>) new List<Transparency>((IEnumerable<Transparency>) from.ilist_8);
        }
        else
        {
          foreach (Transparency transparency in (IEnumerable<Transparency>) from.ilist_8)
            this.ilist_8.Add(transparency);
        }
      }
    }

    public class VertexData
    {
      private IList<Vector3D> ilist_0;
      private ProxyGraphics.Orientation orientation_0;
      private IList<EntityColor> ilist_1;

      public IList<Vector3D> Normals
      {
        get
        {
          return this.ilist_0;
        }
        set
        {
          this.ilist_0 = value;
        }
      }

      public ProxyGraphics.Orientation Orientation
      {
        get
        {
          return this.orientation_0;
        }
        set
        {
          this.orientation_0 = value;
        }
      }

      public IList<EntityColor> TrueColors
      {
        get
        {
          return this.ilist_1;
        }
        set
        {
          this.ilist_1 = value;
        }
      }

      internal void TransformMe(ProxyGraphics.Class790 context)
      {
        if (this.ilist_0 == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ProxyGraphics.VertexData.Class778 class778 = new ProxyGraphics.VertexData.Class778();
        // ISSUE: reference to a compiler-generated field
        class778.vertexData_0 = this;
        // ISSUE: reference to a compiler-generated field
        class778.list_0 = (List<Vector3D>) null;
        if (context.UndoGroup != null)
        {
          // ISSUE: reference to a compiler-generated field
          class778.list_0 = new List<Vector3D>((IEnumerable<Vector3D>) this.ilist_0);
        }
        Matrix4D transform = context.Transform;
        for (int index = 0; index < this.ilist_0.Count; ++index)
          this.ilist_0[index] = transform.Transform(this.ilist_0[index]);
        if (context.UndoGroup == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        context.UndoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new ProxyGraphics.VertexData.Class779()
        {
          class778_0 = class778,
          list_0 = new List<Vector3D>((IEnumerable<Vector3D>) this.ilist_0)
        }.method_0), new System.Action(class778.method_0)));
      }

      public void CopyFrom(CloneContext context, ProxyGraphics.VertexData from)
      {
        if (from.ilist_0 == null)
          this.ilist_0 = (IList<Vector3D>) null;
        else if (this.ilist_0 == null)
        {
          this.ilist_0 = (IList<Vector3D>) new List<Vector3D>((IEnumerable<Vector3D>) from.ilist_0);
        }
        else
        {
          foreach (Vector3D vector3D in (IEnumerable<Vector3D>) from.ilist_0)
            this.ilist_0.Add(vector3D);
        }
        this.orientation_0 = from.orientation_0;
        if (from.ilist_1 == null)
          this.ilist_1 = (IList<EntityColor>) null;
        else if (this.ilist_1 == null)
        {
          this.ilist_1 = (IList<EntityColor>) new List<EntityColor>((IEnumerable<EntityColor>) from.ilist_1);
        }
        else
        {
          foreach (EntityColor entityColor in (IEnumerable<EntityColor>) from.ilist_1)
            this.ilist_1.Add(entityColor);
        }
      }
    }

    public abstract class TextBase : ProxyGraphics.DrawCommand
    {
      private Vector3D vector3D_0 = Vector3D.ZAxis;
      private Vector3D vector3D_1 = Vector3D.XAxis;
      private string string_0 = string.Empty;
      private WW.Math.Point3D point3D_0;
      private double double_0;
      private double double_1;
      private double double_2;

      public WW.Math.Point3D Position
      {
        get
        {
          return this.point3D_0;
        }
        set
        {
          this.point3D_0 = value;
        }
      }

      public Vector3D Normal
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

      public Vector3D Direction
      {
        get
        {
          return this.vector3D_1;
        }
        set
        {
          this.vector3D_1 = value;
        }
      }

      public double Height
      {
        get
        {
          return this.double_0;
        }
        set
        {
          this.double_0 = value;
        }
      }

      public double Width
      {
        get
        {
          return this.double_1;
        }
        set
        {
          this.double_1 = value;
        }
      }

      public double ObliqueAngle
      {
        get
        {
          return this.double_2;
        }
        set
        {
          this.double_2 = value;
        }
      }

      public string Value
      {
        get
        {
          return this.string_0;
        }
        set
        {
          this.string_0 = value ?? string.Empty;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        this.method_0(drawer, context).Draw(context, graphicsFactory);
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        this.method_0(drawer, context).Draw(context, graphicsFactory);
      }

      private DxfMText method_0(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context)
      {
        DxfMText dxfMtext = new DxfMText(this.string_0, this.point3D_0, this.double_0) { XAxis = this.vector3D_1, ZAxis = this.vector3D_0, AttachmentPoint = AttachmentPoint.BottomLeft };
        dxfMtext.vmethod_2((IDxfHandledObject) context.Model);
        dxfMtext.method_12(drawer.EntityContext);
        DxfTextStyle dxfTextStyle = new DxfTextStyle() { ObliqueAngle = this.double_2 };
        dxfTextStyle.vmethod_2((IDxfHandledObject) context.Model);
        dxfMtext.Style = dxfTextStyle;
        return dxfMtext;
      }

      public void CopyFrom(ProxyGraphics.TextBase from)
      {
        this.point3D_0 = from.point3D_0;
        this.vector3D_0 = from.vector3D_0;
        this.vector3D_1 = from.vector3D_1;
        this.double_0 = from.double_0;
        this.double_1 = from.double_1;
        this.double_2 = from.double_2;
        this.string_0 = from.string_0;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.point3D_0 = ProxyGraphics.smethod_46(stream);
        this.vector3D_0 = ProxyGraphics.smethod_48(stream);
        this.vector3D_1 = ProxyGraphics.smethod_48(stream);
        this.double_0 = ProxyGraphics.smethod_44(stream);
        this.double_1 = ProxyGraphics.smethod_44(stream);
        this.double_2 = ProxyGraphics.smethod_44(stream);
        this.string_0 = this.ReadString(stream, encoding);
      }

      protected internal abstract string ReadString(Stream stream, Encoding encoding);

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_67(stream, this.point3D_0);
        ProxyGraphics.smethod_69(stream, this.vector3D_0);
        ProxyGraphics.smethod_69(stream, this.vector3D_1);
        ProxyGraphics.smethod_65(stream, this.double_0);
        ProxyGraphics.smethod_65(stream, this.double_1);
        ProxyGraphics.smethod_65(stream, this.double_2);
        this.WriteString(stream, encoding, this.string_0);
      }

      protected internal abstract void WriteString(Stream stream, Encoding encoding, string value);

      internal override void TransformMe(ProxyGraphics.Class790 context)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ProxyGraphics.TextBase.Class780 class780 = new ProxyGraphics.TextBase.Class780();
        // ISSUE: reference to a compiler-generated field
        class780.textBase_0 = this;
        // ISSUE: reference to a compiler-generated field
        class780.point3D_0 = this.point3D_0;
        // ISSUE: reference to a compiler-generated field
        class780.double_0 = this.double_0;
        // ISSUE: reference to a compiler-generated field
        class780.double_1 = this.double_1;
        // ISSUE: reference to a compiler-generated field
        class780.vector3D_0 = this.vector3D_0;
        // ISSUE: reference to a compiler-generated field
        class780.vector3D_1 = this.vector3D_1;
        Matrix4D transform = context.Transform;
        this.vector3D_1 = transform.Transform(this.vector3D_1);
        this.vector3D_1.Normalize();
        this.vector3D_0 = transform.Transform(this.vector3D_0);
        this.vector3D_0.Normalize();
        Matrix4D inverse = DxfUtil.GetToWCSTransform(this.vector3D_1, this.vector3D_0).GetInverse();
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Matrix4D toWcsTransform = DxfUtil.GetToWCSTransform(class780.vector3D_1, class780.vector3D_0);
        Matrix4D matrix4D = inverse * transform * toWcsTransform;
        this.point3D_0 = transform.Transform(this.point3D_0);
        this.double_0 = matrix4D.Transform(new Vector3D(0.0, this.double_0, 0.0)).GetLength();
        this.double_1 = matrix4D.Transform(new Vector3D(this.double_1, 0.0, 0.0)).GetLength();
        if (context.UndoGroup == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        context.UndoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new ProxyGraphics.TextBase.Class781()
        {
          class780_0 = class780,
          point3D_0 = this.point3D_0,
          double_0 = this.double_0,
          double_1 = this.double_1,
          vector3D_0 = this.vector3D_0,
          vector3D_1 = this.vector3D_1
        }.method_0), new System.Action(class780.method_0)));
      }

      internal override bool HasGeometricData
      {
        get
        {
          return true;
        }
      }
    }

    public class Text : ProxyGraphics.TextBase
    {
      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.Text text = (ProxyGraphics.Text) context.GetExistingClone((IGraphCloneable) this);
        if (text == null)
        {
          text = new ProxyGraphics.Text();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) text);
          text.CopyFrom((ProxyGraphics.TextBase) this);
        }
        return (IGraphCloneable) text;
      }

      protected internal override string ReadString(Stream stream, Encoding encoding)
      {
        return ProxyGraphics.smethod_51(stream, encoding);
      }

      protected internal override void WriteString(Stream stream, Encoding encoding, string value)
      {
        ProxyGraphics.smethod_72(stream, encoding, value);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_10;
        }
      }
    }

    public abstract class Text2Base : ProxyGraphics.DrawCommand
    {
      private Vector3D vector3D_0 = Vector3D.ZAxis;
      private Vector3D vector3D_1 = Vector3D.XAxis;
      private string string_0 = string.Empty;
      private ProxyGraphics.TextStyle textStyle_0 = new ProxyGraphics.TextStyle();
      private WW.Math.Point3D point3D_0;
      private bool bool_0;

      public Vector3D Normal
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

      public WW.Math.Point3D Position
      {
        get
        {
          return this.point3D_0;
        }
        set
        {
          this.point3D_0 = value;
        }
      }

      public Vector3D Direction
      {
        get
        {
          return this.vector3D_1;
        }
        set
        {
          this.vector3D_1 = value;
        }
      }

      public string Value
      {
        get
        {
          return this.string_0;
        }
        set
        {
          this.string_0 = value ?? string.Empty;
        }
      }

      public bool Raw
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

      public ProxyGraphics.TextStyle TextStyle
      {
        get
        {
          return this.textStyle_0;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        this.method_0(drawer, context).Draw(context, graphicsFactory);
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        this.method_0(drawer, context).Draw(context, graphicsFactory);
      }

      private DxfMText method_0(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context)
      {
        string text = this.string_0;
        if (this.textStyle_0.IsUnderlined)
          text = "\\L" + text;
        if (this.textStyle_0.IsOverlined)
          text = "\\O" + text;
        if (this.textStyle_0.XScale != 1.0)
          text = "\\W" + this.textStyle_0.XScale.ToString((IFormatProvider) CultureInfo.InvariantCulture) + ";" + text;
        DxfMText dxfMtext = new DxfMText(text, this.point3D_0, this.textStyle_0.TextSize) { XAxis = this.vector3D_1, ZAxis = this.vector3D_0, AttachmentPoint = AttachmentPoint.BottomLeft };
        dxfMtext.vmethod_2((IDxfHandledObject) context.Model);
        dxfMtext.method_12(drawer.EntityContext);
        DxfTextStyle dxfTextStyle = new DxfTextStyle() { FontFilename = this.textStyle_0.FontFilename, BigFontFilename = this.textStyle_0.BigFontFilename, ObliqueAngle = this.textStyle_0.ObliqueAngle, IsVertical = this.textStyle_0.IsVertical, TrueTypeFontDescriptor = this.textStyle_0.TrueTypeFontDescriptor };
        dxfTextStyle.vmethod_2((IDxfHandledObject) context.Model);
        dxfMtext.Style = dxfTextStyle;
        return dxfMtext;
      }

      public void CopyFrom(ProxyGraphics.Text2Base from)
      {
        this.point3D_0 = from.point3D_0;
        this.vector3D_0 = from.vector3D_0;
        this.vector3D_1 = from.vector3D_1;
        this.string_0 = from.string_0;
        this.bool_0 = from.bool_0;
        this.textStyle_0.CopyFrom(from.textStyle_0);
      }

      internal override void TransformMe(ProxyGraphics.Class790 context)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ProxyGraphics.Text2Base.Class782 class782 = new ProxyGraphics.Text2Base.Class782();
        // ISSUE: reference to a compiler-generated field
        class782.text2Base_0 = this;
        // ISSUE: reference to a compiler-generated field
        class782.point3D_0 = this.point3D_0;
        // ISSUE: reference to a compiler-generated field
        class782.vector3D_0 = this.vector3D_0;
        // ISSUE: reference to a compiler-generated field
        class782.vector3D_1 = this.vector3D_1;
        Matrix4D transform = context.Transform;
        this.vector3D_1 = transform.Transform(this.vector3D_1);
        this.vector3D_1.Normalize();
        this.vector3D_0 = transform.Transform(this.vector3D_0);
        this.vector3D_0.Normalize();
        this.point3D_0 = transform.Transform(this.point3D_0);
        if (context.UndoGroup == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        context.UndoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new ProxyGraphics.Text2Base.Class783()
        {
          class782_0 = class782,
          point3D_0 = this.point3D_0,
          vector3D_0 = this.vector3D_0,
          vector3D_1 = this.vector3D_1
        }.method_0), new System.Action(class782.method_0)));
      }

      internal override bool HasGeometricData
      {
        get
        {
          return true;
        }
      }
    }

    public class Text2 : ProxyGraphics.Text2Base
    {
      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.Text2 text2 = (ProxyGraphics.Text2) context.GetExistingClone((IGraphCloneable) this);
        if (text2 == null)
        {
          text2 = new ProxyGraphics.Text2();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) text2);
          text2.CopyFrom((ProxyGraphics.Text2Base) this);
        }
        return (IGraphCloneable) text2;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.Position = ProxyGraphics.smethod_46(stream);
        this.Normal = ProxyGraphics.smethod_48(stream);
        this.Direction = ProxyGraphics.smethod_48(stream);
        byte[] bytes = ProxyGraphics.smethod_52(stream);
        int count = ProxyGraphics.smethod_39(stream);
        if (count == -1 || count > bytes.Length)
          count = bytes.Length;
        this.Value = encoding.GetString(bytes, 0, count);
        this.Raw = ProxyGraphics.smethod_34(stream);
        this.TextStyle.Read(proxyGraphics, stream, encoding);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_67(stream, this.Position);
        ProxyGraphics.smethod_69(stream, this.Normal);
        ProxyGraphics.smethod_69(stream, this.Direction);
        byte[] bytes = encoding.GetBytes(this.Value);
        ProxyGraphics.smethod_60(stream, bytes.Length);
        ProxyGraphics.smethod_57(stream, bytes, 0, bytes.Length);
        ProxyGraphics.smethod_55(stream, this.Raw);
        this.TextStyle.Write(proxyGraphics, stream, encoding);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_11;
        }
      }
    }

    public class XLine : ProxyGraphics.DrawCommand
    {
      private WW.Math.Point3D point3D_0;
      private WW.Math.Point3D point3D_1;

      public WW.Math.Point3D P1
      {
        get
        {
          return this.point3D_0;
        }
        set
        {
          this.point3D_0 = value;
        }
      }

      public WW.Math.Point3D P2
      {
        get
        {
          return this.point3D_1;
        }
        set
        {
          this.point3D_1 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.XLine xline = (ProxyGraphics.XLine) context.GetExistingClone((IGraphCloneable) this);
        if (xline == null)
        {
          xline = new ProxyGraphics.XLine();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) xline);
          xline.CopyFrom(this);
        }
        return (IGraphCloneable) xline;
      }

      public void CopyFrom(ProxyGraphics.XLine from)
      {
        this.point3D_0 = from.point3D_0;
        this.point3D_1 = from.point3D_1;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.point3D_0 = ProxyGraphics.smethod_46(stream);
        this.point3D_1 = ProxyGraphics.smethod_46(stream);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_67(stream, this.point3D_0);
        ProxyGraphics.smethod_67(stream, this.point3D_1);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_12;
        }
      }

      internal override void TransformMe(ProxyGraphics.Class790 context)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ProxyGraphics.XLine.Class784 class784 = new ProxyGraphics.XLine.Class784();
        // ISSUE: reference to a compiler-generated field
        class784.xline_0 = this;
        // ISSUE: reference to a compiler-generated field
        class784.point3D_0 = this.point3D_0;
        // ISSUE: reference to a compiler-generated field
        class784.point3D_1 = this.point3D_1;
        this.point3D_0 = context.Transform.Transform(this.point3D_0);
        this.point3D_1 = context.Transform.Transform(this.point3D_1);
        if (context.UndoGroup == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        context.UndoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new ProxyGraphics.XLine.Class785()
        {
          class784_0 = class784,
          point3D_0 = this.point3D_0,
          point3D_1 = this.point3D_1
        }.method_0), new System.Action(class784.method_0)));
      }

      internal override bool HasGeometricData
      {
        get
        {
          return true;
        }
      }
    }

    public class Ray : ProxyGraphics.DrawCommand
    {
      private WW.Math.Point3D point3D_0;
      private WW.Math.Point3D point3D_1;

      public WW.Math.Point3D P1
      {
        get
        {
          return this.point3D_0;
        }
        set
        {
          this.point3D_0 = value;
        }
      }

      public WW.Math.Point3D P2
      {
        get
        {
          return this.point3D_1;
        }
        set
        {
          this.point3D_1 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.Ray ray = (ProxyGraphics.Ray) context.GetExistingClone((IGraphCloneable) this);
        if (ray == null)
        {
          ray = new ProxyGraphics.Ray();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) ray);
          ray.CopyFrom(this);
        }
        return (IGraphCloneable) ray;
      }

      public void CopyFrom(ProxyGraphics.Ray from)
      {
        this.point3D_0 = from.point3D_0;
        this.point3D_1 = from.point3D_1;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.point3D_0 = ProxyGraphics.smethod_46(stream);
        this.point3D_1 = ProxyGraphics.smethod_46(stream);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_67(stream, this.point3D_0);
        ProxyGraphics.smethod_67(stream, this.point3D_1);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_13;
        }
      }

      internal override void TransformMe(ProxyGraphics.Class790 context)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ProxyGraphics.Ray.Class786 class786 = new ProxyGraphics.Ray.Class786();
        // ISSUE: reference to a compiler-generated field
        class786.ray_0 = this;
        // ISSUE: reference to a compiler-generated field
        class786.point3D_0 = this.point3D_0;
        // ISSUE: reference to a compiler-generated field
        class786.point3D_1 = this.point3D_1;
        this.point3D_0 = context.Transform.Transform(this.point3D_0);
        this.point3D_1 = context.Transform.Transform(this.point3D_1);
        if (context.UndoGroup == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        context.UndoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new ProxyGraphics.Ray.Class787()
        {
          class786_0 = class786,
          point3D_0 = this.point3D_0,
          point3D_1 = this.point3D_1
        }.method_0), new System.Action(class786.method_0)));
      }

      internal override bool HasGeometricData
      {
        get
        {
          return true;
        }
      }
    }

    public class SetSubEntityColor : ProxyGraphics.DrawCommand
    {
      private short short_0;

      public short ColorIndex
      {
        get
        {
          return this.short_0;
        }
        set
        {
          this.short_0 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        drawer.EntityContext.Color = EntityColor.CreateFromColorIndex(this.short_0);
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        drawer.EntityContext.Color = EntityColor.CreateFromColorIndex(this.short_0);
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.SetSubEntityColor setSubEntityColor = (ProxyGraphics.SetSubEntityColor) context.GetExistingClone((IGraphCloneable) this);
        if (setSubEntityColor == null)
        {
          setSubEntityColor = new ProxyGraphics.SetSubEntityColor();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) setSubEntityColor);
          setSubEntityColor.CopyFrom(this);
        }
        return (IGraphCloneable) setSubEntityColor;
      }

      public void CopyFrom(ProxyGraphics.SetSubEntityColor from)
      {
        this.short_0 = from.short_0;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.short_0 = (short) ProxyGraphics.smethod_39(stream);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_60(stream, (int) this.short_0);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_14;
        }
      }
    }

    public class SetSubEntityLayer : ProxyGraphics.DrawCommand
    {
      private DxfLayer dxfLayer_0;

      public DxfLayer Layer
      {
        get
        {
          return this.dxfLayer_0;
        }
        set
        {
          this.dxfLayer_0 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        drawer.EntityContext.Layer = this.dxfLayer_0;
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        drawer.EntityContext.Layer = this.dxfLayer_0;
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.SetSubEntityLayer setSubEntityLayer = (ProxyGraphics.SetSubEntityLayer) context.GetExistingClone((IGraphCloneable) this);
        if (setSubEntityLayer == null)
        {
          setSubEntityLayer = new ProxyGraphics.SetSubEntityLayer();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) setSubEntityLayer);
          setSubEntityLayer.CopyFrom(context, this);
        }
        return (IGraphCloneable) setSubEntityLayer;
      }

      public void CopyFrom(CloneContext context, ProxyGraphics.SetSubEntityLayer from)
      {
        this.dxfLayer_0 = Class906.GetLayer(context, from.dxfLayer_0);
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        builder.Builders.AddLast((Interface10) new ProxyGraphics.SetSubEntityLayer.Class788(this)
        {
          LayerIndex = (short) ProxyGraphics.smethod_39(stream)
        });
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        int num = model.Layers.IndexOf(this.dxfLayer_0);
        if (num < 0)
          num = model.Layers.IndexOf(model.ZeroLayer);
        if (num < 0)
          num = 0;
        ProxyGraphics.smethod_60(stream, num);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_16;
        }
      }

      private class Class788 : Interface10
      {
        private ProxyGraphics.SetSubEntityLayer setSubEntityLayer_0;
        private short short_0;

        public Class788(ProxyGraphics.SetSubEntityLayer setSubEntityLayer)
        {
          this.setSubEntityLayer_0 = setSubEntityLayer;
        }

        public short LayerIndex
        {
          get
          {
            return this.short_0;
          }
          set
          {
            this.short_0 = value;
          }
        }

        public void ResolveReferences(Class374 modelBuilder)
        {
          DxfModel model = modelBuilder.Model;
          this.setSubEntityLayer_0.dxfLayer_0 = this.short_0 < (short) 0 || (int) this.short_0 >= model.Layers.Count ? model.ZeroLayer : model.Layers[(int) this.short_0];
        }
      }
    }

    public class SetSubEntityLineType : ProxyGraphics.DrawCommand
    {
      private DxfLineType dxfLineType_0;

      public DxfLineType LineType
      {
        get
        {
          return this.dxfLineType_0;
        }
        set
        {
          this.dxfLineType_0 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        DxfEntity entityContext = drawer.EntityContext;
        DxfLineType dxfLineType = this.dxfLineType_0;
        if (dxfLineType == null)
        {
          DxfLineType lineType = drawer.ParentEntity.LineType;
          if (lineType == null)
          {
            dxfLineType = lineType;
          }
          else
          {
            dxfLineType = lineType;
            goto label_4;
          }
        }
        else if (dxfLineType != null)
          goto label_4;
        dxfLineType = context.Model.ContinuousLineType;
label_4:
        entityContext.LineType = dxfLineType;
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        DxfEntity entityContext = drawer.EntityContext;
        DxfLineType dxfLineType = this.dxfLineType_0;
        if (dxfLineType == null)
        {
          DxfLineType lineType = drawer.ParentEntity.LineType;
          if (lineType == null)
          {
            dxfLineType = lineType;
          }
          else
          {
            dxfLineType = lineType;
            goto label_4;
          }
        }
        else if (dxfLineType != null)
          goto label_4;
        dxfLineType = context.Model.ContinuousLineType;
label_4:
        entityContext.LineType = dxfLineType;
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.SetSubEntityLineType subEntityLineType = (ProxyGraphics.SetSubEntityLineType) context.GetExistingClone((IGraphCloneable) this);
        if (subEntityLineType == null)
        {
          subEntityLineType = new ProxyGraphics.SetSubEntityLineType();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) subEntityLineType);
          subEntityLineType.CopyFrom(context, this);
        }
        return (IGraphCloneable) subEntityLineType;
      }

      public void CopyFrom(CloneContext context, ProxyGraphics.SetSubEntityLineType from)
      {
        this.dxfLineType_0 = Class906.GetLineType(context, from.dxfLineType_0);
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        builder.Builders.AddLast((Interface10) new ProxyGraphics.SetSubEntityLineType.Class789(this)
        {
          LineTypeIndex = (short) ProxyGraphics.smethod_39(stream)
        });
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        int num;
        if (this.dxfLineType_0 == null)
          num = (int) short.MaxValue;
        else if (this.dxfLineType_0 == model.ByLayerLineType)
          num = -1;
        else if (this.dxfLineType_0 == model.ByBlockLineType)
        {
          num = -2;
        }
        else
        {
          num = model.LineTypes.IndexOf(this.dxfLineType_0);
          if (num < 0)
            num = (int) short.MaxValue;
        }
        ProxyGraphics.smethod_60(stream, num);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_18;
        }
      }

      private class Class789 : Interface10
      {
        private ProxyGraphics.SetSubEntityLineType setSubEntityLineType_0;
        private short short_0;

        public Class789(
          ProxyGraphics.SetSubEntityLineType setSubEntityLineType)
        {
          this.setSubEntityLineType_0 = setSubEntityLineType;
        }

        public short LineTypeIndex
        {
          get
          {
            return this.short_0;
          }
          set
          {
            this.short_0 = value;
          }
        }

        public void ResolveReferences(Class374 modelBuilder)
        {
          DxfModel model = modelBuilder.Model;
          if (this.short_0 < (short) 0)
          {
            if (this.short_0 == (short) -1)
              this.setSubEntityLineType_0.dxfLineType_0 = model.ByLayerLineType;
            else if (this.short_0 == (short) -2)
              this.setSubEntityLineType_0.dxfLineType_0 = model.ByBlockLineType;
            else
              this.setSubEntityLineType_0.dxfLineType_0 = model.ContinuousLineType;
          }
          else
            this.setSubEntityLineType_0.dxfLineType_0 = (int) this.short_0 < model.LineTypes.Count ? model.LineTypes[(int) this.short_0] : (DxfLineType) null;
        }
      }
    }

    public class SetSubEntitySelectionMarker : ProxyGraphics.DrawCommand
    {
      private int int_0;

      public int SelectionMarker
      {
        get
        {
          return this.int_0;
        }
        set
        {
          this.int_0 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.SetSubEntitySelectionMarker entitySelectionMarker = (ProxyGraphics.SetSubEntitySelectionMarker) context.GetExistingClone((IGraphCloneable) this);
        if (entitySelectionMarker == null)
        {
          entitySelectionMarker = new ProxyGraphics.SetSubEntitySelectionMarker();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) entitySelectionMarker);
          entitySelectionMarker.CopyFrom(this);
        }
        return (IGraphCloneable) entitySelectionMarker;
      }

      public void CopyFrom(ProxyGraphics.SetSubEntitySelectionMarker from)
      {
        this.int_0 = from.int_0;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.int_0 = ProxyGraphics.smethod_39(stream);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_60(stream, this.int_0);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_19;
        }
      }
    }

    public class SetSubEntityFillOn : ProxyGraphics.DrawCommand
    {
      private ProxyGraphics.FillType fillType_0;

      public ProxyGraphics.FillType FillType
      {
        get
        {
          return this.fillType_0;
        }
        set
        {
          this.fillType_0 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        drawer.FillType = this.fillType_0;
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        drawer.FillType = this.fillType_0;
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.SetSubEntityFillOn setSubEntityFillOn = (ProxyGraphics.SetSubEntityFillOn) context.GetExistingClone((IGraphCloneable) this);
        if (setSubEntityFillOn == null)
        {
          setSubEntityFillOn = new ProxyGraphics.SetSubEntityFillOn();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) setSubEntityFillOn);
          setSubEntityFillOn.CopyFrom(this);
        }
        return (IGraphCloneable) setSubEntityFillOn;
      }

      public void CopyFrom(ProxyGraphics.SetSubEntityFillOn from)
      {
        this.fillType_0 = from.fillType_0;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.fillType_0 = (ProxyGraphics.FillType) ProxyGraphics.smethod_39(stream);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_60(stream, (int) this.fillType_0);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_20;
        }
      }
    }

    public class SetSubEntityTrueColor : ProxyGraphics.DrawCommand
    {
      private EntityColor entityColor_0;

      public EntityColor Color
      {
        get
        {
          return this.entityColor_0;
        }
        set
        {
          this.entityColor_0 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        drawer.EntityContext.Color = this.entityColor_0;
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        drawer.EntityContext.Color = this.entityColor_0;
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.SetSubEntityTrueColor subEntityTrueColor = (ProxyGraphics.SetSubEntityTrueColor) context.GetExistingClone((IGraphCloneable) this);
        if (subEntityTrueColor == null)
        {
          subEntityTrueColor = new ProxyGraphics.SetSubEntityTrueColor();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) subEntityTrueColor);
          subEntityTrueColor.CopyFrom(this);
        }
        return (IGraphCloneable) subEntityTrueColor;
      }

      public void CopyFrom(ProxyGraphics.SetSubEntityTrueColor from)
      {
        this.entityColor_0 = from.entityColor_0;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        int num = (int) ProxyGraphics.smethod_35(stream) | (int) ProxyGraphics.smethod_35(stream) << 8 | (int) ProxyGraphics.smethod_35(stream) << 16;
        this.entityColor_0 = EntityColor.smethod_0((uint) ((int) ProxyGraphics.smethod_35(stream) << 24 | num));
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        uint data = this.entityColor_0.Data;
        ProxyGraphics.smethod_56(stream, (byte) (data & (uint) byte.MaxValue));
        ProxyGraphics.smethod_56(stream, (byte) (data >> 8 & (uint) byte.MaxValue));
        ProxyGraphics.smethod_56(stream, (byte) (data >> 16 & (uint) byte.MaxValue));
        ProxyGraphics.smethod_56(stream, (byte) (data >> 24 & (uint) byte.MaxValue));
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_22;
        }
      }
    }

    public class SetSubEntityLineWeight : ProxyGraphics.DrawCommand
    {
      private short short_0;

      public short LineWeight
      {
        get
        {
          return this.short_0;
        }
        set
        {
          this.short_0 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        drawer.EntityContext.LineWeight = this.short_0;
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        drawer.EntityContext.LineWeight = this.short_0;
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.SetSubEntityLineWeight entityLineWeight = (ProxyGraphics.SetSubEntityLineWeight) context.GetExistingClone((IGraphCloneable) this);
        if (entityLineWeight == null)
        {
          entityLineWeight = new ProxyGraphics.SetSubEntityLineWeight();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) entityLineWeight);
          entityLineWeight.CopyFrom(this);
        }
        return (IGraphCloneable) entityLineWeight;
      }

      public void CopyFrom(ProxyGraphics.SetSubEntityLineWeight from)
      {
        this.short_0 = from.short_0;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.short_0 = (short) ProxyGraphics.smethod_39(stream);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_60(stream, (int) this.short_0);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_23;
        }
      }
    }

    public class SetSubEntityLineTypeScale : ProxyGraphics.DrawCommand
    {
      private double double_0;

      public double LineTypeScale
      {
        get
        {
          return this.double_0;
        }
        set
        {
          this.double_0 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        drawer.EntityContext.LineTypeScale = this.double_0;
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        drawer.EntityContext.LineTypeScale = this.double_0;
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.SetSubEntityLineTypeScale entityLineTypeScale = (ProxyGraphics.SetSubEntityLineTypeScale) context.GetExistingClone((IGraphCloneable) this);
        if (entityLineTypeScale == null)
        {
          entityLineTypeScale = new ProxyGraphics.SetSubEntityLineTypeScale();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) entityLineTypeScale);
          entityLineTypeScale.CopyFrom(this);
        }
        return (IGraphCloneable) entityLineTypeScale;
      }

      public void CopyFrom(ProxyGraphics.SetSubEntityLineTypeScale from)
      {
        this.double_0 = from.double_0;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.double_0 = (double) (short) ProxyGraphics.smethod_44(stream);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_65(stream, this.double_0);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_24;
        }
      }
    }

    public class SetSubEntityThickness : ProxyGraphics.DrawCommand
    {
      private double double_0;

      public double Thickness
      {
        get
        {
          return this.double_0;
        }
        set
        {
          this.double_0 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        drawer.Thickness = this.double_0;
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        drawer.Thickness = this.double_0;
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.SetSubEntityThickness subEntityThickness = (ProxyGraphics.SetSubEntityThickness) context.GetExistingClone((IGraphCloneable) this);
        if (subEntityThickness == null)
        {
          subEntityThickness = new ProxyGraphics.SetSubEntityThickness();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) subEntityThickness);
          subEntityThickness.CopyFrom(this);
        }
        return (IGraphCloneable) subEntityThickness;
      }

      public void CopyFrom(ProxyGraphics.SetSubEntityThickness from)
      {
        this.double_0 = from.double_0;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.double_0 = (double) (short) ProxyGraphics.smethod_44(stream);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_65(stream, this.double_0);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_25;
        }
      }
    }

    public class SetSubEntityPlotStyleName : ProxyGraphics.DrawCommand
    {
      private ProxyGraphics.PlotStyleNameType plotStyleNameType_0;
      private uint uint_0;

      public ProxyGraphics.PlotStyleNameType PlotStyleNameType
      {
        get
        {
          return this.plotStyleNameType_0;
        }
        set
        {
          this.plotStyleNameType_0 = value;
        }
      }

      public uint Index
      {
        get
        {
          return this.uint_0;
        }
        set
        {
          this.uint_0 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.SetSubEntityPlotStyleName entityPlotStyleName = (ProxyGraphics.SetSubEntityPlotStyleName) context.GetExistingClone((IGraphCloneable) this);
        if (entityPlotStyleName == null)
        {
          entityPlotStyleName = new ProxyGraphics.SetSubEntityPlotStyleName();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) entityPlotStyleName);
          entityPlotStyleName.CopyFrom(this);
        }
        return (IGraphCloneable) entityPlotStyleName;
      }

      public void CopyFrom(ProxyGraphics.SetSubEntityPlotStyleName from)
      {
        this.plotStyleNameType_0 = from.plotStyleNameType_0;
        this.uint_0 = from.uint_0;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.plotStyleNameType_0 = (ProxyGraphics.PlotStyleNameType) ProxyGraphics.smethod_39(stream);
        this.uint_0 = ProxyGraphics.smethod_40(stream);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_60(stream, (int) this.plotStyleNameType_0);
        ProxyGraphics.smethod_61(stream, this.uint_0);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_26;
        }
      }
    }

    public class PushClip : ProxyGraphics.DrawCommand
    {
      private Vector3D vector3D_0 = Vector3D.ZAxis;
      private Matrix4D matrix4D_0 = Matrix4D.Identity;
      private Matrix4D matrix4D_1 = Matrix4D.Identity;
      private WW.Math.Point3D point3D_0;
      private WW.Math.Point2D[] point2D_0;
      private bool bool_0;
      private bool bool_1;
      private double double_0;
      private double double_1;
      private bool bool_2;

      public Vector3D ClipPlaneNormal
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

      public WW.Math.Point3D ClipBoundaryOrigin
      {
        get
        {
          return this.point3D_0;
        }
        set
        {
          this.point3D_0 = value;
        }
      }

      public WW.Math.Point2D[] ClipBoundary
      {
        get
        {
          return this.point2D_0;
        }
        set
        {
          this.point2D_0 = value;
        }
      }

      public Matrix4D WcsToClipCsTransform
      {
        get
        {
          return this.matrix4D_0;
        }
        set
        {
          this.matrix4D_0 = value;
        }
      }

      public Matrix4D BlockCsToWcsTransform
      {
        get
        {
          return this.matrix4D_1;
        }
        set
        {
          this.matrix4D_1 = value;
        }
      }

      public bool ClipFront
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

      public bool ClipBack
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

      public double FrontClipZ
      {
        get
        {
          return this.double_0;
        }
        set
        {
          this.double_0 = value;
        }
      }

      public double BackClipZ
      {
        get
        {
          return this.double_1;
        }
        set
        {
          this.double_1 = value;
        }
      }

      public bool DrawBoundary
      {
        get
        {
          return this.bool_2;
        }
        set
        {
          this.bool_2 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.PushClip pushClip = (ProxyGraphics.PushClip) context.GetExistingClone((IGraphCloneable) this);
        if (pushClip == null)
        {
          pushClip = new ProxyGraphics.PushClip();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) pushClip);
          pushClip.CopyFrom(this);
        }
        return (IGraphCloneable) pushClip;
      }

      public void CopyFrom(ProxyGraphics.PushClip from)
      {
        this.vector3D_0 = from.vector3D_0;
        this.point3D_0 = from.point3D_0;
        if (from.point2D_0 == null)
        {
          this.point2D_0 = (WW.Math.Point2D[]) null;
        }
        else
        {
          if (this.point2D_0 == null)
            this.point2D_0 = new WW.Math.Point2D[from.point2D_0.Length];
          from.point2D_0.CopyTo((Array) this.point2D_0, 0);
        }
        this.matrix4D_0 = from.matrix4D_0;
        this.matrix4D_1 = from.matrix4D_1;
        this.bool_0 = from.bool_0;
        this.bool_1 = from.bool_1;
        this.double_0 = from.double_0;
        this.double_1 = from.double_1;
        this.bool_2 = from.bool_2;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.vector3D_0 = ProxyGraphics.smethod_48(stream);
        this.point3D_0 = ProxyGraphics.smethod_46(stream);
        int length = ProxyGraphics.smethod_39(stream);
        this.point2D_0 = new WW.Math.Point2D[length];
        for (int index = 0; index < length; ++index)
          this.point2D_0[index] = ProxyGraphics.smethod_45(stream);
        this.matrix4D_0 = ProxyGraphics.smethod_49(stream);
        this.matrix4D_1 = ProxyGraphics.smethod_49(stream);
        this.bool_0 = ProxyGraphics.smethod_34(stream);
        this.bool_1 = ProxyGraphics.smethod_34(stream);
        this.double_0 = ProxyGraphics.smethod_44(stream);
        this.double_1 = ProxyGraphics.smethod_44(stream);
        this.bool_2 = ProxyGraphics.smethod_34(stream);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_69(stream, this.vector3D_0);
        ProxyGraphics.smethod_67(stream, this.point3D_0);
        int num = this.point2D_0 == null ? 0 : this.point2D_0.Length;
        ProxyGraphics.smethod_60(stream, num);
        for (int index = 0; index < num; ++index)
          ProxyGraphics.smethod_66(stream, this.point2D_0[index]);
        ProxyGraphics.smethod_70(stream, this.matrix4D_0);
        ProxyGraphics.smethod_70(stream, this.matrix4D_1);
        ProxyGraphics.smethod_55(stream, this.bool_0);
        ProxyGraphics.smethod_55(stream, this.bool_1);
        ProxyGraphics.smethod_65(stream, this.double_0);
        ProxyGraphics.smethod_65(stream, this.double_1);
        ProxyGraphics.smethod_55(stream, this.bool_2);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_27;
        }
      }

      internal override bool HasGeometricData
      {
        get
        {
          return true;
        }
      }
    }

    public class PopClip : ProxyGraphics.DrawCommand
    {
      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.PopClip popClip = (ProxyGraphics.PopClip) context.GetExistingClone((IGraphCloneable) this);
        if (popClip == null)
        {
          popClip = new ProxyGraphics.PopClip();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) popClip);
          popClip.CopyFrom(this);
        }
        return (IGraphCloneable) popClip;
      }

      public void CopyFrom(ProxyGraphics.PopClip from)
      {
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_28;
        }
      }

      internal override bool HasGeometricData
      {
        get
        {
          return true;
        }
      }
    }

    public class PushModelTransformMatrix : ProxyGraphics.DrawCommand
    {
      private Matrix4D matrix4D_0 = Matrix4D.Identity;

      public Matrix4D ModelTransform
      {
        get
        {
          return this.matrix4D_0;
        }
        set
        {
          this.matrix4D_0 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        drawer.method_0(this.matrix4D_0);
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        drawer.method_0(this.matrix4D_0);
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.PushModelTransformMatrix modelTransformMatrix = (ProxyGraphics.PushModelTransformMatrix) context.GetExistingClone((IGraphCloneable) this);
        if (modelTransformMatrix == null)
        {
          modelTransformMatrix = new ProxyGraphics.PushModelTransformMatrix();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) modelTransformMatrix);
          modelTransformMatrix.CopyFrom(this);
        }
        return (IGraphCloneable) modelTransformMatrix;
      }

      public void CopyFrom(ProxyGraphics.PushModelTransformMatrix from)
      {
        this.matrix4D_0 = from.matrix4D_0;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.matrix4D_0 = ProxyGraphics.smethod_49(stream);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_70(stream, this.matrix4D_0);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_29;
        }
      }

      internal override void TransformMe(ProxyGraphics.Class790 context)
      {
        context.method_0(this.matrix4D_0);
      }

      internal override bool HasGeometricData
      {
        get
        {
          return true;
        }
      }
    }

    public class PushModelTransformFromVector : ProxyGraphics.DrawCommand
    {
      private Vector3D vector3D_0 = new Vector3D(1.0, 1.0, 1.0);

      public Vector3D ModelTransform
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

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        drawer.method_1(this.vector3D_0);
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        drawer.method_1(this.vector3D_0);
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.PushModelTransformFromVector transformFromVector = (ProxyGraphics.PushModelTransformFromVector) context.GetExistingClone((IGraphCloneable) this);
        if (transformFromVector == null)
        {
          transformFromVector = new ProxyGraphics.PushModelTransformFromVector();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) transformFromVector);
          transformFromVector.CopyFrom(this);
        }
        return (IGraphCloneable) transformFromVector;
      }

      public void CopyFrom(ProxyGraphics.PushModelTransformFromVector from)
      {
        this.vector3D_0 = from.vector3D_0;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.vector3D_0 = ProxyGraphics.smethod_48(stream);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_69(stream, this.vector3D_0);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_30;
        }
      }

      internal override void TransformMe(ProxyGraphics.Class790 context)
      {
        context.method_0(Transformation4D.Scaling(this.vector3D_0));
      }

      internal override bool HasGeometricData
      {
        get
        {
          return true;
        }
      }
    }

    public class PopModelTransform : ProxyGraphics.DrawCommand
    {
      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        drawer.method_2();
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        drawer.method_2();
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.PopModelTransform popModelTransform = (ProxyGraphics.PopModelTransform) context.GetExistingClone((IGraphCloneable) this);
        if (popModelTransform == null)
        {
          popModelTransform = new ProxyGraphics.PopModelTransform();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) popModelTransform);
          popModelTransform.CopyFrom(this);
        }
        return (IGraphCloneable) popModelTransform;
      }

      public void CopyFrom(ProxyGraphics.PopModelTransform from)
      {
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_31;
        }
      }

      internal override void TransformMe(ProxyGraphics.Class790 context)
      {
        context.method_1();
      }

      internal override bool HasGeometricData
      {
        get
        {
          return true;
        }
      }
    }

    public class LwPolyline : ProxyGraphics.DrawCommand
    {
      private DxfLwPolyline dxfLwPolyline_0 = new DxfLwPolyline();
      private byte byte_0;
      private byte byte_1;
      private byte byte_2;

      public DxfLwPolyline Polyline
      {
        get
        {
          return this.dxfLwPolyline_0;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        this.dxfLwPolyline_0.method_12(drawer.EntityContext);
        this.dxfLwPolyline_0.Draw(context, graphicsFactory);
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        this.dxfLwPolyline_0.method_12(drawer.EntityContext);
        this.dxfLwPolyline_0.Draw(context, graphicsFactory);
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.LwPolyline lwPolyline = (ProxyGraphics.LwPolyline) context.GetExistingClone((IGraphCloneable) this);
        if (lwPolyline == null)
        {
          lwPolyline = new ProxyGraphics.LwPolyline();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) lwPolyline);
          lwPolyline.CopyFrom(context, this);
        }
        return (IGraphCloneable) lwPolyline;
      }

      public void CopyFrom(CloneContext context, ProxyGraphics.LwPolyline from)
      {
        this.byte_0 = from.byte_0;
        this.byte_1 = from.byte_1;
        this.byte_2 = from.byte_2;
        this.dxfLwPolyline_0.CopyFrom((DxfHandledObject) from.dxfLwPolyline_0, context);
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        uint num = ProxyGraphics.smethod_40(stream);
        byte[] buffer = ProxyGraphics.smethod_36(stream, (int) num);
        this.byte_0 = ProxyGraphics.smethod_35(stream);
        this.byte_1 = ProxyGraphics.smethod_35(stream);
        this.byte_2 = ProxyGraphics.smethod_35(stream);
        this.dxfLwPolyline_0.vmethod_9(FileFormat.Dwg);
        using (MemoryStream memoryStream = new MemoryStream(buffer))
          this.dxfLwPolyline_0.method_14((Interface30) new Class445((DwgReader) null, (Stream) memoryStream), modelBuilder);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        using (MemoryStream memoryStream = new MemoryStream())
        {
          Interface29 objectWriter = Class724.Create(model.Header.AcadVersion, (Stream) memoryStream, Encodings.GetEncoding((int) model.Header.DrawingCodePage));
          this.dxfLwPolyline_0.method_15(objectWriter);
          objectWriter.Flush();
          ProxyGraphics.smethod_61(stream, (uint) memoryStream.Length);
          ProxyGraphics.smethod_57(stream, memoryStream.GetBuffer(), 0, (int) memoryStream.Length);
        }
        ProxyGraphics.smethod_56(stream, this.byte_0);
        ProxyGraphics.smethod_56(stream, this.byte_1);
        ProxyGraphics.smethod_56(stream, this.byte_2);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_33;
        }
      }

      internal override void TransformMe(ProxyGraphics.Class790 context)
      {
        this.dxfLwPolyline_0.TransformMe(new TransformConfig(), context.Transform, context.UndoGroup);
      }

      internal override bool HasGeometricData
      {
        get
        {
          return true;
        }
      }
    }

    public class SetSubEntityMaterial : ProxyGraphics.DrawCommand
    {
      private ulong ulong_0;

      public ulong MaterialHandle
      {
        get
        {
          return this.ulong_0;
        }
        set
        {
          this.ulong_0 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.SetSubEntityMaterial subEntityMaterial = (ProxyGraphics.SetSubEntityMaterial) context.GetExistingClone((IGraphCloneable) this);
        if (subEntityMaterial == null)
        {
          subEntityMaterial = new ProxyGraphics.SetSubEntityMaterial();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) subEntityMaterial);
          subEntityMaterial.CopyFrom(context, this);
        }
        return (IGraphCloneable) subEntityMaterial;
      }

      public void CopyFrom(CloneContext context, ProxyGraphics.SetSubEntityMaterial from)
      {
        this.ulong_0 = from.ulong_0;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.ulong_0 = ProxyGraphics.smethod_43(stream);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_64(stream, this.ulong_0);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_34;
        }
      }

      internal override bool CanWrite
      {
        get
        {
          return false;
        }
      }
    }

    public class SetSubEntityMapper : ProxyGraphics.DrawCommand
    {
      private int int_0;
      private int int_1;
      private int int_2;
      private int int_3;
      private int int_4;
      private int int_5;
      private int int_6;

      public int Projection
      {
        get
        {
          return this.int_2;
        }
        set
        {
          this.int_2 = value;
        }
      }

      public int UTiling
      {
        get
        {
          return this.int_3;
        }
        set
        {
          this.int_3 = value;
        }
      }

      public int VTiling
      {
        get
        {
          return this.int_4;
        }
        set
        {
          this.int_4 = value;
        }
      }

      public int AutoTransform
      {
        get
        {
          return this.int_5;
        }
        set
        {
          this.int_5 = value;
        }
      }

      public override void DrawInternal(
        ProxyGraphics.WireframeGraphicsFactoryDrawer drawer,
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
      }

      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.SetSubEntityMapper setSubEntityMapper = (ProxyGraphics.SetSubEntityMapper) context.GetExistingClone((IGraphCloneable) this);
        if (setSubEntityMapper == null)
        {
          setSubEntityMapper = new ProxyGraphics.SetSubEntityMapper();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) setSubEntityMapper);
          setSubEntityMapper.CopyFrom(context, this);
        }
        return (IGraphCloneable) setSubEntityMapper;
      }

      public void CopyFrom(CloneContext context, ProxyGraphics.SetSubEntityMapper from)
      {
        this.int_0 = from.int_0;
        this.int_1 = from.int_1;
        this.int_2 = from.int_2;
        this.int_3 = from.int_3;
        this.int_4 = from.int_4;
        this.int_5 = from.int_5;
        this.int_6 = from.int_6;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.int_0 = ProxyGraphics.smethod_39(stream);
        this.int_1 = ProxyGraphics.smethod_39(stream);
        this.int_2 = ProxyGraphics.smethod_39(stream);
        this.int_3 = ProxyGraphics.smethod_39(stream);
        this.int_4 = ProxyGraphics.smethod_39(stream);
        this.int_5 = ProxyGraphics.smethod_39(stream);
        this.int_6 = ProxyGraphics.smethod_39(stream);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_60(stream, this.int_0);
        ProxyGraphics.smethod_60(stream, this.int_1);
        ProxyGraphics.smethod_60(stream, this.int_2);
        ProxyGraphics.smethod_60(stream, this.int_3);
        ProxyGraphics.smethod_60(stream, this.int_4);
        ProxyGraphics.smethod_60(stream, this.int_5);
        ProxyGraphics.smethod_60(stream, this.int_6);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_35;
        }
      }
    }

    public class UnicodeText : ProxyGraphics.TextBase
    {
      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.UnicodeText unicodeText = (ProxyGraphics.UnicodeText) context.GetExistingClone((IGraphCloneable) this);
        if (unicodeText == null)
        {
          unicodeText = new ProxyGraphics.UnicodeText();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) unicodeText);
          unicodeText.CopyFrom((ProxyGraphics.TextBase) this);
        }
        return (IGraphCloneable) unicodeText;
      }

      protected internal override string ReadString(Stream stream, Encoding encoding)
      {
        return ProxyGraphics.ReadString(stream);
      }

      protected internal override void WriteString(Stream stream, Encoding encoding, string value)
      {
        ProxyGraphics.WriteString(stream, value);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_36;
        }
      }
    }

    public class UnicodeText2 : ProxyGraphics.Text2Base
    {
      public override IGraphCloneable Clone(CloneContext context)
      {
        ProxyGraphics.UnicodeText2 unicodeText2 = (ProxyGraphics.UnicodeText2) context.GetExistingClone((IGraphCloneable) this);
        if (unicodeText2 == null)
        {
          unicodeText2 = new ProxyGraphics.UnicodeText2();
          context.RegisterClone((IGraphCloneable) this, (IGraphCloneable) unicodeText2);
          unicodeText2.CopyFrom((ProxyGraphics.Text2Base) this);
        }
        return (IGraphCloneable) unicodeText2;
      }

      internal override void Read(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        Class374 modelBuilder,
        ProxyGraphics.Class758 builder)
      {
        this.Position = ProxyGraphics.smethod_46(stream);
        this.Normal = ProxyGraphics.smethod_48(stream);
        this.Direction = ProxyGraphics.smethod_48(stream);
        this.Value = ProxyGraphics.ReadString(stream);
        ProxyGraphics.smethod_39(stream);
        this.Raw = ProxyGraphics.smethod_34(stream);
        this.TextStyle.TextSize = ProxyGraphics.smethod_44(stream);
        this.TextStyle.XScale = ProxyGraphics.smethod_44(stream);
        this.TextStyle.ObliqueAngle = ProxyGraphics.smethod_44(stream);
        this.TextStyle.TrackingPercentage = ProxyGraphics.smethod_44(stream);
        this.TextStyle.IsBackwards = ProxyGraphics.smethod_34(stream);
        this.TextStyle.IsUpsideDown = ProxyGraphics.smethod_34(stream);
        this.TextStyle.IsVertical = ProxyGraphics.smethod_34(stream);
        this.TextStyle.IsUnderlined = ProxyGraphics.smethod_34(stream);
        this.TextStyle.IsOverlined = ProxyGraphics.smethod_34(stream);
        this.TextStyle.TrueTypeFontDescriptor = new TrueTypeFontDescriptor()
        {
          IsBold = ProxyGraphics.smethod_34(stream),
          IsItalic = ProxyGraphics.smethod_34(stream),
          CharSet = (byte) ProxyGraphics.smethod_39(stream),
          PitchAndFamily = (byte) ProxyGraphics.smethod_39(stream),
          TypeFace = ProxyGraphics.ReadString(stream),
          FontFilename = ProxyGraphics.ReadString(stream)
        };
        this.TextStyle.BigFontFilename = ProxyGraphics.ReadString(stream);
      }

      internal override void Write(
        ProxyGraphics proxyGraphics,
        Stream stream,
        Encoding encoding,
        DxfModel model)
      {
        ProxyGraphics.smethod_67(stream, this.Position);
        ProxyGraphics.smethod_69(stream, this.Normal);
        ProxyGraphics.smethod_69(stream, this.Direction);
        ProxyGraphics.WriteString(stream, this.Value);
        ProxyGraphics.smethod_60(stream, this.Value.Length);
        ProxyGraphics.smethod_55(stream, this.Raw);
        ProxyGraphics.smethod_65(stream, this.TextStyle.TextSize);
        ProxyGraphics.smethod_65(stream, this.TextStyle.XScale);
        ProxyGraphics.smethod_65(stream, this.TextStyle.ObliqueAngle);
        ProxyGraphics.smethod_65(stream, this.TextStyle.TrackingPercentage);
        ProxyGraphics.smethod_55(stream, this.TextStyle.IsBackwards);
        ProxyGraphics.smethod_55(stream, this.TextStyle.IsUpsideDown);
        ProxyGraphics.smethod_55(stream, this.TextStyle.IsVertical);
        ProxyGraphics.smethod_55(stream, this.TextStyle.IsUnderlined);
        ProxyGraphics.smethod_55(stream, this.TextStyle.IsOverlined);
        TrueTypeFontDescriptor typeFontDescriptor = this.TextStyle.TrueTypeFontDescriptor;
        if (typeFontDescriptor == null)
          throw new Exception("UnicodeText2 text style's font descriptor is null.");
        ProxyGraphics.smethod_55(stream, typeFontDescriptor.IsBold);
        ProxyGraphics.smethod_55(stream, typeFontDescriptor.IsItalic);
        ProxyGraphics.smethod_60(stream, (int) typeFontDescriptor.CharSet);
        ProxyGraphics.smethod_60(stream, (int) typeFontDescriptor.PitchAndFamily);
        ProxyGraphics.WriteString(stream, typeFontDescriptor.TypeFace);
        ProxyGraphics.WriteString(stream, typeFontDescriptor.FontFilename);
        ProxyGraphics.WriteString(stream, this.TextStyle.BigFontFilename);
      }

      internal override ProxyGraphics.Enum29 DrawCommandCode
      {
        get
        {
          return ProxyGraphics.Enum29.const_38;
        }
      }
    }

    public enum ArcType
    {
      Simple,
      Sector,
      Chord,
    }

    internal enum Enum29
    {
      const_0,
      const_1,
      const_2,
      const_3,
      const_4,
      const_5,
      const_6,
      const_7,
      const_8,
      const_9,
      const_10,
      const_11,
      const_12,
      const_13,
      const_14,
      const_15,
      const_16,
      const_17,
      const_18,
      const_19,
      const_20,
      const_21,
      const_22,
      const_23,
      const_24,
      const_25,
      const_26,
      const_27,
      const_28,
      const_29,
      const_30,
      const_31,
      const_32,
      const_33,
      const_34,
      const_35,
      const_36,
      const_37,
      const_38,
    }

    [Flags]
    public enum GraphicPropertyFlags : uint
    {
      HasColors = 1,
      HasLayers = 2,
      HasLineTypes = 4,
      HasMarkers = 32, // 0x00000020
      HasVisibilities = 64, // 0x00000040
      HasNormals = 128, // 0x00000080
      HasOrientation = 1024, // 0x00000400
    }

    public enum Orientation
    {
      CounterClockWise = -1,
      None = 0,
      ClockWise = 1,
    }

    public class TextStyle
    {
      private string string_0 = string.Empty;
      private string string_1 = string.Empty;
      private double double_1 = 1.0;
      private double double_0;
      private double double_2;
      private double double_3;
      private bool bool_0;
      private bool bool_1;
      private bool bool_2;
      private bool bool_3;
      private bool bool_4;
      private TrueTypeFontDescriptor trueTypeFontDescriptor_0;

      public string FontFilename
      {
        get
        {
          return this.string_0;
        }
        set
        {
          this.string_0 = value ?? string.Empty;
        }
      }

      public string BigFontFilename
      {
        get
        {
          return this.string_1;
        }
        set
        {
          this.string_1 = value ?? string.Empty;
        }
      }

      public double TextSize
      {
        get
        {
          return this.double_0;
        }
        set
        {
          this.double_0 = value;
        }
      }

      public double XScale
      {
        get
        {
          return this.double_1;
        }
        set
        {
          this.double_1 = value;
        }
      }

      public double ObliqueAngle
      {
        get
        {
          return this.double_2;
        }
        set
        {
          this.double_2 = value;
        }
      }

      public double TrackingPercentage
      {
        get
        {
          return this.double_3;
        }
        set
        {
          this.double_3 = value;
        }
      }

      public bool IsBackwards
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

      public bool IsUpsideDown
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

      public bool IsVertical
      {
        get
        {
          return this.bool_2;
        }
        set
        {
          this.bool_2 = value;
        }
      }

      public bool IsUnderlined
      {
        get
        {
          return this.bool_3;
        }
        set
        {
          this.bool_3 = value;
        }
      }

      public bool IsOverlined
      {
        get
        {
          return this.bool_4;
        }
        set
        {
          this.bool_4 = value;
        }
      }

      public TrueTypeFontDescriptor TrueTypeFontDescriptor
      {
        get
        {
          return this.trueTypeFontDescriptor_0;
        }
        set
        {
          this.trueTypeFontDescriptor_0 = value;
        }
      }

      internal void Read(ProxyGraphics proxyGraphics, Stream stream, Encoding encoding)
      {
        this.TextSize = ProxyGraphics.smethod_44(stream);
        this.XScale = ProxyGraphics.smethod_44(stream);
        this.ObliqueAngle = ProxyGraphics.smethod_44(stream);
        this.TrackingPercentage = ProxyGraphics.smethod_44(stream);
        this.IsBackwards = ProxyGraphics.smethod_34(stream);
        this.IsUpsideDown = ProxyGraphics.smethod_34(stream);
        this.IsVertical = ProxyGraphics.smethod_34(stream);
        this.IsUnderlined = ProxyGraphics.smethod_34(stream);
        this.IsOverlined = ProxyGraphics.smethod_34(stream);
        this.FontFilename = ProxyGraphics.smethod_51(stream, encoding);
        this.BigFontFilename = ProxyGraphics.smethod_51(stream, encoding);
      }

      internal void Write(ProxyGraphics proxyGraphics, Stream stream, Encoding encoding)
      {
        ProxyGraphics.smethod_65(stream, this.TextSize);
        ProxyGraphics.smethod_65(stream, this.XScale);
        ProxyGraphics.smethod_65(stream, this.ObliqueAngle);
        ProxyGraphics.smethod_65(stream, this.TrackingPercentage);
        ProxyGraphics.smethod_55(stream, this.IsBackwards);
        ProxyGraphics.smethod_55(stream, this.IsUpsideDown);
        ProxyGraphics.smethod_55(stream, this.IsVertical);
        ProxyGraphics.smethod_55(stream, this.IsUnderlined);
        ProxyGraphics.smethod_55(stream, this.IsOverlined);
        ProxyGraphics.smethod_72(stream, encoding, this.FontFilename);
        ProxyGraphics.smethod_72(stream, encoding, this.BigFontFilename);
      }

      public void CopyFrom(ProxyGraphics.TextStyle from)
      {
        this.string_0 = from.string_0;
        this.string_1 = from.string_1;
        this.double_0 = from.double_0;
        this.double_1 = from.double_1;
        this.double_2 = from.double_2;
        this.double_3 = from.double_3;
        this.bool_0 = from.bool_0;
        this.bool_1 = from.bool_1;
        this.bool_2 = from.bool_2;
        this.bool_3 = from.bool_3;
        this.bool_4 = from.bool_4;
        if (from.trueTypeFontDescriptor_0 == null)
        {
          this.trueTypeFontDescriptor_0 = (TrueTypeFontDescriptor) null;
        }
        else
        {
          if (this.trueTypeFontDescriptor_0 == null)
            this.trueTypeFontDescriptor_0 = new TrueTypeFontDescriptor();
          this.trueTypeFontDescriptor_0.CopyFrom(from.trueTypeFontDescriptor_0);
        }
      }
    }

    public enum FillType
    {
      Fill = 1,
      NoFill = 2,
    }

    public enum PlotStyleNameType
    {
      ByLayer,
      ByBlock,
      IsDictionaryDefault,
      ById,
    }

    internal class Class790
    {
      private Stack<Matrix4D> stack_0 = new Stack<Matrix4D>();
      private Matrix4D matrix4D_0;
      private CommandGroup commandGroup_0;

      public Class790(Matrix4D transform, CommandGroup undoGroup)
      {
        this.matrix4D_0 = transform;
        this.commandGroup_0 = undoGroup;
      }

      public Matrix4D Transform
      {
        get
        {
          return this.matrix4D_0;
        }
      }

      public CommandGroup UndoGroup
      {
        get
        {
          return this.commandGroup_0;
        }
      }

      public void method_0(Matrix4D m)
      {
        this.stack_0.Push(this.matrix4D_0);
        this.matrix4D_0 = m.GetInverse() * this.matrix4D_0 * m;
      }

      public void method_1()
      {
        this.matrix4D_0 = this.stack_0.Pop();
      }
    }
  }
}
