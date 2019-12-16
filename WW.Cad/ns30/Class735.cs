// Decompiled with JetBrains decompiler
// Type: ns30.Class735
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ns30
{
  internal sealed class Class735
  {
    [ThreadStatic]
    private static Dictionary<Class735.Struct6, Pen> dictionary_0;
    [ThreadStatic]
    private static Dictionary<int, Brush> dictionary_1;
    [ThreadStatic]
    private static Bitmap bitmap_0;
    [ThreadStatic]
    private static int[] int_0;
    [ThreadStatic]
    private static IntPtr intptr_0;
    [ThreadStatic]
    private static GCHandle gchandle_0;

    internal static void smethod_0()
    {
      if (Class735.dictionary_0 == null)
        Class735.dictionary_0 = new Dictionary<Class735.Struct6, Pen>(257);
      if (Class735.dictionary_1 == null)
        Class735.dictionary_1 = new Dictionary<int, Brush>(257);
      if (Class735.bitmap_0 != null)
        return;
      Class735.int_0 = new int[1];
      Class735.gchandle_0 = GCHandle.Alloc((object) Class735.int_0, GCHandleType.Pinned);
      Class735.intptr_0 = Marshal.UnsafeAddrOfPinnedArrayElement((Array) Class735.int_0, 0);
      Class735.bitmap_0 = new Bitmap(1, 1, 4, PixelFormat.Format32bppArgb, Class735.intptr_0);
    }

    public static void DisposeThreadStaticObjects()
    {
      if (Class735.dictionary_0 != null)
      {
        foreach (Pen pen in Class735.dictionary_0.Values)
          pen.Dispose();
        Class735.dictionary_0 = (Dictionary<Class735.Struct6, Pen>) null;
      }
      if (Class735.dictionary_1 != null)
      {
        foreach (Brush brush in Class735.dictionary_1.Values)
          brush.Dispose();
        Class735.dictionary_1 = (Dictionary<int, Brush>) null;
      }
      if (Class735.bitmap_0 == null)
        return;
      Class735.bitmap_0.Dispose();
      Class735.bitmap_0 = (Bitmap) null;
      Class735.gchandle_0.Free();
    }

    internal static Pen smethod_1(Color color, float penWidth)
    {
      Class735.Struct6 key = new Class735.Struct6(color, penWidth);
      Pen pen;
      if (!Class735.dictionary_0.TryGetValue(key, out pen))
      {
        pen = new Pen(color, penWidth);
        pen.MiterLimit = 2f;
        Class735.dictionary_0[key] = pen;
      }
      return pen;
    }

    internal static Brush smethod_2(Color color)
    {
      int argb = color.ToArgb();
      Brush brush;
      if (!Class735.dictionary_1.TryGetValue(argb, out brush))
      {
        brush = (Brush) new SolidBrush(color);
        Class735.dictionary_1[argb] = brush;
      }
      return brush;
    }

    internal static void smethod_3(Graphics graphics, Color color, int x, int y)
    {
      Marshal.WriteInt32(Class735.intptr_0, color.ToArgb());
      graphics.DrawImage((Image) Class735.bitmap_0, x, y, 1, 1);
    }

    private struct Struct6
    {
      private int int_0;
      private float float_0;

      public Struct6(Color color, float penWidth)
      {
        this.int_0 = color.ToArgb();
        this.float_0 = penWidth;
      }

      public override int GetHashCode()
      {
        return this.int_0.GetHashCode() ^ this.float_0.GetHashCode();
      }

      public override bool Equals(object other)
      {
        Class735.Struct6 struct6 = (Class735.Struct6) other;
        if (this.int_0 == struct6.int_0)
          return (double) this.float_0 == (double) struct6.float_0;
        return false;
      }
    }
  }
}
