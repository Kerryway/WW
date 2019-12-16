// Decompiled with JetBrains decompiler
// Type: WW.Collections.Generic.LinkedListNodeRef`1
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;

namespace WW.Collections.Generic
{
  public class LinkedListNodeRef<T>
  {
    private System.Collections.Generic.LinkedList<T> linkedList_0;
    private LinkedListNode<T> linkedListNode_0;

    public LinkedListNodeRef(System.Collections.Generic.LinkedList<T> linkedList)
    {
      this.Initialize(linkedList);
    }

    public LinkedListNodeRef(System.Collections.Generic.LinkedList<T> linkedList, LinkedListNode<T> currentNode)
    {
      this.Initialize(linkedList, currentNode);
    }

    public System.Collections.Generic.LinkedList<T> LinkedList
    {
      get
      {
        return this.linkedList_0;
      }
      set
      {
        this.linkedList_0 = value;
      }
    }

    public LinkedListNode<T> CurrentNode
    {
      get
      {
        return this.linkedListNode_0;
      }
      set
      {
        this.linkedListNode_0 = value;
      }
    }

    public void Initialize(System.Collections.Generic.LinkedList<T> linkedList, LinkedListNode<T> currentNode)
    {
      this.linkedList_0 = linkedList;
      this.linkedListNode_0 = currentNode;
    }

    public void Initialize(System.Collections.Generic.LinkedList<T> linkedList)
    {
      this.linkedList_0 = linkedList;
      this.linkedListNode_0 = linkedList == null ? (LinkedListNode<T>) null : linkedList.Last;
    }

    public LinkedListNode<T> Insert(T value)
    {
      if (this.linkedList_0 == null)
      {
        this.linkedList_0 = new System.Collections.Generic.LinkedList<T>();
        this.linkedListNode_0 = this.linkedList_0.AddLast(value);
      }
      else
        this.linkedListNode_0 = this.linkedListNode_0 != null ? this.linkedList_0.AddAfter(this.linkedListNode_0, value) : this.linkedList_0.AddLast(value);
      return this.linkedListNode_0;
    }
  }
}
