// Decompiled with JetBrains decompiler
// Type: ns30.Class664
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Drawing;
using WW.Math;

namespace ns30
{
  internal class Class664 : Interface12
  {
    private LinkedList<Interface12> linkedList_0;

    public LinkedList<Interface12> Drawables
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

    public void Draw(Class385 context)
    {
      if (this.linkedList_0 == null)
        return;
      for (LinkedListNode<Interface12> linkedListNode = this.linkedList_0.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
        linkedListNode.Value.Draw(context);
    }

    public void Draw(Class386 context)
    {
      if (this.linkedList_0 == null)
        return;
      for (LinkedListNode<Interface12> linkedListNode = this.linkedList_0.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
        linkedListNode.Value.Draw(context);
    }

    public void BoundingBox(Bounds3D bounds, Matrix4D transform)
    {
      if (this.linkedList_0 == null)
        return;
      for (LinkedListNode<Interface12> linkedListNode = this.linkedList_0.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
        linkedListNode.Value.BoundingBox(bounds, transform);
    }

    public void Transform(ITransformer4D transformer, GraphicsConfig graphicsConfig)
    {
      if (this.linkedList_0 == null)
        return;
      for (LinkedListNode<Interface12> linkedListNode = this.linkedList_0.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
        linkedListNode.Value.Transform(transformer, graphicsConfig);
    }
  }
}
