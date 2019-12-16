// Decompiled with JetBrains decompiler
// Type: ns28.Class921
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns2;
using ns35;
using ns36;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WW;
using WW.Cad.Model;
using WW.Cad.Model.Tables;
using WW.Text;

namespace ns28
{
  internal class Class921
  {
    private Class954 class954_0 = new Class954();
    private Class995 class995_0 = new Class995();
    private List<Class504> list_0 = new List<Class504>();
    private Class442 class442_0 = new Class442();
    private Class442 class442_1 = new Class442();
    private List<Class441> list_1 = new List<Class441>();
    private List<Class991> list_2 = new List<Class991>();
    public const int int_0 = 128;
    public const int int_1 = 1024;
    public const int int_2 = 1024;
    public const int int_3 = 1152;
    public const int int_4 = 2176;
    public const int int_5 = 232;
    public const int int_6 = 272;
    private DxfModel dxfModel_0;
    private DxfVersion dxfVersion_0;
    private Stream stream_0;
    private Encoding encoding_0;
    private uint uint_0;
    private Class504 class504_0;
    private Class504 class504_1;
    private Class504 class504_2;
    private Class504 class504_3;
    private Class504 class504_4;
    private Class504 class504_5;
    private Class504 class504_6;
    private Class504 class504_7;
    private Class504 class504_8;
    private Class504 class504_9;
    private Class504 class504_10;
    private Class504 class504_11;

    public Class921(Stream stream, DxfModel model)
    {
      if (!stream.CanSeek || !stream.CanWrite)
        throw new ArgumentException("Stream must allow writing and seeking.");
      this.dxfModel_0 = model;
      this.stream_0 = stream;
      this.dxfVersion_0 = model.Header.AcadVersion;
      this.encoding_0 = Encodings.GetEncoding((int) model.Header.DrawingCodePage);
      Random random = new Random();
      byte[] numArray = new byte[8];
      random.NextBytes(numArray);
      this.class995_0.method_0(LittleEndianBitConverter.ToUInt64(numArray));
      this.uint_0 = 0U;
      this.class954_0.RandomSeed = this.class995_0.Seed;
      this.class954_0.CrcSeed = (ulong) this.uint_0;
      this.class954_0.PagesMapCrcSeed = (ulong) this.uint_0;
      this.class954_0.SectionsMapCrcSeed = (ulong) this.uint_0;
    }

    public static void Write(Stream stream, DxfModel model)
    {
      new Class921(stream, model).Write();
    }

    public void Write()
    {
      Class1030 knownClasses = new Class1030(this.dxfModel_0);
      this.method_0();
      this.method_4();
      this.method_8();
      this.method_9();
      this.method_10();
      this.method_11();
      this.method_12(knownClasses);
      this.method_13();
      this.method_14();
      this.method_15();
      this.method_7();
      this.method_5();
      this.method_6();
      for (int index = 0; index < 1152; ++index)
        this.stream_0.WriteByte((byte) 0);
      int pageCount = 0;
      foreach (Class504 class504 in this.list_0)
      {
        class504.method_0();
        pageCount += (int) class504.PageCount;
      }
      byte[] data = new byte[this.method_19(pageCount)];
      this.method_23((Class441) this.class442_0, data, 0, data.Length);
      this.method_23((Class441) this.class442_1, data, 0, data.Length);
      this.method_21(this.class504_3);
      this.method_21(this.class504_2);
      this.method_21(this.class504_1);
      this.method_21(this.class504_0);
      this.method_21(this.class504_4);
      this.method_21(this.class504_5);
      this.method_21(this.class504_6);
      this.method_21(this.class504_7);
      this.method_21(this.class504_8);
      this.method_21(this.class504_9);
      this.method_21(this.class504_10);
      this.method_21(this.class504_11);
      this.class954_0.PagesMaxId = (ulong) (uint) (this.list_1.Count + 2);
      this.class954_0.PagesMapId = this.class954_0.PagesMaxId;
      this.class954_0.SectionsMapId = this.class954_0.PagesMaxId - 1UL;
      this.method_16();
      this.method_18();
      this.method_1();
      this.method_2();
      this.stream_0.Flush();
    }

    private void method_0()
    {
      Class504 class504_1 = this.class504_0 = Class504.smethod_0("AcDb:FileDepList");
      class504_1.HashCode = 1816266186UL;
      if (this.dxfModel_0.FileDependencies.Count > 1)
      {
        int count = this.dxfModel_0.FileDependencies.Count;
        class504_1.MaxDecompressedPageSize = (ulong) (128 * (count + (count >> 1)));
      }
      else
        class504_1.MaxDecompressedPageSize = 256UL;
      class504_1.Encrypted = 2UL;
      class504_1.Encoding = 1UL;
      this.list_0.Add(class504_1);
      Class504 class504_2 = this.class504_1 = Class504.smethod_0("AcDb:AppInfo");
      class504_2.HashCode = 1067451454UL;
      class504_2.MaxDecompressedPageSize = 768UL;
      class504_2.Encrypted = 0UL;
      class504_2.Encoding = 1UL;
      this.list_0.Add(class504_2);
      Class504 class504_3 = this.class504_2 = Class504.smethod_0("AcDb:Preview");
      class504_3.HashCode = 1084884083UL;
      class504_3.MaxDecompressedPageSize = 1024UL;
      class504_3.Encrypted = 0UL;
      class504_3.Encoding = 1UL;
      this.list_0.Add(class504_3);
      Class504 class504_4 = this.class504_3 = Class504.smethod_0("AcDb:SummaryInfo");
      class504_4.HashCode = 1903822351UL;
      class504_4.MaxDecompressedPageSize = 128UL;
      class504_4.Encrypted = 0UL;
      class504_4.Encoding = 1UL;
      this.list_0.Add(class504_4);
      Class504 class504_5 = this.class504_4 = Class504.smethod_0("AcDb:RevHistory");
      class504_5.HashCode = 1621231027UL;
      class504_5.MaxDecompressedPageSize = 4096UL;
      class504_5.Encrypted = 0UL;
      class504_5.Encoding = 4UL;
      class504_5.Compressed = true;
      this.list_0.Add(class504_5);
      Class504 class504_6 = this.class504_5 = Class504.smethod_0("AcDb:AcDbObjects");
      class504_6.HashCode = 1733035433UL;
      class504_6.MaxDecompressedPageSize = 63488UL;
      class504_6.Encrypted = 0UL;
      class504_6.Encoding = 4UL;
      class504_6.Compressed = true;
      this.list_0.Add(class504_6);
      Class504 class504_7 = this.class504_6 = Class504.smethod_0("AcDb:ObjFreeSpace");
      class504_7.HashCode = 2011301407UL;
      class504_7.MaxDecompressedPageSize = 63488UL;
      class504_7.Encrypted = 0UL;
      class504_7.Encoding = 4UL;
      class504_7.Compressed = true;
      this.list_0.Add(class504_7);
      Class504 class504_8 = this.class504_7 = Class504.smethod_0("AcDb:Template");
      class504_8.HashCode = 1242825934UL;
      class504_8.MaxDecompressedPageSize = 1024UL;
      class504_8.Encrypted = 0UL;
      class504_8.Encoding = 4UL;
      class504_8.Compressed = true;
      this.list_0.Add(class504_8);
      Class504 class504_9 = this.class504_8 = Class504.smethod_0("AcDb:Handles");
      class504_9.HashCode = 1064174672UL;
      class504_9.MaxDecompressedPageSize = 63488UL;
      class504_9.Encrypted = 0UL;
      class504_9.Encoding = 4UL;
      class504_9.Compressed = true;
      this.list_0.Add(class504_9);
      Class504 class504_10 = this.class504_9 = Class504.smethod_0("AcDb:Classes");
      class504_10.HashCode = 1062470751UL;
      class504_10.MaxDecompressedPageSize = 63488UL;
      class504_10.Encrypted = 0UL;
      class504_10.Encoding = 4UL;
      class504_10.Compressed = true;
      this.list_0.Add(class504_10);
      Class504 class504_11 = this.class504_10 = Class504.smethod_0("AcDb:AuxHeader");
      class504_11.HashCode = 1425016074UL;
      class504_11.MaxDecompressedPageSize = 2048UL;
      class504_11.Encrypted = 0UL;
      class504_11.Encoding = 4UL;
      class504_11.Compressed = true;
      this.list_0.Add(class504_11);
      Class504 class504_12 = this.class504_11 = Class504.smethod_0("AcDb:Header");
      class504_12.HashCode = 850920409UL;
      class504_12.MaxDecompressedPageSize = 2048UL;
      class504_12.Encrypted = 0UL;
      class504_12.Encoding = 4UL;
      class504_12.Compressed = true;
      this.list_0.Add(class504_12);
      this.class954_0.SectionCount = (ulong) (this.list_0.Count + 1);
    }

    private unsafe void method_1()
    {
      this.stream_0.Position = this.stream_0.Length;
      this.class954_0.FileSize = (ulong) (this.stream_0.Length + 1024L);
      this.class954_0.Header2Offset = (ulong) (this.stream_0.Position - 1152L);
      this.class954_0.SectionsMapCrcSeed = this.class995_0.method_2((uint) this.class954_0.SectionsMapCrcSeed);
      this.class954_0.PagesMapCrcSeed = this.class995_0.method_2((uint) this.class954_0.PagesMapCrcSeed);
      Class888 class888 = new Class888();
      class888.method_0(this.class954_0.CrcSeed, this.class995_0);
      this.class954_0.CrcSeedEncoded = this.class995_0.method_2((uint) (this.class954_0.CrcSeed & (ulong) ushort.MaxValue));
      MemoryStream memoryStream1 = new MemoryStream();
      Class889 byteStream = Class889.Create((Stream) memoryStream1, this.dxfVersion_0, this.encoding_0);
      this.method_3(byteStream);
      ulong num1 = Class656.class656_0.method_0(memoryStream1.GetBuffer(), 0U, (uint) memoryStream1.Length, Class656.smethod_1(0UL, (uint) memoryStream1.Length));
      memoryStream1.Position = 264L;
      byteStream.vmethod_15(num1);
      Class955 class955 = new Class955();
      MemoryStream memoryStream2 = new MemoryStream();
      class955.method_1(memoryStream1.GetBuffer(), 0, (int) memoryStream1.Length, (Stream) memoryStream2);
      if (memoryStream2.Length >= memoryStream1.Length)
        memoryStream2 = memoryStream1;
      ulong num2 = Class656.class656_0.method_0(memoryStream2.GetBuffer(), 0U, (uint) memoryStream2.Length, Class656.smethod_1(0UL, (uint) memoryStream2.Length));
      MemoryStream memoryStream3 = new MemoryStream(12);
      Class889 class889_1 = Class889.Create((Stream) memoryStream3, this.dxfVersion_0, this.encoding_0);
      ulong control = this.class995_0.method_1();
      class889_1.vmethod_15(control);
      class889_1.vmethod_15(Class888.smethod_0(control, control));
      ulong num3 = Class656.class656_0.method_0(memoryStream3.GetBuffer(), 0U, (uint) memoryStream3.Length, Class656.smethod_0(0UL, (uint) memoryStream3.Length));
      MemoryStream memoryStream4 = new MemoryStream(1024);
      Class889 class889_2 = Class889.Create((Stream) memoryStream4, this.dxfVersion_0, this.encoding_0);
      class889_2.vmethod_15(num3);
      class889_2.vmethod_15(control);
      class889_2.vmethod_15(num2);
      if (memoryStream2.Length < 272L)
      {
        class889_2.vmethod_13(memoryStream2.Length);
      }
      else
      {
        if (memoryStream2.Length != 272L)
          throw new Exception();
        class889_2.vmethod_13(-272L);
      }
      memoryStream4.Write(memoryStream2.GetBuffer(), 0, (int) memoryStream2.Length);
      uint num4 = Class746.class746_0.K * 3U;
      uint length = (uint) class889_2.Stream.Length;
      uint num5 = (uint) ((ulong) (uint) ((int) length + 8 - 1) & 18446744073709551608UL);
      uint paddingSize1 = num5 - length;
      this.method_25((Stream) memoryStream4, paddingSize1);
      uint num6 = num4 / num5;
      for (int index = 1; (long) index < (long) num6; ++index)
        memoryStream4.Write(memoryStream4.GetBuffer(), 0, (int) num5);
      uint paddingSize2 = num4 - (uint) memoryStream4.Length;
      this.method_25((Stream) memoryStream4, paddingSize2);
      byte[] buffer = new byte[1024];
      fixed (byte* source = memoryStream4.GetBuffer())
        fixed (byte* destination = buffer)
        {
          this.method_28(destination, source, (int) num4, Class746.class746_0);
          this.method_24(destination + 765, 259U);
        }
      MemoryStream memoryStream5 = new MemoryStream(buffer, true);
      memoryStream5.Position = memoryStream5.Length - 40L;
      class888.Write((Stream) memoryStream5);
      if (memoryStream5.Length != 1024L)
        throw new Exception();
      this.stream_0.Write(buffer, 0, buffer.Length);
      this.stream_0.Position = 128L;
      this.stream_0.Write(buffer, 0, buffer.Length);
    }

    private void method_2()
    {
      Class889 class889 = Class889.Create(this.stream_0, this.dxfVersion_0, this.encoding_0);
      this.stream_0.Position = 0L;
      this.stream_0.Write(Encodings.Ascii.GetBytes(this.dxfModel_0.Header.AcadVersionString), 0, 6);
      this.stream_0.Write(new byte[5], 0, 5);
      int maintenanceVersion = this.dxfModel_0.Header.AcadMaintenanceVersion;
      this.stream_0.WriteByte((byte) this.dxfModel_0.Header.AcadMaintenanceVersion);
      this.stream_0.WriteByte((byte) 3);
      class889.vmethod_11((uint) this.class504_2.Pages[0].StreamOffset + 1152U);
      this.stream_0.WriteByte((byte) Class885.smethod_3(DxfVersion.Dxf27));
      this.stream_0.WriteByte((byte) 8);
      ushort num = Class952.smethod_1(this.dxfModel_0.Header.DrawingCodePage);
      class889.vmethod_7(num);
      this.stream_0.Write(new byte[3], 0, 3);
      class889.vmethod_9((int) this.dxfModel_0.SecurityFlags);
      class889.vmethod_9(0);
      class889.vmethod_11((uint) this.class504_3.Pages[0].StreamOffset + 1152U);
      class889.vmethod_11(0U);
      class889.vmethod_9(128);
      class889.vmethod_11((uint) this.class504_1.Pages[0].StreamOffset + 1152U);
      for (int index = 0; index < 80; ++index)
        this.stream_0.WriteByte((byte) 0);
    }

    private void method_3(Class889 byteStream)
    {
      byteStream.vmethod_15(this.class954_0.HeaderSize);
      byteStream.vmethod_15(this.class954_0.FileSize);
      byteStream.vmethod_15(this.class954_0.PagesMapCrcCompressed);
      byteStream.vmethod_15(this.class954_0.PagesMapDataRepeatCount);
      byteStream.vmethod_15(this.class954_0.PagesMapCrcSeed);
      byteStream.vmethod_15(this.class954_0.PagesMap2Offset);
      byteStream.vmethod_15(this.class954_0.PagesMap2Id);
      byteStream.vmethod_15(this.class954_0.PagesMapOffset);
      byteStream.vmethod_15(this.class954_0.PagesMapId);
      byteStream.vmethod_15(this.class954_0.Header2Offset);
      byteStream.vmethod_15(this.class954_0.PagesMapSizeCompressed);
      byteStream.vmethod_15(this.class954_0.PagesMapSizeDecompressed);
      byteStream.vmethod_15(this.class954_0.PageCount);
      byteStream.vmethod_15(this.class954_0.PagesMaxId);
      byteStream.vmethod_15(this.class954_0.Unknown1);
      byteStream.vmethod_15(this.class954_0.Unknown2);
      byteStream.vmethod_15(this.class954_0.PagesMapCrcDecompressed);
      byteStream.vmethod_15(this.class954_0.Unknown3);
      byteStream.vmethod_15(this.class954_0.Unknown4);
      byteStream.vmethod_15(this.class954_0.Unknown5);
      byteStream.vmethod_15(this.class954_0.SectionCount);
      byteStream.vmethod_15(this.class954_0.SectionsMapCrcDecompressed);
      byteStream.vmethod_15(this.class954_0.SectionsMapSizeCompressed);
      byteStream.vmethod_15(this.class954_0.SectionsMap2Id);
      byteStream.vmethod_15(this.class954_0.SectionsMapId);
      byteStream.vmethod_15(this.class954_0.SectionsMapSizeDecompressed);
      byteStream.vmethod_15(this.class954_0.SectionsMapCrcCompressed);
      byteStream.vmethod_15(this.class954_0.SectionsMapDataRepeatCount);
      byteStream.vmethod_15(this.class954_0.SectionsMapCrcSeed);
      byteStream.vmethod_15(this.class954_0.StreamVersion);
      byteStream.vmethod_15(this.class954_0.CrcSeed);
      byteStream.vmethod_15(this.class954_0.CrcSeedEncoded);
      byteStream.vmethod_15(this.class954_0.RandomSeed);
      byteStream.vmethod_15(0UL);
    }

    private void method_4()
    {
      Class611.Write(Class889.Create((Stream) this.class504_3.Stream, this.dxfVersion_0, this.encoding_0), this.dxfModel_0.SummaryInfo);
    }

    private void method_5()
    {
      new Class993(this.class504_10.Stream, this.dxfModel_0, this.encoding_0).Write();
    }

    private void method_6()
    {
      new Class886((Stream) this.class504_11.Stream, this.dxfModel_0).Write();
    }

    private void method_7()
    {
      new Class1033((Stream) this.class504_9.Stream, this.dxfModel_0).Write();
    }

    private void method_8()
    {
      this.class504_2.MaxDecompressedPageSize = 1024UL;
      new Class328((Stream) this.class504_2.Stream, this.dxfModel_0).Write();
    }

    private void method_9()
    {
      Class889.Create((Stream) this.class504_1.Stream, this.dxfVersion_0, this.encoding_0);
      Class885.smethod_0(new Class949(), (Stream) this.class504_1.Stream, this.encoding_0);
    }

    public static void smethod_0(Class949 appInfo, Class889 byteStream)
    {
      byteStream.vmethod_11(appInfo.Unknown0);
      byteStream.vmethod_19(appInfo.Name);
      byteStream.vmethod_11(appInfo.Unknown1);
      byteStream.vmethod_2(appInfo.VersionData, 0, appInfo.VersionData.Length);
      byteStream.vmethod_19(appInfo.Version);
      byteStream.vmethod_2(appInfo.CommentData, 0, appInfo.CommentData.Length);
      byteStream.vmethod_19(appInfo.Comment);
      byteStream.vmethod_2(appInfo.ProductData, 0, appInfo.ProductData.Length);
      byteStream.vmethod_19(appInfo.Product);
    }

    private void method_10()
    {
      this.class504_0.MaxDecompressedPageSize = 256UL;
      FileDependencyCollection dependencyCollection = new FileDependencyCollection();
      if (dependencyCollection.Count > 1)
        this.class504_0.MaxDecompressedPageSize = 128UL * (ulong) dependencyCollection.Count;
      Class889 class889 = Class889.Create((Stream) this.class504_0.Stream, this.dxfVersion_0, this.encoding_0);
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
    }

    private void method_11()
    {
      Class889 class889 = Class889.Create((Stream) this.class504_4.Stream, this.dxfVersion_0, this.encoding_0);
      class889.vmethod_11(0U);
      class889.vmethod_11(0U);
      class889.vmethod_11(1U);
      class889.vmethod_11(0U);
    }

    private void method_12(Class1030 knownClasses)
    {
      Class432 class432 = new Class432((Stream) this.class504_5.Stream, this.dxfModel_0, knownClasses);
      class432.Write();
      this.list_2 = class432.HandleAndStreamPositionList;
    }

    private void method_13()
    {
      Class612.Write(Class889.Create((Stream) this.class504_6.Stream, this.dxfVersion_0, this.encoding_0), this.dxfModel_0, (uint) this.list_2.Count, 0U);
    }

    private void method_14()
    {
      Class501.Write(Class889.Create((Stream) this.class504_7.Stream, this.dxfVersion_0, this.encoding_0), this.dxfModel_0);
    }

    private void method_15()
    {
      new Class655(this.class504_8.Stream, this.dxfModel_0, this.list_2, 0).Write();
    }

    private void method_16()
    {
      MemoryStream sectionStream = new MemoryStream();
      Class889 byteStream = Class889.Create((Stream) sectionStream, this.dxfVersion_0, this.encoding_0);
      foreach (Class504 section in this.list_0)
      {
        if (section.DataSize != 0UL)
          this.method_17(section, byteStream);
      }
      if (this.dxfVersion_0 == DxfVersion.Dxf21)
        this.method_17(new Class504()
        {
          HashCode = 0UL,
          MaxDecompressedPageSize = 63488UL,
          Encrypted = 0UL,
          Encoding = 4UL
        }, byteStream);
      Class442 page = new Class442();
      ulong pageSize = Class996.smethod_2((ulong) sectionStream.Length);
      byte[] pageData;
      this.method_20(page, sectionStream, this.class954_0.SectionsMapCrcSeed, pageSize, out pageData);
      Class442 class442 = (Class442) page.Clone();
      this.method_23((Class441) page, pageData, 0, pageData.Length);
      this.method_23((Class441) class442, pageData, 0, pageData.Length);
      this.class954_0.SectionsMapDataRepeatCount = page.DataRepeatCount;
      this.class954_0.SectionsMapSizeCompressed = page.CompressedSize;
      this.class954_0.SectionsMapSizeDecompressed = page.DecompressedSize;
      this.class954_0.SectionsMapCrcCompressed = page.CompressedCrc;
      this.class954_0.SectionsMapCrcDecompressed = page.DecompressedCrc;
      this.class954_0.SectionsMapId = (ulong) page.Id;
      this.class954_0.SectionsMap2Id = (ulong) class442.Id;
    }

    private void method_17(Class504 section, Class889 byteStream)
    {
      byteStream.vmethod_15(section.DataSize);
      byteStream.vmethod_15(section.MaxDecompressedPageSize);
      byteStream.vmethod_15(section.Encrypted);
      byteStream.vmethod_15(section.HashCode);
      ulong num = (ulong) section.Name.Length;
      if (num > 0UL)
        num = (ulong) ((long) num + 1L << 1);
      byteStream.vmethod_15(num);
      byteStream.vmethod_15(section.Unknown);
      byteStream.vmethod_15(section.Encoding);
      byteStream.vmethod_15(section.PageCount);
      if (num > 0UL)
      {
        byte[] bytes = Encoding.Unicode.GetBytes(section.Name);
        byteStream.Stream.Write(bytes, 0, bytes.Length);
        byteStream.vmethod_1((byte) 0);
        byteStream.vmethod_1((byte) 0);
      }
      foreach (Class443 page in section.Pages)
      {
        byteStream.vmethod_15(page.DataOffset);
        byteStream.vmethod_15(page.PageSize);
        byteStream.vmethod_13(page.Id);
        byteStream.vmethod_15(page.DecompressedSize);
        byteStream.vmethod_15(page.CompressedSize);
        byteStream.vmethod_15(page.CheckSum);
        byteStream.vmethod_15(page.Crc);
      }
    }

    private void method_18()
    {
      this.class442_0.StreamOffset = 0UL;
      ulong pageSize = this.method_19(this.list_1.Count);
      long num1 = (long) (this.list_1.Count + 1 + 2);
      if (pageSize <= 1024UL)
      {
        Class441 class441 = this.list_1[0];
        long num2 = num1;
        long num3 = num2 + 1L;
        class441.Id = num2;
        this.list_1[1].Id = num3;
        this.class954_0.PagesMapId = (ulong) this.list_1[0].Id;
        this.class954_0.PagesMapOffset = this.list_1[0].StreamOffset;
        this.class954_0.PagesMap2Id = (ulong) this.list_1[1].Id;
        this.class954_0.PagesMap2Offset = this.list_1[1].StreamOffset;
      }
      else
      {
        Class441 class441_1 = this.list_1[0];
        long num2 = num1;
        long num3 = num2 + 1L;
        long num4 = -num2;
        class441_1.Id = num4;
        Class441 class441_2 = this.list_1[1];
        long num5 = num3;
        long num6 = num5 + 1L;
        long num7 = -num5;
        class441_2.Id = num7;
        uint num8 = (uint) (this.stream_0.Position - 1152L);
        Class442 class442_1 = new Class442();
        Class442 class442_2 = class442_1;
        long num9 = num6;
        long num10 = num9 + 1L;
        class442_2.Id = num9;
        class442_1.StreamOffset = (ulong) (num8 - 1152U);
        this.list_1.Add((Class441) class442_1);
        Class442 class442_3 = new Class442();
        class442_3.Id = num10;
        class442_3.StreamOffset = (ulong) ((long) num8 + (long) pageSize - 1152L);
        this.list_1.Add((Class441) class442_3);
      }
      this.class954_0.PagesMaxId = 0UL;
      this.class954_0.PageCount = (ulong) (uint) this.list_1.Count;
      this.class954_0.PagesMapOffset = this.class442_0.StreamOffset;
      MemoryStream sectionStream = new MemoryStream();
      Class889 class889 = Class889.Create((Stream) sectionStream, this.dxfVersion_0, this.encoding_0);
      foreach (Class441 class441 in this.list_1)
      {
        if (class441 != null)
        {
          class889.vmethod_13(class441.Length);
          class889.vmethod_13(class441.Id);
          if (class441.Id > (long) this.class954_0.PagesMaxId)
            this.class954_0.PagesMaxId = (ulong) class441.Id;
        }
      }
      byte[] pageData;
      this.method_20(this.class442_0, sectionStream, this.class954_0.PagesMapCrcSeed, pageSize, out pageData);
      this.class442_0.Length = (long) pageData.Length;
      long id = this.class442_1.Id;
      this.class442_1.CopyFrom(this.class442_0);
      this.class442_1.Id = id;
      this.class442_1.StreamOffset = 1024UL;
      this.stream_0.Position = (long) this.class954_0.PagesMapOffset + 1152L;
      this.stream_0.Write(pageData, 0, pageData.Length);
      this.stream_0.Position = (long) this.class954_0.PagesMap2Offset + 1152L;
      this.stream_0.Write(pageData, 0, pageData.Length);
      this.class954_0.PagesMapDataRepeatCount = this.class442_0.DataRepeatCount;
      this.class954_0.PagesMapSizeCompressed = this.class442_0.CompressedSize;
      this.class954_0.PagesMapSizeDecompressed = this.class442_0.DecompressedSize;
      this.class954_0.PagesMapCrcCompressed = this.class442_0.CompressedCrc;
      this.class954_0.PagesMapCrcDecompressed = this.class442_0.DecompressedCrc;
    }

    private ulong method_19(int pageCount)
    {
      return Class996.smethod_2((ulong) (pageCount + 5) * 16UL);
    }

    private unsafe void method_20(
      Class442 page,
      MemoryStream sectionStream,
      ulong crcSeed,
      ulong pageSize,
      out byte[] pageData)
    {
      page.CrcSeed = crcSeed;
      page.DecompressedSize = (ulong) sectionStream.Length;
      page.DecompressedCrc = Class656.class656_1.method_0(sectionStream.GetBuffer(), 0U, (uint) sectionStream.Length, Class656.smethod_0(crcSeed, (uint) sectionStream.Length));
      MemoryStream memoryStream = new MemoryStream();
      new Class955().method_1(sectionStream.GetBuffer(), 0, (int) sectionStream.Length, (Stream) memoryStream);
      if (memoryStream.Length >= sectionStream.Length)
        memoryStream = sectionStream;
      page.CompressedSize = (ulong) memoryStream.Length;
      page.CompressedCrc = Class656.class656_1.method_0(memoryStream.GetBuffer(), 0U, (uint) memoryStream.Length, Class656.smethod_0(crcSeed, (uint) memoryStream.Length));
      ulong num1 = (ulong) (memoryStream.Length + 8L - 1L & -8L);
      int num2 = (int) ((long) num1 - memoryStream.Length);
      for (int index = 0; index < num2; ++index)
        memoryStream.WriteByte((byte) 0);
      ulong num3 = pageSize / (ulong) byte.MaxValue;
      ulong num4 = num3 * (ulong) Class746.class746_0.K;
      page.DataRepeatCount = num4 / num1;
      for (int index = 1; index < (int) page.DataRepeatCount; ++index)
        memoryStream.Write(memoryStream.GetBuffer(), 0, (int) num1);
      pageData = new byte[pageSize];
      fixed (byte* source = memoryStream.GetBuffer())
        fixed (byte* destination = pageData)
        {
          uint num5 = (uint) (this.method_28(destination, source, (int) memoryStream.Length, Class746.class746_0) * (int) byte.MaxValue);
          byte* pagePtr = destination + (int) num5;
          uint num6 = (uint) num3 * (uint) byte.MaxValue;
          uint num7 = num6 - num5;
          for (int index = 0; (long) index < (long) num7; ++index)
            *pagePtr++ = (byte) 0;
          uint paddingSize = (uint) pageSize - num6;
          this.method_24(pagePtr, paddingSize);
          if (pagePtr + (int) paddingSize - destination != (long) pageSize)
            throw new Exception();
        }
    }

    private void method_21(Class504 section)
    {
      section.DataSize = (ulong) section.Stream.Length;
      ulong num = (ulong) section.Stream.Length / section.MaxDecompressedPageSize;
      byte[] buffer = section.Stream.GetBuffer();
      section.Stream.Dispose();
      section.Stream = (MemoryStream) null;
      ulong position = 0;
      for (int index = 0; index < (int) num; ++index)
      {
        this.method_22(section, buffer, position, section.MaxDecompressedPageSize);
        position += section.MaxDecompressedPageSize;
      }
      ulong uncompressedLength = section.DataSize % section.MaxDecompressedPageSize;
      if (uncompressedLength > 0UL)
      {
        this.method_22(section, buffer, position, uncompressedLength);
        ++num;
      }
      section.PageCount = num;
    }

    private unsafe void method_22(
      Class504 section,
      byte[] buffer,
      ulong position,
      ulong uncompressedLength)
    {
      Class443 class443 = new Class443();
      class443.PageSize = section.MaxDecompressedPageSize;
      class443.DataOffset = position;
      class443.DecompressedSize = uncompressedLength;
      class443.CheckSum = (ulong) Class996.smethod_3((ulong) this.uint_0, buffer, (uint) position, (uint) uncompressedLength);
      Class746 class7461 = Class746.class746_1;
      MemoryStream memoryStream = new MemoryStream();
      if (section.Compressed)
      {
        new Class955().method_1(buffer, (int) position, (int) uncompressedLength, (Stream) memoryStream);
        if (memoryStream.Length >= (long) uncompressedLength)
        {
          memoryStream = new MemoryStream();
          memoryStream.Write(buffer, (int) position, (int) uncompressedLength);
        }
      }
      else
        memoryStream.Write(buffer, (int) position, (int) uncompressedLength);
      class443.CompressedSize = (ulong) memoryStream.Length;
      class443.Crc = Class656.class656_1.method_0(memoryStream.GetBuffer(), 0U, (uint) memoryStream.Length, Class656.smethod_0((ulong) this.uint_0, (uint) memoryStream.Length));
      ulong num1 = (ulong) (memoryStream.Length + 8L - 1L & -8L);
      int num2 = (int) ((ulong) ((long) num1 + (long) class7461.K - 1L) / (ulong) class7461.K);
      byte[] data;
      if (section.Encoding == 4UL)
      {
        data = new byte[(long) num2 * (long) class7461.N];
        int num3 = (int) ((long) num1 - memoryStream.Length);
        for (int index = 0; index < num3; ++index)
          memoryStream.WriteByte((byte) 0);
        fixed (byte* destination = data)
          fixed (byte* source = memoryStream.GetBuffer())
            this.method_28(destination, source, (int) memoryStream.Length, class7461);
      }
      else
      {
        if (section.Encoding != 1UL)
          throw new Exception();
        uint num3 = (uint) (num1 - (ulong) memoryStream.Length);
        for (uint index = 0; index < num3; ++index)
          memoryStream.WriteByte((byte) 0);
        data = new byte[num1 + (ulong) num2 * (ulong) (class7461.N - class7461.K)];
        fixed (byte* dataBufferPtr = data)
          fixed (byte* sourcePtr = memoryStream.GetBuffer())
            this.method_26(dataBufferPtr, dataBufferPtr + num1, sourcePtr, (int) memoryStream.Length, class7461);
      }
      this.method_23((Class441) class443, data, 0, data.Length);
      if (class443.Id > 0L)
        ++section.PageCount;
      section.Pages.Add(class443);
    }

    private void method_23(Class441 page, byte[] data, int offset, int length)
    {
      if (this.stream_0.Position % 32L != 0L)
        throw new Exception();
      long position = this.stream_0.Position;
      page.Id = (long) (this.list_1.Count + 1);
      page.StreamOffset = (ulong) (position - 1152L);
      this.stream_0.Write(data, offset, length);
      this.method_25(this.stream_0, (uint) (((ulong) (length + 32 - 1) & 18446744073709551584UL) - (ulong) length));
      page.Length = this.stream_0.Position - position;
      this.list_1.Add(page);
    }

    private unsafe void method_24(byte* pagePtr, uint paddingSize)
    {
      fixed (byte* numPtr1 = this.class995_0.Padding)
      {
        byte* numPtr2 = numPtr1;
        for (int index = 0; (long) index < (long) paddingSize; ++index)
          *pagePtr++ = *numPtr2++;
      }
    }

    private unsafe void method_25(Stream stream, uint paddingSize)
    {
      fixed (byte* numPtr1 = this.class995_0.Padding)
      {
        byte* numPtr2 = numPtr1;
        for (int index = 0; (long) index < (long) paddingSize; ++index)
          stream.WriteByte(*numPtr2++);
      }
    }

    private unsafe void method_26(
      byte* dataBufferPtr,
      byte* parityBufferPtr,
      byte* sourcePtr,
      int length,
      Class746 rsEncoding)
    {
      byte* numPtr1 = sourcePtr;
      for (int index = 0; index < length; ++index)
        *dataBufferPtr++ = *numPtr1++;
      while ((long) length >= (long) rsEncoding.K)
      {
        this.method_27(ref parityBufferPtr, sourcePtr, rsEncoding);
        length -= (int) rsEncoding.K;
        sourcePtr += (int) rsEncoding.K;
      }
      if (length <= 0)
        return;
      fixed (byte* sourcePtr1 = new byte[(IntPtr) rsEncoding.K])
      {
        byte* numPtr2 = sourcePtr1;
        int num;
        for (num = 0; num < length; ++num)
          *numPtr2++ = *sourcePtr++;
        fixed (byte* numPtr3 = this.class995_0.Padding)
        {
          byte* numPtr4 = numPtr3;
          while ((long) num++ < (long) rsEncoding.K)
            *numPtr2++ = *numPtr4++;
        }
        this.method_27(ref parityBufferPtr, sourcePtr1, rsEncoding);
      }
    }

    private unsafe void method_27(ref byte* parityBufferPtr, byte* sourcePtr, Class746 rsEncoding)
    {
      rsEncoding.method_1(sourcePtr, parityBufferPtr);
      parityBufferPtr += (int) rsEncoding.N - (int) rsEncoding.K;
    }

    private unsafe int method_28(byte* destination, byte* source, int length, Class746 rsEncoding)
    {
      int blockCount = (int) (((long) length + (long) rsEncoding.K - 1L) / (long) rsEncoding.K);
      while ((long) length >= (long) rsEncoding.K)
      {
        this.method_29(destination++, source, blockCount, rsEncoding);
        length -= (int) rsEncoding.K;
        source += (int) rsEncoding.K;
      }
      if (length > 0)
      {
        fixed (byte* source1 = new byte[(IntPtr) rsEncoding.K])
        {
          byte* numPtr1 = source1;
          int num;
          for (num = 0; num < length; ++num)
            *numPtr1++ = *source++;
          fixed (byte* numPtr2 = this.class995_0.Padding)
          {
            byte* numPtr3 = numPtr2;
            while ((long) num++ < (long) rsEncoding.K)
              *numPtr1++ = *numPtr3++;
          }
          this.method_29(destination, source1, blockCount, rsEncoding);
        }
      }
      return blockCount;
    }

    private unsafe void method_29(
      byte* destination,
      byte* source,
      int blockCount,
      Class746 rsEncoding)
    {
      byte* numPtr1 = source;
      for (int index = (int) rsEncoding.K - 1; index >= 0; --index)
      {
        *destination = *numPtr1++;
        destination += blockCount;
      }
      byte[] numArray = new byte[(IntPtr) (rsEncoding.N - rsEncoding.K)];
      fixed (byte* parityBytesPtr = numArray)
      {
        rsEncoding.method_1(source, parityBytesPtr);
        byte* numPtr2 = parityBytesPtr;
        int length = numArray.Length;
        for (int index = 0; index < length; ++index)
        {
          *destination = *numPtr2++;
          destination += blockCount;
        }
      }
    }
  }
}
