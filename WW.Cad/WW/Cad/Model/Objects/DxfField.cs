// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfField
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns28;
using System.Collections.Generic;
using WW.Collections.Generic;

namespace WW.Cad.Model.Objects
{
  public class DxfField : DxfObject
  {
    private string string_0 = string.Empty;
    private string string_1 = string.Empty;
    private readonly ActiveList<DxfField> activeList_0 = new ActiveList<DxfField>();
    private readonly List<DxfHandledObject> list_0 = new List<DxfHandledObject>();
    private string string_2 = string.Empty;
    private EvaluationStatusFlags evaluationStatusFlags_0 = EvaluationStatusFlags.NotEvaluated;
    private string string_4 = string.Empty;
    private DxfValue dxfValue_0 = new DxfValue();
    private string string_5 = string.Empty;
    private readonly Dictionary<string, DxfValue> dictionary_0 = new Dictionary<string, DxfValue>();
    private FieldEvaluationOptionFlags fieldEvaluationOptionFlags_0;
    private FilingOptionFlags filingOptionFlags_0;
    private FieldStateFlags fieldStateFlags_0;
    private int int_0;
    private string string_3;

    public DxfField()
    {
      this.activeList_0.Added += new ItemEventHandler<DxfField>(this.method_8);
      this.activeList_0.Set += new ItemSetEventHandler<DxfField>(this.method_9);
      this.activeList_0.Removed += new ItemEventHandler<DxfField>(this.method_10);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_2.ClassNumber;
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf15OrHigher;
    }

    public override string ObjectType
    {
      get
      {
        return "FIELD";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbField";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfField dxfField = (DxfField) from;
      this.string_0 = dxfField.string_0;
      this.string_1 = dxfField.string_1;
      foreach (DxfHandledObject dxfHandledObject in dxfField.activeList_0)
        this.activeList_0.Add((DxfField) dxfHandledObject.Clone(cloneContext));
      if (cloneContext.SourceModel == cloneContext.TargetModel)
      {
        this.list_0.AddRange((IEnumerable<DxfHandledObject>) dxfField.list_0);
      }
      else
      {
        foreach (DxfHandledObject dxfHandledObject in dxfField.list_0)
          this.list_0.Add((DxfHandledObject) dxfHandledObject.Clone(cloneContext));
      }
      this.string_2 = dxfField.string_2;
      this.fieldEvaluationOptionFlags_0 = dxfField.fieldEvaluationOptionFlags_0;
      this.filingOptionFlags_0 = dxfField.filingOptionFlags_0;
      this.fieldStateFlags_0 = dxfField.fieldStateFlags_0;
      this.evaluationStatusFlags_0 = dxfField.evaluationStatusFlags_0;
      this.int_0 = dxfField.int_0;
      this.string_3 = dxfField.string_3;
      this.string_4 = dxfField.string_4;
      this.dxfValue_0 = dxfField.dxfValue_0.Clone(cloneContext);
      this.string_5 = dxfField.string_5;
      foreach (KeyValuePair<string, DxfValue> keyValuePair in dxfField.dictionary_0)
        this.dictionary_0.Add(keyValuePair.Key, this.dxfValue_0.Clone(cloneContext));
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfField dxfField = (DxfField) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfField == null)
      {
        dxfField = new DxfField();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfField);
        dxfField.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfField;
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      foreach (DxfHandledObject dxfHandledObject in this.activeList_0)
        dxfHandledObject.vmethod_1(context);
    }

    protected internal override void ExecuteDeepHelper(
      Action action,
      Stack<DxfHandledObject> callerStack)
    {
      base.ExecuteDeepHelper(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in this.activeList_0)
        dxfHandledObject.vmethod_0(action, callerStack);
    }

    public string EvaluatorId
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value ?? string.Empty;
      }
    }

    public string FieldCode
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value ?? string.Empty;
      }
    }

    public IList<DxfField> ChildFields
    {
      get
      {
        return (IList<DxfField>) this.activeList_0;
      }
    }

    public IList<DxfHandledObject> FieldObjects
    {
      get
      {
        return (IList<DxfHandledObject>) this.list_0;
      }
    }

    public string FormatString
    {
      get
      {
        return this.string_2;
      }
      set
      {
        this.string_2 = value ?? string.Empty;
      }
    }

    public FieldEvaluationOptionFlags EvalutationOptionFlags
    {
      get
      {
        return this.fieldEvaluationOptionFlags_0;
      }
      set
      {
        this.fieldEvaluationOptionFlags_0 = value;
      }
    }

    public FilingOptionFlags FilingOptionFlags
    {
      get
      {
        return this.filingOptionFlags_0;
      }
      set
      {
        this.filingOptionFlags_0 = value;
      }
    }

    public FieldStateFlags FieldStateFlags
    {
      get
      {
        return this.fieldStateFlags_0;
      }
      set
      {
        this.fieldStateFlags_0 = value;
      }
    }

    public EvaluationStatusFlags EvaluationStatusFlags
    {
      get
      {
        return this.evaluationStatusFlags_0;
      }
      set
      {
        this.evaluationStatusFlags_0 = value;
      }
    }

    public int EvaluationErrorCode
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

    public string EvaluationErrorMessage
    {
      get
      {
        return this.string_3;
      }
      set
      {
        this.string_3 = value ?? string.Empty;
      }
    }

    public string Key
    {
      get
      {
        return this.string_4;
      }
      set
      {
        this.string_4 = value ?? string.Empty;
      }
    }

    public DxfValue Value
    {
      get
      {
        return this.dxfValue_0;
      }
    }

    public string ValueString
    {
      get
      {
        return this.string_5;
      }
      set
      {
        this.string_5 = value ?? string.Empty;
      }
    }

    public IDictionary<string, DxfValue> Values
    {
      get
      {
        return (IDictionary<string, DxfValue>) this.dictionary_0;
      }
    }

    internal static DxfClass smethod_2(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "FIELD");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 0;
        dxfClass.ProxyFlags = ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        dxfClass.CPlusPlusClassName = "AcDbField";
        dxfClass.DxfName = "FIELD";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    private void method_8(object sender, int index, DxfField item)
    {
      item.vmethod_2((IDxfHandledObject) this);
    }

    private void method_9(object sender, int index, DxfField oldItem, DxfField newItem)
    {
      if (oldItem == newItem)
        return;
      oldItem.vmethod_2((IDxfHandledObject) null);
      newItem.vmethod_2((IDxfHandledObject) this);
    }

    private void method_10(object sender, int index, DxfField item)
    {
      item.vmethod_2((IDxfHandledObject) null);
    }
  }
}
