// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfEvalGraphConnectable
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfEvalGraphConnectable : DxfEvalGraphExpression
  {
    public override string ObjectType
    {
      get
      {
        return "";
      }
    }

    public override string AcClass
    {
      get
      {
        return "";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      throw new Exception("This method shouldn't be called.");
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      throw new Exception("The class is base. Clone shouldn't be used.");
    }
  }
}
