// Decompiled with JetBrains decompiler
// Type: ns2.Class375
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns3;
using System;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;

namespace ns2
{
  internal class Class375 : Class374
  {
    private Dictionary<string, List<DxfBlock>> dictionary_3 = new Dictionary<string, List<DxfBlock>>();
    private Dictionary<string, List<Class289>> dictionary_4 = new Dictionary<string, List<Class289>>();
    private List<Class289> list_8 = new List<Class289>();
    private string string_19;
    private object object_0;

    public Class375(DxfModel model, DxfMessageCollection messages)
      : base(model, messages)
    {
    }

    public override FileFormat FileFormat
    {
      get
      {
        return FileFormat.Dxf;
      }
    }

    public Dictionary<string, List<DxfBlock>> NameToBlocks
    {
      get
      {
        return this.dictionary_3;
      }
    }

    public Dictionary<string, List<Class289>> NameToBlockBeginBuilders
    {
      get
      {
        return this.dictionary_4;
      }
    }

    public string PreviousHeaderVariableName
    {
      get
      {
        return this.string_19;
      }
    }

    public object PreviousHeaderVariableValue
    {
      get
      {
        return this.object_0;
      }
    }

    public void method_25(string name, object value)
    {
      this.string_19 = name;
      this.object_0 = value;
    }

    public void method_26(DxfBlock block)
    {
      List<DxfBlock> dxfBlockList;
      if (!this.dictionary_3.TryGetValue(block.Name, out dxfBlockList))
      {
        dxfBlockList = new List<DxfBlock>(1);
        this.dictionary_3.Add(block.Name, dxfBlockList);
      }
      dxfBlockList.Add(block);
    }

    public void method_27(Class289 blockBeginBuilder)
    {
      if (blockBeginBuilder.Name == null)
        throw new ArgumentException("Name must have a value.");
      List<Class289> class289List;
      if (!this.dictionary_4.TryGetValue(blockBeginBuilder.Name, out class289List))
      {
        class289List = new List<Class289>(1);
        this.dictionary_4.Add(blockBeginBuilder.Name, class289List);
      }
      class289List.Add(blockBeginBuilder);
      this.list_8.Add(blockBeginBuilder);
    }

    protected override void vmethod_0()
    {
      DxfBlock dxfBlock = DxfBlock.smethod_2(this.Model, !this.Model.Header.Handling, false);
      if (dxfBlock == null)
        return;
      dxfBlock.method_10(this.Model.Entities);
      if (dxfBlock.Layout == null)
        return;
      dxfBlock.Layout.method_9(this.Model.Entities, false);
    }

    protected override void vmethod_1()
    {
      base.vmethod_1();
      List<Class289> class289List1 = new List<Class289>();
      foreach (string key in this.dictionary_4.Keys)
      {
        List<Class289> class289List2 = this.dictionary_4[key];
        List<DxfBlock> dxfBlockList;
        if (this.dictionary_3.TryGetValue(key, out dxfBlockList))
        {
          if (dxfBlockList.Count > 1)
          {
            for (int index = 0; index < dxfBlockList.Count; ++index)
            {
              DxfBlock dxfBlock = dxfBlockList[index];
              if (dxfBlock.BlockBegin == null)
                dxfBlock.BlockBegin = index >= class289List2.Count ? (DxfBlockBegin) class289List2[class289List2.Count - 1].HandledObject : (DxfBlockBegin) class289List2[index].HandledObject;
              if (dxfBlock.BlockEnd == null)
                dxfBlock.BlockEnd = index >= class289List2.Count ? class289List2[class289List2.Count - 1].BlockEnd : class289List2[index].BlockEnd;
            }
            class289List1.AddRange((IEnumerable<Class289>) class289List2);
          }
          else if (dxfBlockList.Count == 1)
          {
            DxfBlock dxfBlock = dxfBlockList[0];
            if (dxfBlock.BlockBegin == null)
              dxfBlock.BlockBegin = (DxfBlockBegin) class289List2[class289List2.Count - 1].HandledObject;
            if (dxfBlock.BlockEnd == null)
              dxfBlock.BlockEnd = class289List2[class289List2.Count - 1].BlockEnd;
            class289List1.Add(class289List2[class289List2.Count - 1]);
          }
        }
        else
          class289List1.AddRange((IEnumerable<Class289>) class289List2);
      }
      foreach (Class259 class259 in class289List1)
        class259.ResolveReferences((Class374) this);
    }

    protected override void vmethod_2()
    {
      this.ViewportBuilders.Sort((Comparison<Class308>) ((a, b) =>
      {
        int num1 = 0;
        int num2 = 0;
        if (a.Id.HasValue)
          num1 = a.Id.Value;
        if (b.Id.HasValue)
          num2 = b.Id.Value;
        return num1 >= num2 ? (num1 <= num2 ? 0 : 1) : -1;
      }));
      DxfLayout dxfLayout1 = (DxfLayout) null;
      foreach (DxfLayout layout in (KeyedDxfHandledObjectCollection<string, DxfLayout>) this.Model.Layouts)
      {
        if (layout.PaperSpace)
        {
          dxfLayout1 = layout;
          break;
        }
      }
      foreach (Class285 viewportBuilder in this.ViewportBuilders)
      {
        DxfViewport entity = (DxfViewport) viewportBuilder.Entity;
        if (entity.OwnerObjectSoftReference == null)
        {
          DxfLayout dxfLayout2 = (DxfLayout) null;
          if (entity.PersistentReactorCount > 0)
          {
            foreach (DxfHandledObject persistentReactor in entity.PersistentReactors)
            {
              DxfBlock dxfBlock = persistentReactor as DxfBlock;
              if (dxfBlock != null && dxfBlock.Layout != null)
              {
                entity.vmethod_2((IDxfHandledObject) dxfBlock);
                dxfLayout2 = dxfBlock.Layout;
                break;
              }
            }
          }
          if (dxfLayout2 == null)
          {
            if (entity.PaperSpace && dxfLayout1 != null)
              dxfLayout1.Viewports.Add(entity);
            else
              this.Model.ModelLayout.Viewports.Add(entity);
          }
          else
            dxfLayout2.Viewports.Add(entity);
        }
        else
        {
          DxfLayout layout = ((DxfBlock) entity.OwnerObjectSoftReference).Layout;
          if (layout == null)
            this.Model.ModelLayout.Viewports.Add(entity);
          else
            layout.Viewports.Add(entity);
        }
      }
    }
  }
}
