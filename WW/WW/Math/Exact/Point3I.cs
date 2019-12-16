// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Point3I
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace WW.Math.Exact
{
  [TypeConverter(typeof (Point3IConverter))]
  [Serializable]
  public struct Point3I : IEquatable<Point3I>
  {
    public static readonly Point3I Zero = Point3I.smethod_0(0, 0, 0);
    public int X;
    public int Y;
    public int Z;

    [DebuggerStepThrough]
    public Point3I(int x, int y, int z)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Point3I(Point2I point, int z)
    {
      this.X = point.X;
      this.Y = point.Y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Point3I(int[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Point3I(IList<int> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Point3I(Point3I from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
    }

    [DebuggerStepThrough]
    public Point3I(Vector3I from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
    }

    [DisplayName("X")]
    [Obsolete]
    public int _XProperty
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
    public int _YProperty
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

    [Obsolete]
    [DisplayName("Z")]
    public int _ZProperty
    {
      get
      {
        return this.Z;
      }
      set
      {
        this.Z = value;
      }
    }

    public static Point3I Add(Point3I p, Vector3I v)
    {
      return new Point3I(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    }

    public static Point3I Subtract(Point3I p, Vector3I v)
    {
      return new Point3I(p.X - v.X, p.Y - v.Y, p.Z - v.Z);
    }

    public static Vector3I Subtract(Point3I a, Point3I b)
    {
      return new Vector3I(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public void Add(int x, int y, int z)
    {
      this.X += x;
      this.Y += y;
      this.Z += z;
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Point3I)
        return this.Equals((Point3I) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}, {2}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture), (object) this.Z.ToString((IFormatProvider) invariantCulture));
    }

    public static Point3I Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 3)
        throw new ArgumentException("Illegal vector string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Point3I(int.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), int.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat), int.Parse(strArray[2], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal vector string.", ex);
      }
    }

    public static bool operator ==(Point3I a, Point3I b)
    {
      if (a.X == b.X && a.Y == b.Y)
        return a.Z == b.Z;
      return false;
    }

    public static bool operator !=(Point3I a, Point3I b)
    {
      if (a.X == b.X && a.Y == b.Y)
        return a.Z != b.Z;
      return true;
    }

    public static Point3I operator +(Point3I p, Vector3I v)
    {
      return new Point3I(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    }

    public static Point3I operator +(Vector3I v, Point3I p)
    {
      return new Point3I(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    }

    public static Point3I operator -(Point3I p, Vector3I v)
    {
      return new Point3I(p.X - v.X, p.Y - v.Y, p.Z - v.Z);
    }

    public static Vector3I operator -(Point3I a, Point3I b)
    {
      return new Vector3I(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public int this[int index]
    {
      get
      {
        switch (index)
        {
          case 0:
            return this.X;
          case 1:
            return this.Y;
          case 2:
            return this.Z;
          default:
            throw new IndexOutOfRangeException();
        }
      }
      set
      {
        switch (index)
        {
          case 0:
            this.X = value;
            break;
          case 1:
            this.Y = value;
            break;
          case 2:
            this.Z = value;
            break;
          default:
            throw new IndexOutOfRangeException();
        }
      }
    }

    public static explicit operator int[](Point3I p)
    {
      return new int[3]{ p.X, p.Y, p.Z };
    }

    public static explicit operator Point3I(Point2I p)
    {
      return new Point3I(p.X, p.Y, 0);
    }

    public static explicit operator Point3I(Vector3I v)
    {
      return new Point3I(v);
    }

    public static explicit operator Point3F(Point3I p)
    {
      return new Point3F((float) p.X, (float) p.Y, (float) p.Z);
    }

    private static Point3I smethod_0(int x, int y, int z)
    {
      return new Point3I(x, y, z);
    }

    public bool Equals(Point3I other)
    {
      if (this.X == other.X && this.Y == other.Y)
        return this.Z == other.Z;
      return false;
    }
  }
}
