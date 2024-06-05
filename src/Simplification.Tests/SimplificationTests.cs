using Simplification.Algorithms;

namespace Simplification.Tests
{
    public class SimplificationTests
    {
        [Fact]
        public void SimplifyRdp()
        {
            // Arrange
            double[][] input = [
                [0.0, 0.0],
                [5.0, 4.0],
                [11.0, 5.5],
                [17.3, 3.2],
                [27.8, 0.1],
            ];
            RdpAlgorithm algorithm = new();

            // Act
            var output = algorithm.Simplify(input, 1.0);

            // Assert
            double[][] expected = [[0.0, 0.0], [5.0, 4.0], [11.0, 5.5], [27.8, 0.1]];
            Assert.Equal(expected, output);
        }

        [Fact]
        public void SimplifyRdpIdx()
        {
            // Arrange
            double[][] input = [
                [0.0, 0.0],
                [5.0, 4.0],
                [11.0, 5.5],
                [17.3, 3.2],
                [27.8, 0.1],
            ];
            RdpAlgorithm algorithm = new();

            // Act
            var output = algorithm.SimplifyIdx(input, 1.0);

            // Assert
            UIntPtr[] expected = [0, 1, 2, 4];
            Assert.Equal(expected, output);
        }

        [Fact]
        public void SimplifyVisvalingam()
        {
            // Arrange
            double[][] input = [
                [5.0, 2.0],
                [3.0, 8.0],
                [6.0, 20.0],
                [7.0, 25.0],
                [10.0, 10.0],
            ];
            VisvalingamWhyattAlgorithm algorithm = new();

            // Act
            var output = algorithm.Simplify(input, 30.0);

            // Assert
            double[][] expected = [[5.0, 2.0], [7.0, 25.0], [10.0, 10.0]];
            Assert.Equal(expected, output);
        }

        [Fact]
        public void SimplifyVisvalingamIdx()
        {
            // Arrange
            double[][] input = [
                [5.0, 2.0],
                [3.0, 8.0],
                [6.0, 20.0],
                [7.0, 25.0],
                [10.0, 10.0]];
            VisvalingamWhyattAlgorithm algorithm = new();

            // Act
            var output = algorithm.SimplifyIdx(input, 30.0);

            // Assert
            UIntPtr[] expected = [0, 3, 4];
            Assert.Equal(expected, output);
        }

        [Fact]
        public void SimplifyVisvalingamp()
        {
            // Arrange
            double[][] input = [
                [5.0, 2.0],
                [3.0, 8.0],
                [6.0, 20.0],
                [7.0, 25.0],
                [10.0, 10.0],
            ];
            VisvalingamWhyattAlgorithm algorithm = new();

            // Act
            var output = algorithm.PreserveTopologySimplify(input, 30.0);

            // Assert
            double[][] expected = [[5.0, 2.0], [7.0, 25.0], [10.0, 10.0]];
            Assert.Equal(expected, output);
        }
    }
}
