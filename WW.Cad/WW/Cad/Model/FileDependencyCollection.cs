// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.FileDependencyCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;

namespace WW.Cad.Model
{
  public class FileDependencyCollection : Dictionary<FileDependency.Key, FileDependency>
  {
    internal FileDependency Add(
      string featureName,
      string filename,
      bool affectsGraphics,
      DxfHandledObject referencingObject)
    {
      FileDependency.Key key = new FileDependency.Key(featureName, filename);
      FileDependency fileDependency;
      if (this.TryGetValue(key, out fileDependency))
      {
        if (!fileDependency.References.Contains(referencingObject))
          fileDependency.References.Add(referencingObject);
      }
      else
      {
        fileDependency = new FileDependency();
        fileDependency.FeatureName = featureName;
        fileDependency.FullFilename = filename;
        fileDependency.AffectsGraphics = affectsGraphics;
        fileDependency.References.Add(referencingObject);
        this.Add(key, fileDependency);
      }
      return fileDependency;
    }

    internal void Remove(string featureName, string filename, DxfHandledObject referencingObject)
    {
      FileDependency.Key key = new FileDependency.Key(featureName, filename);
      FileDependency fileDependency;
      if (!this.TryGetValue(key, out fileDependency))
        return;
      if (fileDependency.References.Contains(referencingObject))
        fileDependency.References.Remove(referencingObject);
      if (fileDependency.References.Count > 0)
        return;
      this.Remove(key);
    }
  }
}
