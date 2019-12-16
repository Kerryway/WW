// Decompiled with JetBrains decompiler
// Type: WW.Math.Vector4F
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
  [TypeConverter(typeof (Vector4FConverter))]
  [Serializable]
  public struct Vector4F : IEquatable<Vector4F>
  {
    public static readonly Vector4F Zero = Vector4F.smethod_0(0.0f, 0.0f, 0.0f, 0.0f);
    public static readonly Vector4F XAxis = Vector4F.smethod_0(1f, 0.0f, 0.0f, 0.0f);
    public static readonly Vector4F YAxis = Vector4F.smethod_0(0.0f, 1f, 0.0f, 0.0f);
    public static readonly Vector4F ZAxis = Vector4F.smethod_0(0.0f, 0.0f, 1f, 0.0f);
    public static readonly Vector4F WAxis = Vector4F.smethod_0(0.0f, 0.0f, 0.0f, 1f);
    public float X;
    public float Y;
    public float Z;
    public float W;

    [DebuggerStepThrough]
    public Vector4F(float x, float y, float z, float w)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
      this.W = w;
    }

    [DebuggerStepThrough]
    public Vector4F(float[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
      this.W = coordinates[3];
    }

    [DebuggerStepThrough]
    public Vector4F(IList<float> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
      this.W = coordinates[3];
    }

    [DebuggerStepThrough]
    public Vector4F(Vector4F from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
      this.W = from.W;
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

    [DisplayName("Z")]
    [Obsolete]
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

    [DisplayName("W")]
    [Obsolete]
    public float _WProperty
    {
      get
      {
        return this.W;
      }
      set
      {
        this.W = value;
      }
    }

    public static Vector4F Add(Vector4F u, Vector4F v)
    {
      return new Vector4F(u.X + v.X, u.Y + v.Y, u.Z + v.Z, u.W + v.W);
    }

    public static Vector4F Subtract(Vector4F u, Vector4F v)
    {
      return new Vector4F(u.X - v.X, u.Y - v.Y, u.Z - v.Z, u.W - v.W);
    }

    public static Vector4F Divide(Vector4F v, float s)
    {
      float num = 1f / s;
      return new Vector4F(v.X * num, v.Y * num, v.Z * num, v.W * num);
    }

    public static Vector4F Multiply(Vector4F u, float s)
    {
      return new Vector4F(u.X * s, u.Y * s, u.Z * s, u.W * s);
    }

    public static float DotProduct(Vector4F u, Vector4F v)
    {
      return (float) ((double) u.X * (double) v.X + (double) u.Y * (double) v.Y + (double) u.Z * (double) v.Z + (double) u.W * (double) v.W);
    }

    public static Vector4F Negate(Vector4F v)
    {
      return new Vector4F(-v.X, -v.Y, -v.Z, -v.W);
    }

    public static bool AreApproxEqual(Vector4F u, Vector4F v)
    {
      return Vector4F.AreApproxEqual(u, v, 4.768372E-07f);
    }

    public static bool AreApproxEqual(Vector4F u, Vector4F v, float tolerance)
    {
      if ((double) System.Math.Abs(v.X - u.X) <= (double) tolerance && (double) System.Math.Abs(v.Y - u.Y) <= (double) tolerance && (double) System.Math.Abs(v.Z - u.Z) <= (double) tolerance)
        return (double) System.Math.Abs(v.W - u.W) <= (double) tolerance;
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
      this.W *= num;
    }

    public Vector4F GetUnit()
    {
      float lengthSquared = this.GetLengthSquared();
      if ((double) lengthSquared == 1.0)
        return this;
      float num = 1f / (float) System.Math.Sqrt((double) lengthSquared);
      return new Vector4F(this.X * num, this.Y * num, this.Z * num, this.W * num);
    }

    public float GetLength()
    {
      return (float) System.Math.Sqrt((double) this.X * (double) this.X + (double) this.Y * (double) this.Y + (double) this.Z * (double) this.Z + (double) this.W * (double) this.W);
    }

    public float GetLengthSquared()
    {
      return (float) ((double) this.X * (double) this.X + (double) this.Y * (double) this.Y + (double) this.Z * (double) this.Z + (double) this.W * (double) this.W);
    }

    public static Vector4F FromWeightedEuclidean(Point3F p, float w)
    {
      return new Vector4F(p.X * w, p.Y * w, p.Z * w, w);
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode() ^ this.W.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Vector4F)
        return this.Equals((Vector4F) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}, {2}, {3}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture), (object) this.Z.ToString((IFormatProvider) invariantCulture), (object) this.W.ToString((IFormatProvider) invariantCulture));
    }

    public static Vector4F Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 4)
        throw new ArgumentException("Illegal vector string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Vector4F(float.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), float.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat), float.Parse(strArray[2], (IFormatProvider) invariantCulture.NumberFormat), float.Parse(strArray[3], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal vector string.", ex);
      }
    }

    public static bool operator ==(Vector4F u, Vector4F v)
    {
      if ((double) u.X == (double) v.X && (double) u.Y == (double) v.Y && (double) u.Z == (double) v.Z)
        return (double) u.W == (double) v.W;
      return false;
    }

    public static bool operator !=(Vector4F u, Vector4F v)
    {
      if ((double) u.X == (double) v.X && (double) u.Y == (double) v.Y && (double) u.Z == (double) v.Z)
        return (double) u.W != (double) v.W;
      return true;
    }

    public static Vector4F operator -(Vector4F v)
    {
      return Vector4F.Negate(v);
    }

    public static Vector4F operator +(Vector4F u, Vector4F v)
    {
      return Vector4F.Add(u, v);
    }

    public static Vector4F operator +(Vector4F u, Vector3F v)
    {
      return new Vector4F(u.X + v.X, u.Y + v.Y, u.Z + v.Z, u.W);
    }

    public static Vector4F operator -(Vector4F u, Vector4F v)
    {
      return Vector4F.Subtract(u, v);
    }

    public static Vector4F operator -(Vector4F u, Vector3F v)
    {
      return new Vector4F(u.X - v.X, u.Y - v.Y, u.Z - v.Z, u.W);
    }

    public static Vector4F operator *(Vector4F v, float s)
    {
      return Vector4F.Multiply(v, s);
    }

    public static Vector4F operator *(float s, Vector4F v)
    {
      return Vector4F.Multiply(v, s);
    }

    public static Vector4F operator /(Vector4F v, float s)
    {
      return Vector4F.Divide(v, s);
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
          case 3:
            return this.W;
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
          case 3:
            this.W = value;
            break;
          default:
            throw new IndexOutOfRangeException();
        }
      }
    }

    public static explicit operator float[](Vector4F v)
    {
      return new float[4]{ v.X, v.Y, v.Z, v.W };
    }

    public static explicit operator Vector4F(Vector3F v)
    {
      return new Vector4F(v.X, v.Y, v.Z, 1f);
    }

    private static Vector4F smethod_0(float x, float y, float z, float w)
    {
      return new Vector4F(x, y, z, w);
    }

    public bool Equals(Vector4F other)
    {
      if ((double) this.X == (double) other.X && (double) this.Y == (double) other.Y && (double) this.Z == (double) other.Z)
        return (double) this.W == (double) other.W;
      return false;
    }
  }
}
