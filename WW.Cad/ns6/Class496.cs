// Decompiled with JetBrains decompiler
// Type: ns6.Class496
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System;
using System.IO;
using WW.Cad.IO;
using WW.Cad.Model;
using WW.IO;

namespace ns6
{
  internal class Class496 : Class495
  {
    protected override bool vmethod_0(DxfReader r)
    {
      bool flag;
      if (!(flag = base.vmethod_0(r)))
      {
        flag = true;
        switch (this.DataType)
        {
          case Enum26.const_0:
          case Enum26.const_1:
          case Enum26.const_2:
          case Enum26.const_3:
          case Enum26.const_4:
          case Enum26.const_5:
          case Enum26.const_6:
          case Enum26.const_7:
          case Enum26.const_8:
          case Enum26.const_10:
          case Enum26.const_11:
            this.Data = new Struct18(r.CurrentGroup.Code, r.CurrentGroup.Value);
            r.method_85();
            break;
          case Enum26.const_9:
            if (r.CurrentGroup.Code == 161)
              this.Data = new Struct18(r.CurrentGroup.Code, r.CurrentGroup.Value);
            else
              this.Data = new Struct18(r.CurrentGroup.Code, (object) DxfHandledObject.Parse(r.CurrentGroup.ValueString));
            r.method_85();
            break;
          case Enum26.const_12:
            break;
          case Enum26.const_14:
            int num = (int) r.CurrentGroup.Value;
            r.method_85();
            PagedMemoryStream pagedMemoryStream = (PagedMemoryStream) null;
            while (r.CurrentGroup.Code == 310)
            {
              if (pagedMemoryStream == null)
              {
                pagedMemoryStream = new PagedMemoryStream((long) num);
                this.Data = new Struct18(r.CurrentGroup.Code, (object) pagedMemoryStream);
              }
              byte[] buffer = (byte[]) r.CurrentGroup.Value;
              pagedMemoryStream.Write(buffer, 0, buffer.Length);
              r.method_85();
            }
            if (pagedMemoryStream != null)
            {
              pagedMemoryStream.Position = 0L;
              break;
            }
            break;
          default:
            flag = false;
            break;
        }
      }
      return flag;
    }

    public override void Write(DxfWriter w)
    {
      base.Write(w);
      switch (this.DataType)
      {
        case Enum26.const_0:
          Enum5 enum5 = Class820.smethod_2(this.Data.Code);
          bool flag;
          switch (enum5)
          {
            case Enum5.const_1:
              flag = (bool) this.Data.Value;
              break;
            case Enum5.const_10:
            case Enum5.const_17:
              flag = this.Data.Int16 != (short) 0;
              break;
            default:
              throw new Exception("Invalid group value type " + (object) enum5 + ".");
          }
          w.Write(291, (object) flag);
          break;
        case Enum26.const_1:
          w.Write(0, this.Data.Value);
          break;
        case Enum26.const_2:
          w.Write(281, this.Data.Value);
          break;
        case Enum26.const_3:
          w.Write(70, (object) this.Data.Int16);
          break;
        case Enum26.const_4:
          w.Write(92, this.Data.Value);
          break;
        case Enum26.const_5:
          w.Write(160, this.Data.Value);
          break;
        case Enum26.const_6:
          w.Write(282, this.Data.Value);
          break;
        case Enum26.const_7:
          w.Write(71, (object) this.Data.UInt16);
          break;
        case Enum26.const_8:
          w.Write(93, this.Data.Value);
          break;
        case Enum26.const_9:
          w.Write(320, this.Data.Value);
          break;
        case Enum26.const_10:
          w.Write(41, this.Data.Value);
          break;
        case Enum26.const_11:
          w.Write(40, this.Data.Value);
          break;
        case Enum26.const_12:
          throw new Exception();
        case Enum26.const_13:
        case Enum26.const_14:
          if (this.Data.Value == null)
            throw new Exception("No binary data");
          byte[] numArray1 = this.Data.Value as byte[];
          if (numArray1 != null)
          {
            w.Write(94, (object) numArray1.Length);
            int num = numArray1.Length / (int) sbyte.MaxValue;
            byte[] numArray2 = new byte[(int) sbyte.MaxValue];
            for (int index = 0; index < num; ++index)
            {
              Array.Copy((Array) numArray1, index * (int) sbyte.MaxValue, (Array) numArray2, 0, (int) sbyte.MaxValue);
              w.Write(310, (object) numArray2);
            }
            int length = numArray1.Length % (int) sbyte.MaxValue;
            byte[] numArray3 = new byte[length];
            Array.Copy((Array) numArray1, numArray1.Length - length, (Array) numArray3, 0, length);
            w.Write(310, (object) numArray3);
            break;
          }
          Stream stream = this.Data.Value as Stream;
          if (stream == null)
            throw new Exception("Unexpected binary data value type " + (object) this.Data.Value.GetType());
          long position = stream.Position;
          stream.Position = 0L;
          w.Write(94, (object) (int) stream.Length);
          int num1 = (int) stream.Length / (int) sbyte.MaxValue;
          byte[] buffer1 = new byte[(int) sbyte.MaxValue];
          for (int index = 0; index < num1; ++index)
          {
            stream.Read(buffer1, 0, (int) sbyte.MaxValue);
            w.Write(310, (object) buffer1);
          }
          int count = (int) stream.Length % (int) sbyte.MaxValue;
          byte[] buffer2 = new byte[count];
          stream.Read(buffer2, 0, count);
          w.Write(310, (object) buffer2);
          stream.Position = position;
          break;
        default:
          throw new Exception();
      }
    }
  }
}
