// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.DxfTypedObjectReference
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns3;

namespace WW.Cad.Model
{
  public class DxfTypedObjectReference
  {
    private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
    private ReferenceType referenceType_0;

    internal DxfTypedObjectReference()
    {
    }

    internal DxfTypedObjectReference(ReferenceType referenceType)
    {
      this.referenceType_0 = referenceType;
    }

    public DxfTypedObjectReference(ReferenceType referenceType, DxfObjectReference objectReference)
    {
      this.referenceType_0 = referenceType;
      this.dxfObjectReference_0 = objectReference;
    }

    public ReferenceType ReferenceType
    {
      get
      {
        return this.referenceType_0;
      }
      internal set
      {
        this.referenceType_0 = value;
      }
    }

    public DxfObjectReference ObjectReference
    {
      get
      {
        return this.dxfObjectReference_0;
      }
      internal set
      {
        this.dxfObjectReference_0 = value ?? DxfObjectReference.Null;
      }
    }

    internal DxfTypedObjectReference.Class559 method_0(ulong handle)
    {
      return new DxfTypedObjectReference.Class559(this)
      {
        Handle = handle
      };
    }

    public DxfTypedObjectReference Clone(CloneContext cloneContext)
    {
      return new DxfTypedObjectReference(this.referenceType_0, (DxfObjectReference) this.dxfObjectReference_0.Clone(cloneContext));
    }

    internal class Class559 : Interface10
    {
      private DxfTypedObjectReference dxfTypedObjectReference_0;
      private ulong ulong_0;

      public Class559(DxfTypedObjectReference objectReference)
      {
        this.dxfTypedObjectReference_0 = objectReference;
      }

      public ulong Handle
      {
        get
        {
          return this.ulong_0;
        }
        set
        {
          this.ulong_0 = value;
        }
      }

      public void ResolveReferences(Class374 modelBuilder)
      {
        DxfHandledObject dxfHandledObject = modelBuilder.method_3(this.ulong_0);
        if (dxfHandledObject == null)
          return;
        this.dxfTypedObjectReference_0.ObjectReference = dxfHandledObject.Reference;
      }
    }
  }
}
