// Decompiled with JetBrains decompiler
// Type: WW.Cad.IO.PatternReader
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using WW.Cad.Model.Entities;
using WW.Math;

namespace WW.Cad.IO
{
  public static class PatternReader
  {
    public static DxfPattern[] ReadPatterns(string filename)
    {
      using (StreamReader streamReader = File.OpenText(filename))
        return PatternReader.ReadPatterns((TextReader) streamReader);
    }

    public static DxfPattern[] ReadPatterns(TextReader reader)
    {
      int num1 = 0;
      List<DxfPattern> dxfPatternList = new List<DxfPattern>();
      DxfPattern dxfPattern = (DxfPattern) null;
      try
      {
        while (true)
        {
          string str1;
          do
          {
            do
            {
              string str2 = reader.ReadLine();
              ++num1;
              if (str2 != null)
                str1 = str2.Trim('\x001A');
              else
                goto label_14;
            }
            while (string.IsNullOrEmpty(str1) || str1.StartsWith(";"));
            if (str1.StartsWith("*"))
            {
              int num2 = str1.IndexOf(',');
              string name;
              string str2;
              if (num2 < 0)
              {
                name = str1.Substring(1);
                str2 = (string) null;
              }
              else
              {
                name = str1.Substring(1, num2 - 1);
                str2 = str1.Substring(num2 + 1);
              }
              dxfPattern = new DxfPattern(name);
              dxfPattern.Description = str2;
              dxfPatternList.Add(dxfPattern);
            }
          }
          while (dxfPattern == null);
          DxfPattern.Line line = new DxfPattern.Line();
          string[] strArray = str1.Split(',');
          line.Angle = System.Math.PI / 180.0 * double.Parse(strArray[0], (IFormatProvider) CultureInfo.InvariantCulture);
          line.BasePoint = new Point2D(double.Parse(strArray[1], (IFormatProvider) CultureInfo.InvariantCulture), double.Parse(strArray[2], (IFormatProvider) CultureInfo.InvariantCulture));
          Vector2D vector2D = new Vector2D(double.Parse(strArray[3], (IFormatProvider) CultureInfo.InvariantCulture), double.Parse(strArray[4], (IFormatProvider) CultureInfo.InvariantCulture));
          double num3 = System.Math.Cos(line.Angle);
          double num4 = System.Math.Sin(line.Angle);
          line.Offset = new Vector2D(vector2D.X * num3 - vector2D.Y * num4, vector2D.X * num4 + vector2D.Y * num3);
          for (int index = 5; index < strArray.Length; ++index)
            line.DashLengths.Add(double.Parse(strArray[index], (IFormatProvider) CultureInfo.InvariantCulture));
          dxfPattern.Lines.Add(line);
        }
      }
      catch (Exception ex)
      {
        throw new Exception(string.Format("Parse error at line {0}: ", (object) num1), ex);
      }
label_14:
      return dxfPatternList.ToArray();
    }
  }
}
