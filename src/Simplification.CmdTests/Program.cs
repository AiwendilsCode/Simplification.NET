using Simplification.Algorithms;
using System.Globalization;

string[] lines = File.ReadAllLines("generatedValuesSin.csv");

float[][] data = new float[lines.Length - 1][];

for (int i = 1; i < lines.Length; i++) // skip first line
{
    data[i - 1] = [(i - 1) * 3600, float.Parse(lines[i], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture)];
}

float[][] simplified = RdpAlgorithm.Simplify(data, 0.15);

;