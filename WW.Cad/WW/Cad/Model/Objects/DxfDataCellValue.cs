// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfDataCellValue
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns28;
using ns3;
using WW.Cad.IO;

namespace WW.Cad.Model.Objects
{
  public abstract class DxfDataCellValue
  {
    public abstract DataCellType CellType { get; }

    public abstract void Accept(IDataCellValueVisitor visitor);

    public abstract DxfDataCellValue Clone(CloneContext cloneContext);

    public class Unknown : DxfDataCellValue
    {
      public static readonly DxfDataCellValue.Unknown Instance = new DxfDataCellValue.Unknown();

      private Unknown()
      {
      }

      public override DataCellType CellType
      {
        get
        {
          return DataCellType.Unknown;
        }
      }

      public override void Accept(IDataCellValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override DxfDataCellValue Clone(CloneContext cloneContext)
      {
        return (DxfDataCellValue) this;
      }
    }

    public class Int32 : DxfDataCellValue
    {
      private int int_0;

      public Int32()
      {
      }

      public Int32(int value)
      {
        this.int_0 = value;
      }

      public override DataCellType CellType
      {
        get
        {
          return DataCellType.Int32;
        }
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

      public override void Accept(IDataCellValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override DxfDataCellValue Clone(CloneContext cloneContext)
      {
        return (DxfDataCellValue) new DxfDataCellValue.Int32(this.int_0);
      }

      public override string ToString()
      {
        return this.int_0.ToString();
      }
    }

    public class Double : DxfDataCellValue
    {
      private double double_0;

      public Double()
      {
      }

      public Double(double value)
      {
        this.double_0 = value;
      }

      public override DataCellType CellType
      {
        get
        {
          return DataCellType.Double;
        }
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

      public override void Accept(IDataCellValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override DxfDataCellValue Clone(CloneContext cloneContext)
      {
        return (DxfDataCellValue) new DxfDataCellValue.Double(this.double_0);
      }

      public override string ToString()
      {
        return this.double_0.ToString();
      }
    }

    public class String : DxfDataCellValue
    {
      private string string_0;

      public String()
      {
      }

      public String(string value)
      {
        this.string_0 = value;
      }

      public override DataCellType CellType
      {
        get
        {
          return DataCellType.String;
        }
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

      public override void Accept(IDataCellValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override DxfDataCellValue Clone(CloneContext cloneContext)
      {
        return (DxfDataCellValue) new DxfDataCellValue.String(this.string_0);
      }

      public override string ToString()
      {
        if (this.string_0 != null)
          return this.string_0.ToString();
        return string.Empty;
      }
    }

    public class Point3D : DxfDataCellValue
    {
      private WW.Math.Point3D point3D_0;

      public Point3D()
      {
      }

      public Point3D(WW.Math.Point3D value)
      {
        this.point3D_0 = value;
      }

      public override DataCellType CellType
      {
        get
        {
          return DataCellType.Point3D;
        }
      }

      public WW.Math.Point3D Value
      {
        get
        {
          return this.point3D_0;
        }
        set
        {
          this.point3D_0 = value;
        }
      }

      public override void Accept(IDataCellValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override DxfDataCellValue Clone(CloneContext cloneContext)
      {
        return (DxfDataCellValue) new DxfDataCellValue.Point3D(this.point3D_0);
      }

      public override string ToString()
      {
        return this.point3D_0.ToString();
      }
    }

    public abstract class ObjectIdBase : DxfDataCellValue
    {
      private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;

      protected ObjectIdBase()
      {
      }

      protected ObjectIdBase(DxfHandledObject value)
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

      public override string ToString()
      {
        if (this.Value != null)
          return this.Value.ToString();
        return "null";
      }

      internal class Class554 : Interface10
      {
        private DxfDataCellValue.ObjectIdBase objectIdBase_0;
        private ulong ulong_0;

        public Class554(DxfDataCellValue.ObjectIdBase o, ulong handle)
        {
          this.objectIdBase_0 = o;
          this.ulong_0 = handle;
        }

        public void ResolveReferences(Class374 modelBuilder)
        {
          if (this.ulong_0 == 0UL)
            return;
          this.objectIdBase_0.Value = modelBuilder.method_3(this.ulong_0);
        }
      }
    }

    public class ObjectId : DxfDataCellValue.ObjectIdBase
    {
      public ObjectId()
      {
      }

      public ObjectId(DxfHandledObject value)
        : base(value)
      {
      }

      public override DataCellType CellType
      {
        get
        {
          return DataCellType.ObjectId;
        }
      }

      public override void Accept(IDataCellValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override DxfDataCellValue Clone(CloneContext cloneContext)
      {
        DxfHandledObject dxfHandledObject = (DxfHandledObject) null;
        if (this.Value != null)
          dxfHandledObject = (DxfHandledObject) this.Value.Clone(cloneContext);
        return (DxfDataCellValue) new DxfDataCellValue.ObjectId(dxfHandledObject);
      }
    }

    public abstract class OwnerIdBase : DxfDataCellValue
    {
      private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;

      protected OwnerIdBase()
      {
      }

      protected OwnerIdBase(DxfObject value)
      {
        this.Value = value;
      }

      public DxfObject Value
      {
        get
        {
          return (DxfObject) this.dxfObjectReference_0.Value;
        }
        set
        {
          this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        }
      }

      public override string ToString()
      {
        if (this.Value != null)
          return this.Value.ToString();
        return "null";
      }

      internal class Class555 : Interface10
      {
        private DxfDataCellValue.OwnerIdBase ownerIdBase_0;
        private ulong ulong_0;

        public Class555(DxfDataCellValue.OwnerIdBase o, ulong handle)
        {
          this.ownerIdBase_0 = o;
          this.ulong_0 = handle;
        }

        public void ResolveReferences(Class374 modelBuilder)
        {
          if (this.ulong_0 == 0UL)
            return;
          this.ownerIdBase_0.Value = modelBuilder.method_4<DxfObject>(this.ulong_0);
        }
      }
    }

    public class HardOwnerId : DxfDataCellValue.OwnerIdBase
    {
      public HardOwnerId()
      {
      }

      public HardOwnerId(DxfObject value)
        : base(value)
      {
      }

      public override DataCellType CellType
      {
        get
        {
          return DataCellType.HardOwnerId;
        }
      }

      public override void Accept(IDataCellValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override DxfDataCellValue Clone(CloneContext cloneContext)
      {
        DxfObject dxfObject = (DxfObject) null;
        if (this.Value != null)
          dxfObject = (DxfObject) this.Value.Clone(cloneContext);
        return (DxfDataCellValue) new DxfDataCellValue.HardOwnerId(dxfObject);
      }
    }

    public class SoftOwnerId : DxfDataCellValue.OwnerIdBase
    {
      public SoftOwnerId()
      {
      }

      public SoftOwnerId(DxfObject value)
        : base(value)
      {
      }

      public override DataCellType CellType
      {
        get
        {
          return DataCellType.SoftOwnerId;
        }
      }

      public override void Accept(IDataCellValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override DxfDataCellValue Clone(CloneContext cloneContext)
      {
        DxfObject dxfObject = (DxfObject) null;
        if (this.Value != null)
          dxfObject = (DxfObject) this.Value.Clone(cloneContext);
        return (DxfDataCellValue) new DxfDataCellValue.SoftOwnerId(dxfObject);
      }
    }

    public class HardPointerId : DxfDataCellValue.ObjectIdBase
    {
      public HardPointerId()
      {
      }

      public HardPointerId(DxfHandledObject value)
        : base(value)
      {
      }

      public override DataCellType CellType
      {
        get
        {
          return DataCellType.HardPointerId;
        }
      }

      public override void Accept(IDataCellValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override DxfDataCellValue Clone(CloneContext cloneContext)
      {
        DxfHandledObject dxfHandledObject = (DxfHandledObject) null;
        if (this.Value != null)
        {
          dxfHandledObject = (DxfHandledObject) this.Value.Clone(cloneContext);
          cloneContext.method_0(dxfHandledObject);
        }
        return (DxfDataCellValue) new DxfDataCellValue.HardPointerId(dxfHandledObject);
      }
    }

    public class SoftPointerId : DxfDataCellValue.ObjectIdBase
    {
      public SoftPointerId()
      {
      }

      public SoftPointerId(DxfHandledObject value)
        : base(value)
      {
      }

      public override DataCellType CellType
      {
        get
        {
          return DataCellType.SoftPointerId;
        }
      }

      public override void Accept(IDataCellValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override DxfDataCellValue Clone(CloneContext cloneContext)
      {
        DxfHandledObject dxfHandledObject = (DxfHandledObject) null;
        if (this.Value != null)
        {
          dxfHandledObject = (DxfHandledObject) this.Value.Clone(cloneContext);
          cloneContext.method_0(dxfHandledObject);
        }
        return (DxfDataCellValue) new DxfDataCellValue.SoftPointerId(dxfHandledObject);
      }
    }

    public class Bool : DxfDataCellValue
    {
      private bool bool_0;

      public Bool()
      {
      }

      public Bool(bool value)
      {
        this.bool_0 = value;
      }

      public override DataCellType CellType
      {
        get
        {
          return DataCellType.Bool;
        }
      }

      public bool Value
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

      public override void Accept(IDataCellValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override DxfDataCellValue Clone(CloneContext cloneContext)
      {
        return (DxfDataCellValue) new DxfDataCellValue.Bool(this.bool_0);
      }

      public override string ToString()
      {
        return this.bool_0.ToString();
      }
    }

    public class Vector3D : DxfDataCellValue
    {
      private WW.Math.Vector3D vector3D_0;

      public Vector3D()
      {
      }

      public Vector3D(WW.Math.Vector3D value)
      {
        this.vector3D_0 = value;
      }

      public override DataCellType CellType
      {
        get
        {
          return DataCellType.Vector3D;
        }
      }

      public WW.Math.Vector3D Value
      {
        get
        {
          return this.vector3D_0;
        }
        set
        {
          this.vector3D_0 = value;
        }
      }

      public override void Accept(IDataCellValueVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override DxfDataCellValue Clone(CloneContext cloneContext)
      {
        return (DxfDataCellValue) new DxfDataCellValue.Vector3D(this.vector3D_0);
      }

      public override string ToString()
      {
        return this.vector3D_0.ToString();
      }
    }

    internal class Class556 : IDataCellValueVisitor
    {
      private Class432 class432_0;
      private Interface29 interface29_0;

      public Class556(Class432 ow, Interface29 w)
      {
        this.class432_0 = ow;
        this.interface29_0 = w;
      }

      public void Visit(DxfDataCellValue.Unknown visitee)
      {
      }

      public void Visit(DxfDataCellValue.Int32 visitee)
      {
        this.interface29_0.imethod_33(visitee.Value);
      }

      public void Visit(DxfDataCellValue.Double visitee)
      {
        this.interface29_0.imethod_16(visitee.Value);
      }

      public void Visit(DxfDataCellValue.String visitee)
      {
        this.interface29_0.imethod_4(visitee.Value);
      }

      public void Visit(DxfDataCellValue.Point3D visitee)
      {
        this.interface29_0.imethod_24(visitee.Value);
      }

      public void Visit(DxfDataCellValue.ObjectId visitee)
      {
        this.interface29_0.imethod_41(visitee.Value);
      }

      public void Visit(DxfDataCellValue.HardOwnerId visitee)
      {
        this.interface29_0.imethod_39((DxfHandledObject) visitee.Value);
        this.class432_0.method_42(visitee.Value);
      }

      public void Visit(DxfDataCellValue.SoftOwnerId visitee)
      {
        this.interface29_0.imethod_38((DxfHandledObject) visitee.Value);
        this.class432_0.method_42(visitee.Value);
      }

      public void Visit(DxfDataCellValue.HardPointerId visitee)
      {
        this.interface29_0.imethod_41(visitee.Value);
      }

      public void Visit(DxfDataCellValue.SoftPointerId visitee)
      {
        this.interface29_0.imethod_40(visitee.Value);
      }

      public void Visit(DxfDataCellValue.Bool visitee)
      {
        this.interface29_0.imethod_14(visitee.Value);
      }

      public void Visit(DxfDataCellValue.Vector3D visitee)
      {
        this.interface29_0.imethod_29(visitee.Value);
      }
    }

    internal class Class557 : IDataCellValueVisitor
    {
      private DxfWriter dxfWriter_0;

      public Class557(DxfWriter w)
      {
        this.dxfWriter_0 = w;
      }

      public void Visit(DxfDataCellValue.Unknown visitee)
      {
      }

      public void Visit(DxfDataCellValue.Int32 visitee)
      {
        this.dxfWriter_0.Write(93, (object) visitee.Value);
      }

      public void Visit(DxfDataCellValue.Double visitee)
      {
        this.dxfWriter_0.Write(40, (object) visitee.Value);
      }

      public void Visit(DxfDataCellValue.String visitee)
      {
        this.dxfWriter_0.Write(3, (object) visitee.Value);
      }

      public void Visit(DxfDataCellValue.Point3D visitee)
      {
        this.dxfWriter_0.Write(10, visitee.Value);
      }

      public void Visit(DxfDataCellValue.ObjectId visitee)
      {
        this.dxfWriter_0.method_218(331, visitee.Value);
      }

      public void Visit(DxfDataCellValue.HardOwnerId visitee)
      {
        this.dxfWriter_0.method_218(360, (DxfHandledObject) visitee.Value);
        this.dxfWriter_0.method_71(visitee.Value);
      }

      public void Visit(DxfDataCellValue.SoftOwnerId visitee)
      {
        this.dxfWriter_0.method_218(350, (DxfHandledObject) visitee.Value);
        this.dxfWriter_0.method_71(visitee.Value);
      }

      public void Visit(DxfDataCellValue.HardPointerId visitee)
      {
        this.dxfWriter_0.method_218(340, visitee.Value);
      }

      public void Visit(DxfDataCellValue.SoftPointerId visitee)
      {
        this.dxfWriter_0.method_218(330, visitee.Value);
      }

      public void Visit(DxfDataCellValue.Bool visitee)
      {
        this.dxfWriter_0.Write(71, (object) (short) (visitee.Value ? 1 : 0));
      }

      public void Visit(DxfDataCellValue.Vector3D visitee)
      {
        this.dxfWriter_0.Write(11, visitee.Value);
      }
    }
  }
}
