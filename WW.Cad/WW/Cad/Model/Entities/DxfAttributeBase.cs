// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfAttributeBase
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns1;
using ns2;
using System;
using System.Collections.Generic;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Cad.IO;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.Annotations;
using WW.Collections.Generic;

namespace WW.Cad.Model.Entities
{
  public abstract class DxfAttributeBase : DxfText
  {
    internal static readonly Class680 class680_0 = new Class680();
    private string string_5 = string.Empty;
    private const string string_1 = "ACAD_FIELD";
    private const string string_2 = "ACAD_MLATT";
    private const string string_3 = "ACAD_XRECT_ROUNDTRIP";
    private const string string_4 = "Embedded Object";
    private AttributeFlags attributeFlags_0;
    private bool bool_3;
    private DxfAttributeBase dxfAttributeBase_0;

    protected DxfAttributeBase()
    {
    }

    protected DxfAttributeBase(string text, WW.Math.Point3D alignmentPoint1)
      : base(text, alignmentPoint1)
    {
    }

    protected DxfAttributeBase(string text, WW.Math.Point3D alignmentPoint1, double height)
      : base(text, alignmentPoint1, height)
    {
    }

    protected DxfAttributeBase(DxfAttributeBase attributeBase)
      : base((DxfText) attributeBase)
    {
      this.string_5 = attributeBase.string_5;
      this.attributeFlags_0 = attributeBase.attributeFlags_0;
      this.bool_3 = attributeBase.bool_3;
    }

    public AttributeMultiLineState MultiLineState
    {
      get
      {
        if (this.dxfAttributeBase_0 != null)
          return AttributeMultiLineState.SecondarySingleLine;
        return this.method_21() != null ? AttributeMultiLineState.PrimaryMultiLine : AttributeMultiLineState.PrimarySingleLine;
      }
    }

    public bool Invisible
    {
      get
      {
        return (this.attributeFlags_0 & AttributeFlags.Invisible) != AttributeFlags.None;
      }
      set
      {
        if (value)
          this.Flags |= AttributeFlags.Invisible;
        else
          this.Flags &= ~AttributeFlags.Invisible;
      }
    }

    public bool Constant
    {
      get
      {
        return (this.attributeFlags_0 & AttributeFlags.Constant) != AttributeFlags.None;
      }
      set
      {
        if (value)
          this.Flags |= AttributeFlags.Constant;
        else
          this.Flags &= ~AttributeFlags.Constant;
      }
    }

    public bool InputVerificationRequired
    {
      get
      {
        return (this.attributeFlags_0 & AttributeFlags.InputVerificationRequired) != AttributeFlags.None;
      }
      set
      {
        if (value)
          this.Flags |= AttributeFlags.InputVerificationRequired;
        else
          this.Flags &= ~AttributeFlags.InputVerificationRequired;
      }
    }

    public bool Preset
    {
      get
      {
        return (this.attributeFlags_0 & AttributeFlags.Preset) != AttributeFlags.None;
      }
      set
      {
        if (value)
          this.Flags |= AttributeFlags.Preset;
        else
          this.Flags &= ~AttributeFlags.Preset;
      }
    }

    public string TagString
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

    public string BasicTagString
    {
      get
      {
        string tagString = this.TagString;
        if (this.MultiLineState != AttributeMultiLineState.PrimarySingleLine && tagString.Length > 4)
        {
          int num = tagString.Length - 4;
          string str = tagString.Substring(num);
          if (str[0] == '_' && char.IsDigit(str[1]) && (char.IsDigit(str[2]) && char.IsDigit(str[3])))
            return tagString.Substring(0, num);
        }
        return tagString;
      }
      set
      {
        string tagString = this.TagString;
        string basicTagString = this.BasicTagString;
        if (basicTagString.Length > tagString.Length)
          this.TagString = value + tagString.Substring(basicTagString.Length);
        else
          this.TagString = value;
      }
    }

    public bool LockPosition
    {
      get
      {
        return this.bool_3;
      }
      set
      {
        this.bool_3 = value;
      }
    }

    internal AttributeFlags Flags
    {
      get
      {
        return this.attributeFlags_0;
      }
      set
      {
        this.attributeFlags_0 = value;
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      if (!this.IsVisible((DrawContext) context))
        return;
      DxfMText dxfMtext = this.method_20(context.Config);
      if (dxfMtext != null)
        dxfMtext.DrawInternal(context, graphicsFactory);
      else
        base.DrawInternal(context, graphicsFactory);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      if (!this.IsVisible((DrawContext) context))
        return;
      DxfMText dxfMtext = this.method_20(context.Config);
      if (dxfMtext != null)
        dxfMtext.DrawInternal(context, graphicsFactory);
      else
        base.DrawInternal(context, graphicsFactory);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      if (!this.IsVisible((DrawContext) context))
        return;
      DxfMText dxfMtext = this.method_20(context.Config);
      if (dxfMtext != null)
        dxfMtext.DrawInternal(context, graphicsFactory);
      else
        base.DrawInternal(context, graphicsFactory);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      if (!this.IsVisible((DrawContext) context))
        return;
      DxfMText dxfMtext = this.method_20(context.Config);
      if (dxfMtext != null)
        dxfMtext.DrawInternal(context, graphics, parentGraphicElementBlock);
      else
        base.DrawInternal(context, graphics, parentGraphicElementBlock);
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfAttributeBase dxfAttributeBase = (DxfAttributeBase) from;
      this.string_5 = dxfAttributeBase.string_5;
      this.attributeFlags_0 = dxfAttributeBase.attributeFlags_0;
      this.bool_3 = dxfAttributeBase.bool_3;
      this.dxfAttributeBase_0 = dxfAttributeBase.dxfAttributeBase_0;
    }

    public abstract bool IsVisible(DrawContext context);

    internal void method_17(string tagString)
    {
      this.string_5 = tagString;
    }

    internal bool method_18()
    {
      if (this.ExtensionDictionary != null)
        return this.ExtensionDictionary.GetValueByName("ACAD_MLATT") is DxfXRecord;
      return false;
    }

    internal void method_19()
    {
      if (this.ExtensionDictionary == null)
        return;
      DxfObject valueByName = this.ExtensionDictionary.GetValueByName("ACAD_MLATT");
      if (!(valueByName is DxfXRecord))
        return;
      DxfXRecordValueCollection values = ((DxfXRecord) valueByName).Values;
      if (values.Count <= 2)
        return;
      DxfXRecordValue dxfXrecordValue1 = values[2];
      if (dxfXrecordValue1.Code != (short) 70)
        return;
      int num = (int) (short) dxfXrecordValue1.Value;
      if (values.Count <= 2 + num)
        return;
      for (int index = 0; index < num; ++index)
      {
        DxfXRecordValue dxfXrecordValue2 = values[3 + index];
        if (dxfXrecordValue2.Code != (short) 340)
          break;
        DxfAttributeBase dxfAttributeBase = dxfXrecordValue2.Value as DxfAttributeBase;
        if (dxfAttributeBase != null)
          dxfAttributeBase.dxfAttributeBase_0 = this;
      }
    }

    internal DxfMText method_20(GraphicsConfig config)
    {
      if (config.MultiLineAttributeHandling != MultiLineAttributeHandling.UseMultiLine)
        return (DxfMText) null;
      return this.method_21();
    }

    internal DxfMText method_21()
    {
      if (this.ExtensionDictionary != null)
      {
        DxfObject valueByName = this.ExtensionDictionary.GetValueByName("ACAD_MLATT");
        if (valueByName is DxfXRecord)
        {
          DxfXRecord dxfXrecord = (DxfXRecord) valueByName;
          int num = 0;
          DxfXRecordValueCollection values = dxfXrecord.Values;
          while (num < values.Count)
          {
            DxfXRecordValue dxfXrecordValue = values[num++];
            if (dxfXrecordValue.Code == (short) 1 && "Embedded Object".Equals(dxfXrecordValue.Value.ToString()))
              break;
          }
          if (num < values.Count)
          {
            DxfXRecordValueCollection xrecordValueCollection = new DxfXRecordValueCollection();
            xrecordValueCollection.AddRange((IEnumerable<DxfXRecordValue>) new DxfXRecordValue[5]
            {
              new DxfXRecordValue((short) 0, (object) "MTEXT"),
              new DxfXRecordValue((short) 100, (object) "AcDbEntity"),
              new DxfXRecordValue((short) 8, (object) this.Layer.Name),
              new DxfXRecordValue((short) 67, (object) (short) (this.PaperSpace ? 1 : 0)),
              new DxfXRecordValue((short) 100, (object) "AcDbMText")
            });
            while (num < values.Count)
              xrecordValueCollection.Add(values[num++]);
            Struct18 endGroup = new Struct18(0, (object) "ENDSIM");
            DxfModel model = this.Model;
            if (model == null)
              throw new Exception("Cannot get MTEXT substitute when attribute has no parent object.");
            DxfMText dxfMtext = DxfReader.smethod_1(model, (Interface33) new Class720(endGroup, (IEnumerable<DxfXRecordValue>) xrecordValueCollection), endGroup) as DxfMText;
            if (dxfMtext != null)
            {
              dxfMtext.method_12((DxfEntity) this);
              dxfMtext.Style = this.Style;
              if (this.IsAnnotative)
              {
                dxfMtext.IsAnnotative = true;
                dxfMtext.vmethod_2((IDxfHandledObject) this);
                DxfDictionary dxfDictionary1 = DxfAnnotationScaleObjectContextData.smethod_7((DxfHandledObject) this, true);
                DxfDictionary dxfDictionary2 = DxfAnnotationScaleObjectContextData.smethod_7((DxfHandledObject) dxfMtext, true);
                foreach (IDictionaryEntry entry in (ActiveList<IDictionaryEntry>) dxfDictionary1.Entries)
                  dxfDictionary2.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("*A", (DxfObject) ((DxfAttributeObjectContextData) entry.Value).Mtext));
              }
              return dxfMtext;
            }
          }
        }
      }
      return (DxfMText) null;
    }

    protected bool IsVisibleMultiLine(GraphicsConfig config)
    {
      if (this.MultiLineState == AttributeMultiLineState.SecondarySingleLine)
        return config.MultiLineAttributeHandling == MultiLineAttributeHandling.UseSingleLine;
      return true;
    }
  }
}
