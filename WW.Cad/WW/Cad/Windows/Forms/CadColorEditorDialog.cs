// Decompiled with JetBrains decompiler
// Type: WW.Cad.Windows.Forms.CadColorEditorDialog
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WW.Cad.Windows.Forms
{
  public class CadColorEditorDialog : Form
  {
    private IContainer icontainer_0;
    private CadColorEditor cadColorEditor;
    private Button okButton;
    private Button cancelButton;
    private CadColorEditor cadColorEditor1;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.icontainer_0 != null)
        this.icontainer_0.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (CadColorEditorDialog));
      this.okButton = new Button();
      this.cancelButton = new Button();
      this.cadColorEditor = new CadColorEditor();
      this.cadColorEditor1 = new CadColorEditor();
      this.SuspendLayout();
      this.okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.okButton.DialogResult = DialogResult.OK;
      this.okButton.Location = new Point(421, 420);
      this.okButton.Name = "okButton";
      this.okButton.Size = new Size(75, 23);
      this.okButton.TabIndex = 1;
      this.okButton.Text = "&OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.cancelButton.DialogResult = DialogResult.Cancel;
      this.cancelButton.Location = new Point(502, 420);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new Size(75, 23);
      this.cancelButton.TabIndex = 2;
      this.cancelButton.Text = "&Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cadColorEditor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.cadColorEditor.Location = new Point(12, 12);
      this.cadColorEditor.Name = "cadColorEditor";
      this.cadColorEditor.ShowColorBookTab = true;
      this.cadColorEditor.Size = new Size(565, 402);
      this.cadColorEditor.TabIndex = 0;
      this.cadColorEditor1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.cadColorEditor1.Location = new Point(12, 12);
      this.cadColorEditor1.Name = "cadColorEditor1";
      this.cadColorEditor1.ShowColorBookTab = true;
      this.cadColorEditor1.Size = new Size(565, 374);
      this.cadColorEditor1.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(589, 455);
      this.Controls.Add((Control) this.cancelButton);
      this.Controls.Add((Control) this.okButton);
      this.Controls.Add((Control) this.cadColorEditor);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (CadColorEditorDialog);
      this.Text = "Color editor";
      this.ResumeLayout(false);
    }

    public CadColorEditorDialog()
    {
      this.InitializeComponent();
    }

    public WW.Cad.Model.Color Color
    {
      get
      {
        return this.cadColorEditor.Color;
      }
      set
      {
        this.cadColorEditor.Color = value;
      }
    }

    public bool ShowColorBookTab
    {
      get
      {
        return this.cadColorEditor.ShowColorBookTab;
      }
      set
      {
        this.cadColorEditor.ShowColorBookTab = value;
      }
    }
  }
}
