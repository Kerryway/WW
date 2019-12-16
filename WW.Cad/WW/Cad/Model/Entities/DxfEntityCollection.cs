// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfEntityCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using WW.Actions;

namespace WW.Cad.Model.Entities
{
  public class DxfEntityCollection : ActiveDxfHandledObjectCollection<DxfEntity>
  {
    public void AddRange(params DxfEntity[] entities)
    {
      this.AddRange((IEnumerable<DxfEntity>) entities);
    }

    public static class Actions
    {
      public class Add : ICommand
      {
        private DxfEntityCollection dxfEntityCollection_0;
        private DxfEntity dxfEntity_0;

        public Add(DxfEntityCollection entities, DxfEntity entity)
        {
          this.dxfEntityCollection_0 = entities;
          this.dxfEntity_0 = entity;
        }

        public object Target
        {
          get
          {
            return (object) this.dxfEntityCollection_0;
          }
        }

        public void Do(CommandInvoker commandInvoker)
        {
          this.dxfEntityCollection_0.Add(this.dxfEntity_0);
        }

        public void Undo(CommandInvoker commandInvoker)
        {
          if (this.dxfEntityCollection_0[this.dxfEntityCollection_0.Count - 1] != this.dxfEntity_0)
            throw new Exception("Last entity is not equal to entity to be removed.");
          this.dxfEntityCollection_0.RemoveAt(this.dxfEntityCollection_0.Count - 1);
        }
      }

      public class Remove : ICommand
      {
        private DxfEntityCollection dxfEntityCollection_0;
        private DxfEntity dxfEntity_0;
        private int int_0;

        public Remove(DxfEntityCollection entities, int index)
        {
          this.dxfEntityCollection_0 = entities;
          this.int_0 = index;
          this.dxfEntity_0 = entities[index];
        }

        public object Target
        {
          get
          {
            return (object) this.dxfEntityCollection_0;
          }
        }

        public void Do(CommandInvoker commandInvoker)
        {
          if (this.dxfEntityCollection_0[this.int_0] != this.dxfEntity_0)
            throw new Exception("Last entity is not equal to entity to be removed.");
          this.dxfEntityCollection_0.RemoveAt(this.int_0);
        }

        public void Undo(CommandInvoker commandInvoker)
        {
          this.dxfEntityCollection_0.Insert(this.int_0, this.dxfEntity_0);
        }
      }
    }
  }
}
