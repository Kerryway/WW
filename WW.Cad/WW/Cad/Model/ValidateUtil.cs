// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.ValidateUtil
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Base;

namespace WW.Cad.Model
{
  public static class ValidateUtil
  {
    public static bool ValidateName(
      object obj,
      string name,
      DxfModel model,
      IList<DxfMessage> messages)
    {
      bool flag = true;
      if (name == null)
      {
        messages.Add(new DxfMessage(DxfStatus.EmptyName, Severity.Error, "target", obj));
        flag = false;
      }
      else if (!model.Header.Dxf15OrHigher)
      {
        foreach (char c in name)
        {
          if (!ValidateUtil.smethod_0(c))
          {
            messages.Add(new DxfMessage(DxfStatus.InvalidName, Severity.Error, "target", obj));
            flag = false;
            break;
          }
        }
        if (name.Length > 31)
        {
          messages.Add(new DxfMessage(DxfStatus.InvalidNameLength, Severity.Error, "target", obj));
          flag = false;
        }
      }
      return flag;
    }

    private static bool smethod_0(char c)
    {
      if (!char.IsLetterOrDigit(c))
        return "$-_*".IndexOf(c) >= 0;
      return true;
    }
  }
}
