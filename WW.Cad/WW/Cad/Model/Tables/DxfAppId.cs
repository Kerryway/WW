// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.DxfAppId
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Base;

namespace WW.Cad.Model.Tables
{
  public class DxfAppId : DxfTableRecord
  {
    private StandardFlags standardFlags_0 = StandardFlags.IsReferenced;
    private string string_0;

    public DxfAppId()
    {
    }

    public DxfAppId(string name)
    {
      this.string_0 = name;
    }

    public override string Name
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

    public override bool IsExternallyDependent
    {
      get
      {
        return (this.standardFlags_0 & StandardFlags.IsExternallyDependent) != StandardFlags.None;
      }
      set
      {
        if (value)
          this.standardFlags_0 |= StandardFlags.IsExternallyDependent;
        else
          this.standardFlags_0 &= ~StandardFlags.IsExternallyDependent;
      }
    }

    public override bool IsResolvedExternalRef
    {
      get
      {
        return (this.standardFlags_0 & StandardFlags.IsResolvedExternalRef) != StandardFlags.None;
      }
      set
      {
        if (value)
          this.standardFlags_0 |= StandardFlags.IsResolvedExternalRef;
        else
          this.standardFlags_0 &= ~StandardFlags.IsResolvedExternalRef;
      }
    }

    public override bool IsReferenced
    {
      get
      {
        return (this.standardFlags_0 & StandardFlags.IsReferenced) != StandardFlags.None;
      }
      set
      {
        if (value)
          this.standardFlags_0 |= StandardFlags.IsReferenced;
        else
          this.standardFlags_0 &= ~StandardFlags.IsReferenced;
      }
    }

    public override void Accept(ITableRecordVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      return ValidateUtil.ValidateName((object) this, this.string_0, model, messages);
    }

    public override string ToString()
    {
      return this.string_0;
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfAppId dxfAppId = (DxfAppId) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfAppId == null)
      {
        dxfAppId = new DxfAppId();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfAppId);
        dxfAppId.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfAppId;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfAppId dxfAppId = (DxfAppId) from;
      this.string_0 = dxfAppId.string_0;
      this.standardFlags_0 = dxfAppId.standardFlags_0;
      if (dxfAppId.Handle != 18UL)
        return;
      this.SetHandle(18UL);
    }

    internal StandardFlags Flags
    {
      get
      {
        return this.standardFlags_0;
      }
      set
      {
        this.standardFlags_0 = value;
      }
    }

    internal override void vmethod_3(DxfModel modelContext)
    {
      base.vmethod_3(modelContext);
      this.vmethod_2((IDxfHandledObject) modelContext.AppIdTable);
    }

    internal override void vmethod_4(DxfModel modelContext)
    {
      base.vmethod_4(modelContext);
      this.vmethod_2((IDxfHandledObject) null);
    }

    internal static DxfAppId smethod_2(bool useFixedHandles)
    {
      DxfAppId dxfAppId = new DxfAppId("ACAD");
      if (useFixedHandles)
        dxfAppId.SetHandle(18UL);
      return dxfAppId;
    }

    internal static DxfAppId smethod_3(bool useFixedHandles)
    {
      return new DxfAppId("ACAD_MLEADERVER");
    }

    public static class Names
    {
      public const string Acad = "ACAD";
      public const string MLeaderVer = "ACAD_MLEADERVER";
      public const string AcCmTransparency = "AcCmTransparency";
    }
  }
}
