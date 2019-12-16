// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.DxfExtendedData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns2;
using ns3;
using System;
using System.Collections;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model.Tables;
using WW.Math;

namespace WW.Cad.Model
{
  [Serializable]
  public class DxfExtendedData
  {
    private DxfObjectReference appIdRef = DxfObjectReference.Null;
    private readonly DxfExtendedData.ValueCollection values;

    public DxfExtendedData()
      : this((DxfAppId) null)
    {
    }

    public DxfExtendedData(DxfAppId appId)
      : this(appId, new DxfExtendedData.ValueCollection())
    {
    }

    internal DxfExtendedData(DxfAppId appId, DxfExtendedData.ValueCollection values)
    {
      this.AppId = appId;
      this.values = values;
    }

    public DxfAppId AppId
    {
      get
      {
        return (DxfAppId) this.appIdRef.Value;
      }
      set
      {
        this.appIdRef = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfExtendedData.ValueCollection Values
    {
      get
      {
        return this.values;
      }
    }

    public DxfExtendedData Clone(CloneContext cloneContext)
    {
      return new DxfExtendedData(Class906.smethod_3(cloneContext, this.AppId), (DxfExtendedData.ValueCollection) this.values.Clone(cloneContext));
    }

    public override string ToString()
    {
      return string.Format("App ID: {0}", this.appIdRef.Value == null ? (object) "null" : (object) this.AppId.Name);
    }

    public class String : IExtendedDataValue
    {
      private string string_0;

      public String()
      {
      }

      public String(string value)
      {
        this.string_0 = value;
      }

      public string Value
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

      public object ValueObject
      {
        get
        {
          return (object) this.string_0;
        }
      }

      public override string ToString()
      {
        return this.string_0;
      }

      public void Accept(IExtendedDataValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public IExtendedDataValue Clone(CloneContext cloneContext)
      {
        return (IExtendedDataValue) new DxfExtendedData.String(this.string_0);
      }
    }

    public class Bracket : IExtendedDataValue
    {
      private bool bool_0;

      public Bracket()
      {
      }

      public Bracket(bool isClosingBracket)
      {
        this.bool_0 = isClosingBracket;
      }

      public bool IsClosingBracket
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

      public object ValueObject
      {
        get
        {
          if (!this.bool_0)
            return (object) "{";
          return (object) "}";
        }
      }

      public override string ToString()
      {
        return !this.bool_0 ? "{" : "}";
      }

      public void Accept(IExtendedDataValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public IExtendedDataValue Clone(CloneContext cloneContext)
      {
        return (IExtendedDataValue) new DxfExtendedData.Bracket(this.bool_0);
      }
    }

    public class LayerReference : IExtendedDataValue
    {
      private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;

      public LayerReference()
      {
      }

      public LayerReference(DxfLayer value)
      {
        this.Value = value;
      }

      public DxfLayer Value
      {
        get
        {
          return (DxfLayer) this.dxfObjectReference_0.Value;
        }
        set
        {
          this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        }
      }

      public object ValueObject
      {
        get
        {
          return (object) this.Value;
        }
      }

      public override string ToString()
      {
        if (this.Value != null)
          return this.Value.Name;
        return string.Empty;
      }

      public void Accept(IExtendedDataValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public IExtendedDataValue Clone(CloneContext cloneContext)
      {
        return (IExtendedDataValue) new DxfExtendedData.LayerReference(this.Value != null ? (DxfLayer) this.Value.Clone(cloneContext) : (DxfLayer) null);
      }
    }

    public class BinaryData : IExtendedDataValue
    {
      private byte[] byte_0;

      public BinaryData()
      {
      }

      public BinaryData(byte[] value)
      {
        this.byte_0 = value;
      }

      public byte[] Value
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

      public object ValueObject
      {
        get
        {
          return (object) this.byte_0;
        }
      }

      public override string ToString()
      {
        if (this.byte_0 != null)
          return this.byte_0.ToString();
        return "null";
      }

      public void Accept(IExtendedDataValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public IExtendedDataValue Clone(CloneContext cloneContext)
      {
        return (IExtendedDataValue) new DxfExtendedData.BinaryData(this.byte_0 != null ? (byte[]) this.byte_0.Clone() : (byte[]) null);
      }
    }

    public class DatabaseHandle : IExtendedDataValue
    {
      private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;

      public DatabaseHandle()
      {
      }

      public DatabaseHandle(DxfHandledObject value)
      {
        this.Value = value;
      }

      public DxfHandledObject Value
      {
        get
        {
          return (DxfHandledObject) this.dxfObjectReference_0.Value;
        }
        set
        {
          this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        }
      }

      public object ValueObject
      {
        get
        {
          return (object) this.Value;
        }
      }

      public override string ToString()
      {
        return this.Value.ToString();
      }

      public void Accept(IExtendedDataValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public IExtendedDataValue Clone(CloneContext cloneContext)
      {
        DxfHandledObject dxfHandledObject = (DxfHandledObject) cloneContext.GetExistingClone((IGraphCloneable) this.Value);
        if (dxfHandledObject == null)
        {
          ITableRecord tableRecord = this.Value as ITableRecord;
          if (tableRecord == null)
          {
            dxfHandledObject = (DxfHandledObject) cloneContext.Clone((IGraphCloneable) this.Value);
            cloneContext.method_0(dxfHandledObject);
          }
          else
            dxfHandledObject = cloneContext.CloneTableRecord(tableRecord);
        }
        return (IExtendedDataValue) new DxfExtendedData.DatabaseHandle(dxfHandledObject);
      }
    }

    public class PointOrVector : IExtendedDataValue
    {
      private double double_0;
      private double double_1;
      private double double_2;

      public PointOrVector()
      {
      }

      public PointOrVector(double x, double y, double z)
      {
        this.double_0 = x;
        this.double_1 = y;
        this.double_2 = z;
      }

      public double X
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

      public double Y
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

      public double Z
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

      public object ValueObject
      {
        get
        {
          return (object) new WW.Math.Point3D(this.double_0, this.double_1, this.double_2);
        }
      }

      public WW.Math.Point3D GetPoint3D()
      {
        return new WW.Math.Point3D(this.double_0, this.double_1, this.double_2);
      }

      public Vector3D GetVector3D()
      {
        return new Vector3D(this.double_0, this.double_1, this.double_2);
      }

      public override string ToString()
      {
        return string.Format("{0}, {1}, {2}", (object) this.double_0, (object) this.double_1, (object) this.double_2);
      }

      public void Accept(IExtendedDataValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public IExtendedDataValue Clone(CloneContext cloneContext)
      {
        return (IExtendedDataValue) new DxfExtendedData.PointOrVector(this.double_0, this.double_1, this.double_2);
      }
    }

    public class WorldSpacePosition : IExtendedDataValue
    {
      private double double_0;
      private double double_1;
      private double double_2;

      public WorldSpacePosition()
      {
      }

      public WorldSpacePosition(double x, double y, double z)
      {
        this.double_0 = x;
        this.double_1 = y;
        this.double_2 = z;
      }

      public double X
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

      public double Y
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

      public double Z
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

      public object ValueObject
      {
        get
        {
          return (object) new WW.Math.Point3D(this.double_0, this.double_1, this.double_2);
        }
      }

      public WW.Math.Point3D GetPoint3D()
      {
        return new WW.Math.Point3D(this.double_0, this.double_1, this.double_2);
      }

      public Vector3D GetVector3D()
      {
        return new Vector3D(this.double_0, this.double_1, this.double_2);
      }

      public override string ToString()
      {
        return string.Format("{0}, {1}, {2}", (object) this.double_0, (object) this.double_1, (object) this.double_2);
      }

      public void Accept(IExtendedDataValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public IExtendedDataValue Clone(CloneContext cloneContext)
      {
        return (IExtendedDataValue) new DxfExtendedData.WorldSpacePosition(this.double_0, this.double_1, this.double_2);
      }
    }

    public class WorldSpaceDisplacement : IExtendedDataValue
    {
      private double double_0;
      private double double_1;
      private double double_2;

      public WorldSpaceDisplacement()
      {
      }

      public WorldSpaceDisplacement(double x, double y, double z)
      {
        this.double_0 = x;
        this.double_1 = y;
        this.double_2 = z;
      }

      public double X
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

      public double Y
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

      public double Z
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

      public object ValueObject
      {
        get
        {
          return (object) new WW.Math.Point3D(this.double_0, this.double_1, this.double_2);
        }
      }

      public WW.Math.Point3D GetPoint3D()
      {
        return new WW.Math.Point3D(this.double_0, this.double_1, this.double_2);
      }

      public Vector3D GetVector3D()
      {
        return new Vector3D(this.double_0, this.double_1, this.double_2);
      }

      public override string ToString()
      {
        return string.Format("{0}, {1}, {2}", (object) this.double_0, (object) this.double_1, (object) this.double_2);
      }

      public void Accept(IExtendedDataValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public IExtendedDataValue Clone(CloneContext cloneContext)
      {
        return (IExtendedDataValue) new DxfExtendedData.WorldSpaceDisplacement(this.double_0, this.double_1, this.double_2);
      }
    }

    public class WorldDirection : IExtendedDataValue
    {
      private double double_0;
      private double double_1;
      private double double_2;

      public WorldDirection()
      {
      }

      public WorldDirection(double x, double y, double z)
      {
        this.double_0 = x;
        this.double_1 = y;
        this.double_2 = z;
      }

      public double X
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

      public double Y
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

      public double Z
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

      public object ValueObject
      {
        get
        {
          return (object) new Vector3D(this.double_0, this.double_1, this.double_2);
        }
      }

      public WW.Math.Point3D GetPoint3D()
      {
        return new WW.Math.Point3D(this.double_0, this.double_1, this.double_2);
      }

      public Vector3D GetVector3D()
      {
        return new Vector3D(this.double_0, this.double_1, this.double_2);
      }

      public override string ToString()
      {
        return string.Format("{0}, {1}, {2}", (object) this.double_0, (object) this.double_1, (object) this.double_2);
      }

      public void Accept(IExtendedDataValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public IExtendedDataValue Clone(CloneContext cloneContext)
      {
        return (IExtendedDataValue) new DxfExtendedData.WorldDirection(this.double_0, this.double_1, this.double_2);
      }
    }

    public class Double : IExtendedDataValue
    {
      private double double_0;

      public Double()
      {
      }

      public Double(double value)
      {
        this.double_0 = value;
      }

      public double Value
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

      public object ValueObject
      {
        get
        {
          return (object) this.double_0;
        }
      }

      public override string ToString()
      {
        return this.double_0.ToString();
      }

      public virtual void Accept(IExtendedDataValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public virtual IExtendedDataValue Clone(CloneContext cloneContext)
      {
        return (IExtendedDataValue) new DxfExtendedData.Double(this.double_0);
      }
    }

    public class Distance : DxfExtendedData.Double
    {
      public Distance()
      {
      }

      public Distance(double value)
        : base(value)
      {
      }

      public override void Accept(IExtendedDataValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override IExtendedDataValue Clone(CloneContext cloneContext)
      {
        return (IExtendedDataValue) new DxfExtendedData.Distance(this.Value);
      }
    }

    public class ScaleFactor : DxfExtendedData.Double
    {
      public ScaleFactor()
      {
      }

      public ScaleFactor(double value)
        : base(value)
      {
      }

      public override void Accept(IExtendedDataValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override IExtendedDataValue Clone(CloneContext cloneContext)
      {
        return (IExtendedDataValue) new DxfExtendedData.ScaleFactor(this.Value);
      }
    }

    public class Int16 : IExtendedDataValue
    {
      private short short_0;

      public Int16()
      {
      }

      public Int16(short value)
      {
        this.short_0 = value;
      }

      public short Value
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

      public object ValueObject
      {
        get
        {
          return (object) this.short_0;
        }
      }

      public override string ToString()
      {
        return this.short_0.ToString();
      }

      public void Accept(IExtendedDataValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public IExtendedDataValue Clone(CloneContext cloneContext)
      {
        return (IExtendedDataValue) new DxfExtendedData.Int16(this.short_0);
      }
    }

    public class Int32 : IExtendedDataValue
    {
      private int int_0;

      public Int32()
      {
      }

      public Int32(int value)
      {
        this.int_0 = value;
      }

      public int Value
      {
        get
        {
          return this.int_0;
        }
        set
        {
          this.int_0 = value;
        }
      }

      public object ValueObject
      {
        get
        {
          return (object) this.int_0;
        }
      }

      public override string ToString()
      {
        return this.int_0.ToString();
      }

      public void Accept(IExtendedDataValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public IExtendedDataValue Clone(CloneContext cloneContext)
      {
        return (IExtendedDataValue) new DxfExtendedData.Int32(this.int_0);
      }
    }

    public class ValueCollection : List<IExtendedDataValue>, IExtendedDataValue
    {
      public ValueCollection()
      {
      }

      public ValueCollection(IEnumerable<IExtendedDataValue> collection)
        : base(collection)
      {
      }

      public ValueCollection(int capacity)
        : base(capacity)
      {
      }

      internal void method_0(DxfExtendedData.ValueCollection debracketized, ref int i)
      {
        while (i < this.Count)
        {
          IExtendedDataValue extendedDataValue = this[i];
          DxfExtendedData.Bracket bracket = extendedDataValue as DxfExtendedData.Bracket;
          if (bracket == null)
          {
            debracketized.Add(extendedDataValue);
          }
          else
          {
            if (bracket.IsClosingBracket)
              break;
            DxfExtendedData.ValueCollection debracketized1 = new DxfExtendedData.ValueCollection();
            ++i;
            this.method_0(debracketized1, ref i);
            debracketized.Add((IExtendedDataValue) debracketized1);
          }
          ++i;
        }
      }

      public void Accept(IExtendedDataValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public IExtendedDataValue Clone(CloneContext cloneContext)
      {
        DxfExtendedData.ValueCollection valueCollection = new DxfExtendedData.ValueCollection();
        foreach (IExtendedDataValue extendedDataValue in (List<IExtendedDataValue>) this)
          valueCollection.Add(extendedDataValue.Clone(cloneContext));
        return (IExtendedDataValue) valueCollection;
      }

      public object ValueObject
      {
        get
        {
          return (object) null;
        }
      }

      internal static DxfExtendedData.ValueCollection Read(
        Class259 objectBuilder,
        DxfReader r)
      {
        DxfExtendedData.ValueCollection valueCollection1 = new DxfExtendedData.ValueCollection();
        r.method_85();
        bool flag1 = false;
        bool flag2 = true;
        int num1 = -1;
        bool flag3 = false;
        while (!flag1)
        {
          Struct18 currentGroup = r.CurrentGroup;
          switch (currentGroup.Code)
          {
            case 1000:
              valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.String((string) r.CurrentGroup.Value));
              r.method_85();
              continue;
            case 1002:
              if ((string) r.CurrentGroup.Value == "{")
              {
                if (flag2)
                {
                  flag3 = true;
                  ++num1;
                }
                valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Bracket(false));
              }
              else
              {
                if (!((string) r.CurrentGroup.Value == "}"))
                  throw new DxfException("Expected '{' or '}', found " + r.CurrentGroup.Value.ToString() + " instead.");
                if (flag2)
                {
                  if (num1 < 0)
                    flag2 = false;
                  --num1;
                }
                valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.Bracket(true));
              }
              r.method_85();
              continue;
            case 1003:
              valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.LayerReference(r.Model.GetLayerWithName((string) r.CurrentGroup.Value)));
              r.method_85();
              continue;
            case 1004:
              List<byte> byteList = new List<byte>();
              byteList.AddRange((IEnumerable<byte>) (byte[]) r.CurrentGroup.Value);
              r.method_85();
              while (r.CurrentGroup.Code == 1004)
              {
                byteList.AddRange((IEnumerable<byte>) (byte[]) r.CurrentGroup.Value);
                r.method_85();
              }
              valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.BinaryData(byteList.ToArray()));
              continue;
            case 1005:
              ulong num2 = (ulong) r.CurrentGroup.Value;
              DxfExtendedData.DatabaseHandle xdataDatabaseHandle = new DxfExtendedData.DatabaseHandle();
              valueCollection1.Add((IExtendedDataValue) xdataDatabaseHandle);
              objectBuilder.ChildBuilders.Add((Interface10) new Class618(xdataDatabaseHandle)
              {
                DatabaseHandle = num2
              });
              r.method_85();
              continue;
            case 1010:
              double x1 = (double) r.CurrentGroup.Value;
              r.method_85();
              double y1 = (double) r.CurrentGroup.Value;
              r.method_85();
              double z1 = (double) r.CurrentGroup.Value;
              valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.PointOrVector(x1, y1, z1));
              r.method_85();
              continue;
            case 1011:
              double x2 = (double) r.CurrentGroup.Value;
              r.method_85();
              double y2 = (double) r.CurrentGroup.Value;
              r.method_85();
              double z2 = (double) r.CurrentGroup.Value;
              valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.WorldSpacePosition(x2, y2, z2));
              r.method_85();
              continue;
            case 1012:
              double x3 = (double) r.CurrentGroup.Value;
              r.method_85();
              double y3 = (double) r.CurrentGroup.Value;
              r.method_85();
              double z3 = (double) r.CurrentGroup.Value;
              valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.WorldSpaceDisplacement(x3, y3, z3));
              r.method_85();
              continue;
            case 1013:
              currentGroup = r.CurrentGroup;
              double x4 = (double) currentGroup.Value;
              r.method_85();
              currentGroup = r.CurrentGroup;
              double y4 = (double) currentGroup.Value;
              r.method_85();
              currentGroup = r.CurrentGroup;
              double z4 = (double) currentGroup.Value;
              valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.WorldDirection(x4, y4, z4));
              r.method_85();
              continue;
            case 1020:
              double x5 = 0.0;
              double y5 = (double) r.CurrentGroup.Value;
              r.method_85();
              double z5 = (double) r.CurrentGroup.Value;
              valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.PointOrVector(x5, y5, z5));
              r.method_85();
              continue;
            case 1021:
              double x6 = 0.0;
              double y6 = (double) r.CurrentGroup.Value;
              r.method_85();
              double z6 = (double) r.CurrentGroup.Value;
              valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.WorldSpacePosition(x6, y6, z6));
              r.method_85();
              continue;
            case 1022:
              double x7 = 0.0;
              double y7 = (double) r.CurrentGroup.Value;
              r.method_85();
              double z7 = (double) r.CurrentGroup.Value;
              valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.WorldSpaceDisplacement(x7, y7, z7));
              r.method_85();
              continue;
            case 1023:
              double x8 = 0.0;
              currentGroup = r.CurrentGroup;
              double y8 = (double) currentGroup.Value;
              r.method_85();
              currentGroup = r.CurrentGroup;
              double z8 = (double) currentGroup.Value;
              valueCollection1.Add((IExtendedDataValue) new DxfExtendedData.WorldDirection(x8, y8, z8));
              r.method_85();
              continue;
            case 1040:
              DxfExtendedData.ValueCollection valueCollection2 = valueCollection1;
              currentGroup = r.CurrentGroup;
              DxfExtendedData.Double @double = new DxfExtendedData.Double((double) currentGroup.Value);
              valueCollection2.Add((IExtendedDataValue) @double);
              r.method_85();
              continue;
            case 1041:
              DxfExtendedData.ValueCollection valueCollection3 = valueCollection1;
              currentGroup = r.CurrentGroup;
              DxfExtendedData.Distance distance = new DxfExtendedData.Distance((double) currentGroup.Value);
              valueCollection3.Add((IExtendedDataValue) distance);
              r.method_85();
              continue;
            case 1042:
              DxfExtendedData.ValueCollection valueCollection4 = valueCollection1;
              currentGroup = r.CurrentGroup;
              DxfExtendedData.ScaleFactor scaleFactor = new DxfExtendedData.ScaleFactor((double) currentGroup.Value);
              valueCollection4.Add((IExtendedDataValue) scaleFactor);
              r.method_85();
              continue;
            case 1070:
              DxfExtendedData.ValueCollection valueCollection5 = valueCollection1;
              currentGroup = r.CurrentGroup;
              DxfExtendedData.Int16 int16 = new DxfExtendedData.Int16((short) currentGroup.Value);
              valueCollection5.Add((IExtendedDataValue) int16);
              r.method_85();
              continue;
            case 1071:
              DxfExtendedData.ValueCollection valueCollection6 = valueCollection1;
              currentGroup = r.CurrentGroup;
              DxfExtendedData.Int32 int32 = new DxfExtendedData.Int32((int) currentGroup.Value);
              valueCollection6.Add((IExtendedDataValue) int32);
              r.method_85();
              continue;
            default:
              flag1 = true;
              continue;
          }
        }
        if (flag3 && num1 == -1)
        {
          DxfExtendedData.ValueCollection debracketized = new DxfExtendedData.ValueCollection();
          int i = 0;
          valueCollection1.method_0(debracketized, ref i);
          valueCollection1 = debracketized;
        }
        return valueCollection1;
      }
    }

    public class RecursiveEnumerator : IDisposable, IEnumerator<IExtendedDataValue>, IEnumerator
    {
      private Stack<IEnumerator<IExtendedDataValue>> stack_0 = new Stack<IEnumerator<IExtendedDataValue>>();

      public RecursiveEnumerator(IEnumerator<IExtendedDataValue> rootEnumerator)
      {
        this.stack_0.Push(rootEnumerator);
      }

      public IExtendedDataValue Current
      {
        get
        {
          return this.stack_0.Peek().Current;
        }
      }

      public void Dispose()
      {
        this.stack_0 = (Stack<IEnumerator<IExtendedDataValue>>) null;
      }

      object IEnumerator.Current
      {
        get
        {
          return (object) this.stack_0.Peek().Current;
        }
      }

      public bool MoveNext()
      {
        IEnumerator<IExtendedDataValue> enumerator1 = this.stack_0.Peek();
        DxfExtendedData.ValueCollection current = enumerator1.Current as DxfExtendedData.ValueCollection;
        if (current != null)
        {
          IEnumerator<IExtendedDataValue> enumerator2 = (IEnumerator<IExtendedDataValue>) current.GetEnumerator();
          this.stack_0.Push(enumerator2);
          enumerator1 = enumerator2;
        }
        bool flag;
        for (flag = enumerator1.MoveNext(); !flag && this.stack_0.Count > 1; flag = this.stack_0.Peek().MoveNext())
          this.stack_0.Pop();
        return flag;
      }

      public void Reset()
      {
        while (this.stack_0.Count > 1)
          this.stack_0.Pop();
        this.stack_0.Peek().Reset();
      }
    }
  }
}
