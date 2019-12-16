// Decompiled with JetBrains decompiler
// Type: WW.Cad.Base.DxfStatus
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Base
{
  public enum DxfStatus
  {
    Ok = 0,
    InvalidName = 1,
    EmptyName = 2,
    InvalidSplineKnots = 3,
    InvalidSplineWeights = 4,
    UnsupportedDxfVersion = 5,
    InvalidNoOfPointsForSolid = 6,
    InvalidNameLength = 7,
    InvalidVPortHeight = 8,
    HatchPolylineVerticesIdentical = 9,
    ImageNotEnoughBoundaryVertices = 10, // 0x0000000A
    FaceIllegalVertexCount = 11, // 0x0000000B
    CellStyleNeedTextStyle = 12, // 0x0000000C
    UnknownEntity = 13, // 0x0000000D
    DuplicateObjectHandle = 14, // 0x0000000E
    UnresolvedReference = 15, // 0x0000000F
    DxfReadError = 16, // 0x00000010
    ShxFontNotFound = 17, // 0x00000011
    DimStyleAlreadySet = 18, // 0x00000012
    WrongType = 19, // 0x00000013
    MTextMustHaveBackgroundFillInfo = 20, // 0x00000014
    AuditRepairedDuplicateName = 22, // 0x00000016
    TableSharedBorderOverrideConflict = 23, // 0x00000017
    InvalidValue = 24, // 0x00000018
    InvalidXDataGroupCode = 25, // 0x00000019
    ParseByteError = 26, // 0x0000001A
    ParseInt16Error = 27, // 0x0000001B
    ParseUInt16Error = 28, // 0x0000001C
    ParseInt32Error = 29, // 0x0000001D
    ParseUInt32Error = 30, // 0x0000001E
    ParseInt64Error = 31, // 0x0000001F
    ParseUInt64Error = 32, // 0x00000020
    ParseSingleError = 33, // 0x00000021
    ParseDoubleError = 34, // 0x00000022
    ParseIntegralTypeErrorButCouldRoundFromFloatingPoint = 35, // 0x00000023
    BlockLayoutReferenceCorrupt = 36, // 0x00000024
    TableMissesTableStyle = 37, // 0x00000025
    InvalidDoubleSubstitutedWithZero = 38, // 0x00000026
    InvalidXRecordGroupCodeEncounteredValueDiscarded = 39, // 0x00000027
    InvalidMeshFaceVertexIndex = 40, // 0x00000028
    InvalidGroupCode = 41, // 0x00000029
    InvalidPolylineVertexEntityType = 42, // 0x0000002A
    InvalidXRecordGroupCodeEncounteredXRecordDiscarded = 43, // 0x0000002B
    RecursiveBlockInsertRemoved = 44, // 0x0000002C
    MergedDuplicateBlock = 45, // 0x0000002D
    RemovedInvalidLayout = 46, // 0x0000002E
    InvalidPoint = 47, // 0x0000002F
    InvalidVector = 48, // 0x00000030
    InvalidNormal = 49, // 0x00000031
    InvalidDouble = 50, // 0x00000032
    InvalidScale = 51, // 0x00000033
    InvalidXDataValueType = 52, // 0x00000034
    SkippedDuplicateTableRecord = 53, // 0x00000035
  }
}
