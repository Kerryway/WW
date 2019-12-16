// Decompiled with JetBrains decompiler
// Type: WW.OpenGL.Actions.IInteractorGLDrawable
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using WW.Actions;
using WW.Drawing;

namespace WW.OpenGL.Actions
{
  public interface IInteractorGLDrawable
  {
    void Draw(GraphicsHelper graphicsHelper, InteractionContext context);
  }
}
