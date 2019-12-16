// Decompiled with JetBrains decompiler
// Type: WW.Windows.InputUtil
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Windows.Forms;
using System.Windows.Input;

namespace WW.Windows
{
  public static class InputUtil
  {
    public static bool IsShiftPressed()
    {
      return Keyboard.Modifiers == ModifierKeys.Shift;
    }

    public static void GetWindowsKey(Keys keyData, out Key key, out ModifierKeys modifierKeys)
    {
      modifierKeys = ModifierKeys.None;
      if ((keyData & Keys.Shift) != Keys.None)
      {
        modifierKeys |= ModifierKeys.Shift;
        keyData ^= Keys.Shift;
      }
      if ((keyData & Keys.Alt) != Keys.None)
      {
        modifierKeys |= ModifierKeys.Alt;
        keyData ^= Keys.Alt;
      }
      if ((keyData & Keys.Control) != Keys.None)
      {
        modifierKeys |= ModifierKeys.Control;
        keyData ^= Keys.Control;
      }
      key = KeyInterop.KeyFromVirtualKey((int) keyData);
    }
  }
}
