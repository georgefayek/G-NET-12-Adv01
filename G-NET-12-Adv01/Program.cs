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
    }
    }
}
