// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.NoMoreSegmentsException
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.Math.Geometry
{
  public class NoMoreSegmentsException : Exception
  {
    public NoMoreSegmentsException()
      : this("No more segments available!")
    {
    }

    public NoMoreSegmentsException(string message)
      : base(message)
    {
    }
  }
}
