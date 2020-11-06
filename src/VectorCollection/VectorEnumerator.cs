using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace VectorCollection
{
    internal class VectorEnumerator : IEnumerator<double>
    {
        private List<double> _data;
        private double _current;
        private int _pos = -1;
        private bool disposing;

        public double Current
        {
            get 
            {
                if (_pos > _data.Count || _pos < 0)
                    throw new InvalidOperationException("Current position is out of range");
                
                return _current;
            }

            private set 
            {
                _current = value;
            }
        }

        public VectorEnumerator(List<double> data)
        {
            _data = data;
        }

        object IEnumerator.Current => _current;

        public void Dispose()
        {
            disposing = true;
        }

        public bool MoveNext()
        {
            if (_pos + 1 >= _data.Count)
                return false;
            
            _pos++;
            _current = _data[_pos];
            return true;
        }

        public void Reset()
        {
            _pos = -1;
        }
    }
}
