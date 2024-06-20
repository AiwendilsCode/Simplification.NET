using System;

namespace Simplification.Algorithms
{
    public interface ISimplificationAlgorithm
    {
        /// <summary>
        /// </summary>
        /// <param name="data">2-dimensional data for simplification</param>
        /// <param name="tolerance"></param>
        /// <returns>simplified geometry coordinates</returns>
        double[][] Simplify(double[][] data, double tolerance);
        /// <summary>
        /// </summary>
        /// <param name="data">2-dimensional data for simplification</param>
        /// <param name="tolerance"></param>
        /// <returns>simplified geometry indices</returns>
        UIntPtr[] SimplifyIdx(double[][] data, double tolerance);
    }
}
