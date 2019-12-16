// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.GDI.IGdiDrawable
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Windows.Forms;
using WW.Actions;
using WW.Drawing;

namespace WW.Cad.Drawing.GDI
{
  public interface IGdiDrawable
  {
    void Draw(PaintEventArgs e, GraphicsHelper graphicsHelper, InteractionContext context);
  }
}
