using Microsoft.VisualBasic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Contracts;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Timers;
using static G_NET_12_Adv01.Program;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            //Q4: What is a generic method? Write Swap<T> method.

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
            #region Q11
            //        Q11: What is the base class constraint? Write an example.

            //        Restricts the type to inherit from a specific base class.

            //        Example:

            //    public class Animal { }

            //public class Example<T> where T : Animal
            //{
            //}
            #endregion
            #region Q12
            //    Q12: How do you apply multiple constraints? Write an example

            //    //                You can combine multiple constraints for a single type parameter, and have different constraints for different type parameters.

            ////Single Type Parameter with Multiple Constraints
            ////public class EntityManager<T>
            ////    where T : class, IEntity, new()
            ////        {
            ////            public T CreateAndSave()
            ////            {
            ////                var entity = new T();      // ✅ new() constraint
            ////                entity.Id = Guid.NewGuid(); // ✅ IEntity constraint
            ////                return entity;
            ////            }
            ////        }
            ////        Multiple Type Parameters with Different Constraints
            ////public class Mapper<TSource, TDest>
            ////    where TSource : class
            ////    where TDest : class, new()
            ////        {
            ////            public TDest Map(TSource source)
            ////            {
            ////                var dest = new TDest();
            ////                // Copy properties via reflection...
            ////                return dest;
            ////            }
            ////        }
            ////⚠️ Order matters: class/struct first, then interfaces, then new() last!
            #endregion
            #region Q13
            //    Q13: What does the 'default' keyword do in generics ?

            //    default(T) or default returns the default value for type T: null for reference types, 0 / false for value types.

            //public class ValueOrDefault<T>
            //        {
            //            private T? _value;
            //            private bool _hasValue;

            //            public T GetValueOrDefault()
            //            {
            //                return _hasValue ? _value! : default!;
            //            }

            //            public T GetValueOrDefault(T fallback)
            //            {
            //                return _hasValue ? _value! : fallback;
            //            }
            //        }

            //// Usage:
            //default(int)     // 0
            //default(bool)    // false
            //default(string)  // null
            //default(DateTime) // 0001-01-01
            //💡 Use default when you need to initialize or return a "zero" value without knowing the type.
            #endregion
            #region Q14
            //Q14: Write a SafeList < T > that returns default when the index is invalid.

            //    Problem:

            //    Accessing an invalid index causes errors.

            //    Solution:

            //                Return default value instead.

            //    Example:

            //using System.Collections.Generic;

            //public class SafeList<T>
            //        {
            //            private List<T> list = new List<T>();

            //            public void Add(T item)
            //            {
            //                list.Add(item);
            //            }

            //            public T Get(int index)
            //            {
            //                if (index >= 0 && index < list.Count)
            //                    return list[index];

            //                return default(T);
            //            }
            //        }
            #endregion
            #region Q15

            //Q15: What is covariance? Explain the 'out' keyword

            //   Covariance allows you to use a more derived type than originally specified.Marked with out keyword.T can only appear in output positions.

            //   Example: IEnumerable is Covariant
            //   // IEnumerable<out T> - T is covariant

            //   class Animal { }
            //           class Dog : Animal { }

            //           IEnumerable<Dog> dogs = new List<Dog> { new Dog() };

            //           // ✅ Covariance: Dog → Animal (more derived → less derived)
            //           IEnumerable<Animal> animals = dogs;
            //           Creating Your Own Covariant Interface
            //   public interface IProducer<out T>
            //           {
            //               T Produce();  // ✅ T in output position
            //                             // void Consume(T item); // ❌ Would NOT compile!
            //           }

            //           class DogProducer : IProducer<Dog>
            //           {
            //               public Dog Produce() => new Dog();
            //           }

            //           IProducer<Animal> animalProducer = new DogProducer(); // ✅ Works!
            #endregion
            #region Q16
            //Q16: What is contravariance? Explain the 'in' keyword.

            //    Contravariance allows you to use a less derived type than originally specified.Marked with in keyword.T can only appear in input positions.

            //    Example: Action is Contravariant
            //    // Action<in T> - T is contravariant

            //    class Animal { public void Eat() { } }
            //            class Dog : Animal { }

            //            Action<Animal> feedAnimal = a => a.Eat();

            //            // ✅ Contravariance: Animal → Dog (less derived → more derived)
            //            Action<Dog> feedDog = feedAnimal;

            //            feedDog(new Dog()); // Works! Dog is-an Animal
            //    Creating Your Own Contravariant Interface
            //    public interface IConsumer<in T>
            //            {
            //                void Consume(T item);  // ✅ T in input position
            //                                       // T Produce(); // ❌ Would NOT compile!
            //            }

            //            class AnimalFeeder : IConsumer<Animal>
            //            {
            //                public void Consume(Animal a) => a.Eat();
            //            }

            //            IConsumer<Dog> dogFeeder = new AnimalFeeder(); // ✅ Works!
            #endregion
            #region Q17
            //Q17: What is the difference between covariance and contravariance?

            //    Aspect Covariance(out)    Contravariance(in)
            //    Direction Derived → Base Base → Derived
            //    T Position Output only(return)	Input only(parameter)
            //    Example IEnumerable<out T>  Action<in T>
            //    Think of as Producer of T   Consumer of T
            //    💡 Memory aid: out = output = producer = covariant(child → parent)
            //    💡 Memory aid: in = input = consumer = contravariant(parent → child)
            #endregion
            #region Q18
             Q18: How do static members work in generic types ?

                //Each closed generic type has its own copy of static fields.List<int> and List<string> have separate static data!

                ////public class Counter<T>
                ////        {
                ////            public static int Count = 0;

                ////            public Counter()
                ////            {
                ////                Count++;
                ////            }
                ////        }

                ////        // Each type argument gets its own static Count!
                ////        var a1 = new Counter<int>();
                ////        var a2 = new Counter<int>();
                ////        var b1 = new Counter<string>();

                ////        Console.WriteLine(Counter<int>.Count);    // 2
                ////Console.WriteLine(Counter<string>.Count); // 1
                ////⚠️ This is a common interview question and source of bugs!
            #endregion
            #region Q19
                // Q19: How can you inherit from a generic class?

                //Generic classes can inherit from other generic or non - generic classes.Several patterns are possible.

                // Pattern 1: Inherit and Pass Type Parameter
                // public class Repository<T> { /* base */ }

                //         // Derived class is also generic
                //         public class CachedRepository<T> : Repository<T> { }
                //         Pattern 2: Inherit with Concrete Type
                // // Derived class specifies the type
                // public class UserRepository : Repository<User> { }
                //         Pattern 3: Add New Type Parameter
                // // Derived class adds more type parameters
                // public class KeyedRepository<TKey, TEntity> : Repository<TEntity> { }
            #endregion
            #region Q20
                //Q20: Complete Exercise -Create a generic Cache < TKey, TValue> with Add, Get, Remove, Contains, and expiration support.

                //using System;
                //    using System.Collections.Generic;

                //public class Cache<TKey, TValue>
                //{
                //    private Dictionary<TKey, (TValue value, DateTime expiry)> data
                //        = new Dictionary<TKey, (TValue, DateTime)>();

                //    public void Add(TKey key, TValue value, int seconds)
                //    {
                //        data[key] = (value, DateTime.Now.AddSeconds(seconds));
                //    }

                //    public TValue Get(TKey key)
                //    {
                //        if (data.ContainsKey(key))
                //        {
                //            var item = data[key];

                //            if (DateTime.Now < item.expiry)
                //                return item.value;
                //        }

                //        return default(TValue);
                //    }

                //    public void Remove(TKey key)
                //    {
                //        data.Remove(key);
                //    }

                //    public bool Contains(TKey key)
                //    {
                //        return data.ContainsKey(key);
                //    }
                //}
            #endregion



    }
    }
}
