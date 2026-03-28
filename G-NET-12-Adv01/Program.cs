using System.Collections;
using System.ComponentModel;
using System.Timers;

namespace G_NET_12_Adv01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q01
            //Q1: What is a generic class? Why use generics?

            //Generics allow you to define type - safe classes, interfaces, methods, and delegates without committing to a specific data type until the code is used.

            //Before generics, we had two bad choices: duplicate code for each type, or use object and lose type safety + performance.

            //Benefits of Generics
            //Benefit Description
            //Type Safety Compile-time type checking
            //Performance No boxing / unboxing for value types
            //Code Reuse  One implementation for all types
            //IntelliSense Better IDE support and discovery



            #endregion
            #region Q02
            //    Q2: Write a generic class Container<T> with Add and Get methods.

            //    A generic class uses type parameters that are replaced with actual types when you create an instance.The type parameter T acts as a placeholder.

            //    public class Stack<T>
            //{
            //    private T[] _items = new T[100];
            //    private int _count = 0;

            //    public void Push(T item)
            //    {
            //        _items[_count++] = item;
            //    }

            //    public T Pop()
            //    {
            //        return _items[--_count];
            //    }

            //    public T Peek() => _items[_count - 1];

            //    public int Count => _count;
            //}

            #endregion
            #region Q03
            //Q3: What are multiple type parameters? Write Pair<TKey, TValue>.

            //    Generic classes can have multiple type parameters.Common examples: Dictionary<TKey, TValue>, Tuple<T1, T2>
            //    Example: Generic Pair
            //        public class Pair<TFirst, TSecond>
            //                {
            //                    public TFirst First { get; set; }
            //                    public TSecond Second { get; set; }

            //                    public Pair(TFirst first, TSecond second)
            //                    {
            //                        First = first;
            //                        Second = second;
            //                    }

            //                    public void Deconstruct(out TFirst first, out TSecond second)
            //                    {
            //                        first = First;
            //                        second = Second;
            //                    }
            //                }
            #endregion
            #region Q04

             Q4: What is a generic method? Write Swap<T> method.

                    //    A generic method declares its own type parameter(s). It can exist in both generic and non-generic classes.The compiler often infers the type argument.

                    //Example: Swap Method
                    //public static class Utilities
                    //        {
                    //            public static void Swap<T>(ref T a, ref T b)
                    //            {
                    //                T temp = a;
                    //                a = b;
                    //                b = temp;
                    //            }

                    //            public static T Max<T>(T a, T b) where T : IComparable<T>
                    //            {
                    //                return a.CompareTo(b) > 0 ? a : b;
                    //            }
                    //        }
            #endregion

    }
    }
}
