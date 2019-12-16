// Decompiled with JetBrains decompiler
// Type: ns3.Class318
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class318 : Class259
  {
    private readonly List<DxfViewport> list_2 = new List<DxfViewport>();
    private int int_0;
    private bool bool_1;
    private ulong ulong_2;
    private ulong ulong_3;
    private ulong ulong_4;
    private List<ulong> list_1;
    private ulong ulong_5;
    private ulong ulong_6;
    private HashSet<DxfEntity> hashSet_0;

    public Class318(DxfBlock blockRecord)
      : base((DxfHandledObject) blockRecord)
    {
    }

    public int CrossRefIndex
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

    public ulong BlockBeginHandle
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

    public ulong FirstEntityHandle
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

    public ulong LastEntityHandle
    {
      get
      {
        return this.ulong_4;
      }
      set
      {
        this.ulong_4 = value;
      }
    }

    public List<ulong> OwnedEntityHandles
    {
      get
      {
        if (this.list_1 == null)
          this.list_1 = new List<ulong>();
        return this.list_1;
      }
    }

    public ulong BlockEndHandle
    {
      get
      {
        return this.ulong_5;
      }
      set
      {
        this.ulong_5 = value;
      }
    }

    public ulong LayoutHandle
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

    public List<DxfViewport> OrderedViewports
    {
      get
      {
        return this.list_2;
      }
    }

    public void method_1(DxfEntity entity)
    {
      if (this.hashSet_0 == null)
        this.hashSet_0 = new HashSet<DxfEntity>();
      if (this.hashSet_0.Contains(entity))
        return;
      this.hashSet_0.Add(entity);
    }

    public void method_2()
    {
      if (this.hashSet_0 == null)
        return;
      DxfBlock handledObject = (DxfBlock) this.HandledObject;
      DxfEntityCollection entities = handledObject.Entities;
      DxfEntity[] array = entities.ToArray();
      handledObject.Deactivate();
      entities.Clear();
      foreach (DxfEntity dxfEntity in array)
      {
        if (!this.hashSet_0.Contains(dxfEntity))
          entities.Add(dxfEntity);
      }
      handledObject.method_11();
    }

    public override string ToString()
    {
      string str = ((DxfTableRecord) this.HandledObject).Name;
      if (this.ulong_3 != 0UL)
        str = str + ", first entity handle: " + this.ulong_3.ToString("X") + ", last entity handle: " + this.ulong_4.ToString("X");
      return str;
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfBlock handledObject1 = (DxfBlock) this.HandledObject;
      if (this.ulong_2 != 0UL)
        handledObject1.BlockBegin = modelBuilder.method_4<DxfBlockBegin>(this.ulong_2);
      if (this.ulong_6 != 0UL)
      {
        Class284 class284 = modelBuilder.method_5(this.ulong_6) as Class284;
        if (class284 != null)
        {
          if ((long) class284.AssociatedBockRecordHandle == (long) handledObject1.Handle)
          {
            DxfLayout handledObject2 = (DxfLayout) class284.HandledObject;
            if (handledObject2 != null)
              handledObject1.Layout = handledObject2;
          }
          else
            modelBuilder.Messages.Add(new DxfMessage(DxfStatus.BlockLayoutReferenceCorrupt, Severity.Warning, "BlockHandle", (object) handledObject1.Handle)
            {
              Parameters = {
                {
                  "BlockName",
                  (object) handledObject1.Name
                }
              }
            });
        }
      }
      if (this.ulong_3 != 0UL && this.ulong_4 != 0UL)
      {
        for (Class285 entityBuilder = modelBuilder.method_6(this.ulong_3); entityBuilder != null; entityBuilder = modelBuilder.method_7(entityBuilder))
        {
          DxfEntity entity = entityBuilder.Entity;
          this.method_3(modelBuilder, handledObject1, entity);
          if ((long) entityBuilder.HandledObject.Handle == (long) this.ulong_4)
            break;
        }
      }
      else if (this.list_1 != null)
      {
        foreach (ulong handle in this.list_1)
        {
          Class285 class285 = modelBuilder.method_6(handle);
          if (class285 != null)
          {
            DxfEntity entity = class285.Entity;
            this.method_3(modelBuilder, handledObject1, entity);
          }
        }
      }
      if (this.ulong_5 != 0UL)
        handledObject1.BlockEnd = modelBuilder.method_4<DxfBlockEnd>(this.ulong_5);
      if (handledObject1.ExtensionDictionary == null || !handledObject1.ExtensionDictionary.Entries.Contains("ACAD_UNLOAD"))
        return;
      handledObject1.IsExternalReferenceUnloaded = true;
    }

    private void method_3(Class374 modelBuilder, DxfBlock block, DxfEntity entity)
    {
      DxfViewport dxfViewport = entity as DxfViewport;
      if (dxfViewport != null)
      {
        this.list_2.Add(dxfViewport);
      }
      else
      {
        if (!modelBuilder.LoadUnknownObjects && entity is DxfUnknownEntity)
          return;
        block.Entities.Add(entity);
      }
    }
  }
}
