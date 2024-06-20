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
        /// topology-preserving Visvalingam-Whyatt
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tolerance"></param>
        /// <returns>simplified geometry coordinates</returns>
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

        /// <summary>
        /// More memory efficient but slower on larger datasets.
        /// </summary>
        /// <param name="points"></param>
        /// <param name="tolerance"></param>
        /// <returns>simplified geometry coordinates</returns>
        public List<double[]> SimplifyMemOptimized(List<double[]> points, double tolerance)
        {
            if (points == null || points.Count <= 2)
                return points;

            int count = points.Count;
            int index = 1;
            double area = double.MaxValue;

            while (count > 2)
            {
                if (index < count - 1)
                {
                    area = CalculateTriangleArea(points[index - 1], points[index], points[index + 1]);

                    if (area < tolerance)
                    {
                        points.RemoveAt(index);
                        count--;
                    }
                    else
                    {
                        index++;
                    }
                }
                else
                {
                    break;
                }
            }

            return points;
        }

        private double CalculateTriangleArea(double[] a, double[] b, double[] c)
        {
            return 0.5 * Math.Abs(a[0] * (b[1] - c[1]) + b[0] * (c[1] - a[1]) + c[0] * (a[1] - b[1]));
        }
    }
}
