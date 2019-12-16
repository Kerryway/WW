// Decompiled with JetBrains decompiler
// Type: ns0.Class906
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.Linq;
using WW.Cad.Base;
using WW.Cad.Model;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;

namespace ns0
{
  internal static class Class906
  {
    internal static DxfBlock smethod_0(
      CloneContext cloneContext,
      DxfBlock from,
      bool ownsBlock)
    {
      if (from == null)
        return (DxfBlock) null;
      if (!ownsBlock && cloneContext.SourceModel == cloneContext.TargetModel)
        return from;
      DxfBlock dxfBlock = (DxfBlock) cloneContext.GetExistingClone((IGraphCloneable) from);
      string str = from.Name;
      if (dxfBlock == null && !from.IsReallyAnonymous)
      {
        cloneContext.TargetModel.Blocks.TryGetValue(str, out dxfBlock);
        if (dxfBlock != null && cloneContext.RenameClashingBlocks && cloneContext.SourceModel != cloneContext.TargetModel)
        {
          str = Class906.smethod_1<DxfBlock>((KeyedDxfHandledObjectCollection<string, DxfBlock>) cloneContext.TargetModel.Blocks, str, cloneContext.TargetModel.Header.Dxf13OrHigher);
          dxfBlock = (DxfBlock) null;
        }
      }
      if (dxfBlock == null)
      {
        switch (cloneContext.ReferenceResolutionType)
        {
          case ReferenceResolutionType.CloneMissing:
            DxfBlock block = (DxfBlock) from.Clone(cloneContext);
            block.Name = str;
            if (!cloneContext.CloneExact)
              cloneContext.TargetModel.method_38(block, (IList<DxfMessage>) null, false);
            dxfBlock = block;
            break;
          case ReferenceResolutionType.FailOnMissing:
            throw new DxfException(string.Format("Could not resolve reference to block with name {0}", (object) str));
        }
      }
      return dxfBlock;
    }

    internal static string smethod_1<T>(
      KeyedDxfHandledObjectCollection<string, T> collection,
      string name,
      bool allowLongNames)
      where T : DxfHandledObject
    {
      SortedSet<string> sortedSet = new SortedSet<string>((IComparer<string>) new CaseInsensitiveStringComparer());
      foreach (string key in (IEnumerable<string>) collection.Keys)
        sortedSet.Add(key);
      int num1 = allowLongNames ? (int) byte.MaxValue : 31;
      int toBase;
      uint num2;
      string str1;
      if (char.IsDigit(name[name.Length - 1]))
      {
        toBase = 10;
        int index = name.Length - 2;
        while (index >= 0 && char.IsDigit(name[index]))
          --index;
        int num3 = index + 1;
        try
        {
          num2 = Convert.ToUInt32(name.Substring(num3));
          str1 = name.Substring(0, num3);
        }
        catch (OverflowException ex)
        {
          num2 = 1U;
          str1 = name + "_";
        }
      }
      else
      {
        toBase = 16;
        str1 = name;
        num2 = 1U;
      }
      do
      {
        string str2 = Convert.ToString((long) num2, toBase);
        name = str1 + str2;
        if (name.Length > num1)
          goto label_16;
label_15:
        ++num2;
        continue;
label_16:
        str1 = str1.Substring(0, num1 - str2.Length);
        name = str1 + str2;
        goto label_15;
      }
      while (sortedSet.Contains(name));
      return name;
    }

    internal static DxfLayer GetLayer(CloneContext cloneContext, DxfLayer from)
    {
      if (from == null)
        return (DxfLayer) null;
      if (from.Name == null)
        throw new Exception("Table record name is null.");
      if (cloneContext.SourceModel == cloneContext.TargetModel)
        return from;
      DxfLayer dxfLayer1 = (DxfLayer) cloneContext.GetExistingClone((IGraphCloneable) from) ?? cloneContext.TargetModel.GetLayerWithName(from.Name);
      if (dxfLayer1 == null)
      {
        switch (cloneContext.ReferenceResolutionType)
        {
          case ReferenceResolutionType.IgnoreMissing:
            dxfLayer1 = cloneContext.TargetModel.ZeroLayer;
            break;
          case ReferenceResolutionType.CloneMissing:
            DxfLayer dxfLayer2 = (DxfLayer) from.Clone(cloneContext);
            if (!cloneContext.CloneExact)
              cloneContext.TargetModel.Layers.Add(dxfLayer2);
            dxfLayer1 = dxfLayer2;
            break;
          case ReferenceResolutionType.FailOnMissing:
            throw new DxfException(string.Format("Could not resolve reference to layer with name {0}", (object) from.Name));
        }
      }
      return dxfLayer1;
    }

    internal static DxfTextStyle GetTextStyle(
      CloneContext cloneContext,
      DxfTextStyle from)
    {
      if (from == null)
        return (DxfTextStyle) null;
      if (from.Name == null)
        throw new Exception("Table record name is null.");
      if (cloneContext.SourceModel == cloneContext.TargetModel)
        return from;
      DxfTextStyle textStyle = (DxfTextStyle) cloneContext.GetExistingClone((IGraphCloneable) from);
      if (textStyle == null)
        cloneContext.TargetModel.TextStyles.TryGetValue(from.Name, out textStyle);
      if (textStyle == null)
      {
        switch (cloneContext.ReferenceResolutionType)
        {
          case ReferenceResolutionType.IgnoreMissing:
            textStyle = cloneContext.TargetModel.DefaultTextStyle;
            break;
          case ReferenceResolutionType.CloneMissing:
            DxfTextStyle dxfTextStyle = (DxfTextStyle) from.Clone(cloneContext);
            if (!cloneContext.CloneExact)
              cloneContext.TargetModel.TextStyles.Add(dxfTextStyle);
            textStyle = dxfTextStyle;
            break;
          case ReferenceResolutionType.FailOnMissing:
            throw new DxfException(string.Format("Could not resolve reference to text style with name {0}.", (object) from.Name));
        }
      }
      return textStyle;
    }

    internal static DxfLineType GetLineType(CloneContext cloneContext, DxfLineType from)
    {
      if (from == null)
        return (DxfLineType) null;
      if (from.Name == null)
        throw new Exception("Table record name is null.");
      if (cloneContext.SourceModel == cloneContext.TargetModel)
        return from;
      DxfLineType dxfLineType1 = (DxfLineType) cloneContext.GetExistingClone((IGraphCloneable) from) ?? cloneContext.TargetModel.GetLineTypeWithName(from.Name);
      if (dxfLineType1 == null)
      {
        switch (cloneContext.ReferenceResolutionType)
        {
          case ReferenceResolutionType.IgnoreMissing:
            dxfLineType1 = cloneContext.TargetModel.ContinuousLineType;
            break;
          case ReferenceResolutionType.CloneMissing:
            DxfLineType dxfLineType2 = (DxfLineType) from.Clone(cloneContext);
            if (!cloneContext.CloneExact)
              cloneContext.TargetModel.LineTypes.Add(dxfLineType2);
            dxfLineType1 = dxfLineType2;
            break;
          case ReferenceResolutionType.FailOnMissing:
            throw new DxfException(string.Format("Could not resolve reference to line type with name {0}", (object) from.Name));
        }
      }
      return dxfLineType1;
    }

    internal static DxfUcs smethod_2(CloneContext cloneContext, DxfUcs from)
    {
      if (from == null)
        return (DxfUcs) null;
      if (cloneContext.SourceModel == cloneContext.TargetModel)
        return from;
      DxfUcs dxfUcs1;
      if (from.Name != null)
      {
        dxfUcs1 = (DxfUcs) cloneContext.GetExistingClone((IGraphCloneable) from) ?? cloneContext.TargetModel.GetUcsWithName(from.Name);
        if (dxfUcs1 == null)
        {
          switch (cloneContext.ReferenceResolutionType)
          {
            case ReferenceResolutionType.CloneMissing:
              DxfUcs dxfUcs2 = (DxfUcs) from.Clone(cloneContext);
              if (!cloneContext.CloneExact)
                cloneContext.TargetModel.UcsCollection.Add(dxfUcs2);
              dxfUcs1 = dxfUcs2;
              break;
            case ReferenceResolutionType.FailOnMissing:
              throw new DxfException(string.Format("Could not resolve reference to ucs with name {0}", (object) from.Name));
          }
        }
      }
      else
        dxfUcs1 = (DxfUcs) from.Clone(cloneContext);
      return dxfUcs1;
    }

    internal static DxfAppId smethod_3(CloneContext cloneContext, DxfAppId from)
    {
      if (from == null)
        return (DxfAppId) null;
      if (from.Name == null)
        throw new Exception("Table record name is null.");
      if (cloneContext.SourceModel == cloneContext.TargetModel)
        return from;
      DxfAppId dxfAppId1 = (DxfAppId) cloneContext.GetExistingClone((IGraphCloneable) from);
      if (dxfAppId1 == null)
        cloneContext.TargetModel.AppIds.TryGetValue(from.Name, out dxfAppId1);
      if (dxfAppId1 == null)
      {
        switch (cloneContext.ReferenceResolutionType)
        {
          case ReferenceResolutionType.CloneMissing:
            DxfAppId dxfAppId2 = (DxfAppId) from.Clone(cloneContext);
            if (!cloneContext.CloneExact)
              cloneContext.TargetModel.AppIds.Add(dxfAppId2);
            dxfAppId1 = dxfAppId2;
            break;
          case ReferenceResolutionType.FailOnMissing:
            throw new DxfException(string.Format("Could not resolve reference to APPID with name {0}", (object) from.Name));
        }
      }
      return dxfAppId1;
    }

    internal static DxfTableStyle smethod_4(
      CloneContext cloneContext,
      DxfTableStyle from)
    {
      if (from == null)
        return (DxfTableStyle) null;
      if (from.Name == null)
        throw new Exception("Table record name is null.");
      if (cloneContext.SourceModel == cloneContext.TargetModel)
        return from;
      DxfTableStyle dxfTableStyle1 = (DxfTableStyle) cloneContext.GetExistingClone((IGraphCloneable) from);
      if (dxfTableStyle1 == null)
        cloneContext.TargetModel.TableStyles.TryGetValue(from.Name, out dxfTableStyle1);
      if (dxfTableStyle1 == null)
      {
        switch (cloneContext.ReferenceResolutionType)
        {
          case ReferenceResolutionType.CloneMissing:
            DxfTableStyle dxfTableStyle2 = (DxfTableStyle) from.Clone(cloneContext);
            if (!cloneContext.CloneExact)
              cloneContext.TargetModel.TableStyles.Add(dxfTableStyle2);
            dxfTableStyle1 = dxfTableStyle2;
            break;
          case ReferenceResolutionType.FailOnMissing:
            throw new DxfException(string.Format("Could not resolve reference to TABLESTYLE with name {0}", (object) from.Name));
        }
      }
      return dxfTableStyle1;
    }

    internal static DxfDimensionStyle smethod_5(
      CloneContext cloneContext,
      DxfDimensionStyle from)
    {
      if (from == null)
        return (DxfDimensionStyle) null;
      if (from.Name == null)
        throw new Exception("Table record name is null.");
      if (cloneContext.SourceModel == cloneContext.TargetModel)
        return from;
      DxfDimensionStyle dxfDimensionStyle1 = (DxfDimensionStyle) cloneContext.GetExistingClone((IGraphCloneable) from);
      if (dxfDimensionStyle1 == null)
        cloneContext.TargetModel.DimensionStyles.TryGetValue(from.Name, out dxfDimensionStyle1);
      if (dxfDimensionStyle1 == null)
      {
        switch (cloneContext.ReferenceResolutionType)
        {
          case ReferenceResolutionType.CloneMissing:
            DxfDimensionStyle dxfDimensionStyle2 = (DxfDimensionStyle) from.Clone(cloneContext);
            if (!cloneContext.CloneExact)
              cloneContext.TargetModel.DimensionStyles.Add(dxfDimensionStyle2);
            dxfDimensionStyle1 = dxfDimensionStyle2;
            break;
          case ReferenceResolutionType.FailOnMissing:
            throw new DxfException(string.Format("Could not resolve reference to dimension style with name {0}.", (object) from.Name));
        }
      }
      return dxfDimensionStyle1;
    }

    internal static DxfView smethod_6(CloneContext cloneContext, DxfView from)
    {
      if (from == null)
        return (DxfView) null;
      if (from.Name == null)
        throw new Exception("Table record name is null.");
      if (cloneContext.SourceModel == cloneContext.TargetModel)
        return from;
      DxfView dxfView1 = (DxfView) cloneContext.GetExistingClone((IGraphCloneable) from);
      if (dxfView1 == null)
        cloneContext.TargetModel.Views.TryGetValue(from.Name, out dxfView1);
      if (dxfView1 == null)
      {
        switch (cloneContext.ReferenceResolutionType)
        {
          case ReferenceResolutionType.CloneMissing:
            DxfView dxfView2 = (DxfView) from.Clone(cloneContext);
            if (!cloneContext.CloneExact)
              cloneContext.TargetModel.Views.Add(dxfView2);
            dxfView1 = dxfView2;
            break;
          case ReferenceResolutionType.FailOnMissing:
            throw new DxfException(string.Format("Could not resolve reference to VIEW with name {0}", (object) from.Name));
        }
      }
      return dxfView1;
    }

    internal static DxfVPort smethod_7(CloneContext cloneContext, DxfVPort from)
    {
      if (from == null)
        return (DxfVPort) null;
      if (from.Name == null)
        throw new Exception("Table record name is null.");
      if (cloneContext.SourceModel == cloneContext.TargetModel)
        return from;
      DxfVPort dxfVport1 = (DxfVPort) cloneContext.GetExistingClone((IGraphCloneable) from);
      if (dxfVport1 == null)
        cloneContext.TargetModel.VPorts.TryGetValue(from.Name, out dxfVport1);
      if (dxfVport1 == null)
      {
        switch (cloneContext.ReferenceResolutionType)
        {
          case ReferenceResolutionType.CloneMissing:
            DxfVPort dxfVport2 = (DxfVPort) from.Clone(cloneContext);
            if (!cloneContext.CloneExact)
              cloneContext.TargetModel.VPorts.Add(dxfVport2);
            dxfVport1 = dxfVport2;
            break;
          case ReferenceResolutionType.FailOnMissing:
            throw new DxfException(string.Format("Could not resolve reference to VPORT with name {0}", (object) from.Name));
        }
      }
      return dxfVport1;
    }

    internal static DxfViewportEntityHeader smethod_8(
      CloneContext cloneContext,
      DxfViewportEntityHeader from)
    {
      if (from == null)
        return (DxfViewportEntityHeader) null;
      if (from.Name == null)
        throw new Exception("Table record name is null.");
      DxfViewportEntityHeader viewportEntityHeader1 = (DxfViewportEntityHeader) cloneContext.GetExistingClone((IGraphCloneable) from);
      if (viewportEntityHeader1 == null)
        cloneContext.TargetModel.ViewportEntityHeaders.TryGetValue(from.Name, out viewportEntityHeader1);
      if (viewportEntityHeader1 == null)
      {
        switch (cloneContext.ReferenceResolutionType)
        {
          case ReferenceResolutionType.CloneMissing:
            DxfViewportEntityHeader viewportEntityHeader2 = (DxfViewportEntityHeader) from.Clone(cloneContext);
            if (!cloneContext.CloneExact)
              cloneContext.TargetModel.ViewportEntityHeaders.Add(viewportEntityHeader2);
            viewportEntityHeader1 = viewportEntityHeader2;
            break;
          case ReferenceResolutionType.FailOnMissing:
            throw new DxfException(string.Format("Could not resolve reference to viewport enity header with name {0}", (object) from.Name));
        }
      }
      return viewportEntityHeader1;
    }

    internal static DxfClass smethod_9(CloneContext cloneContext, DxfClass from)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Class906.Class907 class907 = new Class906.Class907();
      // ISSUE: reference to a compiler-generated field
      class907.dxfClass_0 = from;
      // ISSUE: reference to a compiler-generated field
      if (class907.dxfClass_0 == null)
        return (DxfClass) null;
      // ISSUE: reference to a compiler-generated field
      if (class907.dxfClass_0.CPlusPlusClassName == null)
        throw new Exception("Table record name is null.");
      if (cloneContext.SourceModel == cloneContext.TargetModel)
      {
        // ISSUE: reference to a compiler-generated field
        return class907.dxfClass_0;
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      DxfClass dxfClass = (DxfClass) cloneContext.GetExistingClone((IGraphCloneable) class907.dxfClass_0) ?? cloneContext.TargetModel.Classes.FirstOrDefault<DxfClass>(new Func<DxfClass, bool>(class907.method_0));
      if (dxfClass == null)
      {
        switch (cloneContext.ReferenceResolutionType)
        {
          case ReferenceResolutionType.CloneMissing:
            // ISSUE: reference to a compiler-generated field
            dxfClass = (DxfClass) class907.dxfClass_0.Clone(cloneContext);
            if (!cloneContext.CloneExact)
            {
              cloneContext.TargetModel.Classes.Add(dxfClass);
              break;
            }
            break;
          case ReferenceResolutionType.FailOnMissing:
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            throw new DxfException(string.Format("Could not resolve reference to CLASS with application/name {0}/{1}", (object) class907.dxfClass_0.ApplicationName, (object) class907.dxfClass_0.CPlusPlusClassName));
        }
      }
      return dxfClass;
    }

    internal static DxfColor smethod_10(CloneContext cloneContext, DxfColor from)
    {
      if (from == null)
        return (DxfColor) null;
      if (cloneContext.SourceModel == cloneContext.TargetModel)
        return from;
      DxfColor dxfColor1 = (DxfColor) null;
      if (!string.IsNullOrEmpty(from.Color.Name))
      {
        dxfColor1 = (DxfColor) cloneContext.GetExistingClone((IGraphCloneable) from) ?? cloneContext.TargetModel.Colors.GetColor(from.Color.ColorBookName, from.Color.Name);
        if (dxfColor1 == null)
        {
          switch (cloneContext.ReferenceResolutionType)
          {
            case ReferenceResolutionType.CloneMissing:
              DxfColor dxfColor2 = (DxfColor) from.Clone(cloneContext);
              if (!cloneContext.CloneExact)
                cloneContext.TargetModel.Colors.Add(dxfColor2);
              dxfColor1 = dxfColor2;
              break;
            case ReferenceResolutionType.FailOnMissing:
              throw new DxfException(string.Format("Could not resolve reference to color with book name {0} and name {1}", (object) from.Color.ColorBookName, (object) from.Color.Name));
          }
        }
      }
      return dxfColor1;
    }
  }
}
