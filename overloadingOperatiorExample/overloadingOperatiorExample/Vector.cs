using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace overloadingOperatiorExample
{
    class Vector
    {
        

        public int Y { get; set; }
        public int X { get; set; }

        public Vector(int x, int y)
        {
            X = x;
            Y = y;

        }
        // without operator overloading, we can make use of the following method to add 2 vectors

        public Vector Add(Vector other)
        {
            return new Vector(X + other.X, Y + other.Y);
        }


        //overload the + to add 2 vectors

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }



        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y);
        }
    }
}
