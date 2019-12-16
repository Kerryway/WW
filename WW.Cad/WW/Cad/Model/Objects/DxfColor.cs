// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfColor
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects
{
  public class DxfColor : DxfObject
  {
    private Color color_0;

    public DxfColor()
    {
    }

    public DxfColor(Color color)
    {
      this.color_0 = color;
    }

    public DxfColor(DxfColor from)
    {
      this.color_0 = from.color_0;
    }

    public Color Color
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
      }
    }

    public DxfColor.Key GetKey()
    {
      return new DxfColor.Key(this.color_0.ColorBookName, this.color_0.Name);
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf18OrHigher;
    }

    public override string ObjectType
    {
      get
      {
        return "DBCOLOR";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbColor";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfColor dxfColor = (DxfColor) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfColor == null)
      {
        dxfColor = new DxfColor();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfColor);
        dxfColor.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfColor;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      this.color_0 = ((DxfColor) from).color_0;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_0.ClassNumber;
    }

    public class Key
    {
      private string string_0;
      private string string_1;

      public Key(string colorBookName, string name)
      {
        this.string_0 = colorBookName;
        this.string_1 = name;
      }

      public string ColorBookName
      {
        get
        {
          return this.string_0;
        }
        set
        {
          this.string_0 = value;
        }
      }

      public string Name
      {
        get
        {
          return this.string_1;
        }
        set
        {
          this.string_1 = value;
        }
      }

      public override bool Equals(object obj)
      {
        DxfColor.Key key = obj as DxfColor.Key;
        if (key == null || !(this.string_0 == key.string_0))
          return false;
        return this.string_1 == key.string_1;
      }

      public override int GetHashCode()
      {
        return this.ColorBookName.GetHashCode() ^ this.string_1.GetHashCode();
      }
    }
  }
}
