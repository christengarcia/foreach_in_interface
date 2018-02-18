/*
 * C# Program to Implement for-each in Inteface
 */

using System;
using System.Collections;

namespace foreach_in_interface
{
    class GrowableArray : IEnumerable
    {
        object[] a;
        public GrowableArray(int size)
        {
            a = new object[size];
        }
        public GrowableArray() : this(8) { }
        void Grow()
        {
            object[] b = new object[2 * a.Length];
            Array.Copy(a, b, a.Length);
            a = b;
        }
        public object this[int i]
        {
            set
            {
                if (i >= a.Length) Grow();
                a[i] = value;
            }
            get
            {
                if (i >= a.Length) Grow();
                return a[i];
            }
        }
    }
}
