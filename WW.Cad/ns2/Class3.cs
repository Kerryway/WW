// Decompiled with JetBrains decompiler
// Type: ns2.Class3
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.IO;
using System.Text;
using WW.Cad.Model.Entities;

namespace ns2
{
  internal class Class3 : Class2
  {
    internal Class3(BinaryReader r, Encoding encoding, ShxFile shxfile)
      : base(r, encoding, (CharRemapDelegate) null, shxfile)
    {
    }

    internal override void Read()
    {
      ushort num1 = this.binaryReader_0.ReadUInt16();
      int num2 = (int) this.binaryReader_0.ReadUInt16();
      ushort num3 = this.binaryReader_0.ReadUInt16();
      long position1 = this.binaryReader_0.BaseStream.Position;
      string description1 = this.method_0();
      long position2 = this.binaryReader_0.BaseStream.Position;
      this.shxFile_0.method_1(description1);
      byte[] numArray = this.binaryReader_0.ReadBytes((int) ((long) num3 - (position2 - position1)));
      this.shxFile_0.method_2((int) numArray[0]);
      this.shxFile_0.method_3((int) numArray[1]);
      this.shxFile_0.method_4((int) numArray[2]);
      this.shxFile_0.method_7((int) numArray[3]);
      this.shxFile_0.method_8((int) numArray[4]);
      for (int index1 = 1; index1 < (int) num1; ++index1)
      {
        ushort index2 = this.binaryReader_0.ReadUInt16();
        ushort num4 = this.binaryReader_0.ReadUInt16();
        long position3 = this.binaryReader_0.BaseStream.Position;
        string description2 = this.method_0();
        long num5 = this.binaryReader_0.BaseStream.Position - position3;
        byte[] geometry = this.binaryReader_0.ReadBytes((int) num4 - (int) num5);
        this.shxFile_0.method_0(new ShxShape(this.shxFile_0, index2, Convert.ToChar(index2), description2, geometry));
      }
    }
  }
}
