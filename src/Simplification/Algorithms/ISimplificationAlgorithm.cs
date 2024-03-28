namespace Simplification.Algorithms
{
    public interface ISimplificationAlgorithm
    {
        static abstract float[][] Simplify(float[][] data, double tolerance);
    }
}
