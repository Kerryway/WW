// Decompiled with JetBrains decompiler
// Type: ns46.Class740
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.DynamicBlock;

namespace ns46
{
  internal static class Class740
  {
    public static int smethod_0(DxfConnectionPoint[] someList)
    {
      if (someList != null)
        return someList.Length;
      return 0;
    }

    public static int smethod_1(double[] someList)
    {
      if (someList != null)
        return someList.Length;
      return 0;
    }

    public static int smethod_2(DxfHandledObject[] someList)
    {
      if (someList != null)
        return someList.Length;
      return 0;
    }

    public static int smethod_3(IList<DxfHandledObject> someList)
    {
      if (someList != null)
        return someList.Count;
      return 0;
    }

    public static int smethod_4(DxfEvalGraph.GraphNodeId[] someList)
    {
      if (someList != null)
        return someList.Length;
      return 0;
    }

    public static int smethod_5(string[] someList)
    {
      if (someList != null)
        return someList.Length;
      return 0;
    }

    public static int smethod_6(int[] someList)
    {
      if (someList != null)
        return someList.Length;
      return 0;
    }

    public static int smethod_7(
      DxfBlockPolarStretchAction.StretchEntity[] someList)
    {
      if (someList != null)
        return someList.Length;
      return 0;
    }

    public static int smethod_8(WW.Math.Point2D[] someList)
    {
      if (someList != null)
        return someList.Length;
      return 0;
    }

    public static int smethod_9(DxfLookupActionInformation[] someList)
    {
      if (someList != null)
        return someList.Length;
      return 0;
    }

    public static int smethod_10(DxfBlockPolarStretchAction.StretchNode[] someList)
    {
      if (someList != null)
        return someList.Length;
      return 0;
    }

    public static int smethod_11(DxfVisibilityState[] someList)
    {
      if (someList != null)
        return someList.Length;
      return 0;
    }

    public static int smethod_12(DxfEvalGraph.GraphNode[] someList)
    {
      if (someList != null)
        return someList.Length;
      return 0;
    }

    public static int smethod_13(DxfEvalGraph.GraphEdge[] someList)
    {
      if (someList != null)
        return someList.Length;
      return 0;
    }

    public static void smethod_14(DxfEvalGraph evalGraph)
    {
      DxfHandledObject objectSoftReference = evalGraph.OwnerObjectSoftReference as DxfHandledObject;
      if (!(objectSoftReference is DxfDictionary))
        return;
      ((DxfDictionary) objectSoftReference).Entries.RemoveAll("ACAD_ENHANCEDBLOCK");
    }
  }
}
