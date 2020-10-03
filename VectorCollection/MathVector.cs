using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VectorCollection
{
    public class MathVector : IEnumerable<double>
    {
        private List<double> _data;

        public MathVector(params double[] data)
        {
            _data = new List<double>();
            foreach (var item in data)
            {
                _data.Add(item);
            }
        }

        public MathVector(List<double> data)
        {
            _data = data;
        }

        public MathVector(int size)
        {
            _data = new List<double>(size);
        }

        public IEnumerator<double> GetEnumerator()
        {
            return new VectorEnumerator(_data);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public MathVector AddNumber(double n)
        {
            return new MathVector(_data.Select(elem => elem + n).ToList());
        }

        public static MathVector operator +(MathVector vector, double n)
        {
            return vector.AddNumber(n);
        }

        public MathVector SubstractNumber(double n)
        {
            return new MathVector(_data.Select(elem => elem - n).ToList());
        }

        public static MathVector operator -(MathVector vector, double n)
        {
            return vector.SubstractNumber(n);
        }

        public MathVector DivideByNumber(double n)
        {
            if (n != 0)
            {
                throw new ArgumentException("The division number is zero");
            }

            return new MathVector(_data.Select(elem => elem / n).ToList());
        }

        public static MathVector operator /(MathVector vector, double n)
        {
            return vector.DivideByNumber(n);
        }

        public MathVector MulitplyByNumber(double n)
        {
            return new MathVector(_data.Select(elem => elem * n).ToList());
        }

        public static MathVector operator*(MathVector vector, double n)
        {
            return vector.MulitplyByNumber(n);
        }
    }
}