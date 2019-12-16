// Decompiled with JetBrains decompiler
// Type: WW.Actions.IInteractorWinFormsDrawable
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Drawing;
using System.Windows.Forms;
using WW.Drawing;
using WW.Math;

namespace WW.Actions
{
  public interface IInteractorWinFormsDrawable
  {
    void DrawBackground(
      PaintEventArgs e,
      GraphicsHelper graphicsHelper,
      InteractionContext context);

    void Draw(PaintEventArgs e, GraphicsHelper graphicsHelper, InteractionContext context);

    Cursor GetCursor();

    bool TryCreateCaretBitmap(
      GraphicsHelper graphicsHelper,
      InteractionContext context,
      out Bitmap caretBitmap,
      out Point2D dcsPosition);
  }
}
