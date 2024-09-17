using EuclideanGeometry.Interfaces;

namespace EuclideanGeometry.Shapes
{
    public class Triangle : IShape
    {
        public double FirstSide { get; }
        public double SecondSide { get; }
        public double ThirdSide { get; }

        private static readonly double Precision = 1e-10;
        private double? _cachedArea = null;

        /// <summary>
        /// Initializes a new instance of the Triangle class with the given side lengths.
        /// Throws an exception if the side lengths do not form a valid triangle.
        /// </summary>
        /// <param name="firstSide">Length of the first side.</param>
        /// <param name="secondSide">Length of the second side.</param>
        /// <param name="thirdSide">Length of the third side.</param>
        /// <exception cref="ArgumentException">Thrown when any side is less than or equal to zero, or when the sides do not form a valid triangle.</exception>
        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            ValidateSides(firstSide, secondSide, thirdSide);

            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
        }

        /// <summary>
        /// Calculates the area of the triangle using Heron's formula.
        /// The result of calculating the area is cached since the sides are immutable.
        /// </summary>
        /// <returns>The area of the triangle.</returns>
        public double CalculateArea()
        {
            if (_cachedArea.HasValue)
                return _cachedArea.Value;

            double semiPerimeter = (FirstSide + SecondSide + ThirdSide) / 2;
            _cachedArea = Math.Sqrt(semiPerimeter * (semiPerimeter - FirstSide) * (semiPerimeter - SecondSide) * (semiPerimeter - ThirdSide));
            return _cachedArea.Value;
        }

        /// <summary>
        /// Determines whether the triangle is a right-angled triangle using the Pythagorean theorem.
        /// </summary>
        /// <returns>True if the triangle is right-angled, otherwise false.</returns>
        public bool IsRightTriangle()
        {
            var sides = new[] { FirstSide, SecondSide, ThirdSide };
            Array.Sort(sides);

            return IsRightAngle(sides[2], sides[0], sides[1]);
        }

        #region Helper methods

        /// <summary>
        /// Validate a triangle's sideds/
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <exception cref="ArgumentException"></exception>
        private static void ValidateSides(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("All sides must be greater than 0.");

            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException($"A triangle with sides {a}, {b}, and {c} cannot exist.");
        }

        /// <summary>
        /// Checks if the given sides of a triangle satisfy the Pythagorean theorem
        /// </summary>
        /// <param name="hypotenuse"></param>
        /// <param name="firstCathetus"></param>
        /// <param name="secondCathetus"></param>
        /// <returns></returns>
        private static bool IsRightAngle(double hypotenuse, double firstCathetus, double secondCathetus)
        {
            return Math.Abs(hypotenuse * hypotenuse - (firstCathetus * firstCathetus + secondCathetus * secondCathetus)) < Precision; //Checks if the difference between these two quantities is within a small range 
        }

        #endregion
    }
}
