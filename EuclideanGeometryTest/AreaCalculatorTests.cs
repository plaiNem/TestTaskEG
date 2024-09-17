using EuclideanGeometry.Interfaces;
using EuclideanGeometry.Utilities;
using Moq;

namespace EuclideanGeometryTest
{
    public class AreaCalculatorTests
    {
        [Fact]
        public void CalculateShapeArea_ShouldReturnShapeArea()
        {
            // Arrange
            var mockShape = new Mock<IShape>();
            mockShape.Setup(shape => shape.CalculateArea()).Returns(42.0);

            // Act
            double result = AreaCalculator.CalculateShapeArea(mockShape.Object);

            // Assert
            Assert.Equal(42.0, result);
        }
    }
}