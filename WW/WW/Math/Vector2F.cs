// Decompiled with JetBrains decompiler
// Type: WW.Math.Vector2F
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace WW.Math
{
  [TypeConverter(typeof (Vector2FConverter))]
  [Serializable]
  public struct Vector2F : IEquatable<Vector2F>
  {
    public static readonly Vector2F Zero = Vector2F.smethod_0(0.0f, 0.0f);
    public static readonly Vector2F XAxis = Vector2F.smethod_0(1f, 0.0f);
    public static readonly Vector2F YAxis = Vector2F.smethod_0(0.0f, 1f);
    public float X;
    public float Y;

    [DebuggerStepThrough]
    public Vector2F(float x, float y)
    {
      this.X = x;
      this.Y = y;
    }

    [DebuggerStepThrough]
    public Vector2F(float[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
    }

    [DebuggerStepThrough]
    public Vector2F(IList<float> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
    }

    [DebuggerStepThrough]
    public Vector2F(Vector2F from)
    {
      this.X = from.X;
      this.Y = from.Y;
    }

    [DisplayName("X")]
    [Obsolete]
    public float _XProperty
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
    public float _YProperty
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

    public static Vector2F Add(Vector2F u, Vector2F v)
    {
      return new Vector2F(u.X + v.X, u.Y + v.Y);
    }

    public static Vector2F Subtract(Vector2F u, Vector2F v)
    {
      return new Vector2F(u.X - v.X, u.Y - v.Y);
    }

    public static Vector2F Divide(Vector2F v, float s)
    {
      float num = 1f / s;
      return new Vector2F(v.X * num, v.Y * num);
    }

    public static Vector2F Multiply(Vector2F u, float s)
    {
      return new Vector2F(u.X * s, u.Y * s);
    }

    public static float DotProduct(Vector2F u, Vector2F v)
    {
      return (float) ((double) u.X * (double) v.X + (double) u.Y * (double) v.Y);
    }

    public static float CrossProduct(Vector2F u, Vector2F v)
    {
      return (float) ((double) u.X * (double) v.Y - (double) u.Y * (double) v.X);
    }

    public static Vector2F Negate(Vector2F v)
    {
      return new Vector2F(-v.X, -v.Y);
    }

    public static bool AreApproxEqual(Vector2F u, Vector2F v)
    {
      return Vector2F.AreApproxEqual(u, v, 4.768372E-07f);
    }

    public static bool AreApproxEqual(Vector2F u, Vector2F v, float tolerance)
    {
      if ((double) System.Math.Abs(v.X - u.X) <= (double) tolerance)
        return (double) System.Math.Abs(v.Y - u.Y) <= (double) tolerance;
      return false;
    }

    public static float GetAngle(Vector2F a, Vector2F b)
    {
      Vector2F unit = a.GetUnit();
      Vector2F u = new Vector2F(-unit.Y, unit.X);
      float num = Vector2F.DotProduct(unit, b);
      return (float) System.Math.Atan2((double) Vector2F.DotProduct(u, b - num * unit), (double) num);
    }

    public void Normalize()
    {
      float lengthSquared = this.GetLengthSquared();
      if ((double) lengthSquared == 1.0)
        return;
      float num = 1f / (float) System.Math.Sqrt((double) lengthSquared);
      this.X *= num;
      this.Y *= num;
    }

    public Vector2F GetUnit()
    {
      float lengthSquared = this.GetLengthSquared();
      if ((double) lengthSquared == 1.0)
        return this;
      float num = 1f / (float) System.Math.Sqrt((double) lengthSquared);
      return new Vector2F(this.X * num, this.Y * num);
    }

    public float GetLength()
    {
      return (float) System.Math.Sqrt((double) this.X * (double) this.X + (double) this.Y * (double) this.Y);
    }

    public float GetLengthSquared()
    {
      return (float) ((double) this.X * (double) this.X + (double) this.Y * (double) this.Y);
    }

    public static Vector2F FromAngle(double angle)
    {
      return new Vector2F((float) System.Math.Cos(angle), (float) System.Math.Sin(angle));
    }

    public double GetAngle()
    {
      return System.Math.Atan2((double) this.Y, (double) this.X);
    }

    public static int CompareAngles(Vector2F a, Vector2F b)
    {
      int quadrant1 = Vector2F.GetQuadrant(a);
      int quadrant2 = Vector2F.GetQuadrant(b);
      if (quadrant1 < quadrant2)
        return -1;
      if (quadrant1 > quadrant2)
        return 1;
      float num = Vector2F.CrossProduct(a, b);
      if ((double) num < 0.0)
        return 1;
      return (double) num > 0.0 ? -1 : 0;
    }

    public static int GetQuadrant(Vector2F v)
    {
      return (double) v.Y >= 0.0 ? ((double) v.X >= 0.0 ? 0 : 1) : ((double) v.X >= 0.0 ? 3 : 2);
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Vector2F)
        return this.Equals((Vector2F) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture));
    }

    public static Vector2F Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 2)
        throw new ArgumentException("Illegal vector string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Vector2F(float.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), float.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal vector string.", ex);
      }
    }

    public static bool operator ==(Vector2F u, Vector2F v)
    {
      if ((double) u.X == (double) v.X)
        return (double) u.Y == (double) v.Y;
      return false;
    }

    public static bool operator !=(Vector2F u, Vector2F v)
    {
      if ((double) u.X == (double) v.X)
        return (double) u.Y != (double) v.Y;
      return true;
    }

    public static Vector2F operator -(Vector2F v)
    {
      return Vector2F.Negate(v);
    }

    public static Vector2F operator +(Vector2F u, Vector2F v)
    {
      return Vector2F.Add(u, v);
    }

    public static Vector2F operator -(Vector2F u, Vector2F v)
    {
      return Vector2F.Subtract(u, v);
    }

    public static Vector2F operator *(Vector2F v, float s)
    {
      return Vector2F.Multiply(v, s);
    }

    public static Vector2F operator *(float s, Vector2F v)
    {
      return Vector2F.Multiply(v, s);
    }

    public static Vector2F operator /(Vector2F v, float s)
    {
      return Vector2F.Divide(v, s);
    }

    public float this[int index]
    {
      get
      {
        switch (index)
        {
          case 0:
            return this.X;
          case 1:
            return this.Y;
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
          default:
            throw new IndexOutOfRangeException();
        }
      }
    }

    public static explicit operator Vector2F(Vector3F p)
    {
      return new Vector2F(p.X, p.Y);
    }

    public static explicit operator float[](Vector2F v)
    {
      return new float[2]{ v.X, v.Y };
    }

    private static Vector2F smethod_0(float x, float y)
    {
      return new Vector2F(x, y);
    }

    public bool Equals(Vector2F other)
    {
      if ((double) this.X == (double) other.X)
        return (double) this.Y == (double) other.Y;
      return false;
    }
  }
}
