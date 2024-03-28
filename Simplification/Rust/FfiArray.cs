using System.Runtime.InteropServices;

namespace Simplification.Rust
{
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct FfiArray
    {
        public required nint data;
        public required nuint len;
    }
}
