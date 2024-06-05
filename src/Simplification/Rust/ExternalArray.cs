using System.Runtime.InteropServices;

namespace Simplification.Rust
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct ExternalArray
    {
        public IntPtr data;
        public UIntPtr len;
    }
}
