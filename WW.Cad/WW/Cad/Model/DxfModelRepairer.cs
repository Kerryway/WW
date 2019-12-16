// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.DxfModelRepairer
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;

namespace WW.Cad.Model
{
  public class DxfModelRepairer
  {
    private readonly Dictionary<DxfBlock, List<int>> dictionary_0 = new Dictionary<DxfBlock, List<int>>();
    private readonly HashSet<DxfLayout> hashSet_0 = new HashSet<DxfLayout>();
    private readonly DxfModel dxfModel_0;
    private readonly IList<DxfMessage> ilist_0;

    public DxfModelRepairer(DxfModel model, IList<DxfMessage> messages)
    {
      this.dxfModel_0 = model;
      this.ilist_0 = messages;
    }

    public DxfModel Model
    {
      get
      {
        return this.dxfModel_0;
      }
    }

    public IList<DxfMessage> Messages
    {
      get
      {
        return this.ilist_0;
      }
    }

    public void Repair()
    {
      this.dxfModel_0.ExecuteForChildren(new Action(this.Repair));
      this.method_0();
    }

    internal Dictionary<DxfBlock, List<int>> BlockToEntityRemovalIndices
    {
      get
      {
        return this.dictionary_0;
      }
    }

    internal HashSet<DxfLayout> LayoutsToBeRemoved
    {
      get
      {
        return this.hashSet_0;
      }
    }

    private void Repair(DxfHandledObject handledObject)
    {
      handledObject.Repair(this);
    }

    private void method_0()
    {
      foreach (KeyValuePair<DxfBlock, List<int>> keyValuePair in this.dictionary_0)
      {
        if (keyValuePair.Value != null)
        {
          for (int index1 = keyValuePair.Value.Count - 1; index1 >= 0; --index1)
          {
            int index2 = keyValuePair.Value[index1];
            keyValuePair.Key.Entities.RemoveAt(index2);
          }
        }
      }
      for (int index = this.dxfModel_0.Layouts.Count - 1; index >= 0; --index)
      {
        if (this.hashSet_0.Contains(this.dxfModel_0.Layouts[index]))
          this.dxfModel_0.Layouts.RemoveAt(index);
      }
    }

    internal static bool smethod_0(double d)
    {
      return double.IsNaN(d) || d > 1E+100 || d < -1E+100;
    }

    internal bool method_1(DxfHandledObject sourceObject, string fieldName, ref WW.Math.Point3D p)
    {
      bool flag = false;
      string str = (string) null;
      if (DxfModelRepairer.smethod_0(p.X))
      {
        p.X = 0.0;
        flag = true;
        str = "X";
      }
      if (DxfModelRepairer.smethod_0(p.Y))
      {
        p.Y = 0.0;
        flag = true;
        str = !string.IsNullOrEmpty(str) ? str + ", Y" : "Y";
      }
      if (DxfModelRepairer.smethod_0(p.Z))
      {
        p.Z = 0.0;
        flag = true;
        str = !string.IsNullOrEmpty(str) ? str + " and Z" : "Z";
      }
      if (flag)
        this.ilist_0.Add(new DxfMessage(DxfStatus.InvalidPoint, Severity.Warning, "FieldName", (object) fieldName)
        {
          Parameters = {
            {
              "Object",
              (object) sourceObject
            },
            {
              "InvalidCoordinates",
              (object) str
            }
          }
        });
      return flag;
    }

    internal bool method_2(DxfHandledObject sourceObject, string fieldName, ref WW.Math.Vector3D v)
    {
      bool flag = false;
      string str = (string) null;
      if (DxfModelRepairer.smethod_0(v.X))
      {
        v.X = 0.0;
        flag = true;
        str = "X";
      }
      if (DxfModelRepairer.smethod_0(v.Y))
      {
        v.Y = 0.0;
        flag = true;
        str = !string.IsNullOrEmpty(str) ? str + ", Y" : "Y";
      }
      if (DxfModelRepairer.smethod_0(v.Z))
      {
        v.Z = 0.0;
        flag = true;
        str = !string.IsNullOrEmpty(str) ? str + " and Z" : "Z";
      }
      if (flag)
        this.ilist_0.Add(new DxfMessage(DxfStatus.InvalidVector, Severity.Warning, "FieldName", (object) fieldName)
        {
          Parameters = {
            {
              "Object",
              (object) sourceObject
            },
            {
              "InvalidCoordinates",
              (object) str
            }
          }
        });
      return flag;
    }

    internal bool method_3(DxfHandledObject sourceObject, string fieldName, ref double d)
    {
      bool flag = false;
      if (DxfModelRepairer.smethod_0(d))
      {
        d = 1.0;
        flag = true;
      }
      if (flag)
        this.ilist_0.Add(new DxfMessage(DxfStatus.InvalidDouble, Severity.Warning, "FieldName", (object) fieldName)
        {
          Parameters = {
            {
              "Object",
              (object) sourceObject
            }
          }
        });
      return flag;
    }

    internal bool method_4(DxfHandledObject sourceObject, string fieldName, ref double scale)
    {
      bool flag = false;
      if (DxfModelRepairer.smethod_0(scale) || scale == 0.0)
      {
        scale = 1.0;
        flag = true;
      }
      if (flag)
        this.ilist_0.Add(new DxfMessage(DxfStatus.InvalidScale, Severity.Warning, "FieldName", (object) fieldName)
        {
          Parameters = {
            {
              "Object",
              (object) sourceObject
            }
          }
        });
      return flag;
    }

    internal bool method_5(DxfHandledObject sourceObject, string fieldName, ref WW.Math.Vector3D scale)
    {
      bool flag = false;
      string str = (string) null;
      if (DxfModelRepairer.smethod_0(scale.X) || scale.X == 0.0)
      {
        scale.X = 1.0;
        flag = true;
        str = "X";
      }
      if (DxfModelRepairer.smethod_0(scale.Y) || scale.Y == 0.0)
      {
        scale.Y = 1.0;
        flag = true;
        str = !string.IsNullOrEmpty(str) ? str + ", Y" : "Y";
      }
      if (DxfModelRepairer.smethod_0(scale.Z) || scale.Z == 0.0)
      {
        scale.Z = 1.0;
        flag = true;
        str = !string.IsNullOrEmpty(str) ? str + " and Z" : "Z";
      }
      if (flag)
        this.ilist_0.Add(new DxfMessage(DxfStatus.InvalidScale, Severity.Warning, "FieldName", (object) fieldName)
        {
          Parameters = {
            {
              "Object",
              (object) sourceObject
            },
            {
              "InvalidCoordinates",
              (object) str
            }
          }
        });
      return flag;
    }

    internal bool method_6(DxfHandledObject sourceObject, string fieldName, ref WW.Math.Vector3D normal)
    {
      bool flag = false;
      string str = (string) null;
      if (DxfModelRepairer.smethod_0(normal.X))
      {
        flag = true;
        str = "X";
      }
      if (DxfModelRepairer.smethod_0(normal.Y))
      {
        flag = true;
        str = !string.IsNullOrEmpty(str) ? str + ", Y" : "Y";
      }
      if (DxfModelRepairer.smethod_0(normal.Z))
      {
        flag = true;
        str = !string.IsNullOrEmpty(str) ? str + " and Z" : "Z";
      }
      if (flag)
      {
        normal = WW.Math.Vector3D.ZAxis;
        this.ilist_0.Add(new DxfMessage(DxfStatus.InvalidNormal, Severity.Warning, "FieldName", (object) fieldName)
        {
          Parameters = {
            {
              "Object",
              (object) sourceObject
            },
            {
              "InvalidCoordinates",
              (object) str
            }
          }
        });
      }
      return flag;
    }
  }
}
