// Decompiled with JetBrains decompiler
// Type: ns3.Class309
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System;
using WW.Cad.Base;
using WW.Cad.Model;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class309 : Class259
  {
    private string string_0;
    private ulong ulong_2;
    private string string_1;
    private ulong ulong_3;
    private string string_2;
    private ulong ulong_4;
    private string string_3;
    private ulong ulong_5;
    private string string_4;
    private ulong ulong_6;
    private string string_5;
    private ulong ulong_7;
    private string string_6;
    private ulong ulong_8;
    private string string_7;
    private ulong ulong_9;

    public Class309(DxfDimensionStyle dimensionStyle)
      : base((DxfHandledObject) dimensionStyle)
    {
    }

    public string TextStyleName
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }

    public ulong TextStyleHandle
    {
      get
      {
        return this.ulong_2;
      }
      set
      {
        this.ulong_2 = value;
      }
    }

    public string LeaderArrowBlockName
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
      }
    }

    public ulong LeaderArrowBlockHandle
    {
      get
      {
        return this.ulong_3;
      }
      set
      {
        this.ulong_3 = value;
      }
    }

    public string ArrowBlockName
    {
      get
      {
        return this.string_2;
      }
      set
      {
        this.string_2 = value;
      }
    }

    public ulong ArrowBlockHandle
    {
      get
      {
        return this.ulong_4;
      }
      set
      {
        this.ulong_4 = value;
      }
    }

    public string FirstArrowBlockName
    {
      get
      {
        return this.string_3;
      }
      set
      {
        this.string_3 = value;
      }
    }

    public ulong FirstArrowBlockHandle
    {
      get
      {
        return this.ulong_5;
      }
      set
      {
        this.ulong_5 = value;
      }
    }

    public string SecondArrowBlockName
    {
      get
      {
        return this.string_4;
      }
      set
      {
        this.string_4 = value;
      }
    }

    public ulong SecondArrowBlockHandle
    {
      get
      {
        return this.ulong_6;
      }
      set
      {
        this.ulong_6 = value;
      }
    }

    public string DimensionLineLineTypeName
    {
      get
      {
        return this.string_5;
      }
      set
      {
        this.string_5 = value;
      }
    }

    public ulong DimensionLineLineTypeHandle
    {
      get
      {
        return this.ulong_7;
      }
      set
      {
        this.ulong_7 = value;
      }
    }

    public string FirstExtensionLineLineTypeName
    {
      get
      {
        return this.string_6;
      }
      set
      {
        this.string_6 = value;
      }
    }

    public ulong FirstExtensionLineLineTypeHandle
    {
      get
      {
        return this.ulong_8;
      }
      set
      {
        this.ulong_8 = value;
      }
    }

    public string SecondExtensionLineLineTypeName
    {
      get
      {
        return this.string_7;
      }
      set
      {
        this.string_7 = value;
      }
    }

    public ulong SecondExtensionLineLineTypeHandle
    {
      get
      {
        return this.ulong_9;
      }
      set
      {
        this.ulong_9 = value;
      }
    }

    public static void smethod_0(
      DxfDimensionStyleOverrides dimensionStyle,
      DxfExtendedData extendedData,
      Class374 modelBuilder)
    {
      DxfExtendedData.ValueCollection valueCollection = (DxfExtendedData.ValueCollection) null;
      for (int index1 = 0; index1 < extendedData.Values.Count; ++index1)
      {
        DxfExtendedData.String @string = extendedData.Values[index1] as DxfExtendedData.String;
        if (@string != null && @string.Value == "DSTYLE")
        {
          int index2 = index1 + 1;
          if (index2 < extendedData.Values.Count)
          {
            valueCollection = extendedData.Values[index2] as DxfExtendedData.ValueCollection;
            break;
          }
          break;
        }
      }
      if (valueCollection == null)
        return;
      for (int index1 = 0; index1 < valueCollection.Count; index1 += 2)
      {
        DxfExtendedData.Int16 int16 = valueCollection[index1] as DxfExtendedData.Int16;
        if (int16 != null)
        {
          short num = int16.Value;
          int index2 = index1 + 1;
          if (index2 < valueCollection.Count)
          {
            IExtendedDataValue extendedDataValue = valueCollection[index2];
            switch (num)
            {
              case 3:
                dimensionStyle.PostFix = ((DxfExtendedData.String) extendedDataValue).Value;
                continue;
              case 4:
                dimensionStyle.AlternateDimensioningSuffix = ((DxfExtendedData.String) extendedDataValue).Value;
                continue;
              case 5:
                string blockName1 = ((DxfExtendedData.String) extendedDataValue).Value;
                if (!string.IsNullOrEmpty(blockName1))
                {
                  dimensionStyle.ArrowBlock = Class309.smethod_1(modelBuilder, blockName1);
                  continue;
                }
                continue;
              case 6:
                string blockName2 = ((DxfExtendedData.String) extendedDataValue).Value;
                if (!string.IsNullOrEmpty(blockName2))
                {
                  dimensionStyle.FirstArrowBlock = Class309.smethod_1(modelBuilder, blockName2);
                  continue;
                }
                continue;
              case 7:
                string blockName3 = ((DxfExtendedData.String) extendedDataValue).Value;
                if (!string.IsNullOrEmpty(blockName3))
                {
                  dimensionStyle.SecondArrowBlock = Class309.smethod_1(modelBuilder, blockName3);
                  continue;
                }
                continue;
              case 40:
                dimensionStyle.ScaleFactor = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 41:
                dimensionStyle.ArrowSize = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 42:
                dimensionStyle.ExtensionLineOffset = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 43:
                dimensionStyle.DimensionLineIncrement = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 44:
                dimensionStyle.ExtensionLineExtension = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 45:
                dimensionStyle.Rounding = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 46:
                dimensionStyle.DimensionLineExtension = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 47:
                dimensionStyle.PlusTolerance = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 48:
                dimensionStyle.MinusTolerance = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 49:
                dimensionStyle.FixedExtensionLineLength = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 50:
                dimensionStyle.JoggedRadiusDimensionTransverseSegmentAngle = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 69:
                dimensionStyle.TextBackgroundFillMode = (DimensionTextBackgroundFillMode) ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 70:
                dimensionStyle.TextBackgroundColor = Color.CreateFromColorIndex(((DxfExtendedData.Int16) extendedDataValue).Value);
                continue;
              case 71:
                dimensionStyle.GenerateTolerances = ((DxfExtendedData.Int16) extendedDataValue).Value == (short) 1;
                continue;
              case 72:
                dimensionStyle.LimitsGeneration = ((DxfExtendedData.Int16) extendedDataValue).Value == (short) 1;
                continue;
              case 73:
                dimensionStyle.TextInsideHorizontal = ((DxfExtendedData.Int16) extendedDataValue).Value == (short) 1;
                continue;
              case 74:
                dimensionStyle.TextOutsideHorizontal = ((DxfExtendedData.Int16) extendedDataValue).Value == (short) 1;
                continue;
              case 75:
                dimensionStyle.SuppressFirstExtensionLine = ((DxfExtendedData.Int16) extendedDataValue).Value == (short) 1;
                continue;
              case 76:
                dimensionStyle.SuppressSecondExtensionLine = ((DxfExtendedData.Int16) extendedDataValue).Value == (short) 1;
                continue;
              case 77:
                dimensionStyle.TextVerticalAlignment = (DimensionTextVerticalAlignment) ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 78:
                dimensionStyle.ZeroHandling = (ZeroHandling) ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 79:
                dimensionStyle.AngularZeroHandling = (ZeroHandling) ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 90:
                dimensionStyle.ArcLengthSymbolPosition = (ArcLengthSymbolPosition) ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 140:
                dimensionStyle.TextHeight = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 141:
                dimensionStyle.CenterMarkSize = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 142:
                dimensionStyle.TickSize = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 143:
                dimensionStyle.AlternateUnitScaleFactor = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 144:
                dimensionStyle.LinearScaleFactor = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 145:
                dimensionStyle.TextVerticalPosition = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 146:
                dimensionStyle.ToleranceScaleFactor = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 147:
                dimensionStyle.DimensionLineGap = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 148:
                dimensionStyle.AlternateUnitRounding = ((DxfExtendedData.Double) extendedDataValue).Value;
                continue;
              case 170:
                dimensionStyle.AlternateUnitDimensioning = ((DxfExtendedData.Int16) extendedDataValue).Value == (short) 1;
                continue;
              case 171:
                dimensionStyle.AlternateUnitDecimalPlaces = ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 172:
                dimensionStyle.TextOutsideExtensions = ((DxfExtendedData.Int16) extendedDataValue).Value == (short) 1;
                continue;
              case 173:
                dimensionStyle.SeparateArrowBlocks = ((DxfExtendedData.Int16) extendedDataValue).Value == (short) 1;
                continue;
              case 174:
                dimensionStyle.TextInsideExtensions = ((DxfExtendedData.Int16) extendedDataValue).Value == (short) 1;
                continue;
              case 175:
                dimensionStyle.SuppressOutsideExtensions = ((DxfExtendedData.Int16) extendedDataValue).Value == (short) 1;
                continue;
              case 176:
                short colorIndex1 = ((DxfExtendedData.Int16) extendedDataValue).Value;
                dimensionStyle.DimensionLineColor = Color.CreateFromColorIndex(colorIndex1);
                continue;
              case 177:
                short colorIndex2 = ((DxfExtendedData.Int16) extendedDataValue).Value;
                dimensionStyle.ExtensionLineColor = Color.CreateFromColorIndex(colorIndex2);
                continue;
              case 178:
                short colorIndex3 = ((DxfExtendedData.Int16) extendedDataValue).Value;
                dimensionStyle.TextColor = Color.CreateFromColorIndex(colorIndex3);
                continue;
              case 179:
                dimensionStyle.AngularDimensionDecimalPlaces = ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 271:
                dimensionStyle.DecimalPlaces = Convert.ToInt16(extendedDataValue.ValueObject);
                continue;
              case 272:
                dimensionStyle.ToleranceDecimalPlaces = ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 273:
                dimensionStyle.AlternateUnitFormat = (AlternateUnitFormat) ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 274:
                dimensionStyle.AlternateUnitToleranceDecimalPlaces = ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 275:
                dimensionStyle.AngularUnit = (AngularUnit) ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 276:
                dimensionStyle.FractionFormat = (FractionFormat) ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 277:
                dimensionStyle.LinearUnitFormat = (LinearUnitFormat) ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 278:
                dimensionStyle.DecimalSeparator = (char) ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 279:
                dimensionStyle.TextMovement = (TextMovement) ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 280:
                dimensionStyle.TextHorizontalAlignment = (DimensionTextHorizontalAlignment) ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 281:
                dimensionStyle.SuppressFirstDimensionLine = ((DxfExtendedData.Int16) extendedDataValue).Value == (short) 1;
                continue;
              case 282:
                dimensionStyle.SuppressSecondDimensionLine = ((DxfExtendedData.Int16) extendedDataValue).Value == (short) 1;
                continue;
              case 283:
                dimensionStyle.ToleranceAlignment = (ToleranceAlignment) ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 284:
                dimensionStyle.ToleranceZeroHandling = (ZeroHandling) ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 285:
                dimensionStyle.AlternateUnitZeroHandling = (ZeroHandling) ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 286:
                dimensionStyle.AlternateUnitToleranceZeroHandling = (ZeroHandling) ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 288:
                dimensionStyle.CursorUpdate = (CursorUpdate) ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 290:
                dimensionStyle.IsExtensionLineLengthFixed = ((DxfExtendedData.Int16) extendedDataValue).Value != (short) 0;
                continue;
              case 340:
                DxfTextStyle dxfTextStyle = Class309.smethod_2(modelBuilder, extendedDataValue) as DxfTextStyle;
                if (dxfTextStyle != null)
                {
                  dimensionStyle.TextStyle = dxfTextStyle;
                  continue;
                }
                continue;
              case 341:
                DxfBlock dxfBlock1 = Class309.smethod_2(modelBuilder, extendedDataValue) as DxfBlock;
                if (dxfBlock1 != null)
                {
                  dimensionStyle.LeaderArrowBlock = dxfBlock1;
                  continue;
                }
                continue;
              case 342:
                DxfBlock dxfBlock2 = Class309.smethod_2(modelBuilder, extendedDataValue) as DxfBlock;
                if (dxfBlock2 != null)
                {
                  dimensionStyle.ArrowBlock = dxfBlock2;
                  continue;
                }
                continue;
              case 343:
                DxfBlock dxfBlock3 = Class309.smethod_2(modelBuilder, extendedDataValue) as DxfBlock;
                if (dxfBlock3 != null)
                {
                  dimensionStyle.FirstArrowBlock = dxfBlock3;
                  continue;
                }
                continue;
              case 344:
                DxfBlock dxfBlock4 = Class309.smethod_2(modelBuilder, extendedDataValue) as DxfBlock;
                if (dxfBlock4 != null)
                {
                  dimensionStyle.SecondArrowBlock = dxfBlock4;
                  continue;
                }
                continue;
              case 345:
                DxfLineType dxfLineType1 = Class309.smethod_2(modelBuilder, extendedDataValue) as DxfLineType;
                if (dxfLineType1 != null)
                {
                  dimensionStyle.DimensionLineLineType = dxfLineType1;
                  continue;
                }
                continue;
              case 346:
                DxfLineType dxfLineType2 = Class309.smethod_2(modelBuilder, extendedDataValue) as DxfLineType;
                if (dxfLineType2 != null)
                {
                  dimensionStyle.FirstExtensionLineLineType = dxfLineType2;
                  continue;
                }
                continue;
              case 347:
                DxfLineType dxfLineType3 = Class309.smethod_2(modelBuilder, extendedDataValue) as DxfLineType;
                if (dxfLineType3 != null)
                {
                  dimensionStyle.SecondExtensionLineLineType = dxfLineType3;
                  continue;
                }
                continue;
              case 371:
                dimensionStyle.DimensionLineWeight = ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              case 372:
                dimensionStyle.ExtensionLineWeight = ((DxfExtendedData.Int16) extendedDataValue).Value;
                continue;
              default:
                continue;
            }
          }
        }
        else
        {
          modelBuilder.Messages.Add(new DxfMessage(DxfStatus.InvalidXDataValueType, Severity.Warning, "ValueType", (object) valueCollection[index1].GetType())
          {
            Parameters = {
              {
                "ExpectedValueType",
                (object) typeof (DxfExtendedData.Int16)
              },
              {
                "Target",
                (object) dimensionStyle
              }
            }
          });
          break;
        }
      }
    }

    private static DxfBlock smethod_1(Class374 modelBuilder, string blockName)
    {
      DxfBlock blockWithName = modelBuilder.Model.GetBlockWithName(blockName);
      if (blockWithName == null && !blockName.StartsWith("_"))
        blockWithName = modelBuilder.Model.GetBlockWithName("_" + blockName);
      return blockWithName;
    }

    private static DxfHandledObject smethod_2(
      Class374 modelBuilder,
      IExtendedDataValue value)
    {
      DxfExtendedData.DatabaseHandle databaseHandle = value as DxfExtendedData.DatabaseHandle;
      DxfHandledObject dxfHandledObject = (DxfHandledObject) null;
      if (databaseHandle != null)
      {
        dxfHandledObject = databaseHandle.Value;
      }
      else
      {
        DxfExtendedData.String @string = value as DxfExtendedData.String;
        ulong handle = @string == null ? 0UL : DxfHandledObject.Parse(@string.Value);
        if (handle != 0UL)
          dxfHandledObject = modelBuilder.method_3(handle);
      }
      return dxfHandledObject;
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfDimensionStyle handledObject = (DxfDimensionStyle) this.HandledObject;
      if (this.ulong_2 != 0UL)
      {
        DxfTextStyle dxfTextStyle = modelBuilder.method_4<DxfTextStyle>(this.ulong_2);
        if (dxfTextStyle != null)
          handledObject.TextStyle = dxfTextStyle;
      }
      else if (!string.IsNullOrEmpty(this.string_0))
      {
        DxfTextStyle textStyleWithName = modelBuilder.Model.GetTextStyleWithName(this.string_0);
        if (textStyleWithName != null)
          handledObject.TextStyle = textStyleWithName;
      }
      if (this.ulong_3 != 0UL)
      {
        DxfBlock dxfBlock = modelBuilder.method_4<DxfBlock>(this.ulong_3);
        handledObject.LeaderArrowBlock = dxfBlock;
      }
      else if (!string.IsNullOrEmpty(this.string_1))
      {
        DxfBlock blockWithName = modelBuilder.Model.GetBlockWithName(this.string_1);
        handledObject.LeaderArrowBlock = blockWithName;
      }
      if (this.ulong_4 != 0UL)
      {
        DxfBlock dxfBlock = modelBuilder.method_4<DxfBlock>(this.ulong_4);
        handledObject.ArrowBlock = dxfBlock;
      }
      else if (!string.IsNullOrEmpty(this.string_2))
      {
        DxfBlock blockWithName = modelBuilder.Model.GetBlockWithName(this.string_2);
        handledObject.ArrowBlock = blockWithName;
      }
      if (this.ulong_5 != 0UL)
      {
        DxfBlock dxfBlock = modelBuilder.method_4<DxfBlock>(this.ulong_5);
        handledObject.FirstArrowBlock = dxfBlock;
      }
      else if (!string.IsNullOrEmpty(this.string_3))
      {
        DxfBlock blockWithName = modelBuilder.Model.GetBlockWithName(this.string_3);
        handledObject.FirstArrowBlock = blockWithName;
      }
      if (this.ulong_6 != 0UL)
      {
        DxfBlock dxfBlock = modelBuilder.method_4<DxfBlock>(this.ulong_6);
        handledObject.SecondArrowBlock = dxfBlock;
      }
      else if (!string.IsNullOrEmpty(this.string_4))
      {
        DxfBlock blockWithName = modelBuilder.Model.GetBlockWithName(this.string_4);
        handledObject.SecondArrowBlock = blockWithName;
      }
      if (this.ulong_7 != 0UL)
        handledObject.DimensionLineLineType = modelBuilder.method_4<DxfLineType>(this.ulong_7);
      else if (!string.IsNullOrEmpty(this.string_5))
        handledObject.DimensionLineLineType = modelBuilder.Model.GetLineTypeWithName(this.string_5);
      if (this.ulong_8 != 0UL)
        handledObject.FirstExtensionLineLineType = modelBuilder.method_4<DxfLineType>(this.ulong_8);
      else if (!string.IsNullOrEmpty(this.string_6))
        handledObject.FirstExtensionLineLineType = modelBuilder.Model.GetLineTypeWithName(this.string_6);
      if (this.ulong_9 != 0UL)
      {
        handledObject.SecondExtensionLineLineType = modelBuilder.method_4<DxfLineType>(this.ulong_9);
      }
      else
      {
        if (string.IsNullOrEmpty(this.string_7))
          return;
        handledObject.SecondExtensionLineLineType = modelBuilder.Model.GetLineTypeWithName(this.string_7);
      }
    }
  }
}
