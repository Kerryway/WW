// Decompiled with JetBrains decompiler
// Type: WW.Drawing.GdiBitmap
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using ns3;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using WW.IO;

namespace WW.Drawing
{
  public class GdiBitmap : IDisposable, IBitmap
  {
    public static readonly IBitmap InvalidBitmap = (IBitmap) new Class184();
    private readonly Bitmap bitmap_0;
    private int int_0;
    private BitmapData bitmapData_0;
    private unsafe byte* pByte_0;

    public GdiBitmap(Bitmap bitmap)
    {
      this.bitmap_0 = bitmap;
      if (bitmap == null)
        return;
      this.int_0 = bitmap.Width;
    }

    public bool IsValid
    {
      get
      {
        return this.bitmap_0 != null;
      }
    }

    public int Width
    {
      get
      {
        return this.bitmap_0.Width;
      }
    }

    public int Height
    {
      get
      {
        return this.bitmap_0.Height;
      }
    }

    public unsafe ArgbColor GetPixel(int x, int y)
    {
      if (this.bitmapData_0 == null)
        throw new Exception("Bitmap bits are not locked.");
      byte* numPtr = this.pByte_0 + ((y * this.int_0 + x) * 4);
      return new ArgbColor(((int) numPtr[3] << 24) + ((int) numPtr[2] << 16) + ((int) numPtr[1] << 8) + (int) *numPtr);
    }

    public unsafe byte GetAlpha(int x, int y)
    {
      if (this.bitmapData_0 == null)
        throw new Exception("Bitmap bits are not locked.");
      return (this.pByte_0 + ( (y * this.int_0 + x) * 4))[3];
    }

    public unsafe int GetRgb(int x, int y)
    {
      if (this.bitmapData_0 == null)
        throw new Exception("Bitmap bits are not locked.");
      byte* numPtr = this.pByte_0 + ((y * this.int_0 + x) * 4);
      return ((int) numPtr[2] << 16) + ((int) numPtr[1] << 8) + (int) *numPtr;
    }

    public unsafe void LockBits()
    {
      this.bitmapData_0 = this.bitmap_0.LockBits(new Rectangle(0, 0, this.bitmap_0.Width, this.bitmap_0.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
      this.pByte_0 = (byte*) (void*) this.bitmapData_0.Scan0;
    }

    public unsafe void UnlockBits()
    {
      if (this.bitmapData_0 == null)
        return;
      this.bitmap_0.UnlockBits(this.bitmapData_0);
      this.bitmapData_0 = (BitmapData) null;
      this.pByte_0 = (byte*) null;
    }

    public unsafe byte[] GetRgbaBytes()
    {
      byte[] numArray = new byte[this.bitmap_0.Width * this.bitmap_0.Height * 4];
      this.LockBits();
      try
      {
        for (int index1 = 0; index1 < this.bitmap_0.Height; ++index1)
        {
          for (int index2 = 0; index2 < this.bitmap_0.Width; ++index2)
          {
            int index3 = (index1 * this.bitmap_0.Width + index2) * 4;
            byte* numPtr = this.pByte_0 + ((index1 * this.int_0 + index2) * 4);
            numArray[index3] = numPtr[2];
            numArray[index3 + 1] = numPtr[1];
            numArray[index3 + 2] = *numPtr;
            numArray[index3 + 3] = numPtr[3];
          }
        }
      }
      finally
      {
        this.UnlockBits();
      }
      return numArray;
    }

    public Bitmap Image
    {
      get
      {
        return this.bitmap_0;
      }
    }

    public void Dispose()
    {
      this.UnlockBits();
      if (this.bitmap_0 == null)
        return;
      this.bitmap_0.Dispose();
    }

    public static IBitmap LoadBitmap(
      string filename,
      string modelFilename,
      int downloadTimeoutMs)
    {
      if (!filename.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase))
      {
        if (!filename.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase))
        {
          string str = filename;
          if (!System.IO.File.Exists(str) && Path.IsPathRooted(str))
            str = Path.GetFileName(filename);
          if (!Path.IsPathRooted(str) && Path.IsPathRooted(modelFilename))
          {
            string directoryName = Path.GetDirectoryName(modelFilename);
            str = Path.Combine(directoryName, str);
            if (!System.IO.File.Exists(str))
              str = Path.Combine(directoryName, Path.GetFileName(str));
          }
          if (System.IO.File.Exists(str))
          {
            MemoryStream memoryStream = new MemoryStream(System.IO.File.ReadAllBytes(str), false);
            Bitmap bitmap;
            try
            {
              bitmap = (Bitmap) System.Drawing.Image.FromStream((Stream) memoryStream);
            }
            catch (Exception ex)
            {
              return GdiBitmap.InvalidBitmap;
            }
            return (IBitmap) new GdiBitmap(bitmap);
          }
          goto label_15;
        }
      }
      try
      {
        PagedMemoryStream pagedMemoryStream = GdiBitmap.smethod_0(filename);
        if (pagedMemoryStream != null)
          return (IBitmap) new GdiBitmap(new Bitmap((Stream) pagedMemoryStream));
      }
      catch (Exception ex)
      {
      }
label_15:
      return GdiBitmap.InvalidBitmap;
    }

    private static PagedMemoryStream smethod_0(string uri)
    {
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(uri);
      httpWebRequest.UserAgent = "Foo";
      using (HttpWebResponse response = (HttpWebResponse) httpWebRequest.GetResponse())
      {
        if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.MovedPermanently)
        {
          if (response.StatusCode != HttpStatusCode.Found)
            goto label_14;
        }
        if (response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
        {
          using (Stream responseStream = response.GetResponseStream())
          {
            PagedMemoryStream pagedMemoryStream = new PagedMemoryStream();
            byte[] buffer = new byte[4096];
            int count;
            do
            {
              count = responseStream.Read(buffer, 0, buffer.Length);
              pagedMemoryStream.Write(buffer, 0, count);
            }
            while (count != 0);
            pagedMemoryStream.Position = 0L;
            return pagedMemoryStream;
          }
        }
      }
label_14:
      return (PagedMemoryStream) null;
    }
  }
}
