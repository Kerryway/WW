// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.PaperSizes
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Drawing.Printing;

namespace WW.Cad.Drawing
{
  public class PaperSizes
  {
    public static PaperSize GetPaperSize(PaperKind paperKind)
    {
      switch (paperKind)
      {
        case PaperKind.Letter:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(8.5), PaperSizes.smethod_2(11f));
        case PaperKind.LetterSmall:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(8.5), PaperSizes.smethod_2(11f));
        case PaperKind.Tabloid:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_2(11f), PaperSizes.smethod_2(17f));
        case PaperKind.Ledger:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_2(17f), PaperSizes.smethod_2(11f));
        case PaperKind.Legal:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(8.5), PaperSizes.smethod_2(14f));
        case PaperKind.Statement:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(5.5), PaperSizes.smethod_3(8.5));
        case PaperKind.Executive:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(7.25), PaperSizes.smethod_3(10.5));
        case PaperKind.A3:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(297f), PaperSizes.smethod_0(420f));
        case PaperKind.A4:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(210f), PaperSizes.smethod_0(297f));
        case PaperKind.A4Small:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(210f), PaperSizes.smethod_0(297f));
        case PaperKind.A5:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(148f), PaperSizes.smethod_0(210f));
        case PaperKind.B4:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(250f), PaperSizes.smethod_0(353f));
        case PaperKind.B5:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(176f), PaperSizes.smethod_0(250f));
        case PaperKind.Folio:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(8.5), PaperSizes.smethod_2(13f));
        case PaperKind.Quarto:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(215f), PaperSizes.smethod_0(275f));
        case PaperKind.Standard10x14:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_2(10f), PaperSizes.smethod_2(14f));
        case PaperKind.Standard11x17:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_2(11f), PaperSizes.smethod_2(17f));
        case PaperKind.Note:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(8.5), PaperSizes.smethod_2(11f));
        case PaperKind.Number9Envelope:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(3.875), PaperSizes.smethod_3(8.875));
        case PaperKind.Number10Envelope:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(4.125), PaperSizes.smethod_3(9.5));
        case PaperKind.Number11Envelope:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(4.5), PaperSizes.smethod_3(10.375));
        case PaperKind.Number12Envelope:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(4.75), PaperSizes.smethod_2(11f));
        case PaperKind.Number14Envelope:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_2(5f), PaperSizes.smethod_3(11.5));
        case PaperKind.CSheet:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_2(17f), PaperSizes.smethod_2(22f));
        case PaperKind.DSheet:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_2(22f), PaperSizes.smethod_2(34f));
        case PaperKind.ESheet:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_2(34f), PaperSizes.smethod_2(44f));
        case PaperKind.DLEnvelope:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(110f), PaperSizes.smethod_0(220f));
        case PaperKind.C5Envelope:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(162f), PaperSizes.smethod_0(229f));
        case PaperKind.C3Envelope:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(324f), PaperSizes.smethod_0(458f));
        case PaperKind.C4Envelope:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(229f), PaperSizes.smethod_0(324f));
        case PaperKind.C6Envelope:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(114f), PaperSizes.smethod_0(162f));
        case PaperKind.C65Envelope:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(114f), PaperSizes.smethod_0(229f));
        case PaperKind.B4Envelope:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(250f), PaperSizes.smethod_0(353f));
        case PaperKind.B5Envelope:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(176f), PaperSizes.smethod_0(250f));
        case PaperKind.B6Envelope:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(176f), PaperSizes.smethod_0(125f));
        case PaperKind.ItalyEnvelope:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(110f), PaperSizes.smethod_0(230f));
        case PaperKind.MonarchEnvelope:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(3.875), PaperSizes.smethod_3(7.5));
        case PaperKind.PersonalEnvelope:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(3.625), PaperSizes.smethod_3(6.5));
        case PaperKind.USStandardFanfold:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(14.875), PaperSizes.smethod_2(11f));
        case PaperKind.GermanStandardFanfold:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(8.5), PaperSizes.smethod_2(12f));
        case PaperKind.GermanLegalFanfold:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(8.5), PaperSizes.smethod_2(13f));
        case PaperKind.IsoB4:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(250f), PaperSizes.smethod_0(353f));
        case PaperKind.JapanesePostcard:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(100f), PaperSizes.smethod_0(148f));
        case PaperKind.Standard9x11:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_2(9f), PaperSizes.smethod_2(11f));
        case PaperKind.Standard10x11:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_2(10f), PaperSizes.smethod_2(11f));
        case PaperKind.Standard15x11:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_2(15f), PaperSizes.smethod_2(11f));
        case PaperKind.InviteEnvelope:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(220f), PaperSizes.smethod_0(220f));
        case PaperKind.LetterExtra:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(9.275), PaperSizes.smethod_2(12f));
        case PaperKind.LegalExtra:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(9.275), PaperSizes.smethod_2(15f));
        case PaperKind.TabloidExtra:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(11.69), PaperSizes.smethod_2(18f));
        case PaperKind.A4Extra:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(236f), PaperSizes.smethod_0(322f));
        case PaperKind.LetterTransverse:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(8.275), PaperSizes.smethod_2(11f));
        case PaperKind.A4Transverse:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(210f), PaperSizes.smethod_0(297f));
        case PaperKind.LetterExtraTransverse:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(9.275), PaperSizes.smethod_2(12f));
        case PaperKind.APlus:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(227f), PaperSizes.smethod_0(356f));
        case PaperKind.BPlus:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(305f), PaperSizes.smethod_0(487f));
        case PaperKind.LetterPlus:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_3(8.5), PaperSizes.smethod_3(12.69));
        case PaperKind.A4Plus:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(210f), PaperSizes.smethod_0(330f));
        case PaperKind.A5Transverse:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(148f), PaperSizes.smethod_0(210f));
        case PaperKind.B5Transverse:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(182f), PaperSizes.smethod_0(257f));
        case PaperKind.A3Extra:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(322f), PaperSizes.smethod_0(445f));
        case PaperKind.A5Extra:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(174f), PaperSizes.smethod_0(235f));
        case PaperKind.B5Extra:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(201f), PaperSizes.smethod_0(276f));
        case PaperKind.A2:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(420f), PaperSizes.smethod_0(594f));
        case PaperKind.A3Transverse:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(297f), PaperSizes.smethod_0(420f));
        case PaperKind.A3ExtraTransverse:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(322f), PaperSizes.smethod_0(445f));
        case PaperKind.JapaneseDoublePostcard:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(200f), PaperSizes.smethod_0(148f));
        case PaperKind.A6:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(105f), PaperSizes.smethod_0(148f));
        case PaperKind.LetterRotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_2(11f), PaperSizes.smethod_3(8.5));
        case PaperKind.A3Rotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(420f), PaperSizes.smethod_0(297f));
        case PaperKind.A4Rotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(297f), PaperSizes.smethod_0(210f));
        case PaperKind.A5Rotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(210f), PaperSizes.smethod_0(148f));
        case PaperKind.B4JisRotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(364f), PaperSizes.smethod_0(257f));
        case PaperKind.B5JisRotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(257f), PaperSizes.smethod_0(182f));
        case PaperKind.JapanesePostcardRotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(148f), PaperSizes.smethod_0(100f));
        case PaperKind.JapaneseDoublePostcardRotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(148f), PaperSizes.smethod_0(200f));
        case PaperKind.A6Rotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(148f), PaperSizes.smethod_0(105f));
        case PaperKind.B6Jis:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(128f), PaperSizes.smethod_0(182f));
        case PaperKind.B6JisRotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(182f), PaperSizes.smethod_0(128f));
        case PaperKind.Standard12x11:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_2(12f), PaperSizes.smethod_2(11f));
        case PaperKind.Prc16K:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(146f), PaperSizes.smethod_0(215f));
        case PaperKind.Prc32K:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(97f), PaperSizes.smethod_0(151f));
        case PaperKind.Prc32KBig:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(97f), PaperSizes.smethod_0(151f));
        case PaperKind.PrcEnvelopeNumber1:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(102f), PaperSizes.smethod_0(165f));
        case PaperKind.PrcEnvelopeNumber2:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(102f), PaperSizes.smethod_0(176f));
        case PaperKind.PrcEnvelopeNumber3:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(125f), PaperSizes.smethod_0(176f));
        case PaperKind.PrcEnvelopeNumber4:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(110f), PaperSizes.smethod_0(208f));
        case PaperKind.PrcEnvelopeNumber5:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(110f), PaperSizes.smethod_0(220f));
        case PaperKind.PrcEnvelopeNumber6:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(120f), PaperSizes.smethod_0(230f));
        case PaperKind.PrcEnvelopeNumber7:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(160f), PaperSizes.smethod_0(230f));
        case PaperKind.PrcEnvelopeNumber8:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(120f), PaperSizes.smethod_0(309f));
        case PaperKind.PrcEnvelopeNumber9:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(229f), PaperSizes.smethod_0(324f));
        case PaperKind.PrcEnvelopeNumber10:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(324f), PaperSizes.smethod_0(458f));
        case PaperKind.Prc16KRotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(146f), PaperSizes.smethod_0(215f));
        case PaperKind.Prc32KRotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(97f), PaperSizes.smethod_0(151f));
        case PaperKind.Prc32KBigRotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(97f), PaperSizes.smethod_0(151f));
        case PaperKind.PrcEnvelopeNumber1Rotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(165f), PaperSizes.smethod_0(102f));
        case PaperKind.PrcEnvelopeNumber2Rotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(176f), PaperSizes.smethod_0(102f));
        case PaperKind.PrcEnvelopeNumber3Rotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(176f), PaperSizes.smethod_0(125f));
        case PaperKind.PrcEnvelopeNumber4Rotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(208f), PaperSizes.smethod_0(110f));
        case PaperKind.PrcEnvelopeNumber5Rotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(220f), PaperSizes.smethod_0(110f));
        case PaperKind.PrcEnvelopeNumber6Rotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(230f), PaperSizes.smethod_0(120f));
        case PaperKind.PrcEnvelopeNumber7Rotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(230f), PaperSizes.smethod_0(160f));
        case PaperKind.PrcEnvelopeNumber8Rotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(309f), PaperSizes.smethod_0(120f));
        case PaperKind.PrcEnvelopeNumber9Rotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(324f), PaperSizes.smethod_0(229f));
        case PaperKind.PrcEnvelopeNumber10Rotated:
          return new PaperSize(paperKind.ToString(), PaperSizes.smethod_0(458f), PaperSizes.smethod_0(324f));
        default:
          return (PaperSize) null;
      }
    }

    private static int smethod_0(float mm)
    {
      return (int) ((double) mm / 0.254000008106232);
    }

    private static int smethod_1(double mm)
    {
      return (int) (mm / 0.254);
    }

    private static int smethod_2(float inch)
    {
      return (int) (100.0 * (double) inch);
    }

    private static int smethod_3(double inch)
    {
      return (int) (100.0 * inch);
    }
  }
}
