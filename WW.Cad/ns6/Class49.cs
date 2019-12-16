// Decompiled with JetBrains decompiler
// Type: ns6.Class49
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using WW.Diagnostics;
using WW.IO;
using WW.Text;

namespace ns6
{
  internal class Class49 : IDumpable
  {
    internal const int int_0 = 128;
    internal const int int_1 = 16;
    internal const byte byte_0 = 115;
    private Class681 class681_0;
    private ulong ulong_0;

    public Class49(string name)
    {
      this.class681_0 = new Class681(name);
    }

    public Class681 Header
    {
      get
      {
        return this.class681_0;
      }
    }

    public ulong StartOffset
    {
      get
      {
        return this.ulong_0;
      }
      set
      {
        this.ulong_0 = value;
      }
    }

    public ulong SystemDataOffset
    {
      get
      {
        return this.ulong_0 + this.class681_0.SystemDataLocalOffset;
      }
      set
      {
        this.class681_0.SystemDataLocalOffset = value - this.ulong_0;
      }
    }

    public ulong DataOffset
    {
      get
      {
        return this.ulong_0 + this.class681_0.ObjectDataLocalOffset;
      }
      set
      {
        this.class681_0.ObjectDataLocalOffset = value - this.ulong_0;
      }
    }

    public virtual void Dump(DumpWriter w)
    {
      w.WriteField("header", (IDumpable) this.class681_0);
      w.WriteField("startOffset", this.ulong_0);
    }

    public override string ToString()
    {
      if (this.class681_0 != null)
        return Encodings.Ascii.GetString(this.class681_0.Name, 0, this.class681_0.Name.Length);
      return string.Empty;
    }

    internal virtual void Read(Class741.Class742 serializer)
    {
      this.ulong_0 = (ulong) serializer.Stream.Position;
      this.class681_0.Read(serializer);
    }

    internal void Write(Class741.Class742 serializer)
    {
      Class889 stream = serializer.Stream;
      this.ulong_0 = (ulong) stream.Stream.Position;
      this.class681_0.Write(serializer);
      this.vmethod_0(serializer);
      uint n = (uint) ((ulong) stream.Stream.Position - this.ulong_0);
      uint num = Class49.smethod_0(n, 128);
      this.class681_0.SegmentSize = n + num;
      for (int index = 0; (long) index < (long) num; ++index)
        stream.vmethod_1((byte) 112);
      long position = stream.Stream.Position;
      stream.Position = (long) this.ulong_0;
      this.class681_0.Write(serializer);
      stream.Position = position;
    }

    internal virtual void vmethod_0(Class741.Class742 serializer)
    {
    }

    internal static uint smethod_0(uint n, int alignmentSize)
    {
      return (uint) ((ulong) (alignmentSize - 1) - (ulong) (n - 1U) % (ulong) alignmentSize);
    }

    internal class Class50 : Class49
    {
      private readonly List<Class46> list_0 = new List<Class46>();

      public Class50()
        : base("search")
      {
      }

      public List<Class46> Schemas
      {
        get
        {
          return this.list_0;
        }
      }

      public override void Dump(DumpWriter w)
      {
        base.Dump(w);
        w.WriteField("schemas", (ICollection) this.list_0);
      }

      internal override void Read(Class741.Class742 serializer)
      {
        base.Read(serializer);
        Class889 stream = serializer.Stream;
        uint num = stream.vmethod_10();
        for (int index = 0; (long) index < (long) num; ++index)
        {
          Class46 class46 = new Class46();
          class46.Read(stream);
          this.list_0.Add(class46);
        }
      }

      internal override void vmethod_0(Class741.Class742 serializer)
      {
        Class889 stream = serializer.Stream;
        stream.vmethod_11((uint) this.list_0.Count);
        foreach (Class46 class46 in this.list_0)
          class46.Write(stream);
      }
    }

    internal class Class51 : Class49
    {
      private readonly List<Class49.Class51.Class57> list_0 = new List<Class49.Class51.Class57>();

      public Class51()
        : base("segidx")
      {
      }

      public List<Class49.Class51.Class57> Entries
      {
        get
        {
          return this.list_0;
        }
      }

      public override void Dump(DumpWriter w)
      {
        base.Dump(w);
        w.WriteField("entries", (ICollection) this.list_0);
      }

      internal override void Read(Class741.Class742 serializer)
      {
        base.Read(serializer);
        Class889 stream = serializer.Stream;
        this.list_0.Capacity = serializer.FileHeader.SegmentIndexEntryCount;
        for (int index = 0; index < serializer.FileHeader.SegmentIndexEntryCount; ++index)
        {
          Class49.Class51.Class57 class57 = new Class49.Class51.Class57();
          class57.Read(stream);
          this.list_0.Add(class57);
        }
      }

      internal override void vmethod_0(Class741.Class742 serializer)
      {
        base.vmethod_0(serializer);
        Class889 stream = serializer.Stream;
        foreach (Class49.Class51.Class57 class57 in this.list_0)
          class57.Write(stream);
      }

      public class Class57 : IDumpable
      {
        private ulong ulong_0;
        private uint uint_0;

        public ulong Offset
        {
          get
          {
            return this.ulong_0;
          }
          set
          {
            this.ulong_0 = value;
          }
        }

        public uint Size
        {
          get
          {
            return this.uint_0;
          }
          set
          {
            if (value % 128U != 0U)
              throw new Exception("Size is not a multiple of the alignment size.");
            this.uint_0 = value;
          }
        }

        public override string ToString()
        {
          return string.Format("Offset: {0}, Size: {1}", (object) this.ulong_0, (object) this.uint_0);
        }

        internal void Read(Class889 r)
        {
          this.ulong_0 = r.vmethod_14();
          this.uint_0 = r.vmethod_10();
        }

        internal void Write(Class889 w)
        {
          w.vmethod_15(this.ulong_0);
          w.vmethod_11(this.uint_0);
        }

        public void Dump(DumpWriter w)
        {
          w.WriteField("offset", this.ulong_0);
          w.WriteField("size", this.uint_0);
        }
      }
    }

    internal class Class52 : Class49
    {
      private readonly List<Class49.Class52.Class60> list_0 = new List<Class49.Class52.Class60>();
      internal const byte byte_1 = 98;
      public const int int_2 = 262144;

      public Class52()
        : base("_data_")
      {
      }

      public List<Class49.Class52.Class60> Entries
      {
        get
        {
          return this.list_0;
        }
      }

      public override void Dump(DumpWriter w)
      {
        base.Dump(w);
        w.WriteField("entries", (ICollection) this.list_0);
      }

      internal void method_0(ulong handle, Interface2 dataRecord)
      {
        this.list_0.Add(new Class49.Class52.Class60()
        {
          Handle = handle,
          ReferencedObject = dataRecord
        });
      }

      internal override void Read(Class741.Class742 serializer)
      {
        base.Read(serializer);
        Class889 stream = serializer.Stream;
        long position = stream.Position;
        List<Class49.Class54.Class64> toDataIndexEntry = serializer.SegmentIndexToDataIndexEntries[this.class681_0.SegmentIndex];
        int count = toDataIndexEntry.Count;
        this.list_0.Capacity = count;
        for (int index = 0; index < count; ++index)
        {
          stream.Position = position + (long) toDataIndexEntry[index].LocalOffset;
          Class49.Class52.Class60 class60 = new Class49.Class52.Class60();
          if (class60.Read(stream))
            this.list_0.Add(class60);
        }
        if (this.list_0.Count <= 0)
          return;
        long dataOffset = (long) this.DataOffset;
        int num = this.list_0.Count - 1;
        int index1;
        for (index1 = 0; index1 < num; ++index1)
        {
          stream.Position = dataOffset + (long) this.list_0[index1].LocalOffset;
          uint maxRawSize = this.list_0[index1 + 1].LocalOffset - this.list_0[index1].LocalOffset;
          this.method_1(stream, index1, maxRawSize);
        }
        stream.Position = dataOffset + (long) this.list_0[index1].LocalOffset;
        uint maxRawSize1 = (uint) ((ulong) -(long) this.class681_0.ObjectDataLocalOffset + (ulong) this.class681_0.SegmentSize - (ulong) this.list_0[index1].LocalOffset);
        this.method_1(stream, index1, maxRawSize1);
      }

      private void method_1(Class889 r, int index, uint maxRawSize)
      {
        uint num = r.vmethod_10();
        Interface2 nterface2;
        if (num + 4U <= maxRawSize)
        {
          nterface2 = (Interface2) new Class1068();
        }
        else
        {
          if (num != 3138415537U)
            throw new Exception("Illegal data file segment data record data size " + (object) num + ".");
          nterface2 = (Interface2) new Class49.Class52.Class58();
        }
        nterface2.Read(r, (int) num);
        this.list_0[index].ReferencedObject = nterface2;
      }

      internal override void vmethod_0(Class741.Class742 serializer)
      {
        Class889 stream = serializer.Stream;
        long position1 = stream.Position;
        int num1 = (this.list_0.Count * 20 + 16) / 16;
        for (int index1 = 0; index1 < num1; ++index1)
        {
          for (int index2 = 0; index2 < 16; ++index2)
            stream.vmethod_1((byte) 98);
        }
        this.DataOffset = (ulong) stream.Position;
        for (int index = 0; index < this.list_0.Count; ++index)
        {
          uint num2 = (uint) ((ulong) stream.Position - this.DataOffset);
          Class49.Class52.Class60 class60 = this.list_0[index];
          if (class60.ReferencedObject == null)
            throw new Exception("Entry's ReferencedObject property is null.");
          class60.ReferencedObject.Write(stream);
          class60.LocalOffset = num2;
        }
        long position2 = stream.Position;
        stream.Position = position1;
        for (int index = 0; index < this.list_0.Count; ++index)
        {
          serializer.DataIndex.Entries.Add(new Class49.Class54.Class64()
          {
            SegmentIndex = this.class681_0.SegmentIndex,
            LocalOffset = (uint) (stream.Position - position1)
          });
          this.list_0[index].Write(stream);
        }
        stream.Position = position2;
      }

      public class Class58 : IDumpable, Interface2
      {
        private List<Class49.Class52.Class58.Class59> list_0 = new List<Class49.Class52.Class58.Class59>();
        public const int int_0 = 1048496;
        private ulong ulong_0;
        private uint uint_0;
        private uint uint_1;
        private uint uint_2;

        public ulong TotalDataSize
        {
          get
          {
            return this.ulong_0;
          }
          set
          {
            this.ulong_0 = value;
          }
        }

        public uint PageCount
        {
          get
          {
            return this.uint_0;
          }
          set
          {
            this.uint_0 = value;
          }
        }

        public uint PageSize
        {
          get
          {
            return this.uint_1;
          }
          set
          {
            this.uint_1 = value;
          }
        }

        public uint LastPageSize
        {
          get
          {
            return this.uint_2;
          }
          set
          {
            this.uint_2 = value;
          }
        }

        public List<Class49.Class52.Class58.Class59> Pages
        {
          get
          {
            return this.list_0;
          }
        }

        public void method_0(ulong totalDataSize)
        {
          this.ulong_0 = totalDataSize;
          if (totalDataSize <= 1048496UL)
          {
            this.uint_0 = 1U;
            this.uint_1 = (uint) totalDataSize;
            this.uint_2 = this.uint_1;
          }
          else
          {
            this.uint_0 = totalDataSize > 1048496UL ? (uint) (totalDataSize / 1048496UL) : 1U;
            this.uint_1 = 1048496U;
            this.uint_2 = (uint) (totalDataSize - (ulong) (this.uint_0 * this.uint_1));
            if (this.uint_2 <= 0U)
              return;
            ++this.uint_0;
          }
        }

        public Stream imethod_0(Class741.Class742 serializer)
        {
          PagedMemoryStream pagedMemoryStream = new PagedMemoryStream((long) (int) this.ulong_0);
          int num = 0;
          foreach (Class49.Class52.Class58.Class59 class59 in this.list_0)
          {
            serializer.Stream.Position = serializer.DataStoreStreamStartPosition + (long) serializer.SegmentIndex.Entries[(int) class59.SegmentIndex].Offset;
            Class49.Class56 class56 = new Class49.Class56();
            class56.Read(serializer);
            if ((long) class56.BinaryData.Length != (long) class59.Size)
              throw new Exception("Blob binary data size does not match expected size.");
            StreamUtil.Forward(class56.BinaryData.Stream, class56.BinaryData.Offset, (Stream) pagedMemoryStream, class56.BinaryData.Length);
            num += (int) class59.Size;
          }
          pagedMemoryStream.Position = 0L;
          return (Stream) pagedMemoryStream;
        }

        public void Read(Class889 r, int dataSize)
        {
          long position1 = r.Position;
          this.ulong_0 = r.vmethod_14();
          this.uint_0 = r.vmethod_10();
          int num1 = (int) r.vmethod_10();
          this.uint_1 = r.vmethod_10();
          this.uint_2 = r.vmethod_10();
          int num2 = (int) r.vmethod_10();
          int num3 = (int) r.vmethod_10();
          this.list_0.Capacity = (int) this.uint_0;
          for (int index = 0; (long) index < (long) this.uint_0; ++index)
          {
            Class49.Class52.Class58.Class59 class59 = new Class49.Class52.Class58.Class59();
            class59.Read(r);
            this.list_0.Add(class59);
          }
          long position2 = r.Position;
        }

        public void Write(Class889 w)
        {
          w.vmethod_11(3138415537U);
          w.vmethod_15(this.ulong_0);
          w.vmethod_11(this.uint_0);
          w.vmethod_11((uint) (32 + this.list_0.Count * 8));
          w.vmethod_11(this.uint_1);
          w.vmethod_11(this.uint_2);
          w.vmethod_11(0U);
          w.vmethod_11(0U);
          for (int index = 0; (long) index < (long) this.uint_0; ++index)
            this.list_0[index].Write(w);
        }

        public override string ToString()
        {
          return string.Format("DataRecord, totalDataSize: {0}, pageCount: {1}", (object) this.ulong_0, (object) this.uint_0);
        }

        public void Dump(DumpWriter w)
        {
          w.WriteField("totalDataSize", this.ulong_0);
          w.WriteField("pageCount", this.uint_0);
          w.WriteField("pageSize", this.uint_1);
          w.WriteField("lastPageSize", this.uint_2);
          w.WriteField("pages", (ICollection) this.list_0);
        }

        public class Class59 : IDumpable
        {
          private uint uint_0;
          private uint uint_1;

          public uint SegmentIndex
          {
            get
            {
              return this.uint_0;
            }
            set
            {
              this.uint_0 = value;
            }
          }

          public uint Size
          {
            get
            {
              return this.uint_1;
            }
            set
            {
              this.uint_1 = value;
            }
          }

          internal void Read(Class889 r)
          {
            this.uint_0 = r.vmethod_10();
            this.uint_1 = r.vmethod_10();
          }

          internal void Write(Class889 w)
          {
            w.vmethod_11(this.uint_0);
            w.vmethod_11(this.uint_1);
          }

          public void Dump(DumpWriter w)
          {
            w.WriteField("segmentIndex", this.uint_0);
            w.WriteField("size", this.uint_1);
          }
        }
      }

      public class Class60 : IDumpable
      {
        public const int int_0 = 20;
        private ulong ulong_0;
        private uint uint_0;
        private Interface2 interface2_0;

        public ulong Handle
        {
          get
          {
            return this.ulong_0;
          }
          set
          {
            this.ulong_0 = value;
          }
        }

        public uint LocalOffset
        {
          get
          {
            return this.uint_0;
          }
          set
          {
            this.uint_0 = value;
          }
        }

        public Interface2 ReferencedObject
        {
          get
          {
            return this.interface2_0;
          }
          set
          {
            this.interface2_0 = value;
          }
        }

        internal bool Read(Class889 r)
        {
          if (r.vmethod_10() != 20U)
            throw new Exception("Unexpected DataRecordHeader size.");
          int num = (int) r.vmethod_10();
          this.ulong_0 = r.vmethod_14();
          this.uint_0 = r.vmethod_10();
          return true;
        }

        internal void Write(Class889 w)
        {
          w.vmethod_11(20U);
          w.vmethod_11(1U);
          w.vmethod_15(this.ulong_0);
          w.vmethod_11(this.uint_0);
        }

        public void Dump(DumpWriter w)
        {
          w.WriteField("handle", this.ulong_0);
          w.WriteField("localOffset", this.uint_0);
          w.WriteField("referencedObject", "object");
        }

        public override string ToString()
        {
          return string.Format("Handle: {0}, local offset: {1}, referenced object: {2}", (object) this.ulong_0, (object) this.uint_0, (object) this.interface2_0);
        }
      }

      public enum Enum0
      {
        const_0,
        const_1,
        const_2,
        const_3,
      }
    }

    public class Class61
    {
    }

    internal class Class53 : Class49
    {
      private HashSet<uint> hashSet_0 = new HashSet<uint>();
      private readonly List<string> list_0 = new List<string>();
      private readonly List<Class49.Class53.Class62> list_1 = new List<Class49.Class53.Class62>();
      private readonly List<Class49.Class53.Class63> list_2 = new List<Class49.Class53.Class63>();

      public Class53()
        : base("schidx")
      {
      }

      public HashSet<uint> SegmentIndexes
      {
        get
        {
          return this.hashSet_0;
        }
      }

      public List<string> SchemaNames
      {
        get
        {
          return this.list_0;
        }
      }

      public List<Class49.Class53.Class62> SchemaEntries
      {
        get
        {
          return this.list_1;
        }
      }

      public List<Class49.Class53.Class63> PropertyEntries
      {
        get
        {
          return this.list_2;
        }
      }

      public override void Dump(DumpWriter w)
      {
        base.Dump(w);
        w.OpenObject("segmentIndexes");
        foreach (uint num in this.hashSet_0)
          w.WriteLine(num.ToString() + ",");
        w.CloseObject();
        w.WriteField("schemaNames", (ICollection) this.list_0);
        w.WriteField("schemaEntries", (ICollection) this.list_1);
        w.WriteField("propertyEntries", (ICollection) this.list_2);
      }

      internal override void Read(Class741.Class742 serializer)
      {
        base.Read(serializer);
        Class889 stream = serializer.Stream;
        uint num1 = stream.vmethod_10();
        int num2 = (int) stream.vmethod_10();
        this.list_1.Capacity = (int) num1;
        for (int index = 0; (long) index < (long) num1; ++index)
        {
          Class49.Class53.Class62 class62 = new Class49.Class53.Class62();
          class62.Read(stream);
          this.list_1.Add(class62);
          if (!this.hashSet_0.Contains(class62.SegmentIndex))
            this.hashSet_0.Add(class62.SegmentIndex);
        }
        stream.vmethod_12();
        uint num3 = stream.vmethod_10();
        int num4 = (int) stream.vmethod_10();
        this.list_2.Capacity = (int) num3;
        for (int index = 0; (long) index < (long) num3; ++index)
        {
          Class49.Class53.Class63 class63 = new Class49.Class53.Class63();
          class63.Read(stream);
          this.list_2.Add(class63);
          if (!this.hashSet_0.Contains(class63.SegmentIndex))
            this.hashSet_0.Add(class63.SegmentIndex);
        }
        stream.Position = (long) this.SystemDataOffset;
        uint num5 = stream.vmethod_10();
        for (int index = 0; (long) index < (long) num5; ++index)
          this.list_0.Add(stream.vmethod_18());
      }

      internal override void vmethod_0(Class741.Class742 serializer)
      {
        Class889 stream = serializer.Stream;
        this.list_0.Clear();
        foreach (Class48 schema in serializer.DataStore.Schemas)
          this.list_0.Add(schema.Name);
        stream.vmethod_11((uint) this.list_1.Count);
        stream.vmethod_11(0U);
        foreach (Class49.Class53.Class62 class62 in this.list_1)
          class62.Write(stream);
        stream.vmethod_13(717068L);
        stream.vmethod_11((uint) this.list_2.Count);
        stream.vmethod_11(0U);
        foreach (Class49.Class53.Class63 class63 in this.list_2)
          class63.Write(stream);
        uint num = Class49.smethod_0((uint) ((ulong) stream.Position - this.ulong_0), 16);
        for (int index = 0; (long) index < (long) num; ++index)
          stream.vmethod_1((byte) 115);
        this.SystemDataOffset = (ulong) stream.Position;
        stream.vmethod_11((uint) this.list_0.Count);
        foreach (string str in this.list_0)
          stream.vmethod_20(str);
      }

      public class Class62 : Class49.Class61, IDumpable
      {
        private uint uint_0;
        private uint uint_1;
        private uint uint_2;

        public uint Index
        {
          get
          {
            return this.uint_0;
          }
          set
          {
            this.uint_0 = value;
          }
        }

        public uint SegmentIndex
        {
          get
          {
            return this.uint_1;
          }
          set
          {
            this.uint_1 = value;
          }
        }

        public uint LocalOffset
        {
          get
          {
            return this.uint_2;
          }
          set
          {
            this.uint_2 = value;
          }
        }

        public override string ToString()
        {
          return string.Format("Index: {0}, segment index: {1}, local offset: {2}", (object) this.uint_0, (object) this.uint_1, (object) this.uint_2);
        }

        internal void Read(Class889 r)
        {
          this.uint_0 = r.vmethod_10();
          this.uint_1 = r.vmethod_10();
          this.uint_2 = r.vmethod_10();
        }

        internal void Write(Class889 w)
        {
          w.vmethod_11(this.uint_0);
          w.vmethod_11(this.uint_1);
          w.vmethod_11(this.uint_2);
        }

        public void Dump(DumpWriter w)
        {
          w.WriteField("index", this.uint_0);
          w.WriteField("segmentIndex", this.uint_1);
          w.WriteField("localOffset", this.uint_2);
        }
      }

      public class Class63 : Class49.Class61, IDumpable
      {
        private uint uint_0;
        private uint uint_1;
        private uint uint_2;

        public uint Index
        {
          get
          {
            return this.uint_0;
          }
          set
          {
            this.uint_0 = value;
          }
        }

        public uint SegmentIndex
        {
          get
          {
            return this.uint_1;
          }
          set
          {
            this.uint_1 = value;
          }
        }

        public uint LocalOffset
        {
          get
          {
            return this.uint_2;
          }
          set
          {
            this.uint_2 = value;
          }
        }

        public override string ToString()
        {
          return string.Format("Index: {0}, segment index: {1}, local offset: {2}", (object) this.uint_0, (object) this.uint_1, (object) this.uint_2);
        }

        internal void Read(Class889 r)
        {
          this.uint_1 = r.vmethod_10();
          this.uint_2 = r.vmethod_10();
          this.uint_0 = r.vmethod_10();
        }

        internal void Write(Class889 w)
        {
          w.vmethod_11(this.uint_1);
          w.vmethod_11(this.uint_2);
          w.vmethod_11(this.uint_0);
        }

        public void Dump(DumpWriter w)
        {
          w.WriteField("index", this.uint_0);
          w.WriteField("segmentIndex", this.uint_1);
          w.WriteField("localOffset", this.uint_2);
        }
      }
    }

    internal class Class54 : Class49
    {
      private readonly List<Class49.Class54.Class64> list_0 = new List<Class49.Class54.Class64>();

      public Class54()
        : base("datidx")
      {
      }

      public List<Class49.Class54.Class64> Entries
      {
        get
        {
          return this.list_0;
        }
      }

      public override void Dump(DumpWriter w)
      {
        base.Dump(w);
        w.WriteField("entries", (ICollection) this.list_0);
      }

      internal override void Read(Class741.Class742 serializer)
      {
        base.Read(serializer);
        Class889 stream = serializer.Stream;
        int num = stream.vmethod_8();
        stream.vmethod_8();
        this.list_0.Capacity = num;
        for (int index = 0; index < num; ++index)
        {
          Class49.Class54.Class64 class64 = new Class49.Class54.Class64();
          class64.Read(stream);
          this.list_0.Add(class64);
        }
      }

      internal override void vmethod_0(Class741.Class742 serializer)
      {
        Class889 stream = serializer.Stream;
        stream.vmethod_9(this.list_0.Count);
        stream.vmethod_9(0);
        foreach (Class49.Class54.Class64 class64 in this.list_0)
          class64.Write(stream);
      }

      public class Class64 : Class49.Class61
      {
        private uint uint_0;
        private uint uint_1;
        private uint uint_2;

        public uint SegmentIndex
        {
          get
          {
            return this.uint_0;
          }
          set
          {
            this.uint_0 = value;
          }
        }

        public bool IsStubEntry
        {
          get
          {
            return this.uint_0 == 0U;
          }
        }

        public uint LocalOffset
        {
          get
          {
            return this.uint_1;
          }
          set
          {
            this.uint_1 = value;
          }
        }

        public uint SchemaIndex
        {
          get
          {
            return this.uint_2;
          }
          set
          {
            this.uint_2 = value;
          }
        }

        internal void Read(Class889 r)
        {
          this.uint_0 = r.vmethod_10();
          this.uint_1 = r.vmethod_10();
          this.uint_2 = r.vmethod_10();
        }

        internal void Write(Class889 w)
        {
          w.vmethod_11(this.uint_0);
          w.vmethod_11(this.uint_1);
          w.vmethod_11(this.uint_2);
        }
      }
    }

    internal class Class55 : Class49
    {
      private readonly List<Class48> list_0 = new List<Class48>();
      private readonly List<Class558> list_1 = new List<Class558>();

      public Class55()
        : base("schdat")
      {
      }

      public List<Class48> Schemas
      {
        get
        {
          return this.list_0;
        }
      }

      public List<Class558> UnknownProperties
      {
        get
        {
          return this.list_1;
        }
      }

      public override void Dump(DumpWriter w)
      {
        base.Dump(w);
        w.WriteField("schemas", (ICollection) this.list_0);
        w.WriteField("unknownProperties", (ICollection) this.list_1);
      }

      internal override void Read(Class741.Class742 serializer)
      {
        base.Read(serializer);
        Class889 stream = serializer.Stream;
        long position = stream.Position;
        foreach (Class49.Class53.Class63 propertyEntry in serializer.SchemaIndex.PropertyEntries)
        {
          if ((int) propertyEntry.SegmentIndex == (int) this.class681_0.SegmentIndex)
          {
            Class558 class558 = new Class558();
            class558.Read(stream);
            this.list_1.Add(class558);
          }
        }
        uint num1 = 0;
        foreach (Class49.Class53.Class62 schemaEntry in serializer.SchemaIndex.SchemaEntries)
        {
          if ((int) schemaEntry.SegmentIndex == (int) this.class681_0.SegmentIndex)
          {
            stream.Position = position + (long) schemaEntry.LocalOffset;
            Class48 class48 = new Class48();
            class48.Index = num1;
            class48.Name = serializer.SchemaIndex.SchemaNames[(int) schemaEntry.Index];
            class48.Read(stream);
            this.list_0.Add(class48);
          }
          ++num1;
        }
        stream.Position = (long) this.SystemDataOffset;
        uint num2 = stream.vmethod_10();
        List<string> stringList = new List<string>((int) num2);
        for (int index = 0; (long) index < (long) num2; ++index)
          stringList.Add(stream.vmethod_18());
        for (int index = 0; index < this.list_0.Count; ++index)
        {
          foreach (Class986 property in this.list_0[index].Properties)
          {
            property.Name = stringList[(int) property.NameIndex];
            property.NameIndex = uint.MaxValue;
          }
        }
      }

      internal override void vmethod_0(Class741.Class742 serializer)
      {
        Class889 stream = serializer.Stream;
        long position = stream.Position;
        uint num1 = serializer.SchemaIndex.PropertyEntries.Count == 0 ? 1U : serializer.SchemaIndex.PropertyEntries[serializer.SchemaIndex.PropertyEntries.Count - 1].Index + 1U;
        foreach (Class558 class558 in this.list_1)
        {
          uint num2 = (uint) (stream.Position - position);
          serializer.SchemaIndex.PropertyEntries.Add(new Class49.Class53.Class63()
          {
            Index = num1,
            SegmentIndex = this.class681_0.SegmentIndex,
            LocalOffset = num2
          });
          class558.Write(stream);
          ++num1;
        }
        List<string> stringList = new List<string>();
        Dictionary<string, uint> dictionary = new Dictionary<string, uint>();
        foreach (Class48 class48 in this.list_0)
        {
          foreach (Class986 property in class48.Properties)
          {
            uint count;
            if (!dictionary.TryGetValue(property.Name, out count))
            {
              count = (uint) stringList.Count;
              stringList.Add(property.Name);
              dictionary.Add(property.Name, count);
            }
            property.NameIndex = count;
          }
        }
        if (serializer.SchemaIndex.SchemaEntries.Count != 0)
          throw new Exception("SchemaIndex.SchemaEntries is expected to have 0 elements.");
        uint num3 = 0;
        foreach (Class48 class48 in this.list_0)
        {
          uint num2 = (uint) (stream.Position - position);
          serializer.SchemaIndex.SchemaEntries.Add(new Class49.Class53.Class62()
          {
            Index = num3,
            SegmentIndex = this.class681_0.SegmentIndex,
            LocalOffset = num2
          });
          class48.Write(stream);
          ++num3;
        }
        uint num4 = Class49.smethod_0((uint) (stream.Position - position), 16);
        for (int index = 0; (long) index < (long) num4; ++index)
          stream.vmethod_1((byte) 115);
        this.SystemDataOffset = (ulong) stream.Position;
        stream.vmethod_11((uint) stringList.Count);
        foreach (string str in stringList)
          stream.vmethod_20(str);
      }
    }

    internal class Class56 : Class49
    {
      private ulong ulong_1;
      private ulong ulong_2;
      private int int_2;
      private int int_3;
      private ulong ulong_3;
      private Class882 class882_0;

      public Class56()
        : base("blob01")
      {
      }

      public ulong TotalDataSize
      {
        get
        {
          return this.ulong_1;
        }
        set
        {
          this.ulong_1 = value;
        }
      }

      public ulong PageStartOffset
      {
        get
        {
          return this.ulong_2;
        }
        set
        {
          this.ulong_2 = value;
        }
      }

      public int PageIndex
      {
        get
        {
          return this.int_2;
        }
        set
        {
          this.int_2 = value;
        }
      }

      public int PageCount
      {
        get
        {
          return this.int_3;
        }
        set
        {
          this.int_3 = value;
        }
      }

      public ulong PageDataSize
      {
        get
        {
          return this.ulong_3;
        }
        set
        {
          this.ulong_3 = value;
        }
      }

      public Class882 BinaryData
      {
        get
        {
          return this.class882_0;
        }
        set
        {
          this.class882_0 = value;
        }
      }

      public new void Dump(DumpWriter w)
      {
        w.WriteField("totalDataSize", this.ulong_1);
        w.WriteField("pageStartOffset", this.ulong_2);
        w.WriteField("pageIndex", this.int_2);
        w.WriteField("pageCount", this.int_3);
        w.WriteField("pageDataSize", this.ulong_3);
        w.WriteField("binaryData", (IDumpable) this.class882_0);
      }

      internal override void Read(Class741.Class742 serializer)
      {
        base.Read(serializer);
        Class889 stream = serializer.Stream;
        this.ulong_1 = stream.vmethod_14();
        this.ulong_2 = stream.vmethod_14();
        this.int_2 = stream.vmethod_8();
        this.int_3 = stream.vmethod_8();
        this.ulong_3 = stream.vmethod_14();
        this.class882_0 = new Class882((Stream) new PagedMemoryStream(stream.Stream, (long) (int) this.ulong_3), 0, (int) this.ulong_3);
      }

      internal override void vmethod_0(Class741.Class742 serializer)
      {
        Class889 stream = serializer.Stream;
        stream.vmethod_15(this.ulong_1);
        stream.vmethod_15(this.ulong_2);
        stream.vmethod_9(this.int_2);
        stream.vmethod_9(this.int_3);
        stream.vmethod_15(this.ulong_3);
        StreamUtil.Forward(this.class882_0.Stream, this.class882_0.Offset, stream.Stream, this.class882_0.Length);
      }
    }
  }
}
