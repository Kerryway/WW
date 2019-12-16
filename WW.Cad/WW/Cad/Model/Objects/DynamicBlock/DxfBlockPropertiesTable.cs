// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockPropertiesTable
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockPropertiesTable : DxfBlockSinglePointParameter
  {
    private DxfEvalGraph.GraphNodeId graphNodeId_2;
    private string string_1;
    private string string_2;
    private int int_6;
    private bool bool_2;
    private bool bool_3;
    private bool bool_4;
    private DxfXRecordValue[][] dxfXRecordValue_1;
    private int[] int_7;
    private DxfBlockPropertiesTableColumnDefinition[] dxfBlockPropertiesTableColumnDefinition_0;

    public DxfBlockPropertiesTableColumnDefinition[] ColumnInformation
    {
      get
      {
        return this.dxfBlockPropertiesTableColumnDefinition_0;
      }
      set
      {
        this.dxfBlockPropertiesTableColumnDefinition_0 = value;
      }
    }

    public new DxfEvalGraph.GraphNodeId NodeId
    {
      get
      {
        return this.graphNodeId_2;
      }
      set
      {
        this.graphNodeId_2 = value;
      }
    }

    public int[] DataNodeId
    {
      get
      {
        return this.int_7;
      }
      set
      {
        this.int_7 = value;
      }
    }

    public DxfXRecordValue[][] Data
    {
      get
      {
        return this.dxfXRecordValue_1;
      }
      set
      {
        this.dxfXRecordValue_1 = value;
      }
    }

    public string TableName
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

    public string DescriptionString
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

    public int Unknown1
    {
      get
      {
        return this.int_6;
      }
      set
      {
        this.int_6 = value;
      }
    }

    public bool PropertiesCanBeModifiedIndividually
    {
      get
      {
        return this.bool_2;
      }
      set
      {
        this.bool_2 = value;
      }
    }

    public bool UnknownFlag2
    {
      get
      {
        return this.bool_3;
      }
      set
      {
        this.bool_3 = value;
      }
    }

    public bool UnknownFlag3
    {
      get
      {
        return this.bool_4;
      }
      set
      {
        this.bool_4 = value;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "BLOCKPROPERTIESTABLE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockPropertiesTable";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockPropertiesTable blockPropertiesTable = (DxfBlockPropertiesTable) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (blockPropertiesTable == null)
      {
        blockPropertiesTable = new DxfBlockPropertiesTable();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) blockPropertiesTable);
        blockPropertiesTable.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) blockPropertiesTable;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockPropertiesTable blockPropertiesTable = (DxfBlockPropertiesTable) from;
      this.NodeId = (DxfEvalGraph.GraphNodeId) cloneContext.Clone((IGraphCloneable) blockPropertiesTable.NodeId);
      this.TableName = blockPropertiesTable.TableName;
      this.DescriptionString = blockPropertiesTable.DescriptionString;
      this.Unknown1 = blockPropertiesTable.Unknown1;
      this.PropertiesCanBeModifiedIndividually = blockPropertiesTable.PropertiesCanBeModifiedIndividually;
      this.UnknownFlag2 = blockPropertiesTable.UnknownFlag2;
      this.UnknownFlag3 = blockPropertiesTable.UnknownFlag3;
      if (blockPropertiesTable.Data == null)
      {
        this.Data = (DxfXRecordValue[][]) null;
      }
      else
      {
        this.Data = new DxfXRecordValue[blockPropertiesTable.Data.Length][];
        for (int index1 = 0; index1 < blockPropertiesTable.Data.Length; ++index1)
        {
          int length = blockPropertiesTable.Data[index1] == null ? 0 : blockPropertiesTable.Data[index1].Length;
          this.Data[index1] = new DxfXRecordValue[length];
          for (int index2 = 0; index2 < length; ++index2)
            this.Data[index1][index2] = (DxfXRecordValue) blockPropertiesTable.Data[index1][index2].Clone(cloneContext);
        }
      }
      if (blockPropertiesTable.DataNodeId == null)
      {
        this.DataNodeId = (int[]) null;
      }
      else
      {
        this.DataNodeId = new int[blockPropertiesTable.DataNodeId.Length];
        for (int index = 0; index < blockPropertiesTable.DataNodeId.Length; ++index)
          this.DataNodeId[index] = blockPropertiesTable.DataNodeId[index];
      }
      if (blockPropertiesTable.ColumnInformation == null)
      {
        this.ColumnInformation = (DxfBlockPropertiesTableColumnDefinition[]) null;
      }
      else
      {
        this.ColumnInformation = new DxfBlockPropertiesTableColumnDefinition[blockPropertiesTable.ColumnInformation.Length];
        for (int index = 0; index < blockPropertiesTable.ColumnInformation.Length; ++index)
          this.ColumnInformation[index] = blockPropertiesTable.ColumnInformation[index].Clone(cloneContext) as DxfBlockPropertiesTableColumnDefinition;
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_5.ClassNumber;
    }
  }
}
