// Decompiled with JetBrains decompiler
// Type: ns6.Class741
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns28;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using WW.Cad.IO;
using WW.Diagnostics;

namespace ns6
{
  internal class Class741 : IDumpable
  {
    private readonly List<Class48> list_0 = new List<Class48>();
    private readonly List<Class558> list_1 = new List<Class558>();
    private readonly List<Class46> list_2 = new List<Class46>();
    private readonly Dictionary<Enum53, Class560> dictionary_0 = new Dictionary<Enum53, Class560>();

    public Class741(bool createDefaultObjects)
    {
      if (!createDefaultObjects)
        return;
      this.method_1();
    }

    public List<Class48> Schemas
    {
      get
      {
        return this.list_0;
      }
    }

    public List<Class558> SchemaUnknownProperties
    {
      get
      {
        return this.list_1;
      }
    }

    public List<Class46> SchemaSearchDataList
    {
      get
      {
        return this.list_2;
      }
    }

    public Dictionary<Enum53, Class560> RecordTypeTohandleToDataRecord
    {
      get
      {
        return this.dictionary_0;
      }
    }

    internal Class560 method_0(Enum53 recordType)
    {
      Class560 class560;
      if (!this.dictionary_0.TryGetValue(recordType, out class560))
      {
        class560 = new Class560();
        this.dictionary_0.Add(recordType, class560);
      }
      return class560;
    }

    public void Add(Enum53 recordType, ulong handle, Stream data)
    {
      if (data == null)
        throw new ArgumentNullException(nameof (data));
      Class560 class560;
      if (!this.dictionary_0.TryGetValue(recordType, out class560))
      {
        class560 = new Class560();
        this.dictionary_0.Add(recordType, class560);
      }
      class560.Add(handle, data);
    }

    public void Dump(DumpWriter w)
    {
      w.WriteField("schemas", (ICollection) this.list_0);
      w.WriteField("schemaUnknownProperties", (ICollection) this.list_1);
      w.WriteField("schemaSearchDataList", (ICollection) this.list_2);
      w.OpenObject("handleToDataRecord");
      foreach (KeyValuePair<Enum53, Class560> keyValuePair1 in this.dictionary_0)
      {
        w.WriteLine("Record type: {0}, handle + data count: {1}", (object) keyValuePair1.Key, (object) keyValuePair1.Value.Count);
        foreach (KeyValuePair<ulong, List<Stream>> keyValuePair2 in (Dictionary<ulong, List<Stream>>) keyValuePair1.Value)
        {
          w.Write("{0}: ", (object) keyValuePair2.Key);
          foreach (Stream stream in keyValuePair2.Value)
          {
            w.Write("DataRecord: ");
            w.Write(stream);
          }
          w.WriteLine(",");
        }
      }
      w.CloseObject();
    }

    private void method_1()
    {
      this.method_2();
      this.method_3();
      this.method_4();
      this.method_5();
      this.method_6();
      this.method_7();
      this.method_8();
    }

    private void method_2()
    {
      Class48 class48 = new Class48() { Name = "AcDb3DSolid_ASM_Data", Index = 0 };
      class48.Indexes.Add(0UL);
      class48.Indexes.Add(1UL);
      this.list_0.Add(class48);
      Class986 class986 = new Class986() { Flags = Enum52.flag_0, NameIndex = 0, Name = "AcDbDs::ID", Type = 10 };
      List<byte[]> propertyValues1 = class986.PropertyValues;
      byte[] numArray1 = new byte[8];
      numArray1[0] = (byte) 2;
      byte[] numArray2 = numArray1;
      propertyValues1.Add(numArray2);
      List<byte[]> propertyValues2 = class986.PropertyValues;
      byte[] numArray3 = new byte[8];
      numArray3[0] = (byte) 3;
      byte[] numArray4 = numArray3;
      propertyValues2.Add(numArray4);
      class48.Properties.Add(class986);
      class48.Properties.Add(new Class986()
      {
        Flags = Enum52.flag_0,
        NameIndex = 1U,
        Name = "ASM_Data",
        Type = 15U
      });
      Class496 class496_1 = new Class496();
      class496_1.Name = "AcDbDs::TreatedAsObjectData";
      class496_1.DataType = Enum26.const_0;
      Class496 class496_2 = class496_1;
      class496_2.Data = new Struct18(291, (object) true);
      class48.PropertyDescriptors.Add(new Class360()
      {
        Id = 0,
        Index = 1,
        Item = class496_2
      });
      Class496 class496_3 = new Class496();
      class496_3.Name = "AcDbDs::Legacy";
      class496_3.DataType = Enum26.const_0;
      Class496 class496_4 = class496_3;
      class496_4.Data = new Struct18(291, (object) true);
      class48.PropertyDescriptors.Add(new Class360()
      {
        Id = 0,
        Index = 2,
        Item = class496_4
      });
      Class496 class496_5 = new Class496();
      class496_5.Name = "AcDs:Indexable";
      class496_5.DataType = Enum26.const_0;
      Class496 class496_6 = class496_5;
      class496_6.Data = new Struct18(291, (object) true);
      class48.PropertyDescriptors.Add(new Class360()
      {
        IdName = "AcDbDs::ID",
        Index = 3,
        Item = class496_6
      });
      Class496 class496_7 = new Class496();
      class496_7.Name = "AcDbDs::HandleAttribute";
      class496_7.DataType = Enum26.const_6;
      Class496 class496_8 = class496_7;
      class496_8.Data = new Struct18(282, (object) (byte) 1);
      class48.PropertyDescriptors.Add(new Class360()
      {
        IdName = "AcDbDs::ID",
        Index = 4,
        Item = class496_8
      });
    }

    private void method_3()
    {
      Class48 class48 = new Class48() { Index = 1, Name = "AcDbDs::TreatedAsObjectDataSchema" };
      Class986 class986 = new Class986() { Flags = Enum52.flag_0, NameIndex = 2, Name = "AcDbDs::TreatedAsObjectData", Type = 1 };
      class48.Properties.Add(class986);
      this.list_0.Add(class48);
    }

    private void method_4()
    {
      Class48 class48 = new Class48() { Index = 2, Name = "AcDbDs::LegacySchema" };
      class48.Properties.Add(new Class986()
      {
        Flags = Enum52.flag_0,
        NameIndex = 3U,
        Name = "AcDbDs::Legacy",
        Type = 1U
      });
      this.list_0.Add(class48);
    }

    private void method_5()
    {
      Class48 class48 = new Class48() { Index = 3, Name = "AcDbDs::IndexedPropertySchema" };
      class48.Properties.Add(new Class986()
      {
        Flags = Enum52.flag_0,
        NameIndex = 4U,
        Name = "AcDs:Indexable",
        Type = 1U
      });
      this.list_0.Add(class48);
    }

    private void method_6()
    {
      Class48 class48 = new Class48() { Index = 4, Name = "AcDbDs::HandleAttributeSchema" };
      Class986 class986 = new Class986() { Flags = Enum52.flag_3, NameIndex = 5, Name = "AcDbDs::HandleAttribute", Type = 7, Unknown2 = 1 };
      class986.PropertyValues.Add(new byte[1]);
      class48.Properties.Add(class986);
      this.list_0.Add(class48);
    }

    private void method_7()
    {
      this.list_1.Add(new Class558()
      {
        DataSize = 8U,
        UnknownFlags = 1U
      });
      this.list_1.Add(new Class558()
      {
        DataSize = 8U,
        UnknownFlags = 1U
      });
      this.list_1.Add(new Class558()
      {
        DataSize = 8U,
        UnknownFlags = 1U
      });
      this.list_1.Add(new Class558()
      {
        DataSize = 8U,
        UnknownFlags = 0U
      });
    }

    private void method_8()
    {
      Class46 class46 = new Class46() { SchemaNameIndex = 0 };
      ulong index = 0;
      class46.IdIndexesSet = new Class46.Class47[1][];
      int length = 0;
      foreach (KeyValuePair<Enum53, Class560> keyValuePair in this.dictionary_0)
        length += keyValuePair.Value.Count;
      class46.IdIndexesSet[0] = new Class46.Class47[length];
      foreach (KeyValuePair<Enum53, Class560> keyValuePair1 in this.dictionary_0)
      {
        foreach (KeyValuePair<ulong, List<Stream>> keyValuePair2 in (Dictionary<ulong, List<Stream>>) keyValuePair1.Value)
        {
          Class46.Class47 class47 = new Class46.Class47() { Handle = keyValuePair2.Key };
          class47.Indexes.Add(index);
          class46.IdIndexesSet[0][index] = class47;
          ++index;
        }
      }
    }

    internal class Class742
    {
      private readonly Class916 class916_0 = new Class916();
      private readonly Class49.Class51 class51_0 = new Class49.Class51();
      private readonly Class49.Class54 class54_0 = new Class49.Class54();
      private readonly Class49.Class53 class53_0 = new Class49.Class53();
      private readonly List<Class49.Class55> list_0 = new List<Class49.Class55>();
      private readonly Class49.Class50 class50_0 = new Class49.Class50();
      private readonly SortedDictionary<uint, List<Class49.Class54.Class64>> sortedDictionary_0 = new SortedDictionary<uint, List<Class49.Class54.Class64>>();
      private readonly Dictionary<ulong, Class1027> dictionary_0 = new Dictionary<ulong, Class1027>();
      private const int int_0 = 128;
      public const string string_0 = "ACDSDATA";
      private Class889 class889_0;
      private long long_0;
      private Class741 class741_0;
      private uint uint_0;

      public event EventHandler<EventArgs0> FileSegmentWritten;

      public Class741 DataStore
      {
        get
        {
          return this.class741_0;
        }
      }

      public Class889 Stream
      {
        get
        {
          return this.class889_0;
        }
        set
        {
          this.class889_0 = value;
        }
      }

      public long DataStoreStreamStartPosition
      {
        get
        {
          return this.long_0;
        }
      }

      public Class916 FileHeader
      {
        get
        {
          return this.class916_0;
        }
      }

      public Class49.Class51 SegmentIndex
      {
        get
        {
          return this.class51_0;
        }
      }

      public Class49.Class54 DataIndex
      {
        get
        {
          return this.class54_0;
        }
      }

      public Class49.Class53 SchemaIndex
      {
        get
        {
          return this.class53_0;
        }
      }

      public Class49.Class50 SearchSegment
      {
        get
        {
          return this.class50_0;
        }
      }

      public SortedDictionary<uint, List<Class49.Class54.Class64>> SegmentIndexToDataIndexEntries
      {
        get
        {
          return this.sortedDictionary_0;
        }
      }

      public Dictionary<ulong, Class1027> HandleToRecord
      {
        get
        {
          return this.dictionary_0;
        }
      }

      public Enum53 method_0(int recordIndex)
      {
        return this.method_1(this.class54_0.Entries[recordIndex]);
      }

      public Enum53 method_1(Class49.Class54.Class64 entry)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        Class741.Class742.Class743 class743 = new Class741.Class742.Class743();
        // ISSUE: reference to a compiler-generated field
        class743.class64_0 = entry;
        Enum53 enum53 = Enum53.const_0;
        // ISSUE: reference to a compiler-generated method
        Class48 class48 = this.class741_0.list_0.Find(new Predicate<Class48>(class743.method_0));
        if (class48 != null)
          enum53 = class48.RecordType;
        return enum53;
      }

      public void Read(out Class741 dataStore, Class889 r)
      {
        this.class741_0 = new Class741(false);
        dataStore = this.class741_0;
        this.class889_0 = r;
        this.long_0 = r.Position;
        this.class916_0.Read(r);
        this.method_2();
        this.method_5();
        this.method_6();
        this.method_3();
        this.method_4();
        this.method_7();
        dataStore.SchemaSearchDataList.AddRange((IEnumerable<Class46>) this.class50_0.Schemas);
      }

      private void method_2()
      {
        this.class889_0.Position = this.long_0 + (long) this.class916_0.SegmentIndexOffset;
        this.class51_0.Read(this);
      }

      private void method_3()
      {
        this.class889_0.Position = this.long_0 + (long) this.class51_0.Entries[(int) this.class916_0.DataIndexSegmentIndex].Offset;
        this.class54_0.Read(this);
        foreach (Class49.Class54.Class64 entry in this.class54_0.Entries)
        {
          if (!entry.IsStubEntry)
          {
            List<Class49.Class54.Class64> class64List;
            if (!this.sortedDictionary_0.TryGetValue(entry.SegmentIndex, out class64List))
            {
              class64List = new List<Class49.Class54.Class64>();
              this.sortedDictionary_0.Add(entry.SegmentIndex, class64List);
            }
            class64List.Add(entry);
          }
        }
      }

      private void method_4()
      {
        foreach (KeyValuePair<uint, List<Class49.Class54.Class64>> keyValuePair in this.sortedDictionary_0)
        {
          this.class889_0.Position = this.long_0 + (long) this.class51_0.Entries[(int) keyValuePair.Key].Offset;
          Class49.Class52 class52 = new Class49.Class52();
          class52.Read(this);
          List<Class49.Class54.Class64> class64List = keyValuePair.Value;
          int index = 0;
          foreach (Class49.Class52.Class60 entry in class52.Entries)
          {
            Stream data = entry.ReferencedObject.imethod_0(this);
            this.class741_0.Add(this.method_1(class64List[index]), entry.Handle, data);
            ++index;
          }
        }
      }

      private void method_5()
      {
        this.class889_0.Position = this.long_0 + (long) this.class51_0.Entries[(int) this.class916_0.SchemaIndexSegmentIndex].Offset;
        this.class53_0.Read(this);
      }

      private void method_6()
      {
        this.list_0.Capacity = this.class53_0.SegmentIndexes.Count;
        foreach (int segmentIndex in this.class53_0.SegmentIndexes)
        {
          this.class889_0.Position = this.long_0 + (long) this.class51_0.Entries[segmentIndex].Offset;
          Class49.Class55 class55 = new Class49.Class55();
          class55.Read(this);
          this.list_0.Add(class55);
        }
        foreach (Class49.Class55 class55 in this.list_0)
        {
          this.class741_0.Schemas.AddRange((IEnumerable<Class48>) class55.Schemas);
          this.class741_0.SchemaUnknownProperties.AddRange((IEnumerable<Class558>) class55.UnknownProperties);
        }
      }

      private void method_7()
      {
        this.class889_0.Position = this.long_0 + (long) this.class51_0.Entries[(int) this.class916_0.SearchSegmentIndex].Offset;
        this.class50_0.Read(this);
      }

      public void Write(Class741 dataStore, Class889 w)
      {
        this.class889_0 = w;
        this.class741_0 = dataStore;
        Class49.Class55 class55 = new Class49.Class55();
        class55.Schemas.AddRange((IEnumerable<Class48>) dataStore.Schemas);
        class55.UnknownProperties.AddRange((IEnumerable<Class558>) dataStore.SchemaUnknownProperties);
        this.list_0.Add(class55);
        this.class50_0.Schemas.AddRange((IEnumerable<Class46>) dataStore.SchemaSearchDataList);
        long position1 = w.Position;
        for (int index = 0; index < 128; ++index)
          w.vmethod_1((byte) 0);
        this.method_8(new Class49.Class51.Class57());
        this.method_8(new Class49.Class51.Class57());
        this.method_9(w);
        this.method_11(w);
        this.method_12(w);
        this.method_13(w);
        this.method_14(w);
        this.method_15(w);
        this.class916_0.FileSize = (int) (w.Position - position1);
        long position2 = w.Position;
        w.Position = position1;
        this.class916_0.Write(w);
      }

      private void method_8(Class49.Class51.Class57 entry)
      {
        this.class51_0.Entries.Add(entry);
        ++this.uint_0;
      }

      private void method_9(Class889 w)
      {
        Class49.Class52 class52 = new Class49.Class52();
        class52.Header.SegmentIndex = this.uint_0;
        foreach (KeyValuePair<Enum53, Class560> keyValuePair1 in this.class741_0.RecordTypeTohandleToDataRecord)
        {
          foreach (KeyValuePair<ulong, List<Stream>> keyValuePair2 in (Dictionary<ulong, List<Stream>>) keyValuePair1.Value)
          {
            foreach (Stream data in keyValuePair2.Value)
            {
              if (data.Length > 262144L)
              {
                Class49.Class52.Class58 class58 = this.method_10(w, keyValuePair2.Key, data);
                class52.method_0(keyValuePair2.Key, (Interface2) class58);
              }
              else
              {
                Class1068 class1068 = new Class1068() { Stream = data };
                class52.method_0(keyValuePair2.Key, (Interface2) class1068);
              }
            }
          }
        }
        this.method_16(w, (Class49) class52);
      }

      private Class49.Class52.Class58 method_10(Class889 w, ulong handle, Stream data)
      {
        Class49.Class52.Class58 class58 = new Class49.Class52.Class58();
        class58.method_0((ulong) data.Length);
        uint num1 = 0;
        int num2 = 0;
        for (; (ulong) num1 < class58.TotalDataSize; num1 += class58.PageSize)
        {
          ulong num3 = (ulong) (w.Position - this.long_0);
          Class49.Class56 class56 = new Class49.Class56() { TotalDataSize = class58.TotalDataSize, PageCount = (int) class58.PageCount, PageDataSize = (long) num2 < (long) (class58.PageCount - 1U) ? (ulong) class58.PageSize : (ulong) class58.LastPageSize, PageIndex = num2, PageStartOffset = (ulong) num1 };
          class56.Header.SegmentIndex = this.uint_0;
          class56.BinaryData = new Class882(data, (int) class56.PageStartOffset, (int) class56.PageDataSize);
          class56.Write(this);
          class58.Pages.Add(new Class49.Class52.Class58.Class59()
          {
            SegmentIndex = this.uint_0,
            Size = (uint) class56.PageDataSize
          });
          this.method_8(new Class49.Class51.Class57()
          {
            Offset = num3,
            Size = class56.Header.SegmentSize
          });
          ++num2;
        }
        return class58;
      }

      private void method_11(Class889 w)
      {
        this.method_16(w, (Class49) this.class54_0);
        this.class916_0.DataIndexSegmentIndex = this.class54_0.Header.SegmentIndex;
      }

      private void method_12(Class889 w)
      {
        foreach (Class49.Class55 class55 in this.list_0)
          this.method_16(w, (Class49) class55);
      }

      private void method_13(Class889 w)
      {
        this.method_16(w, (Class49) this.class53_0);
        this.class916_0.SchemaIndexSegmentIndex = this.class53_0.Header.SegmentIndex;
      }

      private void method_14(Class889 w)
      {
        this.method_16(w, (Class49) this.class50_0);
        this.class916_0.SearchSegmentIndex = this.class50_0.Header.SegmentIndex;
      }

      private void method_15(Class889 w)
      {
        ulong num1 = (ulong) (w.Position - this.long_0);
        uint n = (uint) (this.class51_0.Entries.Count * 12 + 48);
        uint num2 = n + Class49.smethod_0(n, 128);
        this.class51_0.Header.SegmentIndex = 1U;
        this.class51_0.Entries[1].Offset = num1;
        this.class51_0.Entries[1].Size = num2;
        this.class51_0.Write(this);
        this.class916_0.SegmentIndexOffset = (uint) num1;
        this.class916_0.SegmentIndexEntryCount = this.class51_0.Entries.Count;
      }

      private void method_16(Class889 w, Class49 fileSegment)
      {
        long num = w.Position - this.long_0;
        fileSegment.Header.SegmentIndex = this.uint_0;
        fileSegment.Write(this);
        this.method_8(new Class49.Class51.Class57()
        {
          Offset = (ulong) num,
          Size = fileSegment.Header.SegmentSize
        });
        this.vmethod_0(new EventArgs0(fileSegment));
      }

      protected virtual void vmethod_0(EventArgs0 e)
      {
        if (this.eventHandler_0 == null)
          return;
        this.eventHandler_0((object) this, e);
      }

      public void Read(out Class741 dataStore, DxfReader r)
      {
        dataStore = new Class741(false);
        this.class741_0 = dataStore;
        while (r.CurrentGroup != Class824.struct18_1 && r.CurrentGroup != Struct18.struct18_0)
        {
          if (r.CurrentGroup.Code == 0)
          {
            switch ((string) r.CurrentGroup.Value)
            {
              case "ACDSSCHEMA":
                Class48 class48 = new Class48();
                class48.Read(r);
                dataStore.Schemas.Add(class48);
                continue;
              case "ACDSRECORD":
                Class1027 class1027 = new Class1027();
                class1027.Read(r);
                if (class1027.Columns.Count == 2 && class1027.Columns[0].Name == "AcDbDs::ID" && class1027.Columns[1].Name == "ASM_Data")
                {
                  Class496 column1 = class1027.Columns[0];
                  Class496 column2 = class1027.Columns[1];
                  ulong handle = (ulong) column1.Data.Value;
                  Stream data = (Stream) column2.Data.Value;
                  dataStore.Add(Enum53.const_2, handle, data);
                  continue;
                }
                continue;
              default:
                r.method_85();
                continue;
            }
          }
          else
            r.method_85();
        }
      }

      public void Write(Class741 dataStore, DxfWriter w)
      {
        this.class741_0 = dataStore;
        w.Write(0, (object) "SECTION");
        w.Write(2, (object) "ACDSDATA");
        w.Write(70, (object) (short) 2);
        w.Write(71, (object) (short) 2);
        foreach (Class48 schema in dataStore.Schemas)
          schema.Write(w);
        foreach (KeyValuePair<ulong, List<Stream>> keyValuePair in (Dictionary<ulong, List<Stream>>) dataStore.method_0(Enum53.const_2))
        {
          foreach (Stream stream in keyValuePair.Value)
          {
            Class1027 class1027 = new Class1027();
            Class496 class496_1 = new Class496();
            class496_1.Name = "AcDbDs::ID";
            class496_1.DataType = Enum26.const_9;
            Class496 class496_2 = class496_1;
            class496_2.Data = new Struct18(320, (object) keyValuePair.Key);
            class1027.Columns.Add(class496_2);
            Class496 class496_3 = new Class496();
            class496_3.Name = "ASM_Data";
            class496_3.DataType = Enum26.const_14;
            Class496 class496_4 = class496_3;
            class496_4.Data = new Struct18(310, (object) stream);
            class1027.Columns.Add(class496_4);
            class1027.Write(w);
          }
        }
        w.Write(0, (object) "ENDSEC");
      }
    }
  }
}
