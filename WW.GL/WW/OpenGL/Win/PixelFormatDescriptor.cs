// Decompiled with JetBrains decompiler
// Type: WW.OpenGL.Win.PixelFormatDescriptor
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;

namespace WW.OpenGL.Win
{
  public struct PixelFormatDescriptor
  {
    public static PixelFormatDescriptor Empty = new PixelFormatDescriptor();
    private ushort ushort_0;
    private ushort ushort_1;
    private PFD.Flags flags_0;
    private PFD.PixelType pixelType_0;
    private byte byte_0;
    private byte byte_1;
    private byte byte_2;
    private byte byte_3;
    private byte byte_4;
    private byte byte_5;
    private byte byte_6;
    private byte byte_7;
    private byte byte_8;
    private byte byte_9;
    private byte byte_10;
    private byte byte_11;
    private byte byte_12;
    private byte byte_13;
    private byte byte_14;
    private byte byte_15;
    private byte byte_16;
    private PFD.LayerType layerType_0;
    private byte byte_17;
    private uint uint_0;
    private uint uint_1;
    private uint uint_2;
    public static PixelFormatDescriptor RGBA;

    public ushort Size
    {
      get
      {
        return this.ushort_0;
      }
      set
      {
        this.ushort_0 = value;
      }
    }

    public ushort Version
    {
      get
      {
        return this.ushort_1;
      }
      set
      {
        this.ushort_1 = value;
      }
    }

    public PFD.Flags Flags
    {
      get
      {
        return this.flags_0;
      }
      set
      {
        this.flags_0 = value;
      }
    }

    public PFD.PixelType PixelType
    {
      get
      {
        return this.pixelType_0;
      }
      set
      {
        this.pixelType_0 = value;
      }
    }

    public byte ColorBits
    {
      get
      {
        return this.byte_0;
      }
      set
      {
        this.byte_0 = value;
      }
    }

    public byte RedBits
    {
      get
      {
        return this.byte_1;
      }
      set
      {
        this.byte_1 = value;
      }
    }

    public byte RedShift
    {
      get
      {
        return this.byte_2;
      }
      set
      {
        this.byte_2 = value;
      }
    }

    public byte GreenBits
    {
      get
      {
        return this.byte_3;
      }
      set
      {
        this.byte_3 = value;
      }
    }

    public byte GreenShift
    {
      get
      {
        return this.byte_4;
      }
      set
      {
        this.byte_4 = value;
      }
    }

    public byte BlueBits
    {
      get
      {
        return this.byte_5;
      }
      set
      {
        this.byte_5 = value;
      }
    }

    public byte BlueShift
    {
      get
      {
        return this.byte_6;
      }
      set
      {
        this.byte_6 = value;
      }
    }

    public byte AlphaBits
    {
      get
      {
        return this.byte_7;
      }
      set
      {
        this.byte_7 = value;
      }
    }

    public byte AlphaShift
    {
      get
      {
        return this.byte_8;
      }
      set
      {
        this.byte_8 = value;
      }
    }

    public byte AccumBits
    {
      get
      {
        return this.byte_9;
      }
      set
      {
        this.byte_9 = value;
      }
    }

    public byte AccumRedBits
    {
      get
      {
        return this.byte_10;
      }
      set
      {
        this.byte_10 = value;
      }
    }

    public byte AccumGreenBits
    {
      get
      {
        return this.byte_11;
      }
      set
      {
        this.byte_11 = value;
      }
    }

    public byte AccumBlueBits
    {
      get
      {
        return this.byte_12;
      }
      set
      {
        this.byte_12 = value;
      }
    }

    public byte AccumAlphaBits
    {
      get
      {
        return this.byte_13;
      }
      set
      {
        this.byte_13 = value;
      }
    }

    public byte DepthBits
    {
      get
      {
        return this.byte_14;
      }
      set
      {
        this.byte_14 = value;
      }
    }

    public byte StencilBits
    {
      get
      {
        return this.byte_15;
      }
      set
      {
        this.byte_15 = value;
      }
    }

    public byte AuxBuffers
    {
      get
      {
        return this.byte_16;
      }
      set
      {
        this.byte_16 = value;
      }
    }

    public PFD.LayerType LayerType
    {
      get
      {
        return this.layerType_0;
      }
      set
      {
        this.layerType_0 = value;
      }
    }

    public byte Reserved
    {
      get
      {
        return this.byte_17;
      }
      set
      {
        this.byte_17 = value;
      }
    }

    public uint LayerMask
    {
      get
      {
        return this.uint_0;
      }
      set
      {
        this.uint_0 = value;
      }
    }

    public uint VisibleMask
    {
      get
      {
        return this.uint_1;
      }
      set
      {
        this.uint_1 = value;
      }
    }

    public uint DamageMask
    {
      get
      {
        return this.uint_2;
      }
      set
      {
        this.uint_2 = value;
      }
    }

    static PixelFormatDescriptor()
    {
      PixelFormatDescriptor.Empty.Size = (ushort) 40;
      PixelFormatDescriptor.Empty.Version = (ushort) 0;
      PixelFormatDescriptor.Empty.Flags = PFD.Flags.None;
      PixelFormatDescriptor.Empty.PixelType = PFD.PixelType.RGBA;
      PixelFormatDescriptor.Empty.ColorBits = (byte) 0;
      PixelFormatDescriptor.Empty.RedBits = (byte) 0;
      PixelFormatDescriptor.Empty.RedShift = (byte) 0;
      PixelFormatDescriptor.Empty.GreenBits = (byte) 0;
      PixelFormatDescriptor.Empty.GreenShift = (byte) 0;
      PixelFormatDescriptor.Empty.BlueBits = (byte) 0;
      PixelFormatDescriptor.Empty.BlueShift = (byte) 0;
      PixelFormatDescriptor.Empty.AlphaBits = (byte) 0;
      PixelFormatDescriptor.Empty.AlphaShift = (byte) 0;
      PixelFormatDescriptor.Empty.AccumBits = (byte) 0;
      PixelFormatDescriptor.Empty.AccumRedBits = (byte) 0;
      PixelFormatDescriptor.Empty.AccumGreenBits = (byte) 0;
      PixelFormatDescriptor.Empty.AccumBlueBits = (byte) 0;
      PixelFormatDescriptor.Empty.AccumAlphaBits = (byte) 0;
      PixelFormatDescriptor.Empty.DepthBits = (byte) 0;
      PixelFormatDescriptor.Empty.StencilBits = (byte) 0;
      PixelFormatDescriptor.Empty.AuxBuffers = (byte) 0;
      PixelFormatDescriptor.Empty.LayerType = PFD.LayerType.MainPlane;
      PixelFormatDescriptor.Empty.Reserved = (byte) 0;
      PixelFormatDescriptor.Empty.LayerMask = 0U;
      PixelFormatDescriptor.Empty.VisibleMask = 0U;
      PixelFormatDescriptor.Empty.DamageMask = 0U;
      PixelFormatDescriptor.RGBA = new PixelFormatDescriptor();
      PixelFormatDescriptor.RGBA.Size = (ushort) 40;
      PixelFormatDescriptor.RGBA.Version = (ushort) 1;
      PixelFormatDescriptor.RGBA.Flags = PFD.Flags.SupportOpenGL;
      PixelFormatDescriptor.RGBA.PixelType = PFD.PixelType.RGBA;
      PixelFormatDescriptor.RGBA.ColorBits = (byte) 32;
      PixelFormatDescriptor.RGBA.RedBits = (byte) 0;
      PixelFormatDescriptor.RGBA.RedShift = (byte) 0;
      PixelFormatDescriptor.RGBA.GreenBits = (byte) 0;
      PixelFormatDescriptor.RGBA.GreenShift = (byte) 0;
      PixelFormatDescriptor.RGBA.BlueBits = (byte) 0;
      PixelFormatDescriptor.RGBA.BlueShift = (byte) 0;
      PixelFormatDescriptor.RGBA.AlphaBits = (byte) 32;
      PixelFormatDescriptor.RGBA.AlphaShift = (byte) 0;
      PixelFormatDescriptor.RGBA.AccumBits = (byte) 0;
      PixelFormatDescriptor.RGBA.AccumRedBits = (byte) 0;
      PixelFormatDescriptor.RGBA.AccumGreenBits = (byte) 0;
      PixelFormatDescriptor.RGBA.AccumBlueBits = (byte) 0;
      PixelFormatDescriptor.RGBA.AccumAlphaBits = (byte) 0;
      PixelFormatDescriptor.RGBA.DepthBits = (byte) 32;
      PixelFormatDescriptor.RGBA.StencilBits = (byte) 0;
      PixelFormatDescriptor.RGBA.AuxBuffers = (byte) 0;
      PixelFormatDescriptor.RGBA.LayerType = PFD.LayerType.MainPlane;
      PixelFormatDescriptor.RGBA.Reserved = (byte) 0;
      PixelFormatDescriptor.RGBA.LayerMask = 0U;
      PixelFormatDescriptor.RGBA.VisibleMask = 0U;
      PixelFormatDescriptor.RGBA.DamageMask = 0U;
    }

    [SecuritySafeCritical]
    public static PixelFormatDescriptor[] GetSupportedFixelFormatDescriptors(
      IntPtr hdc)
    {
      List<PixelFormatDescriptor> formatDescriptorList = new List<PixelFormatDescriptor>();
      PixelFormatDescriptor empty1 = PixelFormatDescriptor.Empty;
      int num = WGL.DescribePixelFormat(hdc, 1, 40U, ref empty1);
      if (num == 0)
        throw new Win32Exception(Marshal.GetLastWin32Error());
      formatDescriptorList.Add(empty1);
      for (int pixelFormat = 2; pixelFormat <= num; ++pixelFormat)
      {
        PixelFormatDescriptor empty2 = PixelFormatDescriptor.Empty;
        WGL.DescribePixelFormat(hdc, pixelFormat, 40U, ref empty2);
        formatDescriptorList.Add(empty2);
      }
      return formatDescriptorList.ToArray();
    }
  }
}
