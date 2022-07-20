using EDFlibCS.Enums;
using EDFlibCS.Internal;
using System;
using System.IO;

namespace EDFlibCS
{
    public class EdfReader : EdfLibObj
    {
        public string Filename { get; }
        public EdfHeader Header { get; }

        public EdfReader(string path, AnnotationRead annotationRead = AnnotationRead.DoNotRead) : base(DllHandler.CreateReader(path, (int)annotationRead))
        {
            // error handling
            Filename = Path.GetFileName(path);
            Header = new EdfHeader(this);
        }

        protected override void DestroyEdfLibObject(IntPtr obj)
        { }
    }
}
