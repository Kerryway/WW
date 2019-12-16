// Decompiled with JetBrains decompiler
// Type: ns3.Class322
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Model;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class322 : Class259
  {
    protected Class322(DxfHandledObject blockRecordTable)
      : base(blockRecordTable)
    {
    }

    internal class Class323 : Class322
    {
      public Class323(DxfHandledObject blockRecordTable)
        : base(blockRecordTable)
      {
      }

      public override void ResolveReferences(Class374 modelBuilder)
      {
        base.ResolveReferences(modelBuilder);
        foreach (Class318 blockBuilder in modelBuilder.BlockBuilders)
          modelBuilder.Model.method_38((DxfBlock) blockBuilder.HandledObject, (IList<DxfMessage>) modelBuilder.Messages, true);
      }
    }

    internal class Class324 : Class322
    {
      private List<ulong> list_1 = new List<ulong>();
      private int int_0;
      private ulong ulong_2;
      private ulong ulong_3;

      public Class324(DxfHandledObject blockRecordTable)
        : base(blockRecordTable)
      {
      }

      public int EntryCount
      {
        get
        {
          return this.int_0;
        }
        set
        {
          this.int_0 = value;
        }
      }

      public List<ulong> BlockRecordHandles
      {
        get
        {
          return this.list_1;
        }
      }

      public ulong ModelSpaceBlockRecordHandle
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

      public ulong PaperSpaceBlockRecordHandle
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

      public override void ResolveReferences(Class374 modelBuilder)
      {
        base.ResolveReferences(modelBuilder);
        Class322.Class324.smethod_0(modelBuilder, this.ulong_2);
        Class322.Class324.smethod_0(modelBuilder, this.ulong_3);
        foreach (ulong handle in this.list_1)
          Class322.Class324.smethod_0(modelBuilder, handle);
      }

      private static void smethod_0(Class374 modelBuilder, ulong handle)
      {
        DxfBlock block = modelBuilder.method_4<DxfBlock>(handle);
        if (block == null)
          return;
        modelBuilder.Model.method_38(block, (IList<DxfMessage>) modelBuilder.Messages, true);
      }
    }
  }
}
