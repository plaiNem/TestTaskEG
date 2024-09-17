using EuclideanGeometry.Interfaces;

namespace EuclideanGeometry.Shapes
{
    public class Circle : IShape
    {
        public double Radius { get; }
        private double? _cachedArea;

        /// <summary>
        /// Initializes a new instance of the Circle class with the specified radius.
        /// </summary>
        /// <param name="radius">The radius of the circle, must be greater than 0.</param>
        /// <exception cref="ArgumentException">Thrown if the radius is less than or equal to 0.</exception>
        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Radius must be greater than 0.", nameof(radius));

            Radius = radius;
        }

        /// <summary>
        /// Calculates the area of the circle.
        /// The result of calculating the area is cached since the sides are immutable.
        /// </summary>
        /// <returns>The area of the circle.</returns>
        public double CalculateArea()
        {
            return _cachedArea ??= Math.PI * Radius * Radius;
        }
    }
}