// Decompiled with JetBrains decompiler
// Type: WW.Pair`2
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW
{
  public class Pair<T1, T2>
  {
    private readonly T1 gparam_0;
    private readonly T2 gparam_1;

    public Pair(T1 first, T2 second)
    {
      this.gparam_0 = first;
      this.gparam_1 = second;
    }

    public T1 First
    {
      get
      {
        return this.gparam_0;
      }
    }

    public T2 Second
    {
      get
      {
        return this.gparam_1;
      }
    }

    public override bool Equals(object obj)
    {
      Pair<T1, T2> pair = obj as Pair<T1, T2>;
      if (pair != null && this.gparam_0.Equals((object) pair.gparam_0))
        return this.gparam_1.Equals((object) pair.gparam_1);
      return false;
    }

    public override int GetHashCode()
    {
      return this.gparam_0.GetHashCode() ^ this.gparam_1.GetHashCode();
    }

    public override string ToString()
    {
      return string.Format("{0}, {1}", (object) this.gparam_0, (object) this.gparam_1);
    }
  }
}
