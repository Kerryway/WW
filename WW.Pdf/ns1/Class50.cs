// Decompiled with JetBrains decompiler
// Type: ns1.Class50
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns2;
using ns3;
using System;
using System.Collections.Generic;

namespace ns1
{
  internal class Class50
  {
    private IDictionary<string, Class41> idictionary_0;

    protected internal void method_0(Class74 stream)
    {
      stream.method_25(4L);
      int capacity = (int) stream.method_8();
      stream.method_25(6L);
      this.idictionary_0 = (IDictionary<string, Class41>) new Dictionary<string, Class41>(capacity);
      for (int index = 0; index < capacity; ++index)
      {
        Class41 class41 = new Class41(stream.method_20(), stream.method_14(), stream.method_14(), stream.method_14());
        this.idictionary_0.Add(class41.TableName, class41);
      }
    }

    public bool method_1(string tableName)
    {
      if (this.idictionary_0 != null)
        return this.idictionary_0.ContainsKey(tableName);
      return false;
    }

    public Class41 this[string tableName]
    {
      get
      {
        if (!this.method_1(tableName))
          throw new ArgumentException("Cannot locate table " + tableName, nameof (tableName));
        return this.idictionary_0[tableName];
      }
    }

    public int Count
    {
      get
      {
        if (this.idictionary_0 == null)
          return 0;
        return this.idictionary_0.Count;
      }
    }
  }
}
