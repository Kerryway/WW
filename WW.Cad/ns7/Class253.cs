// Decompiled with JetBrains decompiler
// Type: ns7.Class253
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace ns7
{
  internal class Class253 : Class252
  {
    public const char char_2 = '@';

    internal Class253(
      Interface6 resolver,
      Interface7 subResolver,
      int version,
      Class251.Class254 marker)
      : base(resolver, subResolver, version, marker)
    {
    }

    protected override Interface8 vmethod_0(
      Interface6 entityResolver,
      Interface7 subEntityResolver,
      int fileFormatVersion,
      Class251.Class254 subReadMarker)
    {
      return (Interface8) new Class253(entityResolver, subEntityResolver, fileFormatVersion, subReadMarker);
    }

    public override string ReadString()
    {
      try
      {
        string str = this.method_2();
        if (str[0] == '@')
          str = str.Substring(1);
        return this.method_3(Convert.ToInt32(str));
      }
      catch (FormatException ex)
      {
        throw new Exception0("String length broken!", (Exception) ex);
      }
    }
  }
}
