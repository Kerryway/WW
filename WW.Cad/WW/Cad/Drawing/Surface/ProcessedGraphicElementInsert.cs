// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.ProcessedGraphicElementInsert
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace WW.Cad.Drawing.Surface
{
  public class ProcessedGraphicElementInsert
  {
    private ProcessedGraphicElementBlock processedGraphicElementBlock_0;
    private ProcessedGraphicElementBlock processedGraphicElementBlock_1;
    private ProcessedGraphicElementInsert.InsertCell[,] insertCell_0;
    private Matrix4D[,] matrix4D_0;

    public ProcessedGraphicElementBlock UnclippedBlock
    {
      get
      {
        return this.processedGraphicElementBlock_0;
      }
      set
      {
        this.processedGraphicElementBlock_0 = value;
      }
    }

    public ProcessedGraphicElementBlock AttributeBlock
    {
      get
      {
        return this.processedGraphicElementBlock_1;
      }
      set
      {
        this.processedGraphicElementBlock_1 = value;
      }
    }

    public ProcessedGraphicElementInsert.InsertCell[,] InsertCells
    {
      get
      {
        return this.insertCell_0;
      }
      set
      {
        this.insertCell_0 = value;
      }
    }

    public Matrix4D[,] AttributeBlockCells
    {
      get
      {
        return this.matrix4D_0;
      }
      set
      {
        this.matrix4D_0 = value;
      }
    }

    public class InsertCell
    {
      private ProcessedGraphicElementBlock processedGraphicElementBlock_0;
      private Matrix4D matrix4D_0;

      public InsertCell()
      {
      }

      public InsertCell(Matrix4D transform)
      {
        this.matrix4D_0 = transform;
      }

      public ProcessedGraphicElementBlock ClippedBlock
      {
        get
        {
          return this.processedGraphicElementBlock_0;
        }
        set
        {
          this.processedGraphicElementBlock_0 = value;
        }
      }

      public Matrix4D Transform
      {
        get
        {
          return this.matrix4D_0;
        }
        set
        {
          this.matrix4D_0 = value;
        }
      }
    }
  }
}
