// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfStream
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System;
using System.Collections.Generic;

namespace WW.Pdf
{
  public class PdfStream : IPdfObject
  {
    private readonly PdfDictionary pdfDictionary_0 = new PdfDictionary();
    private readonly byte[] byte_0;
    private IList<IFilter> ilist_0;

    public PdfStream()
    {
    }

    public PdfStream(byte[] data)
    {
      this.byte_0 = data;
    }

    public void AddFilter(IFilter filter)
    {
      if (filter == null)
        throw new ArgumentNullException(nameof (filter));
      if (this.ilist_0 == null)
        this.ilist_0 = (IList<IFilter>) new List<IFilter>();
      this.ilist_0.Add(filter);
    }

    protected PdfDictionary Dictionary
    {
      get
      {
        return this.pdfDictionary_0;
      }
    }

    public virtual byte[] Data
    {
      get
      {
        if (this.byte_0 == null)
          return (byte[]) null;
        return (byte[]) this.byte_0.Clone();
      }
    }

    private IPdfObject FilterName
    {
      get
      {
        if (!this.HasFilters)
          return (IPdfObject) PdfNull.Null;
        if (this.ilist_0.Count == 1)
          return this.ilist_0[0].Name;
        PdfArray pdfArray = new PdfArray();
        foreach (IFilter filter in (IEnumerable<IFilter>) this.ilist_0)
          pdfArray.Add(filter.Name);
        return (IPdfObject) pdfArray;
      }
    }

    private IPdfObject FilterDecodeParms
    {
      get
      {
        if (!this.HasFilters)
          return (IPdfObject) PdfNull.Null;
        if (this.ilist_0.Count == 1)
          return this.ilist_0[0].DecodeParameters;
        PdfArray pdfArray = new PdfArray();
        foreach (IFilter filter in (IEnumerable<IFilter>) this.ilist_0)
          pdfArray.Add(filter.DecodeParameters);
        return (IPdfObject) pdfArray;
      }
    }

    private bool HasFilters
    {
      get
      {
        if (this.ilist_0 != null)
          return this.ilist_0.Count > 0;
        return false;
      }
    }

    private bool HasDecodeParams
    {
      get
      {
        if (this.ilist_0 == null)
          return false;
        foreach (IFilter filter in (IEnumerable<IFilter>) this.ilist_0)
        {
          if (filter.HasDecodeParameters)
            return true;
        }
        return false;
      }
    }

    private byte[] method_0(byte[] unfilteredData)
    {
      if (this.ilist_0 == null)
        return unfilteredData;
      byte[] data = unfilteredData;
      for (int index = this.ilist_0.Count - 1; index >= 0; --index)
        data = this.ilist_0[index].Encode(data);
      return data;
    }

    internal virtual byte[] FilteredData
    {
      get
      {
        byte[] unfilteredData = this.Data;
        if (unfilteredData == null)
          return (byte[]) null;
        if (this.HasFilters)
          unfilteredData = this.method_0(unfilteredData);
        return unfilteredData;
      }
    }

    internal PdfDictionary method_1(byte[] filteredData, bool noFiltering)
    {
      this.pdfDictionary_0["Length"] = (IPdfObject) new PdfInt(filteredData.Length);
      if (this.HasFilters && !noFiltering)
      {
        this.pdfDictionary_0["Filter"] = this.FilterName;
        if (this.HasDecodeParams)
          this.pdfDictionary_0["DecodeParams"] = this.FilterDecodeParms;
      }
      return this.pdfDictionary_0;
    }

    public virtual void Write(ExtendedPdfOutput output)
    {
      byte[] numArray = ((IPdfOutput) output).UseFilters ? this.FilteredData : this.Data;
      if (numArray == null)
        throw new InvalidOperationException("No data for stream.");
      PdfDictionary pdfDictionary = this.method_1(numArray, !((IPdfOutput) output).UseFilters);
      output.WriteLine((IPdfObject) pdfDictionary);
      output.WriteLine("stream");
      output.WriteLine(numArray);
      output.Write("endstream");
    }
  }
}
