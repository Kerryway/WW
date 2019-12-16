// Decompiled with JetBrains decompiler
// Type: ns35.Class890
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System.IO;
using System.Text;

namespace ns35
{
  internal class Class890 : Class889
  {
    public Class890(Stream stream, Encoding encoding)
      : base(stream, Encoding.Unicode)
    {
    }

    public override string vmethod_16()
    {
      short num = (short) ((int) this.vmethod_4() << 1);
      return num <= (short) 0 ? string.Empty : Encoding.Unicode.GetString(this.vmethod_3((int) num), 0, (int) num - 2);
    }

    public override string vmethod_21()
    {
      int count = this.vmethod_8();
      return count <= 0 ? string.Empty : Encoding.Unicode.GetString(this.vmethod_3(count), 0, count);
    }

    public override string vmethod_17(int lengthInBytes)
    {
      if (lengthInBytes == 0)
        return string.Empty;
      return Encoding.Unicode.GetString(this.vmethod_3(lengthInBytes), 0, lengthInBytes - 2);
    }

    public override void vmethod_19(string value)
    {
      this.vmethod_5((short) (value.Length + 1));
      byte[] bytes = Encoding.Unicode.GetBytes(value);
      this.Stream.Write(bytes, 0, bytes.Length);
      this.Stream.WriteByte((byte) 0);
      this.Stream.WriteByte((byte) 0);
    }

    public override void vmethod_22(string value)
    {
      this.vmethod_9(value.Length << 1);
      byte[] bytes = Encoding.Unicode.GetBytes(value);
      this.Stream.Write(bytes, 0, bytes.Length);
    }
  }
}
