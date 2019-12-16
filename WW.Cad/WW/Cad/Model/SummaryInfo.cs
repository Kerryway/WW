// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.SummaryInfo
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns43;
using System;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Model.Objects;

namespace WW.Cad.Model
{
  public class SummaryInfo
  {
    private string string_0 = string.Empty;
    private string string_1 = string.Empty;
    private string string_2 = string.Empty;
    private string string_3 = string.Empty;
    private string string_4 = string.Empty;
    private string string_5 = string.Empty;
    private string string_6 = string.Empty;
    private string string_7 = string.Empty;
    private DxfTimeSpan dxfTimeSpan_0 = DxfTimeSpan.Zero;
    private DateTime dateTime_0 = DxfUtil.DateTimeNow;
    private DateTime dateTime_1 = DxfUtil.DateTimeNow;
    private readonly List<SummaryInfo.Property> list_0 = new List<SummaryInfo.Property>();

    public SummaryInfo()
    {
    }

    public SummaryInfo(SummaryInfo from)
    {
      this.string_1 = from.string_1;
      this.string_2 = from.string_2;
      this.string_3 = from.string_3;
      this.string_4 = from.string_4;
      this.string_5 = from.string_5;
      this.string_6 = from.string_6;
      this.string_7 = from.string_7;
      this.dxfTimeSpan_0 = from.dxfTimeSpan_0;
      this.dateTime_0 = from.dateTime_0;
      this.dateTime_1 = from.dateTime_1;
      this.list_0 = new List<SummaryInfo.Property>(from.list_0.Count);
      foreach (SummaryInfo.Property property in from.list_0)
        this.list_0.Add(new SummaryInfo.Property(property.Name, property.Value));
    }

    public string Title
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

    public string Subject
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
      }
    }

    public string Author
    {
      get
      {
        return this.string_2;
      }
      set
      {
        this.string_2 = value;
      }
    }

    public string Keywords
    {
      get
      {
        return this.string_3;
      }
      set
      {
        this.string_3 = value;
      }
    }

    public string Comments
    {
      get
      {
        return this.string_4;
      }
      set
      {
        this.string_4 = value;
      }
    }

    public string LastSavedBy
    {
      get
      {
        return this.string_5;
      }
      set
      {
        this.string_5 = value;
      }
    }

    public string RevisionNumber
    {
      get
      {
        return this.string_6;
      }
      set
      {
        this.string_6 = value;
      }
    }

    public string HyperLinkBase
    {
      get
      {
        return this.string_7;
      }
      set
      {
        this.string_7 = value;
      }
    }

    public DxfTimeSpan TotalEditingTime
    {
      get
      {
        return this.dxfTimeSpan_0;
      }
      set
      {
        this.dxfTimeSpan_0 = value;
      }
    }

    public DateTime CreationDateTime
    {
      get
      {
        return this.dateTime_0;
      }
      set
      {
        this.dateTime_0 = value;
      }
    }

    public DateTime ModifiedDateTime
    {
      get
      {
        return this.dateTime_1;
      }
      set
      {
        this.dateTime_1 = value;
      }
    }

    public List<SummaryInfo.Property> Properties
    {
      get
      {
        return this.list_0;
      }
    }

    internal void method_0(Class1070 context, DxfModel model)
    {
      if (model.Header.AcadVersion > DxfVersion.Dxf15)
      {
        if (model.XRecordDwgProps == null)
          return;
        model.DictionaryRoot.Entries.RemoveAll("DWGPROPS");
        model.XRecordDwgProps = (DxfXRecord) null;
      }
      else
      {
        DxfXRecord dxfXrecord = model.XRecordDwgProps;
        if (dxfXrecord == null)
        {
          dxfXrecord = new DxfXRecord();
          model.XRecordDwgProps = dxfXrecord;
          model.DictionaryRoot.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("DWGPROPS", (DxfObject) model.XRecordDwgProps));
        }
        else
          dxfXrecord.Values.Clear();
        short num1 = 1;
        DxfXRecordValueCollection values1 = dxfXrecord.Values;
        num1 = (short) 2;
        values1.Add((short) 1, (object) "DWGPROPS COOKIE");
        DxfXRecordValueCollection values2 = dxfXrecord.Values;
        num1 = (short) 3;
        string string0 = this.string_0;
        values2.Add((short) 2, (object) string0);
        DxfXRecordValueCollection values3 = dxfXrecord.Values;
        num1 = (short) 4;
        string string1 = this.string_1;
        values3.Add((short) 3, (object) string1);
        DxfXRecordValueCollection values4 = dxfXrecord.Values;
        num1 = (short) 5;
        string string2 = this.string_2;
        values4.Add((short) 4, (object) string2);
        num1 = (short) 6;
        DxfXRecordValueCollection values5 = dxfXrecord.Values;
        num1 = (short) 7;
        string string4 = this.string_4;
        values5.Add((short) 6, (object) string4);
        DxfXRecordValueCollection values6 = dxfXrecord.Values;
        num1 = (short) 8;
        string string3 = this.string_3;
        values6.Add((short) 7, (object) string3);
        DxfXRecordValueCollection values7 = dxfXrecord.Values;
        num1 = (short) 9;
        string string5 = this.string_5;
        values7.Add((short) 8, (object) string5);
        DxfXRecordValueCollection values8 = dxfXrecord.Values;
        num1 = (short) 10;
        string string6 = this.string_6;
        values8.Add((short) 9, (object) string6);
        short num2 = 300;
        foreach (SummaryInfo.Property property in this.list_0)
        {
          dxfXrecord.Values.Add(num2++, (object) (property.Name + "=" + property.Value));
          if (num2 > (short) 309)
            break;
        }
        while (num2 < (short) 310)
          dxfXrecord.Values.Add(num2++, (object) "=");
        num1 = (short) 40;
        DxfXRecordValueCollection values9 = dxfXrecord.Values;
        num1 = (short) 41;
        // ISSUE: variable of a boxed type
        __Boxed<double> local1 = (ValueType) Class644.smethod_3(this.dxfTimeSpan_0);
        values9.Add((short) 40, (object) local1);
        DxfXRecordValueCollection values10 = dxfXrecord.Values;
        num1 = (short) 42;
        // ISSUE: variable of a boxed type
        __Boxed<double> local2 = (ValueType) Class644.smethod_0(this.dateTime_0);
        values10.Add((short) 41, (object) local2);
        DxfXRecordValueCollection values11 = dxfXrecord.Values;
        short num3 = 43;
        // ISSUE: variable of a boxed type
        __Boxed<double> local3 = (ValueType) Class644.smethod_0(this.dateTime_1);
        values11.Add((short) 42, (object) local3);
        dxfXrecord.Values.Add((short) 1, (object) this.string_7);
        dxfXrecord.Values.Add((short) 90, (object) this.list_0.Count);
        for (int index = 10; index < this.list_0.Count; ++index)
        {
          SummaryInfo.Property property = this.list_0[index];
          dxfXrecord.Values.Add(num3++, (object) (property.Name + "=" + property.Value));
        }
      }
    }

    internal void method_1(DxfModel model)
    {
      if (model.Header.AcadVersion >= DxfVersion.Dxf18)
        return;
      DxfXRecord xrecordDwgProps = model.XRecordDwgProps;
      if (xrecordDwgProps == null)
        return;
      List<DxfXRecordValue>.Enumerator enumerator = xrecordDwgProps.Values.GetEnumerator();
      if (!enumerator.MoveNext() || enumerator.Current.Code != (short) 1 || !((string) enumerator.Current.Value == "DWGPROPS COOKIE"))
        return;
      while (enumerator.MoveNext())
      {
        DxfXRecordValue current = enumerator.Current;
        if (current.Code >= (short) 300 && current.Code <= (short) 309)
        {
          string str1 = (string) current.Value;
          if (!(str1 == "="))
          {
            int length = str1.IndexOf('=');
            string str2 = string.Empty;
            string name;
            if (length < 0)
            {
              name = str1;
            }
            else
            {
              name = str1.Substring(0, length);
              str2 = str1.Substring(length + 1);
            }
            this.list_0.Add(new SummaryInfo.Property(name, str2));
          }
        }
        else
        {
          switch (current.Code)
          {
            case 1:
              this.HyperLinkBase = (string) current.Value;
              continue;
            case 2:
              this.Title = (string) current.Value;
              continue;
            case 3:
              this.Subject = (string) current.Value;
              continue;
            case 4:
              this.Author = (string) current.Value;
              continue;
            case 6:
              this.Comments = (string) current.Value;
              continue;
            case 7:
              this.Keywords = (string) current.Value;
              continue;
            case 8:
              this.LastSavedBy = (string) current.Value;
              continue;
            case 9:
              this.RevisionNumber = (string) current.Value;
              continue;
            case 40:
              this.dxfTimeSpan_0 = Class644.smethod_7((double) current.Value);
              continue;
            case 41:
              this.dateTime_0 = Class644.smethod_4((double) current.Value);
              continue;
            case 42:
              this.dateTime_1 = Class644.smethod_4((double) current.Value);
              continue;
            default:
              continue;
          }
        }
      }
    }

    public class Property
    {
      private string string_0 = string.Empty;
      private string string_1 = string.Empty;

      public Property()
      {
      }

      public Property(string name, string value)
      {
        this.Name = name;
        this.Value = value;
      }

      public string Name
      {
        get
        {
          return this.string_0;
        }
        set
        {
          this.string_0 = value ?? string.Empty;
        }
      }

      public string Value
      {
        get
        {
          return this.string_1;
        }
        set
        {
          this.string_1 = value ?? string.Empty;
        }
      }

      public override string ToString()
      {
        return string.Format("{0}: {1}", (object) this.string_0, (object) this.string_1);
      }
    }
  }
}
