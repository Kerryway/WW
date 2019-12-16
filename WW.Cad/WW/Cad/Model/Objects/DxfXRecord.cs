// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfXRecord
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System.Collections.Generic;

namespace WW.Cad.Model.Objects
{
  public class DxfXRecord : DxfObject
  {
    private readonly DxfXRecordValueCollection dxfXRecordValueCollection_0 = new DxfXRecordValueCollection();
    private DuplicateRecordCloningFlag duplicateRecordCloningFlag_0;

    public DuplicateRecordCloningFlag DuplicateRecordCloningFlag
    {
      get
      {
        return this.duplicateRecordCloningFlag_0;
      }
      set
      {
        this.duplicateRecordCloningFlag_0 = value;
      }
    }

    public DxfXRecordValueCollection Values
    {
      get
      {
        return this.dxfXRecordValueCollection_0;
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.short_9;
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf14OrHigher;
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override string ObjectType
    {
      get
      {
        return "XRECORD";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbXrecord";
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfXRecord dxfXrecord = (DxfXRecord) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfXrecord == null)
      {
        dxfXrecord = new DxfXRecord();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfXrecord);
        dxfXrecord.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfXrecord;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfXRecord dxfXrecord = (DxfXRecord) from;
      this.duplicateRecordCloningFlag_0 = dxfXrecord.duplicateRecordCloningFlag_0;
      this.dxfXRecordValueCollection_0.Clear();
      foreach (DxfXRecordValue dxfXrecordValue in (List<DxfXRecordValue>) dxfXrecord.dxfXRecordValueCollection_0)
        this.dxfXRecordValueCollection_0.Add((DxfXRecordValue) dxfXrecordValue.Clone(cloneContext));
    }

    protected internal override void ExecuteDeepHelper(
      Action action,
      Stack<DxfHandledObject> callerStack)
    {
      base.ExecuteDeepHelper(action, callerStack);
      foreach (DxfXRecordValue dxfXrecordValue in (List<DxfXRecordValue>) this.dxfXRecordValueCollection_0)
        (dxfXrecordValue.Value as DxfHandledObject)?.vmethod_0(action, callerStack);
    }
  }
}
