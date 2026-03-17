using System;

namespace PUCPR.SceneDocs
{
    [AttributeUsage(AttributeTargets.Class)]
    public class NoteComponentMenuAttribute : Attribute
    {
        public string menu;
        public NoteComponentMenuAttribute(string menu) => this.menu = menu;
    }
}
