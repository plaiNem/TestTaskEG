using EuclideanGeometry.Interfaces;

namespace EuclideanGeometry.Utilities
{
    public static class AreaCalculator
    {
        /// <summary>
        /// Calculating the area of a shape without knowing the type of shape in compile-time
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        public static double CalculateShapeArea(IShape shape)
        {
            return shape.CalculateArea();
        }
    }
}