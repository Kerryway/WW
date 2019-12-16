// Decompiled with JetBrains decompiler
// Type: ns29.Class620
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ns29
{
  internal class Class620 : Interface37
  {
    private LinkedList<Interface37> linkedList_0;

    public LinkedList<Interface37> Drawables
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

    internal void method_0()
    {
      if (this.linkedList_0 == null)
        return;
      this.linkedList_0.Clear();
    }

    public void Draw(ICollection<FrameworkElement> targetElements)
    {
      if (this.linkedList_0 == null)
        return;
      for (LinkedListNode<Interface37> linkedListNode = this.linkedList_0.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
        linkedListNode.Value.Draw(targetElements);
    }

    public void Draw(UIElementCollection targetElements)
    {
      if (this.linkedList_0 == null)
        return;
      for (LinkedListNode<Interface37> linkedListNode = this.linkedList_0.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
        linkedListNode.Value.Draw(targetElements);
    }
  }
}
