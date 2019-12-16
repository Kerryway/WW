// Decompiled with JetBrains decompiler
// Type: ns28.Class1033
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
  internal class Class1033
  {
    private static readonly byte[] byte_0 = new byte[16]{ (byte) 141, (byte) 161, (byte) 196, (byte) 184, (byte) 196, (byte) 169, (byte) 248, (byte) 197, (byte) 192, (byte) 220, (byte) 244, (byte) 95, (byte) 231, (byte) 207, (byte) 182, (byte) 138 };
    private static readonly byte[] byte_1 = new byte[16]{ (byte) 114, (byte) 94, (byte) 59, (byte) 71, (byte) 59, (byte) 86, (byte) 7, (byte) 58, (byte) 63, (byte) 35, (byte) 11, (byte) 160, (byte) 24, (byte) 48, (byte) 73, (byte) 117 };
    private Stream stream_0;
    private MemoryStream memoryStream_0;
    private Interface29 interface29_0;
    private DxfModel dxfModel_0;

    public Class1033(Stream stream, DxfModel model)
    {
      this.stream_0 = stream;
      this.dxfModel_0 = model;
      this.memoryStream_0 = new MemoryStream(500);
      this.interface29_0 = Class724.Create(model.Header.AcadVersion, (Stream) this.memoryStream_0, Encodings.GetEncoding((int) model.Header.DrawingCodePage));
    }

    public MemoryStream DataStream
    {
      get
      {
        return this.memoryStream_0;
      }
    }

    public void Write()
    {
      this.method_0();
      this.stream_0.Write(Class1033.byte_0, 0, Class1033.byte_0.Length);
      Stream1 stream1 = new Stream1(this.stream_0, (ushort) 49345);
      Class1045.smethod_9((Stream) stream1, (int) this.memoryStream_0.Length);
      if (this.dxfModel_0.Header.AcadVersion > DxfVersion.Dxf21 && this.dxfModel_0.Header.AcadMaintenanceVersion > 3 || this.dxfModel_0.Header.AcadVersion > DxfVersion.Dxf27)
        Class1045.smethod_9((Stream) stream1, 0);
      byte[] buffer = this.memoryStream_0.GetBuffer();
      stream1.Write(buffer, 0, (int) this.memoryStream_0.Length);
      Class1045.smethod_6(this.stream_0, stream1.Crc);
      this.stream_0.Write(Class1033.byte_1, 0, Class1033.byte_1.Length);
      if (this.dxfModel_0.Header.AcadVersion < DxfVersion.Dxf18)
        return;
      Class1045.smethod_9(this.stream_0, 0);
      Class1045.smethod_9(this.stream_0, 0);
    }

    private void method_0()
    {
      if (this.dxfModel_0.Header.AcadVersion >= DxfVersion.Dxf21)
        this.interface29_0.imethod_0();
      short num = 0;
      foreach (DxfClass dxfClass in (List<DxfClass>) this.dxfModel_0.Classes)
      {
        if ((int) dxfClass.ClassNumber > (int) num)
          num = dxfClass.ClassNumber;
      }
      if (this.dxfModel_0.Header.AcadVersion >= DxfVersion.Dxf18)
      {
        this.interface29_0.imethod_32(num);
        this.interface29_0.imethod_11((byte) 0);
        this.interface29_0.imethod_11((byte) 0);
        this.interface29_0.imethod_14(true);
      }
      foreach (DxfClass dxfClass in (List<DxfClass>) this.dxfModel_0.Classes)
      {
        this.interface29_0.imethod_32(dxfClass.ClassNumber);
        this.interface29_0.imethod_32((short) dxfClass.GetEffectiveProxyFlags(this.dxfModel_0.Header.AcadVersion));
        this.interface29_0.imethod_4(dxfClass.ApplicationName);
        this.interface29_0.imethod_4(dxfClass.CPlusPlusClassName);
        this.interface29_0.imethod_4(dxfClass.DxfName);
        this.interface29_0.imethod_14(dxfClass.WasAZombie);
        this.interface29_0.imethod_32(dxfClass.ItemClassId);
        if (this.dxfModel_0.Header.AcadVersion >= DxfVersion.Dxf18)
        {
          this.interface29_0.imethod_32((short) 1);
          this.interface29_0.imethod_32((short) dxfClass.DwgVersion);
          this.interface29_0.imethod_32(dxfClass.MaintenanceVersion);
          this.interface29_0.imethod_33(0);
          this.interface29_0.imethod_33(0);
        }
      }
      this.interface29_0.Flush();
    }
  }
}
