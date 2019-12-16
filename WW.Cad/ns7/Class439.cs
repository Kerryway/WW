// Decompiled with JetBrains decompiler
// Type: ns7.Class439
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace ns7
{
  internal class Class439 : Class437
  {
    private static readonly string[] string_0 = new string[2]{ "F", "I" };

    public Class439(double start, double end)
      : base(start, end)
    {
    }

    public Class439(Interface8 reader)
      : this(reader.FileFormatVersion < Class250.int_15 ? reader.imethod_8() : (new Class686.Class689(reader).Value ? reader.imethod_8() : double.NegativeInfinity), reader.FileFormatVersion < Class250.int_15 ? reader.imethod_8() : (new Class686.Class689(reader).Value ? reader.imethod_8() : double.PositiveInfinity))
    {
    }

    public void method_0(Interface9 writer)
    {
      if (writer.FileFormatVersion < Class250.int_15)
      {
        writer.imethod_7(this.Start);
        writer.imethod_7(this.End);
      }
      else
      {
        if (this.HasUnboundStart)
        {
          writer.imethod_12((Interface39) Class686.Class689.class689_1);
        }
        else
        {
          writer.imethod_12((Interface39) Class686.Class689.class689_0);
          writer.imethod_7(this.Start);
        }
        if (this.HasUnboundEnd)
        {
          writer.imethod_12((Interface39) Class686.Class689.class689_1);
        }
        else
        {
          writer.imethod_12((Interface39) Class686.Class689.class689_0);
          writer.imethod_7(this.End);
        }
      }
    }
  }
}
