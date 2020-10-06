using System;
using System.Collections.Generic;
using System.Text;

namespace VectorCollection
{
    public interface IMathVector : IEnumerable<double>
    {
        int Dimensions { get; }
        double Length();
        double this [int i] { get; set; }
        IMathVector AddNumber(double n);
        IMathVector SubstractNumber(double n);
        IMathVector DivideByNumber(double n);
        IMathVector MultiplyByNumber(double n);
        IMathVector AddVector(IMathVector vector);
        IMathVector SubstractVector(IMathVector other);
        IMathVector DivideByVector(IMathVector other);
        IMathVector MultiplyByVector(IMathVector other);
        double ScalarProduct(IMathVector other);
    }
}
