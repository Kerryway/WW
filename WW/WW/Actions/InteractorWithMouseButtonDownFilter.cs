// Decompiled with JetBrains decompiler
// Type: WW.Actions.InteractorWithMouseButtonDownFilter
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Actions
{
  public class InteractorWithMouseButtonDownFilter : InteractorWrapper
  {
    private MouseButtonFlags mouseButtonFlags_0;

    public InteractorWithMouseButtonDownFilter(IInteractor wrappee)
      : base(wrappee)
    {
    }

    public InteractorWithMouseButtonDownFilter(
      IInteractor wrappee,
      MouseButtonFlags mouseDownButtonFlags)
      : base(wrappee)
    {
      this.mouseButtonFlags_0 = mouseDownButtonFlags;
    }

    public MouseButtonFlags MouseDownButtonFlags
    {
      get
      {
        return this.mouseButtonFlags_0;
      }
      set
      {
        this.mouseButtonFlags_0 = value;
      }
    }

    public override bool ProcessMouseButtonDown(
      CanonicalMouseEventArgs e,
      InteractionContext context)
    {
      if (e.MouseButtonFlags != this.mouseButtonFlags_0)
        return false;
      this.Activate();
      return base.ProcessMouseButtonDown(e, context);
    }
  }
}
