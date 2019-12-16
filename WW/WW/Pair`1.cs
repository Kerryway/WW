// Decompiled with JetBrains decompiler
// Type: WW.Pair`1
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW
{
  public class Pair<T>
  {
    private readonly T gparam_0;
    private readonly T gparam_1;

    public Pair(T first, T second)
    {
      this.gparam_0 = first;
      this.gparam_1 = second;
    }

    public T First
    {
      get
      {
        return this.gparam_0;
      }
    }

    public T Second
    {
      get
      {
        return this.gparam_1;
      }
    }

    public override bool Equals(object obj)
    {
      Pair<T> pair = obj as Pair<T>;
      if (pair != null && this.gparam_0.Equals((object) pair.gparam_0))
        return this.gparam_1.Equals((object) pair.gparam_1);
      return false;
    }

    public override int GetHashCode()
    {
      return this.gparam_0.GetHashCode() ^ this.gparam_1.GetHashCode();
    }
  }
}
