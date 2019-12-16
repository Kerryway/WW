﻿// Decompiled with JetBrains decompiler
// Type: ns4.Class757
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WW.IO.Compression;

namespace ns4
{
  internal class Class757
  {
    private static readonly byte[] byte_0 = new byte[4]{ (byte) 76, (byte) 66, (byte) 68, (byte) 84 };
    public static readonly Class757 class757_0 = new Class757();
    private readonly IDictionary<uint, Enum28> idictionary_0 = (IDictionary<uint, Enum28>) new Dictionary<uint, Enum28>();
    public const string string_0 = "linebreak.dat";
    private string string_1;

    private Class757()
    {
    }

    private void method_0(Stream stream)
    {
      this.idictionary_0.Clear();
      using (ZlibDecompressStream decompressStream = new ZlibDecompressStream(stream, false))
      {
        using (BinaryReader r = new BinaryReader((Stream) decompressStream))
        {
          foreach (byte num in Class757.byte_0)
          {
            if ((int) r.ReadByte() != (int) num)
              throw new IOException("Not a line break data file!");
          }
          byte num1 = r.ReadByte();
          if (num1 != (byte) 0)
            throw new IOException("Unsupported version of line break data file: " + (object) num1);
          StringBuilder stringBuilder = new StringBuilder(64);
          char ch;
          while ((ch = Class757.smethod_0(r)) != char.MinValue)
            stringBuilder.Append(ch);
          this.string_1 = stringBuilder.ToString();
          uint num2 = Class757.smethod_1(r);
          for (int index = 0; (long) index < (long) num2; ++index)
            this.idictionary_0.Add(Class757.smethod_1(r), (Enum28) r.ReadByte());
        }
      }
      char[] chArray = new char[7]{ '(', ')', '[', ']', '{', '}', '-' };
      foreach (uint index in chArray)
        this.idictionary_0[index] = Enum28.const_28;
    }

    private static char smethod_0(BinaryReader r)
    {
      return (char) ((uint) r.ReadByte() << 8 | (uint) r.ReadByte());
    }

    private static uint smethod_1(BinaryReader r)
    {
      return (uint) (ushort) ((uint) ((int) r.ReadByte() << 24 | (int) r.ReadByte() << 16 | (int) r.ReadByte() << 8) | (uint) r.ReadByte());
    }

    public Enum28 method_1(uint character)
    {
      Enum28 enum28;
      if (!this.idictionary_0.TryGetValue(character, out enum28))
        return Enum28.const_0;
      return enum28;
    }

    public Enum28 this[uint character]
    {
      get
      {
        Enum28 enum28;
        if (!this.idictionary_0.TryGetValue(character, out enum28))
          return Enum28.const_0;
        return enum28;
      }
    }

    public string Description
    {
      get
      {
        return this.string_1;
      }
    }

    public bool IsValid()
    {
      return this.string_1 != null;
    }

    static Class757()
    {
      try
      {
        using (Stream stream = (Stream) new MemoryStream(Class757.byte_1))
          Class757.class757_0.method_0(stream);
      }
      catch (Exception ex)
      {
      }
    }
  }
}