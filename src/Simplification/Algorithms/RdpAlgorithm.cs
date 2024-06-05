using Simplification.Rust;

namespace Simplification.Algorithms
{
    public class RdpAlgorithm : ISimplificationAlgorithm
    {
        public double[][] Simplify(double[][] data, double tolerance)
        {
            using (var converter = new ExternalArrayConverter(data))
            {
                ExternalArray output = RustBindings.simplify_rdp_ffi(converter.ExternalArray, tolerance);

                var outputArray = ExternalArrayConverter.ToDoubleArray(output);

                RustBindings.drop_float_array(output);

                return outputArray;
            }
        }

        public UIntPtr[] SimplifyIdx(double[][] data, double tolerance)
        {
            using (var converter = new ExternalArrayConverter(data))
            {
                ExternalArray output = RustBindings.simplify_rdp_idx_ffi(converter.ExternalArray, tolerance);

                var outputArray = ExternalArrayConverter.ToUIntPtrArray(output);

                RustBindings.drop_usize_array(output);

                return outputArray;
            }
        }
    }
}
