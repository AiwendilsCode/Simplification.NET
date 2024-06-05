using System.Runtime.InteropServices;

namespace Simplification.Rust
{
    internal class RustBindings
    {
        [DllImport("RustSimplificationAlgorithms.dll")]
        public static extern ExternalArray simplify_rdp_ffi(ExternalArray array, double precision);
        [DllImport("RustSimplificationAlgorithms.dll")]
        public static extern ExternalArray simplify_rdp_idx_ffi(ExternalArray array, double precision);
        [DllImport("RustSimplificationAlgorithms.dll")]
        public static extern ExternalArray simplify_visvalingam_ffi(ExternalArray array, double precision);
        [DllImport("RustSimplificationAlgorithms.dll")]
        public static extern ExternalArray simplify_visvalingam_idx_ffi(ExternalArray array, double precision);
        [DllImport("RustSimplificationAlgorithms.dll")]
        public static extern ExternalArray simplify_visvalingamp_ffi(ExternalArray array, double precision);
        [DllImport("RustSimplificationAlgorithms.dll")]
        public static extern void drop_float_array(ExternalArray ptr);
        [DllImport("RustSimplificationAlgorithms.dll")]
        public static extern void drop_usize_array(ExternalArray ptr);
    }
}
