// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.FileDependency
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using WW.Cad.Base;

namespace WW.Cad.Model
{
  public class FileDependency
  {
    private string string_0 = string.Empty;
    private string string_1 = string.Empty;
    private string string_2 = string.Empty;
    private string string_3 = string.Empty;
    private string string_4 = string.Empty;
    private DateTime dateTime_0 = DxfUtil.DateTimeNow;
    private readonly List<DxfHandledObject> list_0 = new List<DxfHandledObject>();
    public const string XRefFeatureName = "Acad:XRef";
    public const string ImageFeatureName = "Acad:Image";
    public const string PlotConfigFeatureName = "Acad:PlotConfig";
    public const string TextFeatureName = "Acad:Text";
    private int int_0;
    private bool bool_0;

    public FileDependency()
    {
    }

    public FileDependency(FileDependency from, CloneContext cloneContext)
    {
      this.string_0 = from.string_0;
      this.string_1 = from.string_1;
      this.string_2 = from.string_2;
      this.string_3 = from.string_3;
      this.string_4 = from.string_4;
      this.dateTime_0 = from.dateTime_0;
      this.int_0 = from.int_0;
      this.bool_0 = from.bool_0;
      foreach (DxfHandledObject dxfHandledObject in from.list_0)
        this.list_0.Add((DxfHandledObject) dxfHandledObject.Clone(cloneContext));
    }

    public string FeatureName
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

    public string FullFilename
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

    public string FoundPath
    {
      get
      {
        return this.string_2;
      }
      set
      {
        this.string_2 = value;
      }
    }

    public string FingerPrintGuid
    {
      get
      {
        return this.string_3;
      }
      set
      {
        this.string_3 = value;
      }
    }

    public string VersionGuid
    {
      get
      {
        return this.string_4;
      }
      set
      {
        this.string_4 = value;
      }
    }

    public DateTime TimeStamp
    {
      get
      {
        return this.dateTime_0;
      }
      set
      {
        this.dateTime_0 = value;
      }
    }

    public int FileSize
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public bool AffectsGraphics
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

    public List<DxfHandledObject> References
    {
      get
      {
        return this.list_0;
      }
    }

    public override int GetHashCode()
    {
      return this.string_0.GetHashCode() ^ this.string_1.GetHashCode();
    }

    public override bool Equals(object obj)
    {
      FileDependency fileDependency = obj as FileDependency;
      bool flag = false;
      if (fileDependency != null)
        flag = this.string_0 == fileDependency.string_0 && this.string_1 == fileDependency.string_1;
      return flag;
    }

    public class Key
    {
      private string string_0 = string.Empty;
      private string string_1 = string.Empty;

      public Key(string featureName, string fullFilename)
      {
        this.string_0 = featureName;
        this.string_1 = fullFilename;
      }

      public string FeatureName
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

      public string FullFilename
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

      public override int GetHashCode()
      {
        return this.string_0.GetHashCode() ^ this.string_1.GetHashCode();
      }

      public override bool Equals(object obj)
      {
        FileDependency.Key key = obj as FileDependency.Key;
        bool flag = false;
        if (key != null)
          flag = this.string_0 == key.string_0 && this.string_1 == key.string_1;
        return flag;
      }
    }
  }
}
