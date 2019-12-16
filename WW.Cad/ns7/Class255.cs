// Decompiled with JetBrains decompiler
// Type: ns7.Class255
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns9;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using WW.Math;

namespace ns7
{
  internal class Class255 : Interface6, Interface7, Interface9
  {
    public const char char_0 = '-';
    private readonly Interface6 interface6_0;
    private readonly Interface7 interface7_0;
    private int int_0;
    private StringBuilder stringBuilder_0;

    internal Class255(Interface6 resolver, Interface7 subResolver, int version)
    {
      this.interface6_0 = resolver;
      this.interface7_0 = subResolver;
      this.int_0 = version;
      this.stringBuilder_0 = new StringBuilder();
    }

    public string SAT
    {
      get
      {
        return this.stringBuilder_0.ToString();
      }
    }

    protected void method_0(string value)
    {
      this.stringBuilder_0.Append(value);
      this.stringBuilder_0.Append(' ');
    }

    protected virtual Interface9 vmethod_0(
      Interface6 entityResolver,
      Interface7 subEntityResolver,
      int fileFormatVersion)
    {
      return (Interface9) new Class255(entityResolver, subEntityResolver, fileFormatVersion);
    }

    public virtual void imethod_4(int value)
    {
      this.method_0(value.ToString());
    }

    public virtual void imethod_5(int value)
    {
      this.method_0("$" + value.ToString());
    }

    public virtual void imethod_6(Class80 entity)
    {
      if (entity == null)
        this.method_0("$" + -1.ToString());
      else
        this.method_0("$" + entity.Index.ToString());
    }

    public virtual void imethod_7(double value)
    {
      this.method_0(value.ToString((IFormatProvider) CultureInfo.InvariantCulture));
    }

    public virtual void imethod_8()
    {
      this.method_0("}");
    }

    public virtual void imethod_9()
    {
      this.method_0("{");
    }

    public virtual void WriteString(string value)
    {
      if (Class250.int_63 <= this.int_0)
        this.method_0("@" + value.Length.ToString());
      else
        this.method_0(value.Length.ToString());
      this.method_0(value);
    }

    public virtual void imethod_11(string[] values, int[] indexes, int value)
    {
      if (this.int_0 >= Class250.int_26)
      {
        if (indexes != null)
        {
          for (int index = 0; index < indexes.Length; ++index)
          {
            if (indexes[index] == value)
            {
              this.method_0(values[index]);
              break;
            }
          }
        }
        else
          this.method_0(values[value]);
      }
      else if (indexes != null)
      {
        for (int index = 0; index < indexes.Length; ++index)
        {
          if (indexes[index] == value)
          {
            this.imethod_4(index);
            break;
          }
        }
      }
      else
        this.imethod_4(value);
    }

    public virtual void imethod_10(string[] values, int value)
    {
      this.imethod_11(values, (int[]) null, value);
    }

    public virtual void imethod_12(Interface39 values)
    {
      this.method_0(values.SAT);
    }

    public virtual void imethod_13(string value)
    {
      this.method_0(value);
    }

    public virtual void imethod_14()
    {
      this.method_0("#");
      this.imethod_15();
    }

    public virtual void imethod_15()
    {
      this.method_0("\r\n");
    }

    public virtual void imethod_16(Class987 header)
    {
      this.imethod_4(header.NumberOfRecords);
      this.imethod_4(header.EntityCount);
      this.imethod_4(this.int_0 != 21200 ? (this.int_0 != 21500 ? (this.int_0 != 21600 ? (this.int_0 != 21700 ? (this.int_0 != 21800 ? 0 : 12) : 4) : 8) : 24) : 26);
      this.imethod_15();
      if (this.int_0 < Class250.int_28)
        return;
      this.WriteString(header.Product);
      this.WriteString(header.AcisVersion);
      this.WriteString(header.method_1());
      this.imethod_15();
      this.imethod_7(header.MmPerUnit);
      this.imethod_7(header.AbsoluteResolution);
      this.imethod_7(header.NormalResolution);
      this.imethod_15();
    }

    public virtual void imethod_17(Point3D position)
    {
      this.imethod_7(position.X);
      this.imethod_7(position.Y);
      this.imethod_7(position.Z);
    }

    public virtual void imethod_18(Vector3D vector)
    {
      this.imethod_7(vector.X);
      this.imethod_7(vector.Y);
      this.imethod_7(vector.Z);
    }

    public virtual void imethod_19(List<Class561> unknownData, bool comesFromSat)
    {
      if (!comesFromSat)
      {
        foreach (Class561 class561 in unknownData)
        {
          switch (class561.enum41_0)
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
              this.method_0("1");
              continue;
            case Class951.Enum41.const_11:
              this.method_0("0");
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
              throw new Exception0("Saving of unknown entities is not supported for SAB format");
          }
        }
      }
      else
      {
        foreach (Class561 class561 in unknownData)
        {
          switch (class561.enum41_0)
          {
            case Class951.Enum41.const_9:
              this.method_0(((Class562<string>) class561).gparam_0);
              continue;
            case Class951.Enum41.const_12:
              this.imethod_5(((Class562<int>) class561).gparam_0);
              continue;
            default:
              throw new Exception0("Unknown data fromat is invalid");
          }
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

    public Class80 this[int index]
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

    public virtual Interface9 imethod_20()
    {
      return this.vmethod_0(this.interface6_0, this.interface7_0, this.int_0);
    }

    public int imethod_3(Class196 subEntity)
    {
      return this.interface7_0.imethod_3(subEntity);
    }
  }
}
