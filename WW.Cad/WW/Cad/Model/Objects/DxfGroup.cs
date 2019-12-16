// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfGroup
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System.Collections.Generic;
using WW.Cad.Model.Entities;

namespace WW.Cad.Model.Objects
{
  public class DxfGroup : DxfObject, INamedObject
  {
    private string string_0 = string.Empty;
    private string string_1 = string.Empty;
    private bool bool_0 = true;
    private readonly DxfHandledObjectCollection<DxfHandledObject> dxfHandledObjectCollection_1 = new DxfHandledObjectCollection<DxfHandledObject>();

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

    public bool IsAnonymous
    {
      get
      {
        if (!string.IsNullOrEmpty(this.string_0))
          return this.string_0[0] == '*';
        return false;
      }
    }

    public string Description
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

    public bool Selectable
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

    public IList<DxfHandledObject> Members
    {
      get
      {
        return (IList<DxfHandledObject>) this.dxfHandledObjectCollection_1;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "GROUP";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbGroup";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfGroup dxfGroup = (DxfGroup) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfGroup == null)
      {
        dxfGroup = new DxfGroup();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfGroup);
        dxfGroup.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfGroup;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfGroup dxfGroup = (DxfGroup) from;
      this.string_0 = dxfGroup.string_0;
      this.string_1 = dxfGroup.string_1;
      this.bool_0 = dxfGroup.bool_0;
      this.dxfHandledObjectCollection_1.Clear();
      if (cloneContext.SourceModel == cloneContext.TargetModel)
      {
        this.dxfHandledObjectCollection_1.AddRange((IEnumerable<DxfHandledObject>) dxfGroup.dxfHandledObjectCollection_1);
      }
      else
      {
        foreach (DxfEntity dxfEntity in dxfGroup.dxfHandledObjectCollection_1)
        {
          if (dxfEntity != null)
            this.dxfHandledObjectCollection_1.Add((DxfHandledObject) dxfEntity.Clone(cloneContext));
        }
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return 72;
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf13OrHigher;
    }
  }
}
