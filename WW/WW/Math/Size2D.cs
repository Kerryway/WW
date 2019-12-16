// Decompiled with JetBrains decompiler
// Type: WW.Math.Size2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace WW.Math
{
  [TypeConverter(typeof (Size2DConverter))]
  [Serializable]
  public struct Size2D : IEquatable<Size2D>
  {
    public static readonly Size2D Zero = Size2D.smethod_0(0.0, 0.0);
    public double X;
    public double Y;

    [DebuggerStepThrough]
    public Size2D(double width, double height)
    {
      this.X = width;
      this.Y = height;
    }

    [Obsolete]
    [DisplayName("X")]
    public double _XProperty
    {
      get
      {
        return this.X;
      }
      set
      {
        this.X = value;
      }
    }

    [DisplayName("Y")]
    [Obsolete]
    public double _YProperty
    {
      get
      {
        return this.Y;
      }
      set
      {
        this.Y = value;
      }
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Size2D)
        return this.Equals((Size2D) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture));
    }

    public static Size2D Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 2)
        throw new ArgumentException("Illegal Size2D string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Size2D(double.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), double.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal Size2D string.", ex);
      }
    }

    private static Size2D smethod_0(double x, double y)
    {
      return new Size2D(x, y);
    }

    public bool Equals(Size2D other)
    {
      if (this.X == other.X)
        return this.Y == other.Y;
      return false;
    }

    public static bool operator ==(Size2D u, Size2D v)
    {
      if (u.X == v.X)
        return u.Y == v.Y;
      return false;
    }

    public static bool operator !=(Size2D u, Size2D v)
    {
      if (u.X == v.X)
        return u.Y != v.Y;
      return true;
    }
  }
}
