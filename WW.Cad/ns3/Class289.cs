// Decompiled with JetBrains decompiler
// Type: ns3.Class289
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;
using WW.Math;

namespace ns3
{
  internal class Class289 : Class288
  {
    private Vector3D vector3D_0 = Vector3D.Zero;
    private BlockFlags? nullable_3;
    private DxfEntityCollection dxfEntityCollection_0;
    private string string_3;
    private string string_4;
    private bool? nullable_4;
    private DxfBlockEnd dxfBlockEnd_0;

    public Class289(DxfBlockBegin entity)
      : base(entity)
    {
    }

    public BlockFlags? Flags
    {
      get
      {
        return this.nullable_3;
      }
      set
      {
        this.nullable_3 = value;
      }
    }

    public DxfEntityCollection Entities
    {
      get
      {
        return this.dxfEntityCollection_0;
      }
      set
      {
        this.dxfEntityCollection_0 = value;
      }
    }

    public Vector3D BasePoint
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

    public string Description
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

    public string ExternalReference
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

    public bool? IsExternalReferenceUnloaded
    {
      get
      {
        return this.nullable_4;
      }
      set
      {
        this.nullable_4 = value;
      }
    }

    public DxfBlockEnd BlockEnd
    {
      get
      {
        return this.dxfBlockEnd_0;
      }
      set
      {
        this.dxfBlockEnd_0 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfBlockBegin handledObject = this.HandledObject as DxfBlockBegin;
      if (handledObject == null)
        return;
      DxfBlock block = handledObject.Block;
      bool flag = false;
      if (block == null)
      {
        block = new DxfBlock(this.Name);
        flag = true;
      }
      block.BlockBegin = handledObject;
      if (this.dxfBlockEnd_0 == null)
        this.dxfBlockEnd_0 = new DxfBlockEnd();
      block.BlockEnd = this.dxfBlockEnd_0;
      if (this.nullable_3.HasValue)
        block.Flags = this.nullable_3.Value;
      if (this.dxfEntityCollection_0 != null)
        block.method_10(this.dxfEntityCollection_0);
      block.method_8(this.vector3D_0);
      if (this.string_3 != null)
        block.Description = this.string_3;
      if (this.string_4 != null)
        block.ExternalReference = this.string_4;
      block.BlockEnd = this.dxfBlockEnd_0;
      if (this.nullable_4.HasValue)
        block.IsExternalReferenceUnloaded = this.nullable_4.Value;
      if (!flag)
        return;
      modelBuilder.Model.method_38(block, (IList<DxfMessage>) modelBuilder.Messages, true);
    }
  }
}
