// Decompiled with JetBrains decompiler
// Type: ns27.Class265
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns3;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.DynamicBlock;

namespace ns27
{
  internal class Class265 : Class260
  {
    private Class485 class485_0;

    public Class265(DxfEvalGraphExpression obj)
      : base((DxfObject) obj)
    {
      this.class485_0 = new Class485(obj.DataValue);
    }

    public Class485 XRecordBuilder
    {
      get
      {
        return this.class485_0;
      }
      set
      {
        this.class485_0 = value;
      }
    }

    public ulong DataValueHandle
    {
      get
      {
        return this.class485_0.DataValueHandle;
      }
      set
      {
        this.class485_0.DataValueHandle = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfEvalGraphExpression handledObject = (DxfEvalGraphExpression) this.HandledObject;
      if (this.class485_0 == null || this.class485_0.DataValueHandle == 0UL)
        return;
      handledObject.DataValue.Value = (object) modelBuilder.method_3(this.class485_0.DataValueHandle);
      if (handledObject.DataValue.Value != null)
        return;
      handledObject.DataValue = (DxfXRecordValue) null;
    }
  }
}
