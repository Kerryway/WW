// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockVisibilityParameter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockVisibilityParameter : DxfBlockSinglePointParameter
  {
    private bool bool_2;
    private bool bool_3;
    private string string_1;
    private string string_2;
    private DxfHandledObjectCollection<DxfHandledObject> dxfHandledObjectCollection_1;
    private DxfVisibilityState[] dxfVisibilityState_0;

    public string LabelText
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
      }
    }

    public string Description
    {
      get
      {
        return this.string_2;
      }
      set
      {
        this.string_2 = value;
      }
    }

    public bool UnknownFlag
    {
      get
      {
        return this.bool_2;
      }
      set
      {
        this.bool_2 = value;
      }
    }

    public bool UnknownFlag2
    {
      get
      {
        return this.bool_3;
      }
      set
      {
        this.bool_3 = value;
      }
    }

    public DxfVisibilityState[] VisibilityStates
    {
      get
      {
        return this.dxfVisibilityState_0;
      }
      set
      {
        this.dxfVisibilityState_0 = value;
      }
    }

    public DxfHandledObjectCollection<DxfHandledObject> HandleSet
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

    public override string ObjectType
    {
      get
      {
        return "BLOCKVISIBILITYPARAMETER";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockVisibilityParameter";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockVisibilityParameter visibilityParameter = (DxfBlockVisibilityParameter) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (visibilityParameter == null)
      {
        visibilityParameter = new DxfBlockVisibilityParameter();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) visibilityParameter);
        visibilityParameter.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) visibilityParameter;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockVisibilityParameter visibilityParameter = (DxfBlockVisibilityParameter) from;
      this.LabelText = visibilityParameter.LabelText;
      this.Description = visibilityParameter.Description;
      this.UnknownFlag = visibilityParameter.UnknownFlag;
      this.UnknownFlag2 = visibilityParameter.UnknownFlag2;
      this.VisibilityStates = new DxfVisibilityState[visibilityParameter.VisibilityStates.Length];
      for (int index = 0; index < visibilityParameter.VisibilityStates.Length; ++index)
        this.VisibilityStates[index] = visibilityParameter.VisibilityStates[index].Clone(cloneContext) as DxfVisibilityState;
      this.HandleSet = new DxfHandledObjectCollection<DxfHandledObject>(visibilityParameter.HandleSet.Count);
      for (int index = 0; index < visibilityParameter.HandleSet.Count; ++index)
        this.HandleSet.Add(cloneContext.SourceModel == cloneContext.TargetModel ? visibilityParameter.dxfHandledObjectCollection_1[index] : visibilityParameter.dxfHandledObjectCollection_1[index].Clone(cloneContext) as DxfHandledObject);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_4.ClassNumber;
    }
  }
}
