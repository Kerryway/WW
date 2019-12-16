// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Transparency
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model
{
  public struct Transparency : IEquatable<Transparency>
  {
    public static readonly Transparency ByLayer = new Transparency(0U);
    public static readonly Transparency ByBlock = new Transparency(16777216U);
    public static readonly Transparency Transparent = new Transparency(33554432U);
    public static readonly Transparency Opaque = new Transparency(33554687U);
    private uint uint_0;

    internal Transparency(uint data)
    {
      this.uint_0 = data;
    }

    public TransparencyType TransparencyType
    {
      get
      {
        return (TransparencyType) (this.uint_0 >> 24);
      }
    }

    public byte Alpha
    {
      get
      {
        return (byte) (this.uint_0 & (uint) byte.MaxValue);
      }
    }

    public override int GetHashCode()
    {
      return this.uint_0.GetHashCode();
    }

    public override bool Equals(object obj)
    {
      if (obj != null && obj is Transparency)
        return (int) this.uint_0 == (int) ((Transparency) obj).uint_0;
      return false;
    }

    public static Transparency Create(byte alpha)
    {
      return new Transparency(33554432U | (uint) alpha);
    }

    public override string ToString()
    {
      if (this == Transparency.ByLayer)
        return "By layer";
      if (this == Transparency.ByBlock)
        return "By block";
      return string.Format("Alpha = {0}", (object) this.Alpha);
    }

    public static bool operator ==(Transparency a, Transparency b)
    {
      return (int) a.uint_0 == (int) b.uint_0;
    }

    public static bool operator !=(Transparency a, Transparency b)
    {
      return (int) a.uint_0 != (int) b.uint_0;
    }

    public bool Equals(Transparency other)
    {
      return (int) this.uint_0 == (int) other.uint_0;
    }

    internal uint Data
    {
      get
      {
        return this.uint_0;
      }
    }
  }
}
