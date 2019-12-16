// Decompiled with JetBrains decompiler
// Type: ns7.Class951
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns9;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WW.Math;
using WW.Text;

namespace ns7
{
  internal class Class951 : Interface6, Interface7, Interface8
  {
    private static readonly string[] string_0 = new string[1]{ "" };
    public const char char_0 = '-';
    private readonly Interface6 interface6_0;
    private readonly Interface7 interface7_0;
    private readonly int int_0;
    private readonly MemoryStream memoryStream_0;
    private Interface8 interface8_0;

    internal Class951(
      Interface6 resolver,
      Interface7 subResolver,
      int version,
      MemoryStream stream)
    {
      this.interface7_0 = subResolver;
      this.interface6_0 = resolver;
      this.int_0 = version;
      this.memoryStream_0 = stream;
    }

    private static Interface8 smethod_0(
      Interface6 resolver,
      Interface7 subResolver,
      int version,
      MemoryStream stream)
    {
      int num = Class1045.smethod_7((Stream) stream);
      string empty = string.Empty;
      for (int index = 0; index < num; ++index)
        empty += (string) (object) (char) stream.ReadByte();
      Class251.Class254 marker = new Class251.Class254(empty);
      if (version < Class250.int_7)
        return (Interface8) new Class251(resolver, subResolver, version, marker);
      if (version < Class250.int_63)
        return (Interface8) new Class252(resolver, subResolver, version, marker);
      return (Interface8) new Class253(resolver, subResolver, version, marker);
    }

    protected void method_0()
    {
      this.interface8_0 = Class951.smethod_0(this.interface6_0, this.interface7_0, this.int_0, this.memoryStream_0);
    }

    protected void method_1()
    {
      this.interface8_0 = (Interface8) null;
    }

    protected bool method_2()
    {
      return this.interface8_0 != null;
    }

    protected virtual Interface8 vmethod_0(
      Interface6 entityResolver,
      Interface7 subEntityResolver,
      int fileFormatVersion,
      MemoryStream inputStream)
    {
      return (Interface8) new Class951(entityResolver, subEntityResolver, fileFormatVersion, inputStream);
    }

    public virtual int imethod_4(int defaultNumber)
    {
      return defaultNumber;
    }

    public virtual void imethod_17(Class987 header)
    {
      header.NumberOfRecords = Class1045.smethod_7((Stream) this.memoryStream_0);
      header.EntityCount = Class1045.smethod_7((Stream) this.memoryStream_0);
      int num = Class1045.smethod_7((Stream) this.memoryStream_0);
      header.HistorySaved = num != 0;
      if (this.int_0 < Class250.int_28)
        return;
      header.Product = this.ReadString();
      header.AcisVersion = this.ReadString();
      header.method_0(this.ReadString());
      header.MmPerUnit = this.imethod_8();
      header.AbsoluteResolution = this.imethod_8();
      header.NormalResolution = this.imethod_8();
    }

    public virtual Point3D imethod_18()
    {
      Point3D point3D = new Point3D();
      if (!this.method_2())
      {
        Class951.Enum41 enum41 = (Class951.Enum41) this.memoryStream_0.ReadByte();
        if (Class951.Enum41.const_19 == enum41)
        {
          point3D.X = Class1045.smethod_8((Stream) this.memoryStream_0);
          point3D.Y = Class1045.smethod_8((Stream) this.memoryStream_0);
          point3D.Z = Class1045.smethod_8((Stream) this.memoryStream_0);
        }
        else
        {
          if (Class951.Enum41.const_18 != enum41)
            throw new Exception0("Position type requested");
          this.method_0();
        }
      }
      if (this.method_2())
        point3D = this.interface8_0.imethod_18();
      return point3D;
    }

    public virtual Vector3D imethod_19()
    {
      Vector3D vector3D = new Vector3D();
      if (!this.method_2())
      {
        Class951.Enum41 enum41 = (Class951.Enum41) this.memoryStream_0.ReadByte();
        if (Class951.Enum41.const_20 == enum41)
        {
          vector3D.X = Class1045.smethod_8((Stream) this.memoryStream_0);
          vector3D.Y = Class1045.smethod_8((Stream) this.memoryStream_0);
          vector3D.Z = Class1045.smethod_8((Stream) this.memoryStream_0);
        }
        else
        {
          if (Class951.Enum41.const_18 != enum41)
            throw new Exception0("Vector type requested");
          this.method_0();
        }
      }
      if (this.method_2())
        vector3D = this.interface8_0.imethod_19();
      return vector3D;
    }

    public virtual int imethod_5()
    {
      try
      {
        if (!this.method_2())
        {
          Class951.Enum41 enum41 = (Class951.Enum41) this.memoryStream_0.ReadByte();
          if (Class951.Enum41.const_4 == enum41)
            return Class1045.smethod_7((Stream) this.memoryStream_0);
          if (Class951.Enum41.const_18 == enum41)
            this.method_0();
        }
        if (!this.method_2())
          throw new Exception0("Broken long value!");
        return this.interface8_0.imethod_5();
      }
      catch (FormatException ex)
      {
        throw new Exception0("Broken integer number!", (Exception) ex);
      }
    }

    public virtual int imethod_7()
    {
      try
      {
        if (!this.method_2())
        {
          Class951.Enum41 enum41 = (Class951.Enum41) this.memoryStream_0.ReadByte();
          if (Class951.Enum41.const_12 == enum41)
            return Class1045.smethod_7((Stream) this.memoryStream_0);
          if (Class951.Enum41.const_18 == enum41)
            this.method_0();
        }
        if (!this.method_2())
          throw new Exception0("Broken pointer value!");
        return this.interface8_0.imethod_7();
      }
      catch (FormatException ex)
      {
        throw new Exception0("Broken pointer number!", (Exception) ex);
      }
    }

    public virtual double imethod_8()
    {
      try
      {
        if (!this.method_2())
        {
          Class951.Enum41 enum41 = (Class951.Enum41) this.memoryStream_0.ReadByte();
          if (Class951.Enum41.const_6 == enum41)
            return Class1045.smethod_8((Stream) this.memoryStream_0);
          if (Class951.Enum41.const_18 == enum41)
            this.method_0();
        }
        if (!this.method_2())
          throw new Exception0("Broken double value!");
        return this.interface8_0.imethod_8();
      }
      catch (FormatException ex)
      {
        throw new Exception0("Broken double value!", (Exception) ex);
      }
    }

    public virtual void imethod_10()
    {
      try
      {
        if (!this.method_2())
        {
          Class951.Enum41 enum41 = (Class951.Enum41) this.memoryStream_0.ReadByte();
          if (Class951.Enum41.const_15 != enum41)
          {
            if (Class951.Enum41.const_18 != enum41)
              throw new Exception0("Broken subtype marker");
            this.method_0();
          }
        }
        if (!this.method_2())
          return;
        this.interface8_0.imethod_10();
      }
      catch (FormatException ex)
      {
        throw new Exception0("Broken subtype marker", (Exception) ex);
      }
    }

    public virtual void imethod_6()
    {
    }

    public virtual void imethod_9()
    {
      try
      {
        if (!this.method_2())
        {
          Class951.Enum41 enum41 = (Class951.Enum41) this.memoryStream_0.ReadByte();
          if (Class951.Enum41.const_16 != enum41)
          {
            if (Class951.Enum41.const_18 != enum41)
              throw new Exception0("Broken subtype end marker");
            this.method_0();
          }
        }
        if (!this.method_2())
          return;
        this.interface8_0.imethod_9();
      }
      catch (FormatException ex)
      {
        throw new Exception0("Broken subtype end marker", (Exception) ex);
      }
    }

    public virtual string ReadString()
    {
      try
      {
        switch ((Class951.Enum41) this.memoryStream_0.ReadByte())
        {
          case Class951.Enum41.const_7:
            byte num1 = (byte) this.memoryStream_0.ReadByte();
            byte[] numArray1 = new byte[(int) num1];
            this.memoryStream_0.Read(numArray1, 0, (int) num1);
            return Encodings.Ascii.GetString(numArray1, 0, numArray1.Length);
          case Class951.Enum41.const_8:
            short num2 = Class1045.smethod_3((Stream) this.memoryStream_0);
            byte[] numArray2 = new byte[(int) num2];
            this.memoryStream_0.Read(numArray2, 0, (int) num2);
            return Encodings.Ascii.GetString(numArray2, 0, numArray2.Length);
          case Class951.Enum41.const_9:
            int count1 = Class1045.smethod_7((Stream) this.memoryStream_0);
            byte[] numArray3 = new byte[count1];
            this.memoryStream_0.Read(numArray3, 0, count1);
            return Encodings.Ascii.GetString(numArray3, 0, numArray3.Length);
          case Class951.Enum41.const_18:
            int count2 = Class1045.smethod_7((Stream) this.memoryStream_0);
            byte[] numArray4 = new byte[count2];
            this.memoryStream_0.Read(numArray4, 0, count2);
            return Encodings.Ascii.GetString(numArray4, 0, numArray4.Length);
          default:
            throw new Exception0("String broken!");
        }
      }
      catch (FormatException ex)
      {
        throw new Exception0("String length broken!", (Exception) ex);
      }
    }

    public virtual void imethod_13(Interface39 values)
    {
      if (!this.method_2())
      {
        Class951.Enum41 enum41 = (Class951.Enum41) this.memoryStream_0.ReadByte();
        if (Class951.Enum41.const_18 == enum41)
          this.method_0();
        else if (Class951.Enum41.const_4 == enum41)
        {
          int num = Class1045.smethod_7((Stream) this.memoryStream_0);
          if (num != 0 || num != 1)
            throw new Exception0("Logical value broken");
          values.Value = num != 0;
        }
        else if (Class951.Enum41.const_10 == enum41)
        {
          values.Value = true;
        }
        else
        {
          if (Class951.Enum41.const_11 != enum41)
            throw new Exception0("Logical value broken");
          values.Value = false;
        }
      }
      if (!this.method_2())
        return;
      this.interface8_0.imethod_13(values);
    }

    public virtual int imethod_12(string[] values, int[] indexes)
    {
      if (!this.method_2())
      {
        Class951.Enum41 enum41 = (Class951.Enum41) this.memoryStream_0.ReadByte();
        if (Class951.Enum41.const_18 == enum41)
          this.method_0();
        else if (Class951.Enum41.const_21 == enum41)
        {
          int num = Class1045.smethod_7((Stream) this.memoryStream_0);
          if (indexes != null)
          {
            for (int index = indexes.Length - 1; index >= 0; --index)
            {
              if (num == indexes[index])
                return num;
            }
          }
          else if (num >= 0 && num < values.Length)
            return num;
        }
      }
      if (!this.method_2())
        throw new Exception0("Enum value broken");
      return this.interface8_0.imethod_12(values, indexes);
    }

    public virtual int imethod_11(string[] values)
    {
      return this.imethod_12(values, (int[]) null);
    }

    public virtual string imethod_14()
    {
      Class951.Enum41 enum41 = (Class951.Enum41) this.memoryStream_0.ReadByte();
      if (Class951.Enum41.const_13 != enum41 && Class951.Enum41.const_14 != enum41)
        throw new Exception0("Broken ReadKeyword!");
      StringBuilder stringBuilder = new StringBuilder((int) byte.MaxValue);
      byte num1 = (byte) this.memoryStream_0.ReadByte();
      byte[] numArray1 = new byte[(int) num1];
      this.memoryStream_0.Read(numArray1, 0, (int) num1);
      stringBuilder.Append(Encodings.Ascii.GetString(numArray1, 0, numArray1.Length));
      while (enum41 == Class951.Enum41.const_14)
      {
        long position = this.memoryStream_0.Position;
        enum41 = (Class951.Enum41) this.memoryStream_0.ReadByte();
        byte num2 = (byte) this.memoryStream_0.ReadByte();
        byte[] numArray2 = new byte[(int) num2];
        this.memoryStream_0.Read(numArray2, 0, (int) num2);
        stringBuilder.Append('-');
        stringBuilder.Append(Encodings.Ascii.GetString(numArray2, 0, numArray2.Length));
      }
      return stringBuilder.ToString();
    }

    public virtual bool imethod_15(ref List<Class561> unknownData)
    {
      Class951.Enum41 type;
      do
      {
        long position = this.memoryStream_0.Position;
        type = (Class951.Enum41) this.memoryStream_0.ReadByte();
        this.memoryStream_0.Seek(position, SeekOrigin.Begin);
        switch (type)
        {
          case Class951.Enum41.const_0:
            this.memoryStream_0.ReadByte();
            goto case Class951.Enum41.const_17;
          case Class951.Enum41.const_1:
          case Class951.Enum41.const_2:
          case Class951.Enum41.const_3:
          case Class951.Enum41.const_5:
          case Class951.Enum41.const_15:
          case Class951.Enum41.const_16:
            goto label_13;
          case Class951.Enum41.const_4:
            unknownData.Add((Class561) new Class562<long>(type, (long) this.imethod_5()));
            goto case Class951.Enum41.const_17;
          case Class951.Enum41.const_6:
            unknownData.Add((Class561) new Class562<double>(type, this.imethod_8()));
            goto case Class951.Enum41.const_17;
          case Class951.Enum41.const_7:
          case Class951.Enum41.const_8:
          case Class951.Enum41.const_9:
          case Class951.Enum41.const_18:
            unknownData.Add((Class561) new Class562<string>(type, this.ReadString()));
            goto case Class951.Enum41.const_17;
          case Class951.Enum41.const_10:
          case Class951.Enum41.const_11:
            unknownData.Add((Class561) new Class562<int>(type, this.memoryStream_0.ReadByte()));
            goto case Class951.Enum41.const_17;
          case Class951.Enum41.const_12:
            unknownData.Add((Class561) new Class562<int>(type, this.imethod_7()));
            goto case Class951.Enum41.const_17;
          case Class951.Enum41.const_13:
          case Class951.Enum41.const_14:
            StringBuilder stringBuilder = new StringBuilder((int) byte.MaxValue);
            byte num = (byte) this.memoryStream_0.ReadByte();
            byte[] numArray = new byte[(int) num];
            this.memoryStream_0.Read(numArray, 0, (int) num);
            unknownData.Add((Class561) new Class562<string>(type, Encodings.Ascii.GetString(numArray, 0, (int) num)));
            goto case Class951.Enum41.const_17;
          case Class951.Enum41.const_17:
            continue;
          case Class951.Enum41.const_19:
            unknownData.Add((Class561) new Class562<Point3D>(type, this.imethod_18()));
            goto case Class951.Enum41.const_17;
          case Class951.Enum41.const_20:
            unknownData.Add((Class561) new Class562<Vector3D>(type, this.imethod_19()));
            goto case Class951.Enum41.const_17;
          case Class951.Enum41.const_21:
            this.memoryStream_0.ReadByte();
            unknownData.Add((Class561) new Class562<int>(type, Class1045.smethod_7((Stream) this.memoryStream_0)));
            goto case Class951.Enum41.const_17;
          default:
            goto label_12;
        }
      }
      while (type != Class951.Enum41.const_17);
      goto label_14;
label_12:
      throw new Exception0("Unknown entity format broken");
label_13:
      throw new Exception0("Reading of unknown entities isn't implemented yet");
label_14:
      return false;
    }

    public virtual bool imethod_16(bool silentMode)
    {
      Class951.Enum41 enum41 = (Class951.Enum41) this.memoryStream_0.ReadByte();
      if (Class951.Enum41.const_17 != enum41)
      {
        if (!silentMode)
          throw new Exception0("Broken terminator!");
        if (enum41 == Class951.Enum41.const_12)
          Class1045.smethod_7((Stream) this.memoryStream_0);
        return false;
      }
      if (this.method_2())
        this.method_1();
      return true;
    }

    public virtual int FileFormatVersion
    {
      get
      {
        return this.int_0;
      }
    }

    public virtual Interface8 imethod_20()
    {
      return this.vmethod_0(this.interface6_0, this.interface7_0, this.int_0, this.memoryStream_0);
    }

    public ns9.Class80 this[int index]
    {
      get
      {
        return this.interface6_0[index];
      }
    }

    public void imethod_0(int index, Delegate10 binder)
    {
      this.interface6_0.imethod_0(index, binder);
    }

    public Class196 imethod_1(int index)
    {
      return this.interface7_0.imethod_1(index);
    }

    public void imethod_2(Class196 subEntity)
    {
      this.interface7_0.imethod_2(subEntity);
    }

    public int imethod_3(Class196 subEntity)
    {
      return -1;
    }

    public enum Enum41 : byte
    {
      const_0,
      const_1,
      const_2,
      const_3,
      const_4,
      const_5,
      const_6,
      const_7,
      const_8,
      const_9,
      const_10,
      const_11,
      const_12,
      const_13,
      const_14,
      const_15,
      const_16,
      const_17,
      const_18,
      const_19,
      const_20,
      const_21,
    }
  }
}
