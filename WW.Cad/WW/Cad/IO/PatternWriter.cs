// Decompiled with JetBrains decompiler
// Type: WW.Cad.IO.PatternWriter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Globalization;
using System.IO;
using System.Text;
using WW.Cad.Model.Entities;
using WW.Math;

namespace WW.Cad.IO
{
  public static class PatternWriter
  {
    public static void WritePatterns(string filename, DxfPattern[] patterns)
    {
      if (string.Compare(Path.GetExtension(filename), ".pat", StringComparison.InvariantCultureIgnoreCase) != 0)
        filename += ".pat";
      using (StreamWriter text = File.CreateText(filename))
        PatternWriter.WritePatterns((TextWriter) text, patterns);
    }

    public static void WritePatterns(TextWriter writer, DxfPattern[] patterns)
    {
      foreach (DxfPattern pattern in patterns)
      {
        writer.WriteLine("*{0},{1}", (object) pattern.Name, (object) pattern.Description);
        foreach (DxfPattern.Line line in pattern.Lines)
        {
          StringBuilder stringBuilder = new StringBuilder();
          double num1 = line.Angle * 180.0 / System.Math.PI;
          double num2 = System.Math.Cos(-line.Angle);
          double num3 = System.Math.Sin(-line.Angle);
          Vector2D offset = line.Offset;
          Vector2D vector2D = new Vector2D(offset.X * num2 - offset.Y * num3, offset.X * num3 + offset.Y * num2);
          stringBuilder.Append(num1.ToString((IFormatProvider) CultureInfo.InvariantCulture));
          stringBuilder.Append(",");
          stringBuilder.Append(line.BasePoint.X.ToString((IFormatProvider) CultureInfo.InvariantCulture));
          stringBuilder.Append(",");
          stringBuilder.Append(line.BasePoint.Y.ToString((IFormatProvider) CultureInfo.InvariantCulture));
          stringBuilder.Append(",");
          stringBuilder.Append(vector2D.X.ToString((IFormatProvider) CultureInfo.InvariantCulture));
          stringBuilder.Append(",");
          stringBuilder.Append(vector2D.Y.ToString((IFormatProvider) CultureInfo.InvariantCulture));
          stringBuilder.Append(",");
          if (line.DashLengths.Count > 0)
          {
            stringBuilder.Append(line.DashLengths[0].ToString((IFormatProvider) CultureInfo.InvariantCulture));
            for (int index = 1; index < line.DashLengths.Count; ++index)
            {
              stringBuilder.Append(",");
              stringBuilder.Append(line.DashLengths[index].ToString((IFormatProvider) CultureInfo.InvariantCulture));
            }
          }
          writer.WriteLine(stringBuilder.ToString());
        }
      }
    }
  }
}
