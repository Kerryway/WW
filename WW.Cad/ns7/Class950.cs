// Decompiled with JetBrains decompiler
// Type: ns7.Class950
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns9;
using System.Collections.Generic;
using System.IO;
using WW.Math;
using WW.Text;

namespace ns7
{
  internal class Class950 : Interface6, Interface7, Interface9
  {
    private static readonly string[] string_0 = new string[1]{ "" };
    private readonly Interface6 interface6_0;
    private readonly Interface7 interface7_0;
    private readonly int int_0;
    private readonly MemoryStream memoryStream_0;

    internal Class950(
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

    protected virtual Interface9 vmethod_0(
      Interface6 entityResolver,
      Interface7 subEntityResolver,
      int fileFormatVersion,
      MemoryStream inputStream)
    {
      return (Interface9) new Class950(entityResolver, subEntityResolver, fileFormatVersion, inputStream);
    }

    public virtual void vmethod_1(int defaultNumber)
    {
    }

    public virtual void imethod_16(Class987 header)
    {
      Class1045.smethod_9((Stream) this.memoryStream_0, 0);
      Class1045.smethod_9((Stream) this.memoryStream_0, header.EntityCount);
      Class1045.smethod_9((Stream) this.memoryStream_0, this.int_0 != 21200 ? (this.int_0 != 21500 ? (this.int_0 != 21600 ? (this.int_0 != 21700 ? (this.int_0 != 21800 ? 0 : 12) : 4) : 8) : 24) : 26);
      if (this.int_0 < Class250.int_28)
        return;
      this.WriteString(header.Product);
      this.WriteString(header.AcisVersion);
      this.WriteString(header.method_1());
      this.imethod_7(header.MmPerUnit);
      this.imethod_7(header.AbsoluteResolution);
      this.imethod_7(header.NormalResolution);
    }

    public virtual void imethod_17(Point3D position)
    {
      this.memoryStream_0.WriteByte((byte) 19);
      Class1045.smethod_16((Stream) this.memoryStream_0, position.X);
      Class1045.smethod_16((Stream) this.memoryStream_0, position.Y);
      Class1045.smethod_16((Stream) this.memoryStream_0, position.Z);
    }

    public virtual void imethod_18(Vector3D vector)
    {
      this.memoryStream_0.WriteByte((byte) 20);
      Class1045.smethod_16((Stream) this.memoryStream_0, vector.X);
      Class1045.smethod_16((Stream) this.memoryStream_0, vector.Y);
      Class1045.smethod_16((Stream) this.memoryStream_0, vector.Z);
    }

    public virtual void imethod_4(int value)
    {
      this.memoryStream_0.WriteByte((byte) 4);
      Class1045.smethod_9((Stream) this.memoryStream_0, value);
    }

    public virtual void imethod_5(int value)
    {
      this.memoryStream_0.WriteByte((byte) 12);
      Class1045.smethod_9((Stream) this.memoryStream_0, value);
    }

    public virtual void imethod_6(ns9.Class80 entity)
    {
      this.memoryStream_0.WriteByte((byte) 12);
      if (entity == null)
        Class1045.smethod_9((Stream) this.memoryStream_0, -1);
      else
        Class1045.smethod_9((Stream) this.memoryStream_0, entity.Index);
    }

    public virtual void imethod_7(double value)
    {
      this.memoryStream_0.WriteByte((byte) 6);
      Class1045.smethod_16((Stream) this.memoryStream_0, value);
    }

    public virtual void imethod_9()
    {
      this.memoryStream_0.WriteByte((byte) 15);
    }

    public virtual void imethod_8()
    {
      this.memoryStream_0.WriteByte((byte) 16);
    }

    public virtual void WriteString(string value)
    {
      int length = value.Length;
      if (length <= (int) byte.MaxValue)
      {
        this.memoryStream_0.WriteByte((byte) 7);
        this.memoryStream_0.WriteByte((byte) length);
      }
      else if (length <= (int) ushort.MaxValue)
      {
        this.memoryStream_0.WriteByte((byte) 8);
        Class1045.smethod_4((Stream) this.memoryStream_0, (short) length);
      }
      else
      {
        this.memoryStream_0.WriteByte((byte) 9);
        Class1045.smethod_9((Stream) this.memoryStream_0, length);
      }
      this.memoryStream_0.Write(Encodings.Ascii.GetBytes(value), 0, value.Length);
    }

    public virtual void imethod_12(Interface39 values)
    {
      if (values.Value)
        this.memoryStream_0.WriteByte((byte) 10);
      else
        this.memoryStream_0.WriteByte((byte) 11);
    }

    public virtual void imethod_11(string[] values, int[] indexes, int value)
    {
      this.memoryStream_0.WriteByte((byte) 21);
      Class1045.smethod_9((Stream) this.memoryStream_0, value);
    }

    public virtual void imethod_10(string[] values, int value)
    {
      this.imethod_11(values, (int[]) null, value);
    }

    public virtual void imethod_13(string key)
    {
      if (key.Length == 0)
        throw new Exception0("Key length must be non zero");
      byte[] bytes = Encodings.Ascii.GetBytes(key);
      int num1 = key.IndexOf('-');
      int count1 = num1;
      if (num1 == -1)
      {
        count1 = key.Length;
        this.memoryStream_0.WriteByte((byte) 13);
      }
      else
        this.memoryStream_0.WriteByte((byte) 14);
      this.memoryStream_0.WriteByte((byte) count1);
      this.memoryStream_0.Write(bytes, 0, count1);
      while (num1 != -1)
      {
        int num2 = num1 + 1;
        num1 = key.IndexOf('-', num2);
        int count2;
        if (num1 == -1)
        {
          count2 = key.Length - num2;
          this.memoryStream_0.WriteByte((byte) 13);
        }
        else
        {
          count2 = num1 - num2;
          this.memoryStream_0.WriteByte((byte) 14);
        }
        this.memoryStream_0.WriteByte((byte) count2);
        this.memoryStream_0.Write(bytes, num2, count2);
      }
    }

    public virtual void imethod_14()
    {
      this.memoryStream_0.WriteByte((byte) 17);
    }

    public virtual void imethod_15()
    {
    }

    public virtual void imethod_19(List<Class561> unknownData, bool comesFromSat)
    {
      if (comesFromSat)
        throw new Exception0("Saving of unknown entities is not supported for SAT format.");
      foreach (Class561 class561 in unknownData)
      {
        Class951.Enum41 enum410 = class561.enum41_0;
        switch (enum410)
        {
          case Class951.Enum41.const_1:
          case Class951.Enum41.const_2:
          case Class951.Enum41.const_3:
          case Class951.Enum41.const_5:
          case Class951.Enum41.const_13:
          case Class951.Enum41.const_14:
          case Class951.Enum41.const_15:
          case Class951.Enum41.const_16:
            throw new Exception0("Writing of unknown entities isn't implemented yet");
          case Class951.Enum41.const_4:
            this.imethod_4((int) ((Class562<long>) class561).gparam_0);
            continue;
          case Class951.Enum41.const_6:
            this.imethod_7(((Class562<double>) class561).gparam_0);
            continue;
          case Class951.Enum41.const_7:
          case Class951.Enum41.const_8:
          case Class951.Enum41.const_9:
          case Class951.Enum41.const_18:
            this.WriteString(((Class562<string>) class561).gparam_0);
            continue;
          case Class951.Enum41.const_10:
          case Class951.Enum41.const_11:
            this.memoryStream_0.WriteByte((byte) enum410);
            continue;
          case Class951.Enum41.const_12:
            this.imethod_5(((Class562<int>) class561).gparam_0);
            continue;
          case Class951.Enum41.const_17:
            continue;
          case Class951.Enum41.const_19:
            this.imethod_17(((Class562<Point3D>) class561).gparam_0);
            continue;
          case Class951.Enum41.const_20:
            this.imethod_18(((Class562<Vector3D>) class561).gparam_0);
            continue;
          case Class951.Enum41.const_21:
            this.imethod_4(((Class562<int>) class561).gparam_0);
            continue;
          default:
            throw new Exception0("Saving of unknown entities is not supported for SAB format.");
        }
      }
    }

    public virtual int FileFormatVersion
    {
      get
      {
        return this.int_0;
      }
    }

    public virtual Interface9 imethod_20()
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

    public string SAT
    {
      get
      {
        return string.Empty;
      }
    }

    public Class196 imethod_1(int index)
    {
      return this.interface7_0.imethod_1(index);
    }

    public int imethod_3(Class196 subEntity)
    {
      return this.interface7_0.imethod_3(subEntity);
    }

    public void imethod_2(Class196 subEntity)
    {
      this.interface7_0.imethod_2(subEntity);
    }
  }
}
