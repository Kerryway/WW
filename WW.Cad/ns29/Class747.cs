// Decompiled with JetBrains decompiler
// Type: ns29.Class747
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ns29
{
  internal class Class747 : Interface37
  {
    private readonly FrameworkElement frameworkElement_0;

    public Class747(FrameworkElement frameworkElement)
    {
      this.frameworkElement_0 = frameworkElement;
    }

    public void Draw(ICollection<FrameworkElement> targetElements)
    {
      targetElements.Add(this.frameworkElement_0);
    }

    public void Draw(UIElementCollection targetElements)
    {
      targetElements.Add((UIElement) this.frameworkElement_0);
    }
  }
}
