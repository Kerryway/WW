// Decompiled with JetBrains decompiler
// Type: ns2.Class2
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.IO;
using System.Text;
using WW;
using WW.Cad.Model.Entities;

namespace ns2
{
  internal class Class2
  {
    protected internal BinaryReader binaryReader_0;
    protected readonly Encoding encoding_0;
    protected readonly CharRemapDelegate charRemapDelegate_0;
    protected internal ShxFile shxFile_0;
    private readonly MemoryStream memoryStream_0;

    internal Class2(
      BinaryReader r,
      Encoding encoding,
      CharRemapDelegate charRemapper,
      ShxFile shxfile)
    {
      this.binaryReader_0 = r;
      this.encoding_0 = encoding;
      this.charRemapDelegate_0 = charRemapper;
      this.shxFile_0 = shxfile;
      this.memoryStream_0 = new MemoryStream();
    }

    protected virtual void vmethod_0(
      Class2.Struct0[] shapeInfoList,
      out int degree,
      out int plusMinus,
      out int diameter)
    {
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      foreach (Class2.Struct0 shapeInfo in shapeInfoList)
      {
        switch (shapeInfo.ushort_0)
        {
          case (ushort) sbyte.MaxValue:
            flag2 = true;
            break;
          case 129:
            flag1 = true;
            break;
          case 248:
            flag3 = true;
            break;
        }
      }
      bool flag4 = flag2 && flag3;
      degree = flag4 ? 248 : (int) sbyte.MaxValue;
      plusMinus = flag4 ? 241 : 128;
      if (!flag4)
        diameter = flag1 ? 129 : 258;
      else
        diameter = 237;
    }

    internal virtual void Read()
    {
      int num1 = (int) this.binaryReader_0.ReadUInt16();
      int num2 = (int) this.binaryReader_0.ReadUInt16();
      ushort num3 = this.binaryReader_0.ReadUInt16();
      Class2.Struct0[] shapeInfoList = new Class2.Struct0[(int) num3];
      for (int index1 = 0; index1 < (int) num3; ++index1)
      {
        ushort index2 = this.binaryReader_0.ReadUInt16();
        ushort length = this.binaryReader_0.ReadUInt16();
        shapeInfoList[index1] = new Class2.Struct0(index2, length);
      }
      if (num3 <= (ushort) 0)
        return;
      int num4 = 0;
      if (shapeInfoList[0].ushort_0 == (ushort) 0)
      {
        num4 = 1;
        this.shxFile_0.method_1(this.method_0());
        byte[] numArray = this.binaryReader_0.ReadBytes(4);
        this.shxFile_0.method_2((int) numArray[0]);
        this.shxFile_0.method_3((int) numArray[1]);
        this.shxFile_0.method_4((int) numArray[2]);
      }
      int degree;
      int plusMinus;
      int diameter;
      this.vmethod_0(shapeInfoList, out degree, out plusMinus, out diameter);
      for (int index = num4; index < (int) num3; ++index)
      {
        long position = this.binaryReader_0.BaseStream.Position;
        string description = this.method_0();
        long num5 = this.binaryReader_0.BaseStream.Position - position;
        byte[] geometry = this.binaryReader_0.ReadBytes((int) shapeInfoList[index].ushort_1 - (int) num5);
        int ushort0 = (int) shapeInfoList[index].ushort_0;
        char ch;
        if (ushort0 == degree)
          ch = '°';
        else if (ushort0 == plusMinus)
          ch = '±';
        else if (ushort0 == diameter)
          ch = 'Ø';
        else if (ushort0 > (int) byte.MaxValue)
        {
          ch = char.MinValue;
        }
        else
        {
          ch = this.encoding_0.GetChars(LittleEndianBitConverter.GetBytes(shapeInfoList[index].ushort_0))[0];
          if (this.charRemapDelegate_0 != null)
            ch = this.charRemapDelegate_0(ch);
        }
        this.shxFile_0.method_0(new ShxShape(this.shxFile_0, (ushort) ushort0, ch, description, geometry));
      }
    }

    protected internal string method_0()
    {
      try
      {
        for (byte index = this.binaryReader_0.ReadByte(); index != (byte) 0; index = this.binaryReader_0.ReadByte())
          this.memoryStream_0.WriteByte(index);
      }
      catch (EndOfStreamException ex)
      {
        return (string) null;
      }
      string str = this.encoding_0.GetString(this.memoryStream_0.GetBuffer(), 0, (int) this.memoryStream_0.Length);
      this.memoryStream_0.SetLength(0L);
      this.memoryStream_0.Position = 0L;
      return str;
    }

    protected struct Struct0
    {
      public ushort ushort_0;
      public ushort ushort_1;

      public Struct0(ushort index, ushort length)
      {
        this.ushort_0 = index;
        this.ushort_1 = length;
      }
    }
  }
}
