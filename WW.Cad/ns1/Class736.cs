// Decompiled with JetBrains decompiler
// Type: ns1.Class736
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;

namespace ns1
{
  internal class Class736
  {
    private double double_0 = 2.5;

    public double Width
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
      }
    }

    internal Class736 Clone(CloneContext cloneContext)
    {
      Class736 class736 = new Class736();
      class736.CopyFrom(this, cloneContext);
      return class736;
    }

    private void CopyFrom(Class736 from, CloneContext cloneContext)
    {
      this.double_0 = from.double_0;
    }
  }
}
