using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using WW.Actions;

namespace WW.ComponentModel
{
    public class UndoRedoPropertyDescriptor : PropertyDescriptor
    {
        private PropertyDescriptor propertyDescriptor_0;

        private UndoRedoTypeDescriptor undoRedoTypeDescriptor_0;

        public override string Category
        {
            get
            {
                return this.propertyDescriptor_0.Category;
            }
        }

        public override Type ComponentType
        {
            get
            {
                return this.propertyDescriptor_0.ComponentType;
            }
        }

        public override string Description
        {
            get
            {
                return this.propertyDescriptor_0.Description;
            }
        }

        public override string DisplayName
        {
            get
            {
                return this.propertyDescriptor_0.DisplayName;
            }
        }

        public override bool IsBrowsable
        {
            get
            {
                return this.propertyDescriptor_0.IsBrowsable;
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                return this.propertyDescriptor_0.IsReadOnly;
            }
        }

        public override string Name
        {
            get
            {
                return this.propertyDescriptor_0.Name;
            }
        }

        public override Type PropertyType
        {
            get
            {
                return this.propertyDescriptor_0.PropertyType;
            }
        }

        public UndoRedoPropertyDescriptor(PropertyDescriptor basePropertyDescriptor, UndoRedoTypeDescriptor typeDescriptor) : base(basePropertyDescriptor)
        {
            this.propertyDescriptor_0 = basePropertyDescriptor;
            this.undoRedoTypeDescriptor_0 = typeDescriptor;
        }

        public override bool CanResetValue(object component)
        {
            return this.propertyDescriptor_0.CanResetValue(component);
        }

        public override object GetValue(object component)
        {
            return this.propertyDescriptor_0.GetValue(component);
        }

        public override void ResetValue(object component)
        {
            this.propertyDescriptor_0.ResetValue(component);
        }

        public override void SetValue(object component, object value)
        {
            Command command;
            object obj = this.GetValue(component);
            PropertyInfo property = component.GetType().GetProperty(this.propertyDescriptor_0.Name);
            command = (property != null ? new Command(component, () => property.SetValue(component, value, null), () => property.SetValue(component, obj, null)) : new Command(component, () => this.propertyDescriptor_0.SetValue(component, value), () => this.propertyDescriptor_0.SetValue(component, obj)));
            if (command != null)
            {
                this.undoRedoTypeDescriptor_0.method_0(new CommandEventArgs(command));
            }
        }

        public override bool ShouldSerializeValue(object component)
        {
            return this.propertyDescriptor_0.ShouldSerializeValue(component);
        }
    }
}