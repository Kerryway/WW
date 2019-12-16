// Decompiled with JetBrains decompiler
// Type: ns6.Class560
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using System.IO;

namespace ns6
{
  internal class Class560 : Dictionary<ulong, List<Stream>>
  {
    public void Add(ulong handle, Stream data)
    {
      List<Stream> streamList;
      if (!this.TryGetValue(handle, out streamList))
      {
        streamList = new List<Stream>();
        this.Add(handle, streamList);
      }
      streamList.Add(data);
    }
  }
}
