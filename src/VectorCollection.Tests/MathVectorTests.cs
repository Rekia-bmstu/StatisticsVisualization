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
        public void SumPositiveNumberTest()
        {
            var vector = new MathVector(-1, 0, 1);
            Assert.Equal<MathVector>(new MathVector(0, 1, 2), vector + 1);
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
    }
}
