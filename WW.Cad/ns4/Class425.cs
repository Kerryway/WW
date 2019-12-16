// Decompiled with JetBrains decompiler
// Type: ns4.Class425
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Math;

namespace ns4
{
  internal class Class425 : Interface24
  {
    private readonly LinkedList<Interface24> linkedList_0 = new LinkedList<Interface24>();
    private readonly Class596 class596_0;
    private Vector2D vector2D_0;
    private readonly bool bool_0;

    public Class425(Class596 settings)
    {
      this.class596_0 = settings;
    }

    public Class425(Class596 settings, bool vertical)
      : this(settings)
    {
      this.bool_0 = vertical;
    }

    public void method_0(Interface24 block)
    {
      this.linkedList_0.AddLast(block);
    }

    public LinkedList<Interface24> Blocks
    {
      get
      {
        return this.linkedList_0;
      }
    }

    protected virtual Class425 vmethod_0(bool first)
    {
      return new Class425(this.class596_0, this.bool_0);
    }

    public virtual Vector2D Offset
    {
      get
      {
        return this.vector2D_0;
      }
      set
      {
        Vector2D vector2D = value - this.vector2D_0;
        this.vector2D_0 = value;
        foreach (Interface24 nterface24 in this.linkedList_0)
          nterface24.Offset += vector2D;
      }
    }

    public virtual Class596 Settings
    {
      get
      {
        return this.class596_0;
      }
    }

    public virtual Bounds2D GetBounds(Enum24 whiteSpaceHandling, Class985 resultLayoutInfo)
    {
      Bounds2D bounds2D = new Bounds2D();
      foreach (Interface24 nterface24 in this.linkedList_0)
        bounds2D.Update(nterface24.GetBounds(whiteSpaceHandling, resultLayoutInfo));
      return bounds2D;
    }

    public virtual void imethod_0(
      ref Vector2D baselinePos,
      double height,
      Enum24 whiteSpaceHandlingFlags)
    {
      this.vector2D_0 = baselinePos;
      foreach (Interface24 nterface24 in this.linkedList_0)
        nterface24.imethod_0(ref baselinePos, height, whiteSpaceHandlingFlags);
    }

    public virtual bool Breakable
    {
      get
      {
        if (this.bool_0)
          return false;
        if (this.linkedList_0.Count == 1)
          return this.linkedList_0.First.Value.Breakable;
        return this.linkedList_0.Count > 1;
      }
    }

    public virtual Interface24[] imethod_1(double width, Interface25 breaker)
    {
      if (this.GetBounds(Enum24.flag_1, (Class985) null).Corner2.X > width)
      {
        Class425 class425_1 = this.vmethod_0(true);
        class425_1.Offset = this.Offset;
        using (LinkedList<Interface24>.Enumerator enumerator = this.linkedList_0.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            Interface24 current = enumerator.Current;
            if (current.Breakable)
            {
              Interface24[] nterface24Array = current.imethod_1(width, breaker);
              switch (nterface24Array.Length)
              {
                case 0:
                  if (class425_1.linkedList_0.Count <= 0)
                    return Class470.interface24_0;
                  Class425 class425_2 = this.vmethod_0(false);
                  class425_2.method_0(current);
                  while (enumerator.MoveNext())
                    class425_2.method_0(enumerator.Current);
                  return new Interface24[2]{ (Interface24) class425_1, (Interface24) class425_2 };
                case 1:
                  class425_1.method_0(current);
                  continue;
                case 2:
                  class425_1.method_0(nterface24Array[0]);
                  Class425 class425_3 = this.vmethod_0(false);
                  class425_3.method_0(nterface24Array[1]);
                  while (enumerator.MoveNext())
                    class425_3.method_0(enumerator.Current);
                  return new Interface24[2]{ (Interface24) class425_1, (Interface24) class425_3 };
                default:
                  continue;
              }
            }
            else if (current.GetBounds(Enum24.flag_1, (Class985) null).Corner2.X <= width)
            {
              class425_1.method_0(current);
            }
            else
            {
              if (class425_1.linkedList_0.Count <= 0)
                return Class470.interface24_0;
              Class425 class425_2 = this.vmethod_0(false);
              class425_2.method_0(current);
              while (enumerator.MoveNext())
                class425_2.method_0(enumerator.Current);
              return new Interface24[2]{ (Interface24) class425_1, (Interface24) class425_2 };
            }
          }
        }
        return Class470.interface24_0;
      }
      return new Interface24[1]{ (Interface24) this };
    }

    public virtual Vector2D? imethod_2(char ch, Enum24 whiteSpaceHandlingFlags)
    {
      Vector2D? nullable = new Vector2D?();
      if (!this.bool_0)
      {
        foreach (Interface24 nterface24 in this.linkedList_0)
        {
          nullable = nterface24.imethod_2(ch, whiteSpaceHandlingFlags);
          if (nullable.HasValue)
            break;
        }
      }
      return nullable;
    }

    public virtual void imethod_3(
      ICollection<Class908> collector,
      Matrix4D insertionTrafo,
      short lineWeight)
    {
      foreach (Interface24 nterface24 in this.linkedList_0)
        nterface24.imethod_3(collector, insertionTrafo, lineWeight);
    }
  }
}
