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
            var sum_vector = vector + 1;
            Assert.Equal(new MathVector(0, 1, 2), sum_vector);
        }
    }
}
