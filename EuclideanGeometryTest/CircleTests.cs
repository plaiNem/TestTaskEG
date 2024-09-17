using EuclideanGeometry.Shapes;

namespace EuclideanGeometryTest
{
    public class CircleTests
    {
        [Fact]
        public void Constructor_InvalidRadius_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Circle(0));
            Assert.Throws<ArgumentException>(() => new Circle(-1));
        }

        [Fact]
        public void CalculateArea_ValidRadius_ReturnsCorrectArea()
        {
            // Arrange
            var circle = new Circle(2);

            // Act
            double area = circle.CalculateArea();

            // Assert
            Assert.Equal(Math.PI * 4, area, precision: (int)1e-10);
        }
    }
}