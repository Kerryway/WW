// Decompiled with JetBrains decompiler
// Type: WW.Cad.Base.DxfMessage
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using System.Text;

namespace WW.Cad.Base
{
  public class DxfMessage
  {
    private Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();
    private DxfStatus dxfStatus_0;
    private Severity severity_0;

    public DxfMessage(DxfStatus status, Severity severity)
    {
      this.dxfStatus_0 = status;
      this.severity_0 = severity;
    }

    public DxfMessage(
      DxfStatus status,
      Severity severity,
      string parameterKey,
      object parameterValue)
    {
      this.dxfStatus_0 = status;
      this.severity_0 = severity;
      this.dictionary_0.Add(parameterKey, parameterValue);
    }

    public Dictionary<string, object> Parameters
    {
      get
      {
        return this.dictionary_0;
      }
    }

    public DxfStatus Status
    {
      get
      {
        return this.dxfStatus_0;
      }
    }

    public Severity Severity
    {
      get
      {
        return this.severity_0;
      }
    }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append(this.severity_0.ToString());
      sb.Append(": ");
      sb.Append(this.dxfStatus_0.ToString());
      if (this.dictionary_0 != null && this.dictionary_0.Count > 0)
      {
        sb.Append(", for objects ");
        List<string> stringList = new List<string>((IEnumerable<string>) this.dictionary_0.Keys);
        stringList.Sort((IComparer<string>) new CaseInsensitiveStringComparer());
        this.method_0(sb, stringList[0], this.dictionary_0[stringList[0]]);
        for (int index = 1; index < stringList.Count; ++index)
        {
          object o = this.dictionary_0[stringList[index]];
          sb.Append(", ");
          this.method_0(sb, stringList[index], o);
        }
      }
      return sb.ToString();
    }

    private void method_0(StringBuilder sb, string key, object o)
    {
      sb.Append(key + " = ");
      sb.Append(o.ToString());
      sb.Append(" (type: ");
      sb.Append(o.GetType().Name);
      sb.Append(")");
    }
  }
}
