// Decompiled with JetBrains decompiler
// Type: ns28.Class500
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns39;
using ns6;
using System.IO;
using WW.Cad.Model;

namespace ns28
{
  internal class Class500 : Class499
  {
    private Class617 class617_13 = new Class617("AcDb:AcDsPrototype_1b");

    public Class500(Stream stream, DxfModel model)
      : base(stream, model)
    {
    }

    protected override void vmethod_0(Class1030 knownClasses)
    {
      base.vmethod_0(knownClasses);
      this.method_28();
      this.Sections.Add(this.class617_13);
    }

    private void method_28()
    {
      MemoryStream memoryStream = new MemoryStream();
      new Class741.Class742().Write(this.Model.method_13(), Class889.Create((Stream) memoryStream, this.Version, this.Encoding));
      this.method_23(this.class617_13, memoryStream, true);
    }
  }
}
