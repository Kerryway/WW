// Decompiled with JetBrains decompiler
// Type: ns27.Class271
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns46;
using System.Collections.Generic;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.DynamicBlock;

namespace ns27
{
  internal class Class271 : Class265
  {
    private List<Class485> list_1 = new List<Class485>();
    private ulong[] ulong_2;
    private ulong[] ulong_3;

    public Class271(DxfEvalGraphExpression obj)
      : base(obj)
    {
    }

    public ulong[] Parameters
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

    public ulong[] DxfObjects2
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

    public List<Class485> XRecordHandles
    {
      get
      {
        return this.list_1;
      }
      set
      {
        this.list_1 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      bool flag = false;
      DxfBlockPropertiesTable blockPropertiesTable = this.Object as DxfBlockPropertiesTable;
      if (this.Parameters != null && this.Parameters.Length != 0)
      {
        for (int index = 0; index < blockPropertiesTable.ColumnInformation.Length; ++index)
        {
          blockPropertiesTable.ColumnInformation[index].Parameter = modelBuilder.method_4<DxfObject>(this.Parameters[index]);
          blockPropertiesTable.ColumnInformation[index].UnknownObject1 = modelBuilder.method_4<DxfObject>(this.DxfObjects2[index]);
          int num1 = blockPropertiesTable.ColumnInformation[index].Parameter != null ? 1 : 0;
          long parameter = (long) this.Parameters[index];
          if (num1 == 0)
          {
            int num2 = blockPropertiesTable.ColumnInformation[index].UnknownObject1 != null ? 1 : 0;
            long num3 = (long) this.DxfObjects2[index];
            if (num2 == 0)
              continue;
          }
          flag = true;
        }
      }
      else
      {
        for (int index = 0; index < blockPropertiesTable.ColumnInformation.Length; ++index)
        {
          blockPropertiesTable.ColumnInformation[index].Parameter = (DxfObject) null;
          blockPropertiesTable.ColumnInformation[index].UnknownObject1 = (DxfObject) null;
        }
      }
      if (this.list_1 != null)
      {
        foreach (Class485 xrecordHandle in this.XRecordHandles)
        {
          xrecordHandle.ResolveReferences(modelBuilder);
          if (xrecordHandle.DataValueHandle == 0UL)
            flag = true;
        }
      }
      if (!flag)
        return;
      Class740.smethod_14(blockPropertiesTable.OwnerObjectSoftReference as DxfEvalGraph);
    }
  }
}
