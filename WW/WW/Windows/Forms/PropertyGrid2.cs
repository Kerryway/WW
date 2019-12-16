// Decompiled with JetBrains decompiler
// Type: WW.Windows.Forms.PropertyGrid2
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace WW.Windows.Forms
{
  public class PropertyGrid2 : PropertyGrid
  {
    private ResourceManager resourceManager_0;
    private bool bool_0;
    private int int_0;
    private bool bool_1;

    public PropertyGrid2()
    {
      this.Refresh();
    }

    [Description("Whether to expand an item when pressing tab.")]
    public bool ExpandOnTab
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    [Description("Initial value is zero. When zero the original property grid splitter position is unaffected.")]
    public int SplitterPosition
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
        if (!this.IsHandleCreated)
          return;
        this.method_1();
      }
    }

    public bool IsReadOnly
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public override void Refresh()
    {
      if (this.resourceManager_0 == null)
        this.resourceManager_0 = new ResourceManager(this.GetType());
      foreach (Control control in (ArrangedElementCollection) this.Controls)
      {
        if (control is ToolBar)
        {
          foreach (ToolBarButton button in (control as ToolBar).Buttons)
          {
            switch (button.ImageIndex)
            {
              case 0:
                button.ToolTipText = this.resourceManager_0.GetString("Alphabetic.ToolTip");
                continue;
              case 1:
                button.ToolTipText = this.resourceManager_0.GetString("Categorized.ToolTip");
                continue;
              case 3:
                button.ToolTipText = this.resourceManager_0.GetString("PropertyPages.ToolTip");
                continue;
              default:
                continue;
            }
          }
        }
      }
      base.Refresh();
    }

    public static PropertyGrid GetPropertyGrid(ITypeDescriptorContext context)
    {
      if (context == null)
        return (PropertyGrid) null;
      PropertyInfo property = context.GetType().GetProperty("OwnerGrid", BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
      PropertyGrid propertyGrid = (PropertyGrid) null;
      if (property != (PropertyInfo) null)
        propertyGrid = property.GetValue((object) context, (object[]) null) as PropertyGrid;
      return propertyGrid;
    }

    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);
      this.method_1();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Tab || keyData == (Keys.Tab | Keys.Shift))
      {
        GridItem selectedGridItem = this.SelectedGridItem;
        GridItem parent = selectedGridItem;
        while (parent.Parent != null)
          parent = parent.Parent;
        ArrayList arrayList = new ArrayList();
        this.method_0(parent, (IList) arrayList);
        if (selectedGridItem != null)
        {
          int num = arrayList.IndexOf((object) selectedGridItem);
          if ((keyData & Keys.Shift) == Keys.Shift)
          {
            int index = num - 1;
            if (index < 0)
              index = arrayList.Count - 1;
            this.SelectedGridItem = (GridItem) arrayList[index];
            if (this.bool_0 && this.SelectedGridItem.GridItems.Count > 0)
              this.SelectedGridItem.Expanded = false;
          }
          else
          {
            int index = num + 1;
            if (index >= arrayList.Count)
              index = 0;
            this.SelectedGridItem = (GridItem) arrayList[index];
            if (this.bool_0 && this.SelectedGridItem.GridItems.Count > 0)
              this.SelectedGridItem.Expanded = true;
          }
          return true;
        }
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void method_0(GridItem parent, IList items)
    {
      if (parent.PropertyDescriptor != null)
        items.Add((object) parent);
      if (!parent.Expanded)
        return;
      foreach (GridItem gridItem in parent.GridItems)
        this.method_0(gridItem, items);
    }

    private void method_1()
    {
      if (this.int_0 == 0)
        return;
      foreach (Control control in (ArrangedElementCollection) this.Controls)
      {
        if (control.GetType().Name == "PropertyGridView")
        {
          control.GetType().GetMethod("MoveSplitterTo", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic).Invoke((object) control, new object[1]
          {
            (object) this.int_0
          });
          break;
        }
      }
    }
  }
}
