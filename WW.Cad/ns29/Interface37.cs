// Decompiled with JetBrains decompiler
// Type: ns29.Interface37
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ns29
{
  internal interface Interface37
  {
    void Draw(ICollection<FrameworkElement> targetElements);

    void Draw(UIElementCollection targetElements);
  }
}
