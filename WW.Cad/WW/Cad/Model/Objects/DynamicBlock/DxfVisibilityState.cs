// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfVisibilityState
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfVisibilityState : IGraphCloneable
  {
    private string string_0;
    private DxfHandledObjectCollection<DxfHandledObject> dxfHandledObjectCollection_0;
    private DxfHandledObjectCollection<DxfHandledObject> dxfHandledObjectCollection_1;

    public string Name
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

    public DxfHandledObjectCollection<DxfHandledObject> SelectionSet1
    {
      get
      {
        return this.dxfHandledObjectCollection_0;
      }
      set
      {
        this.dxfHandledObjectCollection_0 = value;
      }
    }

    public DxfHandledObjectCollection<DxfHandledObject> SelectionSet2
    {
      get
      {
        return this.dxfHandledObjectCollection_1;
      }
      set
      {
        this.dxfHandledObjectCollection_1 = value;
      }
    }

    public IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfVisibilityState dxfVisibilityState = (DxfVisibilityState) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfVisibilityState == null)
      {
        dxfVisibilityState = new DxfVisibilityState();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfVisibilityState);
        dxfVisibilityState.Name = this.Name;
        if (this.SelectionSet1 != null)
        {
          dxfVisibilityState.SelectionSet1 = new DxfHandledObjectCollection<DxfHandledObject>(this.SelectionSet1.Count);
          for (int index = 0; index < this.dxfHandledObjectCollection_0.Count; ++index)
            dxfVisibilityState.SelectionSet1.Add(this.SelectionSet1[index].Clone(cloneContext) as DxfHandledObject);
        }
        if (this.SelectionSet2 != null)
        {
          dxfVisibilityState.SelectionSet2 = new DxfHandledObjectCollection<DxfHandledObject>(this.SelectionSet2.Count);
          for (int index = 0; index < this.dxfHandledObjectCollection_1.Count; ++index)
            dxfVisibilityState.SelectionSet2.Add(this.SelectionSet2[index].Clone(cloneContext) as DxfHandledObject);
        }
      }
      return (IGraphCloneable) dxfVisibilityState;
    }
  }
}
