// Decompiled with JetBrains decompiler
// Type: ns3.Class294
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class294 : Class285
  {
    private string string_2;
    private ulong ulong_6;
    private bool bool_1;
    private ulong ulong_7;
    private ulong ulong_8;
    private List<ulong> list_1;
    private ulong ulong_9;

    public Class294(DxfInsertBase insert)
      : base((DxfEntity) insert)
    {
    }

    public string BlockName
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

    public ulong BlockHeaderHandle
    {
      get
      {
        return this.ulong_6;
      }
      set
      {
        this.ulong_6 = value;
      }
    }

    public bool HasAttributes
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public ulong FirstAttributeHandle
    {
      get
      {
        return this.ulong_7;
      }
      set
      {
        this.ulong_7 = value;
      }
    }

    public ulong LastAttributeHandle
    {
      get
      {
        return this.ulong_8;
      }
      set
      {
        this.ulong_8 = value;
      }
    }

    public List<ulong> AttributeHandles
    {
      get
      {
        if (this.list_1 == null)
          this.list_1 = new List<ulong>();
        return this.list_1;
      }
    }

    public ulong EndSequenceHandle
    {
      get
      {
        return this.ulong_9;
      }
      set
      {
        this.ulong_9 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfInsertBase handledObject = (DxfInsertBase) this.HandledObject;
      if (this.ulong_6 != 0UL)
      {
        DxfBlock dxfBlock = modelBuilder.method_3(this.ulong_6) as DxfBlock;
        if (dxfBlock != null)
          handledObject.Block = dxfBlock;
        else
          modelBuilder.Messages.Add(new DxfMessage(DxfStatus.UnresolvedReference, Severity.Warning)
          {
            Parameters = {
              {
                "Type",
                (object) "BLOCK_RECORD"
              },
              {
                "Handle",
                (object) this.ulong_6
              },
              {
                "Insert",
                (object) handledObject
              },
              {
                "InsertHandle",
                (object) handledObject.Handle
              }
            }
          });
      }
      else if (!string.IsNullOrEmpty(this.string_2))
      {
        handledObject.Block = modelBuilder.Model.GetBlockWithName(this.string_2);
        if (handledObject.Block == null)
          modelBuilder.Messages.Add(new DxfMessage(DxfStatus.UnresolvedReference, Severity.Warning)
          {
            Parameters = {
              {
                "Type",
                (object) "BLOCK_RECORD"
              },
              {
                "Name",
                (object) this.string_2
              },
              {
                "Insert",
                (object) handledObject
              },
              {
                "InsertHandle",
                (object) handledObject.Handle
              }
            }
          });
      }
      if (this.ulong_7 != 0UL)
      {
        for (Class285 entityBuilder = modelBuilder.method_6(this.ulong_7); entityBuilder != null; entityBuilder = modelBuilder.method_7(entityBuilder))
        {
          handledObject.Attributes.Add((DxfAttribute) entityBuilder.Entity);
          if ((long) entityBuilder.HandledObject.Handle == (long) this.ulong_8)
            break;
        }
      }
      else if (this.list_1 != null)
      {
        foreach (ulong handle in this.list_1)
        {
          DxfAttribute dxfAttribute = modelBuilder.method_4<DxfAttribute>(handle);
          if (dxfAttribute != null)
            handledObject.Attributes.Add(dxfAttribute);
        }
      }
      if (this.ulong_9 == 0UL)
        return;
      DxfSequenceEnd dxfSequenceEnd = modelBuilder.method_4<DxfSequenceEnd>(this.ulong_9);
      if (dxfSequenceEnd == null)
        return;
      handledObject.AttributesSeqEnd = dxfSequenceEnd;
    }
  }
}
