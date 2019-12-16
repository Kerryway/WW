// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfDictionaryVariable
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects
{
  public class DxfDictionaryVariable : DxfObject
  {
    private string string_0;

    public DxfDictionaryVariable()
    {
    }

    public DxfDictionaryVariable(string value)
    {
      this.string_0 = value;
    }

    public string Value
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

    public override string ObjectType
    {
      get
      {
        return "DICTIONARYVAR";
      }
    }

    public override string AcClass
    {
      get
      {
        return "DictionaryVariables";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfDictionaryVariable dictionaryVariable = (DxfDictionaryVariable) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dictionaryVariable == null)
      {
        dictionaryVariable = new DxfDictionaryVariable();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dictionaryVariable);
        dictionaryVariable.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dictionaryVariable;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      this.string_0 = ((DxfDictionaryVariable) from).string_0;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.short_0;
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf14OrHigher;
    }
  }
}
