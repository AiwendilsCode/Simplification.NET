# Simplification
C# wrapper for [Rust library](https://github.com/urschrei/rdp/tree/master) by [urschrei](https://github.com/urschrei) for [Ramer-Douglas-Peucker](https://en.wikipedia.org/wiki/Ramer%E2%80%93Douglas%E2%80%93Peucker_algorithm) and [Visvalingam-Whyatt](https://en.wikipedia.org/wiki/Visvalingam%E2%80%93Whyatt_algorithm) algorithms.

## Usage

```
using Simplification.Algorithms;

double[][] input = [
    [0.0, 0.0],
    [5.0, 4.0],
    [11.0, 5.5],
    [17.3, 3.2],
    [27.8, 0.1],
];

ISimplificationAlgorithm rdpAlgorithm = new RdpAlgorithm();

// For RDP, Try an epsilon of 1.0 to start with. Other sensible values include 0.01, 0.001
double[][] simplified = rdpAlgorithm.Simplify(input, 1.0); // returns simplified data
UIntPtr[] simplifiedIndices = rdpAlgorithm.SimplifyIdx(input, 1.0); // returns simplified indices

ISimplificationAlgorithm visvAlgorithm = new VisvalingamWhyattAlgorithm();

simplified = visvAlgorithm.Simplify(input, 1.0); // returns simplified data
simplifiedIndices = visvAlgorithm.SimplifyIdx(input, 1.0); // returns simplified indices

simplified = ((VisvalingamWhyattAlgorithm)visvAlgorithm)
    .PreserveTopologySimplify(input, 1.0); // returns simplified data, while preserving topology
```