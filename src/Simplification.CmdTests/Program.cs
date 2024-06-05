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
