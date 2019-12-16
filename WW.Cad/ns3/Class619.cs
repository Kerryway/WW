// Decompiled with JetBrains decompiler
// Type: ns3.Class619
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections;
using System.Collections.Generic;

namespace ns3
{
  internal class Class619 : IEnumerable, ICollection<Class259>, IEnumerable<Class259>
  {
    private LinkedList<Class259> linkedList_0 = new LinkedList<Class259>();

    public void Add(Class259 item)
    {
      item.ListNode = this.linkedList_0.AddLast(item);
    }

    public void Clear()
    {
      foreach (Class259 class259 in this.linkedList_0)
        class259.ListNode = (LinkedListNode<Class259>) null;
      this.linkedList_0.Clear();
    }

    public bool Contains(Class259 item)
    {
      return this.linkedList_0.Contains(item);
    }

    public void CopyTo(Class259[] array, int arrayIndex)
    {
      this.linkedList_0.CopyTo(array, arrayIndex);
    }

    public int Count
    {
      get
      {
        return this.linkedList_0.Count;
      }
    }

    public bool IsReadOnly
    {
      get
      {
        return false;
      }
    }

    public bool Remove(Class259 item)
    {
      bool flag;
      if (flag = this.linkedList_0.Remove(item))
        item.ListNode = (LinkedListNode<Class259>) null;
      return flag;
    }

    public IEnumerator<Class259> GetEnumerator()
    {
      return (IEnumerator<Class259>) this.linkedList_0.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this.linkedList_0.GetEnumerator();
    }
  }
}
