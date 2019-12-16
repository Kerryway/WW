// Decompiled with JetBrains decompiler
// Type: ns7.Class251
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns9;
using System;
using System.Collections.Generic;
using System.Globalization;
using WW.Math;

namespace ns7
{
  internal class Class251 : Interface6, Interface7, Interface8
  {
    public const char char_0 = '-';
    private readonly Interface6 interface6_0;
    private readonly Interface7 interface7_0;
    private readonly int int_0;
    private readonly Class251.Class254 class254_0;

    private int method_0(string word, string message)
    {
      int result;
      if (!int.TryParse(word, out result))
        throw new Exception0(message + word);
      return result;
    }

    private int method_1(string message)
    {
      return this.method_0(this.method_2(), message);
    }

    internal Class251(
      Interface6 resolver,
      Interface7 subResolver,
      int version,
      Class251.Class254 marker)
    {
      this.interface6_0 = resolver;
      this.interface7_0 = subResolver;
      this.int_0 = version;
      this.class254_0 = marker;
    }

    protected string method_2()
    {
      string str = this.class254_0.method_2();
      if (str == null)
        throw new Exception1();
      return str;
    }

    protected string method_3(int numChars)
    {
      string str = this.class254_0.method_3(numChars);
      if (str == null)
        throw new Exception1();
      return str;
    }

    protected virtual Interface8 vmethod_0(
      Interface6 entityResolver,
      Interface7 subEntityResolver,
      int fileFormatVersion,
      Class251.Class254 subReadMarker)
    {
      return (Interface8) new Class251(entityResolver, subEntityResolver, fileFormatVersion, subReadMarker);
    }

    public virtual int imethod_4(int defaultNumber)
    {
      if (this.class254_0.method_5() == '-')
        return -this.method_1("Broken SAT sequence number ");
      return defaultNumber;
    }

    public virtual int imethod_5()
    {
      return this.method_1("Broken integer number : ");
    }

    public virtual int imethod_7()
    {
      return this.method_1("Broken index number : ");
    }

    public virtual double imethod_8()
    {
      string s = this.method_2();
      double result;
      if (!double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, (IFormatProvider) CultureInfo.InvariantCulture, out result))
        throw new Exception0("Broken double value : " + s);
      return result;
    }

    public virtual void imethod_9()
    {
      string str = this.method_3(1);
      if (str != "}")
        throw new Exception0("Broken subtype end marker : " + str);
    }

    public virtual void imethod_10()
    {
      string str = this.method_3(1);
      if (str != "{")
        throw new Exception0("Broken subtype start marker : " + str);
    }

    public virtual string ReadString()
    {
      return this.method_3(this.method_1("String length broken : "));
    }

    public virtual int imethod_12(string[] values, int[] indexes)
    {
      string str = this.method_2();
      if (this.int_0 >= Class250.int_26)
      {
        for (int index = values.Length - 1; index >= 0; --index)
        {
          if (string.Compare(str, values[index], StringComparison.InvariantCultureIgnoreCase) == 0)
          {
            if (indexes == null)
              return index;
            return indexes[index];
          }
        }
      }
      else
      {
        int num = this.method_0(str, "Unexpected enum value : ");
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
      throw new Exception0("Unexpected enum value : " + str);
    }

    public virtual int imethod_11(string[] values)
    {
      return this.imethod_12(values, (int[]) null);
    }

    public virtual void imethod_13(Interface39 values)
    {
      string str = this.method_2();
      values.SAT = str;
    }

    public virtual string imethod_14()
    {
      return this.class254_0.method_2();
    }

    public virtual bool imethod_15(ref List<Class561> unknownData)
    {
      string str1 = this.class254_0.method_4();
      if (this.FileFormatVersion < Class250.int_7)
      {
        unknownData.Add((Class561) new Class562<string>(Class951.Enum41.const_9, str1));
      }
      else
      {
        int startIndex = 0;
        int num = 0;
        int result = -2;
        int index = 0;
        while (index < str1.Length)
        {
          if (str1[index] == '$')
          {
            string s = new Class251.Class254(str1.Substring(index + 1)).method_2();
            if (int.TryParse(s, out result))
            {
              num = index - 1;
              index += s.Length + 2;
            }
          }
          else if (str1[index] == '#')
          {
            num = index - 1;
            ++index;
          }
          else
          {
            ++index;
            continue;
          }
          if (startIndex < num)
          {
            string str2 = str1.Substring(startIndex, num - startIndex);
            unknownData.Add((Class561) new Class562<string>(Class951.Enum41.const_9, str2));
            num = 0;
            startIndex = index;
          }
          if (result != -2)
          {
            unknownData.Add((Class561) new Class562<int>(Class951.Enum41.const_12, result));
            result = -2;
            startIndex = index;
          }
        }
      }
      return true;
    }

    public virtual bool imethod_16(bool silentMode)
    {
      string str = this.method_2();
      if (str.Length == 1 && str[0] == '#')
        return true;
      if (!silentMode)
        throw new Exception0("Not an end-of-record");
      return false;
    }

    public virtual void imethod_17(Class987 header)
    {
      header.NumberOfRecords = this.imethod_5();
      header.EntityCount = this.imethod_5();
      header.HistorySaved = this.imethod_5() != 0;
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
      return new Point3D() { X = this.imethod_8(), Y = this.imethod_8(), Z = this.imethod_8() };
    }

    public virtual Vector3D imethod_19()
    {
      return new Vector3D() { X = this.imethod_8(), Y = this.imethod_8(), Z = this.imethod_8() };
    }

    public virtual void imethod_6()
    {
      this.class254_0.method_1();
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
      return this.vmethod_0(this.interface6_0, this.interface7_0, this.int_0, this.class254_0);
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

    public int imethod_3(Class196 subEntity)
    {
      return -1;
    }

    public override string ToString()
    {
      return this.class254_0.ToString();
    }

    internal class Class254
    {
      public const string string_0 = "{";
      public const string string_1 = "}";
      private readonly int int_0;
      private readonly string string_2;
      private int int_1;

      public Class254(string content)
      {
        this.string_2 = content;
        this.int_0 = content.Length;
        this.int_1 = 0;
        this.method_0();
      }

      private void method_0()
      {
        while (this.int_1 < this.int_0 && char.IsWhiteSpace(this.string_2[this.int_1]))
          ++this.int_1;
      }

      public void method_1()
      {
      }

      internal string method_2()
      {
        if (this.int_1 >= this.int_0)
          return (string) null;
        int startIndex = this.int_1++;
        while (this.int_1 < this.int_0 && (!char.IsWhiteSpace(this.string_2[this.int_1]) && this.string_2[this.int_1] != '#'))
          ++this.int_1;
        string str = this.string_2.Substring(startIndex, this.int_1 - startIndex);
        this.method_0();
        return str;
      }

      internal string method_3(int numChars)
      {
        if (numChars < 0 || this.int_1 + numChars > this.int_0)
          return (string) null;
        string str = this.string_2.Substring(this.int_1, numChars);
        this.int_1 += numChars;
        this.method_0();
        return str;
      }

      internal string method_4()
      {
        int int1 = this.int_1;
        string str = this.method_2();
        while (str != null && !Class250.string_2.Equals(str))
          str = this.method_2();
        if (str == null)
          return (string) null;
        do
          ;
        while (this.string_2[--this.int_1] != '#');
        return this.string_2.Substring(int1, this.int_1 - int1 + 1);
      }

      internal char method_5()
      {
        if (this.int_1 >= this.int_0)
          return char.MinValue;
        return this.string_2[this.int_1];
      }

      internal Class251.Class254 method_6()
      {
        string str1 = this.method_2();
        if (!"{".Equals(str1))
          throw new Exception0("Subtype start marker '{' expected, but found '" + str1 + "'!");
        int int1 = this.int_1;
        int num1 = int1;
        int num2 = 1;
        while (num2 > 0)
        {
          num1 = this.int_1;
          string str2 = this.method_2();
          if ("}".Equals(str2))
            --num2;
          else if ("{".Equals(str2))
            ++num2;
          else if (Class250.string_2.Equals(str2))
            throw new Exception0("Subtype end not found in record, nesting level is " + (object) num2);
        }
        return new Class251.Class254(this.string_2.Substring(int1, num1 - int1));
      }

      public override string ToString()
      {
        return this.string_2.Substring(this.int_1);
      }
    }
  }
}
