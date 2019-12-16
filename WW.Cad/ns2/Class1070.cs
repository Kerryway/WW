// Decompiled with JetBrains decompiler
// Type: ns2.Class1070
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.IO;
using WW.Cad.Model;

namespace ns2
{
  internal class Class1070
  {
    private DxfModel dxfModel_0;
    private FileFormat fileFormat_0;
    private DxfVersion dxfVersion_0;

    public Class1070(DxfModel model, FileFormat fileFormat, DxfVersion version)
    {
      this.dxfModel_0 = model;
      this.fileFormat_0 = fileFormat;
      this.dxfVersion_0 = version;
    }

    public DxfModel Model
    {
      get
      {
        return this.dxfModel_0;
      }
    }

    public FileFormat FileFormat
    {
      get
      {
        return this.fileFormat_0;
      }
    }

    public DxfVersion Version
    {
      get
      {
        return this.dxfVersion_0;
      }
    }
  }
}
