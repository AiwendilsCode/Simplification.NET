using System;

namespace Simplification.Algorithms
{
    public interface ISimplificationAlgorithm
    {
        /// <summary>
        /// returning simplified geometry coordinates
        /// </summary>
        /// <param name="data">2-dimensional data for simplification</param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        double[][] Simplify(double[][] data, double tolerance);
        /// <summary>
        /// returning simplified geometry indices
        /// </summary>
        /// <param name="data">2-dimensional data for simplification</param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        UIntPtr[] SimplifyIdx(double[][] data, double tolerance);
    }
}
