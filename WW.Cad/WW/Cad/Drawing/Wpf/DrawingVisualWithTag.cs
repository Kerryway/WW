// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Wpf.DrawingVisualWithTag
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Windows.Media;

namespace WW.Cad.Drawing.Wpf
{
  public class DrawingVisualWithTag : DrawingVisual
  {
    private object object_0;

    public object Tag
    {
      get
      {
        return this.object_0;
      }
      set
      {
        this.object_0 = value;
      }
    }
  }
}
