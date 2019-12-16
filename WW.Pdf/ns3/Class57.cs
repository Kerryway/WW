// Decompiled with JetBrains decompiler
// Type: ns3.Class57
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

namespace ns3
{
  internal class Class57
  {
    private readonly ushort ushort_0;
    private readonly short short_0;

    public Class57(ushort advanceWidth, short leftSideBearing)
    {
      this.ushort_0 = advanceWidth;
      this.short_0 = leftSideBearing;
    }

    public Class57 method_0()
    {
      return new Class57(this.ushort_0, this.short_0);
    }

    public ushort AdvanceWidth
    {
      get
      {
        return this.ushort_0;
      }
    }

    public short LeftSideBearing
    {
      get
      {
        return this.short_0;
      }
    }
  }
}
