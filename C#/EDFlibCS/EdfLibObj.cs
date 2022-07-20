using System;
using System.Runtime.InteropServices;

namespace EDFlibCS
{
    public abstract class EdfLibObj : SafeHandle
    {
        public IntPtr Obj => handle;
       
        public EdfLibObj(IntPtr obj) : base(IntPtr.Zero, true)
        {
            if (obj == IntPtr.Zero)
                throw new Exception("Error creating object");
            SetHandle(obj);
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected abstract void DestroyEdfLibObject(IntPtr obj);

        protected override bool ReleaseHandle()
        {
            DestroyEdfLibObject(handle);
            return true;
        }

    }
}
