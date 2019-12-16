// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.DxfTextStyle
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns36;
using ns4;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using WW.Cad.Base;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Text;

namespace WW.Cad.Model.Tables
{
  public class DxfTextStyle : DxfTableRecord, IEquatable<DxfTextStyle>
  {
    private string string_0 = string.Empty;
    private TextStyleFlags textStyleFlags_0 = TextStyleFlags.IsReferenced;
    private double double_1 = 1.0;
    private double double_3 = 0.2;
    public const string DefaultTextStyleName = "Standard";
    private string string_1;
    private string string_2;
    private TrueTypeFontDescriptor trueTypeFontDescriptor_0;
    private TextGenerationFlags textGenerationFlags_0;
    private double double_0;
    private double double_2;
    private FontFamily fontFamily_0;
    private FontStyle fontStyle_0;
    private ShxFile shxFile_0;

    public DxfTextStyle()
    {
    }

    public DxfTextStyle(string name, string fontFilename)
    {
      this.Name = name;
      this.string_1 = fontFilename;
    }

    public string FontFilename
    {
      get
      {
        return this.string_1;
      }
      set
      {
        DxfModel model = this.Model;
        if (model != null && !string.IsNullOrEmpty(this.string_1))
          model.FileDependencies.Remove("Acad:Text", this.string_1, (DxfHandledObject) this);
        this.string_1 = value;
        if (model != null && !string.IsNullOrEmpty(this.string_1))
          model.FileDependencies.Add("Acad:Text", this.string_1, true, (DxfHandledObject) this);
        this.fontFamily_0 = (FontFamily) null;
        this.fontStyle_0 = FontStyle.Regular;
        if (this.double_2 <= 0.0)
          return;
        this.fontStyle_0 = FontStyle.Italic;
      }
    }

    public FontFamily FontFamily
    {
      get
      {
        if (this.fontFamily_0 == null)
          Class594.smethod_0(this.string_1, false, false, out this.fontFamily_0, out this.fontStyle_0);
        return this.fontFamily_0;
      }
    }

    public FontStyle FontStyle
    {
      get
      {
        return this.fontStyle_0;
      }
    }

    public string BigFontFilename
    {
      get
      {
        return this.string_2;
      }
      set
      {
        DxfModel model = this.Model;
        if (model != null && !string.IsNullOrEmpty(this.string_2))
          model.FileDependencies.Remove("Acad:Text", this.string_2, (DxfHandledObject) this);
        this.string_2 = value;
        if (model == null || string.IsNullOrEmpty(this.string_2))
          return;
        model.FileDependencies.Add("Acad:Text", this.string_2, true, (DxfHandledObject) this);
      }
    }

    public TrueTypeFontDescriptor TrueTypeFontDescriptor
    {
      get
      {
        return this.trueTypeFontDescriptor_0;
      }
      set
      {
        this.trueTypeFontDescriptor_0 = value;
      }
    }

    public double FixedHeight
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
      }
    }

    public TextStyleFlags Flags
    {
      get
      {
        return this.textStyleFlags_0;
      }
      set
      {
        this.textStyleFlags_0 = value;
      }
    }

    public bool IsShape
    {
      get
      {
        return (this.textStyleFlags_0 & TextStyleFlags.IsShape) != TextStyleFlags.None;
      }
      set
      {
        if (value)
          this.textStyleFlags_0 |= TextStyleFlags.IsShape;
        else
          this.textStyleFlags_0 &= ~TextStyleFlags.IsShape;
      }
    }

    public bool IsVertical
    {
      get
      {
        return (this.textStyleFlags_0 & TextStyleFlags.VerticalText) != TextStyleFlags.None;
      }
      set
      {
        if (value)
          this.textStyleFlags_0 |= TextStyleFlags.VerticalText;
        else
          this.textStyleFlags_0 &= ~TextStyleFlags.VerticalText;
      }
    }

    public override bool IsExternallyDependent
    {
      get
      {
        return (this.textStyleFlags_0 & TextStyleFlags.IsExternallyDependent) != TextStyleFlags.None;
      }
      set
      {
        if (value)
          this.textStyleFlags_0 |= TextStyleFlags.IsExternallyDependent;
        else
          this.textStyleFlags_0 &= ~TextStyleFlags.IsExternallyDependent;
      }
    }

    public override bool IsResolvedExternalRef
    {
      get
      {
        return (this.textStyleFlags_0 & TextStyleFlags.IsResolvedExternalRef) != TextStyleFlags.None;
      }
      set
      {
        if (value)
          this.textStyleFlags_0 |= TextStyleFlags.IsResolvedExternalRef;
        else
          this.textStyleFlags_0 &= ~TextStyleFlags.IsResolvedExternalRef;
      }
    }

    public override bool IsReferenced
    {
      get
      {
        return (this.textStyleFlags_0 & TextStyleFlags.IsReferenced) != TextStyleFlags.None;
      }
      set
      {
        if (value)
          this.textStyleFlags_0 |= TextStyleFlags.IsReferenced;
        else
          this.textStyleFlags_0 &= ~TextStyleFlags.IsReferenced;
      }
    }

    public double LastHeightUsed
    {
      get
      {
        return this.double_3;
      }
      set
      {
        this.double_3 = value;
      }
    }

    public override string Name
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

    public double ObliqueAngle
    {
      get
      {
        return this.double_2;
      }
      set
      {
        this.double_2 = value;
      }
    }

    [Obsolete("Replaced by property TextGenerationFlags.")]
    public TextGenerationFlags GenerationFlags
    {
      get
      {
        return this.textGenerationFlags_0;
      }
      set
      {
        this.textGenerationFlags_0 = value;
      }
    }

    public TextGenerationFlags TextGenerationFlags
    {
      get
      {
        return this.textGenerationFlags_0;
      }
      set
      {
        this.textGenerationFlags_0 = value;
      }
    }

    public bool IsBackwards
    {
      get
      {
        return (this.textGenerationFlags_0 & TextGenerationFlags.Backwards) != TextGenerationFlags.None;
      }
      set
      {
        if (value)
          this.textGenerationFlags_0 |= TextGenerationFlags.Backwards;
        else
          this.textGenerationFlags_0 &= ~TextGenerationFlags.Backwards;
      }
    }

    public bool IsUpsideDown
    {
      get
      {
        return (this.textGenerationFlags_0 & TextGenerationFlags.UpsideDown) != TextGenerationFlags.None;
      }
      set
      {
        if (value)
          this.textGenerationFlags_0 |= TextGenerationFlags.UpsideDown;
        else
          this.textGenerationFlags_0 &= ~TextGenerationFlags.UpsideDown;
      }
    }

    public double WidthFactor
    {
      get
      {
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
      }
    }

    public override void Accept(ITableRecordVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      if (this.string_0 == string.Empty)
        return true;
      return ValidateUtil.ValidateName((object) this, this.string_0, model, messages);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfTextStyle dxfTextStyle = (DxfTextStyle) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfTextStyle == null)
      {
        dxfTextStyle = new DxfTextStyle();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfTextStyle);
        dxfTextStyle.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfTextStyle;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfTextStyle dxfTextStyle = (DxfTextStyle) from;
      this.string_0 = dxfTextStyle.string_0;
      this.string_1 = dxfTextStyle.string_1;
      this.string_2 = dxfTextStyle.string_2;
      this.textStyleFlags_0 = dxfTextStyle.textStyleFlags_0;
      this.textGenerationFlags_0 = dxfTextStyle.textGenerationFlags_0;
      this.double_0 = dxfTextStyle.double_0;
      this.double_1 = dxfTextStyle.double_1;
      this.double_2 = dxfTextStyle.double_2;
      this.double_3 = dxfTextStyle.double_3;
      this.trueTypeFontDescriptor_0 = dxfTextStyle.trueTypeFontDescriptor_0 == null ? (TrueTypeFontDescriptor) null : (TrueTypeFontDescriptor) dxfTextStyle.trueTypeFontDescriptor_0.Clone();
      if (dxfTextStyle.Handle != 17UL)
        return;
      this.SetHandle(17UL);
    }

    public override string ToString()
    {
      return this.string_0;
    }

    internal override void vmethod_10(DxfModel model)
    {
      base.vmethod_10(model);
      DxfExtendedData extendedData;
      if (!this.HasExtendedData || !this.ExtendedDataCollection.TryGetValue(this.Model.AppIdAcad, out extendedData))
        return;
      TrueTypeFontDescriptor typeFontDescriptor = new TrueTypeFontDescriptor();
      bool flag = false;
      foreach (IExtendedDataValue extendedDataValue in (List<IExtendedDataValue>) extendedData.Values)
      {
        DxfExtendedData.String @string = extendedDataValue as DxfExtendedData.String;
        if (@string != null)
        {
          typeFontDescriptor.FontFilename = @string.Value;
          if (!string.IsNullOrEmpty(typeFontDescriptor.FontFilename))
            flag = true;
        }
        else
        {
          DxfExtendedData.Int32 int32 = extendedDataValue as DxfExtendedData.Int32;
          if (int32 != null)
          {
            typeFontDescriptor.Flags = (TrueTypeFontFlags) int32.Value;
            if (typeFontDescriptor.Flags != TrueTypeFontFlags.None)
              flag = true;
          }
        }
      }
      if (!flag)
        return;
      this.trueTypeFontDescriptor_0 = typeFontDescriptor;
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      if (this.trueTypeFontDescriptor_0 == null)
      {
        if (!this.HasExtendedData)
          return;
        this.ExtendedDataCollection.Remove(this.Model.AppIdAcad);
      }
      else
      {
        DxfExtendedData extendedData;
        if (this.HasExtendedData && this.ExtendedDataCollection.TryGetValue(this.Model.AppIdAcad, out extendedData))
        {
          extendedData.Values.Clear();
        }
        else
        {
          extendedData = new DxfExtendedData(this.Model.AppIdAcad);
          this.ExtendedDataCollection.Add(extendedData);
        }
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.String(this.trueTypeFontDescriptor_0.FontFilename));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Int32((int) this.trueTypeFontDescriptor_0.Flags));
      }
    }

    internal static string smethod_2(string[] path, string filename)
    {
      string str = string.Empty;
      if (!string.IsNullOrEmpty(filename))
      {
        filename.ToLower();
        if (Path.GetExtension(filename) == ".shx")
        {
          str = Class1043.smethod_1(filename, path);
        }
        else
        {
          Class895 class895 = Class810.smethod_0(filename);
          if (class895 != null)
            str = class895.FullFilename;
        }
      }
      return str;
    }

    internal bool method_8()
    {
      return this.Model.method_34(this.string_1);
    }

    internal ShxFile GetShxFile()
    {
      if (this.shxFile_0 == null)
      {
        try
        {
          this.shxFile_0 = this.Model.GetShxFile(this.string_1);
        }
        catch (IOException ex)
        {
        }
      }
      return this.shxFile_0;
    }

    internal void method_9(string name)
    {
      this.string_0 = name;
    }

    internal static DxfTextStyle smethod_3(bool useFixedHandles)
    {
      DxfTextStyle dxfTextStyle = new DxfTextStyle();
      dxfTextStyle.FontFilename = "txt.shx";
      dxfTextStyle.Name = "Standard";
      if (useFixedHandles)
        dxfTextStyle.SetHandle(17UL);
      return dxfTextStyle;
    }

    internal override void vmethod_3(DxfModel modelContext)
    {
      base.vmethod_3(modelContext);
      this.vmethod_2((IDxfHandledObject) modelContext.TextStyleTable);
      if (!string.IsNullOrEmpty(this.string_1))
        modelContext.FileDependencies.Add("Acad:Text", this.string_1, true, (DxfHandledObject) this);
      if (string.IsNullOrEmpty(this.string_2))
        return;
      modelContext.FileDependencies.Add("Acad:Text", this.string_2, true, (DxfHandledObject) this);
    }

    internal override void vmethod_4(DxfModel modelContext)
    {
      base.vmethod_4(modelContext);
      this.vmethod_2((IDxfHandledObject) null);
      if (!string.IsNullOrEmpty(this.string_1))
        modelContext.FileDependencies.Remove("Acad:Text", this.string_1, (DxfHandledObject) this);
      if (string.IsNullOrEmpty(this.string_2))
        return;
      modelContext.FileDependencies.Remove("Acad:Text", this.string_2, (DxfHandledObject) this);
    }

    public bool Equals(DxfTextStyle other)
    {
      return this == other;
    }
  }
}
