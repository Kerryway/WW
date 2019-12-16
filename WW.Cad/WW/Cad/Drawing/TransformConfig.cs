// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.TransformConfig
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.ComponentModel;

namespace WW.Cad.Drawing
{
  public class TransformConfig
  {
    private bool bool_0 = true;
    private TransformConfig.HatchPatternTransform hatchPatternTransform_0 = TransformConfig.HatchPatternTransform.CompleteTransform;

    [Browsable(false)]
    public virtual bool TreatAttributesAsPartOfInsert
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

    [Browsable(false)]
    public virtual TransformConfig.HatchPatternTransform HatchPatternHandling
    {
      get
      {
        return this.hatchPatternTransform_0;
      }
      set
      {
        this.hatchPatternTransform_0 = value;
      }
    }

    public enum HatchPatternTransform
    {
      DontTransform,
      OnlyTranslate,
      CompleteTransform,
    }
  }
}
