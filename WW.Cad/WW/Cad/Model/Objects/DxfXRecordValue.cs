// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfXRecordValue
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System;

namespace WW.Cad.Model.Objects
{
  public class DxfXRecordValue : IGraphCloneable
  {
    private short short_0;
    private object object_0;

    public DxfXRecordValue()
    {
    }

    public DxfXRecordValue(short code, object value)
    {
      this.method_1(code, value);
      this.short_0 = code;
      this.Value = value;
    }

    public short Code
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

    public object Value
    {
      get
      {
        DxfObjectReference object0 = this.object_0 as DxfObjectReference;
        if (object0 != null)
          return (object) object0.Value;
        return this.object_0;
      }
      set
      {
        this.method_1(this.short_0, value);
        DxfHandledObject dxfHandledObject = value as DxfHandledObject;
        this.object_0 = dxfHandledObject == null ? value : (object) dxfHandledObject.Reference;
      }
    }

    public override string ToString()
    {
      string str = "Code: " + this.short_0.ToString() + ", value: " + (this.Value == null ? "null" : this.Value.ToString());
      if (this.Value != null)
        str = str + ", type: " + this.Value.GetType().FullName;
      return str;
    }

    internal Struct18[] method_0()
    {
      if (Class820.smethod_2((int) this.short_0) == Enum5.const_13)
      {
        WW.Math.Point3D object0 = (WW.Math.Point3D) this.object_0;
        return new Struct18[3]{ new Struct18((int) this.short_0, (object) object0.X), new Struct18((int) this.short_0 + 10, (object) object0.Y), new Struct18((int) this.short_0 + 20, (object) object0.Z) };
      }
      return new Struct18[1]{ new Struct18((int) this.short_0, this.Value) };
    }

    public IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfXRecordValue dxfXrecordValue = new DxfXRecordValue();
      dxfXrecordValue.short_0 = this.short_0;
      DxfHandledObject dxfHandledObject1 = this.Value as DxfHandledObject;
      if (dxfHandledObject1 == null)
      {
        dxfXrecordValue.Value = this.Value;
      }
      else
      {
        DxfHandledObject dxfHandledObject2 = (DxfHandledObject) dxfHandledObject1.Clone(cloneContext);
        dxfXrecordValue.object_0 = (object) dxfHandledObject2;
        switch (Class820.smethod_2((int) this.short_0))
        {
          case Enum5.const_5:
          case Enum5.const_7:
          case Enum5.const_8:
          case Enum5.const_15:
            cloneContext.method_0(dxfHandledObject2);
            break;
        }
      }
      return (IGraphCloneable) dxfXrecordValue;
    }

    private void method_1(short code, object value)
    {
      switch (Class820.smethod_2((int) code))
      {
        case Enum5.const_5:
        case Enum5.const_7:
        case Enum5.const_8:
        case Enum5.const_9:
        case Enum5.const_14:
        case Enum5.const_15:
          if (value == null || value is DxfHandledObject)
            break;
          throw new ArgumentException("Value should be a handled object for code " + (object) code + ".");
        case Enum5.const_18:
          if (value == null)
            break;
          throw new ArgumentException("Value must be null for code " + (object) code + ".");
        default:
          if (value != null)
            break;
          throw new ArgumentException("Value may not be null for code " + (object) code + ".");
      }
    }
  }
}
