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

        public IEnumerator GetEnumerator()
        {
            return new GAEnumerator(a);
        }

        class GAEnumerator : IEnumerator
        {
            object[] a;
            int i = -1;
            public GAEnumerator(object[] a) { this.a = a; }
            public object Current
            {
                get
                {
                    return a[i];
                }
            }
            public void Reset()
            {
                i = -1;
            }
            public bool MoveNext()
            {
                do i++;
                while (i < a.Length && a[i] == null);
                if (i == a.Length)
                    return false;
                else return true;
            }
        }
    }

    class Test
    {
        public static void Main()
        {
            GrowableArray a = new GrowableArray(2);
            a[0] = 0;
            a[1] = 1;
            a[3] = 3;
            foreach (object x in a) Console.Write(" " + x);
        }
    }
}

