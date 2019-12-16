// Decompiled with JetBrains decompiler
// Type: ns21.Class188
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns7;
using ns9;
using System.Collections.Generic;
using WW.Math;
using WW.Math.Geometry;

namespace ns21
{
  internal class Class188 : Interface3, Interface4
  {
    private static readonly Dictionary<string, Class188.Delegate3> dictionary_0 = new Dictionary<string, Class188.Delegate3>();
    protected const int int_0 = 5;
    private Class439 class439_0;
    private Class439 class439_1;

    static Class188()
    {
      Class188.dictionary_0.Add("cone", (Class188.Delegate3) (() => (Class188) new Class190()));
      Class188.dictionary_0.Add("plane", (Class188.Delegate3) (() => (Class188) new Class194()));
      Class188.dictionary_0.Add("sphere", (Class188.Delegate3) (() => (Class188) new Class193()));
      Class188.dictionary_0.Add("spline", (Class188.Delegate3) (() => (Class188) new Class191()));
      Class188.dictionary_0.Add("torus", (Class188.Delegate3) (() => (Class188) new Class192()));
      Class188.dictionary_0.Add("null_surface", (Class188.Delegate3) (() => (Class188) new Class189()));
    }

    public static Class188 smethod_0(Interface8 reader)
    {
      string key = reader.imethod_14();
      Class188.Delegate3 delegate3;
      if (!Class188.dictionary_0.TryGetValue(key, out delegate3))
        throw new Exception0("Not supported sub surface primitive type : " + key);
      Class188 class188 = delegate3();
      class188.imethod_0(reader);
      return class188;
    }

    public static void smethod_1(Interface9 writer, Class188 subEntity)
    {
      string str = subEntity.imethod_2(writer.FileFormatVersion);
      writer.imethod_13(str);
      subEntity.imethod_1(writer);
    }

    public virtual string imethod_2(int version)
    {
      return "";
    }

    public virtual void imethod_0(Interface8 reader)
    {
      if (reader.FileFormatVersion < Class250.int_17)
        return;
      this.class439_0 = new Class439(reader);
      this.class439_1 = new Class439(reader);
    }

    public virtual void imethod_1(Interface9 writer)
    {
      if (writer.FileFormatVersion < Class250.int_17)
        return;
      this.class439_0.method_0(writer);
      this.class439_1.method_0(writer);
    }

    public Interface27 IntervalU
    {
      get
      {
        return (Interface27) this.class439_0;
      }
    }

    public Interface27 IntervalV
    {
      get
      {
        return (Interface27) this.class439_1;
      }
    }

    protected virtual Interface28 ExtendedIntervalU
    {
      get
      {
        return (Interface28) new Class438(this.IntervalU);
      }
    }

    protected virtual Interface28 ExtendedIntervalV
    {
      get
      {
        return (Interface28) new Class438(this.IntervalV);
      }
    }

    protected virtual void vmethod_0(Class608 wires, Polygon2D[] paramShape, Interface26 mapper)
    {
    }

    protected virtual Polyline2D vmethod_1(ns9.Class107 edge)
    {
      return (Polyline2D) null;
    }

    public virtual void vmethod_2(Class95 firstLoop, Class608 wires)
    {
      Interface26 pointParamMapper = this.PointParamMapper;
      if (pointParamMapper != null)
      {
        List<Polygon2D> polygon2DList1 = new List<Polygon2D>();
        List<Polygon2D> polygon2DList2 = new List<Polygon2D>();
        foreach (Class95 loop in (IEnumerable<Class95>) Class80.smethod_0<Class95>(firstLoop))
        {
          Class917 approximation = new Class917();
          Polygon2D polygon2D1 = new Polygon2D();
          foreach (ns9.Class107 coedge in (IEnumerable<ns9.Class107>) loop.Coedges)
          {
            ns9.Class88 curve = (ns9.Class88) coedge.Edge.Curve;
            if (curve != null)
            {
              curve.CurvePrimitive.imethod_3(loop, curve, coedge, approximation, wires.Accuracy);
            }
            else
            {
              Polyline2D polyline2D = this.vmethod_1(coedge);
              polygon2D1.AddRange((IEnumerable<Point2D>) polyline2D);
            }
          }
          if (polygon2D1.Count > 0)
          {
            if (pointParamMapper.IsRightHandedParametric)
            {
              if (polygon2D1.GetArea() >= 0.0)
                polygon2DList1.Add(polygon2D1);
              else
                polygon2DList2.Add(polygon2D1);
            }
            else if (polygon2D1.GetArea() < 0.0)
              polygon2DList1.Add(polygon2D1);
            else
              polygon2DList2.Add(polygon2D1);
          }
          Point3D[] points = approximation.Points;
          if (points.Length > 0)
          {
            Polygon2D polygon2D2 = new Polygon2D(points.Length);
            foreach (Point3D point in points)
              polygon2D2.Add(pointParamMapper.imethod_0(point));
            if (pointParamMapper.IsRightHandedParametric)
            {
              if (polygon2D2.GetArea() >= 0.0)
                polygon2DList1.Add(polygon2D2);
              else
                polygon2DList2.Add(polygon2D2);
            }
            else if (polygon2D2.GetArea() < 0.0)
              polygon2DList1.Add(polygon2D2);
            else
              polygon2DList2.Add(polygon2D2);
          }
        }
        if (polygon2DList1.Count == 0 && polygon2DList2.Count != 0)
        {
          foreach (List<Point2D> point2DList in polygon2DList2)
            point2DList.Reverse();
          polygon2DList1.AddRange((IEnumerable<Polygon2D>) polygon2DList2);
          polygon2DList2.Clear();
        }
        Polygon2D[] paramShape = Class794.smethod_9(this.ExtendedIntervalU, this.ExtendedIntervalV, polygon2DList1.ToArray(), polygon2DList2.ToArray(), pointParamMapper.IsRightHandedParametric, wires.Accuracy.Epsilon);
        if (paramShape == null)
          return;
        foreach (Polygon2D polygon2D in paramShape)
        {
          Polygon3D polygon3D = new Polygon3D(polygon2D.Count);
          foreach (Point2D point2D in (List<Point2D>) polygon2D)
            polygon3D.Add(pointParamMapper.imethod_1(point2D.X, point2D.Y));
          wires.method_9((ICollection<Point3D>) polygon3D, true);
        }
        this.vmethod_0(wires, paramShape, pointParamMapper);
      }
      else
        Class80.smethod_2((Class80) firstLoop, wires);
    }

    public virtual Interface26 PointParamMapper
    {
      get
      {
        return (Interface26) null;
      }
    }

    private delegate Class188 Delegate3();
  }
}
