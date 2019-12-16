// Decompiled with JetBrains decompiler
// Type: WW.Actions.SimpleInteractor
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Actions
{
  public abstract class SimpleInteractor : Interactor
  {
    private readonly SimpleTransformationProviderBase simpleTransformationProviderBase_0;

    protected SimpleInteractor(
      SimpleTransformationProviderBase transformationProvider)
    {
      this.simpleTransformationProviderBase_0 = transformationProvider;
    }

    public SimpleTransformationProviderBase TransformationProvider
    {
      get
      {
        return this.simpleTransformationProviderBase_0;
      }
    }
  }
}
