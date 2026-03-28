using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Timers;
using static G_NET_12_Adv01.Program;

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
            #region Q05
                //Q5: Write a generic method FindMax < T > that finds maximum value
                //Problem:

                //We cannot compare generic types directly.

                //Solution:

                //            Use IComparable<T> constraint.

                //            Example:
                //       public static T FindMax<T>(T a, T b) where T : IComparable<T>
                //{
                //    if (a.CompareTo(b) > 0)
                //        return a;
                //    else
                //        return b;
                //}

            #endregion
            #region Q06
                //        Q6: What is a generic interface? Write IRepository<T>.
                //    Generic interfaces define contracts with type parameters. Classes implementing them specify the actual types.

                //    Example: IRepository Pattern
                //    public interface IRepository<T> where T : class
                //            {
                //    T? GetById(int id);
                //    IEnumerable<T> GetAll();
                //    void Add(T entity);
                //    void Update(T entity);
                //    void Delete(int id);
                //}
                //Implementation
                //public class UserRepository : IRepository<User>
                //        {
                //            private readonly List<User> _users = new();

                //            public User? GetById(int id)
                //                => _users.FirstOrDefault(u => u.Id == id);

                //            public IEnumerable<User> GetAll() => _users;

                //            public void Add(User entity) => _users.Add(entity);
                //            // ... other implementations
                //        }
            #endregion
            #region Q07
                //Q7: What is the 'struct' constraint? Write an example.
                //where T : struct restricts T to value types only.Useful when you need value semantics(copy, no null).

                //public struct Nullable<T> where T : struct
                //        {
                //            private readonly bool _hasValue;
                //            private readonly T _value;

                //            public bool HasValue => _hasValue;
                //            public T Value => _hasValue ? _value
                //                : throw new InvalidOperationException();

                //            public Nullable(T value)
                //            {
                //                _hasValue = true;
                //                _value = value;
                //            }
                //        }
            #endregion
            #region Q08
                //        Q8: What is the 'class' constraint? Write an example

                //        where T : class restricts T to reference types only.This allows T to be null and enables reference comparison.

                //        public class Cache<T> where T : class
                //{
                //    private T? _cachedItem;

                //    public T? Get() => _cachedItem;

                //    public void Set(T item)
                //    {
                //        _cachedItem = item;
                //    }

                //    public void Clear()
                //    {
                //        _cachedItem = null; // ✅ Allowed because T is class
                //    }

                //    public bool IsSame(T other)
                //    {
                //        return ReferenceEquals(_cachedItem, other);
                //    }
                //}
            #endregion
            #region Q09
                //Q9: What is the 'new()' constraint? Write an example

                //where T : new () requires T to have a public parameterless constructor.This allows you to create instances of T inside the generic code.

                //    public class Factory<T> where T : new()
                //            {
                //                public T Create()
                //                {
                //                    return new T(); // ✅ Allowed because of new() constraint
                //                }

                //                public List<T> CreateMany(int count)
                //                {
                //                    var list = new List<T>();
                //                    for (int i = 0; i < count; i++)
                //                    {
                //                        list.Add(new T());
                //                    }
                //                    return list;
                //                }
                //            }
                //            public class User { public string Name { get; set; } = ""; }

                //            var factory = new Factory<User>();
                //            var users = factory.CreateMany(5); // Creates 5 User instances
                //    ⚠️ new () must be last if combining with other constraints!
            #endregion
            #region Q10
            //    Q10:  What is the interface constraint? Write an example.

            //    where T : IInterface requires T to implement a specific interface. This enables calling interface methods on type parameter.

            //public class Sorter<T> where T : IComparable<T>
            //        {
            //            public void BubbleSort(T[] array)
            //            {
            //                for (int i = 0; i < array.Length - 1; i++)
            //                {
            //                    for (int j = 0; j < array.Length - i - 1; j++)
            //                    {
            //                        // ✅ CompareTo available because of constraint
            //                        if (array[j].CompareTo(array[j + 1]) > 0)
            //                        {
            //                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
            //                        }
            //                    }
            //                }
            //            }

            //            public T FindMax(T[] array)
            //            {
            //                T max = array[0];
            //                foreach (var item in array)
            //                {
            //                    if (item.CompareTo(max) > 0) max = item;
            //                }
            //                return max;
            //            }
            //        }
        #endregion


    }
    }
}
