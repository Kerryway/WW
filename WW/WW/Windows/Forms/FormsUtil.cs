// Decompiled with JetBrains decompiler
// Type: WW.Windows.Forms.FormsUtil
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Windows.Forms;

namespace WW.Windows.Forms
{
  public static class FormsUtil
  {
    public static Label CreateAutoSizeLabel()
    {
      Label label = new Label();
      label.Width = 0;
      label.AutoSize = true;
      return label;
    }

    public static TextBox CreateTextBoxThatAcceptsTab()
    {
      TextBox textBox = new TextBox();
      textBox.AcceptsTab = true;
      textBox.Multiline = true;
      return textBox;
    }
  }
}
