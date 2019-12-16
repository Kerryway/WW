// Decompiled with JetBrains decompiler
// Type: ns43.Class644
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using WW.Cad.Model;

namespace ns43
{
  internal static class Class644
  {
    public static readonly DateTime dateTime_0 = new DateTime(1, 1, 1, 12, 0, 0);
    public const int int_0 = 1721426;
    public const int int_1 = 5373484;

    public static double smethod_0(DateTime dateTime)
    {
      if (dateTime < Class644.dateTime_0)
        return 0.0;
      dateTime = dateTime.AddHours(-12.0);
      double num1 = Math.Floor((14.0 - (double) dateTime.Month) / 12.0);
      double num2 = (double) (dateTime.Year + 4800) - num1;
      double num3 = (double) dateTime.Month + 12.0 * num1 - 3.0;
      return (double) dateTime.Day + Math.Floor((153.0 * num3 + 2.0) / 5.0) + 365.0 * num2 + Math.Floor(num2 / 4.0) - Math.Floor(num2 / 100.0) + Math.Floor(num2 / 400.0) - 32045.0 + ((double) dateTime.Millisecond / 1000.0 + (double) dateTime.Second + (double) dateTime.Minute * 60.0 + (double) dateTime.Hour * 3600.0) / 86400.0;
    }

    public static void smethod_1(DateTime dateTime, out int days, out int milliseconds)
    {
      if (dateTime < Class644.dateTime_0)
      {
        days = 0;
        milliseconds = 0;
      }
      else
      {
        dateTime = dateTime.AddHours(-12.0);
        int num1 = (int) Math.Floor((14.0 - (double) dateTime.Month) / 12.0);
        int num2 = dateTime.Year + 4800 - num1;
        int num3 = dateTime.Month + 12 * num1 - 3;
        days = dateTime.Day + (int) Math.Floor((153.0 * (double) num3 + 2.0) / 5.0) + 365 * num2 + (int) Math.Floor((double) num2 / 4.0) - (int) Math.Floor((double) num2 / 100.0) + (int) Math.Floor((double) num2 / 400.0) - 32045;
        milliseconds = dateTime.Millisecond + dateTime.Second * 1000 + dateTime.Minute * 60000 + dateTime.Hour * 3600000;
      }
    }

    public static double smethod_2(TimeSpan timeSpan)
    {
      return timeSpan.TotalDays;
    }

    public static double smethod_3(DxfTimeSpan timeSpan)
    {
      return timeSpan.TotalDays;
    }

    public static DateTime smethod_4(double julianDateTime)
    {
      if (julianDateTime < 1721426.0)
        return DateTime.MinValue;
      if (julianDateTime > 5373484.0)
        return DateTime.MaxValue;
      int julianDayNumber = (int) Math.Floor(julianDateTime);
      return Class644.smethod_5(julianDayNumber).AddDays(julianDateTime - (double) julianDayNumber);
    }

    public static DateTime smethod_5(int julianDayNumber)
    {
      if (julianDayNumber < 1721426)
        return DateTime.MinValue;
      if (julianDayNumber > 5373484)
        return DateTime.MaxValue;
      int num1 = julianDayNumber + 32044;
      int num2 = num1 / 146097;
      int num3 = num1 % 146097;
      int num4 = (num3 / 36524 + 1) * 3 / 4;
      int num5 = num3 - num4 * 36524;
      int num6 = num5 / 1461;
      int num7 = num5 % 1461;
      int num8 = (num7 / 365 + 1) * 3 / 4;
      int num9 = num7 - num8 * 365;
      int num10 = num2 * 400 + num4 * 100 + num6 * 4 + num8;
      int num11 = (num9 * 5 + 308) / 153 - 2;
      int num12 = num9 - (num11 + 4) * 153 / 5 + 122;
      return new DateTime(num10 - 4800 + (num11 + 2) / 12, (num11 + 2) % 12 + 1, num12 + 1, 12, 0, 0);
    }

    public static TimeSpan smethod_6(double julianDateTime)
    {
      TimeSpan timeSpan;
      if (julianDateTime > TimeSpan.MaxValue.TotalDays)
        timeSpan = TimeSpan.MaxValue;
      else if (julianDateTime < TimeSpan.MinValue.TotalDays)
      {
        timeSpan = TimeSpan.MinValue;
      }
      else
      {
        int days = (int) Math.Floor(julianDateTime);
        int milliseconds = (int) ((julianDateTime - (double) days) * 24.0 * 60.0 * 60.0 * 1000.0);
        timeSpan = new TimeSpan(days, 0, 0, 0, milliseconds);
      }
      return timeSpan;
    }

    public static DxfTimeSpan smethod_7(double julianDateTime)
    {
      int days = (int) Math.Floor(julianDateTime);
      int milliseconds = (int) ((julianDateTime - (double) days) * 24.0 * 60.0 * 60.0 * 1000.0);
      return new DxfTimeSpan(days, milliseconds);
    }
  }
}
