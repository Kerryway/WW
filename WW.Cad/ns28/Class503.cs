// Decompiled with JetBrains decompiler
// Type: ns28.Class503
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace ns28
{
  internal class Class503
  {
    private uint uint_0;
    private string string_0;
    private uint uint_1;
    private byte[] byte_0;
    private string string_1;
    private byte[] byte_1;
    private string string_2;
    private byte[] byte_2;
    private string string_3;

    public Class503()
    {
      this.uint_0 = 2U;
      this.string_0 = "AppInfoDataList";
      this.uint_1 = 3U;
      this.string_2 = "Wout Ware CadLib DWG. This file is saved by Wout Ware's CadLib component.";
      this.string_1 = "4.0.37.140";
      this.string_3 = "<ProductInformation name =\"CadLib\" build_version=\"" + this.string_1 + "\" registry_version=\"" + this.string_1 + "\" install_id_string=\"WW\" registry_localeID=\"1033\"/>";
      this.byte_0 = new byte[16];
      this.byte_1 = new byte[16];
      this.byte_2 = new byte[16];
    }

    public uint Unknown0
    {
      get
      {
        return this.uint_0;
      }
      set
      {
        this.uint_0 = value;
      }
    }

    public string Name
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }

    public uint Unknown1
    {
      get
      {
        return this.uint_1;
      }
      set
      {
        this.uint_1 = value;
      }
    }

    public byte[] VersionData
    {
      get
      {
        return this.byte_0;
      }
      set
      {
        this.byte_0 = value;
      }
    }

    public string Version
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
      }
    }

    public byte[] CommentData
    {
      get
      {
        return this.byte_1;
      }
      set
      {
        this.byte_1 = value;
      }
    }

    public string Comment
    {
      get
      {
        return this.string_2;
      }
      set
      {
        this.string_2 = value;
      }
    }

    public byte[] ProductData
    {
      get
      {
        return this.byte_2;
      }
      set
      {
        this.byte_2 = value;
      }
    }

    public string Product
    {
      get
      {
        return this.string_3;
      }
      set
      {
        this.string_3 = value;
      }
    }
  }
}
