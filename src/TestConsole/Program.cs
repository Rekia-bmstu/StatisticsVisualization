using System;
using System.Collections.Generic;
using VectorCollection;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MathVector vector = new MathVector(-1, 0, 1);
            MathVector vector2 = new MathVector(-1, 0, 1);
            
            Console.WriteLine(vector.Equals(vector2));
        }
    }
}
