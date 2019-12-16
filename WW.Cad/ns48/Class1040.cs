// Decompiled with JetBrains decompiler
// Type: ns48.Class1040
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ns48
{
  [DebuggerNonUserCode]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [CompilerGenerated]
  internal class Class1040
  {
    private static ResourceManager resourceManager_0;
    private static CultureInfo cultureInfo_0;

    internal Class1040()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) Class1040.resourceManager_0, (object) null))
          Class1040.resourceManager_0 = new ResourceManager("ns48.Class1040", typeof (Class1040).Assembly);
        return Class1040.resourceManager_0;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return Class1040.cultureInfo_0;
      }
      set
      {
        Class1040.cultureInfo_0 = value;
      }
    }

    internal static string SelectInteractor_MirrorInteractor_PickPoint1
    {
      get
      {
        return Class1040.ResourceManager.GetString(nameof (SelectInteractor_MirrorInteractor_PickPoint1), Class1040.cultureInfo_0);
      }
    }

    internal static string SelectInteractor_MirrorInteractor_PickPoint2
    {
      get
      {
        return Class1040.ResourceManager.GetString(nameof (SelectInteractor_MirrorInteractor_PickPoint2), Class1040.cultureInfo_0);
      }
    }

    internal static string SelectInteractor_MoveInteractor_PickBasePoint
    {
      get
      {
        return Class1040.ResourceManager.GetString(nameof (SelectInteractor_MoveInteractor_PickBasePoint), Class1040.cultureInfo_0);
      }
    }

    internal static string SelectInteractor_MoveInteractor_PickTargetPoint
    {
      get
      {
        return Class1040.ResourceManager.GetString(nameof (SelectInteractor_MoveInteractor_PickTargetPoint), Class1040.cultureInfo_0);
      }
    }

    internal static string SelectInteractor_RotateInteractor_PickBasePoint
    {
      get
      {
        return Class1040.ResourceManager.GetString(nameof (SelectInteractor_RotateInteractor_PickBasePoint), Class1040.cultureInfo_0);
      }
    }

    internal static string SelectInteractor_RotateInteractor_PickRefeferencePoint
    {
      get
      {
        return Class1040.ResourceManager.GetString(nameof (SelectInteractor_RotateInteractor_PickRefeferencePoint), Class1040.cultureInfo_0);
      }
    }

    internal static string SelectInteractor_RotateInteractor_PickTargetPoint
    {
      get
      {
        return Class1040.ResourceManager.GetString(nameof (SelectInteractor_RotateInteractor_PickTargetPoint), Class1040.cultureInfo_0);
      }
    }

    internal static string SelectInteractor_ScaleFromBasePointInteractor_PickBasePoint
    {
      get
      {
        return Class1040.ResourceManager.GetString(nameof (SelectInteractor_ScaleFromBasePointInteractor_PickBasePoint), Class1040.cultureInfo_0);
      }
    }

    internal static string SelectInteractor_ScaleFromBasePointInteractor_PickRefeferencePoint
    {
      get
      {
        return Class1040.ResourceManager.GetString(nameof (SelectInteractor_ScaleFromBasePointInteractor_PickRefeferencePoint), Class1040.cultureInfo_0);
      }
    }

    internal static string SelectInteractor_ScaleFromBasePointInteractor_PickTargetPoint
    {
      get
      {
        return Class1040.ResourceManager.GetString(nameof (SelectInteractor_ScaleFromBasePointInteractor_PickTargetPoint), Class1040.cultureInfo_0);
      }
    }
  }
}
