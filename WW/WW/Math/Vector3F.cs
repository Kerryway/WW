// Decompiled with JetBrains decompiler
// Type: WW.Math.Vector3F
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
  [TypeConverter(typeof (Vector3FConverter))]
  [Serializable]
  public struct Vector3F : IEquatable<Vector3F>
  {
    public static readonly Vector3F Zero = Vector3F.smethod_0(0.0f, 0.0f, 0.0f);
    public static readonly Vector3F XAxis = Vector3F.smethod_0(1f, 0.0f, 0.0f);
    public static readonly Vector3F YAxis = Vector3F.smethod_0(0.0f, 1f, 0.0f);
    public static readonly Vector3F ZAxis = Vector3F.smethod_0(0.0f, 0.0f, 1f);
    public float X;
    public float Y;
    public float Z;

    [DebuggerStepThrough]
    public Vector3F(float x, float y, float z)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Vector3F(Vector2F vector, float z)
    {
      this.X = vector.X;
      this.Y = vector.Y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Vector3F(float[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Vector3F(IList<float> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Vector3F(Vector3F from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
    }

    [DebuggerStepThrough]
    public Vector3F(Point3F from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
    }

    [Obsolete]
    [DisplayName("X")]
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

    [Obsolete]
    [DisplayName("Y")]
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

    [Obsolete]
    [DisplayName("Z")]
    public float _ZProperty
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

    public static Vector3F Add(Vector3F u, Vector3F v)
    {
      return new Vector3F(u.X + v.X, u.Y + v.Y, u.Z + v.Z);
    }

    public static Vector3F Subtract(Vector3F u, Vector3F v)
    {
      return new Vector3F(u.X - v.X, u.Y - v.Y, u.Z - v.Z);
    }

    public static Vector3F Divide(Vector3F v, float s)
    {
      float num = 1f / s;
      return new Vector3F(v.X * num, v.Y * num, v.Z * num);
    }

    public static Vector3F Multiply(Vector3F u, float s)
    {
      return new Vector3F(u.X * s, u.Y * s, u.Z * s);
    }

    public static float DotProduct(Vector3F u, Vector3F v)
    {
      return (float) ((double) u.X * (double) v.X + (double) u.Y * (double) v.Y + (double) u.Z * (double) v.Z);
    }

    public static Vector3F CrossProduct(Vector3F u, Vector3F v)
    {
      return new Vector3F((float) ((double) u.Y * (double) v.Z - (double) u.Z * (double) v.Y), (float) ((double) u.Z * (double) v.X - (double) u.X * (double) v.Z), (float) ((double) u.X * (double) v.Y - (double) u.Y * (double) v.X));
    }

    public static Vector3F Negate(Vector3F v)
    {
      return new Vector3F(-v.X, -v.Y, -v.Z);
    }

    public static bool AreApproxEqual(Vector3F u, Vector3F v)
    {
      return Vector3F.AreApproxEqual(u, v, 4.768372E-07f);
    }

    public static bool AreApproxEqual(Vector3F u, Vector3F v, float tolerance)
    {
      if ((double) System.Math.Abs(v.X - u.X) <= (double) tolerance && (double) System.Math.Abs(v.Y - u.Y) <= (double) tolerance)
        return (double) System.Math.Abs(v.Z - u.Z) <= (double) tolerance;
      return false;
    }

    public void Normalize()
    {
      float lengthSquared = this.GetLengthSquared();
      if ((double) lengthSquared == 1.0)
        return;
      float num = 1f / (float) System.Math.Sqrt((double) lengthSquared);
      this.X *= num;
      this.Y *= num;
      this.Z *= num;
    }

    public Vector3F GetUnit()
    {
      float lengthSquared = this.GetLengthSquared();
      if ((double) lengthSquared == 1.0)
        return this;
      float num = 1f / (float) System.Math.Sqrt((double) lengthSquared);
      return new Vector3F(this.X * num, this.Y * num, this.Z * num);
    }

    public float GetLength()
    {
      return (float) System.Math.Sqrt((double) this.X * (double) this.X + (double) this.Y * (double) this.Y + (double) this.Z * (double) this.Z);
    }

    public float GetLengthSquared()
    {
      return (float) ((double) this.X * (double) this.X + (double) this.Y * (double) this.Y + (double) this.Z * (double) this.Z);
    }

    public static Vector3F FromAngle(double angle)
    {
      return new Vector3F((float) System.Math.Cos(angle), (float) System.Math.Sin(angle), 0.0f);
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Vector3F)
        return this.Equals((Vector3F) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}, {2}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture), (object) this.Z.ToString((IFormatProvider) invariantCulture));
    }

    public static Vector3F Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 3)
        throw new ArgumentException("Illegal vector string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Vector3F(float.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), float.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat), float.Parse(strArray[2], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal vector string.", ex);
      }
    }

    public static bool operator ==(Vector3F u, Vector3F v)
    {
      if ((double) u.X == (double) v.X && (double) u.Y == (double) v.Y)
        return (double) u.Z == (double) v.Z;
      return false;
    }

    public static bool operator !=(Vector3F u, Vector3F v)
    {
      if ((double) u.X == (double) v.X && (double) u.Y == (double) v.Y)
        return (double) u.Z != (double) v.Z;
      return true;
    }

    public static Vector3F operator -(Vector3F v)
    {
      return Vector3F.Negate(v);
    }

    public static Vector3F operator +(Vector3F u, Vector3F v)
    {
      return Vector3F.Add(u, v);
    }

    public static Vector3F operator -(Vector3F u, Vector3F v)
    {
      return Vector3F.Subtract(u, v);
    }

    public static Vector3F operator *(Vector3F v, float s)
    {
      return Vector3F.Multiply(v, s);
    }

    public static Vector3F operator *(float s, Vector3F v)
    {
      return Vector3F.Multiply(v, s);
    }

    public static Vector3F operator /(Vector3F v, float s)
    {
      return Vector3F.Divide(v, s);
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

    public static explicit operator float[](Vector3F v)
    {
      return new float[3]{ v.X, v.Y, v.Z };
    }

    public static explicit operator Vector3F(Vector2F v)
    {
      return new Vector3F(v.X, v.Y, 0.0f);
    }

    public static explicit operator Vector3F(Vector4F v)
    {
      return new Vector3F(v.X, v.Y, v.Z);
    }

    public static explicit operator Vector3F(Point3F p)
    {
      return new Vector3F(p.X, p.Y, p.Z);
    }

    private static Vector3F smethod_0(float x, float y, float z)
    {
      return new Vector3F(x, y, z);
    }

    public bool Equals(Vector3F other)
    {
      if ((double) this.X == (double) other.X && (double) this.Y == (double) other.Y)
        return (double) this.Z == (double) other.Z;
      return false;
    }
  }
}
