// Decompiled with JetBrains decompiler
// Type: WW.OpenGL.DisplayList
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using System.Collections.Generic;
using System.Security;

namespace WW.OpenGL
{
  [SecuritySafeCritical]
  public class DisplayList
  {
    private uint uint_0;
    private bool bool_0;
    private List<DisplayList> list_0;

    public DisplayList()
    {
      this.uint_0 = GL.glGenLists(1);
      if (this.uint_0 == 0U)
        throw new GLException("Error getting OpenGL display list.");
      GL.glNewList(this.uint_0, ListMode.Compile);
    }

    public List<DisplayList> Children
    {
      get
      {
        if (this.list_0 == null)
          this.list_0 = new List<DisplayList>();
        return this.list_0;
      }
    }

    public void EndList()
    {
      if (this.bool_0)
        return;
      this.bool_0 = true;
      if (this.list_0 != null)
      {
        foreach (DisplayList displayList in this.list_0)
        {
          if (displayList.uint_0 == 0U)
            throw new GLException("Child display list has no ID.");
          GL.glCallList(displayList.uint_0);
        }
      }
      GL.glEndList();
    }

    public void Delete()
    {
      if (this.uint_0 != 0U)
      {
        this.EndList();
        GL.glDeleteLists(this.uint_0, 1);
        this.uint_0 = 0U;
      }
      if (this.list_0 == null)
        return;
      foreach (DisplayList displayList in this.list_0)
        displayList.Delete();
      this.list_0 = (List<DisplayList>) null;
    }

    public void Draw()
    {
      GL.glCallList(this.uint_0);
    }
  }
}
