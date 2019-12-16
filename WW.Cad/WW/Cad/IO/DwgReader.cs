// Decompiled with JetBrains decompiler
// Type: WW.Cad.IO.DwgReader
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns28;
using ns35;
using ns38;
using ns39;
using ns6;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WW.Cad.Base;
using WW.Cad.Model;
using WW.IO;
using WW.Text;

namespace WW.Cad.IO
{
  public class DwgReader : IDisposable
  {
    private bool bool_1 = true;
    private MemoryPageCache memoryPageCache_0 = new MemoryPageCache(65536);
    private Dictionary<int, Class884> dictionary_0 = new Dictionary<int, Class884>(30);
    private List<Class799> list_0 = new List<Class799>();
    private Dictionary<ulong, Class799> dictionary_4 = new Dictionary<ulong, Class799>();
    private readonly DxfMessageCollection dxfMessageCollection_0 = new DxfMessageCollection();
    private Queue<ulong> queue_0 = new Queue<ulong>();
    private string string_0;
    private bool bool_0;
    private DxfModel dxfModel_0;
    private DxfHeader dxfHeader_0;
    private Stream stream_0;
    private Interface30 interface30_0;
    private byte byte_0;
    private byte byte_1;
    private DxfVersion dxfVersion_0;
    private Dictionary<long, Class801> dictionary_1;
    private Dictionary<string, Class617> dictionary_2;
    private Dictionary<string, Class504> dictionary_3;
    private Class374 class374_0;
    private int int_0;

    public event EventHandler<ReadEventArgs> BeforeRead;

    public event ProgressEventHandler Progress;

    public DwgReader(Stream stream)
    {
      if (!stream.CanSeek)
      {
        byte[] buffer = new byte[stream.Length];
        stream.Read(buffer, 0, buffer.Length);
        stream = (Stream) new MemoryStream(buffer);
        stream.Position = 0L;
      }
      this.stream_0 = stream;
    }

    public DwgReader(string filename)
    {
      this.string_0 = filename;
      this.stream_0 = StreamUtil.OpenReadOnlyStream(filename);
    }

    public bool CloseStreamAfterReading
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
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

    public static DxfModel Read(string filename)
    {
      return DwgReader.Read(filename, (ProgressEventHandler) null);
    }

    public static DxfModel Read(string filename, ProgressEventHandler progressEventHandler)
    {
      using (DwgReader dwgReader = new DwgReader(filename))
      {
        if (progressEventHandler != null)
          dwgReader.Progress += progressEventHandler;
        return dwgReader.Read();
      }
    }

    public static DxfModel Read(
      string filename,
      ProgressEventHandler progressEventHandler,
      out DxfMessageCollection messageReturn)
    {
      using (DwgReader dwgReader = new DwgReader(filename))
      {
        if (progressEventHandler != null)
          dwgReader.Progress += progressEventHandler;
        DxfModel dxfModel = dwgReader.Read();
        messageReturn = dwgReader.Messages;
        return dxfModel;
      }
    }

    public static DxfModel Read(Stream stream)
    {
      return DwgReader.Read(stream, (ProgressEventHandler) null);
    }

    public static DxfModel Read(Stream stream, ProgressEventHandler progressEventHandler)
    {
      using (DwgReader dwgReader = new DwgReader(stream))
      {
        if (progressEventHandler != null)
          dwgReader.Progress += progressEventHandler;
        return dwgReader.Read();
      }
    }

    public static DxfModel Read(
      Stream stream,
      ProgressEventHandler progressEventHandler,
      out DxfMessageCollection messageReturn)
    {
      using (DwgReader dwgReader = new DwgReader(stream))
      {
        if (progressEventHandler != null)
          dwgReader.Progress += progressEventHandler;
        DxfModel dxfModel = dwgReader.Read();
        messageReturn = dwgReader.Messages;
        return dxfModel;
      }
    }

    public DxfModel Read()
    {
      this.dxfModel_0 = new DxfModel(DxfVersion.Dxf12, false);
      this.dxfModel_0.Filename = this.string_0;
      Class376 class376 = new Class376(this.dxfModel_0, this.dxfMessageCollection_0);
      class376.LoadUnknownObjects = this.bool_0;
      this.class374_0 = (Class374) class376;
      this.dxfHeader_0 = this.dxfModel_0.Header;
      this.Read(this.dxfModel_0);
      return this.dxfModel_0;
    }

    public void Read(DxfModel model)
    {
      Class809.smethod_0(Enum15.const_3);
      this.dxfModel_0 = model;
      this.OnBeforeRead(new ReadEventArgs(model));
      this.dxfHeader_0 = model.Header;
      this.method_11();
      this.method_2();
      this.method_4();
      this.method_1();
      this.method_5();
      this.method_26();
      this.method_29();
      this.method_30();
      this.method_31();
      this.method_32();
      this.method_33();
      this.method_0();
      this.method_35();
      this.class374_0.ResolveReferences();
      this.class374_0.method_19();
      this.class374_0.method_13();
      this.class374_0.method_9();
      this.OnProgress(new ProgressEventArgs(1f));
    }

    private void method_0()
    {
      if (this.dxfVersion_0 < DxfVersion.Dxf18)
        return;
      Interface30 nterface30 = this.method_7("AcDb:AuxHeader", -1, false);
      long position = nterface30.Stream.Position;
      if (nterface30 != null)
        Class994.Read(Class889.Create(nterface30.Stream, this.dxfVersion_0, nterface30.Encoding));
      DwgReader.smethod_4(nterface30.Stream, position);
    }

    private void method_1()
    {
      Interface30 bitStream = this.method_6();
      long position = bitStream.Stream.Position;
      new Class887(this, bitStream, this.class374_0).method_0();
      DwgReader.smethod_4(bitStream.Stream, position);
    }

    private void method_2()
    {
      if (this.dxfVersion_0 < DxfVersion.Dxf18 || this.dxfVersion_0 > DxfVersion.Dxf27)
        return;
      Interface30 nterface30 = this.method_7("AcDb:SummaryInfo", -1, false);
      if (nterface30 == null)
        return;
      Class889 class889 = Class889.Create(nterface30.Stream, this.dxfVersion_0, nterface30.Encoding);
      long position = nterface30.Stream.Position;
      this.dxfModel_0.SummaryInfo.Title = class889.vmethod_16();
      this.dxfModel_0.SummaryInfo.Subject = class889.vmethod_16();
      this.dxfModel_0.SummaryInfo.Author = class889.vmethod_16();
      this.dxfModel_0.SummaryInfo.Keywords = class889.vmethod_16();
      this.dxfModel_0.SummaryInfo.Comments = class889.vmethod_16();
      this.dxfModel_0.SummaryInfo.LastSavedBy = class889.vmethod_16();
      this.dxfModel_0.SummaryInfo.RevisionNumber = class889.vmethod_16();
      class889.vmethod_16();
      class889.vmethod_24();
      this.dxfModel_0.SummaryInfo.CreationDateTime = class889.vmethod_26();
      this.dxfModel_0.SummaryInfo.ModifiedDateTime = class889.vmethod_26();
      ushort num = class889.vmethod_6();
      this.dxfModel_0.SummaryInfo.Properties.Clear();
      for (int index = 0; index < (int) num; ++index)
        this.dxfModel_0.SummaryInfo.Properties.Add(new SummaryInfo.Property(class889.vmethod_16(), class889.vmethod_16()));
      class889.vmethod_8();
      class889.vmethod_8();
      DwgReader.smethod_4(nterface30.Stream, position);
    }

    private void method_3()
    {
      if (this.dxfVersion_0 < DxfVersion.Dxf18)
        return;
      Interface30 nterface30 = this.method_7("AcDb:AppInfo", -1, false);
      if (nterface30 == null)
        return;
      long position = nterface30.Stream.Position;
      switch ((DwgVersion) this.byte_0)
      {
        case DwgVersion.Dwg1018Beta:
        case DwgVersion.Dwg1018:
          DwgReader.smethod_0(Class889.Create(nterface30.Stream, this.dxfVersion_0, nterface30.Encoding));
          break;
        case DwgVersion.Dwg1021Beta:
        case DwgVersion.Dwg1021:
          DwgReader.smethod_1(Class889.Create(nterface30.Stream, DxfVersion.Dxf21, Encoding.Unicode));
          break;
        case DwgVersion.Dwg1024Beta:
        case DwgVersion.Dwg1024:
        case DwgVersion.Dwg1027Beta:
        case DwgVersion.Dwg1027:
        case DwgVersion.Dwg1032:
          DwgReader.smethod_1(Class889.Create(nterface30.Stream, DxfVersion.Dxf24, Encoding.Unicode));
          break;
      }
      DwgReader.smethod_4(nterface30.Stream, position);
    }

    private static void smethod_0(Class889 byteStream)
    {
      byteStream.vmethod_16();
      int num = (int) byteStream.vmethod_10();
      byteStream.vmethod_16();
      byteStream.vmethod_16();
      byteStream.vmethod_16();
    }

    private static void smethod_1(Class889 byteStream)
    {
      int num1 = (int) byteStream.vmethod_10();
      byteStream.vmethod_16();
      int num2 = (int) byteStream.vmethod_10();
      byteStream.vmethod_3(16);
      byteStream.vmethod_16();
      byteStream.vmethod_3(16);
      byteStream.vmethod_16();
      byteStream.vmethod_3(16);
      byteStream.vmethod_16();
    }

    private void method_4()
    {
      if (this.dxfVersion_0 != DxfVersion.Dxf18)
        return;
      Interface30 nterface30 = this.method_7("AcDb:FileDepList", -1, false);
      if (nterface30 == null)
        return;
      long position = nterface30.Stream.Position;
      Class889 class889 = Class889.Create(nterface30.Stream, this.dxfVersion_0, nterface30.Encoding);
      int num1 = class889.vmethod_8();
      for (int index = 0; index < num1; ++index)
        class889.vmethod_21();
      int num2 = class889.vmethod_8();
      for (int index = 0; index < num2; ++index)
      {
        class889.vmethod_21();
        class889.vmethod_21();
        class889.vmethod_21();
        class889.vmethod_21();
        class889.vmethod_8();
        class889.vmethod_8();
        class889.vmethod_8();
        int num3 = (int) class889.vmethod_4();
        class889.vmethod_8();
      }
      DwgReader.smethod_4(nterface30.Stream, position);
    }

    private void method_5()
    {
      this.interface30_0.StreamPosition = (long) this.int_0;
      long position = this.interface30_0.Stream.Position;
      this.interface30_0.imethod_19(16);
      this.interface30_0.imethod_43();
      int num = (int) this.interface30_0.imethod_18();
      DwgReader.smethod_4(this.interface30_0.Stream, position);
    }

    private Interface30 method_6()
    {
      return this.method_7("AcDb:Header", 0, false);
    }

    private Interface30 method_7(
      string sectionName,
      int sectionIndex,
      bool enableLogging)
    {
      Interface30 nterface30 = (Interface30) null;
      if (this.class374_0.Version == DxfVersion.Dxf21)
      {
        Stream stream = this.method_9(sectionName, sectionIndex, enableLogging);
        if (stream != null)
        {
          nterface30 = Class444.Create(this.dxfVersion_0, this, stream, enableLogging);
          nterface30.Encoding = Encoding.Unicode;
        }
      }
      else if (this.class374_0.Version != DxfVersion.Dxf18 && this.class374_0.Version < DxfVersion.Dxf24)
      {
        nterface30 = this.interface30_0;
        if (sectionIndex >= 0)
        {
          Class884 class884;
          if (this.dictionary_0.TryGetValue(sectionIndex, out class884))
          {
            this.interface30_0.StreamPosition = (long) class884.Position;
          }
          else
          {
            this.interface30_0.StreamPosition = 0L;
            nterface30 = (Interface30) null;
          }
        }
        else
          this.interface30_0.StreamPosition = 0L;
      }
      else
      {
        Stream stream = this.method_9(sectionName, sectionIndex, enableLogging);
        if (stream != null)
        {
          nterface30 = Class444.Create(this.dxfVersion_0, this, stream, enableLogging);
          nterface30.Encoding = this.interface30_0.Encoding;
        }
      }
      return nterface30;
    }

    private Class889 method_8(string sectionName, int sectionIndex, bool enableLogging)
    {
      Class889 class889 = (Class889) null;
      Stream stream = this.method_9(sectionName, sectionIndex, enableLogging);
      if (stream != null)
        class889 = Class889.Create(stream, this.class374_0.Version, this.interface30_0.Encoding);
      return class889;
    }

    private Stream method_9(string sectionName, int sectionIndex, bool enableLogging)
    {
      Stream stream = (Stream) null;
      if (this.class374_0.Version == DxfVersion.Dxf21)
      {
        Class504 class504 = (Class504) null;
        if (this.dictionary_3.TryGetValue(sectionName, out class504))
        {
          ulong length = 0;
          foreach (Class443 page in class504.Pages)
            length += page.DecompressedSize;
          byte[] buffer = new byte[length];
          long num1 = 0;
          Class997 class997 = new Class997();
          foreach (Class443 page in class504.Pages)
          {
            if (page.ContainsOnlyZeroes)
            {
              for (int index = 0; index < (int) page.DecompressedSize; ++index)
                buffer[(IntPtr) num1++] = (byte) 0;
            }
            else
            {
              Class801 class801 = this.dictionary_1[Math.Abs(page.Id)];
              this.interface30_0.StreamPosition = class801.Position + 1152L;
              byte[] numArray = new byte[class801.Size];
              this.interface30_0.Stream.Read(numArray, 0, (int) class801.Size);
              ulong num2 = (ulong) ((long) page.CompressedSize + 7L & 4294967288L);
              if (class504.Encoding == 4UL)
              {
                int rsBlockCount = (int) ((ulong) ((long) num2 + 251L - 1L) / 251UL);
                byte[] outputBuffer = new byte[rsBlockCount * 251];
                this.method_20(numArray, outputBuffer, rsBlockCount, 251);
                numArray = outputBuffer;
              }
              if ((long) page.CompressedSize != (long) page.DecompressedSize)
              {
                byte[] outputBuffer = new byte[page.DecompressedSize];
                class997.method_0(numArray, 0U, (uint) page.CompressedSize, outputBuffer, (uint) page.DecompressedSize);
                numArray = outputBuffer;
              }
              for (int index = 0; index < (int) page.DecompressedSize; ++index)
                buffer[(IntPtr) num1++] = numArray[index];
            }
          }
          stream = (Stream) new MemoryStream(buffer, 0, buffer.Length, false, true);
        }
      }
      else if (this.class374_0.Version != DxfVersion.Dxf18 && this.class374_0.Version < DxfVersion.Dxf24)
      {
        stream = this.interface30_0.Stream;
        if (sectionIndex >= 0)
        {
          Class884 class884;
          if (this.dictionary_0.TryGetValue(sectionIndex, out class884))
          {
            this.interface30_0.StreamPosition = (long) class884.Position;
          }
          else
          {
            this.interface30_0.StreamPosition = 0L;
            stream = (Stream) null;
          }
        }
        else
          this.interface30_0.StreamPosition = 0L;
      }
      else
      {
        Class617 class617 = (Class617) null;
        if (this.dictionary_2.TryGetValue(sectionName, out class617))
        {
          MemoryStream memoryStream = new MemoryStream(class617.MaxDecompressedPageSize * class617.Pages.Count);
          Class889 class889 = Class889.Create(this.interface30_0.Stream, this.dxfVersion_0, this.interface30_0.Encoding);
          foreach (Class616 page in class617.Pages)
          {
            if (page.ContainsOnlyZeroes)
            {
              for (int index = 0; index < page.DecompressedSize; ++index)
                memoryStream.WriteByte((byte) 0);
            }
            else
            {
              this.interface30_0.StreamPosition = page.StreamOffset;
              this.method_10(page);
              if (class617.Compressed == 2)
              {
                Class956.smethod_2(this.interface30_0.Stream, (Stream) memoryStream);
                int count = page.PageSize - 32 - page.CompressedSize;
                if (count > 0)
                  class889.vmethod_3(count);
              }
              else if (class617.Compressed == 1)
              {
                byte[] buffer = new byte[page.CompressedSize];
                this.interface30_0.Stream.Read(buffer, 0, page.CompressedSize);
                memoryStream.Write(buffer, 0, page.CompressedSize);
              }
            }
          }
          memoryStream.Position = 0L;
          stream = (Stream) memoryStream;
        }
      }
      return stream;
    }

    private void method_10(Class616 page)
    {
      int num1 = 1097093995 ^ (int) this.interface30_0.StreamPosition;
      this.interface30_0.imethod_43();
      this.interface30_0.imethod_43();
      int num2 = this.interface30_0.imethod_43() ^ num1;
      page.CompressedSize = num2;
      int num3 = this.interface30_0.imethod_43() ^ num1;
      page.PageSize = num3;
      int num4 = this.interface30_0.imethod_43() ^ num1;
      int num5 = this.interface30_0.imethod_43() ^ num1;
      page.StartOffset = (ulong) (num5 + num4);
      page.HeaderChecksum = (uint) (this.interface30_0.imethod_43() ^ num1);
      page.DataChecksum = (uint) (this.interface30_0.imethod_43() ^ num1);
    }

    protected virtual void OnBeforeRead(ReadEventArgs e)
    {
      if (this.eventHandler_0 == null)
        return;
      this.eventHandler_0((object) this, e);
    }

    protected virtual void OnProgress(ProgressEventArgs e)
    {
      if (this.progressEventHandler_0 == null)
        return;
      this.progressEventHandler_0((object) this, e);
    }

    public MemoryPageCache MemoryPageCache
    {
      get
      {
        return this.memoryPageCache_0;
      }
    }

    internal Queue<ulong> OwnedObjectHandles
    {
      get
      {
        return this.queue_0;
      }
    }

    private void method_11()
    {
      byte[] numArray = new byte[6];
      this.stream_0.Read(numArray, 0, 6);
      this.dxfModel_0.Header.method_4(Encodings.Ascii.GetString(numArray, 0, 6), false);
      this.dxfVersion_0 = this.dxfModel_0.Header.AcadVersion;
      this.interface30_0 = Class444.Create(this.dxfVersion_0, this, this.stream_0, false);
      this.class374_0.method_0(this.dxfVersion_0);
      if (this.dxfVersion_0 < DxfVersion.Dxf13)
        throw new NotSupportedException("Versions older than version 13 are not supported.");
      if (this.dxfVersion_0 < DxfVersion.Dxf18)
        this.method_12();
      else if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.method_13();
      else if (this.dxfVersion_0 < DxfVersion.Dxf24)
      {
        this.method_17(this.method_15());
      }
      else
      {
        if (this.dxfVersion_0 < DxfVersion.Dxf24 || this.dxfVersion_0 > DxfVersion.Dxf27)
          throw new NotSupportedException("Versions newer than version 2013 are not supported.");
        this.method_13();
      }
    }

    private void method_12()
    {
      this.interface30_0.imethod_19(7);
      this.int_0 = this.interface30_0.imethod_43();
      this.interface30_0.imethod_19(2);
      this.dxfModel_0.Header.DrawingCodePage = Class952.GetDrawingCodePage((int) this.interface30_0.imethod_45());
      this.interface30_0.Encoding = Encodings.GetEncoding((int) this.dxfModel_0.Header.DrawingCodePage);
      int num1 = this.interface30_0.imethod_43();
      for (int index = 0; index < num1; ++index)
      {
        Class884 class884 = new Class884();
        class884.Index = (int) this.interface30_0.imethod_18();
        class884.Position = this.interface30_0.imethod_43();
        class884.Size = this.interface30_0.imethod_43();
        this.dictionary_0.Add(class884.Index, class884);
      }
      int num2 = (int) this.interface30_0.imethod_27();
      this.class374_0.IsVersion13c3OrLater = this.dictionary_0.ContainsKey(3);
    }

    private void method_13()
    {
      long position = this.interface30_0.Stream.Position;
      this.interface30_0.imethod_52(5);
      this.dxfModel_0.Header.AcadMaintenanceVersion = (int) this.interface30_0.imethod_18();
      this.interface30_0.imethod_52(1);
      this.int_0 = this.interface30_0.imethod_43();
      this.byte_0 = this.interface30_0.imethod_18();
      this.byte_1 = this.interface30_0.imethod_18();
      this.dxfModel_0.Header.DrawingCodePage = Class952.GetDrawingCodePage((int) this.interface30_0.imethod_45());
      this.interface30_0.Encoding = Encodings.GetEncoding((int) this.dxfModel_0.Header.DrawingCodePage);
      this.interface30_0.imethod_52(3);
      this.interface30_0.imethod_43();
      this.interface30_0.imethod_43();
      this.interface30_0.imethod_43();
      this.interface30_0.imethod_43();
      this.interface30_0.imethod_43();
      this.interface30_0.imethod_43();
      this.interface30_0.imethod_52(80);
      Stream2 stream2 = DwgReader.smethod_2(this.interface30_0.imethod_19(108));
      this.interface30_0.imethod_19(20);
      ulong sectionPageMapAddress;
      uint sectionMapId;
      ulong secondHeaderDataAddress;
      DwgReader.smethod_3(Class889.Create((Stream) stream2, this.dxfVersion_0, this.interface30_0.Encoding), out sectionPageMapAddress, out sectionMapId, out secondHeaderDataAddress);
      DwgReader.smethod_4(this.interface30_0.Stream, position);
      this.method_14(secondHeaderDataAddress);
      this.method_22(sectionPageMapAddress);
      this.method_25(sectionMapId);
    }

    private static Stream2 smethod_2(byte[] data)
    {
      int num1 = 1;
      for (int index = 0; index < 108; ++index)
      {
        num1 = num1 * 214013 + 2531011;
        byte num2 = (byte) (num1 >> 16);
        data[index] = (byte) ((uint) data[index] ^ (uint) num2);
      }
      return new Stream2((Stream) new MemoryStream(data), 0U);
    }

    private void method_14(ulong secondHeaderDataAddress)
    {
      if ((long) secondHeaderDataAddress + 108L > this.interface30_0.Stream.Length)
        throw new Exception("Illegal second header data address in DWG file.");
      this.interface30_0.imethod_4(8L * (long) secondHeaderDataAddress);
      ulong sectionPageMapAddress;
      uint sectionMapId;
      DwgReader.smethod_3(Class889.Create((Stream) DwgReader.smethod_2(this.interface30_0.imethod_19(108)), this.dxfVersion_0, this.interface30_0.Encoding), out sectionPageMapAddress, out sectionMapId, out secondHeaderDataAddress);
    }

    private static void smethod_3(
      Class889 headerDataStream,
      out ulong sectionPageMapAddress,
      out uint sectionMapId,
      out ulong secondHeaderDataAddress)
    {
      headerDataStream.vmethod_23(Class1045.encoding_0, 12);
      headerDataStream.vmethod_8();
      headerDataStream.vmethod_8();
      headerDataStream.vmethod_8();
      headerDataStream.vmethod_8();
      headerDataStream.vmethod_8();
      headerDataStream.vmethod_8();
      headerDataStream.vmethod_8();
      headerDataStream.vmethod_8();
      long num1 = (long) headerDataStream.vmethod_14();
      secondHeaderDataAddress = headerDataStream.vmethod_14();
      int num2 = (int) headerDataStream.vmethod_10();
      int num3 = (int) headerDataStream.vmethod_10();
      headerDataStream.vmethod_8();
      headerDataStream.vmethod_8();
      headerDataStream.vmethod_8();
      int num4 = (int) headerDataStream.vmethod_10();
      sectionPageMapAddress = headerDataStream.vmethod_14() + 256UL;
      sectionMapId = headerDataStream.vmethod_10();
      int num5 = (int) headerDataStream.vmethod_10();
      int num6 = (int) headerDataStream.vmethod_10();
      int num7 = (int) headerDataStream.vmethod_10();
    }

    private Class954 method_15()
    {
      this.interface30_0.imethod_52(5);
      this.dxfModel_0.Header.AcadMaintenanceVersion = (int) this.interface30_0.imethod_18();
      int num = (int) this.interface30_0.imethod_18();
      this.int_0 = this.interface30_0.imethod_43();
      this.byte_0 = this.interface30_0.imethod_18();
      this.byte_1 = this.interface30_0.imethod_18();
      this.dxfModel_0.Header.DrawingCodePage = Class952.GetDrawingCodePage((int) this.interface30_0.imethod_45());
      this.interface30_0.Encoding = Encodings.GetEncoding((int) this.dxfModel_0.Header.DrawingCodePage);
      this.interface30_0.imethod_52(3);
      this.interface30_0.imethod_43();
      this.interface30_0.imethod_43();
      this.interface30_0.imethod_52(4);
      this.interface30_0.imethod_52(4);
      this.interface30_0.imethod_52(4);
      this.interface30_0.imethod_52(4);
      this.interface30_0.imethod_52(80);
      return this.method_16();
    }

    private Class954 method_16()
    {
      byte[] inputBuffer = this.interface30_0.imethod_19(1024);
      byte[] numArray1 = new byte[717];
      this.method_20(inputBuffer, numArray1, 3, 239);
      int int32 = LittleEndianBitConverter.ToInt32(numArray1, 24);
      LittleEndianBitConverter.ToInt32(numArray1, 28);
      Class997 class997 = new Class997();
      byte[] numArray2 = new byte[272];
      class997.method_0(numArray1, 32U, (uint) int32, numArray2, 272U);
      Class889 class889 = Class889.Create((Stream) new MemoryStream(numArray2), this.dxfVersion_0, Encoding.Unicode);
      return new Class954() { HeaderSize = class889.vmethod_14(), FileSize = class889.vmethod_14(), PagesMapCrcCompressed = class889.vmethod_14(), PagesMapDataRepeatCount = class889.vmethod_14(), PagesMapCrcSeed = class889.vmethod_14(), PagesMap2Offset = class889.vmethod_14(), PagesMap2Id = class889.vmethod_14(), PagesMapOffset = class889.vmethod_14(), PagesMapId = class889.vmethod_14(), Header2Offset = class889.vmethod_14(), PagesMapSizeCompressed = class889.vmethod_14(), PagesMapSizeDecompressed = class889.vmethod_14(), PageCount = class889.vmethod_14(), PagesMaxId = class889.vmethod_14(), Unknown1 = class889.vmethod_14(), Unknown2 = class889.vmethod_14(), PagesMapCrcDecompressed = class889.vmethod_14(), Unknown3 = class889.vmethod_14(), Unknown4 = class889.vmethod_14(), Unknown5 = class889.vmethod_14(), SectionCount = class889.vmethod_14(), SectionsMapCrcDecompressed = class889.vmethod_14(), SectionsMapSizeCompressed = class889.vmethod_14(), SectionsMap2Id = class889.vmethod_14(), SectionsMapId = class889.vmethod_14(), SectionsMapSizeDecompressed = class889.vmethod_14(), SectionsMapCrcCompressed = class889.vmethod_14(), SectionsMapDataRepeatCount = class889.vmethod_14(), SectionsMapCrcSeed = class889.vmethod_14(), StreamVersion = class889.vmethod_14(), CrcSeed = class889.vmethod_14(), CrcSeedEncoded = class889.vmethod_14(), RandomSeed = class889.vmethod_14(), HeaderCrc = class889.vmethod_14() };
    }

    private void method_17(Class954 fileHeader)
    {
      this.method_18((long) fileHeader.PagesMapDataRepeatCount, (long) fileHeader.PagesMapOffset, (long) fileHeader.PagesMapSizeCompressed, (long) fileHeader.PagesMapSizeDecompressed);
      this.method_19(this.dictionary_1[(long) fileHeader.SectionsMapId].Position, (long) fileHeader.SectionsMapSizeCompressed, (long) fileHeader.SectionsMapSizeDecompressed, (long) fileHeader.SectionsMapDataRepeatCount, 239);
    }

    private void method_18(
      long pagesMapFactor,
      long pagesMapOffset,
      long pagesMapCompressedSize,
      long pagesMapDecompressedSize)
    {
      Class889 class889 = Class889.Create((Stream) new MemoryStream(this.method_21(pagesMapOffset, pagesMapCompressedSize, pagesMapDecompressedSize, pagesMapFactor, 239, this.interface30_0.Stream)), this.dxfVersion_0, Encoding.Unicode);
      long position = 0;
      this.dictionary_1 = new Dictionary<long, Class801>();
      while (class889.Position < class889.Length)
      {
        long size = class889.vmethod_12();
        long num = Math.Abs(class889.vmethod_12());
        this.dictionary_1.Add(num, new Class801(num, position, size));
        position += size;
      }
    }

    private void method_19(
      long sectionsMapOffset,
      long sectionsMapCompressedSize,
      long sectionsMapDecompressedSize,
      long sectionsMapFactor,
      int reedSolomonBlockDataLength)
    {
      this.dictionary_3 = new Dictionary<string, Class504>(15);
      Class889 class889 = Class889.Create((Stream) new MemoryStream(this.method_21(sectionsMapOffset, sectionsMapCompressedSize, sectionsMapDecompressedSize, sectionsMapFactor, reedSolomonBlockDataLength, this.interface30_0.Stream)), this.dxfVersion_0, Encoding.Unicode);
      while (class889.Position < class889.Length)
      {
        Class504 class504 = new Class504();
        class504.DataSize = class889.vmethod_14();
        class504.MaxDecompressedPageSize = class889.vmethod_14();
        class504.Encrypted = class889.vmethod_14();
        class504.HashCode = class889.vmethod_14();
        int lengthInBytes = (int) class889.vmethod_12();
        class504.Unknown = class889.vmethod_14();
        class504.Encoding = class889.vmethod_14();
        class504.PageCount = class889.vmethod_14();
        if (lengthInBytes > 0)
          class504.Name = class889.vmethod_17(lengthInBytes);
        ulong num1 = 0;
        for (int index = 0; index < (int) class504.PageCount; ++index)
        {
          Class443 class443_1 = new Class443();
          class443_1.DataOffset = class889.vmethod_14();
          class443_1.Length = class889.vmethod_12();
          class443_1.Id = class889.vmethod_12();
          class443_1.DecompressedSize = class889.vmethod_14();
          class443_1.CompressedSize = class889.vmethod_14();
          class443_1.CheckSum = class889.vmethod_14();
          class443_1.Crc = class889.vmethod_14();
          if (num1 < class443_1.DataOffset)
          {
            ulong num2 = class443_1.DataOffset - num1;
            Class443 class443_2 = new Class443();
            class443_2.ContainsOnlyZeroes = true;
            class443_2.DataOffset = num1;
            class443_2.CompressedSize = 0UL;
            class443_2.DecompressedSize = num2;
            class443_2.PageSize = num2;
            Class443 class443_3 = class443_2;
            class504.Pages.Add(class443_3);
          }
          class504.Pages.Add(class443_1);
          num1 = class443_1.DataOffset + class443_1.DecompressedSize;
        }
        if (lengthInBytes > 0)
          this.dictionary_3.Add(class504.Name, class504);
      }
    }

    private void method_20(
      byte[] inputBuffer,
      byte[] outputBuffer,
      int rsBlockCount,
      int rsBlockDataLength)
    {
      int index1 = 0;
      int num1 = 0;
      int length = outputBuffer.Length;
      for (int index2 = 0; index2 < rsBlockCount; ++index2)
      {
        int index3 = num1;
        if (num1 < inputBuffer.Length)
        {
          int num2 = Math.Min(length, rsBlockDataLength);
          length -= num2;
          int num3 = index1 + num2;
          while (index1 < num3)
          {
            outputBuffer[index1] = inputBuffer[index3];
            ++index1;
            index3 += rsBlockCount;
          }
        }
        ++num1;
      }
    }

    private byte[] method_21(
      long offset,
      long compressedSize,
      long decompressedSize,
      long dataRepeatCount,
      int reedSolomonBlockDataLength,
      Stream stream)
    {
      Class997 class997 = new Class997();
      long num1 = decompressedSize;
      uint num2 = (uint) ((compressedSize + 7L & 4294967288L) * dataRepeatCount);
      int rsBlockCount = (int) ((long) num2 + (long) reedSolomonBlockDataLength - 1L) / reedSolomonBlockDataLength;
      int count = rsBlockCount * (int) byte.MaxValue;
      byte[] numArray1 = new byte[count];
      stream.Position = 1152L + offset;
      stream.Read(numArray1, 0, count);
      byte[] numArray2 = new byte[(IntPtr) num2];
      this.method_20(numArray1, numArray2, rsBlockCount, reedSolomonBlockDataLength);
      byte[] outputBuffer = new byte[decompressedSize];
      class997.method_0(numArray2, 0U, (uint) compressedSize, outputBuffer, (uint) num1);
      return outputBuffer;
    }

    private void method_22(ulong sectionMapAddress)
    {
      this.interface30_0.StreamPosition = (long) sectionMapAddress;
      this.method_24(Class889.Create(Class956.smethod_0(this.interface30_0.Stream, (long) this.method_23()), this.dxfVersion_0, this.interface30_0.Encoding));
    }

    private uint method_23()
    {
      this.interface30_0.imethod_43();
      uint num = (uint) this.interface30_0.imethod_43();
      this.interface30_0.imethod_43();
      this.interface30_0.imethod_43();
      this.interface30_0.imethod_43();
      return num;
    }

    private void method_24(Class889 sectionPageMapStream)
    {
      int num = 256;
      while (sectionPageMapStream.Position < sectionPageMapStream.Length)
      {
        Class884 class884 = new Class884();
        class884.Index = sectionPageMapStream.vmethod_8();
        class884.Size = sectionPageMapStream.vmethod_8();
        if (class884.Index >= 0)
        {
          class884.Position = num;
          this.dictionary_0.Add(class884.Index, class884);
        }
        else
        {
          sectionPageMapStream.vmethod_8();
          sectionPageMapStream.vmethod_8();
          sectionPageMapStream.vmethod_8();
          sectionPageMapStream.vmethod_8();
        }
        num += class884.Size;
      }
    }

    private void method_25(uint sectionInfoId)
    {
      this.dictionary_2 = new Dictionary<string, Class617>(15);
      this.interface30_0.StreamPosition = (long) this.dictionary_0[(int) sectionInfoId].Position;
      Class889 class889 = Class889.Create(Class956.smethod_0(this.interface30_0.Stream, (long) this.method_23()), this.dxfVersion_0, this.interface30_0.Encoding);
      int num1 = class889.vmethod_8();
      class889.vmethod_8();
      class889.vmethod_8();
      class889.vmethod_8();
      class889.vmethod_8();
      for (int index1 = 0; index1 < num1; ++index1)
      {
        Class617 class617 = new Class617();
        class617.SectionSize = class889.vmethod_14();
        class617.PageCount = class889.vmethod_8();
        class617.MaxDecompressedPageSize = class889.vmethod_8();
        class889.vmethod_8();
        class617.Compressed = class889.vmethod_8();
        class617.SectionId = class889.vmethod_8();
        class617.Encrypted = class889.vmethod_8();
        class617.Name = class889.vmethod_23(Class1045.encoding_0, 64);
        ulong num2 = 0;
        for (int index2 = 0; index2 < class617.PageCount; ++index2)
        {
          Class616 class616_1 = new Class616();
          class616_1.PageNumber = class889.vmethod_8();
          class616_1.CompressedSize = class889.vmethod_8();
          class616_1.StartOffset = class889.vmethod_14();
          class616_1.DecompressedSize = class617.MaxDecompressedPageSize;
          Class616 class616_2 = class616_1;
          class616_2.StreamOffset = (long) this.dictionary_0[class616_2.PageNumber].Position;
          for (; num2 < class616_2.StartOffset; num2 += (ulong) class617.MaxDecompressedPageSize)
          {
            Class616 class616_3 = new Class616();
            class616_3.ContainsOnlyZeroes = true;
            class616_3.PageNumber = 0;
            class616_3.CompressedSize = 0;
            class616_3.StartOffset = num2;
            class616_3.DecompressedSize = class617.MaxDecompressedPageSize;
            Class616 class616_4 = class616_3;
            class617.Pages.Add(class616_4);
          }
          class617.Pages.Add(class616_2);
          num2 += (ulong) class617.MaxDecompressedPageSize;
        }
        for (; num2 < class617.SectionSize; num2 += (ulong) class617.MaxDecompressedPageSize)
        {
          Class616 class616_1 = new Class616();
          class616_1.ContainsOnlyZeroes = true;
          class616_1.PageNumber = 0;
          class616_1.CompressedSize = 0;
          class616_1.StartOffset = num2;
          class616_1.DecompressedSize = class617.MaxDecompressedPageSize;
          Class616 class616_2 = class616_1;
          class617.Pages.Add(class616_2);
        }
        uint num3 = (uint) (class617.SectionSize % (ulong) class617.MaxDecompressedPageSize);
        if (num3 > 0U && class617.Pages.Count > 0)
          class617.Pages[class617.Pages.Count - 1].DecompressedSize = (int) num3;
        this.dictionary_2.Add(class617.Name, class617);
      }
    }

    private void method_26()
    {
      if (this.class374_0.IsVersion21OrLater)
        this.method_28();
      else
        this.method_27();
    }

    private void method_27()
    {
      Interface30 nterface30 = this.method_7("AcDb:Classes", 1, false);
      nterface30.imethod_52(16);
      int num1 = nterface30.imethod_43();
      long num2 = nterface30.StreamPosition + (long) num1;
      if (this.class374_0.IsVersion18OrLater)
      {
        int num3 = (int) nterface30.imethod_14();
        int num4 = (int) nterface30.imethod_18();
        int num5 = (int) nterface30.imethod_18();
        nterface30.imethod_6();
      }
      while (nterface30.StreamPosition < num2)
      {
        DxfClass dxfClass = new DxfClass();
        dxfClass.ClassNumber = nterface30.imethod_14();
        dxfClass.ProxyFlags = (ProxyFlags) nterface30.imethod_14();
        dxfClass.ApplicationName = nterface30.ReadString();
        dxfClass.CPlusPlusClassName = nterface30.ReadString();
        dxfClass.DxfName = nterface30.ReadString();
        dxfClass.WasAZombie = nterface30.imethod_6();
        dxfClass.ItemClassId = nterface30.imethod_14();
        if (this.class374_0.IsVersion18OrLater)
        {
          nterface30.imethod_11();
          dxfClass.DwgVersion = (DwgVersion) nterface30.imethod_14();
          dxfClass.MaintenanceVersion = nterface30.imethod_14();
          nterface30.imethod_11();
          nterface30.imethod_11();
        }
        this.dxfModel_0.Classes.Add(dxfClass);
      }
      int num6 = (int) nterface30.imethod_27();
      nterface30.imethod_52(16);
      if (this.dxfVersion_0 < DxfVersion.Dxf18)
        return;
      nterface30.imethod_43();
      nterface30.imethod_43();
    }

    private void method_28()
    {
      Interface30 nterface30 = this.method_7("AcDb:Classes", 1, false);
      nterface30.imethod_19(16);
      nterface30.imethod_43();
      if (this.dxfVersion_0 > DxfVersion.Dxf21 && this.dxfModel_0.Header.AcadMaintenanceVersion > 3 || this.dxfVersion_0 > DxfVersion.Dxf27)
        nterface30.imethod_43();
      long stringStreamEndBitPosition = nterface30.imethod_3() + (long) nterface30.imethod_43() - 1L;
      long bitPosition1 = nterface30.imethod_3();
      long bitPosition2 = nterface30.imethod_5(stringStreamEndBitPosition);
      nterface30.imethod_4(bitPosition1);
      nterface30.imethod_11();
      nterface30.imethod_6();
      while (nterface30.imethod_3() < bitPosition2)
      {
        DxfClass dxfClass = new DxfClass();
        dxfClass.ClassNumber = nterface30.imethod_14();
        dxfClass.ProxyFlags = (ProxyFlags) nterface30.imethod_14();
        dxfClass.WasAZombie = nterface30.imethod_6();
        dxfClass.ItemClassId = nterface30.imethod_14();
        nterface30.imethod_11();
        nterface30.imethod_11();
        nterface30.imethod_11();
        nterface30.imethod_11();
        nterface30.imethod_11();
        this.dxfModel_0.Classes.Add(dxfClass);
      }
      nterface30.imethod_4(bitPosition2);
      foreach (DxfClass dxfClass in (List<DxfClass>) this.dxfModel_0.Classes)
      {
        dxfClass.ApplicationName = nterface30.ReadString();
        dxfClass.CPlusPlusClassName = nterface30.ReadString();
        dxfClass.DxfName = nterface30.ReadString();
      }
      nterface30.imethod_4(stringStreamEndBitPosition + 1L);
      int num = (int) nterface30.imethod_27();
      nterface30.imethod_19(16);
    }

    private void method_29()
    {
      Interface30 nterface30 = this.method_7("AcDb:Handles", 2, false);
      while (true)
      {
        ulong handle = 0;
        long streamPosition1 = 0;
        int num1 = (int) nterface30.imethod_18() << 8 | (int) nterface30.imethod_18();
        if (num1 != 2)
        {
          long streamPosition2 = nterface30.StreamPosition;
          int num2 = num1 - 2;
          if (num2 > 2032)
            num2 = 2032;
          long num3 = streamPosition2 + (long) num2;
          while (nterface30.StreamPosition < num3)
          {
            ulong num4 = Class992.smethod_5(nterface30.Stream);
            handle += num4;
            int num5 = nterface30.imethod_35();
            streamPosition1 += (long) num5;
            if (num4 != 0UL)
            {
              Class799 class799 = new Class799(handle, streamPosition1);
              this.list_0.Add(class799);
              this.dictionary_4[handle] = class799;
            }
            else
              this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.DuplicateObjectHandle, Severity.Warning)
              {
                Parameters = {
                  {
                    "Handle",
                    (object) handle
                  }
                }
              });
          }
          int num6 = (int) nterface30.imethod_18();
          int num7 = (int) nterface30.imethod_18();
        }
        else
          break;
      }
      int num8 = (int) nterface30.imethod_18();
      int num9 = (int) nterface30.imethod_18();
    }

    private void method_30()
    {
      if (this.dxfVersion_0 < DxfVersion.Dxf18)
        return;
      Interface30 nterface30 = this.method_7("AcDb:ObjFreeSpace", 3, false);
      if (nterface30 == null)
        return;
      Class613.Read(Class889.Create(nterface30.Stream, this.dxfVersion_0, nterface30.Encoding), this.dxfModel_0);
    }

    private void method_31()
    {
      Interface30 nterface30 = this.method_7("AcDb:Template", 4, false);
      if (nterface30 == null)
        return;
      Class502.Read(Class889.Create(nterface30.Stream, this.dxfVersion_0, nterface30.Encoding), this.dxfModel_0);
    }

    private void method_32()
    {
      int address = -1;
      if (this.dxfVersion_0 == DxfVersion.Dxf13)
      {
        Class884 class884_1;
        if (this.dictionary_0.TryGetValue(3, out class884_1))
        {
          address = class884_1.Position + class884_1.Size;
          if (class884_1.Size == 0)
          {
            Class884 class884_2 = this.dictionary_0[2];
            address = class884_2.Position + class884_2.Size;
          }
        }
        else
        {
          Class884 class884_2 = this.dictionary_0[2];
          address = class884_2.Position + class884_2.Size;
        }
      }
      else if (this.dxfVersion_0 >= DxfVersion.Dxf14 && this.dxfVersion_0 <= DxfVersion.Dxf15)
      {
        Class884 class884_1;
        if (this.dictionary_0.TryGetValue(3, out class884_1))
        {
          address = class884_1.Position + class884_1.Size;
          if (class884_1.Size == 0)
          {
            Class884 class884_2 = this.dictionary_0[2];
            address = class884_2.Position + class884_2.Size;
          }
        }
        else
        {
          Class884 class884_2 = this.dictionary_0[2];
          address = class884_2.Position + class884_2.Size;
        }
      }
      if (address >= 0)
      {
        if ((long) address >= this.stream_0.Length)
        {
          address = -1;
        }
        else
        {
          foreach (Class884 class884 in this.dictionary_0.Values)
          {
            if (class884.method_0(address))
            {
              address = -1;
              break;
            }
          }
        }
      }
      if (address < 0 || this.dxfVersion_0 < DxfVersion.Dxf13 || this.dxfVersion_0 > DxfVersion.Dxf15)
        return;
      this.interface30_0.imethod_4((long) (address * 8));
      this.interface30_0.imethod_19(16);
      this.interface30_0.imethod_3();
      this.interface30_0.imethod_43();
      this.interface30_0.imethod_11();
      this.interface30_0.imethod_19(6);
      int num1 = (int) this.interface30_0.imethod_18();
      int num2 = (int) this.interface30_0.imethod_18();
      int num3 = (int) this.interface30_0.imethod_18();
      int num4 = (int) this.interface30_0.imethod_18();
      int num5 = (int) this.interface30_0.imethod_18();
      int num6 = (int) this.interface30_0.imethod_18();
      int num7 = (int) this.interface30_0.imethod_18();
      int num8 = (int) this.interface30_0.imethod_14();
      int num9 = (int) this.interface30_0.imethod_45();
      short num10 = this.interface30_0.imethod_14();
      List<Class884> class884List = new List<Class884>();
      for (int index = 0; index < (int) num10; ++index)
        class884List.Add(new Class884()
        {
          Index = (int) this.interface30_0.imethod_18(),
          Position = this.interface30_0.imethod_11(),
          Size = this.interface30_0.imethod_11()
        });
      short num11 = this.interface30_0.imethod_14();
      List<ulong> ulongList = new List<ulong>();
      for (int index1 = 0; index1 < (int) num11; ++index1)
      {
        byte num12 = this.interface30_0.imethod_18();
        int num13 = (int) this.interface30_0.imethod_18();
        ulong num14 = 0;
        for (int index2 = 0; index2 < (int) num12; ++index2)
          num14 += (ulong) ((int) this.interface30_0.imethod_18() << ((int) num12 - index2 - 1) * 8);
        ulongList.Add(num14);
      }
      if (this.interface30_0.BitIndex > 0)
      {
        for (int bitIndex = this.interface30_0.BitIndex; bitIndex < 8; ++bitIndex)
          this.interface30_0.imethod_6();
      }
      this.interface30_0.imethod_3();
      int num15 = (int) this.interface30_0.imethod_27();
      if (this.dxfVersion_0 >= DxfVersion.Dxf14)
        this.interface30_0.imethod_19(8);
      this.interface30_0.imethod_19(16);
    }

    private void method_33()
    {
      new Class434(this, this.class374_0, this.method_7("AcDb:AcDbObjects", -1, false), this.dictionary_4).method_76(new ProgressEventHandler(this.method_36));
    }

    private void method_34()
    {
      if (this.dxfVersion_0 != DxfVersion.Dxf21)
        return;
      Interface30 nterface30 = this.method_7("AcDb:RevHistory", -1, false);
      if (nterface30 == null)
        return;
      Class889 class889 = Class889.Create(nterface30.Stream, this.dxfVersion_0, nterface30.Encoding);
      long position = nterface30.Stream.Position;
      int num1 = (int) class889.vmethod_10();
      int num2 = (int) class889.vmethod_10();
      int num3 = (int) class889.vmethod_10();
      int num4 = (int) class889.vmethod_10();
      DwgReader.smethod_4(nterface30.Stream, position);
    }

    private void method_35()
    {
      this.class374_0.DataStore = (Class741) null;
      if (this.dxfVersion_0 < DxfVersion.Dxf27)
        return;
      Class889 r = this.method_8("AcDb:AcDsPrototype_1b", -1, false);
      if (r == null)
        return;
      Class741 dataStore;
      new Class741.Class742().Read(out dataStore, r);
      this.class374_0.DataStore = dataStore;
    }

    private void method_36(object sender, ProgressEventArgs e)
    {
      this.OnProgress(e);
    }

    private static void smethod_4(Stream sectionStream, long streamStartPosition)
    {
      long position = sectionStream.Position;
    }

    public void Dispose()
    {
      if (this.stream_0 != null)
      {
        if (this.bool_1)
          this.stream_0.Close();
        this.stream_0 = (Stream) null;
      }
      this.string_0 = (string) null;
      this.dxfModel_0 = (DxfModel) null;
    }
  }
}
