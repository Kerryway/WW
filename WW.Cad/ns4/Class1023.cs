// Decompiled with JetBrains decompiler
// Type: ns4.Class1023
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using WW.Cad.Model.Entities;
using WW.Math;

namespace ns4
{
  internal class Class1023 : Interface24
  {
    public static readonly Class471[] class471_0 = new Class471[0];
    internal static readonly Interface25 interface25_0 = Class757.class757_0.IsValid() ? (Interface25) new Class431() : (Interface25) new Class1044(" ", ",:;.-", "");
    private LinkedList<Class427> linkedList_0 = new LinkedList<Class427>();
    private Interface25 interface25_1 = Class1023.interface25_0;
    private Vector2D vector2D_0;
    private Class1023.Class1024 class1024_0;
    private readonly Class596 class596_0;
    private readonly double double_0;
    private readonly LineSpacingStyle lineSpacingStyle_0;
    private Class427 class427_0;
    private Class426 class426_0;

    public Class1023(
      Class1023.Class1024 paragraphFormat,
      double lineSpacingFactor,
      LineSpacingStyle lineSpacingStyle,
      Class596 settings)
    {
      this.class1024_0 = paragraphFormat;
      this.double_0 = lineSpacingFactor;
      this.lineSpacingStyle_0 = lineSpacingStyle;
      this.class596_0 = new Class596(settings);
      this.method_0(settings);
    }

    public void method_0(Class596 lineSettings)
    {
      this.linkedList_0.AddLast(new Class427(this.double_0, this.lineSpacingStyle_0, lineSettings));
      this.class427_0 = this.linkedList_0.Last.Value;
      this.class426_0 = (Class426) null;
    }

    public void method_1(Class596 tabSettings)
    {
      this.class426_0 = new Class426(this.class1024_0, tabSettings);
      this.class427_0.method_0((Interface24) this.class426_0);
    }

    public void method_2(string text, Class596 textSettings)
    {
      this.method_3((Interface24) new Class470(text, textSettings));
    }

    public void method_3(Interface24 block)
    {
      if (this.class426_0 != null)
        this.class426_0.method_0(block);
      else
        this.class427_0.method_0(block);
    }

    public Interface25 TextBreaker
    {
      get
      {
        return this.interface25_1;
      }
      set
      {
        this.interface25_1 = value;
      }
    }

    public Class1023.Class1024 Format
    {
      get
      {
        return this.class1024_0;
      }
      set
      {
        this.class1024_0 = value;
      }
    }

    public Vector2D Offset
    {
      get
      {
        return this.vector2D_0;
      }
      set
      {
        Vector2D vector2D = value - this.vector2D_0;
        this.vector2D_0 = value;
        foreach (Class427 class427 in this.linkedList_0)
          class427.Offset = class427.Offset + vector2D;
      }
    }

    public Class596 Settings
    {
      get
      {
        return this.class596_0;
      }
    }

    public Bounds2D GetBounds(Enum24 whiteSpaceHandling, Class985 resultLayoutInfo)
    {
      Bounds2D bounds2D = new Bounds2D();
      bool flag = true;
      foreach (Class425 class425 in this.linkedList_0)
      {
        Bounds2D bounds = class425.GetBounds(whiteSpaceHandling, resultLayoutInfo);
        if ((whiteSpaceHandling & Enum24.flag_1) != Enum24.flag_0)
        {
          if (this.class1024_0.ParagraphWidth != 0.0)
          {
            bounds.Min = new Point2D(this.vector2D_0.X, bounds.Min.Y);
          }
          else
          {
            double leftIndent = this.class1024_0.LeftIndent;
            if (flag)
            {
              flag = false;
              leftIndent += this.class1024_0.LeftIndentFirst;
            }
            bounds.Min -= new Vector2D(leftIndent, 0.0);
            if (bounds.Min.X > bounds.Max.X)
              bounds.Max = new Point2D(bounds.Min.X, bounds.Max.Y);
          }
        }
        if ((whiteSpaceHandling & Enum24.flag_2) != Enum24.flag_0 && this.class1024_0.ParagraphWidth != 0.0)
          bounds.Max = new Point2D(this.vector2D_0.X + this.class1024_0.ParagraphWidth, bounds.Max.Y);
        if (resultLayoutInfo != null)
        {
          if (resultLayoutInfo.FirstLineBounds == null)
          {
            resultLayoutInfo.FirstLineBounds = bounds;
            resultLayoutInfo.FirstLineDescent = resultLayoutInfo.TextBlockDescent;
          }
          resultLayoutInfo.LastLineBounds = bounds;
          resultLayoutInfo.LastLineDescent = resultLayoutInfo.TextBlockDescent;
          resultLayoutInfo.TextBlockDescent = 0.0;
        }
        bounds2D.Update(bounds);
      }
      if ((whiteSpaceHandling & Enum24.flag_2) != Enum24.flag_0)
        bounds2D.Update(bounds2D.Max + new Vector2D(this.class1024_0.RightIndent, 0.0));
      return bounds2D;
    }

    public void imethod_0(ref Vector2D baselinePos, double height, Enum24 whiteSpaceHandlingFlags)
    {
      LinkedList<Class427> linkedList = new LinkedList<Class427>();
      this.vector2D_0 = baselinePos;
      baselinePos += new Vector2D(0.0, -this.class1024_0.BeforeSpace);
      double paragraphWidth = this.class1024_0.ParagraphWidth;
      bool flag1;
      double width = (flag1 = paragraphWidth > 0.0) ? paragraphWidth - this.class1024_0.RightIndent + this.vector2D_0.X : 0.0;
      bool flag2 = true;
      using (LinkedList<Class427>.Enumerator enumerator = this.linkedList_0.GetEnumerator())
      {
label_13:
        if (enumerator.MoveNext())
        {
          Class427 class427_1 = enumerator.Current;
          do
          {
            double x = this.vector2D_0.X + this.class1024_0.LeftIndent;
            if (flag2)
              goto label_11;
label_3:
            Vector2D baselinePos1 = new Vector2D(x, baselinePos.Y);
            Vector2D vector2D = baselinePos1;
            class427_1.imethod_0(ref baselinePos1, height, whiteSpaceHandlingFlags);
            Bounds2D bounds = class427_1.GetBounds(whiteSpaceHandlingFlags, (Class985) null);
            if (flag1 && bounds.Delta.X > width - x)
            {
              Interface24[] nterface24Array = class427_1.imethod_1(width, this.TextBreaker);
              switch (nterface24Array.Length)
              {
                case 0:
                  linkedList.AddLast(class427_1);
                  class427_1 = (Class427) null;
                  break;
                case 1:
                  linkedList.AddLast(class427_1);
                  class427_1 = (Class427) null;
                  break;
                case 2:
                  baselinePos1 = vector2D;
                  Class427 class427_2 = (Class427) nterface24Array[0];
                  class427_2.imethod_0(ref baselinePos1, height, whiteSpaceHandlingFlags);
                  linkedList.AddLast(class427_2);
                  class427_1 = (Class427) nterface24Array[1];
                  break;
                default:
                  linkedList.AddLast(class427_1);
                  class427_1 = (Class427) null;
                  break;
              }
            }
            else
            {
              linkedList.AddLast(class427_1);
              class427_1 = (Class427) null;
            }
            baselinePos += baselinePos1 - vector2D;
            continue;
label_11:
            flag2 = false;
            x += this.class1024_0.LeftIndentFirst;
            goto label_3;
          }
          while (class427_1 != null);
          goto label_13;
        }
      }
      if (linkedList.Count > this.linkedList_0.Count)
        this.linkedList_0 = linkedList;
      bool flag3 = true;
      foreach (Class427 class427 in this.linkedList_0)
      {
        double num = this.vector2D_0.X + this.class1024_0.LeftIndent;
        if (flag3)
        {
          flag3 = false;
          num += this.class1024_0.LeftIndentFirst;
        }
        Bounds2D bounds = class427.GetBounds(Enum24.flag_1, (Class985) null);
        switch (this.class1024_0.Alignment)
        {
          case Class1023.Enum45.const_0:
            class427.method_1(0.5 * (width + num) - bounds.Center.X);
            continue;
          case Class1023.Enum45.const_1:
            class427.method_1(num - bounds.Corner1.X);
            continue;
          case Class1023.Enum45.const_2:
            class427.method_1(width - bounds.Corner2.X);
            continue;
          default:
            continue;
        }
      }
      baselinePos += new Vector2D(0.0, -this.class1024_0.AfterSpace);
    }

    public bool Breakable
    {
      get
      {
        return false;
      }
    }

    public Interface24[] imethod_1(double width, Interface25 breaker)
    {
      return Class470.interface24_0;
    }

    public Vector2D? imethod_2(char ch, Enum24 whiteSpaceHandlingFlags)
    {
      return new Vector2D?();
    }

    public void imethod_3(
      ICollection<Class908> collector,
      Matrix4D insertionTrafo,
      short lineWeight)
    {
      foreach (Class425 class425 in this.linkedList_0)
        class425.imethod_3(collector, insertionTrafo, lineWeight);
    }

    internal enum Enum45 : short
    {
      const_0 = 0,
      const_1 = 1,
      const_2 = 2,
      const_3 = 4,
      const_4 = 5,
    }

    internal class Class1024
    {
      private readonly double double_0;
      private Class1023.Enum45 enum45_0;
      private bool bool_0;
      private double double_1;
      private double double_2;
      private double double_3;
      private double double_4;
      private double double_5;
      private Class471[] class471_0;

      public Class1024(double paragraphWidth, Class1023.Enum45 alignment)
      {
        this.double_0 = paragraphWidth;
        this.enum45_0 = alignment;
      }

      public Class1024(double paragraphWidth, AttachmentPoint attachmentPoint)
      {
        this.double_0 = paragraphWidth;
        switch (attachmentPoint)
        {
          case AttachmentPoint.TopCenter:
          case AttachmentPoint.MiddleCenter:
          case AttachmentPoint.BottomCenter:
            this.enum45_0 = Class1023.Enum45.const_0;
            break;
          case AttachmentPoint.TopRight:
          case AttachmentPoint.MiddleRight:
          case AttachmentPoint.BottomRight:
            this.enum45_0 = Class1023.Enum45.const_2;
            break;
          default:
            this.enum45_0 = Class1023.Enum45.const_1;
            break;
        }
      }

      public Class1024(Class1023.Class1024 format)
      {
        this.double_0 = format.ParagraphWidth;
        this.enum45_0 = format.Alignment;
        this.bool_0 = format.bool_0;
        this.double_1 = format.double_1;
        this.double_2 = format.double_2;
        this.double_3 = format.double_3;
        this.double_4 = format.double_4;
        this.double_5 = format.double_5;
        this.class471_0 = format.class471_0;
      }

      public Class1024(Class1023.Class1024 previousFormat, string definition, double fontHeight)
        : this(previousFormat)
      {
        this.method_0(definition, fontHeight);
      }

      private void method_0(string format, double fontHeight)
      {
        if (format.Length <= 0)
          return;
        if (format[0] == 'x')
        {
          this.bool_0 = true;
          format = format.Substring(1);
        }
        double scaling = this.bool_0 ? fontHeight : 1.0;
        format += (string) (object) ',';
        bool flag1 = false;
        bool flag2 = false;
        int length1;
        for (; format.Length > 0; format = format.Substring(length1 + 1))
        {
          length1 = format.IndexOf(',');
          char c = format[0];
          switch (c)
          {
            case 'D':
              if (!flag1)
              {
                this.class471_0 = Class1023.class471_0;
                flag1 = true;
              }
              char decimalChar = format[1];
              if (decimalChar == ',')
              {
                length1 = format.IndexOf(',', length1 + 1);
                if (length1 == -1)
                  length1 = format.Length - 1;
              }
              this.method_2(Class471.Enum13.const_3, format.Substring(2, length1 - 2), scaling, decimalChar);
              break;
            case 'a':
              try
              {
                this.double_5 = scaling * double.Parse(format.Substring(1, length1 - 1), (IFormatProvider) CultureInfo.InvariantCulture);
                break;
              }
              catch (FormatException ex)
              {
                break;
              }
            case 'b':
              try
              {
                this.double_4 = scaling * double.Parse(format.Substring(1, length1 - 1), (IFormatProvider) CultureInfo.InvariantCulture);
                break;
              }
              catch (FormatException ex)
              {
                break;
              }
            case 'c':
              if (!flag1)
              {
                this.class471_0 = Class1023.class471_0;
                flag1 = true;
              }
              this.method_1(Class471.Enum13.const_1, format.Substring(1, length1 - 1), scaling);
              break;
            case 'i':
              try
              {
                this.double_2 = scaling * double.Parse(format.Substring(1, length1 - 1), (IFormatProvider) CultureInfo.InvariantCulture);
                break;
              }
              catch (FormatException ex)
              {
                break;
              }
            case 'l':
              try
              {
                this.double_1 = scaling * double.Parse(format.Substring(1, length1 - 1), (IFormatProvider) CultureInfo.InvariantCulture);
                break;
              }
              catch (FormatException ex)
              {
                break;
              }
            case 'q':
              string str = format.Substring(1, length1 - 1);
              if (str.Length >= 1)
              {
                int length2 = str.Length;
                switch (str[0])
                {
                  case 'c':
                    this.enum45_0 = Class1023.Enum45.const_0;
                    continue;
                  case 'd':
                    this.enum45_0 = Class1023.Enum45.const_4;
                    continue;
                  case 'j':
                    this.enum45_0 = Class1023.Enum45.const_3;
                    continue;
                  case 'l':
                    this.enum45_0 = Class1023.Enum45.const_1;
                    continue;
                  case 'r':
                    this.enum45_0 = Class1023.Enum45.const_2;
                    continue;
                  default:
                    continue;
                }
              }
              else
                break;
            case 'r':
              if (!flag2)
              {
                flag2 = true;
                try
                {
                  this.double_3 = scaling * double.Parse(format.Substring(1, length1 - 1), (IFormatProvider) CultureInfo.InvariantCulture);
                  break;
                }
                catch (FormatException ex)
                {
                  break;
                }
              }
              else
              {
                if (!flag1)
                {
                  this.class471_0 = Class1023.class471_0;
                  flag1 = true;
                }
                this.method_1(Class471.Enum13.const_2, format.Substring(1, length1 - 1), scaling);
                break;
              }
            case 't':
              string position = format.Substring(1, length1 - 1);
              if ("z" != position)
              {
                if (!flag1)
                  this.class471_0 = Class1023.class471_0;
                flag1 = true;
                this.method_1(Class471.Enum13.const_0, position, scaling);
                break;
              }
              this.class471_0 = Class1023.class471_0;
              break;
            default:
              if (flag1 && char.IsDigit(c))
              {
                this.method_1(Class471.Enum13.const_0, format.Substring(0, length1), scaling);
                break;
              }
              break;
          }
        }
      }

      private void method_1(Class471.Enum13 type, string position, double scaling)
      {
        this.method_2(type, position, scaling, '.');
      }

      private void method_2(
        Class471.Enum13 type,
        string position,
        double scaling,
        char decimalChar)
      {
        try
        {
          Class471 other = new Class471(type);
          other.Position = scaling * double.Parse(position, (IFormatProvider) CultureInfo.InvariantCulture);
          other.DecimalPointChar = decimalChar;
          Class471[] class471Array = new Class471[this.class471_0.Length + 1];
          int index;
          for (index = 0; index < this.class471_0.Length && this.class471_0[index].CompareTo(other) <= 0; ++index)
            class471Array[index] = this.class471_0[index];
          class471Array[index] = other;
          for (; index < this.class471_0.Length; ++index)
            class471Array[index + 1] = this.class471_0[index];
          this.class471_0 = class471Array;
        }
        catch (FormatException ex)
        {
        }
      }

      public Class1023.Enum45 Alignment
      {
        get
        {
          return this.enum45_0;
        }
      }

      public double ParagraphWidth
      {
        get
        {
          return this.double_0;
        }
      }

      public Class471[] Tabulators
      {
        get
        {
          return this.class471_0 ?? Class1023.class471_0;
        }
      }

      public double LeftIndent
      {
        get
        {
          return this.double_1;
        }
      }

      public double LeftIndentFirst
      {
        get
        {
          return this.double_2;
        }
      }

      public double RightIndent
      {
        get
        {
          return this.double_3;
        }
      }

      public double BeforeSpace
      {
        get
        {
          return this.double_4;
        }
      }

      public double AfterSpace
      {
        get
        {
          return this.double_5;
        }
      }
    }
  }
}
