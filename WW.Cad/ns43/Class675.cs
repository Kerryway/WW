// Decompiled with JetBrains decompiler
// Type: ns43.Class675
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ns43
{
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  internal class Class675
  {
    private static ResourceManager resourceManager_0;
    private static CultureInfo cultureInfo_0;

    internal Class675()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) Class675.resourceManager_0, (object) null))
          Class675.resourceManager_0 = new ResourceManager("ns43.Class675", typeof (Class675).Assembly);
        return Class675.resourceManager_0;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return Class675.cultureInfo_0;
      }
      set
      {
        Class675.cultureInfo_0 = value;
      }
    }

    internal static string Degrees
    {
      get
      {
        return Class675.ResourceManager.GetString(nameof (Degrees), Class675.cultureInfo_0);
      }
    }

    internal static string Edit
    {
      get
      {
        return Class675.ResourceManager.GetString(nameof (Edit), Class675.cultureInfo_0);
      }
    }

    internal static string Height
    {
      get
      {
        return Class675.ResourceManager.GetString(nameof (Height), Class675.cultureInfo_0);
      }
    }

    internal static string Length
    {
      get
      {
        return Class675.ResourceManager.GetString(nameof (Length), Class675.cultureInfo_0);
      }
    }

    internal static string Other
    {
      get
      {
        return Class675.ResourceManager.GetString(nameof (Other), Class675.cultureInfo_0);
      }
    }

    internal static string Radius
    {
      get
      {
        return Class675.ResourceManager.GetString(nameof (Radius), Class675.cultureInfo_0);
      }
    }

    internal static string Rotation
    {
      get
      {
        return Class675.ResourceManager.GetString(nameof (Rotation), Class675.cultureInfo_0);
      }
    }

    internal static string ScaleFactor
    {
      get
      {
        return Class675.ResourceManager.GetString(nameof (ScaleFactor), Class675.cultureInfo_0);
      }
    }
  }
}
