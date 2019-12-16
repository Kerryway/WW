// Decompiled with JetBrains decompiler
// Type: ns3.Class259
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System;
using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class259 : Interface10
  {
    private DxfHandledObject dxfHandledObject_0;
    private bool bool_0;
    private ulong ulong_0;
    private ulong ulong_1;
    private LinkedList<Interface10> linkedList_0;
    private short short_0;
    private List<ulong> list_0;
    private Dictionary<string, DxfExtendedData> dictionary_0;
    private LinkedListNode<Class259> linkedListNode_0;

    public Class259(DxfHandledObject handledObject)
    {
      this.dxfHandledObject_0 = handledObject;
    }

    public DxfHandledObject HandledObject
    {
      get
      {
        return this.dxfHandledObject_0;
      }
      set
      {
        this.dxfHandledObject_0 = value;
      }
    }

    public bool IsValid
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public ulong OwnerHandle
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

    public ulong ExtensionDictionaryHandle
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

    public ICollection<Interface10> ChildBuilders
    {
      get
      {
        if (this.linkedList_0 == null)
          this.linkedList_0 = new LinkedList<Interface10>();
        return (ICollection<Interface10>) this.linkedList_0;
      }
    }

    public short ObjectType
    {
      get
      {
        return this.short_0;
      }
      set
      {
        this.short_0 = value;
      }
    }

    public Dictionary<string, DxfExtendedData> AppIdToExtendedData
    {
      get
      {
        if (this.dictionary_0 == null)
          this.dictionary_0 = new Dictionary<string, DxfExtendedData>();
        return this.dictionary_0;
      }
    }

    public LinkedListNode<Class259> ListNode
    {
      get
      {
        return this.linkedListNode_0;
      }
      set
      {
        if (value != null && this.linkedListNode_0 != null)
          throw new ArgumentException("Object builder was already part of a linked list.");
        this.linkedListNode_0 = value;
      }
    }

    public void method_0(ulong handle)
    {
      if (this.list_0 == null)
        this.list_0 = new List<ulong>();
      this.list_0.Add(handle);
    }

    public virtual void ResolveReferences(Class374 modelBuilder)
    {
      if (this.ulong_0 != 0UL && this.dxfHandledObject_0.OwnerObjectSoftReference == null)
      {
        DxfHandledObject dxfHandledObject = modelBuilder.method_3(this.ulong_0);
        if (dxfHandledObject != null)
          this.dxfHandledObject_0.vmethod_2((IDxfHandledObject) dxfHandledObject);
      }
      if (this.ulong_1 != 0UL)
      {
        DxfDictionary dxfDictionary = modelBuilder.method_4<DxfDictionary>(this.ulong_1);
        if (dxfDictionary != null)
          this.dxfHandledObject_0.ExtensionDictionary = dxfDictionary;
      }
      modelBuilder.ResolveReferences((ICollection<Interface10>) this.linkedList_0);
      if (this.list_0 == null)
        return;
      foreach (ulong handle in this.list_0)
      {
        DxfHandledObject reactor = modelBuilder.method_3(handle);
        if (reactor != null)
          this.dxfHandledObject_0.AddPersistentReactor(reactor);
      }
    }
  }
}
