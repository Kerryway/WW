// Decompiled with JetBrains decompiler
// Type: WW.Cad.IO.CadReader
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.IO;
using WW.Cad.Base;
using WW.Cad.Model;

namespace WW.Cad.IO
{
  public class CadReader
  {
    private readonly string string_0;
    private bool bool_0;
    private int int_0;
    private DxfMessageCollection dxfMessageCollection_0;

    public event EventHandler<ReadEventArgs> BeforeRead;

    public CadReader(string filename)
    {
      this.string_0 = filename;
    }

    public string Filename
    {
      get
      {
        return this.string_0;
      }
    }

    public bool LoadUnknownObjects
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public DxfMessageCollection Messages
    {
      get
      {
        return this.dxfMessageCollection_0;
      }
    }

    public int DefaultCodePage
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public DxfModel Read()
    {
      string extension = Path.GetExtension(this.string_0);
      if (string.Compare(extension, ".dwg", StringComparison.InvariantCultureIgnoreCase) == 0)
      {
        using (DwgReader dwgReader = new DwgReader(this.string_0) { LoadUnknownObjects = this.bool_0 })
          return dwgReader.Read();
      }
      else if (string.Compare(extension, ".dxf", StringComparison.InvariantCultureIgnoreCase) == 0)
      {
        using (DxfReader dxfReader = new DxfReader(this.string_0) { LoadUnknownObjects = this.bool_0 })
          return dxfReader.Read();
      }
      else
      {
        if (string.Compare(extension, ".zip", StringComparison.InvariantCultureIgnoreCase) != 0 && string.Compare(extension, ".gz", StringComparison.InvariantCultureIgnoreCase) != 0 && string.Compare(extension, ".bz2", StringComparison.InvariantCultureIgnoreCase) != 0)
          throw new ArgumentException("Unknown extension " + extension + ", it must be either .dxf or .dwg.");
        using (DxfReader dxfReader = new DxfReader(this.string_0) { LoadUnknownObjects = this.bool_0 })
          return dxfReader.Read();
      }
    }

    public static DxfModel Read(string filename)
    {
      return CadReader.Read(filename, false);
    }

    public static DxfModel Read(string filename, bool loadUnknownObjects)
    {
      string extension = Path.GetExtension(filename);
      if (string.Compare(extension, ".dwg", StringComparison.InvariantCultureIgnoreCase) == 0)
      {
        using (DwgReader dwgReader = new DwgReader(filename) { LoadUnknownObjects = loadUnknownObjects })
          return dwgReader.Read();
      }
      else if (string.Compare(extension, ".dxf", StringComparison.InvariantCultureIgnoreCase) == 0)
      {
        using (DxfReader dxfReader = new DxfReader(filename) { LoadUnknownObjects = loadUnknownObjects })
          return dxfReader.Read();
      }
      else
      {
        if (string.Compare(extension, ".zip", StringComparison.InvariantCultureIgnoreCase) != 0 && string.Compare(extension, ".gz", StringComparison.InvariantCultureIgnoreCase) != 0 && string.Compare(extension, ".bz2", StringComparison.InvariantCultureIgnoreCase) != 0)
          throw new ArgumentException("Unknown extension " + extension + ", it must be either .dxf or .dwg.");
        using (DxfReader dxfReader = new DxfReader(filename) { LoadUnknownObjects = loadUnknownObjects })
          return dxfReader.Read();
      }
    }

    public static DxfModel Read(string filename, int defaultCodepage)
    {
      string extension = Path.GetExtension(filename);
      DxfModel dxfModel;
      if (string.Compare(extension, ".dwg", StringComparison.InvariantCultureIgnoreCase) == 0)
        dxfModel = DwgReader.Read(filename);
      else if (string.Compare(extension, ".dxf", StringComparison.InvariantCultureIgnoreCase) == 0)
      {
        dxfModel = DxfReader.Read(filename, defaultCodepage);
      }
      else
      {
        if (string.Compare(extension, ".gz", StringComparison.InvariantCultureIgnoreCase) != 0 && string.Compare(extension, ".zip", StringComparison.InvariantCultureIgnoreCase) != 0)
          throw new ArgumentException("Unknown extension " + extension + ", it must be either .dxf or .dwg.");
        dxfModel = DxfReader.Read(filename, defaultCodepage);
      }
      return dxfModel;
    }

    public static DxfModel Read(string filename, out DxfMessageCollection messagesReturn)
    {
      string extension = Path.GetExtension(filename);
      DxfModel dxfModel;
      if (string.Compare(extension, ".dwg", StringComparison.InvariantCultureIgnoreCase) == 0)
        dxfModel = DwgReader.Read(filename, (ProgressEventHandler) null, out messagesReturn);
      else if (string.Compare(extension, ".dxf", StringComparison.InvariantCultureIgnoreCase) == 0)
      {
        dxfModel = DxfReader.Read(filename, (ProgressEventHandler) null, out messagesReturn);
      }
      else
      {
        if (string.Compare(extension, ".gz", StringComparison.InvariantCultureIgnoreCase) != 0 && string.Compare(extension, ".zip", StringComparison.InvariantCultureIgnoreCase) != 0)
          throw new ArgumentException("Unknown extension " + extension + ", it must be either .dxf or .dwg.");
        dxfModel = DxfReader.Read(filename, (ProgressEventHandler) null, out messagesReturn);
      }
      return dxfModel;
    }

    public static bool IsDwgFilenameExtension(string extension)
    {
      return string.Compare(extension, ".dwg", StringComparison.InvariantCultureIgnoreCase) == 0;
    }

    public static bool IsDxfFilenameExtension(string extension)
    {
      return string.Compare(extension, ".dxf", StringComparison.InvariantCultureIgnoreCase) == 0;
    }

    protected virtual void OnBeforeRead(ReadEventArgs e)
    {
      if (this.eventHandler_0 == null)
        return;
      this.eventHandler_0((object) this, e);
    }
  }
}
