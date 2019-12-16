// Decompiled with JetBrains decompiler
// Type: ns3.Class300
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class300 : Class285
  {
    private ulong ulong_6;

    public Class300(DxfShape shape)
      : base((DxfEntity) shape)
    {
    }

    public ulong TextStyleHandle
    {
      get
      {
        return this.ulong_6;
      }
      set
      {
        this.ulong_6 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfShape handledObject = (DxfShape) this.HandledObject;
      if (this.ulong_6 != 0UL)
      {
        DxfTextStyle textStyle = modelBuilder.method_4<DxfTextStyle>(this.ulong_6);
        if (textStyle == null)
          return;
        handledObject.SetShape(modelBuilder.Model, textStyle, handledObject.ShapeIndex, true);
      }
      else
      {
        if (handledObject.Name == null)
          return;
        foreach (DxfTextStyle textStyle in (DxfHandledObjectCollection<DxfTextStyle>) modelBuilder.Model.TextStyles)
        {
          if (textStyle.IsShape)
          {
            ShxFile shxFile = modelBuilder.Model.GetShxFile(textStyle.FontFilename);
            if (shxFile != null)
            {
              ushort? indexByDescription = shxFile.GetShapeIndexByDescription(handledObject.Name);
              if (indexByDescription.HasValue)
              {
                handledObject.SetShape(modelBuilder.Model, textStyle, indexByDescription.Value, false);
                break;
              }
            }
          }
        }
      }
    }
  }
}
