// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfImage
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System;
using System.IO;
using WW.Drawing;
using WW.IO;
using WW.Pdf.Filter;

namespace WW.Pdf
{
  public class PdfImage : PdfContentStream, IDisposable
  {
    private string string_0;
    private IBitmap ibitmap_0;
    private readonly bool bool_0;
    private readonly PdfImage.ClipRect clipRect_0;

    public PdfImage(string baseName, IBitmap bitmap, bool ownsBitmap, PdfImage.ClipRect clipMask)
    {
      this.ibitmap_0 = bitmap;
      this.bool_0 = ownsBitmap;
      this.clipRect_0 = clipMask;
      this.string_0 = PdfImage.GetPdfName(baseName, clipMask);
      this.AddFilter((IFilter) new FlateFilter());
    }

    public PdfImage(string baseName, IBitmap bitmap, bool ownsBitmap)
      : this(baseName, bitmap, ownsBitmap, new PdfImage.ClipRect(bitmap.Width, bitmap.Height))
    {
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

    public int Width
    {
      get
      {
        return this.clipRect_0.Width;
      }
    }

    public int Height
    {
      get
      {
        return this.clipRect_0.Height;
      }
    }

    public void AddSoftMask(PdfBody body)
    {
      int width = this.Width;
      int height = this.Height;
      PagedMemoryStream pagedMemoryStream = new PagedMemoryStream((long) (width * height));
      bool flag = false;
      this.ibitmap_0.LockBits();
      try
      {
        for (int y = 0; y < height; ++y)
        {
          for (int x = 0; x < width; ++x)
          {
            byte alpha = this.GetAlpha(x, y);
            if (alpha != byte.MaxValue)
              flag = true;
            pagedMemoryStream.WriteByte(alpha);
          }
        }
      }
      finally
      {
        this.ibitmap_0.UnlockBits();
      }
      if (flag)
      {
        PdfIndirectObject pdfIndirectObject = new PdfIndirectObject((IPdfObject) new PdfSoftMaskImage() { Width = this.Width, Height = this.Height, OpacityStream = (Stream) pagedMemoryStream });
        body.IndirectObjects.Add((IPdfIndirectObject) pdfIndirectObject);
        this.Dictionary["SMask"] = (IPdfObject) new PdfReference((IPdfIndirectObject) pdfIndirectObject);
      }
      else
        pagedMemoryStream.Dispose();
    }

    public byte GetAlpha(int x, int y)
    {
      return this.ibitmap_0.GetAlpha(x + this.clipRect_0.X, y + this.clipRect_0.Y);
    }

    public int GetPixel(int x, int y)
    {
      return this.ibitmap_0.GetRgb(x + this.clipRect_0.X, y + this.clipRect_0.Y);
    }

    public void Dispose()
    {
      if (this.ibitmap_0 == null)
        return;
      if (this.bool_0)
        this.ibitmap_0.Dispose();
      this.ibitmap_0 = (IBitmap) null;
    }

    public static string GetPdfName(string baseName, PdfImage.ClipRect clipMask)
    {
      return baseName + "_" + (object) clipMask.X + "_" + (object) clipMask.Y + "_" + (object) clipMask.Width + "_" + (object) clipMask.Height;
    }

    public override void Write(ExtendedPdfOutput output)
    {
      this.Dictionary["Type"] = (IPdfObject) new PdfName("XObject");
      this.Dictionary["Subtype"] = (IPdfObject) new PdfName("Image");
      this.Dictionary["Width"] = (IPdfObject) new PdfInt(this.Width);
      this.Dictionary["Height"] = (IPdfObject) new PdfInt(this.Height);
      this.Dictionary["ColorSpace"] = (IPdfObject) new PdfName("DeviceRGB");
      this.Dictionary["BitsPerComponent"] = (IPdfObject) new PdfInt(8);
      int width = this.Width;
      int height = this.Height;
      byte[] data = new byte[3];
      this.ibitmap_0.LockBits();
      try
      {
        for (int y = 0; y < height; ++y)
        {
          for (int x = 0; x < width; ++x)
          {
            int pixel = this.GetPixel(x, y);
            data[0] = (byte) (pixel >> 16 & (int) byte.MaxValue);
            data[1] = (byte) (pixel >> 8 & (int) byte.MaxValue);
            data[2] = (byte) (pixel & (int) byte.MaxValue);
            this.XOut.Write(data);
          }
        }
      }
      finally
      {
        this.ibitmap_0.UnlockBits();
      }
      base.Write(output);
    }

    public struct ClipRect
    {
      public readonly int X;
      public readonly int Y;
      public readonly int Width;
      public readonly int Height;

      public ClipRect(int x, int y, int width, int height)
      {
        this.X = x;
        this.Y = y;
        this.Width = width;
        this.Height = height;
      }

      public ClipRect(int width, int height)
      {
        this = new PdfImage.ClipRect(0, 0, width, height);
      }
    }
  }
}
