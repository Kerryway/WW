// Decompiled with JetBrains decompiler
// Type: ns4.Class470
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW;
using WW.Math;

namespace ns4
{
  internal class Class470 : Interface24
  {
    public static readonly Interface24[] interface24_0 = new Interface24[0];
    public static readonly char[] char_0 = new char[1]{ '\n' };
    public const double double_0 = -0.2;
    public const double double_1 = 1.1;
    private string string_0;
    private Vector2D vector2D_0;
    private Class596 class596_0;

    internal Class470(string text, Class596 settings)
    {
      this.string_0 = text;
      this.class596_0 = new Class596(settings);
    }

    public string Text
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }

    public Vector2D Offset
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

    public Class596 Settings
    {
      get
      {
        return this.class596_0;
      }
      set
      {
        this.class596_0 = value;
      }
    }

    public Bounds2D GetBounds(Enum24 whiteSpaceHandling, Class985 resultLayoutInfo)
    {
      Bounds2D bounds = this.Settings.Font.Metrics.GetBounds(this.Text, whiteSpaceHandling);
      if (resultLayoutInfo != null)
      {
        double y = bounds.Min.Y;
        if (y < 0.0)
        {
          if ((resultLayoutInfo.BoundsCalculationFlags & Enum36.flag_1) != Enum36.flag_0)
            bounds.Min = new Point2D(bounds.Min.X, 0.0);
          if (y < resultLayoutInfo.TextBlockDescent)
            resultLayoutInfo.TextBlockDescent = y;
        }
      }
      if (bounds.Max.Y > this.class596_0.Height)
        bounds.Max = new Point2D(bounds.Max.X, this.class596_0.Height);
      bounds.Move(this.vector2D_0.X, this.vector2D_0.Y);
      return bounds;
    }

    public void imethod_0(ref Vector2D baselinePos, double height, Enum24 whiteSpaceHandlingFlags)
    {
      this.Offset = baselinePos;
      baselinePos += this.Advance;
    }

    public bool Breakable
    {
      get
      {
        return true;
      }
    }

    public Interface24[] imethod_1(double width, Interface25 breaker)
    {
      Interface0 metrics = this.Settings.Font.Metrics;
      double num = width - this.Offset.X;
      if (metrics.GetBounds(this.Text, Enum24.flag_0).Corner2.X <= num)
        return new Interface24[1]{ (Interface24) this };
      int position = -1;
      Pair<string, string> pair1 = (Pair<string, string>) null;
      Pair<string, string> pair2;
      do
      {
        pair2 = pair1;
        pair1 = breaker.imethod_1(this.Text, ref position);
      }
      while (position >= 0 && metrics.GetBounds(pair1.First, Enum24.flag_0).Corner2.X <= num);
      if (pair2 == null)
      {
        if (pair1 == null)
          return Class470.interface24_0;
        pair2 = pair1;
      }
      return new Interface24[2]{ (Interface24) new Class470(pair2.First, this.Settings) { Offset = this.Offset }, (Interface24) new Class470(pair2.Second, this.Settings) };
    }

    public Vector2D? imethod_2(char ch, Enum24 whiteSpaceHandlingFlags)
    {
      int length = this.Text.IndexOf(ch);
      if (length < 0)
        return new Vector2D?();
      Class470 class470 = new Class470(this.Text.Substring(0, length), this.Settings);
      class470.Offset = this.Offset;
      Vector2D baselinePos = new Vector2D();
      class470.imethod_0(ref baselinePos, this.Settings.Height, whiteSpaceHandlingFlags);
      return new Vector2D?(baselinePos);
    }

    public void imethod_3(
      ICollection<Class908> collector,
      Matrix4D insertionTrafo,
      short lineWeight)
    {
      Class908 class908 = new Class908(this.class596_0.Font.GetText(this.Text, this.class596_0.Color, lineWeight, this.class596_0.IsVertical), insertionTrafo * Transformation4D.Translation(new Vector3D(this.Offset, 0.0)));
      if (this.class596_0.Underline || this.class596_0.Overline)
      {
        Vector2D advance = this.Advance;
        if (this.class596_0.Underline)
        {
          double num = -0.2 * this.Settings.Height;
          class908.method_3(0.0, num, advance.X, num);
        }
        if (this.class596_0.Overline)
        {
          double num = 1.1 * this.Settings.Height;
          class908.method_3(0.0, num, advance.X, num);
        }
      }
      collector.Add(class908);
    }

    public Vector2D Advance
    {
      get
      {
        return this.class596_0.Font.Metrics.imethod_0(this.string_0, (IList<Vector2D>) null);
      }
    }
  }
}
