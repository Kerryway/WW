// Decompiled with JetBrains decompiler
// Type: ns28.Class1048
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.IO;
using System.Text;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.IO;
using WW.Math;

namespace ns28
{
  internal class Class1048 : Interface30
  {
    private readonly Interface30 interface30_0;
    private readonly Interface30 interface30_1;
    private readonly Interface30 interface30_2;

    public Class1048(Interface30 mainReader, Interface30 stringReader, Interface30 handleReader)
    {
      this.interface30_0 = mainReader;
      this.interface30_1 = stringReader;
      this.interface30_2 = handleReader;
    }

    public Interface30 MainReader
    {
      get
      {
        return this.interface30_0;
      }
    }

    public Interface30 StringReader
    {
      get
      {
        return this.interface30_1;
      }
    }

    public Interface30 HandleReader
    {
      get
      {
        return this.interface30_2;
      }
    }

    public void imethod_54(Stream stream, uint sizeInBits)
    {
      throw new NotSupportedException();
    }

    public bool LoggingEnabled
    {
      get
      {
        return this.interface30_0.LoggingEnabled;
      }
      set
      {
        this.interface30_0.LoggingEnabled = value;
        this.interface30_1.LoggingEnabled = value;
        this.interface30_2.LoggingEnabled = value;
      }
    }

    public int BitIndex
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    public uint SizeInBits
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    public void imethod_0(int byteCount)
    {
      throw new NotImplementedException();
    }

    public void imethod_1(int byteCount)
    {
      throw new NotImplementedException();
    }

    public Encoding Encoding
    {
      get
      {
        return this.interface30_0.Encoding;
      }
      set
      {
        this.interface30_0.Encoding = value;
        this.interface30_1.Encoding = value;
        this.interface30_2.Encoding = value;
      }
    }

    public ushort imethod_2(ushort initialCrc, byte[] bytes)
    {
      throw new NotImplementedException();
    }

    public long imethod_3()
    {
      return this.interface30_0.imethod_3();
    }

    public void imethod_4(long bitPosition)
    {
      throw new NotImplementedException();
    }

    public long imethod_5(long stringStreamEndBitPosition)
    {
      throw new NotImplementedException();
    }

    public bool imethod_6()
    {
      return this.interface30_0.imethod_6();
    }

    public short imethod_7()
    {
      return this.interface30_0.imethod_7();
    }

    public double imethod_8()
    {
      return this.interface30_0.imethod_8();
    }

    public Vector3D imethod_9()
    {
      return this.interface30_0.imethod_9();
    }

    public Vector3D imethod_10()
    {
      return this.interface30_0.imethod_10();
    }

    public int imethod_11()
    {
      return this.interface30_0.imethod_11();
    }

    public long imethod_12()
    {
      return this.interface30_0.imethod_12();
    }

    public byte imethod_13()
    {
      return this.interface30_0.imethod_13();
    }

    public short imethod_14()
    {
      return this.interface30_0.imethod_14();
    }

    public bool imethod_15()
    {
      return this.interface30_0.imethod_15();
    }

    public Color imethod_16()
    {
      return this.interface30_0.imethod_16();
    }

    public double imethod_17()
    {
      return this.interface30_0.imethod_17();
    }

    public byte imethod_18()
    {
      return this.interface30_0.imethod_18();
    }

    public byte[] imethod_19(int length)
    {
      return this.interface30_0.imethod_19(length);
    }

    public void imethod_20(int length, PagedMemoryStream targetStream)
    {
      this.interface30_0.imethod_20(length, targetStream);
    }

    public uint imethod_21(PagedMemoryStream targetStream)
    {
      return this.interface30_0.imethod_21(targetStream);
    }

    public Color imethod_23(Interface30 stringReader)
    {
      return this.interface30_0.imethod_23(stringReader);
    }

    public Color imethod_22()
    {
      return this.interface30_0.imethod_23(this.interface30_1);
    }

    public Color imethod_25(Interface30 stringReader)
    {
      return this.interface30_0.imethod_25(stringReader);
    }

    public Color imethod_24()
    {
      return this.interface30_0.imethod_25(this.interface30_1);
    }

    public void imethod_26(
      out EntityColor color,
      out Transparency transparency,
      out bool isColorBookColor)
    {
      this.interface30_0.imethod_26(out color, out transparency, out isColorBookColor);
    }

    public ushort imethod_27()
    {
      throw new NotImplementedException();
    }

    public DateTime imethod_28()
    {
      return this.interface30_0.imethod_28();
    }

    public double imethod_29(double defaultValue)
    {
      return this.interface30_0.imethod_29(defaultValue);
    }

    public string imethod_30()
    {
      return this.interface30_0.imethod_30();
    }

    public ulong imethod_31()
    {
      return this.interface30_0.imethod_32(false);
    }

    public int imethod_35()
    {
      return this.interface30_0.imethod_35();
    }

    public WW.Math.Point2D imethod_36()
    {
      return this.interface30_0.imethod_36();
    }

    public WW.Math.Point2D imethod_37(WW.Math.Point2D defaultPoint)
    {
      return this.interface30_0.imethod_37(defaultPoint);
    }

    public WW.Math.Point2D imethod_38()
    {
      return this.interface30_0.imethod_38();
    }

    public WW.Math.Point3D imethod_39()
    {
      return this.interface30_0.imethod_39();
    }

    public WW.Math.Point3D imethod_40(WW.Math.Point3D defaultPoint)
    {
      return this.interface30_0.imethod_40(defaultPoint);
    }

    public WW.Math.Point3D imethod_41()
    {
      return this.interface30_0.imethod_41();
    }

    public double imethod_42()
    {
      return this.interface30_0.imethod_42();
    }

    public int imethod_43()
    {
      return this.interface30_0.imethod_43();
    }

    public uint imethod_44()
    {
      return this.interface30_0.imethod_44();
    }

    public short imethod_45()
    {
      return this.interface30_0.imethod_45();
    }

    public ulong imethod_46()
    {
      return this.interface30_0.imethod_46();
    }

    public ulong imethod_47()
    {
      return this.interface30_0.imethod_47();
    }

    public DxfTimeSpan imethod_48()
    {
      return this.interface30_0.imethod_48();
    }

    public Vector2D imethod_49()
    {
      return this.interface30_0.imethod_49();
    }

    public Vector2D imethod_50()
    {
      return this.interface30_0.imethod_50();
    }

    public Vector3D imethod_51()
    {
      return this.interface30_0.imethod_51();
    }

    public short imethod_55()
    {
      return this.interface30_0.imethod_55();
    }

    public void imethod_52(int n)
    {
      this.interface30_0.imethod_52(n);
    }

    public void imethod_53(int position)
    {
      throw new NotImplementedException();
    }

    public Stream Stream
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    public long StreamPosition
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    public string ReadString()
    {
      return this.interface30_1.ReadString();
    }

    public ulong imethod_32(bool enqueueForRead)
    {
      return this.interface30_2.imethod_32(enqueueForRead);
    }

    public ulong imethod_33(ulong referenceHandle, bool enqueueForRead)
    {
      return this.interface30_2.imethod_33(referenceHandle, enqueueForRead);
    }

    public ulong imethod_34(
      ulong referenceHandle,
      bool enqueueForRead,
      out ReferenceType referenceType)
    {
      return this.interface30_2.imethod_34(referenceHandle, enqueueForRead, out referenceType);
    }
  }
}
