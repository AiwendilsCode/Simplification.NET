
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using Simplification.Algorithms;

namespace Simplification.Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    public class RdpBenchmarks
    {
        private double[][] data = JsonSerializer.Deserialize<double[][]>(File.ReadAllText("data.json"));
        private RdpAlgorithm algorithm = new();

        [Benchmark]
        public void SimplifyRdp_vals_500_toler_0_1()
        {
            var _ = algorithm.Simplify(data[..500], 0.1);
        }

        [Benchmark]
        public void SimplifyRdp_vals_500_toler_0_5()
        {
            var _ = algorithm.Simplify(data[..500], 0.5);
        }

        [Benchmark]
        public void SimplifyRdp_vals_500_toler_0_9()
        {
            var _ = algorithm.Simplify(data[..500], 0.9);
        }

        [Benchmark]
        public void SimplifyRdp_vals_1000_toler_0_1()
        {
            var _ = algorithm.Simplify(data[..1000], 0.1);
        }

        [Benchmark]
        public void SimplifyRdp_vals_1500_toler_0_1()
        {
            var _ = algorithm.Simplify(data[..1500], 0.1);
        }

        [Benchmark]
        public void SimplifyRdpIdx_vals_500_toler_0_1()
        {
            var _ = algorithm.SimplifyIdx(data[..500], 0.1);
        }

        [Benchmark]
        public void SimplifyRdpIdx_vals_500_toler_0_5()
        {
            var _ = algorithm.SimplifyIdx(data[..500], 0.5);
        }

        [Benchmark]
        public void SimplifyRdpIdx_vals_500_toler_0_9()
        {
            var _ = algorithm.SimplifyIdx(data[..500], 0.9);
        }

        [Benchmark]
        public void SimplifyRdpIdx_vals_1000_toler_0_1()
        {
            var _ = algorithm.SimplifyIdx(data[..500], 0.1);
        }

        [Benchmark]
        public void SimplifyRdpIdx_vals_1500_toler_0_1()
        {
            var _ = algorithm.SimplifyIdx(data[..500], 0.1);
        }

        [Benchmark]
        public void SimplifyRdp_vals_12000_toler_0_1()
        {
            var _ = algorithm.Simplify(data[..12000], 0.1);
        }

        [Benchmark]
        public void SimplifyRdpIdx_vals_12000_toler_0_1()
        {
            var _ = algorithm.SimplifyIdx(data[..12000], 0.1);
        }
    }
}
