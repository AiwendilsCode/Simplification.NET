using Simplification.Algorithms;
using System.Globalization;

string[] lines = File.ReadAllLines("generatedValuesSin.csv");

double[][] data = new double[1500][];

for (int i = 1; i < 1501; i++) // skip first line
{
    data[i - 1] = [(i - 1) * 3600, double.Parse(lines[i], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture)];
}

ISimplificationAlgorithm algorithm = new RdpAlgorithm();

UIntPtr[] _ = algorithm.SimplifyIdx(data, 0.005);

;