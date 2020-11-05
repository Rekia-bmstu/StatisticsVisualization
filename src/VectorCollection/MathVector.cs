using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VectorCollection
{
    public class MathVector : IEnumerable<double>
    {
        private List<double> _data;
        private int _dimensions;

        public int Dimensions
        {
            get
            {
                return _dimensions;
            }

            set
            {
                if (_dimensions < 0)
                {
                    throw new InvalidOperationException("Negative count for dimensions");
                }
                _dimensions = value;
            }
        }

        public MathVector()
        {
            _data = new List<double>();
            Dimensions = 0;
        }

        public MathVector(params double[] data)
        {
            _data = new List<double>(0);
            foreach (var item in data)
            {
                _data.Add(item);
            }

            Dimensions = _data.Count();
        }

        public MathVector(List<double> data)
        {
            _data = data;
            Dimensions = data.Count;
        }

        public MathVector(int size)
        {
            Dimensions = size;
            _data = new List<double>(Dimensions);
        }

        public void Add(double value)
        {
            _data.Add(value);
            Dimensions = _data.Count;
        }

        public double Length
        {
            get
            { 
                double sum = 0;
                foreach (var item in _data)
                {
                    sum += Math.Pow(item, 2);
                }

                return Math.Sqrt(sum);
            }
        }

        public double GetAverage()
        {
            if (Dimensions == 0)
                return 0;

            double sum = 0;
            foreach (var elem in this)
            {
                sum += elem;
            }

            return sum / Dimensions;
        }

        public IEnumerator<double> GetEnumerator()
        {
            return new VectorEnumerator(_data);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public double this[int index]
        {
            get 
            {
                return _data[index];
            }

            set
            {
                _data[index] = value;
            }
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
                throw new ArgumentException("Division by zero");
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

        public MathVector AddVector(MathVector other)
        {
            if (other == null)
            {
                throw new NullReferenceException("Invalid arguments");
            }

            if (_data.Count() != other.Count())
            {
                throw new InvalidOperationException("Vectors lengths differ");
            }

            List<double> data = new List<double>();
            for (int i = 0; i < _data.Count(); i++)
            {
                data.Add(_data[i] + other[i]);
            }

            return new MathVector(data);
        }

        public static MathVector operator +(MathVector first, MathVector second)
        {
            return first.AddVector(second);
        }

        public MathVector SubstractVector(MathVector other)
        {
            if (other == null)
            {
                throw new NullReferenceException("Invalid arguments");
            }

            if (_data.Count() != other.Count())
            {
                throw new InvalidOperationException("Vectors lengths differ");
            }

            List<double> data = new List<double>();
            for (int i = 0; i < _data.Count(); i++)
            {
                data.Add(_data[i] - other[i]);
            }

            return new MathVector(data);
        }

        public static MathVector operator -(MathVector first, MathVector second)
        {
            return first.SubstractVector(second);
        }

        public MathVector DivideByVector(MathVector other)
        {
            if (other == null)
            {
                throw new NullReferenceException("Invalid arguments");
            }

            if (_data.Count() != other.Count())
            {
                throw new InvalidOperationException("Vectors lengths differ");
            }

            List<double> data = new List<double>();
            for (int i = 0; i < _data.Count(); i++)
            {
                data.Add(_data[i] / other[i]);
            }

            return new MathVector(data);
        }

        public static MathVector operator /(MathVector first, MathVector second)
        {
            return first.DivideByVector(second);
        }

        public MathVector MultiplyByVector(MathVector other)
        {
            if (other == null)
            {
                throw new NullReferenceException("Invalid arguments");
            }

            if (_data.Count() != other.Count())
            {
                throw new InvalidOperationException("Vectors lengths differ");
            }

            List<double> data = new List<double>();
            for (int i = 0; i < _data.Count(); i++)
            {
                data.Add(_data[i] * other[i]);
            }

            return new MathVector(data);
        }

        public static MathVector operator *(MathVector first, MathVector second)
        {
            return first.MultiplyByVector(second);
        }

        public double ScalarProduct(MathVector other)
        {
            if (other == null)
            {
                throw new NullReferenceException("Invalid arguments");
            }

            if (_data.Count() != other.Count())
            {
                throw new InvalidOperationException("Vectors lengths differ");
            }

            double scalarProduct = 0;

            for (int i = 0; i < other.Count(); i++)
            {
                scalarProduct += this[i] * other[i];
            }

            return scalarProduct;
        }

        public double GetDistance(MathVector vector)
        {
            if (Dimensions != vector.Dimensions)
                throw new ArgumentException("Vectors lengths differ");

            double result = 0.0;

            for (int i = 0; i < Dimensions; i++)
                result += Math.Pow(this[i] - vector[i], 2);

            return Math.Sqrt(result);
        }

        public override string ToString()
        {
            string result = "";
            foreach (var item in _data)
            {
                result += item.ToString() + " ";
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            var vector = obj as MathVector;
            bool result = Dimensions == vector.Dimensions;
            for (int i = 0; i < Dimensions && result; i++)
            {
                result = this[i] == vector[i];
            }

            return result;
        }
    }
}