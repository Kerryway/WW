// Decompiled with JetBrains decompiler
// Type: ns2.Class347
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.IO;
using System.Text;

namespace ns2
{
  internal class Class347 : Interface13
  {
    protected internal BinaryWriter binaryWriter_0;
    private Encoding encoding_0;

    internal Class347(BinaryWriter writer, Encoding encoding)
    {
      this.binaryWriter_0 = writer;
      this.encoding_0 = encoding;
    }

    protected internal virtual void vmethod_0(int groupCode)
    {
      if (groupCode >= (int) byte.MaxValue)
      {
        this.binaryWriter_0.Write(byte.MaxValue);
        this.binaryWriter_0.Write((short) groupCode);
      }
      else
        this.binaryWriter_0.Write((byte) groupCode);
    }

    internal Encoding Encoding
    {
      get
      {
        return this.encoding_0;
      }
    }

    internal BinaryWriter Writer
    {
      get
      {
        return this.binaryWriter_0;
      }
    }

    public void imethod_0(Struct18 group)
    {
      if (group.Code == 999)
        return;
      this.vmethod_0(group.Code);
      Class820.smethod_3(group.Code, group.Value, this);
    }

    public void imethod_1(int baseCode, Struct18 group)
    {
      if (group.Code == 999)
        return;
      this.vmethod_0(group.Code);
      Class820.smethod_3(baseCode, group.Value, this);
    }

    public void imethod_2(Struct18 group)
    {
      if (group.Code == 999)
        return;
      this.vmethod_0(group.Code);
      Class820.smethod_40(group.Value, this);
    }

    public void imethod_3(Struct18 group)
    {
      if (group.Code == 999)
        return;
      this.vmethod_0(group.Code);
      Class820.smethod_41(group.Value, this);
    }

    public void imethod_4(Struct18 group)
    {
      this.vmethod_0(group.Code);
      Class820.smethod_36(group.Value, this);
    }

    public void Flush()
    {
      this.binaryWriter_0.Flush();
    }

    public void imethod_5()
    {
      this.binaryWriter_0.Close();
      this.binaryWriter_0 = (BinaryWriter) null;
    }
  }
}
