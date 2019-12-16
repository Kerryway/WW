// Decompiled with JetBrains decompiler
// Type: WW.Drawing.PenInfo
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.Drawing
{
  public class PenInfo : IEquatable<PenInfo>
  {
    private readonly ArgbColor argbColor_0;
    private readonly double double_0;

    public PenInfo(ArgbColor color, double lineWidth)
    {
      this.argbColor_0 = color;
      this.double_0 = lineWidth;
    }

    public ArgbColor Color
    {
      get
      {
        return this.argbColor_0;
      }
    }

    public double LineWidth
    {
      get
      {
        return this.double_0;
      }
    }

    public bool Equals(PenInfo other)
    {
      if (object.ReferenceEquals((object) null, (object) other))
        return false;
      if (object.ReferenceEquals((object) this, (object) other))
        return true;
      if (other.argbColor_0.Equals(this.argbColor_0))
        return other.double_0.Equals(this.double_0);
      return false;
    }

    public override bool Equals(object obj)
    {
      if (object.ReferenceEquals((object) null, obj))
        return false;
      if (object.ReferenceEquals((object) this, obj))
        return true;
      if (obj.GetType() != typeof (PenInfo))
        return false;
      return this.Equals((PenInfo) obj);
    }

    public override int GetHashCode()
    {
      return this.argbColor_0.GetHashCode() * 397 ^ this.double_0.GetHashCode();
    }

    public static bool operator ==(PenInfo left, PenInfo right)
    {
      return object.Equals((object) left, (object) right);
    }

    public static bool operator !=(PenInfo left, PenInfo right)
    {
      return !object.Equals((object) left, (object) right);
    }
  }
}
