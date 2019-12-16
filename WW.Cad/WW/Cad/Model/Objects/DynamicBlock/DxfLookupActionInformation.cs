// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfLookupActionInformation
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfLookupActionInformation : IGraphCloneable
  {
    private bool bool_0 = true;
    private bool bool_1 = true;
    private DxfEvalGraph.GraphNodeId graphNodeId_0;
    private int int_0;
    private int int_1;
    private string string_0;
    private string string_1;

    public DxfEvalGraph.GraphNodeId Id
    {
      get
      {
        return this.graphNodeId_0;
      }
      set
      {
        this.graphNodeId_0 = value;
      }
    }

    public int ResourceType
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

    public int Type
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
      }
    }

    public bool PropertyType
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

    public string Unmatched
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

    public string ConnectionText
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

    public bool AllowEditing
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfLookupActionInformation actionInformation = (DxfLookupActionInformation) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (actionInformation == null)
      {
        actionInformation = new DxfLookupActionInformation();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) actionInformation);
        actionInformation.Id = (DxfEvalGraph.GraphNodeId) cloneContext.Clone((IGraphCloneable) this.Id);
        actionInformation.ResourceType = this.ResourceType;
        actionInformation.Type = this.Type;
        actionInformation.PropertyType = this.PropertyType;
        actionInformation.Unmatched = this.Unmatched;
        actionInformation.ConnectionText = this.ConnectionText;
        actionInformation.AllowEditing = this.AllowEditing;
      }
      return (IGraphCloneable) actionInformation;
    }
  }
}
