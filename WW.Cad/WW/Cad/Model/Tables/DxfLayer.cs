// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.DxfLayer
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns2;
using System;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;

namespace WW.Cad.Model.Tables
{
  public class DxfLayer : DxfTableRecord, IComparable
  {
    public static readonly IComparer<DxfLayer> CaseInsensitiveNameComparer = (IComparer<DxfLayer>) new DxfLayer.Class904();
    private LayerFlags layerFlags_0 = LayerFlags.IsReferenced;
    private bool bool_0 = true;
    private Color color_0 = Colors.White;
    private Transparency transparency_0 = Transparency.Opaque;
    private DxfObjectReference dxfObjectReference_3 = DxfObjectReference.Null;
    private short short_0 = -3;
    private bool bool_1 = true;
    private const string string_0 = "ADSK_XREC_LAYER_COLOR_OVR";
    private const string string_1 = "{ADSK_LYR_COLOR_OVERRIDE";
    private const string string_2 = "ADSK_XREC_LAYER_LINETYPE_OVR";
    private const string string_3 = "{ADSK_LYR_LINETYPE_OVERRIDE";
    private const string string_4 = "ADSK_XREC_LAYER_LINEWT_OVR";
    private const string string_5 = "{ADSK_LYR_LINEWT_OVERRIDE";
    private const string string_6 = "ADSK_XREC_LAYER_ALPHA_OVR";
    private const string string_7 = "{ADSK_LYR_ALPHA_OVERRIDE";
    private const string string_8 = "}";
    public const string LayerNameZero = "0";
    public const string LayerNameDefinitionPoints = "DEFPOINTS";
    private string string_9;
    private bool bool_2;
    private DxfLayer.Class905 class905_0;

    public DxfLayer()
      : this((string) null)
    {
    }

    public DxfLayer(string name)
    {
      this.Name = name;
    }

    public override string Name
    {
      get
      {
        return this.string_9;
      }
      set
      {
        this.string_9 = value;
        this.bool_2 = this.string_9 == "0";
        this.method_12();
      }
    }

    public LayerFlags Flags
    {
      get
      {
        return this.layerFlags_0;
      }
      set
      {
        this.layerFlags_0 = value;
      }
    }

    public bool Frozen
    {
      get
      {
        return (this.layerFlags_0 & LayerFlags.Frozen) != LayerFlags.None;
      }
      set
      {
        if (value)
          this.layerFlags_0 |= LayerFlags.Frozen;
        else
          this.layerFlags_0 &= ~LayerFlags.Frozen;
      }
    }

    public bool FrozenInNewViewport
    {
      get
      {
        return (this.layerFlags_0 & LayerFlags.FrozenInNewViewport) != LayerFlags.None;
      }
      set
      {
        if (value)
          this.layerFlags_0 |= LayerFlags.FrozenInNewViewport;
        else
          this.layerFlags_0 &= ~LayerFlags.FrozenInNewViewport;
      }
    }

    public bool Locked
    {
      get
      {
        return (this.layerFlags_0 & LayerFlags.Locked) != LayerFlags.None;
      }
      set
      {
        if (value)
          this.layerFlags_0 |= LayerFlags.Locked;
        else
          this.layerFlags_0 &= ~LayerFlags.Locked;
      }
    }

    public override bool IsExternallyDependent
    {
      get
      {
        return (this.layerFlags_0 & LayerFlags.IsExternallyDependent) != LayerFlags.None;
      }
      set
      {
        if (value)
          this.layerFlags_0 |= LayerFlags.IsExternallyDependent;
        else
          this.layerFlags_0 &= ~LayerFlags.IsExternallyDependent;
      }
    }

    public override bool IsResolvedExternalRef
    {
      get
      {
        return (this.layerFlags_0 & LayerFlags.IsResolvedExternalRef) != LayerFlags.None;
      }
      set
      {
        if (value)
          this.layerFlags_0 |= LayerFlags.IsResolvedExternalRef;
        else
          this.layerFlags_0 &= ~LayerFlags.IsResolvedExternalRef;
      }
    }

    public override bool IsReferenced
    {
      get
      {
        return (this.layerFlags_0 & LayerFlags.IsReferenced) != LayerFlags.None;
      }
      set
      {
        if (value)
          this.layerFlags_0 |= LayerFlags.IsReferenced;
        else
          this.layerFlags_0 &= ~LayerFlags.IsReferenced;
      }
    }

    public bool Enabled
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

    public Color Color
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
      }
    }

    public Transparency Transparency
    {
      get
      {
        return this.transparency_0;
      }
      set
      {
        this.transparency_0 = value;
      }
    }

    public DxfLineType LineType
    {
      get
      {
        return (DxfLineType) this.dxfObjectReference_3.Value;
      }
      set
      {
        this.dxfObjectReference_3 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public bool IsZeroLayer
    {
      get
      {
        return this.bool_2;
      }
    }

    public short LineWeight
    {
      get
      {
        return this.short_0;
      }
      set
      {
        this.short_0 = value;
      }
    }

    public bool PlotEnabled
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
        this.method_12();
      }
    }

    public override void Accept(ITableRecordVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      return ValidateUtil.ValidateName((object) this, this.string_9, model, messages);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfLayer dxfLayer = (DxfLayer) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfLayer == null)
      {
        dxfLayer = new DxfLayer();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfLayer);
        dxfLayer.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfLayer;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfLayer dxfLayer = (DxfLayer) from;
      this.string_9 = dxfLayer.string_9;
      this.layerFlags_0 = dxfLayer.layerFlags_0;
      this.bool_0 = dxfLayer.bool_0;
      this.color_0 = dxfLayer.color_0;
      this.transparency_0 = dxfLayer.transparency_0;
      this.LineType = Class906.GetLineType(cloneContext, dxfLayer.LineType);
      this.short_0 = dxfLayer.short_0;
      this.bool_1 = dxfLayer.bool_1;
      this.bool_2 = dxfLayer.bool_2;
      if (dxfLayer.Handle != 16UL)
        return;
      this.SetHandle(16UL);
    }

    public int CompareTo(object obj)
    {
      DxfLayer dxfLayer = obj as DxfLayer;
      if (dxfLayer == null)
        return 1;
      return this.string_9.CompareTo(dxfLayer.string_9);
    }

    public override string ToString()
    {
      return this.string_9;
    }

    public DxfLayer GetEffectiveLayer(DxfLayer insertLayer)
    {
      if (!this.IsZeroLayer)
        return this;
      return insertLayer;
    }

    public Color GetColor(DxfViewport viewport)
    {
      Color color;
      if (viewport != null && this.class905_0 != null && (this.class905_0.dictionary_0 != null && this.class905_0.dictionary_0.TryGetValue(viewport, out color)))
        return color;
      return this.color_0;
    }

    public Color? GetColorOverride(DxfViewport viewport)
    {
      Color color;
      if (viewport != null && this.class905_0 != null && (this.class905_0.dictionary_0 != null && this.class905_0.dictionary_0.TryGetValue(viewport, out color)))
        return new Color?(color);
      return new Color?();
    }

    public void SetColorOverride(DxfViewport viewport, Color? colorOverride)
    {
      if (viewport == null)
        return;
      if (colorOverride.HasValue)
      {
        this.ViewportLayerOverridesNotNull.ViewportColorOverridesNotNull[viewport] = colorOverride.Value;
      }
      else
      {
        if (this.class905_0 == null || this.class905_0.dictionary_0 == null || !this.class905_0.dictionary_0.ContainsKey(viewport))
          return;
        this.class905_0.dictionary_0.Remove(viewport);
        if (this.class905_0.dictionary_0.Count == 0)
          this.class905_0.dictionary_0 = (Dictionary<DxfViewport, Color>) null;
        this.method_11();
      }
    }

    public void RemoveColorOverrides()
    {
      if (this.class905_0 == null)
        return;
      this.class905_0.dictionary_0 = (Dictionary<DxfViewport, Color>) null;
    }

    public DxfLineType GetLineType(DxfViewport viewport)
    {
      DxfLineType dxfLineType;
      if (viewport != null && this.class905_0 != null && (this.class905_0.dictionary_1 != null && this.class905_0.dictionary_1.TryGetValue(viewport, out dxfLineType)))
        return dxfLineType;
      return this.LineType;
    }

    public DxfLineType GetLineTypeOverride(DxfViewport viewport)
    {
      DxfLineType dxfLineType;
      if (viewport != null && this.class905_0 != null && (this.class905_0.dictionary_1 != null && this.class905_0.dictionary_1.TryGetValue(viewport, out dxfLineType)))
        return dxfLineType;
      return (DxfLineType) null;
    }

    public void SetLineTypeOverride(DxfViewport viewport, DxfLineType lineTypeOverride)
    {
      if (viewport == null)
        return;
      if (lineTypeOverride != null)
      {
        this.ViewportLayerOverridesNotNull.ViewportLineTypeOverridesNotNull[viewport] = lineTypeOverride;
      }
      else
      {
        if (this.class905_0 == null || this.class905_0.dictionary_1 == null || !this.class905_0.dictionary_1.ContainsKey(viewport))
          return;
        this.class905_0.dictionary_1.Remove(viewport);
        if (this.class905_0.dictionary_1.Count == 0)
          this.class905_0.dictionary_1 = (Dictionary<DxfViewport, DxfLineType>) null;
        this.method_11();
      }
    }

    public void RemoveLineTypeOverrides()
    {
      if (this.class905_0 == null)
        return;
      this.class905_0.dictionary_1 = (Dictionary<DxfViewport, DxfLineType>) null;
    }

    public short GetLineWeight(DxfViewport viewport)
    {
      short num;
      if (viewport != null && this.class905_0 != null && (this.class905_0.dictionary_2 != null && this.class905_0.dictionary_2.TryGetValue(viewport, out num)))
        return num;
      return this.short_0;
    }

    public short? GetLineWeightOverride(DxfViewport viewport)
    {
      short num;
      if (viewport != null && this.class905_0 != null && (this.class905_0.dictionary_2 != null && this.class905_0.dictionary_2.TryGetValue(viewport, out num)))
        return new short?(num);
      return new short?();
    }

    public void SetLineWeightOverride(DxfViewport viewport, short? lineWeightOverride)
    {
      if (viewport == null)
        return;
      if (lineWeightOverride.HasValue)
      {
        this.ViewportLayerOverridesNotNull.ViewportLineWeightOverridesNotNull[viewport] = lineWeightOverride.Value;
      }
      else
      {
        if (this.class905_0 == null || this.class905_0.dictionary_2 == null || !this.class905_0.dictionary_2.ContainsKey(viewport))
          return;
        this.class905_0.dictionary_2.Remove(viewport);
        if (this.class905_0.dictionary_2.Count == 0)
          this.class905_0.dictionary_2 = (Dictionary<DxfViewport, short>) null;
        this.method_11();
      }
    }

    public void RemoveLineWeightOverrides()
    {
      if (this.class905_0 == null)
        return;
      this.class905_0.dictionary_2 = (Dictionary<DxfViewport, short>) null;
    }

    public Transparency GetTransparency(DxfViewport viewport)
    {
      Transparency transparency;
      if (viewport != null && this.class905_0 != null && (this.class905_0.dictionary_3 != null && this.class905_0.dictionary_3.TryGetValue(viewport, out transparency)))
        return transparency;
      return this.transparency_0;
    }

    public Transparency? GetTransparencyOverride(DxfViewport viewport)
    {
      Transparency transparency;
      if (viewport != null && this.class905_0 != null && (this.class905_0.dictionary_3 != null && this.class905_0.dictionary_3.TryGetValue(viewport, out transparency)))
        return new Transparency?(transparency);
      return new Transparency?();
    }

    public void SetColorOverride(DxfViewport viewport, Transparency? transparencyOverride)
    {
      if (viewport == null)
        return;
      if (transparencyOverride.HasValue)
      {
        this.ViewportLayerOverridesNotNull.ViewportTransparencyOverridesNotNull[viewport] = transparencyOverride.Value;
      }
      else
      {
        if (this.class905_0 == null || this.class905_0.dictionary_3 == null || !this.class905_0.dictionary_3.ContainsKey(viewport))
          return;
        this.class905_0.dictionary_3.Remove(viewport);
        if (this.class905_0.dictionary_3.Count == 0)
          this.class905_0.dictionary_3 = (Dictionary<DxfViewport, Transparency>) null;
        this.method_11();
      }
    }

    public void RemoveTransparencyOverrides()
    {
      if (this.class905_0 == null)
        return;
      this.class905_0.dictionary_3 = (Dictionary<DxfViewport, Transparency>) null;
    }

    public void RemoveViewportLayerOverrides()
    {
      this.class905_0 = (DxfLayer.Class905) null;
    }

    internal static DxfLayer smethod_2(DxfModel model, bool useFixedHandles)
    {
      DxfLayer dxfLayer = new DxfLayer();
      if (useFixedHandles)
        dxfLayer.SetHandle(16UL);
      dxfLayer.Name = "0";
      return dxfLayer;
    }

    internal static DxfLayer smethod_3()
    {
      DxfLayer dxfLayer = new DxfLayer();
      dxfLayer.Name = "DEFPOINTS";
      dxfLayer.bool_1 = false;
      return dxfLayer;
    }

    internal override void vmethod_3(DxfModel modelContext)
    {
      base.vmethod_3(modelContext);
      if (this.LineType == null)
        this.LineType = modelContext.ContinuousLineType;
      this.vmethod_2((IDxfHandledObject) modelContext.LayerTable);
    }

    internal override void vmethod_4(DxfModel modelContext)
    {
      base.vmethod_4(modelContext);
      this.LineType = (DxfLineType) null;
      this.vmethod_2((IDxfHandledObject) null);
    }

    internal short GetLineWeight(DxfViewport viewport, GraphicsConfig graphicsConfig)
    {
      short lineWeight = this.GetLineWeight(viewport);
      if (lineWeight < (short) 0)
        return graphicsConfig.DefaultLineWeight;
      return lineWeight;
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      if (this.transparency_0 == Transparency.Opaque)
      {
        if (this.HasExtendedData)
        {
          DxfAppId dxfAppId;
          if (!this.Model.AppIds.TryGetValue("AcCmTransparency", out dxfAppId))
          {
            dxfAppId = new DxfAppId("AcCmTransparency");
            this.Model.AppIds.Add(dxfAppId);
          }
          DxfExtendedData extendedData;
          if (this.ExtendedDataCollection.TryGetValue(dxfAppId, out extendedData))
          {
            if (extendedData.Values.Count == 0)
              this.ExtendedDataCollection.Remove(dxfAppId);
            else if (extendedData.Values.Count == 1)
            {
              if (extendedData.Values[0] is DxfExtendedData.Int32)
                this.ExtendedDataCollection.Remove(dxfAppId);
            }
            else
              this.method_10(extendedData);
          }
        }
      }
      else
      {
        DxfAppId appId;
        if (!this.Model.AppIds.TryGetValue("AcCmTransparency", out appId))
        {
          appId = new DxfAppId("AcCmTransparency");
          this.Model.AppIds.Add(appId);
        }
        DxfExtendedData extendedData;
        if (this.ExtendedDataCollection.TryGetValue(appId, out extendedData))
        {
          this.method_10(extendedData);
        }
        else
        {
          extendedData = new DxfExtendedData(appId);
          this.ExtendedDataCollection.Add(extendedData);
          extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Int32((int) this.transparency_0.Data));
        }
      }
      if (this.class905_0 != null)
      {
        if (this.class905_0.dictionary_0 != null && this.class905_0.dictionary_0.Count > 0)
        {
          DxfXRecord dxfXrecord = this.method_8("ADSK_XREC_LAYER_COLOR_OVR");
          foreach (KeyValuePair<DxfViewport, Color> keyValuePair in this.class905_0.dictionary_0)
          {
            dxfXrecord.Values.Add((short) 102, (object) "{ADSK_LYR_COLOR_OVERRIDE");
            dxfXrecord.Values.Add((short) 335, (object) keyValuePair.Key);
            dxfXrecord.Values.Add((short) 420, (object) (int) keyValuePair.Value.Data);
            dxfXrecord.Values.Add((short) 102, (object) "}");
          }
        }
        else
          this.method_9("ADSK_XREC_LAYER_COLOR_OVR");
        if (this.class905_0.dictionary_1 != null && this.class905_0.dictionary_1.Count > 0)
        {
          DxfXRecord dxfXrecord = this.method_8("ADSK_XREC_LAYER_LINETYPE_OVR");
          foreach (KeyValuePair<DxfViewport, DxfLineType> keyValuePair in this.class905_0.dictionary_1)
          {
            dxfXrecord.Values.Add((short) 102, (object) "{ADSK_LYR_LINETYPE_OVERRIDE");
            dxfXrecord.Values.Add((short) 335, (object) keyValuePair.Key);
            dxfXrecord.Values.Add((short) 343, (object) keyValuePair.Value);
            dxfXrecord.Values.Add((short) 102, (object) "}");
          }
        }
        else
          this.method_9("ADSK_XREC_LAYER_LINETYPE_OVR");
        if (this.class905_0.dictionary_2 != null && this.class905_0.dictionary_2.Count > 0)
        {
          DxfXRecord dxfXrecord = this.method_8("ADSK_XREC_LAYER_LINEWT_OVR");
          foreach (KeyValuePair<DxfViewport, short> keyValuePair in this.class905_0.dictionary_2)
          {
            dxfXrecord.Values.Add((short) 102, (object) "{ADSK_LYR_LINEWT_OVERRIDE");
            dxfXrecord.Values.Add((short) 335, (object) keyValuePair.Key);
            dxfXrecord.Values.Add((short) 91, (object) (int) keyValuePair.Value);
            dxfXrecord.Values.Add((short) 102, (object) "}");
          }
        }
        else
          this.method_9("ADSK_XREC_LAYER_LINEWT_OVR");
        if (this.class905_0.dictionary_3 != null && this.class905_0.dictionary_3.Count > 0)
        {
          DxfXRecord dxfXrecord = this.method_8("ADSK_XREC_LAYER_ALPHA_OVR");
          foreach (KeyValuePair<DxfViewport, Transparency> keyValuePair in this.class905_0.dictionary_3)
          {
            dxfXrecord.Values.Add((short) 102, (object) "{ADSK_LYR_ALPHA_OVERRIDE");
            dxfXrecord.Values.Add((short) 335, (object) keyValuePair.Key);
            dxfXrecord.Values.Add((short) 440, (object) (int) keyValuePair.Value.Data);
            dxfXrecord.Values.Add((short) 102, (object) "}");
          }
        }
        else
          this.method_9("ADSK_XREC_LAYER_ALPHA_OVR");
      }
      else
      {
        if (this.ExtensionDictionary == null)
          return;
        this.method_9("ADSK_XREC_LAYER_COLOR_OVR");
        this.method_9("ADSK_XREC_LAYER_LINETYPE_OVR");
        this.method_9("ADSK_XREC_LAYER_LINEWT_OVR");
        this.method_9("ADSK_XREC_LAYER_ALPHA_OVR");
        if (this.ExtensionDictionary.Entries.Count != 0)
          return;
        this.ExtensionDictionary = (DxfDictionary) null;
      }
    }

    private DxfXRecord method_8(string recordName)
    {
      DxfXRecord dxfXrecord = this.ExtensionDictionaryNotNull.GetValueByName(recordName) as DxfXRecord;
      if (dxfXrecord == null)
      {
        dxfXrecord = new DxfXRecord();
        this.ExtensionDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("ADSK_XREC_LAYER_COLOR_OVR", (DxfObject) dxfXrecord));
      }
      else
        dxfXrecord.Values.Clear();
      return dxfXrecord;
    }

    private void method_9(string recordName)
    {
      if (this.ExtensionDictionary == null)
        return;
      this.ExtensionDictionary.Entries.RemoveAll(recordName);
    }

    private DxfDictionary ExtensionDictionaryNotNull
    {
      get
      {
        if (this.ExtensionDictionary == null)
          this.ExtensionDictionary = new DxfDictionary();
        return this.ExtensionDictionary;
      }
    }

    private void method_10(DxfExtendedData extendedData)
    {
      IEnumerator<IExtendedDataValue> enumerator = (IEnumerator<IExtendedDataValue>) new DxfExtendedData.RecursiveEnumerator((IEnumerator<IExtendedDataValue>) extendedData.Values.GetEnumerator());
      DxfExtendedData.Int32 int32 = (DxfExtendedData.Int32) null;
      while (enumerator.MoveNext())
      {
        int32 = enumerator.Current as DxfExtendedData.Int32;
        if (int32 != null)
          break;
      }
      if (int32 == null)
      {
        int32 = new DxfExtendedData.Int32();
        extendedData.Values.Add((IExtendedDataValue) int32);
      }
      int32.Value = (int) this.transparency_0.Data;
    }

    internal override void vmethod_10(DxfModel model)
    {
      base.vmethod_10(model);
      DxfExtendedData extendedData;
      if (this.HasExtendedData && this.ExtendedDataCollection.TryGetValue(this.Model, "AcCmTransparency", out extendedData))
      {
        IEnumerator<IExtendedDataValue> enumerator = (IEnumerator<IExtendedDataValue>) new DxfExtendedData.RecursiveEnumerator((IEnumerator<IExtendedDataValue>) extendedData.Values.GetEnumerator());
        while (enumerator.MoveNext())
        {
          DxfExtendedData.Int32 current = enumerator.Current as DxfExtendedData.Int32;
          if (current != null)
          {
            this.transparency_0 = new Transparency((uint) current.Value);
            if (this.transparency_0.TransparencyType != TransparencyType.ByValue)
            {
              this.transparency_0 = Transparency.Opaque;
              break;
            }
            break;
          }
        }
      }
      if (this.ExtensionDictionary == null)
        return;
      DxfXRecord valueByName1 = this.ExtensionDictionary.GetValueByName("ADSK_XREC_LAYER_COLOR_OVR") as DxfXRecord;
      if (valueByName1 != null)
      {
        List<DxfXRecordValue>.Enumerator enumerator = valueByName1.Values.GetEnumerator();
        while (enumerator.MoveNext())
        {
          if (enumerator.Current.Code == (short) 102 && enumerator.Current.Value as string == "{ADSK_LYR_COLOR_OVERRIDE")
          {
            DxfViewport key = (DxfViewport) null;
            uint? nullable = new uint?();
            while (enumerator.MoveNext() && (enumerator.Current.Code != (short) 102 || !(enumerator.Current.Value as string == "}")))
            {
              switch (enumerator.Current.Code)
              {
                case 335:
                  key = enumerator.Current.Value as DxfViewport;
                  continue;
                case 420:
                  nullable = new uint?((uint) Convert.ToInt32(enumerator.Current.Value));
                  continue;
                default:
                  continue;
              }
            }
            if (key != null && nullable.HasValue)
              this.ViewportLayerOverridesNotNull.ViewportColorOverridesNotNull.Add(key, Color.smethod_0(nullable.Value));
          }
        }
      }
      DxfXRecord valueByName2 = this.ExtensionDictionary.GetValueByName("ADSK_XREC_LAYER_LINETYPE_OVR") as DxfXRecord;
      if (valueByName2 != null)
      {
        List<DxfXRecordValue>.Enumerator enumerator = valueByName2.Values.GetEnumerator();
        while (enumerator.MoveNext())
        {
          if (enumerator.Current.Code == (short) 102 && enumerator.Current.Value as string == "{ADSK_LYR_LINETYPE_OVERRIDE")
          {
            DxfViewport key = (DxfViewport) null;
            DxfLineType dxfLineType = (DxfLineType) null;
            while (enumerator.MoveNext() && (enumerator.Current.Code != (short) 102 || !(enumerator.Current.Value as string == "}")))
            {
              switch (enumerator.Current.Code)
              {
                case 335:
                  key = enumerator.Current.Value as DxfViewport;
                  continue;
                case 343:
                  dxfLineType = enumerator.Current.Value as DxfLineType;
                  continue;
                default:
                  continue;
              }
            }
            if (key != null && dxfLineType != null)
              this.ViewportLayerOverridesNotNull.ViewportLineTypeOverridesNotNull.Add(key, dxfLineType);
          }
        }
      }
      DxfXRecord valueByName3 = this.ExtensionDictionary.GetValueByName("ADSK_XREC_LAYER_LINEWT_OVR") as DxfXRecord;
      if (valueByName3 != null)
      {
        List<DxfXRecordValue>.Enumerator enumerator = valueByName3.Values.GetEnumerator();
        while (enumerator.MoveNext())
        {
          if (enumerator.Current.Code == (short) 102 && enumerator.Current.Value as string == "{ADSK_LYR_LINEWT_OVERRIDE")
          {
            DxfViewport key = (DxfViewport) null;
            short? nullable = new short?();
            while (enumerator.MoveNext() && (enumerator.Current.Code != (short) 102 || !(enumerator.Current.Value as string == "}")))
            {
              switch (enumerator.Current.Code)
              {
                case 91:
                  nullable = new short?(Convert.ToInt16(enumerator.Current.Value));
                  continue;
                case 335:
                  key = enumerator.Current.Value as DxfViewport;
                  continue;
                default:
                  continue;
              }
            }
            if (key != null && nullable.HasValue)
              this.ViewportLayerOverridesNotNull.ViewportLineWeightOverridesNotNull.Add(key, nullable.Value);
          }
        }
      }
      DxfXRecord valueByName4 = this.ExtensionDictionary.GetValueByName("ADSK_XREC_LAYER_ALPHA_OVR") as DxfXRecord;
      if (valueByName4 == null)
        return;
      List<DxfXRecordValue>.Enumerator enumerator1 = valueByName4.Values.GetEnumerator();
      while (enumerator1.MoveNext())
      {
        if (enumerator1.Current.Code == (short) 102 && enumerator1.Current.Value as string == "{ADSK_LYR_ALPHA_OVERRIDE")
        {
          DxfViewport key = (DxfViewport) null;
          uint? nullable = new uint?();
          while (enumerator1.MoveNext() && (enumerator1.Current.Code != (short) 102 || !(enumerator1.Current.Value as string == "}")))
          {
            switch (enumerator1.Current.Code)
            {
              case 335:
                key = enumerator1.Current.Value as DxfViewport;
                continue;
              case 440:
                nullable = new uint?((uint) Convert.ToInt32(enumerator1.Current.Value));
                continue;
              default:
                continue;
            }
          }
          if (key != null && nullable.HasValue)
            this.ViewportLayerOverridesNotNull.ViewportTransparencyOverridesNotNull.Add(key, new Transparency(nullable.Value));
        }
      }
    }

    private DxfLayer.Class905 ViewportLayerOverridesNotNull
    {
      get
      {
        if (this.class905_0 == null)
          this.class905_0 = new DxfLayer.Class905();
        return this.class905_0;
      }
    }

    private void method_11()
    {
      if (this.class905_0 == null || this.class905_0.HasOverrides)
        return;
      this.class905_0 = (DxfLayer.Class905) null;
    }

    private void method_12()
    {
      if (string.Compare("DEFPOINTS", this.string_9, StringComparison.InvariantCultureIgnoreCase) != 0)
        return;
      this.bool_1 = false;
    }

    private class Class904 : IComparer<DxfLayer>
    {
      public int Compare(DxfLayer x, DxfLayer y)
      {
        return string.Compare(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase);
      }
    }

    private class Class905
    {
      public Dictionary<DxfViewport, Color> dictionary_0;
      public Dictionary<DxfViewport, DxfLineType> dictionary_1;
      public Dictionary<DxfViewport, short> dictionary_2;
      public Dictionary<DxfViewport, Transparency> dictionary_3;

      public Dictionary<DxfViewport, Color> ViewportColorOverridesNotNull
      {
        get
        {
          if (this.dictionary_0 == null)
            this.dictionary_0 = new Dictionary<DxfViewport, Color>();
          return this.dictionary_0;
        }
      }

      public Dictionary<DxfViewport, DxfLineType> ViewportLineTypeOverridesNotNull
      {
        get
        {
          if (this.dictionary_1 == null)
            this.dictionary_1 = new Dictionary<DxfViewport, DxfLineType>();
          return this.dictionary_1;
        }
      }

      public Dictionary<DxfViewport, short> ViewportLineWeightOverridesNotNull
      {
        get
        {
          if (this.dictionary_2 == null)
            this.dictionary_2 = new Dictionary<DxfViewport, short>();
          return this.dictionary_2;
        }
      }

      public Dictionary<DxfViewport, Transparency> ViewportTransparencyOverridesNotNull
      {
        get
        {
          if (this.dictionary_3 == null)
            this.dictionary_3 = new Dictionary<DxfViewport, Transparency>();
          return this.dictionary_3;
        }
      }

      public bool HasOverrides
      {
        get
        {
          if (this.dictionary_0 == null && this.dictionary_1 == null && this.dictionary_2 == null)
            return this.dictionary_3 != null;
          return true;
        }
      }
    }
  }
}
