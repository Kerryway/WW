// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfProxyEntity
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns2;
using ns28;
using ns3;
using ns35;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WW.Actions;
using WW.Cad.Drawing;
using WW.Cad.IO;
using WW.IO;
using WW.Math;
using WW.Text;

namespace WW.Cad.Model.Entities
{
  public class DxfProxyEntity : DxfEntity
  {
    private List<DxfTypedObjectReference> list_0 = new List<DxfTypedObjectReference>();
    internal const int int_0 = 1024;
    private DxfClass dxfClass_0;
    private ProxyGraphics proxyGraphics_0;
    private DwgVersion dwgVersion_0;
    private short short_1;
    private bool bool_2;
    private long long_0;
    private Stream stream_0;
    private uint uint_0;
    private Stream stream_1;

    public DxfClass OriginalCustomObjectClass
    {
      get
      {
        return this.dxfClass_0;
      }
      set
      {
        this.dxfClass_0 = value;
      }
    }

    public ProxyGraphics ProxyGraphics
    {
      get
      {
        return this.proxyGraphics_0;
      }
      set
      {
        this.proxyGraphics_0 = value;
      }
    }

    public DwgVersion Version
    {
      get
      {
        return this.dwgVersion_0;
      }
      set
      {
        this.dwgVersion_0 = value;
      }
    }

    public short MaintenanceVersion
    {
      get
      {
        return this.short_1;
      }
      set
      {
        this.short_1 = value;
      }
    }

    public bool OriginalCustomObjectDataFormatIsDxf
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

    public long BinaryDataSizeInBits
    {
      get
      {
        return this.long_0;
      }
      set
      {
        this.long_0 = value;
      }
    }

    public Stream BinaryDataStream
    {
      get
      {
        return this.stream_0;
      }
      set
      {
        this.stream_0 = value;
      }
    }

    public uint StringDataSizeInBits
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

    public Stream StringDataStream
    {
      get
      {
        return this.stream_1;
      }
      set
      {
        this.stream_1 = value;
      }
    }

    public IList<DxfTypedObjectReference> ObjectReferences
    {
      get
      {
        return (IList<DxfTypedObjectReference>) this.list_0;
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      if (this.proxyGraphics_0 == null)
        return;
      this.proxyGraphics_0.Draw((DxfEntity) this, context.CreateChildContext((DxfEntity) this, Matrix4D.Identity), graphicsFactory);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      if (this.proxyGraphics_0 == null)
        return;
      this.proxyGraphics_0.Draw((DxfEntity) this, context.CreateChildContext((DxfEntity) this, Matrix4D.Identity), graphicsFactory);
    }

    public override void TransformMe(TransformConfig config, Matrix4D matrix)
    {
      this.TransformMe(config, matrix, (CommandGroup) null);
    }

    public override void TransformMe(
      TransformConfig config,
      Matrix4D matrix,
      CommandGroup undoGroup)
    {
      if (this.proxyGraphics_0 == null)
        return;
      CommandGroup undoGroup1 = undoGroup == null ? (CommandGroup) null : new CommandGroup((object) this);
      this.proxyGraphics_0.TransformMe(config, matrix, undoGroup1);
      undoGroup?.UndoStack.Push((ICommand) undoGroup1);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfProxyEntity dxfProxyEntity = (DxfProxyEntity) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfProxyEntity == null)
      {
        dxfProxyEntity = new DxfProxyEntity();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfProxyEntity);
        dxfProxyEntity.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfProxyEntity;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfProxyEntity dxfProxyEntity = (DxfProxyEntity) from;
      this.dxfClass_0 = dxfProxyEntity.dxfClass_0 != null ? Class906.smethod_9(cloneContext, dxfProxyEntity.dxfClass_0) : (DxfClass) null;
      this.proxyGraphics_0 = dxfProxyEntity.proxyGraphics_0 != null ? (ProxyGraphics) dxfProxyEntity.proxyGraphics_0.Clone(cloneContext) : (ProxyGraphics) null;
      this.dwgVersion_0 = dxfProxyEntity.dwgVersion_0;
      this.short_1 = dxfProxyEntity.short_1;
      this.bool_2 = dxfProxyEntity.bool_2;
      this.long_0 = dxfProxyEntity.long_0;
      if (dxfProxyEntity.stream_0 == null)
      {
        this.stream_0 = (Stream) null;
      }
      else
      {
        long position = dxfProxyEntity.stream_0.Position;
        dxfProxyEntity.stream_0.Position = 0L;
        this.stream_0 = (Stream) new PagedMemoryStream(dxfProxyEntity.stream_0, (long) (int) dxfProxyEntity.stream_0.Length);
        dxfProxyEntity.stream_0.Position = position;
      }
      this.uint_0 = dxfProxyEntity.uint_0;
      if (dxfProxyEntity.stream_1 == null)
      {
        this.stream_1 = (Stream) null;
      }
      else
      {
        long position = dxfProxyEntity.stream_1.Position;
        dxfProxyEntity.stream_1.Position = 0L;
        this.stream_1 = (Stream) new PagedMemoryStream(dxfProxyEntity.stream_1, (long) (int) dxfProxyEntity.stream_1.Length);
        dxfProxyEntity.stream_1.Position = position;
      }
      this.list_0.Clear();
      foreach (DxfTypedObjectReference typedObjectReference in dxfProxyEntity.list_0)
      {
        if (typedObjectReference.ObjectReference.Value == null)
          this.list_0.Add(new DxfTypedObjectReference(typedObjectReference.ReferenceType, DxfObjectReference.Null));
        else
          this.list_0.Add(new DxfTypedObjectReference(typedObjectReference.ReferenceType, cloneContext.CloneReference((DxfHandledObject) typedObjectReference.ObjectReference.Value).Reference));
      }
    }

    public override string EntityType
    {
      get
      {
        return "ACAD_PROXY_ENTITY";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbProxyEntity";
      }
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.AcadVersion > DxfVersion.Dxf14;
    }

    internal override Class259 vmethod_9(FileFormat fileFormat)
    {
      return (Class259) new DxfProxyEntity.Class287(this);
    }

    internal override void Read(Class434 or, Class259 objectBuilder)
    {
      base.Read(or, objectBuilder);
      Interface30 objectBitStream = or.ObjectBitStream;
      int num1;
      if (or.Builder.Version > DxfVersion.Dxf14)
      {
        num1 = objectBitStream.imethod_11();
        if (or.Builder.Version > DxfVersion.Dxf15)
          objectBitStream.ReadString();
        int num2 = objectBitStream.imethod_11();
        this.dwgVersion_0 = (DwgVersion) (num2 & (int) ushort.MaxValue);
        this.short_1 = (short) (num2 >> 16);
        this.bool_2 = objectBitStream.imethod_6();
        if (this.bool_2)
        {
          objectBitStream.imethod_11();
          objectBitStream.imethod_11();
        }
      }
      else
      {
        num1 = objectBitStream.imethod_11();
        objectBitStream.imethod_11();
      }
      this.dxfClass_0 = or.Builder.Model.Classes.GetClassWithClassNumber((short) num1);
      Class1048 class1048 = (Class1048) objectBitStream;
      this.stream_0 = (Stream) new PagedMemoryStream(1024L, 1024);
      this.long_0 = (long) class1048.MainReader.imethod_21((PagedMemoryStream) this.stream_0);
      Class444.Create(or.Builder.Version, this.stream_0);
      if (class1048.StringReader != class1048.MainReader)
      {
        this.stream_1 = (Stream) new PagedMemoryStream(1024L, 1024);
        this.uint_0 = class1048.StringReader.imethod_21((PagedMemoryStream) this.stream_1);
      }
      else
        this.method_13(or.Builder.Version);
      while (class1048.HandleReader.Stream.Position < class1048.HandleReader.Stream.Length)
      {
        ReferenceType referenceType;
        ulong handle = class1048.HandleReader.imethod_34(0UL, true, out referenceType);
        DxfTypedObjectReference typedObjectReference = new DxfTypedObjectReference(referenceType);
        this.list_0.Add(typedObjectReference);
        objectBuilder.ChildBuilders.Add((Interface10) typedObjectReference.method_0(handle));
      }
    }

    private void method_13(DxfVersion fileVersion)
    {
      if (this.bool_2 || this.dwgVersion_0 < DwgVersion.Dwg1021 || (fileVersion <= DxfVersion.Dxf14 || fileVersion >= DxfVersion.Dxf21))
        return;
      if (this.stream_1 != null)
        throw new Exception("String stream is expected to be null.");
      if (this.uint_0 <= 0U)
        return;
      this.stream_1 = (Stream) new PagedMemoryStream(1024L, 1024);
      Class448 class448 = new Class448((DwgReader) null, this.stream_0);
      class448.imethod_5(this.long_0 + (long) this.uint_0);
      int num = (int) class448.imethod_21((PagedMemoryStream) this.stream_1);
    }

    internal override void vmethod_11(Class434 or, Class285 entityBuilder, long imageSize)
    {
      PagedMemoryStream targetStream = new PagedMemoryStream((long) (int) imageSize, System.Math.Min((int) imageSize, 65536));
      or.ObjectBitStream.imethod_20((int) imageSize, targetStream);
      this.proxyGraphics_0 = new ProxyGraphics();
      ((DxfProxyEntity.Class287) entityBuilder).ProxyGraphicsBuilder = this.proxyGraphics_0.Read((Stream) targetStream, or.Builder);
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      Interface29 objectWriter = ow.ObjectWriter;
      if (ow.Version > DxfVersion.Dxf14)
      {
        objectWriter.imethod_33(this.dxfClass_0 == null ? 0 : (int) this.dxfClass_0.ClassNumber);
        if (ow.Version > DxfVersion.Dxf15)
          objectWriter.imethod_4("cn:" + (this.dxfClass_0 == null ? string.Empty : this.dxfClass_0.CPlusPlusClassName));
        objectWriter.imethod_33((int) (this.dwgVersion_0 | (DwgVersion) ((int) this.short_1 << 16)));
        objectWriter.imethod_14(this.bool_2);
        if (this.bool_2)
        {
          objectWriter.imethod_33(this.dxfClass_0 == null ? 0 : (int) this.dxfClass_0.ItemClassId);
          objectWriter.imethod_33(this.dxfClass_0 == null ? 0 : (int) this.dxfClass_0.ClassNumber);
        }
      }
      else
      {
        objectWriter.imethod_33(this.dxfClass_0 == null ? 0 : (int) this.dxfClass_0.ItemClassId);
        objectWriter.imethod_33(this.dxfClass_0 == null ? 0 : (int) this.dxfClass_0.ClassNumber);
      }
      Interface30 binaryDataReader = Class444.Create(ow.Version, this.stream_0);
      binaryDataReader.imethod_4(0L);
      Interface30 stringDataReader = (Interface30) null;
      if (this.stream_1 != null)
      {
        stringDataReader = Class444.Create(ow.Version, this.stream_1);
        stringDataReader.imethod_4(0L);
      }
      if (this.bool_2 && this.method_23(ow.Version))
      {
        DxfProxyEntity.Class362 class362 = new DxfProxyEntity.Class362(this.dwgVersion_0, this.long_0, binaryDataReader, this.uint_0, stringDataReader, this.list_0);
        DxfProxyEntity.Class361 class361 = new DxfProxyEntity.Class361(ow.ObjectWriter);
        while (!class362.IsAtEndOfStream)
          class361.imethod_0(class362.method_0());
      }
      else
      {
        this.method_14(ow.ObjectWriter, this.stream_0, this.long_0);
        if (ow.Version > DxfVersion.Dxf18)
        {
          if (stringDataReader != null && this.uint_0 > 0U)
            this.method_14((Interface29) ((Class990) ow.ObjectWriter).StringBitStreamWriter, this.stream_1, (long) this.uint_0);
        }
        else
          this.method_15(ow.ObjectWriter);
      }
      foreach (DxfTypedObjectReference typedObjectReference in this.list_0)
        objectWriter.imethod_42(typedObjectReference.ReferenceType, (DxfHandledObject) typedObjectReference.ObjectReference.Value);
    }

    private void method_14(Interface29 w, Stream stream, long dataSizeInBits)
    {
      int length1 = (int) (dataSizeInBits >> 3);
      int num1 = (int) dataSizeInBits & 7;
      PagedMemoryStream pagedMemoryStream = stream as PagedMemoryStream;
      if (pagedMemoryStream != null)
      {
        int val2 = length1;
        foreach (byte[] page in pagedMemoryStream.Pages)
        {
          int length2 = System.Math.Min(page.Length, val2);
          if (length2 > 0)
            w.imethod_13(page, 0, length2);
          val2 -= length2;
          if (val2 <= 0)
            break;
        }
      }
      else
      {
        MemoryStream memoryStream = stream as MemoryStream;
        if (memoryStream != null)
        {
          w.imethod_13(memoryStream.GetBuffer(), 0, length1);
        }
        else
        {
          byte[] numArray = new byte[1024];
          int num2 = length1 / 1024;
          for (int index = 0; index < num2; ++index)
          {
            stream.Read(numArray, 0, 1024);
            w.imethod_13(numArray, 0, 1024);
          }
          int num3 = length1 % 1024;
          if (num3 > 0)
          {
            stream.Read(numArray, 0, num3);
            w.imethod_13(numArray, 0, num3);
          }
        }
      }
      if (num1 == 0)
        return;
      stream.Position = (long) length1;
      int num4 = stream.ReadByte();
      for (; num1 > 0; --num1)
      {
        w.imethod_14((num4 & 128) != 0);
        num4 <<= 1;
      }
      stream.Position = 0L;
    }

    private void method_15(Interface29 w)
    {
      if (this.uint_0 > 0U)
      {
        this.method_14(w, this.stream_1, (long) this.uint_0);
        ushort num = (ushort) (this.uint_0 & (uint) short.MaxValue);
        if (this.uint_0 > (uint) short.MaxValue)
        {
          w.imethod_18((short) (this.uint_0 >> 15));
          num |= (ushort) 32768;
        }
        w.imethod_18((short) num);
        w.imethod_14(true);
      }
      else
        w.imethod_14(false);
    }

    internal override void vmethod_12(Class432 ow)
    {
      Interface29 objectWriter = ow.ObjectWriter;
      objectWriter.imethod_14(this.proxyGraphics_0 != null);
      if (this.proxyGraphics_0 == null)
        return;
      PagedMemoryStream from = new PagedMemoryStream(4096L, 4096);
      this.proxyGraphics_0.Write((Stream) from, ow.Model);
      if (ow.Version < DxfVersion.Dxf24)
        objectWriter.imethod_19((int) from.Length);
      else
        objectWriter.imethod_34(from.Length);
      from.Position = 0L;
      Class724.smethod_2(from, objectWriter);
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      base.Read(r, objectBuilder);
      Class285 class285 = (Class285) objectBuilder;
      Interface30 binaryDataReader = (Interface30) null;
      Interface30 stringDataReader = (Interface30) null;
      Stream currentStream = (Stream) null;
      long graphicsDataSizeInBytes = 0;
      PagedMemoryStream graphicsData = (PagedMemoryStream) null;
      r.method_85();
      while (r.CurrentGroup.Code != 0)
      {
        if (r.CurrentGroup.Code == 100)
        {
          switch ((string) r.CurrentGroup.Value)
          {
            case "AcDbZombieEntity":
            case "AcDbProxyEntity":
              this.method_16(r, class285, ref binaryDataReader, ref stringDataReader, ref graphicsDataSizeInBytes, ref graphicsData, ref currentStream);
              continue;
            case "AcDbEntity":
              this.method_8(r, class285);
              continue;
            default:
              if (this.bool_2)
              {
                this.method_18(r, objectBuilder);
                continue;
              }
              continue;
          }
        }
        else
          this.method_9(r, class285);
      }
      this.method_13(r.ModelBuilder.Version);
      if (graphicsData == null)
        return;
      this.proxyGraphics_0 = new ProxyGraphics();
      ((DxfProxyEntity.Class287) class285).ProxyGraphicsBuilder = this.proxyGraphics_0.Read((Stream) graphicsData, (Class374) r.ModelBuilder);
    }

    private void method_16(
      DxfReader r,
      Class285 objectBuilder,
      ref Interface30 binaryDataReader,
      ref Interface30 stringDataReader,
      ref long graphicsDataSizeInBytes,
      ref PagedMemoryStream graphicsData,
      ref Stream currentStream)
    {
      string subclass = (string) r.CurrentGroup.Value;
      r.method_85();
      this.stream_0 = (Stream) null;
      this.stream_1 = (Stream) null;
      while (!r.method_92(subclass))
      {
        if (!this.method_17(r, objectBuilder, ref graphicsDataSizeInBytes, ref graphicsData, ref currentStream))
          r.method_85();
      }
      if (this.stream_0 != null)
      {
        this.stream_0.Position = 0L;
        binaryDataReader = Class444.Create(r.ModelBuilder.Version, this.stream_0);
      }
      if (this.stream_1 == null)
        return;
      this.stream_1.Position = 0L;
      stringDataReader = Class444.Create(r.ModelBuilder.Version, this.stream_1);
    }

    private bool method_17(
      DxfReader r,
      Class285 objectBuilder,
      ref long graphicsDataSizeInBytes,
      ref PagedMemoryStream graphicsData,
      ref Stream currentStream)
    {
      switch (r.CurrentGroup.Code)
      {
        case 1:
          string cPlusPlusClassName = (string) r.CurrentGroup.Value;
          this.dxfClass_0 = r.Model.Classes.GetClassWithCPlusPlusName(cPlusPlusClassName);
          break;
        case 70:
          this.bool_2 = (short) r.CurrentGroup.Value != (short) 0;
          break;
        case 90:
          int num1 = (int) r.CurrentGroup.Value;
          break;
        case 91:
          int num2 = (int) r.CurrentGroup.Value;
          this.dxfClass_0 = r.Model.Classes.GetClassWithClassNumber((short) num2);
          break;
        case 92:
          graphicsDataSizeInBytes = (long) (int) r.CurrentGroup.Value;
          if (graphicsData == null)
            graphicsData = new PagedMemoryStream((long) (int) graphicsDataSizeInBytes, System.Math.Min((int) graphicsDataSizeInBytes, 65536));
          else
            graphicsData.SetLength(graphicsDataSizeInBytes);
          currentStream = (Stream) graphicsData;
          break;
        case 93:
          this.long_0 = (long) (int) r.CurrentGroup.Value;
          if (this.long_0 != 0L)
          {
            int val1 = (int) this.long_0 + 7 >> 3;
            if (this.stream_0 == null)
              this.stream_0 = (Stream) new PagedMemoryStream((long) val1, System.Math.Min(val1, 65536));
            else
              this.stream_0.SetLength((long) val1);
          }
          currentStream = this.stream_0;
          break;
        case 94:
          int num3 = (int) r.CurrentGroup.Value;
          break;
        case 95:
          int num4 = (int) r.CurrentGroup.Value;
          this.dwgVersion_0 = (DwgVersion) (num4 & (int) ushort.MaxValue);
          this.short_1 = (short) (num4 >> 16);
          break;
        case 96:
          this.uint_0 = (uint) (int) r.CurrentGroup.Value;
          if (this.uint_0 != 0U)
          {
            int val1 = (int) (this.uint_0 + 7U >> 3);
            if (this.stream_1 == null)
              this.stream_1 = (Stream) new PagedMemoryStream((long) val1, System.Math.Min(val1, 65536));
            else
              this.stream_1.SetLength((long) val1);
          }
          currentStream = this.stream_1;
          break;
        case 160:
          graphicsDataSizeInBytes = (long) r.CurrentGroup.Value;
          if (graphicsData == null)
            graphicsData = new PagedMemoryStream((long) (int) graphicsDataSizeInBytes, System.Math.Min((int) graphicsDataSizeInBytes, 65536));
          else
            graphicsData.SetLength(graphicsDataSizeInBytes);
          currentStream = (Stream) graphicsData;
          break;
        case 161:
          this.long_0 = (long) r.CurrentGroup.Value;
          if (this.long_0 != 0L)
          {
            int val1 = (int) this.long_0 + 7 >> 3;
            if (this.stream_0 == null)
              this.stream_0 = (Stream) new PagedMemoryStream((long) val1, System.Math.Min(val1, 65536));
            else
              this.stream_0.SetLength((long) val1);
          }
          currentStream = this.stream_0;
          break;
        case 162:
          this.uint_0 = (uint) (long) r.CurrentGroup.Value;
          if (this.uint_0 != 0U)
          {
            int val1 = (int) this.uint_0 + 7 >> 3;
            if (this.stream_1 == null)
              this.stream_1 = (Stream) new PagedMemoryStream((long) val1, System.Math.Min(val1, 65536));
            else
              this.stream_1.SetLength((long) val1);
          }
          currentStream = this.stream_1;
          break;
        case 310:
          if (currentStream == null)
            throw new Exception("No stream size specified.");
          byte[] buffer1 = (byte[]) r.CurrentGroup.Value;
          currentStream.Write(buffer1, 0, buffer1.Length);
          break;
        case 311:
          if (currentStream == null)
            throw new Exception("No stream size specified.");
          if (currentStream != this.stream_1)
            throw new Exception("Wrong stream");
          byte[] buffer2 = (byte[]) r.CurrentGroup.Value;
          currentStream.Write(buffer2, 0, buffer2.Length);
          break;
        case 330:
          this.method_19(r, (Class259) objectBuilder, ReferenceType.SoftPointerReference);
          break;
        case 340:
          this.method_19(r, (Class259) objectBuilder, ReferenceType.HardPointerReference);
          break;
        case 350:
          this.method_19(r, (Class259) objectBuilder, ReferenceType.SoftOwnershipReference);
          break;
        case 360:
          this.method_19(r, (Class259) objectBuilder, ReferenceType.HardOwnershipReference);
          break;
        default:
          return this.method_9(r, objectBuilder);
      }
      r.method_85();
      return true;
    }

    private void method_18(DxfReader r, Class259 objectBuilder)
    {
      this.bool_2 = true;
      DxfVersion version = r.ModelBuilder.Version;
      this.dwgVersion_0 = Class885.smethod_3(version);
      if (this.stream_0 == null)
        this.stream_0 = (Stream) new PagedMemoryStream(1024L, 1024);
      if (this.dwgVersion_0 > DwgVersion.Dwg1018 && this.stream_1 == null)
        this.stream_1 = (Stream) new PagedMemoryStream(1024L, 1024);
      r.method_85();
      Encoding encoding = Encodings.GetEncoding((int) r.Model.Header.DrawingCodePage);
      Interface40 nterface40 = (Interface40) new Class725(this.stream_0, encoding, version);
      DxfProxyEntity.Class361 class361 = new DxfProxyEntity.Class361((Interface29) new Class990((Stream) null, nterface40, this.dwgVersion_0 > DwgVersion.Dwg1018 ? (Interface40) new Class728(this.stream_1, encoding, version) : nterface40, nterface40));
      while (r.CurrentGroup.Code != 0)
      {
        switch (Class820.smethod_2(r.CurrentGroup.Code))
        {
          case Enum5.const_8:
          case Enum5.const_9:
          case Enum5.const_14:
          case Enum5.const_15:
            ulong handle = (ulong) r.CurrentGroup.Value;
            DxfHandledObject dxfHandledObject = new DxfHandledObject();
            dxfHandledObject.SetHandle(handle);
            DxfObjectReference dxfObjectReference = new DxfObjectReference((IDxfHandledObject) dxfHandledObject);
            Struct18 group1 = new Struct18(r.CurrentGroup.Code, (object) dxfObjectReference);
            class361.imethod_0(group1);
            r.method_85();
            continue;
          case Enum5.const_13:
            int code = r.CurrentGroup.Code;
            WW.Math.Point3D point3D = new WW.Math.Point3D((double) r.CurrentGroup.Value, 0.0, 0.0);
            r.method_85();
            if (r.CurrentGroup.Code == code + 10)
            {
              point3D.Y = (double) r.CurrentGroup.Value;
              r.method_85();
              if (r.CurrentGroup.Code == code + 20)
              {
                point3D.Z = (double) r.CurrentGroup.Value;
                r.method_85();
              }
            }
            Struct18 group2 = new Struct18(code, (object) point3D);
            class361.imethod_0(group2);
            continue;
          default:
            class361.imethod_0(r.CurrentGroup);
            r.method_85();
            continue;
        }
      }
    }

    private void method_19(DxfReader r, Class259 objectBuilder, ReferenceType referenceType)
    {
      DxfTypedObjectReference typedObjectReference = new DxfTypedObjectReference(referenceType);
      this.list_0.Add(typedObjectReference);
      objectBuilder.ChildBuilders.Add((Interface10) typedObjectReference.method_0((ulong) r.CurrentGroup.Value));
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      if (this.method_24(true, w.Version))
      {
        this.method_20(w);
      }
      else
      {
        if (w.Version < DxfVersion.Dxf14)
          w.method_234("AcDbZombieEntity");
        else
          w.method_234(this.AcClass);
        w.Write(90, (object) (this.dxfClass_0 == null ? 498 : (int) this.dxfClass_0.ItemClassId));
        w.Write(91, (object) (this.dxfClass_0 == null ? 568 : (int) this.dxfClass_0.ClassNumber));
        if (w.Version > DxfVersion.Dxf14)
        {
          w.Write(95, (object) (int) (this.dwgVersion_0 | (DwgVersion) ((int) this.short_1 << 16)));
          w.method_221(70, this.bool_2);
        }
        if (this.proxyGraphics_0 != null)
        {
          PagedMemoryStream pagedMemoryStream = new PagedMemoryStream(4096L, 4096);
          this.proxyGraphics_0.Write((Stream) pagedMemoryStream, w.Model);
          pagedMemoryStream.Position = 0L;
          this.method_22(w, 92, 160, pagedMemoryStream.Length);
          w.method_145(310, (Stream) pagedMemoryStream, (int) pagedMemoryStream.Length);
        }
        else
        {
          this.method_22(w, 92, 160, 8L);
          DxfWriter dxfWriter = w;
          byte[] numArray1 = new byte[8];
          numArray1[0] = (byte) 8;
          byte[] numArray2 = numArray1;
          dxfWriter.Write(310, (object) numArray2);
        }
        if (this.bool_2)
        {
          this.method_20(w);
        }
        else
        {
          PagedMemoryStream stream0 = this.stream_0 as PagedMemoryStream;
          PagedMemoryStream binData;
          if (stream0 == null)
          {
            binData = new PagedMemoryStream((long) (int) this.stream_0.Length);
            this.stream_0.Position = 0L;
            binData.Write(this.stream_0, (int) this.stream_0.Length);
          }
          else
            binData = stream0.Clone();
          long binDataSizeInBits = this.long_0;
          if (w.Version >= DxfVersion.Dxf21)
          {
            if (this.uint_0 > 0U)
            {
              this.method_22(w, 96, 162, (long) this.uint_0);
              this.stream_1.Position = 0L;
              w.method_145(311, this.stream_1, (int) (this.uint_0 + 7U >> 3));
            }
          }
          else if (this.dwgVersion_0 > DwgVersion.Dwg1018)
            binDataSizeInBits = this.method_21(w, binData, binDataSizeInBits);
          this.method_22(w, 93, 161, binDataSizeInBits);
          binData.Position = 0L;
          w.method_145(310, (Stream) binData, (int) (binDataSizeInBits + 7L >> 3));
          if (this.list_0.Count <= 0)
            return;
          foreach (DxfTypedObjectReference typedObjectReference in this.list_0)
          {
            int code;
            switch (typedObjectReference.ReferenceType)
            {
              case ReferenceType.SoftPointerReference:
                code = 330;
                break;
              case ReferenceType.HardPointerReference:
                code = 340;
                break;
              case ReferenceType.SoftOwnershipReference:
                code = 350;
                break;
              case ReferenceType.HardOwnershipReference:
                code = 360;
                break;
              default:
                throw new Exception("Unexpected reference type " + (object) typedObjectReference.ReferenceType + ".");
            }
            w.method_218(code, (DxfHandledObject) typedObjectReference.ObjectReference.Value);
          }
          w.Write(94, (object) 0);
        }
      }
    }

    private void method_20(DxfWriter w)
    {
      Interface30 binaryDataReader = Class444.Create(w.Version, this.stream_0);
      binaryDataReader.imethod_4(0L);
      Interface30 stringDataReader = (Interface30) null;
      if (this.stream_1 != null)
      {
        stringDataReader = Class444.Create(w.Version, this.stream_1);
        stringDataReader.imethod_4(0L);
      }
      DxfProxyEntity.Class362 class362 = new DxfProxyEntity.Class362(this.dwgVersion_0, this.long_0, binaryDataReader, this.uint_0, stringDataReader, this.list_0);
      while (!class362.IsAtEndOfStream)
      {
        Struct18 group = class362.method_0();
        w.Write(group);
      }
    }

    private long method_21(DxfWriter w, PagedMemoryStream binData, long binDataSizeInBits)
    {
      Class724 class724 = (Class724) Class724.smethod_0(Class885.smethod_4(this.dwgVersion_0), (Stream) binData, Encodings.GetEncoding((int) w.Model.Header.DrawingCodePage));
      class724.imethod_47(binDataSizeInBits);
      if (this.uint_0 > 0U)
      {
        this.stream_1.Position = 0L;
        this.method_14((Interface29) class724, this.stream_1, (long) this.uint_0);
        class724.imethod_50((long) this.uint_0);
      }
      class724.imethod_14(this.uint_0 > 0U);
      binDataSizeInBits += (long) this.uint_0;
      return binDataSizeInBits;
    }

    private void method_22(DxfWriter w, int int32GroupCode, int int64GroupCode, long value)
    {
      if (w.Version > DxfVersion.Dxf21)
        w.Write(int64GroupCode, (object) value);
      else
        w.Write(int32GroupCode, (object) (int) value);
    }

    internal override short vmethod_6(Class432 w)
    {
      return 498;
    }

    internal static DxfClass smethod_2(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "ACAD_PROXY_ENTITY");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg0;
        dxfClass.MaintenanceVersion = (short) 0;
        dxfClass.ProxyFlags = ProxyFlags.None;
        dxfClass.CPlusPlusClassName = "AcDbProxyEntity";
        dxfClass.DxfName = "ACAD_PROXY_ENTITY";
        dxfClass.ItemClassId = (short) 498;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    private bool FormatIsLessThanOrEqualToDxfR18
    {
      get
      {
        return this.uint_0 == 0U;
      }
    }

    private bool method_23(DxfVersion version)
    {
      return version > DxfVersion.Dxf18 == this.FormatIsLessThanOrEqualToDxfR18;
    }

    private bool method_24(bool writeToDxf, DxfVersion fileVersion)
    {
      DwgVersion dwgVersion = Class885.smethod_3(fileVersion);
      if (writeToDxf != this.bool_2)
        return false;
      if (this.dwgVersion_0 == dwgVersion)
        return true;
      if (this.dwgVersion_0 < dwgVersion)
        return dwgVersion <= DwgVersion.Dwg1014;
      return false;
    }

    internal class Class361 : Interface13
    {
      private Interface29 interface29_0;

      public Class361(Interface29 w)
      {
        this.interface29_0 = w;
      }

      public void imethod_0(Struct18 group)
      {
        this.interface29_0.imethod_32((short) group.Code);
        Enum5 enum5 = Class820.smethod_2(group.Code);
        switch (enum5)
        {
          case Enum5.const_1:
            this.interface29_0.imethod_14((bool) group.Value);
            break;
          case Enum5.const_2:
            this.interface29_0.imethod_11((byte) group.Value);
            break;
          case Enum5.const_3:
            byte[] bytes = (byte[]) group.Value;
            this.interface29_0.imethod_32((short) bytes.Length);
            this.interface29_0.imethod_12(bytes);
            break;
          case Enum5.const_4:
            this.interface29_0.imethod_16((double) group.Value);
            break;
          case Enum5.const_5:
            this.interface29_0.imethod_37((byte) 0, (ulong) group.Value);
            break;
          case Enum5.const_6:
            this.interface29_0.imethod_37((byte) 0, DxfHandledObject.Parse((string) group.Value));
            break;
          case Enum5.const_7:
            throw new Exception("Object ID is not supported.");
          case Enum5.const_8:
            this.interface29_0.imethod_41((DxfHandledObject) ((DxfObjectReference) group.Value).Value);
            break;
          case Enum5.const_9:
            this.interface29_0.imethod_39((DxfHandledObject) ((DxfObjectReference) group.Value).Value);
            break;
          case Enum5.const_10:
          case Enum5.const_17:
            this.interface29_0.imethod_32((short) group.Value);
            break;
          case Enum5.const_11:
            this.interface29_0.imethod_33((int) group.Value);
            break;
          case Enum5.const_12:
            this.interface29_0.imethod_34((long) group.Value);
            break;
          case Enum5.const_13:
            this.interface29_0.imethod_24((WW.Math.Point3D) group.Value);
            break;
          case Enum5.const_14:
            this.interface29_0.imethod_38((DxfHandledObject) ((DxfObjectReference) group.Value).Value);
            break;
          case Enum5.const_15:
            this.interface29_0.imethod_40((DxfHandledObject) ((DxfObjectReference) group.Value).Value);
            break;
          case Enum5.const_16:
            this.interface29_0.imethod_4((string) group.Value);
            break;
          default:
            throw new Exception("Unsupported group value type " + (object) enum5 + ".");
        }
      }

      public void imethod_1(int baseCode, Struct18 group)
      {
        throw new NotImplementedException();
      }

      public void imethod_2(Struct18 group)
      {
        throw new NotImplementedException();
      }

      public void imethod_3(Struct18 group)
      {
        throw new NotImplementedException();
      }

      public void imethod_4(Struct18 group)
      {
        throw new NotImplementedException();
      }

      public void Flush()
      {
        throw new NotImplementedException();
      }

      public void imethod_5()
      {
      }
    }

    internal class Class362
    {
      private long long_0;
      private Interface30 interface30_0;
      private uint uint_0;
      private Interface30 interface30_1;
      private List<DxfTypedObjectReference> list_0;
      private int int_0;

      public Class362(
        DwgVersion version,
        long binaryDataSizeInBits,
        Interface30 binaryDataReader,
        uint stringDataSizeInBits,
        Interface30 stringDataReader,
        List<DxfTypedObjectReference> objectReferences)
      {
        this.long_0 = binaryDataSizeInBits;
        this.interface30_0 = binaryDataReader;
        if (version < DwgVersion.Dwg1021)
        {
          this.uint_0 = 0U;
          this.interface30_1 = binaryDataReader;
        }
        else
        {
          this.uint_0 = stringDataSizeInBits;
          this.interface30_1 = stringDataReader;
        }
        this.list_0 = objectReferences;
      }

      public bool IsAtEndOfStream
      {
        get
        {
          return (long) this.interface30_0.BitIndex >= this.long_0;
        }
      }

      public Struct18 method_0()
      {
        short num = this.method_1();
        Enum5 enum5 = Class820.smethod_2((int) num);
        object obj;
        switch (enum5)
        {
          case Enum5.const_1:
            obj = (object) this.interface30_0.imethod_6();
            break;
          case Enum5.const_2:
            obj = (object) this.interface30_0.imethod_18();
            break;
          case Enum5.const_3:
            obj = (object) this.interface30_0.imethod_19((int) this.interface30_0.imethod_14());
            break;
          case Enum5.const_4:
            obj = (object) this.interface30_0.imethod_8();
            break;
          case Enum5.const_5:
            obj = (object) DxfHandledObject.Parse(this.interface30_1.ReadString());
            break;
          case Enum5.const_6:
            obj = (object) this.interface30_1.ReadString();
            break;
          case Enum5.const_7:
            throw new Exception("Object ID is not supported.");
          case Enum5.const_8:
          case Enum5.const_9:
          case Enum5.const_14:
          case Enum5.const_15:
            obj = (object) this.list_0[this.int_0++].ObjectReference;
            break;
          case Enum5.const_10:
          case Enum5.const_17:
            obj = (object) this.interface30_0.imethod_14();
            break;
          case Enum5.const_11:
            obj = (object) this.interface30_0.imethod_11();
            break;
          case Enum5.const_12:
            obj = (object) this.interface30_0.imethod_12();
            break;
          case Enum5.const_13:
            obj = (object) this.interface30_0.imethod_39();
            break;
          case Enum5.const_16:
            obj = (object) this.interface30_1.ReadString();
            break;
          default:
            throw new Exception("Unsupported group value type " + (object) enum5 + ".");
        }
        return new Struct18((int) num, obj);
      }

      private short method_1()
      {
        return this.interface30_0.imethod_14();
      }
    }

    internal class Class287 : Class285
    {
      private ProxyGraphics.Class758 class758_0;

      public Class287(DxfProxyEntity entity)
        : base((DxfEntity) entity)
      {
      }

      public ProxyGraphics.Class758 ProxyGraphicsBuilder
      {
        get
        {
          return this.class758_0;
        }
        set
        {
          this.class758_0 = value;
        }
      }

      public override void ResolveReferences(Class374 modelBuilder)
      {
        base.ResolveReferences(modelBuilder);
        if (this.class758_0 == null)
          return;
        this.class758_0.ResolveReferences(modelBuilder);
      }
    }

    private class Class363 : IDxfHandledObject
    {
      private ulong ulong_0;

      public Class363(ulong handle)
      {
        this.ulong_0 = handle;
      }

      public ulong Handle
      {
        get
        {
          return this.ulong_0;
        }
      }

      public IDxfHandledObject OwnerObjectSoftReference
      {
        get
        {
          throw new NotImplementedException();
        }
      }

      public DxfObjectReference Reference
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
    }
  }
}
