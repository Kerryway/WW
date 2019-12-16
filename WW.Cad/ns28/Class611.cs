// Decompiled with JetBrains decompiler
// Type: ns28.Class611
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;

namespace ns28
{
  internal class Class611
  {
    public static void Write(Class889 byteStream, SummaryInfo summaryInfo)
    {
      byteStream.vmethod_19(summaryInfo.Title);
      byteStream.vmethod_19(summaryInfo.Subject);
      byteStream.vmethod_19(summaryInfo.Author);
      byteStream.vmethod_19(summaryInfo.Keywords);
      byteStream.vmethod_19(summaryInfo.Comments);
      byteStream.vmethod_19(summaryInfo.LastSavedBy);
      byteStream.vmethod_19(summaryInfo.RevisionNumber);
      byteStream.vmethod_19(summaryInfo.HyperLinkBase);
      byteStream.vmethod_25(summaryInfo.TotalEditingTime);
      byteStream.vmethod_27(summaryInfo.CreationDateTime);
      byteStream.vmethod_27(summaryInfo.ModifiedDateTime);
      byteStream.vmethod_7((ushort) summaryInfo.Properties.Count);
      foreach (SummaryInfo.Property property in summaryInfo.Properties)
      {
        byteStream.vmethod_19(property.Name);
        byteStream.vmethod_19(property.Value);
      }
      byteStream.vmethod_9(0);
      byteStream.vmethod_9(0);
    }
  }
}
