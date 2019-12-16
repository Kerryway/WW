// Decompiled with JetBrains decompiler
// Type: ns28.Class653
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WW;
using WW.Cad.Model;
using WW.Text;

namespace ns28
{
  internal class Class653
  {
    private List<Class991> list_0 = new List<Class991>();
    private List<Class723> list_1 = new List<Class723>();
    private int int_0 = 6;
    private DxfModel dxfModel_0;
    private DxfVersion dxfVersion_0;
    private Stream stream_0;
    private Encoding encoding_0;
    private MemoryStream memoryStream_0;
    private Class723 class723_0;
    private MemoryStream memoryStream_1;
    private Class723 class723_1;
    private MemoryStream memoryStream_2;
    private Class723 class723_2;
    private MemoryStream memoryStream_3;
    private MemoryStream memoryStream_4;
    private Class723 class723_3;
    private MemoryStream memoryStream_5;
    private Class723 class723_4;
    private MemoryStream memoryStream_6;
    private Class723 class723_5;
    private MemoryStream memoryStream_7;
    private Class723 class723_6;
    private MemoryStream memoryStream_8;
    private Class723 class723_7;
    private MemoryStream memoryStream_9;
    private Class723 class723_8;

    public Class653(Stream stream, DxfModel model)
    {
      if (!stream.CanSeek || !stream.CanWrite)
        throw new ArgumentException("Stream must allow writing and seeking.");
      this.dxfModel_0 = model;
      this.stream_0 = stream;
      this.dxfVersion_0 = model.Header.AcadVersion;
      this.encoding_0 = Encodings.GetEncoding((int) model.Header.DrawingCodePage);
    }

    public static void Write(Stream stream, DxfModel model)
    {
      new Class653(stream, model).Write();
    }

    public void Write()
    {
      Class1030 knownClasses = new Class1030(this.dxfModel_0);
      this.method_0();
      this.method_1();
      this.method_7();
      this.method_8();
      this.method_9();
      this.method_10(knownClasses);
      long num1 = Class653.smethod_0(this.int_0);
      long num2 = 0;
      if (this.memoryStream_0 != null)
        num2 = this.memoryStream_0.Length;
      this.method_11((int) (num1 + num2 + this.memoryStream_4.Length + this.memoryStream_1.Length + this.memoryStream_2.Length));
      this.method_2();
      this.method_4();
      this.method_5();
      this.method_6();
      this.method_12();
      this.method_15();
      this.stream_0.Flush();
    }

    private void method_0()
    {
      this.memoryStream_0 = new MemoryStream();
      new Class993(this.memoryStream_0, this.dxfModel_0, this.encoding_0).Write();
    }

    private void method_1()
    {
      this.memoryStream_1 = new MemoryStream();
      new Class886((Stream) this.memoryStream_1, this.dxfModel_0).Write();
    }

    private void method_2()
    {
      int position = (int) Class653.smethod_0(this.int_0);
      this.class723_0 = this.method_3(new int?(5), ref position, this.memoryStream_0);
      this.class723_3 = this.method_3(new int?(), ref position, this.memoryStream_4);
      this.class723_1 = this.method_3(new int?(0), ref position, this.memoryStream_1);
      this.class723_2 = this.method_3(new int?(1), ref position, this.memoryStream_2);
      this.class723_4 = this.method_3(new int?(), ref position, this.memoryStream_5);
      this.class723_5 = this.method_3(new int?(2), ref position, this.memoryStream_6);
      this.class723_6 = this.method_3(new int?(), ref position, this.memoryStream_7);
      this.class723_7 = this.method_3(new int?(3), ref position, this.memoryStream_8);
      this.class723_8 = this.method_3(new int?(4), ref position, this.memoryStream_9);
    }

    private Class723 method_3(int? sectionId, ref int position, MemoryStream stream)
    {
      Class723 class723 = new Class723(sectionId, position, stream);
      this.list_1.Add(class723);
      if (stream != null)
        position += (int) stream.Length;
      return class723;
    }

    private void method_4()
    {
      this.memoryStream_7 = new MemoryStream();
      new Class654((Stream) this.memoryStream_7, this.dxfModel_0, this.list_1).Write();
      this.class723_6.Stream = this.memoryStream_7;
    }

    private void method_5()
    {
      this.memoryStream_8 = new MemoryStream();
      this.class723_7.Stream = this.memoryStream_8;
    }

    private void method_6()
    {
      this.memoryStream_9 = new MemoryStream();
      Class501.Write(Class889.Create((Stream) this.memoryStream_9, this.dxfVersion_0, this.encoding_0), this.dxfModel_0);
      this.class723_8.Stream = this.memoryStream_9;
    }

    private void method_7()
    {
      this.memoryStream_2 = new MemoryStream();
      new Class1033((Stream) this.memoryStream_2, this.dxfModel_0).Write();
    }

    private void method_8()
    {
      this.memoryStream_3 = new MemoryStream();
    }

    private void method_9()
    {
      this.memoryStream_4 = new MemoryStream();
      new Class328((Stream) this.memoryStream_4, this.dxfModel_0).Write();
    }

    private void method_10(Class1030 knownClasses)
    {
      this.memoryStream_5 = new MemoryStream();
      Class432 class432 = new Class432((Stream) this.memoryStream_5, this.dxfModel_0, knownClasses);
      class432.Write();
      this.list_0 = class432.HandleAndStreamPositionList;
    }

    private void method_11(int objectDataStreamOffset)
    {
      this.memoryStream_6 = new MemoryStream();
      new Class655(this.memoryStream_6, this.dxfModel_0, this.list_0, objectDataStreamOffset).Write();
    }

    private void method_12()
    {
      int sectionStartPosition1 = (int) Class653.smethod_0(this.int_0);
      int num1 = sectionStartPosition1 + (int) this.memoryStream_0.Length;
      int sectionStartPosition2 = num1 + (int) this.memoryStream_4.Length;
      int sectionStartPosition3 = sectionStartPosition2 + (int) this.memoryStream_1.Length;
      int sectionStartPosition4 = sectionStartPosition3 + (int) this.memoryStream_2.Length + (int) this.memoryStream_3.Length + (int) this.memoryStream_5.Length;
      int sectionStartPosition5 = sectionStartPosition4 + (int) this.memoryStream_6.Length + (int) this.memoryStream_7.Length;
      MemoryStream memoryStream = new MemoryStream();
      Interface29 streamWriter = Class724.Create(this.dxfVersion_0, (Stream) memoryStream, Encodings.GetEncoding((int) this.dxfModel_0.Header.DrawingCodePage));
      streamWriter.imethod_13(Encodings.Ascii.GetBytes(this.dxfModel_0.Header.AcadVersionString), 0, 6);
      Interface29 nterface29 = streamWriter;
      byte[] numArray = new byte[7];
      numArray[5] = (byte) 15;
      numArray[6] = (byte) 1;
      byte[] bytes = numArray;
      nterface29.imethod_12(bytes);
      streamWriter.imethod_19(num1);
      streamWriter.imethod_11((byte) 27);
      streamWriter.imethod_11((byte) 25);
      int num2 = (int) Class952.smethod_1(this.dxfModel_0.Header.DrawingCodePage);
      streamWriter.imethod_13(LittleEndianBitConverter.GetBytes((short) num2), 0, 2);
      streamWriter.imethod_13(LittleEndianBitConverter.GetBytes(this.int_0), 0, 4);
      long position = this.stream_0.Position;
      this.method_13(streamWriter, (byte) 0, sectionStartPosition2, (int) this.memoryStream_1.Length);
      this.method_13(streamWriter, (byte) 1, sectionStartPosition3, (int) this.memoryStream_2.Length);
      this.method_13(streamWriter, (byte) 2, sectionStartPosition4, (int) this.memoryStream_6.Length);
      this.method_13(streamWriter, (byte) 3, 0, 0);
      this.method_13(streamWriter, (byte) 4, sectionStartPosition5, (int) this.memoryStream_9.Length);
      this.method_13(streamWriter, (byte) 5, sectionStartPosition1, (int) this.memoryStream_0.Length);
      streamWriter.Flush();
      ushort num3 = Stream1.smethod_1((ushort) 49345, memoryStream.GetBuffer(), 0L, memoryStream.Length);
      streamWriter.imethod_18((short) num3);
      streamWriter.imethod_13(Class800.byte_4, 0, Class800.byte_4.Length);
      this.stream_0.Write(memoryStream.GetBuffer(), 0, (int) memoryStream.Length);
    }

    private static long smethod_0(int sectionCount)
    {
      return (long) (25 + sectionCount * 9 + 2 + 16);
    }

    private void method_13(
      Interface29 streamWriter,
      byte sectionNumber,
      int sectionStartPosition,
      int sectionSize)
    {
      streamWriter.imethod_11(sectionNumber);
      streamWriter.imethod_19(sectionStartPosition);
      streamWriter.imethod_19(sectionSize);
    }

    private void method_14(MemoryStream memoryStream)
    {
      this.stream_0.Write(memoryStream.GetBuffer(), 0, (int) memoryStream.Length);
    }

    private void method_15()
    {
      foreach (Class723 class723 in this.list_1)
        this.method_14(class723.Stream);
    }
  }
}
