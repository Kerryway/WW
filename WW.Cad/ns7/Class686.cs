// Decompiled with JetBrains decompiler
// Type: ns7.Class686
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace ns7
{
  internal static class Class686
  {
    public abstract class Class687 : Interface39
    {
      private bool bool_0;

      private Class687()
      {
      }

      protected Class687(bool value)
      {
        this.bool_0 = value;
      }

      protected Class687(Interface8 reader)
      {
        reader.imethod_13((Interface39) this);
      }

      protected abstract string TrueString { get; }

      protected abstract string FalseString { get; }

      public bool Value
      {
        get
        {
          return this.bool_0;
        }
        set
        {
          this.bool_0 = value;
        }
      }

      public string SAT
      {
        get
        {
          if (!this.Value)
            return this.FalseString;
          return this.TrueString;
        }
        set
        {
          if (value == this.TrueString)
            this.bool_0 = true;
          else if (value == this.FalseString)
            this.bool_0 = false;
          else if (value == "1")
          {
            this.bool_0 = true;
          }
          else
          {
            if (!(value == "0"))
              throw new Exception0("Invalid logical value " + value);
            this.bool_0 = false;
          }
        }
      }
    }

    public class Class688 : Class686.Class687
    {
      public Class688(bool value)
        : base(value)
      {
      }

      public Class688(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "T";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "F";
        }
      }
    }

    public class Class689 : Class686.Class687
    {
      public static readonly Class686.Class689 class689_0 = new Class686.Class689(true);
      public static readonly Class686.Class689 class689_1 = new Class686.Class689(false);

      public Class689(bool value)
        : base(value)
      {
      }

      public Class689(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "F";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "I";
        }
      }
    }

    public class Class690 : Class686.Class687
    {
      public Class690(bool value)
        : base(value)
      {
      }

      public Class690(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "reversed";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "forward";
        }
      }
    }

    public class Class691 : Class686.Class687
    {
      public Class691(bool value)
        : base(value)
      {
      }

      public Class691(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "in";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "out";
        }
      }
    }

    public class Class692 : Class686.Class687
    {
      public Class692(bool value)
        : base(value)
      {
      }

      public Class692(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "rotate";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "no_rotate";
        }
      }
    }

    public class Class693 : Class686.Class687
    {
      public Class693(bool value)
        : base(value)
      {
      }

      public Class693(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "reflect";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "no_reflect";
        }
      }
    }

    public class Class694 : Class686.Class687
    {
      public Class694(bool value)
        : base(value)
      {
      }

      public Class694(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "shear";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "no_shear";
        }
      }
    }

    public class Class695 : Class686.Class687
    {
      public Class695(bool value)
        : base(value)
      {
      }

      public Class695(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "reverse_v";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "forward_v";
        }
      }
    }

    public class Class696 : Class686.Class687
    {
      public Class696(bool value)
        : base(value)
      {
      }

      public Class696(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "double";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "single";
        }
      }
    }

    public class Class697 : Class686.Class687
    {
      public Class697(bool value)
        : base(value)
      {
      }

      public Class697(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "surf1";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "surf2";
        }
      }
    }

    public class Class698 : Class686.Class687
    {
      public Class698(bool value)
        : base(value)
      {
      }

      public Class698(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "left";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "right";
        }
      }
    }

    public class Class699 : Class686.Class687
    {
      public Class699(bool value)
        : base(value)
      {
      }

      public Class699(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "left";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "right";
        }
      }
    }

    public class Class700 : Class686.Class687
    {
      public Class700(bool value)
        : base(value)
      {
      }

      public Class700(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "on_xy";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "not_on";
        }
      }
    }

    public class Class701 : Class686.Class687
    {
      public Class701(bool value)
        : base(value)
      {
      }

      public Class701(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "is_planar";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "not_planar";
        }
      }
    }

    public class Class702 : Class686.Class687
    {
      public Class702(bool value)
        : base(value)
      {
      }

      public Class702(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "no_z";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "has_z";
        }
      }
    }

    public class Class703 : Class686.Class687
    {
      public Class703(bool value)
        : base(value)
      {
      }

      public Class703(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "has_scale";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "no_scale";
        }
      }
    }

    public class Class704 : Class686.Class687
    {
      public Class704(bool value)
        : base(value)
      {
      }

      public Class704(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "yes_x_scaling";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "no_x_scaling";
        }
      }
    }

    public class Class705 : Class686.Class687
    {
      public Class705(bool value)
        : base(value)
      {
      }

      public Class705(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "yes_y_scaling";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "no_y_scaling";
        }
      }
    }

    public class Class706 : Class686.Class687
    {
      public Class706(bool value)
        : base(value)
      {
      }

      public Class706(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "no_rail";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "has_rail";
        }
      }
    }

    public class Class707 : Class686.Class687
    {
      public Class707(bool value)
        : base(value)
      {
      }

      public Class707(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "periodic";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "not_periodic";
        }
      }
    }

    public class Class708 : Class686.Class687
    {
      public Class708(bool value)
        : base(value)
      {
      }

      public Class708(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "normal";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "angled";
        }
      }
    }

    public class Class709 : Class686.Class687
    {
      public Class709(bool value)
        : base(value)
      {
      }

      public Class709(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "calibrated";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "uncalibrated";
        }
      }
    }

    public class Class710 : Class686.Class687
    {
      public Class710(bool value)
        : base(value)
      {
      }

      public Class710(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "radius";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "no_radius";
        }
      }
    }

    public class Class711 : Class686.Class687
    {
      public Class711(bool value)
        : base(value)
      {
      }

      public Class711(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "TRUE";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "FALSE";
        }
      }
    }

    public class Class712 : Class686.Class687
    {
      public Class712(bool value)
        : base(value)
      {
      }

      public Class712(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "ARC";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "ISO";
        }
      }
    }

    public class Class713 : Class686.Class687
    {
      public Class713(bool value)
        : base(value)
      {
      }

      public Class713(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "PERPENDICULAR";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "SKIN";
        }
      }
    }

    public class Class714 : Class686.Class687
    {
      public Class714(bool value)
        : base(value)
      {
      }

      public Class714(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "convex";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "concave";
        }
      }
    }

    public class Class715 : Class686.Class687
    {
      public Class715(bool value)
        : base(value)
      {
      }

      public Class715(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "rb_envelope";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "rb_snapshot";
        }
      }
    }

    public class Class716 : Class686.Class687
    {
      public Class716(bool value)
        : base(value)
      {
      }

      public Class716(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "origin_lost";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "origin_live";
        }
      }
    }

    public class Class717 : Class686.Class687
    {
      public Class717(bool value)
        : base(value)
      {
      }

      public Class717(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "set";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "free";
        }
      }
    }

    public class Class718 : Class686.Class687
    {
      public Class718(bool value)
        : base(value)
      {
      }

      public Class718(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "cross";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "non_cross";
        }
      }
    }

    public class Class719 : Class686.Class687
    {
      public Class719(bool value)
        : base(value)
      {
      }

      public Class719(Interface8 reader)
        : base(reader)
      {
      }

      protected override string TrueString
      {
        get
        {
          return "smooth";
        }
      }

      protected override string FalseString
      {
        get
        {
          return "non_smooth";
        }
      }
    }
  }
}
