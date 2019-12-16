// Decompiled with JetBrains decompiler
// Type: ns2.Class1030
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.Annotations;

namespace ns2
{
  internal class Class1030
  {
    public readonly short short_3 = 77;
    public readonly short short_4 = 78;
    public readonly short short_7 = 82;
    public readonly short short_8 = 80;
    public readonly short short_9 = 79;
    public readonly DxfClass dxfClass_0;
    public readonly DxfClass dxfClass_1;
    public readonly DxfClass dxfClass_2;
    public readonly DxfClass dxfClass_3;
    public readonly DxfClass dxfClass_4;
    public readonly DxfClass dxfClass_5;
    public readonly short short_0;
    public readonly short short_1;
    public readonly DxfClass dxfClass_6;
    public readonly short short_2;
    public readonly DxfClass dxfClass_7;
    public readonly DxfClass dxfClass_8;
    public readonly DxfClass dxfClass_9;
    public readonly DxfClass dxfClass_10;
    public readonly short short_5;
    public readonly DxfClass dxfClass_11;
    public readonly short short_6;
    public readonly DxfClass dxfClass_12;
    public readonly DxfClass dxfClass_13;
    public readonly DxfClass dxfClass_14;
    public readonly DxfClass dxfClass_15;
    public readonly DxfClass dxfClass_16;
    public readonly DxfClass dxfClass_17;
    public readonly DxfClass dxfClass_18;
    public readonly DxfClass dxfClass_19;
    public readonly DxfClass dxfClass_20;
    public readonly DxfClass dxfClass_21;
    public readonly DxfClass dxfClass_22;
    public readonly DxfClass dxfClass_23;
    public readonly Class1030.Class1032 class1032_0;
    public readonly Class1030.Class1031 class1031_0;

    public Class1030(DxfModel model)
    {
      DxfVersion acadVersion = model.Header.AcadVersion;
      if (acadVersion < DxfVersion.Dxf15)
      {
        this.short_4 = DxfHatch.smethod_2(model.Classes).ClassNumber;
        this.short_3 = DxfLwPolyline.smethod_2(model.Classes).ClassNumber;
        this.short_9 = DxfClass.smethod_19(model.Classes).ClassNumber;
      }
      if (acadVersion < DxfVersion.Dxf18)
      {
        this.short_8 = DxfClass.smethod_15(model.Classes).ClassNumber;
        this.short_7 = DxfClass.smethod_16(model.Classes).ClassNumber;
      }
      this.dxfClass_0 = DxfClass.smethod_0(model.Classes);
      this.dxfClass_1 = DxfDataTable.smethod_2(model.Classes);
      this.dxfClass_5 = DxfClass.smethod_1(model.Classes);
      this.short_0 = DxfClass.smethod_20(model.Classes).ClassNumber;
      this.short_1 = DxfClass.smethod_21(model.Classes).ClassNumber;
      this.dxfClass_6 = DxfClass.smethod_5(model.Classes);
      this.dxfClass_14 = DxfClass.smethod_2(model.Classes);
      this.dxfClass_10 = DxfClass.smethod_6(model.Classes);
      this.dxfClass_22 = DxfVisualStyle.smethod_2(model.Classes);
      this.dxfClass_23 = DxfWipeoutVariables.smethod_2(model.Classes);
      this.dxfClass_11 = DxfClass.smethod_7(model.Classes);
      this.short_6 = this.dxfClass_11.ClassNumber;
      this.short_2 = this.dxfClass_6.ClassNumber;
      this.dxfClass_7 = DxfMLeader.smethod_2(model.Classes);
      this.dxfClass_8 = DxfMLeaderStyle.smethod_3(model.Classes);
      this.dxfClass_9 = DxfMLeaderObjectContextData.smethod_16(model.Classes);
      this.short_5 = this.dxfClass_10.ClassNumber;
      this.dxfClass_12 = DxfClass.smethod_3(model.Classes);
      this.dxfClass_16 = DxfClass.smethod_10(model.Classes);
      this.dxfClass_17 = DxfClass.smethod_11(model.Classes);
      this.dxfClass_18 = DxfClass.smethod_14(model.Classes);
      this.dxfClass_15 = DxfClass.smethod_12(model.Classes);
      this.dxfClass_19 = DxfClass.smethod_17(model.Classes);
      this.dxfClass_20 = DxfClass.smethod_18(model.Classes);
      this.dxfClass_21 = DxfTableContent.smethod_2(model.Classes);
      this.dxfClass_2 = DxfField.smethod_2(model.Classes);
      this.dxfClass_3 = DxfFieldList.smethod_2(model.Classes);
      this.dxfClass_4 = DxfGeoData.smethod_2(model.Classes);
      this.dxfClass_13 = DxfPlotSettings.smethod_2(model.Classes);
      this.class1032_0 = new Class1030.Class1032(model);
      this.class1031_0 = new Class1030.Class1031(model);
    }

    internal class Class1031
    {
      public readonly DxfClass dxfClass_0;
      public readonly DxfClass dxfClass_1;
      public readonly DxfClass dxfClass_2;
      public readonly DxfClass dxfClass_3;
      public readonly DxfClass dxfClass_4;
      public readonly DxfClass dxfClass_5;
      public readonly DxfClass dxfClass_6;
      public readonly DxfClass dxfClass_7;
      public readonly DxfClass dxfClass_8;
      public readonly DxfClass dxfClass_9;
      public readonly DxfClass dxfClass_10;
      public readonly DxfClass dxfClass_11;
      public readonly DxfClass dxfClass_12;
      public readonly DxfClass dxfClass_13;
      public readonly DxfClass dxfClass_14;
      public readonly DxfClass dxfClass_15;
      public readonly DxfClass dxfClass_16;

      public Class1031(DxfModel model)
      {
        this.dxfClass_0 = DxfClass.smethod_63(model.Classes);
        this.dxfClass_1 = DxfClass.smethod_64(model.Classes);
        this.dxfClass_2 = DxfClass.smethod_65(model.Classes);
        this.dxfClass_3 = DxfClass.smethod_66(model.Classes);
        this.dxfClass_4 = DxfClass.smethod_67(model.Classes);
        this.dxfClass_5 = DxfClass.smethod_68(model.Classes);
        this.dxfClass_6 = DxfClass.smethod_69(model.Classes);
        this.dxfClass_7 = DxfClass.smethod_70(model.Classes);
        this.dxfClass_8 = DxfClass.smethod_71(model.Classes);
        this.dxfClass_9 = DxfClass.smethod_72(model.Classes);
        this.dxfClass_10 = DxfClass.smethod_73(model.Classes);
        this.dxfClass_11 = DxfClass.smethod_74(model.Classes);
        this.dxfClass_12 = DxfClass.smethod_75(model.Classes);
        this.dxfClass_13 = DxfClass.smethod_76(model.Classes);
        this.dxfClass_14 = DxfClass.smethod_77(model.Classes);
        this.dxfClass_15 = DxfClass.smethod_78(model.Classes);
        this.dxfClass_16 = DxfClass.smethod_79(model.Classes);
      }
    }

    internal class Class1032
    {
      public readonly DxfClass dxfClass_0;
      public readonly DxfClass dxfClass_1;
      public readonly DxfClass dxfClass_2;
      public readonly DxfClass dxfClass_3;
      public readonly DxfClass dxfClass_4;
      public readonly DxfClass dxfClass_5;
      public readonly DxfClass dxfClass_6;
      public readonly DxfClass dxfClass_7;
      public readonly DxfClass dxfClass_8;
      public readonly DxfClass dxfClass_9;
      public readonly DxfClass dxfClass_10;
      public readonly DxfClass dxfClass_11;
      public readonly DxfClass dxfClass_12;
      public readonly DxfClass dxfClass_13;
      public readonly DxfClass dxfClass_14;
      public readonly DxfClass dxfClass_15;
      public readonly DxfClass dxfClass_16;
      public readonly DxfClass dxfClass_17;
      public readonly DxfClass dxfClass_18;
      public readonly DxfClass dxfClass_19;
      public readonly DxfClass dxfClass_20;
      public readonly DxfClass dxfClass_21;
      public readonly DxfClass dxfClass_22;
      public readonly DxfClass dxfClass_23;
      public readonly DxfClass dxfClass_24;
      public readonly DxfClass dxfClass_25;
      public readonly DxfClass dxfClass_26;
      public readonly DxfClass dxfClass_27;
      public readonly DxfClass dxfClass_28;
      public readonly DxfClass dxfClass_29;
      public readonly DxfClass dxfClass_30;
      public readonly DxfClass dxfClass_31;
      public readonly DxfClass dxfClass_32;
      public readonly DxfClass dxfClass_33;
      public readonly DxfClass dxfClass_34;
      public readonly DxfClass dxfClass_35;
      public readonly DxfClass dxfClass_36;
      public readonly DxfClass dxfClass_37;
      public readonly DxfClass dxfClass_38;
      public readonly DxfClass dxfClass_39;

      public Class1032(DxfModel model)
      {
        this.dxfClass_0 = DxfClass.smethod_61(model.Classes);
        this.dxfClass_1 = DxfClass.smethod_22(model.Classes);
        this.dxfClass_2 = DxfClass.smethod_50(model.Classes);
        this.dxfClass_3 = DxfClass.smethod_51(model.Classes);
        this.dxfClass_4 = DxfClass.smethod_52(model.Classes);
        this.dxfClass_5 = DxfClass.smethod_60(model.Classes);
        this.dxfClass_6 = DxfClass.smethod_36(model.Classes);
        this.dxfClass_7 = DxfClass.smethod_37(model.Classes);
        this.dxfClass_8 = DxfClass.smethod_47(model.Classes);
        this.dxfClass_9 = DxfClass.smethod_46(model.Classes);
        this.dxfClass_10 = DxfClass.smethod_48(model.Classes);
        this.dxfClass_11 = DxfClass.smethod_49(model.Classes);
        this.dxfClass_12 = DxfClass.smethod_45(model.Classes);
        this.dxfClass_13 = DxfClass.smethod_38(model.Classes);
        this.dxfClass_14 = DxfClass.smethod_40(model.Classes);
        this.dxfClass_15 = DxfClass.smethod_44(model.Classes);
        this.dxfClass_16 = DxfClass.smethod_39(model.Classes);
        this.dxfClass_17 = DxfClass.smethod_43(model.Classes);
        this.dxfClass_18 = DxfClass.smethod_41(model.Classes);
        this.dxfClass_19 = DxfClass.smethod_42(model.Classes);
        this.dxfClass_20 = DxfClass.smethod_23(model.Classes);
        this.dxfClass_21 = DxfClass.smethod_24(model.Classes);
        this.dxfClass_22 = DxfClass.smethod_25(model.Classes);
        this.dxfClass_23 = DxfClass.smethod_26(model.Classes);
        this.dxfClass_24 = DxfClass.smethod_27(model.Classes);
        this.dxfClass_25 = DxfClass.smethod_28(model.Classes);
        this.dxfClass_26 = DxfClass.smethod_29(model.Classes);
        this.dxfClass_27 = DxfClass.smethod_30(model.Classes);
        this.dxfClass_28 = DxfClass.smethod_31(model.Classes);
        this.dxfClass_29 = DxfClass.smethod_32(model.Classes);
        this.dxfClass_30 = DxfClass.smethod_33(model.Classes);
        this.dxfClass_31 = DxfClass.smethod_34(model.Classes);
        this.dxfClass_32 = DxfClass.smethod_35(model.Classes);
        this.dxfClass_33 = DxfClass.smethod_53(model.Classes);
        this.dxfClass_34 = DxfClass.smethod_54(model.Classes);
        this.dxfClass_35 = DxfClass.smethod_55(model.Classes);
        this.dxfClass_36 = DxfClass.smethod_56(model.Classes);
        this.dxfClass_37 = DxfClass.smethod_57(model.Classes);
        this.dxfClass_38 = DxfClass.smethod_58(model.Classes);
        this.dxfClass_39 = DxfClass.smethod_59(model.Classes);
      }
    }
  }
}
