// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfObject
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using ns3;
using WW.Cad.IO;

namespace WW.Cad.Model.Objects
{
  public abstract class DxfObject : DxfHandledObject
  {
    public abstract string ObjectType { get; }

    public abstract string AcClass { get; }

    public abstract void Accept(IObjectVisitor visitor);

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf13OrHigher;
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      ow.method_77((IDxfHandledObject) this, this.OwnerObjectSoftReference);
      ow.method_76((DxfHandledObject) this);
      ow.method_78(this.ExtensionDictionary);
    }

    internal override Class259 vmethod_9(FileFormat fileFormat)
    {
      return (Class259) new Class260(this);
    }
  }
}
