using System;
using System.Collections.Generic;

namespace AccessModifiersLibrary
{
    public class ClassA
    {
        protected internal void MethodClassA()
        {
            Generic<string, int> i = new Generic<string, int>();
            i.t = 5.ToString();
            i.Add(i.t);
            foreach (var item in i.lst)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class ClassB : ClassA
    {
        protected internal void MethodClassB()
        {
            MethodClassA();
        }
    }

    public class ClassC
    {
        public void MethodClassC()
        {
            ClassA classA = new ClassA();
            ClassB classB = new ClassB();
            classA.MethodClassA();
            classB.MethodClassA();
        }
    }

    public class Generic<T, Z> {
        public T t;
        public Z z;
        public List<T> lst;
        public Generic()
        {
            lst = new List<T>();
        }
        
        public void Add(T input)
        {
            lst.Add(input);
        }
    }

}