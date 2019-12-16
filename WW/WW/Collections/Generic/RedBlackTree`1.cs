// Decompiled with JetBrains decompiler
// Type: WW.Collections.Generic.RedBlackTree`1
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections;
using System.Collections.Generic;

namespace WW.Collections.Generic
{
  public class RedBlackTree<T> : ICollection<T>, IEnumerable<T>, IEnumerable
  {
    private RedBlackTree<T>.Node node_0;
    private IComparer<T> icomparer_0;
    private int int_0;

    public RedBlackTree(IComparer<T> comparer)
    {
      this.icomparer_0 = comparer;
    }

    public RedBlackTree()
    {
      this.icomparer_0 = (IComparer<T>) Comparer<T>.Default;
    }

    public RedBlackTree<T>.Node TryAdd(T value)
    {
      RedBlackTree<T>.Node node1;
      if (this.node_0 == null)
      {
        this.node_0 = new RedBlackTree<T>.Node(value);
        node1 = this.node_0;
      }
      else
      {
        RedBlackTree<T>.Node node2 = new RedBlackTree<T>.Node(default (T));
        node2.IsRed = false;
        node2.Right = this.node_0;
        node1 = node2.method_4(value, this.icomparer_0);
        this.node_0 = node2.Right;
      }
      this.node_0.IsRed = false;
      this.node_0.Parent = (RedBlackTree<T>.Node) null;
      if (node1 != null)
        ++this.int_0;
      return node1;
    }

    public T Find(T value)
    {
      RedBlackTree<T>.Node node = this.FindNode(value);
      if (node == null)
        return default (T);
      return node.Value;
    }

    public T Find(IComparable<T> comparer)
    {
      RedBlackTree<T>.Node node;
      int num;
      for (node = this.node_0; node != null; node = num < 0 ? node.Left : node.Right)
      {
        num = comparer.CompareTo(node.Value);
        if (num == 0)
          break;
      }
      if (node == null)
        return default (T);
      return node.Value;
    }

    public RedBlackTree<T>.Node FindNode(T value)
    {
      RedBlackTree<T>.Node node;
      int num;
      for (node = this.node_0; node != null; node = num < 0 ? node.Left : node.Right)
      {
        num = this.icomparer_0.Compare(value, node.Value);
        if (num == 0)
          break;
      }
      return node;
    }

    public RedBlackTree<T>.ForwardEnumerator GetEnumerator(T target)
    {
      return new RedBlackTree<T>.ForwardEnumerator(this, target);
    }

    public RedBlackTree<T>.ReverseEnumerator GetReverseEnumerator()
    {
      return new RedBlackTree<T>.ReverseEnumerator(this);
    }

    public RedBlackTree<T>.ReverseEnumerator GetReverseEnumerator(T target)
    {
      return new RedBlackTree<T>.ReverseEnumerator(this, target);
    }

    public void ReverseNodes(RedBlackTree<T>.Node first, RedBlackTree<T>.Node last)
    {
      if (first == last)
        return;
      RedBlackTree<T>.Node child1 = first;
      RedBlackTree<T>.Node child2 = last;
      while (true)
      {
        RedBlackTree<T>.Node next = child1.GetNext();
        RedBlackTree<T>.Node previous = child2.GetPrevious();
        bool flag = next == previous || next == child2;
        if (child1.Parent == child2)
        {
          RedBlackTree<T>.Node node = child1;
          child1 = child2;
          child2 = node;
        }
        RedBlackTree<T>.Node left1 = child1.Left;
        RedBlackTree<T>.Node right1 = child1.Right;
        RedBlackTree<T>.Node parent1 = child1.Parent;
        bool isRed1 = child1.IsRed;
        RedBlackTree<T>.Node left2 = child2.Left;
        RedBlackTree<T>.Node right2 = child2.Right;
        RedBlackTree<T>.Node parent2 = child2.Parent;
        bool isRed2 = child2.IsRed;
        if (child1.Right == child2)
        {
          child1.Left = left2;
          child1.Right = right2;
          child2.Left = left1;
          child2.Right = child1;
          if (parent1 == null)
          {
            this.node_0 = child2;
            child2.Parent = (RedBlackTree<T>.Node) null;
          }
          else
            parent1.method_1(parent1.Left == child1, child2);
        }
        else if (child1.Left == child2)
        {
          child1.Left = left2;
          child1.Right = right2;
          child2.Left = child1;
          child2.Right = right1;
          if (parent1 == null)
          {
            this.node_0 = child2;
            child2.Parent = (RedBlackTree<T>.Node) null;
          }
          else
            parent1.method_1(parent1.Left == child1, child2);
        }
        else
        {
          child1.Left = left2;
          child1.Right = right2;
          if (parent2 == null)
          {
            this.node_0 = child1;
            child1.Parent = (RedBlackTree<T>.Node) null;
          }
          else
            parent2.method_1(parent2.Left == child2, child1);
          child2.Left = left1;
          child2.Right = right1;
          if (parent1 == null)
          {
            this.node_0 = child2;
            child2.Parent = (RedBlackTree<T>.Node) null;
          }
          else
            parent1.method_1(parent1.Left == child1, child2);
        }
        child1.IsRed = isRed2;
        child2.IsRed = isRed1;
        if (!flag)
        {
          child1 = next;
          child2 = previous;
        }
        else
          break;
      }
    }

    public int Count
    {
      get
      {
        return this.int_0;
      }
    }

    public void Add(T value)
    {
      if (this.TryAdd(value) == null)
        throw new ArgumentException("Duplicate key.");
    }

    public bool Remove(T value)
    {
      RedBlackTree<T>.Node node;
      if ((node = this.FindNode(value)) == null)
        return false;
      this.Remove(node);
      return true;
    }

    internal bool method_0(T value)
    {
      RedBlackTree<T>.Node node = new RedBlackTree<T>.Node(default (T));
      node.IsRed = false;
      node.Right = this.node_0;
      this.int_0 -= node.method_5(value, this.icomparer_0);
      this.node_0 = node.Right;
      if (this.node_0 != null)
      {
        this.node_0.IsRed = false;
        this.node_0.Parent = (RedBlackTree<T>.Node) null;
      }
      return true;
    }

    public void Remove(RedBlackTree<T>.Node node)
    {
      if (node == null)
        throw new ArgumentNullException();
      node.method_6(ref this.node_0);
      --this.int_0;
    }

    public void Clear()
    {
      this.node_0 = (RedBlackTree<T>.Node) null;
      this.int_0 = 0;
    }

    public bool Contains(T item)
    {
      return this.FindNode(item) != null;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
      foreach (T obj in this)
        array[arrayIndex++] = obj;
    }

    public bool IsReadOnly
    {
      get
      {
        return false;
      }
    }

    public IEnumerator<T> GetEnumerator()
    {
      return (IEnumerator<T>) new RedBlackTree<T>.ForwardEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) new RedBlackTree<T>.ForwardEnumerator(this);
    }

    internal RedBlackTree<T>.Node Root
    {
      get
      {
        return this.node_0;
      }
    }

    internal void method_1()
    {
      if (this.method_3(this.node_0, true, 0) == 0)
        throw new Exception("Invalid tree.");
      if (this.node_0 == null)
        return;
      if (this.node_0.Parent != null)
        throw new Exception("root.Parent should be null.");
      RedBlackTree<T>.ForwardEnumerator forwardEnumerator = new RedBlackTree<T>.ForwardEnumerator(this);
      while (forwardEnumerator.MoveNext())
        forwardEnumerator.CurrentNode.method_3();
    }

    internal void method_2(out bool isInvalidTree, out bool rootParentNotNull)
    {
      isInvalidTree = false;
      rootParentNotNull = false;
      if (this.method_3(this.node_0, true, 0) == 0)
        isInvalidTree = true;
      if (this.node_0 == null)
        return;
      if (this.node_0.Parent != null)
        rootParentNotNull = true;
      RedBlackTree<T>.ForwardEnumerator forwardEnumerator = new RedBlackTree<T>.ForwardEnumerator(this);
      while (forwardEnumerator.MoveNext())
        forwardEnumerator.CurrentNode.method_3();
    }

    private int method_3(RedBlackTree<T>.Node root, bool testOrder, int recursionDepth)
    {
      if (recursionDepth > 100)
        throw new Exception("Recursion depth too high, most likely nodes are circular.");
      if (root == null)
        return 1;
      if (root.IsRed && (root.Left != null && root.Left.IsRed || root.Right != null && root.Right.IsRed))
        throw new Exception("Red violation.");
      int num1 = this.method_3(root.Left, testOrder, recursionDepth + 1);
      int num2 = this.method_3(root.Right, testOrder, recursionDepth + 1);
      if (testOrder && (root.Left != null && this.icomparer_0.Compare(root.Left.Value, root.Value) >= 0 || root.Right != null && this.icomparer_0.Compare(root.Right.Value, root.Value) <= 0))
        throw new Exception("Invalid node order.");
      if (num1 != num2)
        throw new Exception("Black violation.");
      return root.IsRed ? num1 : num1 + 1;
    }

    public class Node
    {
      private bool bool_0;
      private T gparam_0;
      private RedBlackTree<T>.Node node_0;
      private RedBlackTree<T>.Node node_1;
      private RedBlackTree<T>.Node node_2;

      public Node(T value)
      {
        this.gparam_0 = value;
        this.bool_0 = true;
      }

      internal bool IsRed
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

      public T Value
      {
        get
        {
          return this.gparam_0;
        }
        internal set
        {
          this.gparam_0 = value;
        }
      }

      public RedBlackTree<T>.Node Parent
      {
        get
        {
          return this.node_0;
        }
        internal set
        {
          this.node_0 = value;
        }
      }

      public RedBlackTree<T>.Node Left
      {
        get
        {
          return this.node_1;
        }
        internal set
        {
          this.node_1 = value;
          if (this.node_1 == null)
            return;
          this.node_1.node_0 = this;
        }
      }

      public RedBlackTree<T>.Node Right
      {
        get
        {
          return this.node_2;
        }
        internal set
        {
          this.node_2 = value;
          if (this.node_2 == null)
            return;
          this.node_2.node_0 = this;
        }
      }

      public RedBlackTree<T>.Node GetLeftMost()
      {
        RedBlackTree<T>.Node node = this;
        while (node.node_1 != null)
          node = node.node_1;
        return node;
      }

      public RedBlackTree<T>.Node GetRightMost()
      {
        RedBlackTree<T>.Node node = this;
        while (node.node_2 != null)
          node = node.node_2;
        return node;
      }

      public RedBlackTree<T>.Node GetPrevious()
      {
        RedBlackTree<T>.Node node = this;
        if (node.node_1 == null)
        {
          bool flag = false;
          RedBlackTree<T>.Node node0;
          for (; node.node_0 != null; node = node0)
          {
            node0 = node.node_0;
            if (node0.node_2 == node)
            {
              flag = true;
              node = node0;
              break;
            }
          }
          if (!flag)
            node = (RedBlackTree<T>.Node) null;
        }
        else
        {
          node = node.node_1;
          while (node.node_2 != null)
            node = node.node_2;
        }
        return node;
      }

      public RedBlackTree<T>.Node GetNext()
      {
        RedBlackTree<T>.Node node = this;
        if (node.node_2 == null)
        {
          bool flag = false;
          RedBlackTree<T>.Node node0;
          for (; node.node_0 != null; node = node0)
          {
            node0 = node.node_0;
            if (node0.node_1 == node)
            {
              flag = true;
              node = node0;
              break;
            }
          }
          if (!flag)
            node = (RedBlackTree<T>.Node) null;
        }
        else
        {
          node = node.node_2;
          while (node.node_1 != null)
            node = node.node_1;
        }
        return node;
      }

      public override string ToString()
      {
        return string.Format("{0} ({1})", (object) this.gparam_0, this.bool_0 ? (object) "R" : (object) "B");
      }

      internal RedBlackTree<T>.Node Sibling
      {
        get
        {
          if (this.node_0 == null)
            return (RedBlackTree<T>.Node) null;
          if (this.node_0.node_1 == this)
            return this.node_0.node_2;
          return this.node_0.node_1;
        }
      }

      internal void method_0(int comparison, RedBlackTree<T>.Node child)
      {
        child.node_0 = this;
        if (comparison < 0)
          this.node_1 = child;
        else
          this.node_2 = child;
      }

      internal void method_1(bool isLeft, RedBlackTree<T>.Node child)
      {
        if (child != null)
          child.node_0 = this;
        if (isLeft)
          this.node_1 = child;
        else
          this.node_2 = child;
      }

      internal RedBlackTree<T>.Node method_2(bool isLeft)
      {
        if (!isLeft)
          return this.node_2;
        return this.node_1;
      }

      internal void method_3()
      {
        if (this.node_1 != null && this.node_1.node_0 != this)
          throw new Exception("Left parent not equal to this.");
        if (this.node_2 != null && this.node_2.node_0 != this)
          throw new Exception("Right parent not equal to this.");
      }

      internal RedBlackTree<T>.Node method_4(T value, IComparer<T> comparer)
      {
        bool isLeft1 = false;
        bool flag = false;
        RedBlackTree<T>.Node node1 = this;
        RedBlackTree<T>.Node root = (RedBlackTree<T>.Node) null;
        RedBlackTree<T>.Node node2 = (RedBlackTree<T>.Node) null;
        RedBlackTree<T>.Node node3;
        for (RedBlackTree<T>.Node node4 = this.node_2; node4 != null; node4 = isLeft1 ? node4.node_1 : node4.node_2)
        {
          if (node4.node_1 != null && node4.node_1.bool_0 && (node4.node_2 != null && node4.node_2.bool_0))
          {
            node4.bool_0 = true;
            node4.node_1.bool_0 = false;
            node4.node_2.bool_0 = false;
            if (RedBlackTree<T>.Node.smethod_0(node2))
            {
              bool isLeft2 = node1.node_1 == root;
              if (isLeft1 == flag)
                node1.method_1(isLeft2, flag ? RedBlackTree<T>.Node.smethod_1(root) : RedBlackTree<T>.Node.smethod_3(root));
              else
                node1.method_1(isLeft2, flag ? RedBlackTree<T>.Node.smethod_2(root) : RedBlackTree<T>.Node.smethod_4(root));
            }
          }
          else if (node4.bool_0 && RedBlackTree<T>.Node.smethod_0(node2))
          {
            bool isLeft2 = node1.node_1 == root;
            if (isLeft1 == flag)
              node1.method_1(isLeft2, flag ? RedBlackTree<T>.Node.smethod_1(root) : RedBlackTree<T>.Node.smethod_3(root));
            else
              node1.method_1(isLeft2, flag ? RedBlackTree<T>.Node.smethod_2(root) : RedBlackTree<T>.Node.smethod_4(root));
          }
          int num = comparer.Compare(value, node4.gparam_0);
          if (num != 0)
          {
            flag = isLeft1;
            isLeft1 = num < 0;
            if (root != null)
              node1 = root;
            root = node2;
            node2 = node4;
          }
          else
          {
            node3 = (RedBlackTree<T>.Node) null;
            goto label_20;
          }
        }
        RedBlackTree<T>.Node child;
        node3 = child = new RedBlackTree<T>.Node(value);
        node2.method_1(isLeft1, child);
        if (node2.bool_0)
        {
          bool isLeft2 = node1.node_1 == root;
          if (isLeft1 == flag)
            node1.method_1(isLeft2, flag ? RedBlackTree<T>.Node.smethod_1(root) : RedBlackTree<T>.Node.smethod_3(root));
          else
            node1.method_1(isLeft2, flag ? RedBlackTree<T>.Node.smethod_2(root) : RedBlackTree<T>.Node.smethod_4(root));
        }
label_20:
        return node3;
      }

      private static bool smethod_0(RedBlackTree<T>.Node node)
      {
        if (node != null)
          return node.bool_0;
        return false;
      }

      private static RedBlackTree<T>.Node smethod_1(RedBlackTree<T>.Node root)
      {
        RedBlackTree<T>.Node node1 = root.node_1;
        root.Left = node1.node_2;
        node1.Right = root;
        root.bool_0 = true;
        node1.bool_0 = false;
        return node1;
      }

      private static RedBlackTree<T>.Node smethod_2(RedBlackTree<T>.Node root)
      {
        root.Left = RedBlackTree<T>.Node.smethod_3(root.node_1);
        return RedBlackTree<T>.Node.smethod_1(root);
      }

      private static RedBlackTree<T>.Node smethod_3(RedBlackTree<T>.Node root)
      {
        RedBlackTree<T>.Node node2 = root.node_2;
        root.Right = node2.node_1;
        node2.Left = root;
        root.bool_0 = true;
        node2.bool_0 = false;
        return node2;
      }

      private static RedBlackTree<T>.Node smethod_4(RedBlackTree<T>.Node root)
      {
        root.Right = RedBlackTree<T>.Node.smethod_1(root.node_2);
        return RedBlackTree<T>.Node.smethod_3(root);
      }

      internal int method_5(T value, IComparer<T> comparer)
      {
        int num1 = 0;
        RedBlackTree<T>.Node node1 = (RedBlackTree<T>.Node) null;
        RedBlackTree<T>.Node root1 = (RedBlackTree<T>.Node) null;
        RedBlackTree<T>.Node root2 = this;
        bool isLeft1 = false;
        RedBlackTree<T>.Node node2 = root2.method_2(false);
        while (node2 != null)
        {
          bool isLeft2 = isLeft1;
          RedBlackTree<T>.Node node3 = root1;
          root1 = root2;
          root2 = node2;
          int num2 = comparer.Compare(value, root2.gparam_0);
          isLeft1 = num2 < 0;
          if (num2 == 0)
            node1 = root2;
          node2 = root2.method_2(isLeft1);
          if (!root2.IsRed && !RedBlackTree<T>.Node.smethod_0(node2))
          {
            if (RedBlackTree<T>.Node.smethod_0(root2.method_2(!isLeft1)))
            {
              RedBlackTree<T>.Node child = isLeft1 ? RedBlackTree<T>.Node.smethod_3(root2) : RedBlackTree<T>.Node.smethod_1(root2);
              root1.method_1(isLeft2, child);
              root1 = child;
            }
            else
            {
              RedBlackTree<T>.Node node4 = root1.method_2(!isLeft2);
              if (node4 != null)
              {
                if (!RedBlackTree<T>.Node.smethod_0(node4.node_1) && !RedBlackTree<T>.Node.smethod_0(node4.node_2))
                {
                  root1.bool_0 = false;
                  node4.bool_0 = true;
                  root2.bool_0 = true;
                }
                else
                {
                  bool isLeft3 = root1 != node3.node_2;
                  RedBlackTree<T>.Node child;
                  if (RedBlackTree<T>.Node.smethod_0(node4.method_2(isLeft2)))
                  {
                    child = isLeft2 ? RedBlackTree<T>.Node.smethod_4(root1) : RedBlackTree<T>.Node.smethod_2(root1);
                    node3.method_1(isLeft3, child);
                  }
                  else if (RedBlackTree<T>.Node.smethod_0(node4.method_2(!isLeft2)))
                  {
                    child = isLeft2 ? RedBlackTree<T>.Node.smethod_3(root1) : RedBlackTree<T>.Node.smethod_1(root1);
                    node3.method_1(isLeft3, child);
                  }
                  else
                    child = node3.method_2(isLeft3);
                  RedBlackTree<T>.Node node5 = root2;
                  child.bool_0 = true;
                  node5.bool_0 = true;
                  child.node_1.bool_0 = false;
                  child.node_2.bool_0 = false;
                }
              }
            }
          }
        }
        if (node1 != null)
        {
          node1.gparam_0 = root2.gparam_0;
          root1.method_1(root1.Right != root2, root2.method_2(root2.Left == null));
          num1 = 1;
        }
        return num1;
      }

      internal void method_6(ref RedBlackTree<T>.Node root)
      {
        if (this.node_1 != null && this.node_2 != null)
        {
          RedBlackTree<T>.Node rightMost = this.node_1.GetRightMost();
          RedBlackTree<T>.Node.smethod_7(ref root, this, rightMost);
        }
        if (this.node_1 == null && this.node_2 == null)
        {
          RedBlackTree<T>.Node sibling = this.Sibling;
          RedBlackTree<T>.Node.smethod_8(ref root, this, (RedBlackTree<T>.Node) null);
          if (!this.bool_0)
          {
            bool parentsNeedRebalancing = true;
            RedBlackTree<T>.Node root1 = this.node_0;
            if (root1 != null)
            {
              while (parentsNeedRebalancing)
              {
                bool flag = root == root1;
                RedBlackTree<T>.Node parent = root1.Parent;
                bool isLeft = parent != null && parent.Left == root1;
                RedBlackTree<T>.Node child = sibling != sibling.Parent.Left ? RedBlackTree<T>.Node.smethod_6(root1, sibling, out parentsNeedRebalancing) : RedBlackTree<T>.Node.smethod_5(root1, sibling, out parentsNeedRebalancing);
                if (flag)
                {
                  root = child;
                  root.Parent = (RedBlackTree<T>.Node) null;
                }
                else
                  parent.method_1(isLeft, child);
                sibling = child.Sibling;
                root1 = child.Parent;
                if (root1 == null || sibling == null)
                  break;
              }
            }
          }
        }
        else
        {
          RedBlackTree<T>.Node replacement = this.node_1 != null ? this.node_1 : this.node_2;
          RedBlackTree<T>.Node.smethod_8(ref root, this, replacement);
          if (!this.bool_0)
          {
            if (!replacement.bool_0)
              throw new Exception();
            replacement.bool_0 = false;
          }
        }
        if (root == null)
          return;
        root.bool_0 = false;
      }

      private static RedBlackTree<T>.Node smethod_5(
        RedBlackTree<T>.Node root,
        RedBlackTree<T>.Node sibling,
        out bool parentsNeedRebalancing)
      {
        RedBlackTree<T>.Node root1 = root;
        parentsNeedRebalancing = true;
        if (root1 == null || sibling == null)
          return root1;
        if (sibling.bool_0)
        {
          root = RedBlackTree<T>.Node.smethod_1(root);
          sibling = root1.node_1;
        }
        if (sibling != null)
        {
          bool flag1;
          if (!(flag1 = RedBlackTree<T>.Node.smethod_0(sibling.node_1)) && !RedBlackTree<T>.Node.smethod_0(sibling.node_2))
          {
            sibling.bool_0 = true;
            if (root1.bool_0)
            {
              root1.bool_0 = false;
              parentsNeedRebalancing = false;
            }
          }
          else
          {
            bool bool0 = root1.bool_0;
            bool flag2 = root1 == root;
            RedBlackTree<T>.Node node;
            if (flag1)
              (node = RedBlackTree<T>.Node.smethod_1(root1)).bool_0 = bool0;
            else
              (node = RedBlackTree<T>.Node.smethod_2(root1)).bool_0 = bool0;
            if (flag2)
              root = node;
            else
              root.Right = node;
            node.node_1.bool_0 = false;
            node.node_2.bool_0 = false;
            parentsNeedRebalancing = false;
          }
        }
        return root;
      }

      private static RedBlackTree<T>.Node smethod_6(
        RedBlackTree<T>.Node root,
        RedBlackTree<T>.Node sibling,
        out bool parentsNeedRebalancing)
      {
        RedBlackTree<T>.Node root1 = root;
        parentsNeedRebalancing = true;
        if (root1 == null || sibling == null)
          return root1;
        if (sibling.bool_0)
        {
          root = RedBlackTree<T>.Node.smethod_3(root);
          sibling = root1.node_2;
        }
        if (sibling != null)
        {
          bool flag1;
          if (!(flag1 = RedBlackTree<T>.Node.smethod_0(sibling.node_2)) && !RedBlackTree<T>.Node.smethod_0(sibling.node_1))
          {
            sibling.bool_0 = true;
            if (root1.bool_0)
            {
              root1.bool_0 = false;
              parentsNeedRebalancing = false;
            }
          }
          else
          {
            bool bool0 = root1.bool_0;
            bool flag2 = root1 == root;
            RedBlackTree<T>.Node node;
            if (flag1)
              (node = RedBlackTree<T>.Node.smethod_3(root1)).bool_0 = bool0;
            else
              (node = RedBlackTree<T>.Node.smethod_4(root1)).bool_0 = bool0;
            if (flag2)
              root = node;
            else
              root.Left = node;
            node.node_2.bool_0 = false;
            node.node_1.bool_0 = false;
            parentsNeedRebalancing = false;
          }
        }
        return root;
      }

      private static void smethod_7(
        ref RedBlackTree<T>.Node root,
        RedBlackTree<T>.Node parent,
        RedBlackTree<T>.Node child)
      {
        RedBlackTree<T>.Node node1 = child.node_1;
        RedBlackTree<T>.Node node2 = child.node_2;
        RedBlackTree<T>.Node node0 = child.node_0;
        bool isLeft = child.node_0.node_1 == child;
        bool bool0 = child.bool_0;
        if (parent.node_0 == null)
        {
          root = child;
          root.node_0 = (RedBlackTree<T>.Node) null;
        }
        else if (parent.node_0.node_1 == parent)
          parent.node_0.Left = child;
        else
          parent.node_0.Right = child;
        if (parent.node_1 == child)
        {
          child.Left = parent;
          child.Right = parent.node_2;
        }
        else if (parent.node_2 == child)
        {
          child.Left = parent.node_1;
          child.Right = parent;
        }
        else
        {
          child.Left = parent.node_1;
          child.Right = parent.node_2;
          node0.method_1(isLeft, parent);
        }
        child.bool_0 = parent.bool_0;
        parent.Left = node1;
        parent.Right = node2;
        parent.bool_0 = bool0;
      }

      private static void smethod_8(
        ref RedBlackTree<T>.Node root,
        RedBlackTree<T>.Node node,
        RedBlackTree<T>.Node replacement)
      {
        if (node.node_0 == null)
        {
          root = replacement;
          if (root == null)
            return;
          root.node_0 = (RedBlackTree<T>.Node) null;
        }
        else if (node.node_0.node_1 == node)
          node.node_0.Left = replacement;
        else
          node.node_0.Right = replacement;
      }
    }

    public abstract class EnumeratorBase : IEnumerator, IEnumerator<T>, IDisposable
    {
      protected T current;
      protected RedBlackTree<T> tree;
      protected RedBlackTree<T>.Node currentNode;

      public EnumeratorBase(RedBlackTree<T> tree)
      {
        this.tree = tree;
        this.Reset();
      }

      public EnumeratorBase(RedBlackTree<T> tree, T target)
      {
        this.tree = tree;
        this.Reset();
        this.method_0(target);
      }

      public EnumeratorBase(RedBlackTree<T>.EnumeratorBase from)
      {
        this.current = from.current;
        this.tree = from.tree;
        this.currentNode = from.currentNode;
      }

      public RedBlackTree<T>.Node CurrentNode
      {
        get
        {
          return this.currentNode;
        }
        set
        {
          this.currentNode = value;
          this.current = value == null ? default (T) : value.Value;
        }
      }

      public bool Find(T target)
      {
        this.Reset();
        return this.method_0(target);
      }

      public bool Search(Func<T, int> compare)
      {
        this.Reset();
        RedBlackTree<T>.Node node1 = this.tree.node_0;
        bool flag = false;
        RedBlackTree<T>.Node node2 = node1;
        while (node1 != null)
        {
          node2 = node1;
          int num = compare(node1.Value);
          if (num < 0)
            node1 = node1.Left;
          else if (num > 0)
          {
            node1 = node1.Right;
            flag = true;
          }
          else if (num == 0)
          {
            flag = true;
            break;
          }
        }
        if (flag)
        {
          this.current = node2.Value;
          this.currentNode = node2;
        }
        else
        {
          this.currentNode = (RedBlackTree<T>.Node) null;
          this.current = default (T);
        }
        return flag;
      }

      public abstract bool MovePrevious();

      private bool method_0(T target)
      {
        RedBlackTree<T>.Node node = this.tree.node_0;
        bool flag = false;
        int num;
        for (; node != null; node = num < 0 ? node.Left : node.Right)
        {
          num = this.tree.icomparer_0.Compare(target, node.Value);
          if (num == 0)
          {
            flag = true;
            this.currentNode = node;
            this.current = node.Value;
            break;
          }
        }
        if (!flag)
        {
          this.currentNode = (RedBlackTree<T>.Node) null;
          this.current = default (T);
        }
        return flag;
      }

      public T Current
      {
        get
        {
          return this.current;
        }
      }

      public void Dispose()
      {
        this.tree = (RedBlackTree<T>) null;
        this.currentNode = (RedBlackTree<T>.Node) null;
      }

      object IEnumerator.Current
      {
        get
        {
          return (object) this.current;
        }
      }

      public abstract bool MoveNext();

      public void Reset()
      {
        this.currentNode = (RedBlackTree<T>.Node) null;
      }

      protected internal bool MoveNextHelper()
      {
        if (this.currentNode == null)
        {
          RedBlackTree<T>.Node node1 = this.tree.node_0;
          RedBlackTree<T>.Node node2 = node1;
          for (; node1 != null; node1 = node1.Left)
            node2 = node1;
          if (node2 == null)
          {
            this.current = default (T);
            this.currentNode = (RedBlackTree<T>.Node) null;
            return false;
          }
          this.current = node2.Value;
          this.currentNode = node2;
          return true;
        }
        RedBlackTree<T>.Node next = this.currentNode.GetNext();
        if (next == null)
        {
          this.currentNode = (RedBlackTree<T>.Node) null;
          this.current = default (T);
          return false;
        }
        this.currentNode = next;
        this.current = next.Value;
        return true;
      }

      protected internal bool MovePreviousHelper()
      {
        if (this.currentNode == null)
        {
          RedBlackTree<T>.Node node1 = this.tree.node_0;
          RedBlackTree<T>.Node node2 = node1;
          for (; node1 != null; node1 = node1.Right)
            node2 = node1;
          if (node2 == null)
          {
            this.current = default (T);
            this.currentNode = (RedBlackTree<T>.Node) null;
            return false;
          }
          this.current = node2.Value;
          this.currentNode = node2;
          return true;
        }
        RedBlackTree<T>.Node previous = this.currentNode.GetPrevious();
        if (previous == null)
        {
          this.currentNode = (RedBlackTree<T>.Node) null;
          this.current = default (T);
          return false;
        }
        this.currentNode = previous;
        this.current = previous.Value;
        return true;
      }
    }

    public class ForwardEnumerator : RedBlackTree<T>.EnumeratorBase
    {
      public ForwardEnumerator(RedBlackTree<T> tree)
        : base(tree)
      {
      }

      public ForwardEnumerator(RedBlackTree<T> tree, T target)
        : base(tree, target)
      {
      }

      public ForwardEnumerator(RedBlackTree<T>.EnumeratorBase from)
        : base(from)
      {
      }

      public bool Search(T value)
      {
        this.Reset();
        if (this.tree.node_0 == null)
        {
          this.current = default (T);
          return false;
        }
        RedBlackTree<T>.Node node1 = this.tree.node_0;
        RedBlackTree<T>.Node node2 = node1;
        bool flag1 = false;
        int num = 0;
        for (; node1 != null; node1 = num < 0 ? node1.Left : node1.Right)
        {
          num = this.tree.icomparer_0.Compare(value, node1.Value);
          if (num != 0)
          {
            node2 = node1;
          }
          else
          {
            flag1 = true;
            this.currentNode = node1;
            this.current = node1.Value;
            break;
          }
        }
        bool flag2 = flag1;
        if (!flag1)
        {
          this.currentNode = node2;
          if (num > 0)
          {
            flag2 = this.MoveNext();
          }
          else
          {
            this.current = node2.Value;
            flag2 = true;
          }
        }
        return flag2;
      }

      public override bool MovePrevious()
      {
        return this.MovePreviousHelper();
      }

      public override bool MoveNext()
      {
        return this.MoveNextHelper();
      }
    }

    public class ReverseEnumerator : RedBlackTree<T>.EnumeratorBase
    {
      public ReverseEnumerator(RedBlackTree<T> tree)
        : base(tree)
      {
      }

      public ReverseEnumerator(RedBlackTree<T> tree, T target)
        : base(tree, target)
      {
      }

      public ReverseEnumerator(RedBlackTree<T>.EnumeratorBase from)
        : base(from)
      {
      }

      public override bool MovePrevious()
      {
        return this.MoveNextHelper();
      }

      public override bool MoveNext()
      {
        return this.MovePreviousHelper();
      }
    }
  }
}
