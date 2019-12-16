// Decompiled with JetBrains decompiler
// Type: ns28.Class654
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using System.IO;
using WW.Cad.Model;
using WW.Text;

namespace ns28
{
  internal class Class654
  {
    private static readonly byte[] byte_0 = new byte[16]{ (byte) 212, (byte) 123, (byte) 33, (byte) 206, (byte) 40, (byte) 147, (byte) 159, (byte) 191, (byte) 83, (byte) 36, (byte) 64, (byte) 9, (byte) 18, (byte) 60, (byte) 170, (byte) 1 };
    private static readonly byte[] byte_1 = new byte[16]{ (byte) 43, (byte) 132, (byte) 222, (byte) 49, (byte) 215, (byte) 108, (byte) 96, (byte) 64, (byte) 172, (byte) 219, (byte) 191, (byte) 246, (byte) 237, (byte) 195, (byte) 85, (byte) 254 };
    private Stream stream_0;
    private DxfModel dxfModel_0;
    private DxfHeader dxfHeader_0;
    private MemoryStream memoryStream_0;
    private Interface29 interface29_0;
    private List<Class723> list_0;

    public Class654(Stream stream, DxfModel model, List<Class723> sections)
    {
      this.stream_0 = stream;
      this.dxfModel_0 = model;
      this.dxfHeader_0 = model.Header;
      this.memoryStream_0 = new MemoryStream(500);
      this.interface29_0 = Class724.Create(model.Header.AcadVersion, (Stream) this.memoryStream_0, Encodings.GetEncoding((int) model.Header.DrawingCodePage));
      this.list_0 = sections;
    }

    public void Write()
    {
      this.method_0();
      this.stream_0.Write(Class654.byte_0, 0, Class654.byte_0.Length);
      Stream1 stream1 = new Stream1(this.stream_0, (ushort) 49345);
      int num = 4 + (int) this.interface29_0.Stream.Length + 2 + 8;
      Class1045.smethod_9((Stream) stream1, num);
      stream1.Write(this.memoryStream_0.GetBuffer(), 0, (int) this.memoryStream_0.Length);
      Class1045.smethod_6(this.stream_0, stream1.Crc);
      if (this.dxfModel_0.Header.AcadVersion >= DxfVersion.Dxf14)
      {
        this.stream_0.WriteByte((byte) 147);
        this.stream_0.WriteByte((byte) 134);
        this.stream_0.WriteByte((byte) 187);
        this.stream_0.WriteByte((byte) 0);
        this.stream_0.WriteByte((byte) 208);
        this.stream_0.WriteByte((byte) 56);
        this.stream_0.WriteByte((byte) 131);
        this.stream_0.WriteByte((byte) 87);
      }
      this.stream_0.Write(Class654.byte_1, 0, Class654.byte_1.Length);
    }

    private void method_0()
    {
      this.interface29_0.imethod_33(this.list_0[0].Position);
      this.interface29_0.imethod_12(Encodings.Ascii.GetBytes(this.dxfHeader_0.AcadVersionString));
      this.interface29_0.imethod_11((byte) 0);
      this.interface29_0.imethod_11((byte) 0);
      this.interface29_0.imethod_11((byte) 0);
      this.interface29_0.imethod_11((byte) 0);
      this.interface29_0.imethod_11((byte) 0);
      this.interface29_0.imethod_11((byte) this.dxfHeader_0.AcadMaintenanceVersion);
      this.interface29_0.imethod_11((byte) 1);
      this.interface29_0.imethod_32((short) 1559);
      this.interface29_0.imethod_18((short) Class952.smethod_1(this.dxfHeader_0.DrawingCodePage));
      List<Class723> class723List = new List<Class723>();
      foreach (Class723 class723 in this.list_0)
      {
        if (class723.SectionId.HasValue)
          class723List.Add(class723);
      }
      class723List.Sort();
      this.interface29_0.imethod_32((short) class723List.Count);
      foreach (Class723 class723 in class723List)
      {
        this.interface29_0.imethod_11((byte) class723.SectionId.Value);
        this.interface29_0.imethod_33(class723.Position);
        this.interface29_0.imethod_33((int) class723.Size);
      }
      this.interface29_0.imethod_33(14);
      this.method_1((byte) 0, this.dxfHeader_0.HandleSeed);
      this.method_1((byte) 1, this.dxfModel_0.BlockRecordTable.Handle);
      this.method_1((byte) 2, this.dxfModel_0.LayerTable.Handle);
      this.method_1((byte) 3, this.dxfModel_0.TextStyleTable.Handle);
      this.method_1((byte) 4, this.dxfModel_0.LineTypeTable.Handle);
      this.method_1((byte) 5, this.dxfModel_0.ViewTable.Handle);
      this.method_1((byte) 6, this.dxfModel_0.UcsTable.Handle);
      this.method_1((byte) 7, this.dxfModel_0.VPortTable.Handle);
      this.method_1((byte) 8, this.dxfModel_0.AppIdTable.Handle);
      this.method_1((byte) 9, this.dxfModel_0.DimStyleTable.Handle);
      this.method_1((byte) 10, this.dxfModel_0.ViewportEntityHeaderTable.Handle);
      this.method_1((byte) 11, this.dxfModel_0.DictionaryRoot.Handle);
      this.method_1((byte) 12, this.dxfModel_0.DefaultMLineStyle.Handle);
      this.method_1((byte) 13, this.dxfModel_0.DictionaryAcadGroup.Handle);
      this.interface29_0.Flush();
    }

    private void method_1(byte handleIndex, ulong handle)
    {
      byte num = 0;
      if (handle == 0UL)
      {
        this.interface29_0.imethod_11(num);
        this.interface29_0.imethod_11(handleIndex);
      }
      else if (handle < 256UL)
      {
        this.interface29_0.imethod_11((byte) ((uint) num | 1U));
        this.interface29_0.imethod_11(handleIndex);
        this.interface29_0.imethod_11((byte) handle);
      }
      else if (handle < 65536UL)
      {
        this.interface29_0.imethod_11((byte) ((uint) num | 2U));
        this.interface29_0.imethod_11(handleIndex);
        this.interface29_0.imethod_11((byte) (handle >> 8));
        this.interface29_0.imethod_11((byte) handle);
      }
      else if (handle < 16777216UL)
      {
        this.interface29_0.imethod_11((byte) ((uint) num | 3U));
        this.interface29_0.imethod_11(handleIndex);
        this.interface29_0.imethod_11((byte) (handle >> 16));
        this.interface29_0.imethod_11((byte) (handle >> 8));
        this.interface29_0.imethod_11((byte) handle);
      }
      else if (handle < 4294967296UL)
      {
        this.interface29_0.imethod_11((byte) ((uint) num | 4U));
        this.interface29_0.imethod_11(handleIndex);
        this.interface29_0.imethod_11((byte) (handle >> 24));
        this.interface29_0.imethod_11((byte) (handle >> 16));
        this.interface29_0.imethod_11((byte) (handle >> 8));
        this.interface29_0.imethod_11((byte) handle);
      }
      else if (handle < 1099511627776UL)
      {
        this.interface29_0.imethod_11((byte) ((uint) num | 5U));
        this.interface29_0.imethod_11(handleIndex);
        this.interface29_0.imethod_11((byte) (handle >> 32));
        this.interface29_0.imethod_11((byte) (handle >> 24));
        this.interface29_0.imethod_11((byte) (handle >> 16));
        this.interface29_0.imethod_11((byte) (handle >> 8));
        this.interface29_0.imethod_11((byte) handle);
      }
      else if (handle < 281474976710656UL)
      {
        this.interface29_0.imethod_11((byte) ((uint) num | 6U));
        this.interface29_0.imethod_11(handleIndex);
        this.interface29_0.imethod_11((byte) (handle >> 40));
        this.interface29_0.imethod_11((byte) (handle >> 32));
        this.interface29_0.imethod_11((byte) (handle >> 24));
        this.interface29_0.imethod_11((byte) (handle >> 16));
        this.interface29_0.imethod_11((byte) (handle >> 8));
        this.interface29_0.imethod_11((byte) handle);
      }
      else if (handle < 72057594037927936UL)
      {
        this.interface29_0.imethod_11((byte) ((uint) num | 7U));
        this.interface29_0.imethod_11(handleIndex);
        this.interface29_0.imethod_11((byte) (handle >> 48));
        this.interface29_0.imethod_11((byte) (handle >> 40));
        this.interface29_0.imethod_11((byte) (handle >> 32));
        this.interface29_0.imethod_11((byte) (handle >> 24));
        this.interface29_0.imethod_11((byte) (handle >> 16));
        this.interface29_0.imethod_11((byte) (handle >> 8));
        this.interface29_0.imethod_11((byte) handle);
      }
      else
      {
        this.interface29_0.imethod_11((byte) ((uint) num | 8U));
        this.interface29_0.imethod_11(handleIndex);
        this.interface29_0.imethod_11((byte) (handle >> 56));
        this.interface29_0.imethod_11((byte) (handle >> 48));
        this.interface29_0.imethod_11((byte) (handle >> 40));
        this.interface29_0.imethod_11((byte) (handle >> 32));
        this.interface29_0.imethod_11((byte) (handle >> 24));
        this.interface29_0.imethod_11((byte) (handle >> 16));
        this.interface29_0.imethod_11((byte) (handle >> 8));
        this.interface29_0.imethod_11((byte) handle);
      }
    }
  }
}
