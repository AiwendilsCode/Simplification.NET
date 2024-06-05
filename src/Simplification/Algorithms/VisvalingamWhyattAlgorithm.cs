using Simplification.Rust;

namespace Simplification.Algorithms
{
    public class VisvalingamWhyattAlgorithm : ISimplificationAlgorithm
    {
        public double[][] Simplify(double[][] data, double tolerance)
        {
            using (var converter = new ExternalArrayConverter(data))
            {
                ExternalArray output = RustBindings.simplify_visvalingam_ffi(converter.ExternalArray, tolerance);

                var outputArray = ExternalArrayConverter.ToDoubleArray(output);

                RustBindings.drop_float_array(output);

                return outputArray;
            }
        }

        public UIntPtr[] SimplifyIdx(double[][] data, double tolerance)
        {
            using (var converter = new ExternalArrayConverter(data))
            {
                ExternalArray output = RustBindings.simplify_visvalingam_idx_ffi(converter.ExternalArray, tolerance);

                var outputArray = ExternalArrayConverter.ToUIntPtrArray(output);

                RustBindings.drop_usize_array(output);

                return outputArray;
            }
        }

        /// <summary>
        /// topology-preserving Visvalingam-Whyatt, returning simplified geometry coordinates
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public double[][]? PreserveTopologySimplify(double[][] data, double tolerance)
        {
            using (var converter = new ExternalArrayConverter(data))
            {
                ExternalArray output = RustBindings.simplify_visvalingamp_ffi(converter.ExternalArray, tolerance);

                var outputArray = ExternalArrayConverter.ToDoubleArray(output);

                RustBindings.drop_float_array(output);

                return outputArray;
            }
        }
    }
}
