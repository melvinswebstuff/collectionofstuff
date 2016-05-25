using System;

namespace AccessModifiersLibrary
{
    public class ClassA
    {
        protected internal void MethodClassA()
        {

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
            classA.MethodClassA();
        }
    }
}