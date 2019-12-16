// Decompiled with JetBrains decompiler
// Type: ns49.Class1064
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;
using WW.Cad.Model.Tables;

namespace ns49
{
  internal class Class1064
  {
    public const string string_0 = "AcadAnnotative";
    private bool bool_0;
    private bool bool_1;

    public bool Annotative
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

    public bool AnnotationAlwaysVisible
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

    public static bool smethod_0(DxfHandledObject o, DxfModel model)
    {
      DxfExtendedData.ValueCollection valueCollection = Class1064.smethod_4(o, model);
      if (valueCollection == null || valueCollection.Count < 1)
        return false;
      DxfExtendedData.Int16 int16 = valueCollection[0] as DxfExtendedData.Int16;
      if (int16 != null)
        return int16.Value != (short) 0;
      return false;
    }

    public static bool smethod_1(DxfHandledObject o, DxfModel model)
    {
      DxfExtendedData.ValueCollection valueCollection = Class1064.smethod_4(o, model);
      if (valueCollection == null || valueCollection.Count < 2)
        return false;
      DxfExtendedData.Int16 int16 = valueCollection[1] as DxfExtendedData.Int16;
      if (int16 != null)
        return int16.Value != (short) 0;
      return false;
    }

    public static bool smethod_2(DxfHandledObject o, DxfModel model)
    {
      DxfExtendedData.ValueCollection valueCollection = Class1064.smethod_4(o, model);
      if (valueCollection == null || valueCollection.Count < 2)
        return false;
      DxfExtendedData.Int16 int16_1 = valueCollection[0] as DxfExtendedData.Int16;
      if (int16_1 == null || int16_1.Value == (short) 0)
        return false;
      DxfExtendedData.Int16 int16_2 = valueCollection[1] as DxfExtendedData.Int16;
      return int16_2 != null && int16_2.Value != (short) 0;
    }

    public static Class1064 Get(DxfHandledObject o)
    {
      Class1064 class1064 = new Class1064();
      DxfExtendedData.ValueCollection valueCollection = Class1064.smethod_4(o, o.Model);
      if (valueCollection != null && valueCollection.Count > 0)
      {
        DxfExtendedData.Int16 int16_1 = valueCollection[0] as DxfExtendedData.Int16;
        if (int16_1 != null)
          class1064.bool_0 = int16_1.Value != (short) 0;
        if (valueCollection.Count > 1)
        {
          DxfExtendedData.Int16 int16_2 = valueCollection[1] as DxfExtendedData.Int16;
          if (int16_2 != null)
            class1064.bool_1 = int16_2.Value != (short) 0;
        }
      }
      return class1064;
    }

    public static void Set(DxfHandledObject o, Class1064 value)
    {
      if (value == null)
      {
        DxfAppId key;
        if (o.Model == null || !o.Model.AppIds.TryGetValue("AcadAnnotative", out key))
          return;
        o.ExtendedDataCollection.Remove(key);
      }
      else
      {
        DxfExtendedData extendedData;
        if (o.ExtendedDataCollection.TryGetValue(Class1064.smethod_3(o.Model), out extendedData))
        {
          DxfExtendedData.ValueCollection valueCollection;
          if (extendedData.Values.Count >= 2 && extendedData.Values[1] is DxfExtendedData.ValueCollection)
          {
            valueCollection = extendedData.Values[1] as DxfExtendedData.ValueCollection;
          }
          else
          {
            extendedData.Values.Clear();
            extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.String("AnnotativeData"));
            valueCollection = new DxfExtendedData.ValueCollection();
            extendedData.Values.Add((IExtendedDataValue) valueCollection);
          }
          valueCollection.Clear();
          valueCollection.Add((IExtendedDataValue) new DxfExtendedData.Int16(value.bool_0 ? (short) 1 : (short) 0));
          valueCollection.Add((IExtendedDataValue) new DxfExtendedData.Int16(value.bool_1 ? (short) 1 : (short) 0));
        }
        else
        {
          DxfExtendedData dxfExtendedData = new DxfExtendedData(Class1064.smethod_3(o.Model));
          dxfExtendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.String("AnnotativeData"));
          DxfExtendedData.ValueCollection valueCollection = new DxfExtendedData.ValueCollection();
          dxfExtendedData.Values.Add((IExtendedDataValue) valueCollection);
          valueCollection.Add((IExtendedDataValue) new DxfExtendedData.Int16(value.bool_0 ? (short) 1 : (short) 0));
          valueCollection.Add((IExtendedDataValue) new DxfExtendedData.Int16(value.bool_1 ? (short) 1 : (short) 0));
          o.ExtendedDataCollection.Add(dxfExtendedData);
        }
      }
    }

    internal static DxfAppId smethod_3(DxfModel model)
    {
      DxfAppId dxfAppId;
      if (!model.AppIds.TryGetValue("AcadAnnotative", out dxfAppId))
      {
        dxfAppId = new DxfAppId("AcadAnnotative");
        model.AppIds.Add(dxfAppId);
      }
      return dxfAppId;
    }

    public static DxfExtendedData.ValueCollection smethod_4(
      DxfHandledObject o,
      DxfModel model)
    {
      if (!o.HasExtendedData)
        return (DxfExtendedData.ValueCollection) null;
      DxfAppId appId;
      if (model == null || !model.AppIds.TryGetValue("AcadAnnotative", out appId))
        return (DxfExtendedData.ValueCollection) null;
      DxfExtendedData extendedData;
      if (!o.ExtendedDataCollection.TryGetValue(appId, out extendedData))
        return (DxfExtendedData.ValueCollection) null;
      DxfExtendedData.ValueCollection valueCollection = (DxfExtendedData.ValueCollection) null;
      if (extendedData.Values.Count > 1)
        valueCollection = extendedData.Values[1] as DxfExtendedData.ValueCollection;
      return valueCollection;
    }
  }
}
