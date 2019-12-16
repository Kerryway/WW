// Decompiled with JetBrains decompiler
// Type: ns29.Class892
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;

namespace ns29
{
  internal class Class892 : IEnumerable, IEnumerable<FrameworkElement>
  {
    private LinkedList<FrameworkElement> linkedList_0;

    internal Class892(LinkedList<FrameworkElement> frameworkElements)
    {
      this.linkedList_0 = frameworkElements;
    }

    public IEnumerator<FrameworkElement> GetEnumerator()
    {
      return (IEnumerator<FrameworkElement>) new Class892.Class893((IEnumerator<FrameworkElement>) this.linkedList_0.GetEnumerator());
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) new Class892.Class893((IEnumerator<FrameworkElement>) this.linkedList_0.GetEnumerator());
    }

    private class Class893 : IDisposable, IEnumerator, IEnumerator<FrameworkElement>
    {
      private IEnumerator<FrameworkElement> ienumerator_0;

      public Class893(IEnumerator<FrameworkElement> wrappedIterator)
      {
        this.ienumerator_0 = wrappedIterator;
      }

      public FrameworkElement Current
      {
        get
        {
          return this.ienumerator_0.Current;
        }
      }

      public void Dispose()
      {
        this.ienumerator_0.Dispose();
      }

      object IEnumerator.Current
      {
        get
        {
          return (object) this.ienumerator_0.Current;
        }
      }

      public bool MoveNext()
      {
        bool flag = this.ienumerator_0.MoveNext();
        while (flag && this.ienumerator_0.Current == null)
          flag = this.ienumerator_0.MoveNext();
        return flag;
      }

      public void Reset()
      {
        this.ienumerator_0.Reset();
      }
    }
  }
}
