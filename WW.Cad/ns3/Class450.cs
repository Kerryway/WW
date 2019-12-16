// Decompiled with JetBrains decompiler
// Type: ns3.Class450
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;

namespace ns3
{
  internal class Class450
  {
    private DxfHandledObject dxfHandledObject_0;
    private Class259 class259_0;

    public Class450(DxfHandledObject handledObject, Class259 objectBuilder)
    {
      this.dxfHandledObject_0 = handledObject;
      this.class259_0 = objectBuilder;
    }

    public DxfHandledObject HandledObject
    {
      get
      {
        return this.dxfHandledObject_0;
      }
      set
      {
        this.dxfHandledObject_0 = value;
      }
    }

    public Class259 ObjectBuilder
    {
      get
      {
        return this.class259_0;
      }
    }
  }
}
