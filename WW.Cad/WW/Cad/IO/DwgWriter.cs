// Decompiled with JetBrains decompiler
// Type: WW.Cad.IO.DwgWriter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns28;
using ns38;
using System;
using System.IO;
using System.Text;
using WW.Cad.Base;
using WW.Cad.Model;
using WW.Cad.Model.Objects.Annotations;
using WW.Text;

namespace WW.Cad.IO
{
  public class DwgWriter
  {
    private bool bool_0 = true;
    private DxfModel dxfModel_0;
    private DxfVersion dxfVersion_0;
    private Stream stream_0;
    private Encoding encoding_0;

    public DwgWriter(Stream stream, DxfModel model)
    {
      if (!stream.CanSeek || !stream.CanWrite)
        throw new ArgumentException("Stream must allow writing and seeking.");
      this.dxfModel_0 = model;
      this.stream_0 = stream;
      this.dxfVersion_0 = model.Header.AcadVersion;
      this.encoding_0 = Encodings.GetEncoding((int) model.Header.DrawingCodePage);
    }

    public bool AutoCloseStream
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

    public static void Write(string filename, DxfModel model)
    {
      DxfMessage[] messages;
      if (!model.Validate(out messages))
        throw new DxfException("Cannot write invalid model, see Messages property for more information. ", messages);
      using (Stream stream = (Stream) File.Create(filename))
        new DwgWriter(stream, model).Write(false);
    }

    public static void Write(Stream stream, DxfModel model)
    {
      new DwgWriter(stream, model).Write(true);
    }

    public void Write()
    {
      this.Write(true);
    }

    public void Write(bool validate)
    {
      Class809.smethod_0(Enum15.const_3);
      DxfMessage[] messages;
      if (validate && !this.dxfModel_0.Validate(out messages))
        throw new DxfException("Cannot write invalid model", messages);
      if (this.dxfModel_0.Header.AcadVersion < DxfVersion.Dxf13 || this.dxfModel_0.Header.AcadVersion > DxfVersion.Dxf27)
        throw new NotSupportedException("Currently DwgWriter only supports writing versions 13, 14, 15, 18, 21, 24 and 27.");
      this.dxfModel_0.method_28(new Class1070(this.dxfModel_0, FileFormat.Dwg, this.dxfVersion_0));
      DxfScale currentAnnotationScale = this.dxfModel_0.Header.CurrentAnnotationScale;
      this.dxfModel_0.Header.CurrentAnnotationScale = (DxfScale) null;
      switch (this.dxfVersion_0)
      {
        case DxfVersion.Dxf13:
          Class745.Write(this.stream_0, this.dxfModel_0);
          break;
        case DxfVersion.Dxf14:
          Class722.Write(this.stream_0, this.dxfModel_0);
          break;
        case DxfVersion.Dxf15:
          Class653.Write(this.stream_0, this.dxfModel_0);
          break;
        case DxfVersion.Dxf18:
          new Class499(this.stream_0, this.dxfModel_0).Write();
          break;
        case DxfVersion.Dxf21:
          Class921.Write(this.stream_0, this.dxfModel_0);
          break;
        case DxfVersion.Dxf24:
          new Class499(this.stream_0, this.dxfModel_0).Write();
          break;
        case DxfVersion.Dxf27:
          new Class500(this.stream_0, this.dxfModel_0).Write();
          break;
      }
      this.dxfModel_0.Header.CurrentAnnotationScale = currentAnnotationScale;
      if (!this.bool_0)
        return;
      this.stream_0.Close();
    }
  }
}
