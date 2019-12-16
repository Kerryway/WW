// Decompiled with JetBrains decompiler
// Type: ns3.Class316
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class316 : Class259
  {
    private ulong ulong_2;

    public Class316(DxfViewportEntityHeader viewportEntityHeader)
      : base((DxfHandledObject) viewportEntityHeader)
    {
    }

    public ulong NextViewportHeaderHandle
    {
      get
      {
        return this.ulong_2;
      }
      set
      {
        this.ulong_2 = value;
      }
    }

    public override string ToString()
    {
      DxfViewportEntityHeader handledObject = (DxfViewportEntityHeader) this.HandledObject;
      return string.Format("vpeh {0}, vp {1}, nh {2}", (object) handledObject.Handle.ToString("x"), handledObject.Viewport == null ? (object) "-" : (object) handledObject.Viewport.Handle.ToString("x"), (object) this.ulong_2.ToString("x"));
    }
  }
}
