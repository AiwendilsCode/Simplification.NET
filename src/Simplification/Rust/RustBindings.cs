using System.Runtime.InteropServices;

namespace Simplification.Rust
{
    internal class RustBindings
    {
        [DllImport("RustSimplificationAlgorithms.dll")]
        public static extern FfiArray simplify_rdp_ffi(FfiArray array, double precision);
        [DllImport("RustSimplificationAlgorithms.dll")]
        public static extern FfiArray simplify_rdp_idx_ffi(FfiArray array, double precision);
        [DllImport("RustSimplificationAlgorithms.dll")]
        public static extern FfiArray simplify_visvalingam_ffi(FfiArray array, double precision);
        [DllImport("RustSimplificationAlgorithms.dll")]
        public static extern FfiArray simplify_visvalingam_idx_ffi(FfiArray array, double precision);
        [DllImport("RustSimplificationAlgorithms.dll")]
        public static extern FfiArray simplify_visvalingamp_ffi(FfiArray array, double precision);
        [DllImport("RustSimplificationAlgorithms.dll")]
        public static extern void drop_float_array(FfiArray ptr);
        [DllImport("RustSimplificationAlgorithms.dll")]
        public static extern void drop_usize_array(FfiArray ptr);
    }
}
