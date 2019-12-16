// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfIndirectObject`1
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System;

namespace WW.Pdf
{
  public class PdfIndirectObject<T> : IDisposable, IPdfIndirectObject where T : IPdfObject
  {
    private int int_0;
    private int int_1;
    protected T value;

    public PdfIndirectObject()
    {
    }

    public PdfIndirectObject(T value)
    {
      this.value = value;
    }

    public int Number
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

    public int Generation
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

    public IPdfObject Value
    {
      get
      {
        return (IPdfObject) this.value;
      }
      set
      {
        this.value = (T) value;
      }
    }

    public void Dispose()
    {
      IDisposable disposable = (object) this.value as IDisposable;
      if (disposable == null)
        return;
      disposable.Dispose();
      this.value = default (T);
    }
  }
}
