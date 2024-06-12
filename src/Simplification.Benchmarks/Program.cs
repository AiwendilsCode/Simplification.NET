using System.Text.Json;
using BenchmarkDotNet.Running;
using Simplification.Algorithms;
using Simplification.Benchmarks.Benchmarks;

//BenchmarkRunner.Run<RdpBenchmarks>();
//BenchmarkRunner.Run<VisvalingamWhyattBenchmarks>();

RdpAlgorithm rdpAlg = new();
VisvalingamWhyattAlgorithm visvAlg = new();

var data = JsonSerializer.Deserialize<double[][]>(File.ReadAllText("data.json"));

File.WriteAllText("RDP_simplified.json",
    JsonSerializer.Serialize(rdpAlg.Simplify(data, 5)));

File.WriteAllText("Visvalingam_simplified.json",
    JsonSerializer.Serialize(visvAlg.Simplify(data, 10)));

File.WriteAllText("VisvalingamPreserveTopology_simplified.json",
    JsonSerializer.Serialize(visvAlg.PreserveTopologySimplify(data, 10)));