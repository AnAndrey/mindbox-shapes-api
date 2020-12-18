using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Shapes;

namespace Tests
{
    [TestClass]
    public class SquareTests : UnitTest
    {
        #region Tests

        [DataTestMethod]
        [DynamicData(nameof(GetValidShapesData), DynamicDataSourceType.Method)]
        public void Calculate_ValidShapesData_CorrectResults(Shape s, double expected)
        {
            Assert.AreEqual(expected, Math.Round(s.Square, 2), $"[{s.GetType().Name} #{s.Id}]: invalid square!");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetInvalidShapesData), DynamicDataSourceType.Method)]
        public void Calculate_InvalidShapesData_IncorrectResults(Shape s, double expected)
        {
            Assert.AreNotEqual(expected, Math.Round(s.Square, 2), $"[{s.GetType().Name} #{s.Id}]: unexpected results match!");
        }

        #endregion

        #region Helpers

        private static IEnumerable<object[]> GetValidShapesData()
        {
            yield return new object[] { new Circle(1, 60), 11309.73 };
            yield return new object[] { new Triangle(2, 12, 15, 17), 87.75 };
            yield return new object[] { new Rectangle(3, 50, 8), 400 };
        }

        private static IEnumerable<object[]> GetInvalidShapesData()
        {
            yield return new object[] { new Circle(1, 10), 11309.73 };
            yield return new object[] { new Triangle(2, 8, 800, 555), 35.35 };
            yield return new object[] { new Rectangle(3, 2, 2), 5 };
        }

        #endregion
    }
}
