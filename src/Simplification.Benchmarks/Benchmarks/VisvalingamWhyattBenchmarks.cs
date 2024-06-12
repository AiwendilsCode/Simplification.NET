
using BenchmarkDotNet.Attributes;
using Simplification.Algorithms;
using System.Text.Json;

namespace Simplification.Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    public class VisvalingamWhyattBenchmarks
    {
        private double[][] data = JsonSerializer.Deserialize<double[][]>(File.ReadAllText("data.json"));
        private VisvalingamWhyattAlgorithm algorithm = new();

        [Benchmark]
        public void SimplifyVw_vals_500_toler_0_5()
        {
            var _ = algorithm.Simplify(data[..500], 0.5);
        }

        [Benchmark]
        public void SimplifyVw_vals_500_toler_1_5()
        {
            var _ = algorithm.Simplify(data[..500], 1.5);
        }

        [Benchmark]
        public void SimplifyVw_vals_500_toler_3()
        {
            var _ = algorithm.Simplify(data[..500], 3);
        }

        [Benchmark]
        public void SimplifyVw_vals_1000_toler_0_5()
        {
            var _ = algorithm.Simplify(data[..1000], 0.5);
        }

        [Benchmark]
        public void SimplifyVw_vals_1500_toler_0_5()
        {
            var _ = algorithm.Simplify(data[..1500], 0.5);
        }

        [Benchmark]
        public void SimplifyVwIdx_vals_500_toler_0_5()
        {
            var _ = algorithm.SimplifyIdx(data[..500], 0.5);
        }

        [Benchmark]
        public void SimplifyVwIdx_vals_500_toler_1_5()
        {
            var _ = algorithm.SimplifyIdx(data[..500], 1.5);
        }

        [Benchmark]
        public void SimplifyVwIdx_vals_500_toler_3()
        {
            var _ = algorithm.SimplifyIdx(data[..500], 3);
        }

        [Benchmark]
        public void SimplifyVwIdx_vals_1000_toler_0_5()
        {
            var _ = algorithm.SimplifyIdx(data[..1000], 0.5);
        }

        [Benchmark]
        public void SimplifyVwIdx_vals_1500_toler_0_5()
        {
            var _ = algorithm.SimplifyIdx(data[..1500], 0.5);
        }

        [Benchmark]
        public void SimplifyPT_vals_500_toler_0_5()
        {
            var _ = algorithm.PreserveTopologySimplify(data[..500], 0.5);
        }

        [Benchmark]
        public void SimplifyPT_vals_500_toler_1_5()
        {
            var _ = algorithm.PreserveTopologySimplify(data[..500], 1.5);
        }

        [Benchmark]
        public void SimplifyPT_vals_500_toler_3()
        {
            var _ = algorithm.PreserveTopologySimplify(data[..500], 3);
        }

        [Benchmark]
        public void SimplifyPT_vals_1000_toler_0_5()
        {
            var _ = algorithm.PreserveTopologySimplify(data[..1000], 0.5);
        }

        [Benchmark]
        public void SimplifyPT_vals_1500_toler_0_5()
        {
            var _ = algorithm.PreserveTopologySimplify(data[..1500], 0.5);
        }

        [Benchmark]
        public void SimplifyVw_vals_12000_toler_0_5()
        {
            var _ = algorithm.Simplify(data[..12000], 0.5);
        }

        [Benchmark]
        public void SimplifyVwIdx_vals_12000_toler_0_5()
        {
            var _ = algorithm.SimplifyIdx(data[..12000], 0.5);
        }

        [Benchmark]
        public void SimplifyVwPT_vals_12000_toler_0_5()
        {
            var _ = algorithm.PreserveTopologySimplify(data[..12000], 0.5);
        }
    }
}
