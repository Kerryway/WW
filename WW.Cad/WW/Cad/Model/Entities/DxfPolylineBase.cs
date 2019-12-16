// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfPolylineBase
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns1;
using ns28;
using System;
using System.Collections.Generic;
using WW.Cad.Base;

namespace WW.Cad.Model.Entities
{
  public abstract class DxfPolylineBase : DxfEntity
  {
    private DxfObjectReference dxfObjectReference_6 = new DxfSequenceEnd().Reference;
    private Enum21 enum21_0;

    public DxfPolylineBase()
    {
      this.SeqEnd.vmethod_2((IDxfHandledObject) this);
    }

    public override string EntityType
    {
      get
      {
        return "POLYLINE";
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      throw new DxfException("Not implemented.");
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfPolylineBase dxfPolylineBase = (DxfPolylineBase) from;
      this.enum21_0 = dxfPolylineBase.enum21_0;
      this.SeqEnd.CopyFrom((DxfHandledObject) dxfPolylineBase.SeqEnd, cloneContext);
    }

    protected internal override void ExecuteDeepHelper(
      WW.Cad.Model.Action action,
      Stack<DxfHandledObject> callerStack)
    {
      base.ExecuteDeepHelper(action, callerStack);
      this.SeqEnd.vmethod_0(action, callerStack);
    }

    internal Enum21 Flags
    {
      get
      {
        return this.enum21_0;
      }
      set
      {
        this.enum21_0 = value;
      }
    }

    internal DxfSequenceEnd SeqEnd
    {
      get
      {
        return (DxfSequenceEnd) this.dxfObjectReference_6.Value;
      }
      set
      {
        this.dxfObjectReference_6 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal virtual short vmethod_14(Class432 ow)
    {
      throw new NotImplementedException();
    }
  }
}
