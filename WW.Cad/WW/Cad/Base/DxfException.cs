// Decompiled with JetBrains decompiler
// Type: WW.Cad.Base.DxfException
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Text;

namespace WW.Cad.Base
{
  public class DxfException : InternalException
  {
    private readonly DxfMessage[] dxfMessage_0;

    public DxfException(string message)
      : base(message)
    {
    }

    public DxfException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    public DxfException(string message, DxfMessage[] dxfMessages)
      : base(message)
    {
      this.dxfMessage_0 = dxfMessages;
    }

    public DxfException(DxfMessage[] dxfMessage)
    {
      this.dxfMessage_0 = dxfMessage;
    }

    public DxfException(DxfMessage cadMessage)
    {
      this.dxfMessage_0 = new DxfMessage[1]{ cadMessage };
    }

    public DxfMessage[] Messages
    {
      get
      {
        return this.dxfMessage_0;
      }
    }

    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(this.Message);
      if (this.dxfMessage_0 != null)
      {
        stringBuilder.Append(Environment.NewLine);
        foreach (DxfMessage dxfMessage in this.dxfMessage_0)
        {
          stringBuilder.Append(dxfMessage.ToString());
          stringBuilder.Append(Environment.NewLine);
        }
      }
      return stringBuilder.ToString();
    }
  }
}
