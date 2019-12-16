// Decompiled with JetBrains decompiler
// Type: ns28.Class655
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.IO;
using WW.Cad.Model;

namespace ns28
{
  internal class Class655
  {
    private MemoryStream memoryStream_0;
    private List<Class991> list_0;
    private int int_0;

    public Class655(
      MemoryStream stream,
      DxfModel model,
      List<Class991> handleAndStreamPositionList,
      int streamOffset)
    {
      this.memoryStream_0 = stream;
      this.list_0 = handleAndStreamPositionList;
      this.int_0 = streamOffset;
      handleAndStreamPositionList.Sort();
    }

    public void Write()
    {
      byte[] buffer1 = new byte[10];
      byte[] buffer2 = new byte[5];
      ulong num1 = 0;
      long num2 = 0;
      long position1 = this.memoryStream_0.Position;
      this.memoryStream_0.WriteByte((byte) 0);
      this.memoryStream_0.WriteByte((byte) 0);
      foreach (Class991 class991 in this.list_0)
      {
        long num3 = class991.StreamPosition + (long) this.int_0;
        ulong num4 = class991.Handle - num1;
        long num5 = num3 - num2;
        int count1 = Class724.smethod_5(num4, buffer1);
        int count2 = Class724.smethod_4((int) num5, buffer2);
        int num6 = count1 + count2;
        if (this.memoryStream_0.Position - position1 + (long) num6 > 2032L)
        {
          this.method_0(position1);
          ulong num7 = 0;
          position1 = this.memoryStream_0.Position;
          this.memoryStream_0.WriteByte((byte) 0);
          this.memoryStream_0.WriteByte((byte) 0);
          num7 = 0UL;
          long num8 = 0;
          ulong num9 = class991.Handle - 0UL;
          if (num9 == 0UL)
            throw new Exception(string.Format("Non unique handle encountered: {0}", (object) class991.Handle));
          long num10 = num3 - num8;
          count1 = Class724.smethod_5(num9, buffer1);
          count2 = Class724.smethod_4((int) num10, buffer2);
        }
        this.memoryStream_0.Write(buffer1, 0, count1);
        this.memoryStream_0.Write(buffer2, 0, count2);
        num1 = class991.Handle;
        num2 = num3;
      }
      this.method_0(position1);
      long position2 = this.memoryStream_0.Position;
      this.memoryStream_0.WriteByte((byte) 0);
      this.memoryStream_0.WriteByte((byte) 0);
      this.method_0(position2);
    }

    private void method_0(long sectionStartPosition)
    {
      ushort num1 = (ushort) (this.memoryStream_0.Position - sectionStartPosition);
      long position = this.memoryStream_0.Position;
      this.memoryStream_0.Position = sectionStartPosition;
      this.memoryStream_0.WriteByte((byte) ((uint) num1 >> 8));
      this.memoryStream_0.WriteByte((byte) ((uint) num1 & (uint) byte.MaxValue));
      this.memoryStream_0.Position = position;
      ushort num2 = Stream1.smethod_1((ushort) 49345, this.memoryStream_0.GetBuffer(), sectionStartPosition, this.memoryStream_0.Length - sectionStartPosition);
      this.memoryStream_0.WriteByte((byte) ((uint) num2 >> 8));
      this.memoryStream_0.WriteByte((byte) ((uint) num2 & (uint) byte.MaxValue));
    }
  }
}
