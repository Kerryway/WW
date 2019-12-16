// Decompiled with JetBrains decompiler
// Type: ns3.Class332
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class332 : Interface10
  {
    private DxfDictionary dxfDictionary_0;
    private DxfDictionaryEntry dxfDictionaryEntry_0;
    private ulong ulong_0;

    public Class332(DxfDictionary dictionary, DxfDictionaryEntry dictionaryEntry)
    {
      this.dxfDictionary_0 = dictionary;
      this.dxfDictionaryEntry_0 = dictionaryEntry;
    }

    public Class332(DxfDictionary dictionary, DxfDictionaryEntry dictionaryEntry, ulong itemHandle)
    {
      this.dxfDictionary_0 = dictionary;
      this.dxfDictionaryEntry_0 = dictionaryEntry;
      this.ulong_0 = itemHandle;
    }

    public ulong ItemHandle
    {
      get
      {
        return this.ulong_0;
      }
      set
      {
        this.ulong_0 = value;
      }
    }

    public void ResolveReferences(Class374 modelBuilder)
    {
      if (this.ulong_0 == 0UL)
        return;
      DxfObject dxfObject = modelBuilder.method_4<DxfObject>(this.ulong_0);
      if (dxfObject == null || dxfObject.Reference == null || dxfObject.Reference.Value == null)
        return;
      INamedObject namedObject = dxfObject as INamedObject;
      if (namedObject != null && string.IsNullOrEmpty(namedObject.Name))
        namedObject.Name = this.dxfDictionaryEntry_0.Name;
      this.dxfDictionaryEntry_0.SetValue(dxfObject);
      dxfObject.Accept((IObjectVisitor) modelBuilder.ObjectCollectionResolver);
    }
  }
}
