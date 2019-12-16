// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockParameterPropertyInfo
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockParameterPropertyInfo : IGraphCloneable
  {
    private DxfConnectionPoint[] dxfConnectionPoint_0;

    public DxfConnectionPoint[] ConnectionPoints
    {
      get
      {
        return this.dxfConnectionPoint_0;
      }
      set
      {
        this.dxfConnectionPoint_0 = value;
      }
    }

    public IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockParameterPropertyInfo parameterPropertyInfo = (DxfBlockParameterPropertyInfo) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (parameterPropertyInfo == null)
      {
        parameterPropertyInfo = new DxfBlockParameterPropertyInfo();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) parameterPropertyInfo);
        parameterPropertyInfo.CopyFrom(cloneContext, this);
      }
      return (IGraphCloneable) parameterPropertyInfo;
    }

    protected virtual void CopyFrom(CloneContext cloneContext, DxfBlockParameterPropertyInfo from)
    {
      this.dxfConnectionPoint_0 = DxfConnectionPoint.Clone(cloneContext, from.dxfConnectionPoint_0);
    }
  }
}
