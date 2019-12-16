// Decompiled with JetBrains decompiler
// Type: WW.Windows.Forms.FieldEditControl
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Drawing;
using System.Windows.Forms;

namespace WW.Windows.Forms
{
  public class FieldEditControl : FloatingForm
  {
    private TextBox textBox_0;

    public TextBox TextBox
    {
      get
      {
        return this.textBox_0;
      }
    }

    public static FieldEditControl Create(string fieldDescription)
    {
      FieldEditControl fieldEditControl = new FieldEditControl();
      Label autoSizeLabel = FormsUtil.CreateAutoSizeLabel();
      autoSizeLabel.Text = fieldDescription;
      autoSizeLabel.Location = new Point(3, 3);
      fieldEditControl.Controls.Add((Control) autoSizeLabel);
      fieldEditControl.textBox_0 = FormsUtil.CreateTextBoxThatAcceptsTab();
      fieldEditControl.textBox_0.Location = new Point(autoSizeLabel.Right, 3);
      fieldEditControl.Controls.Add((Control) fieldEditControl.textBox_0);
      fieldEditControl.Width = fieldEditControl.textBox_0.Right + 3;
      fieldEditControl.Height = fieldEditControl.textBox_0.Height + 6;
      return fieldEditControl;
    }
  }
}
