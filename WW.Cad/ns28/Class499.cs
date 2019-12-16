// Decompiled with JetBrains decompiler
// Type: ns28.Class499
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns2;
using ns36;
using ns39;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WW.Cad.Base;
using WW.Cad.Model;
using WW.Cad.Model.Tables;
using WW.Text;

namespace ns28
{
  internal class Class499
  {
    private Class564 class564_0 = new Class564();
    private Class617 class617_0 = new Class617();
    private Class617 class617_1 = new Class617("AcDb:SummaryInfo");
    private Class617 class617_2 = new Class617("AcDb:AuxHeader");
    private Class617 class617_3 = new Class617("AcDb:Header");
    private Class617 class617_4 = new Class617("AcDb:Classes");
    private Class617 class617_5 = new Class617("AcDb:Preview");
    private Class617 class617_6 = new Class617("AcDb:AppInfo");
    private Class617 class617_7 = new Class617("AcDb:FileDepList");
    private Class617 class617_8 = new Class617("AcDb:RevHistory");
    private Class617 class617_9 = new Class617("AcDb:AcDbObjects");
    private Class617 class617_10 = new Class617("AcDb:ObjFreeSpace");
    private Class617 class617_11 = new Class617("AcDb:Template");
    private Class617 class617_12 = new Class617("AcDb:Handles");
    private List<Class617> list_0 = new List<Class617>();
    private List<Class614> list_1 = new List<Class614>();
    private List<Class991> list_2 = new List<Class991>();
    private DxfModel dxfModel_0;
    private DxfVersion dxfVersion_0;
    private Stream stream_0;
    private Encoding encoding_0;

    public Class499(Stream stream, DxfModel model)
    {
      if (!stream.CanSeek || !stream.CanWrite)
        throw new ArgumentException("Stream must allow writing and seeking.");
      this.dxfModel_0 = model;
      this.stream_0 = stream;
      this.dxfVersion_0 = model.Header.AcadVersion;
      this.encoding_0 = Encodings.GetEncoding((int) model.Header.DrawingCodePage);
    }

    public DxfModel Model
    {
      get
      {
        return this.dxfModel_0;
      }
    }

    public DxfVersion Version
    {
      get
      {
        return this.dxfVersion_0;
      }
    }

    public Encoding Encoding
    {
      get
      {
        return this.encoding_0;
      }
    }

    public List<Class617> Sections
    {
      get
      {
        return this.list_0;
      }
    }

    public void Write()
    {
      Class1030 knownClasses = new Class1030(this.dxfModel_0);
      for (int index = 0; index < 256; ++index)
        this.stream_0.WriteByte((byte) 0);
      this.method_0();
      this.vmethod_0(knownClasses);
      this.list_1.Add((Class614) null);
      this.class564_0.PagesMaxId = (uint) (this.list_1.Count + 2);
      this.class564_0.GapsMaxId = 0U;
      this.class564_0.PagesMapId = this.class564_0.PagesMaxId;
      this.class564_0.SectionsMapId = this.class564_0.PagesMaxId - 1U;
      this.method_17();
      this.method_18();
      this.method_1();
      this.stream_0.Flush();
    }

    protected virtual void vmethod_0(Class1030 knownClasses)
    {
      this.list_0.Add(this.class617_0);
      this.list_0.Add(this.class617_7);
      this.list_0.Add(this.class617_6);
      this.list_0.Add(this.class617_5);
      this.list_0.Add(this.class617_1);
      this.list_0.Add(this.class617_8);
      this.list_0.Add(this.class617_9);
      this.list_0.Add(this.class617_10);
      this.list_0.Add(this.class617_11);
      this.list_0.Add(this.class617_12);
      this.list_0.Add(this.class617_4);
      this.list_0.Add(this.class617_2);
      this.list_0.Add(this.class617_3);
      this.method_4();
      this.method_5();
      this.method_9();
      this.method_10();
      this.method_11();
      this.method_12();
      this.method_13(knownClasses);
      this.method_14();
      this.method_15();
      this.method_16();
      this.method_8();
      this.method_6();
      this.method_7();
    }

    private void method_0()
    {
      for (int index = 1; index < this.list_0.Count; ++index)
      {
        int num = this.list_0.Count - index;
        this.list_0[index].SectionId = num;
      }
    }

    private void method_1()
    {
      Class889 class889 = Class889.Create(this.stream_0, this.dxfVersion_0, this.encoding_0);
      this.class564_0.Header2Offset = (ulong) this.stream_0.Position;
      MemoryStream fileHeaderDataStream = new MemoryStream();
      this.method_2(fileHeaderDataStream);
      this.stream_0.Write(fileHeaderDataStream.GetBuffer(), 0, (int) fileHeaderDataStream.Length);
      this.stream_0.Position = 0L;
      this.stream_0.Write(Encodings.Ascii.GetBytes(this.dxfModel_0.Header.AcadVersionString), 0, 6);
      this.stream_0.Write(new byte[5], 0, 5);
      if (this.dxfModel_0.Header.AcadVersion == DxfVersion.Dxf18 && this.dxfModel_0.Header.AcadMaintenanceVersion == 1)
        throw new DxfException("Header.AcadMaintenanceVersion may not be 1 for R18 files.");
      this.stream_0.WriteByte((byte) this.dxfModel_0.Header.AcadMaintenanceVersion);
      this.stream_0.WriteByte((byte) 3);
      class889.vmethod_11((uint) this.class617_5.Pages[0].StreamOffset + 32U);
      this.stream_0.WriteByte((byte) Class885.smethod_3(DxfVersion.Dxf27));
      this.stream_0.WriteByte((byte) 8);
      ushort num = Class952.smethod_1(this.dxfModel_0.Header.DrawingCodePage);
      class889.vmethod_7(num);
      this.stream_0.Write(new byte[3], 0, 3);
      class889.vmethod_9((int) this.dxfModel_0.SecurityFlags);
      class889.vmethod_9(0);
      class889.vmethod_11((uint) this.class617_1.Pages[0].StreamOffset + 32U);
      class889.vmethod_11(0U);
      class889.vmethod_9(128);
      class889.vmethod_11((uint) this.class617_6.Pages[0].StreamOffset + 32U);
      this.stream_0.Write(new byte[80], 0, 80);
      this.stream_0.Write(fileHeaderDataStream.GetBuffer(), 0, (int) fileHeaderDataStream.Length);
      this.stream_0.Write(Class998.byte_0, 236, 20);
    }

    private void method_2(MemoryStream fileHeaderDataStream)
    {
      Stream2 stream2 = new Stream2((Stream) fileHeaderDataStream, 0U);
      Class889 class889 = Class889.Create((Stream) stream2, this.dxfVersion_0, this.encoding_0);
      byte[] bytes = Class1045.encoding_0.GetBytes("AcFssFcAJMB");
      stream2.Write(bytes, 0, 11);
      stream2.WriteByte((byte) 0);
      class889.vmethod_9(0);
      class889.vmethod_9(108);
      class889.vmethod_9(4);
      class889.vmethod_9(this.class564_0.GapsRootId);
      class889.vmethod_9(this.class564_0.GapsLeftId);
      class889.vmethod_9(this.class564_0.GapsRightId);
      class889.vmethod_9(this.class564_0.GapsUnknown);
      class889.vmethod_9(this.class564_0.LastPageId);
      class889.vmethod_15(this.class564_0.LastPageEndOffset);
      class889.vmethod_15(this.class564_0.Header2Offset);
      class889.vmethod_11(this.class564_0.GapCount);
      class889.vmethod_11(this.class564_0.PageCount);
      class889.vmethod_9(32);
      class889.vmethod_9(128);
      class889.vmethod_9(64);
      class889.vmethod_11(this.class564_0.PagesMapId);
      class889.vmethod_15(this.class564_0.PagesMapOffset - 256UL);
      class889.vmethod_11(this.class564_0.SectionsMapId);
      class889.vmethod_11(this.class564_0.PagesMaxId);
      class889.vmethod_11(this.class564_0.GapsMaxId);
      long position = stream2.Position;
      class889.vmethod_11(0U);
      uint crc = stream2.Crc;
      stream2.Position = position;
      class889.vmethod_11(crc);
      stream2.Flush();
      this.method_3(fileHeaderDataStream);
    }

    private void method_3(MemoryStream fileHeaderDataStream)
    {
      int length = (int) fileHeaderDataStream.Length;
      byte[] buffer = fileHeaderDataStream.GetBuffer();
      for (int index = 0; index < length; ++index)
        buffer[index] ^= Class998.byte_0[index];
    }

    private void method_4()
    {
      this.method_23(this.class617_0, new MemoryStream(), true);
    }

    private void method_5()
    {
      this.class617_1.MaxDecompressedPageSize = 256;
      MemoryStream memoryStream = new MemoryStream();
      SummaryInfo summaryInfo = this.dxfModel_0.SummaryInfo;
      Class611.Write(Class889.Create((Stream) memoryStream, this.dxfVersion_0, this.encoding_0), summaryInfo);
      this.method_23(this.class617_1, memoryStream, false);
    }

    private void method_6()
    {
      MemoryStream memoryStream = new MemoryStream();
      new Class993(memoryStream, this.dxfModel_0, this.encoding_0).Write();
      this.method_23(this.class617_2, memoryStream, true);
    }

    private void method_7()
    {
      MemoryStream memoryStream = new MemoryStream();
      new Class886((Stream) memoryStream, this.dxfModel_0).Write();
      this.method_23(this.class617_3, memoryStream, true);
    }

    private void method_8()
    {
      MemoryStream memoryStream = new MemoryStream();
      new Class1033((Stream) memoryStream, this.dxfModel_0).Write();
      this.method_23(this.class617_4, memoryStream, true);
    }

    private void method_9()
    {
      this.class617_5.MaxDecompressedPageSize = 1024;
      MemoryStream memoryStream = new MemoryStream();
      new Class328((Stream) memoryStream, this.dxfModel_0).Write();
      this.method_23(this.class617_5, memoryStream, false);
    }

    private void method_10()
    {
      this.class617_6.MaxDecompressedPageSize = 128;
      MemoryStream memoryStream = new MemoryStream();
      Class885.smethod_0(new Class949(), (Stream) memoryStream, this.encoding_0);
      this.method_23(this.class617_6, memoryStream, false);
    }

    public static void smethod_0(Class949 appInfo, Class889 byteStream)
    {
      byteStream.vmethod_19(appInfo.Name);
      byteStream.vmethod_11(appInfo.Unknown0);
      byteStream.vmethod_19("4001");
      byteStream.vmethod_19(appInfo.Product);
      byteStream.vmethod_19(appInfo.Version);
    }

    private void method_11()
    {
      this.class617_7.MaxDecompressedPageSize = 128;
      FileDependencyCollection dependencyCollection = new FileDependencyCollection();
      if (dependencyCollection.Count > 1)
        this.class617_7.MaxDecompressedPageSize = 128 * dependencyCollection.Count;
      this.class617_7.Encrypted = 2;
      MemoryStream memoryStream = new MemoryStream();
      Class889 class889 = Class889.Create((Stream) memoryStream, this.dxfVersion_0, this.encoding_0);
      List<string> stringList = new List<string>();
      foreach (FileDependency.Key key in dependencyCollection.Keys)
      {
        if (!stringList.Contains(key.FeatureName))
          stringList.Add(key.FeatureName);
      }
      class889.vmethod_9(stringList.Count);
      foreach (string str in stringList)
        class889.vmethod_22(str);
      class889.vmethod_9(dependencyCollection.Count);
      DateTime dateTime = new DateTime(1980, 1, 1);
      foreach (FileDependency.Key key in dependencyCollection.Keys)
      {
        FileDependency fileDependency = dependencyCollection[key];
        if (fileDependency.FeatureName == "Acad:Text")
        {
          string str = DxfTextStyle.smethod_2(Class1043.smethod_2(this.dxfModel_0.Filename), fileDependency.FullFilename);
          if (!string.IsNullOrEmpty(str) && File.Exists(str))
          {
            FileInfo fileInfo = new FileInfo(str);
            fileDependency.TimeStamp = fileInfo.LastWriteTime;
            fileDependency.FileSize = (int) fileInfo.Length;
          }
        }
        class889.vmethod_22(fileDependency.FullFilename);
        class889.vmethod_22(fileDependency.FoundPath);
        class889.vmethod_22(fileDependency.FingerPrintGuid);
        class889.vmethod_22(fileDependency.VersionGuid);
        class889.vmethod_9(stringList.IndexOf(fileDependency.FeatureName));
        TimeSpan timeSpan = fileDependency.TimeStamp - dateTime;
        class889.vmethod_9((int) timeSpan.TotalSeconds);
        class889.vmethod_9(fileDependency.FileSize);
        class889.vmethod_5(fileDependency.AffectsGraphics ? (short) 1 : (short) 0);
        class889.vmethod_9(fileDependency.References.Count);
      }
      this.method_23(this.class617_7, memoryStream, false);
    }

    private void method_12()
    {
      MemoryStream memoryStream = new MemoryStream();
      Class889 class889 = Class889.Create((Stream) memoryStream, this.dxfVersion_0, this.encoding_0);
      class889.vmethod_11(0U);
      class889.vmethod_11(0U);
      class889.vmethod_11(0U);
      this.method_23(this.class617_8, memoryStream, true);
    }

    private void method_13(Class1030 knownClasses)
    {
      MemoryStream memoryStream = new MemoryStream();
      Class432 class432 = new Class432((Stream) memoryStream, this.dxfModel_0, knownClasses);
      class432.Write();
      this.list_2 = class432.HandleAndStreamPositionList;
      this.method_23(this.class617_9, memoryStream, true);
    }

    private void method_14()
    {
      MemoryStream memoryStream = new MemoryStream();
      Class612.Write(Class889.Create((Stream) memoryStream, this.dxfVersion_0, this.encoding_0), this.dxfModel_0, (uint) this.list_2.Count, 0U);
      this.method_23(this.class617_10, memoryStream, true);
    }

    private void method_15()
    {
      MemoryStream memoryStream = new MemoryStream();
      Class501.Write(Class889.Create((Stream) memoryStream, this.dxfVersion_0, this.encoding_0), this.dxfModel_0);
      this.method_23(this.class617_11, memoryStream, true);
    }

    private void method_16()
    {
      MemoryStream memoryStream = new MemoryStream();
      new Class655(memoryStream, this.dxfModel_0, this.list_2, 0).Write();
      this.method_23(this.class617_12, memoryStream, true);
    }

    private void method_17()
    {
      MemoryStream sectionStream = new MemoryStream();
      Class889 class889 = Class889.Create((Stream) sectionStream, this.dxfVersion_0, this.encoding_0);
      class889.vmethod_9(this.list_0.Count);
      class889.vmethod_9(2);
      class889.vmethod_9(29696);
      class889.vmethod_9(0);
      class889.vmethod_9(this.list_0.Count);
      foreach (Class617 class617 in this.list_0)
      {
        class889.vmethod_15(class617.SectionSize);
        class889.vmethod_9(class617.PageCount);
        class889.vmethod_9(class617.MaxDecompressedPageSize);
        class889.vmethod_9(1);
        class889.vmethod_9(class617.Compressed);
        class889.vmethod_9(class617.SectionId);
        class889.vmethod_9(class617.Encrypted);
        byte[] buffer = new byte[64];
        if (!string.IsNullOrEmpty(class617.Name))
        {
          byte[] bytes = Encodings.Ascii.GetBytes(class617.Name);
          int num = Math.Min(bytes.Length, buffer.Length);
          for (int index = 0; index < num; ++index)
            buffer[index] = bytes[index];
        }
        sectionStream.Write(buffer, 0, buffer.Length);
        foreach (Class616 page in class617.Pages)
        {
          if (page.PageNumber > 0)
          {
            class889.vmethod_9(page.PageNumber);
            class889.vmethod_9(page.CompressedSize);
            class889.vmethod_15(page.StartOffset);
          }
        }
      }
      Class615 page1 = this.method_20(1097007163, sectionStream);
      int count = Class998.smethod_0((int) (this.stream_0.Position - page1.StreamOffset));
      this.stream_0.Write(Class998.byte_0, 0, count);
      page1.Length = this.stream_0.Position - page1.StreamOffset;
      this.method_19(page1);
    }

    private void method_18()
    {
      this.method_27();
      Class615 page = new Class615(1097010747);
      this.method_19(page);
      int pageSize = this.list_1.Count * 8;
      page.StreamOffset = this.stream_0.Position;
      int num = pageSize + Class998.smethod_0(pageSize);
      page.Length = (long) num;
      MemoryStream sectionStream = new MemoryStream();
      Class889 class889 = Class889.Create((Stream) sectionStream, this.dxfVersion_0, this.encoding_0);
      foreach (Class614 class614 in this.list_1)
      {
        if (class614 != null)
        {
          class889.vmethod_9(class614.PageNumber);
          class889.vmethod_9((int) class614.Length);
        }
      }
      this.method_21(page, sectionStream);
      Class614 class614_1 = this.list_1[this.list_1.Count - 1];
      this.class564_0.LastPageId = class614_1.PageNumber;
      this.class564_0.LastPageEndOffset = (ulong) (class614_1.StreamOffset + (long) num - 256L);
      this.class564_0.GapCount = 0U;
      this.class564_0.PageCount = (uint) (this.list_1.Count - 1);
      this.class564_0.PagesMapOffset = (ulong) page.StreamOffset;
    }

    private void method_19(Class615 page)
    {
      page.PageNumber = this.list_1.Count + 1;
      this.list_1.Add((Class614) page);
    }

    private Class615 method_20(int sectionPageType, MemoryStream sectionStream)
    {
      Class615 page = new Class615(sectionPageType);
      this.method_27();
      page.StreamOffset = this.stream_0.Position;
      this.method_21(page, sectionStream);
      return page;
    }

    private void method_21(Class615 page, MemoryStream sectionStream)
    {
      page.DecompressedSize = (int) sectionStream.Length;
      Class565 class565 = new Class565();
      MemoryStream memoryStream1 = new MemoryStream();
      class565.method_1(sectionStream.GetBuffer(), 0, (int) sectionStream.Length, (Stream) memoryStream1);
      page.CompressedSize = (int) memoryStream1.Length;
      MemoryStream memoryStream2 = new MemoryStream();
      this.method_22(page, (Stream) memoryStream2);
      page.Checksum = Class998.smethod_1(0U, memoryStream2.GetBuffer(), 0, (int) memoryStream2.Length);
      page.Checksum = Class998.smethod_1(page.Checksum, memoryStream1.GetBuffer(), 0, (int) memoryStream1.Length);
      this.method_22(page, this.stream_0);
      this.stream_0.Write(memoryStream1.GetBuffer(), 0, (int) memoryStream1.Length);
      this.method_22(new Class615(page.SectionPageType), this.stream_0);
    }

    private void method_22(Class615 page, Stream sectionHeaderStream)
    {
      Class889 class889 = Class889.Create(sectionHeaderStream, this.dxfVersion_0, this.encoding_0);
      class889.vmethod_9(page.SectionPageType);
      class889.vmethod_9(page.DecompressedSize);
      class889.vmethod_9(page.CompressedSize);
      class889.vmethod_9(page.CompressionType);
      class889.vmethod_11(page.Checksum);
    }

    protected void method_23(Class617 section, MemoryStream memoryStream, bool compress)
    {
      section.SectionSize = (ulong) memoryStream.Length;
      section.Compressed = compress ? 2 : 1;
      int decompressedPageSize = section.MaxDecompressedPageSize;
      int num1 = (int) (memoryStream.Length / (long) decompressedPageSize);
      byte[] buffer = memoryStream.GetBuffer();
      ulong num2 = 0;
      for (int index = 0; index < num1; ++index)
      {
        this.method_24(section, 1097008187, decompressedPageSize, buffer, num2, decompressedPageSize, compress);
        num2 += (ulong) decompressedPageSize;
      }
      int uncompressedLength = (int) (memoryStream.Length % (long) decompressedPageSize);
      if (uncompressedLength <= 0 || Class885.smethod_1(buffer, num2, (ulong) uncompressedLength))
        return;
      this.method_24(section, 1097008187, decompressedPageSize, buffer, num2, uncompressedLength, compress);
      int num3 = num1 + 1;
    }

    private void method_24(
      Class617 section,
      int pageType,
      int maxPageSize,
      byte[] buffer,
      ulong position,
      int uncompressedLength,
      bool compress)
    {
      MemoryStream memoryStream1 = new MemoryStream();
      if (compress)
      {
        MemoryStream memoryStream2 = new MemoryStream(maxPageSize);
        memoryStream2.Write(buffer, (int) position, uncompressedLength);
        int num = maxPageSize - uncompressedLength;
        for (int index = 0; index < num; ++index)
          memoryStream2.WriteByte((byte) 0);
        new Class565().method_1(memoryStream2.GetBuffer(), 0, maxPageSize, (Stream) memoryStream1);
      }
      else
      {
        memoryStream1.Write(buffer, (int) position, uncompressedLength);
        int num = maxPageSize - uncompressedLength;
        for (int index = 0; index < num; ++index)
          memoryStream1.WriteByte((byte) 0);
      }
      this.method_27();
      long position1 = this.stream_0.Position;
      Class616 page = new Class616();
      page.PageNumber = this.list_1.Count + 1;
      page.StartOffset = position;
      page.StreamOffset = position1;
      page.DataChecksum = Class998.smethod_1(0U, memoryStream1.GetBuffer(), 0, (int) memoryStream1.Length);
      uint dataChecksum = page.DataChecksum;
      int count = Class998.smethod_0((int) memoryStream1.Length);
      page.CompressedSize = (int) memoryStream1.Length;
      page.DecompressedSize = uncompressedLength;
      page.PageSize = page.CompressedSize + 32 + count;
      page.HeaderChecksum = 0U;
      MemoryStream memoryStream3 = new MemoryStream(32);
      this.method_25((Stream) memoryStream3, section, page, pageType);
      page.HeaderChecksum = Class998.smethod_1(dataChecksum, memoryStream3.GetBuffer(), 0, (int) memoryStream3.Length);
      memoryStream3.SetLength(0L);
      memoryStream3.Position = 0L;
      this.method_25((Stream) memoryStream3, section, page, pageType);
      this.method_26(memoryStream3.GetBuffer(), 0, (int) memoryStream3.Length);
      this.stream_0.Write(memoryStream3.GetBuffer(), 0, (int) memoryStream3.Length);
      this.stream_0.Write(memoryStream1.GetBuffer(), 0, (int) memoryStream1.Length);
      if (compress)
        this.stream_0.Write(Class998.byte_0, 0, count);
      else if (count != 0)
        throw new Exception();
      if (page.PageNumber > 0)
        ++section.PageCount;
      page.Length = this.stream_0.Position - position1;
      section.Pages.Add(page);
      this.list_1.Add((Class614) page);
    }

    private void method_25(Stream pageHeaderStream, Class617 section, Class616 page, int pageType)
    {
      Class889 class889 = Class889.Create(pageHeaderStream, this.dxfVersion_0, this.encoding_0);
      class889.vmethod_9(pageType);
      class889.vmethod_9(section.SectionId);
      class889.vmethod_9(page.CompressedSize);
      class889.vmethod_9(page.PageSize);
      class889.vmethod_13((long) page.StartOffset);
      class889.vmethod_11(page.HeaderChecksum);
      class889.vmethod_11(page.DataChecksum);
    }

    private unsafe void method_26(byte[] pageHeader, int index, int length)
    {
      int num1 = 1097093995 ^ (int) this.stream_0.Position;
      fixed (byte* numPtr1 = pageHeader)
      {
        byte* numPtr2 = numPtr1 + index;
        for (byte* numPtr3 = numPtr1 + index + length; numPtr2 < numPtr3; numPtr2 += 4)
        {
          int* numPtr4 = (int*) numPtr2;
          int num2 = *numPtr4 ^ num1;
          *numPtr4 = num2;
        }
      }
    }

    private void method_27()
    {
      int num = (int) (this.stream_0.Position % 32L);
      for (int index = 0; index < num; ++index)
        this.stream_0.WriteByte(Class998.byte_0[index]);
    }
  }
}
