// Decompiled with JetBrains decompiler
// Type: ns3.Class285
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class285 : Class259
  {
    private byte byte_0 = byte.MaxValue;
    private ulong ulong_2;
    private byte? nullable_0;
    private ulong ulong_3;
    private string string_0;
    private ulong? nullable_1;
    private ulong? nullable_2;
    private ulong ulong_4;
    private ulong ulong_5;
    private string string_1;

    public Class285(DxfEntity entity)
      : base((DxfHandledObject) entity)
    {
    }

    public DxfEntity Entity
    {
      get
      {
        return (DxfEntity) this.HandledObject;
      }
      set
      {
        this.HandledObject = (DxfHandledObject) value;
      }
    }

    public ulong LayerHandle
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

    public byte? LineTypeFlags
    {
      get
      {
        return this.nullable_0;
      }
      set
      {
        this.nullable_0 = value;
      }
    }

    public ulong LineTypeHandle
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

    public string LineTypeName
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

    public byte EntityMode
    {
      get
      {
        return this.byte_0;
      }
      set
      {
        this.byte_0 = value;
      }
    }

    public ulong? PreviousHandle
    {
      get
      {
        return this.nullable_1;
      }
      set
      {
        this.nullable_1 = value;
      }
    }

    public ulong? NextHandle
    {
      get
      {
        return this.nullable_2;
      }
      set
      {
        this.nullable_2 = value;
      }
    }

    public ulong ParentEntityRefHandle
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

    public ulong DxfColorHandle
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

    public string DxfColorConcatenatedName
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

    public ulong method_1()
    {
      if (this.nullable_2.HasValue)
        return this.nullable_2.Value;
      return this.HandledObject.Handle + 1UL;
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfEntity entity = this.Entity;
      if (this.ulong_2 != 0UL)
      {
        DxfLayer dxfLayer = modelBuilder.method_4<DxfLayer>(this.ulong_2);
        if (dxfLayer != null)
          entity.Layer = dxfLayer;
      }
      if (this.nullable_0.HasValue)
      {
        byte? nullable0 = this.nullable_0;
        ref byte? local = ref nullable0;
        byte valueOrDefault = local.GetValueOrDefault();
        if (local.HasValue)
        {
          switch (valueOrDefault)
          {
            case 0:
              entity.LineType = modelBuilder.Model.ByLayerLineType;
              break;
            case 1:
              entity.LineType = modelBuilder.Model.ByBlockLineType;
              break;
            case 2:
              entity.LineType = modelBuilder.Model.ContinuousLineType;
              break;
            case 3:
              if (this.ulong_3 != 0UL)
              {
                DxfLineType dxfLineType = modelBuilder.method_4<DxfLineType>(this.ulong_3);
                if (dxfLineType != null)
                {
                  entity.LineType = dxfLineType;
                  break;
                }
                break;
              }
              break;
          }
        }
      }
      else if (this.ulong_3 != 0UL)
      {
        DxfLineType dxfLineType = modelBuilder.method_4<DxfLineType>(this.ulong_3);
        if (dxfLineType != null)
          entity.LineType = dxfLineType;
      }
      else if (!string.IsNullOrEmpty(this.string_0))
      {
        DxfLineType dxfLineType;
        if (modelBuilder.Model.LineTypes.TryGetValue(this.string_0, out dxfLineType))
          entity.LineType = dxfLineType;
      }
      else
        entity.LineType = modelBuilder.Model.ByLayerLineType;
      if (this.ulong_5 != 0UL)
      {
        DxfColor dxfColor = modelBuilder.method_4<DxfColor>(this.ulong_5);
        if (dxfColor == null)
          return;
        entity.DxfColor = dxfColor;
      }
      else
      {
        if (string.IsNullOrEmpty(this.string_1))
          return;
        string[] strArray = this.string_1.Split('$');
        if (strArray == null || strArray.Length != 2)
          return;
        string colorBookName = strArray[0];
        string colorName = strArray[1];
        DxfColor color = modelBuilder.Model.Colors.GetColor(colorBookName, colorName);
        if (color == null)
          return;
        entity.method_11(color);
      }
    }
  }
}
