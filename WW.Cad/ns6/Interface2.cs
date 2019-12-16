// Decompiled with JetBrains decompiler
// Type: ns6.Interface2
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System.IO;

namespace ns6
{
  internal interface Interface2
  {
    Stream imethod_0(Class741.Class742 serializer);

    void Read(Class889 r, int dataSize);

    void Write(Class889 w);
  }
}
