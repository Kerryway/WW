﻿// Decompiled with JetBrains decompiler
// Type: WW.OpenGL.GetTarget
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

namespace WW.OpenGL
{
  public enum GetTarget : uint
  {
    CurrentColor = 2816, // 0x00000B00
    CurrentIndex = 2817, // 0x00000B01
    CurrentNormal = 2818, // 0x00000B02
    CurrentTextureCoords = 2819, // 0x00000B03
    CurrentRasterColor = 2820, // 0x00000B04
    CurrentRasterIndex = 2821, // 0x00000B05
    CurrentRasterTextureCoords = 2822, // 0x00000B06
    CurrentRasterPosition = 2823, // 0x00000B07
    CurrentRasterPositionValid = 2824, // 0x00000B08
    CurrentRasterDistance = 2825, // 0x00000B09
    PointSmooth = 2832, // 0x00000B10
    PointSize = 2833, // 0x00000B11
    PointSizeRange = 2834, // 0x00000B12
    PointSizeGranularity = 2835, // 0x00000B13
    LineSmooth = 2848, // 0x00000B20
    LineWidth = 2849, // 0x00000B21
    LineWidthRange = 2850, // 0x00000B22
    LineWidthGranularity = 2851, // 0x00000B23
    LineStipple = 2852, // 0x00000B24
    LineStipplePattern = 2853, // 0x00000B25
    LineStippleRepeat = 2854, // 0x00000B26
    ListMode = 2864, // 0x00000B30
    MaxListNesting = 2865, // 0x00000B31
    ListBase = 2866, // 0x00000B32
    ListIndex = 2867, // 0x00000B33
    PolygonMode = 2880, // 0x00000B40
    PolygonSmooth = 2881, // 0x00000B41
    PolygonStipple = 2882, // 0x00000B42
    EdgeFlag = 2883, // 0x00000B43
    CullFace = 2884, // 0x00000B44
    CullFaceMode = 2885, // 0x00000B45
    FrontFace = 2886, // 0x00000B46
    Lighting = 2896, // 0x00000B50
    LightModelLocalViewer = 2897, // 0x00000B51
    LightModelTwoSide = 2898, // 0x00000B52
    LightModelAmbient = 2899, // 0x00000B53
    ShadeModel = 2900, // 0x00000B54
    ColorMaterialFace = 2901, // 0x00000B55
    ColorMaterialParameter = 2902, // 0x00000B56
    ColorMaterial = 2903, // 0x00000B57
    Fog = 2912, // 0x00000B60
    FogIndex = 2913, // 0x00000B61
    FogDensity = 2914, // 0x00000B62
    FogStart = 2915, // 0x00000B63
    FogEnd = 2916, // 0x00000B64
    FogMode = 2917, // 0x00000B65
    FogColor = 2918, // 0x00000B66
    DepthRange = 2928, // 0x00000B70
    DepthTest = 2929, // 0x00000B71
    DepthWritemask = 2930, // 0x00000B72
    DepthClearValue = 2931, // 0x00000B73
    DepthFunc = 2932, // 0x00000B74
    AccumClearValue = 2944, // 0x00000B80
    StencilTest = 2960, // 0x00000B90
    StencilClearValue = 2961, // 0x00000B91
    StencilFunc = 2962, // 0x00000B92
    StencilValueMask = 2963, // 0x00000B93
    StencilFail = 2964, // 0x00000B94
    StencilPassDepthFail = 2965, // 0x00000B95
    StencilPassDepthPass = 2966, // 0x00000B96
    StencilRef = 2967, // 0x00000B97
    StencilWritemask = 2968, // 0x00000B98
    MatrixMode = 2976, // 0x00000BA0
    Normalize = 2977, // 0x00000BA1
    Viewport = 2978, // 0x00000BA2
    ModelviewStackDepth = 2979, // 0x00000BA3
    ProjectionStackDepth = 2980, // 0x00000BA4
    TextureStackDepth = 2981, // 0x00000BA5
    ModelviewMatrix = 2982, // 0x00000BA6
    ProjectionMatrix = 2983, // 0x00000BA7
    TextureMatrix = 2984, // 0x00000BA8
    AttribStackDepth = 2992, // 0x00000BB0
    ClientAttribStackDepth = 2993, // 0x00000BB1
    AlphaTest = 3008, // 0x00000BC0
    AlphaTestFunc = 3009, // 0x00000BC1
    AlphaTestRef = 3010, // 0x00000BC2
    Dither = 3024, // 0x00000BD0
    BlendDst = 3040, // 0x00000BE0
    BlendSrc = 3041, // 0x00000BE1
    Blend = 3042, // 0x00000BE2
    LogicOpMode = 3056, // 0x00000BF0
    IndexLogicOp = 3057, // 0x00000BF1
    ColorLogicOp = 3058, // 0x00000BF2
    AuxBuffers = 3072, // 0x00000C00
    DrawBuffer = 3073, // 0x00000C01
    ReadBuffer = 3074, // 0x00000C02
    ScissorBox = 3088, // 0x00000C10
    ScissorTest = 3089, // 0x00000C11
    IndexClearValue = 3104, // 0x00000C20
    IndexWritemask = 3105, // 0x00000C21
    ColorClearValue = 3106, // 0x00000C22
    ColorWritemask = 3107, // 0x00000C23
    IndexMode = 3120, // 0x00000C30
    RgbaMode = 3121, // 0x00000C31
    Doublebuffer = 3122, // 0x00000C32
    Stereo = 3123, // 0x00000C33
    RenderMode = 3136, // 0x00000C40
    PerspectiveCorrectionHint = 3152, // 0x00000C50
    PointSmoothHint = 3153, // 0x00000C51
    LineSmoothHint = 3154, // 0x00000C52
    PolygonSmoothHint = 3155, // 0x00000C53
    FogHint = 3156, // 0x00000C54
    TextureGenS = 3168, // 0x00000C60
    TextureGenT = 3169, // 0x00000C61
    TextureGenR = 3170, // 0x00000C62
    TextureGenQ = 3171, // 0x00000C63
    PixelMapIToISize = 3248, // 0x00000CB0
    PixelMapSToSSize = 3249, // 0x00000CB1
    PixelMapIToRSize = 3250, // 0x00000CB2
    PixelMapIToGSize = 3251, // 0x00000CB3
    PixelMapIToBSize = 3252, // 0x00000CB4
    PixelMapIToASize = 3253, // 0x00000CB5
    PixelMapRToRSize = 3254, // 0x00000CB6
    PixelMapGToGSize = 3255, // 0x00000CB7
    PixelMapBToBSize = 3256, // 0x00000CB8
    PixelMapAToASize = 3257, // 0x00000CB9
    UnpackSwapBytes = 3312, // 0x00000CF0
    UnpackLsbFirst = 3313, // 0x00000CF1
    UnpackRowLength = 3314, // 0x00000CF2
    UnpackSkipRows = 3315, // 0x00000CF3
    UnpackSkipPixels = 3316, // 0x00000CF4
    UnpackAlignment = 3317, // 0x00000CF5
    PackSwapBytes = 3328, // 0x00000D00
    PackLsbFirst = 3329, // 0x00000D01
    PackRowLength = 3330, // 0x00000D02
    PackSkipRows = 3331, // 0x00000D03
    PackSkipPixels = 3332, // 0x00000D04
    PackAlignment = 3333, // 0x00000D05
    MapColor = 3344, // 0x00000D10
    MapStencil = 3345, // 0x00000D11
    IndexShift = 3346, // 0x00000D12
    IndexOffset = 3347, // 0x00000D13
    RedScale = 3348, // 0x00000D14
    RedBias = 3349, // 0x00000D15
    ZoomX = 3350, // 0x00000D16
    ZoomY = 3351, // 0x00000D17
    GreenScale = 3352, // 0x00000D18
    GreenBias = 3353, // 0x00000D19
    BlueScale = 3354, // 0x00000D1A
    BlueBias = 3355, // 0x00000D1B
    AlphaScale = 3356, // 0x00000D1C
    AlphaBias = 3357, // 0x00000D1D
    DepthScale = 3358, // 0x00000D1E
    DepthBias = 3359, // 0x00000D1F
    MaxEvalOrder = 3376, // 0x00000D30
    MaxLights = 3377, // 0x00000D31
    MaxClipPlanes = 3378, // 0x00000D32
    MaxTextureSize = 3379, // 0x00000D33
    MaxPixelMapTable = 3380, // 0x00000D34
    MaxAttribStackDepth = 3381, // 0x00000D35
    MaxModelviewStackDepth = 3382, // 0x00000D36
    MaxNameStackDepth = 3383, // 0x00000D37
    MaxProjectionStackDepth = 3384, // 0x00000D38
    MaxTextureStackDepth = 3385, // 0x00000D39
    MaxViewportDims = 3386, // 0x00000D3A
    MaxClientAttribStackDepth = 3387, // 0x00000D3B
    SubpixelBits = 3408, // 0x00000D50
    IndexBits = 3409, // 0x00000D51
    RedBits = 3410, // 0x00000D52
    GreenBits = 3411, // 0x00000D53
    BlueBits = 3412, // 0x00000D54
    AlphaBits = 3413, // 0x00000D55
    DepthBits = 3414, // 0x00000D56
    StencilBits = 3415, // 0x00000D57
    AccumRedBits = 3416, // 0x00000D58
    AccumGreenBits = 3417, // 0x00000D59
    AccumBlueBits = 3418, // 0x00000D5A
    AccumAlphaBits = 3419, // 0x00000D5B
    NameStackDepth = 3440, // 0x00000D70
    AutoNormal = 3456, // 0x00000D80
    Map1Color4 = 3472, // 0x00000D90
    Map1Index = 3473, // 0x00000D91
    Map1Normal = 3474, // 0x00000D92
    Map1TextureCoord1 = 3475, // 0x00000D93
    Map1TextureCoord2 = 3476, // 0x00000D94
    Map1TextureCoord3 = 3477, // 0x00000D95
    Map1TextureCoord4 = 3478, // 0x00000D96
    Map1Vertex3 = 3479, // 0x00000D97
    Map1Vertex4 = 3480, // 0x00000D98
    Map2Color4 = 3504, // 0x00000DB0
    Map2Index = 3505, // 0x00000DB1
    Map2Normal = 3506, // 0x00000DB2
    Map2TextureCoord1 = 3507, // 0x00000DB3
    Map2TextureCoord2 = 3508, // 0x00000DB4
    Map2TextureCoord3 = 3509, // 0x00000DB5
    Map2TextureCoord4 = 3510, // 0x00000DB6
    Map2Vertex3 = 3511, // 0x00000DB7
    Map2Vertex4 = 3512, // 0x00000DB8
    Map1GridDomain = 3536, // 0x00000DD0
    Map1GridSegments = 3537, // 0x00000DD1
    Map2GridDomain = 3538, // 0x00000DD2
    Map2GridSegments = 3539, // 0x00000DD3
    FeedbackBufferPointer = 3568, // 0x00000DF0
    FeedbackBufferSize = 3569, // 0x00000DF1
    FeedbackBufferType = 3570, // 0x00000DF2
    SelectionBufferPointer = 3571, // 0x00000DF3
    SelectionBufferSize = 3572, // 0x00000DF4
    PolygonOffsetUnits = 10752, // 0x00002A00
    PolygonOffsetFactor = 32824, // 0x00008038
    TextureBinding1D = 32872, // 0x00008068
    TextureBinding2D = 32873, // 0x00008069
    VertexArray = 32884, // 0x00008074
    NormalArray = 32885, // 0x00008075
    ColorArray = 32886, // 0x00008076
    IndexArray = 32887, // 0x00008077
    TextureCoordArray = 32888, // 0x00008078
    EdgeFlagArray = 32889, // 0x00008079
    VertexArraySize = 32890, // 0x0000807A
    VertexArrayType = 32891, // 0x0000807B
    VertexArrayStride = 32892, // 0x0000807C
    NormalArrayType = 32894, // 0x0000807E
    NormalArrayStride = 32895, // 0x0000807F
    ColorArraySize = 32897, // 0x00008081
    ColorArrayType = 32898, // 0x00008082
    ColorArrayStride = 32899, // 0x00008083
    IndexArrayType = 32901, // 0x00008085
    IndexArrayStride = 32902, // 0x00008086
    TextureCoordArraySize = 32904, // 0x00008088
    TextureCoordArrayType = 32905, // 0x00008089
    TextureCoordArrayStride = 32906, // 0x0000808A
    EdgeFlagArrayStride = 32908, // 0x0000808C
    MaxElementsVertices = 33000, // 0x000080E8
    MaxElementsIndices = 33001, // 0x000080E9
  }
}
