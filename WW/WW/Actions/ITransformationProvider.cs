// Decompiled with JetBrains decompiler
// Type: WW.Actions.ITransformationProvider
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using WW.Math;

namespace WW.Actions
{
  public interface ITransformationProvider
  {
    event EventHandler TransformsChanged;

    Matrix4D WorldTransform { get; }

    Matrix4D ProjectionTransform { get; }

    Matrix4D CanonicalProjectionTransform { get; }

    Matrix4D CompleteTransform { get; }
  }
}
