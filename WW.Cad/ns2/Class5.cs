// Decompiled with JetBrains decompiler
// Type: ns2.Class5
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WW.Cad.Model.Entities;

namespace ns2
{
  internal class Class5 : Class2
  {
    internal Class5(BinaryReader r, Encoding encoding, ShxFile shxfile)
      : base(r, encoding, (CharRemapDelegate) null, shxfile)
    {
    }

    internal override void Read()
    {
      ushort num1 = this.binaryReader_0.ReadUInt16();
      ushort num2 = this.binaryReader_0.ReadUInt16();
      Class5.Struct17[] struct17Array = new Class5.Struct17[(int) num2];
      for (int index = 0; index < (int) num2; ++index)
      {
        ushort start = this.binaryReader_0.ReadUInt16();
        ushort end = this.binaryReader_0.ReadUInt16();
        struct17Array[index] = new Class5.Struct17(start, end);
      }
      Dictionary<long, Class5.Class1059> dictionary = new Dictionary<long, Class5.Class1059>((int) num1);
      for (int index = 0; index < (int) num1; ++index)
      {
        ushort id = this.binaryReader_0.ReadUInt16();
        ushort length = this.binaryReader_0.ReadUInt16();
        uint fileOffset = this.binaryReader_0.ReadUInt32();
        if (fileOffset != 0U)
          dictionary[(long) fileOffset] = new Class5.Class1059(id, length, fileOffset);
      }
      ushort count = (ushort) dictionary.Count;
      for (int index = 0; index < (int) count; ++index)
      {
        long position1 = this.binaryReader_0.BaseStream.Position;
        Class5.Class1059 class1059;
        dictionary.TryGetValue(position1, out class1059);
        if (class1059 == null)
          throw new Exception("Corrupt shx bigfont file.");
        if (class1059.ushort_0 == (ushort) 0)
        {
          long position2 = this.binaryReader_0.BaseStream.Position;
          this.method_0();
          long num3 = this.binaryReader_0.BaseStream.Position - position2;
          int num4 = (int) class1059.ushort_1 - (int) num3;
          if (num4 == 5)
          {
            this.shxFile_0.method_5((int) this.binaryReader_0.ReadByte());
            int num5 = (int) this.binaryReader_0.ReadByte();
            this.shxFile_0.method_4((int) this.binaryReader_0.ReadByte());
            this.shxFile_0.method_6((int) this.binaryReader_0.ReadByte());
            int num6 = (int) this.binaryReader_0.ReadByte();
          }
          else
          {
            this.shxFile_0.method_2((int) this.binaryReader_0.ReadByte());
            this.shxFile_0.method_3((int) this.binaryReader_0.ReadByte());
            this.shxFile_0.method_4((int) this.binaryReader_0.ReadByte());
            while (num4-- > 3)
            {
              int num5 = (int) this.binaryReader_0.ReadByte();
            }
          }
        }
        else
        {
          long position2 = this.binaryReader_0.BaseStream.Position;
          string description = this.method_0();
          long num3 = this.binaryReader_0.BaseStream.Position - position2;
          byte[] geometry = this.binaryReader_0.ReadBytes((int) class1059.ushort_1 - (int) num3);
          this.shxFile_0.method_0(new ShxShape(this.shxFile_0, class1059.ushort_0, ShxShape.smethod_16(this.encoding_0, class1059.ushort_0), description, geometry));
        }
      }
    }

    private struct Struct17
    {
      public ushort ushort_0;
      public ushort ushort_1;

      public Struct17(ushort start, ushort end)
      {
        this.ushort_0 = start;
        this.ushort_1 = end;
      }
    }

    private class Class1059
    {
      public readonly ushort ushort_0;
      public readonly ushort ushort_1;
      public readonly uint uint_0;

      public Class1059(ushort id, ushort length, uint fileOffset)
      {
        this.ushort_0 = id;
        this.ushort_1 = length;
        this.uint_0 = fileOffset;
      }
    }
  }
}
