// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfSoftMaskImage
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System.IO;
using WW.Pdf.Filter;

namespace WW.Pdf
{
  public class PdfSoftMaskImage : PdfContentStream
  {
    private Stream stream_0;
    private int int_0;
    private int int_1;

    public PdfSoftMaskImage()
    {
      this.AddFilter((IFilter) new FlateFilter());
    }

    public Stream OpacityStream
    {
      get
      {
        return this.stream_0;
      }
      set
      {
        this.stream_0 = value;
      }
    }

    public int Width
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

    public int Height
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
      }
    }

    public override void Write(ExtendedPdfOutput output)
    {
      this.Dictionary["Type"] = (IPdfObject) new PdfName("XObject");
      this.Dictionary["Subtype"] = (IPdfObject) new PdfName("Image");
      this.Dictionary["Width"] = (IPdfObject) new PdfInt(this.Width);
      this.Dictionary["Height"] = (IPdfObject) new PdfInt(this.Height);
      this.Dictionary["ColorSpace"] = (IPdfObject) new PdfName("DeviceGray");
      this.Dictionary["BitsPerComponent"] = (IPdfObject) new PdfInt(8);
      int width = this.Width;
      int height = this.Height;
      this.stream_0.Position = 0L;
      byte[] data = new byte[1];
      for (int index1 = 0; index1 < height; ++index1)
      {
        for (int index2 = 0; index2 < width; ++index2)
        {
          data[0] = (byte) this.stream_0.ReadByte();
          this.XOut.Write(data);
        }
      }
      base.Write(output);
    }
  }
}
