// Decompiled with JetBrains decompiler
// Type: ns28.Class993
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns43;
using System.IO;
using System.Text;
using WW.Cad.Model;

namespace ns28
{
  internal class Class993
  {
    private DxfModel dxfModel_0;
    private MemoryStream memoryStream_0;
    private Encoding encoding_0;
    private DxfVersion dxfVersion_0;

    public Class993(MemoryStream stream, DxfModel model, Encoding encoding)
    {
      this.memoryStream_0 = stream;
      this.dxfModel_0 = model;
      this.encoding_0 = encoding;
      this.dxfVersion_0 = model.Header.AcadVersion;
    }

    public void Write()
    {
      Interface29 nterface29 = Class724.Create(this.dxfVersion_0, (Stream) this.memoryStream_0, this.encoding_0);
      nterface29.imethod_11(byte.MaxValue);
      nterface29.imethod_11((byte) 119);
      nterface29.imethod_11((byte) 1);
      DwgVersion dwgVersion = Class885.smethod_3(this.dxfModel_0.Header.AcadVersion);
      nterface29.imethod_18((short) dwgVersion);
      nterface29.imethod_18((short) this.dxfModel_0.Header.AcadMaintenanceVersion);
      nterface29.imethod_19(this.dxfModel_0.NumberOfSaves);
      nterface29.imethod_19(-1);
      short num1 = this.dxfModel_0.NumberOfSaves <= (int) short.MaxValue ? (short) 0 : (short) (this.dxfModel_0.NumberOfSaves - (int) short.MaxValue);
      short num2 = (short) (this.dxfModel_0.NumberOfSaves - (int) num1);
      nterface29.imethod_18(num2);
      nterface29.imethod_18(num1);
      nterface29.imethod_19(0);
      nterface29.imethod_18((short) dwgVersion);
      nterface29.imethod_18((short) this.dxfModel_0.Header.AcadMaintenanceVersion);
      nterface29.imethod_18((short) dwgVersion);
      nterface29.imethod_18((short) this.dxfModel_0.Header.AcadMaintenanceVersion);
      nterface29.imethod_18((short) 5);
      nterface29.imethod_18((short) 2195);
      nterface29.imethod_18((short) 5);
      nterface29.imethod_18((short) 2195);
      nterface29.imethod_18((short) 0);
      nterface29.imethod_18((short) 1);
      nterface29.imethod_19(0);
      nterface29.imethod_19(0);
      nterface29.imethod_19(0);
      nterface29.imethod_19(0);
      nterface29.imethod_19(0);
      int days1;
      int milliseconds1;
      Class644.smethod_1(this.dxfModel_0.Header.CreateDateTime, out days1, out milliseconds1);
      nterface29.imethod_19(days1);
      nterface29.imethod_19(milliseconds1);
      int days2;
      int milliseconds2;
      Class644.smethod_1(this.dxfModel_0.Header.UpdateDateTime, out days2, out milliseconds2);
      nterface29.imethod_19(days2);
      nterface29.imethod_19(milliseconds2);
      int num3 = -1;
      if (this.dxfModel_0.Header.HandleSeed <= (ulong) int.MaxValue)
        num3 = (int) this.dxfModel_0.Header.HandleSeed;
      nterface29.imethod_19(num3);
      nterface29.imethod_19(0);
      nterface29.imethod_18((short) 0);
      nterface29.imethod_18((short) ((int) num2 - (int) num1));
      nterface29.imethod_19(0);
      nterface29.imethod_19(0);
      nterface29.imethod_19(0);
      nterface29.imethod_19(this.dxfModel_0.NumberOfSaves);
      nterface29.imethod_19(0);
      nterface29.imethod_19(0);
      nterface29.imethod_19(0);
      nterface29.imethod_19(0);
    }
  }
}
