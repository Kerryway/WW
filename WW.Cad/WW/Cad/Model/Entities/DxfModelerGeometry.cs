// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfModelerGeometry
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns7;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WW.Actions;
using WW.Cad.Drawing;
using WW.Math;
using WW.Text;

namespace WW.Cad.Model.Entities
{
  public abstract class DxfModelerGeometry : DxfEntity
  {
    public static readonly byte[] BinaryFilePrefix = Encodings.Ascii.GetBytes("ACIS BinaryFile");
    private static readonly byte[] byte_0 = Encodings.Ascii.GetBytes("End-of-ACIS-data");
    private static readonly byte[] byte_1 = Encodings.Ascii.GetBytes("End-of-ASM-data");
    private static readonly byte[][] byte_2 = new byte[4][]{ Encodings.Ascii.GetBytes("End"), Encodings.Ascii.GetBytes("of"), Encodings.Ascii.GetBytes("ACIS"), Encodings.Ascii.GetBytes("data") };
    private static readonly byte[][] byte_3 = new byte[4][]{ Encodings.Ascii.GetBytes("End"), Encodings.Ascii.GetBytes("of"), Encodings.Ascii.GetBytes("ASM"), Encodings.Ascii.GetBytes("data") };
    private string string_1 = "";
    private Guid guid_0 = Guid.Empty;
    private List<Wire> list_0 = new List<Wire>();
    private List<Silhouette> list_1 = new List<Silhouette>();
    private List<ModelerGeometryMaterial> list_2 = new List<ModelerGeometryMaterial>();
    public const string LineFeed = "\r\n";
    private const char char_0 = '_';
    private const char char_1 = '^';
    private const char char_2 = '?';
    private const char char_3 = '\x009F';
    private const char char_4 = ' ';
    private const char char_5 = ' ';
    private const string string_0 = "ACIS BinaryFile";
    private int int_0;
    private MemoryStream memoryStream_0;
    private WW.Math.Point3D? nullable_0;

    protected DxfModelerGeometry()
    {
      this.int_0 = 1;
    }

    protected DxfModelerGeometry(DxfModelerGeometry entity)
      : base((DxfEntity) entity)
    {
      this.string_1 = entity.string_1;
      this.int_0 = entity.int_0;
    }

    public override EntityColor Color
    {
      get
      {
        return base.Color;
      }
      set
      {
        base.Color = value;
        Class795 class795 = this.method_15(Class795.Enum30.const_0, true);
        if (class795 == null || !class795.vmethod_1())
          return;
        if (this.IsSab)
        {
          MemoryStream content = new MemoryStream();
          int version = class795.Header.Version;
          class795.WriteTo(content, version);
          this.memoryStream_0 = content;
        }
        else
        {
          int version = class795.Header.Version;
          string content;
          class795.WriteTo(version, out content);
          this.string_1 = content;
        }
      }
    }

    public Guid Guid
    {
      get
      {
        return this.guid_0;
      }
      set
      {
        this.guid_0 = value;
      }
    }

    public int SATVersion
    {
      get
      {
        return this.method_14(Class795.Enum30.const_1).Header.Version;
      }
    }

    public int AcisFormatIntegrationVersion
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public string SatText
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

    public MemoryStream SabStream
    {
      get
      {
        return this.memoryStream_0;
      }
      set
      {
        this.memoryStream_0 = value;
      }
    }

    public bool IsSab
    {
      get
      {
        if (this.SabStream != null)
          return this.SabStream.Length != 0L;
        return false;
      }
    }

    public bool IsEmpty
    {
      get
      {
        if (this.SabStream != null && this.SabStream.Length != 0L)
          return false;
        return this.SatText.Length == 0;
      }
    }

    public MemoryStream SabStreamFromSAT
    {
      get
      {
        if (this.IsSab)
          return (MemoryStream) null;
        Class795 class795 = this.method_14(Class795.Enum30.const_0);
        MemoryStream content = new MemoryStream();
        int version = class795.Header.Version;
        class795.WriteTo(content, version);
        if (version >= 21800)
          content.Write(DxfModelerGeometry.byte_1, 0, DxfModelerGeometry.byte_1.Length);
        else
          content.Write(DxfModelerGeometry.byte_0, 0, DxfModelerGeometry.byte_0.Length);
        content.Seek(0L, SeekOrigin.Begin);
        return content;
      }
    }

    public string[] EncriptedSatStreamFromSabTextLines
    {
      get
      {
        return DxfModelerGeometry.smethod_4(this.EncriptedSatStreamFromSab);
      }
    }

    public string EncriptedSatStreamFromSab
    {
      get
      {
        return DxfModelerGeometry.Encrypt(this.SatStreamFromSab);
      }
    }

    public string SatStreamFromSab
    {
      get
      {
        if (!this.IsSab)
          return (string) null;
        Class795 class795 = this.method_14(Class795.Enum30.const_0);
        int version = class795.Header.Version;
        string content;
        class795.WriteTo(version, out content);
        return content;
      }
    }

    public string EncryptedSatText
    {
      get
      {
        return DxfModelerGeometry.Encrypt(this.string_1);
      }
      set
      {
        this.string_1 = DxfModelerGeometry.Decrypt(value);
      }
    }

    public string[] SatTextLines
    {
      get
      {
        return DxfModelerGeometry.smethod_4(this.SatText);
      }
      set
      {
        this.string_1 = string.Join("\r\n", value) + "\r\n";
      }
    }

    public string[] EncryptedSatTextLines
    {
      get
      {
        return DxfModelerGeometry.smethod_4(this.EncryptedSatText);
      }
      set
      {
        this.EncryptedSatText = string.Join("\r\n", value) + "\r\n";
      }
    }

    public WW.Math.Point3D? Center
    {
      get
      {
        return this.nullable_0;
      }
      internal set
      {
        this.nullable_0 = value;
      }
    }

    public List<Wire> Wires
    {
      get
      {
        return this.list_0;
      }
    }

    public IList<Silhouette> Silhouettes
    {
      get
      {
        return (IList<Silhouette>) this.list_1;
      }
    }

    public IList<ModelerGeometryMaterial> Materials
    {
      get
      {
        return (IList<ModelerGeometryMaterial>) this.list_2;
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbModelerGeometry";
      }
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfModelerGeometry dxfModelerGeometry = (DxfModelerGeometry) from;
      this.string_1 = dxfModelerGeometry.string_1;
      this.int_0 = dxfModelerGeometry.int_0;
      if (dxfModelerGeometry.memoryStream_0 == null)
        this.memoryStream_0 = (MemoryStream) null;
      else
        this.memoryStream_0 = new MemoryStream(dxfModelerGeometry.memoryStream_0.GetBuffer(), 0, (int) dxfModelerGeometry.memoryStream_0.Length, true, true);
    }

    public virtual bool Transformation(ref Matrix4D transform)
    {
      Class795 class795 = this.method_14(Class795.Enum30.const_0);
      if (class795 == null)
        throw new Exception0("Empty SAT\\SAB stream");
      return class795.vmethod_0(ref transform);
    }

    public virtual void ApplyTransformation(Matrix4D transform)
    {
      Class795 class795 = this.method_14(Class795.Enum30.const_0);
      if (class795 == null)
        throw new Exception0("Empty SAT\\SAB stream");
      class795.ApplyTransformation(transform);
      if (this.IsSab)
      {
        MemoryStream content = new MemoryStream();
        int version = class795.Header.Version;
        class795.WriteTo(content, version);
        this.memoryStream_0 = content;
      }
      else
      {
        int version = class795.Header.Version;
        string content;
        class795.WriteTo(version, out content);
        this.string_1 = content;
      }
    }

    public override void TransformMe(TransformConfig config, Matrix4D matrix)
    {
      this.ApplyTransformation(matrix);
    }

    public override void TransformMe(
      TransformConfig config,
      Matrix4D matrix,
      CommandGroup undoGroup)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfModelerGeometry.Class552 class552 = new DxfModelerGeometry.Class552();
      // ISSUE: reference to a compiler-generated field
      class552.dxfModelerGeometry_0 = this;
      // ISSUE: reference to a compiler-generated field
      class552.string_0 = this.string_1;
      // ISSUE: reference to a compiler-generated field
      class552.memoryStream_0 = this.memoryStream_0 == null ? (MemoryStream) null : new MemoryStream(this.memoryStream_0.GetBuffer(), 0, (int) this.memoryStream_0.Length, true, true);
      this.ApplyTransformation(matrix);
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfModelerGeometry.Class553()
      {
        class552_0 = class552,
        string_0 = this.string_1,
        memoryStream_0 = this.memoryStream_0 == null ? (MemoryStream) null : new MemoryStream(this.memoryStream_0.GetBuffer(), 0, (int) this.memoryStream_0.Length, true, true)
      }.method_0), new System.Action(class552.method_0)));
    }

    public virtual void ApplyParser()
    {
      if (this.IsEmpty)
        return;
      Class795 class795 = this.method_14(Class795.Enum30.const_0);
      if (class795 == null)
        throw new Exception0("Empty SAT\\SAB stream");
      if (this.IsSab)
      {
        MemoryStream content = new MemoryStream();
        int version = class795.Header.Version;
        class795.WriteTo(content, version);
        this.memoryStream_0 = content;
      }
      else
      {
        int version = class795.Header.Version;
        string content;
        class795.WriteTo(version, out content);
        this.string_1 = content;
      }
    }

    public static string Decrypt(string encrypted)
    {
      int length = encrypted.Length;
      StringBuilder stringBuilder = new StringBuilder(length);
      for (int index = 0; index < length; ++index)
      {
        char ch = encrypted[index];
        if (ch == ' ')
          stringBuilder.Append(ch);
        else if (ch < ' ')
          stringBuilder.Append(ch);
        else if (ch == '^')
          stringBuilder.Append((char) (159U - (uint) ch));
        else if (ch >= '?' && ch <= '_')
          stringBuilder.Append((char) (159U - (uint) ch));
        else
          stringBuilder.Append((char) ((uint) ch ^ 95U));
      }
      return stringBuilder.ToString();
    }

    public static string Encrypt(string text)
    {
      if (text == null)
        return "";
      int length = text.Length;
      StringBuilder stringBuilder = new StringBuilder(length + 8);
      for (int index = 0; index < length; ++index)
      {
        char ch = text[index];
        if (ch > ' ' && ch < ' ')
          ch = (char) (159U - (uint) ch);
        else if (ch == '\t')
          ch = ' ';
        if (ch != '\r' && ch != '\n')
        {
          if (ch < ' ')
          {
            stringBuilder.Append('^');
            stringBuilder.Append((int) ch + 63 + 1);
          }
          else if (ch == '^')
            stringBuilder.Append('^');
          else
            stringBuilder.Append(ch);
        }
        else
          stringBuilder.Append(ch);
      }
      return stringBuilder.ToString();
    }

    internal bool method_13(Stream stream)
    {
      bool flag1 = false;
      long position = stream.Position;
      bool flag2 = true;
      for (int index = 0; index < DxfModelerGeometry.BinaryFilePrefix.Length; ++index)
      {
        int num = stream.ReadByte();
        if (num < 0 || (int) DxfModelerGeometry.BinaryFilePrefix[index] != num)
        {
          flag2 = false;
          break;
        }
      }
      if (flag2)
      {
        this.memoryStream_0 = new MemoryStream();
        int num = Class1045.smethod_7(stream);
        Class1045.smethod_9((Stream) this.memoryStream_0, num);
        bool flag3 = false;
        byte[][] numArray1 = num < 21800 ? DxfModelerGeometry.byte_2 : DxfModelerGeometry.byte_3;
label_23:
        byte b;
        while (!flag3 && !DxfModelerGeometry.smethod_2(stream, out b))
        {
          this.memoryStream_0.WriteByte(b);
          if ((int) b == (int) numArray1[0][0])
          {
            int index1 = 0;
            int index2 = 1;
            while (true)
            {
              bool flag4 = true;
              for (byte[] numArray2 = numArray1[index1]; index2 < numArray2.Length; ++index2)
              {
                if (!DxfModelerGeometry.smethod_2(stream, out b))
                {
                  this.memoryStream_0.WriteByte(b);
                  if ((int) b != (int) numArray2[index2])
                  {
                    flag4 = false;
                    break;
                  }
                }
                else
                {
                  flag4 = false;
                  break;
                }
              }
              if (flag4)
              {
                ++index1;
                index2 = 0;
                if (index1 < numArray1.GetLength(0))
                {
                  if (!DxfModelerGeometry.smethod_2(stream, out b))
                  {
                    this.memoryStream_0.WriteByte(b);
                    switch (b)
                    {
                      case 13:
                      case 14:
                        if (!DxfModelerGeometry.smethod_2(stream, out b))
                        {
                          this.memoryStream_0.WriteByte(b);
                          continue;
                        }
                        goto label_23;
                      case 45:
                        continue;
                      default:
                        goto label_23;
                    }
                  }
                  else
                    goto label_23;
                }
                else
                  break;
              }
              else
                goto label_23;
            }
            flag3 = true;
            flag1 = true;
          }
        }
        this.memoryStream_0.Seek(0L, SeekOrigin.Begin);
      }
      else
      {
        stream.Seek(position, SeekOrigin.Begin);
        long length = stream.Length - position;
        byte[] numArray = new byte[length];
        stream.Read(numArray, 0, (int) length);
        this.string_1 = Encodings.Ascii.GetString(numArray, 0, (int) length);
        flag1 = true;
      }
      return flag1;
    }

    private static bool smethod_2(Stream stream, out byte b)
    {
      int num = stream.ReadByte();
      bool flag;
      b = !(flag = num < 0) ? (byte) num : byte.MaxValue;
      return flag;
    }

    internal override bool HasDataStoreData
    {
      get
      {
        return true;
      }
    }

    internal static unsafe void smethod_3(byte[] bytes, int startIndex, int length)
    {
      fixed (byte* numPtr1 = bytes)
      {
        byte* numPtr2 = numPtr1 + startIndex;
        while (length-- != 0)
        {
          byte num = *numPtr2;
          if (num > (byte) 32 && num < (byte) 160)
            *numPtr2 = (byte) (159U - (uint) num);
          else if (num == (byte) 9)
            *numPtr2 = (byte) 32;
          ++numPtr2;
        }
      }
    }

    internal Class795 method_14(Class795.Enum30 mode)
    {
      return this.method_15(mode, false);
    }

    internal Class795 method_15(
      Class795.Enum30 mode,
      bool throwExceptionOnEmptySatorSabStream)
    {
      Class795 class795 = (Class795) null;
      if (this.SatText.Length != 0)
        class795 = Class795.CreateFrom(this.SatText, mode);
      else if (this.IsSab)
      {
        this.SabStream.Seek(0L, SeekOrigin.Begin);
        class795 = Class795.CreateFrom(this.SabStream, mode);
      }
      if (class795 == null && !throwExceptionOnEmptySatorSabStream)
        throw new Exception0("Empty SAT\\SAB stream");
      return class795;
    }

    private static string[] smethod_4(string text)
    {
      int startIndex = 0;
      List<string> stringList = new List<string>();
      int num;
      for (; (num = text.IndexOf("\r\n", startIndex)) >= 0; startIndex = num + "\r\n".Length)
        stringList.Add(text.Substring(startIndex, num - startIndex));
      if (startIndex < text.Length)
        stringList.Add(text.Substring(startIndex));
      return stringList.ToArray();
    }

    public class DxfModelerGuid
    {
      public static readonly DxfModelerGeometry.DxfModelerGuid Empty = new DxfModelerGeometry.DxfModelerGuid();
      private Guid guid_0 = new Guid(0, (short) 0, (short) 0, (byte) 0, (byte) 0, (byte) 0, (byte) 0, (byte) 0, (byte) 0, (byte) 0, (byte) 0);

      public Guid Guid
      {
        get
        {
          return this.guid_0;
        }
        set
        {
          this.guid_0 = value;
        }
      }
    }
  }
}
