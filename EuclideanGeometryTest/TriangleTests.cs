using EuclideanGeometry.Shapes;

namespace EuclideanGeometryTest
{
    public class TriangleTests
    {
        [Fact]
        public void Constructor_InvalidSides_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Triangle(1, 1, 3));
        }

        [Fact]
        public void CalculateArea_ValidTriangle_ReturnsCorrectArea()
        {
            // Arrange
            var triangle = new Triangle(3, 4, 5);

            // Act
            double area = triangle.CalculateArea();

            // Assert
            Assert.Equal(6.0, area, precision: (int)1e-10);
        }

        [Fact]
        public void IsRightTriangle_RightTriangle_ReturnsTrue()
        {
            // Arrange
            var triangle = new Triangle(3, 4, 5);

            // Act
            bool isRight = triangle.IsRightTriangle();

            // Assert
            Assert.True(isRight);
        }

        [Fact]
        public void IsRightTriangle_NotRightTriangle_ReturnsFalse()
        {
            // Arrange
            var triangle = new Triangle(4, 5, 6);

            // Act
            bool isRight = triangle.IsRightTriangle();

            // Assert
            Assert.False(isRight);
        }
    }
}