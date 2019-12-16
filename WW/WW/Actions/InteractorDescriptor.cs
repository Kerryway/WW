// Decompiled with JetBrains decompiler
// Type: WW.Actions.InteractorDescriptor
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Resources;

namespace WW.Actions
{
  public class InteractorDescriptor
  {
    private string string_0 = string.Empty;
    private string string_1 = string.Empty;
    private bool bool_0;
    private ResourceManager resourceManager_0;

    public string Description
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

    public bool HasTransaction
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

    public string DisplayName
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

    public ResourceManager ResourceManager
    {
      get
      {
        return this.resourceManager_0;
      }
      set
      {
        this.resourceManager_0 = value;
      }
    }
  }
}
