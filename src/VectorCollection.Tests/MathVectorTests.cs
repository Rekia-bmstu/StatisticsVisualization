using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace VectorCollection.Tests
{
    public class MathVectorTests
    {
        [Fact]
        public void SumPositiveNumber()
        {
            var vector = new MathVector(-1, 0, 1);
            Assert.Equal<MathVector>(new MathVector(0, 1, 2), vector.AddNumber(1));
        }

        [Fact]
        public void SumNegativeNumber()
        {
            var vector = new MathVector(-1, 0, 1);
            Assert.Equal<MathVector>(new MathVector(-2, -1, 0), vector + (-1));
        }

        [Fact]
        public void SumZeroNumber()
        {
            var vector = new MathVector(-1, 0, 1);
            Assert.Equal<MathVector>(new MathVector(-1, 0, 1), vector + 0);
        }

        [Fact]
        public void SumPositiveVectors()
        {
            var vector1 = new MathVector(1, 2, 3);
            var vector2 = new MathVector(0, 1, 1);

            Assert.Equal(expected: new MathVector(1, 3, 4), actual: vector1 + vector2);
        }

        [Fact]
        public void SumNegativeVectors()
        {
            var vector1 = new MathVector(1, 2, 3);
            var vector2 = new MathVector(-1, -1, -1);

            Assert.Equal(expected: new MathVector(0, 1, 2), actual: vector1 + vector2);
        }

        [Fact]
        public void SumZeroVectors()
        {
            var vector1 = new MathVector(1, 2, 3);
            var vector2 = new MathVector(0, 0, 0);

            Assert.Equal(expected: new MathVector(1, 2, 3), actual: vector1 + vector2);
        }

        [Fact]
        public void MultiplyByPositiveNumber()
        {
            var vector = new MathVector(1, 2, 3);

            Assert.Equal(expected: new MathVector(2, 4, 6), actual: vector * 2);
        }

        [Fact]
        public void MultiplyByNegativeNumber()
        {
            var vector = new MathVector(1, 2, 3);

            Assert.Equal(expected: new MathVector(-1, -2, -3), actual: vector * -1);
        }

        [Fact]
        public void MultiplyByZeroNumber()
        {
            var vector = new MathVector(1, 2, 3);

            Assert.Equal(expected: new MathVector(0, 0, 0), actual: vector * 0);
        }
    }
}
