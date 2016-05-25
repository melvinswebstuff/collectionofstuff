using System;
using AccessModifiersLibrary;

namespace AccessModifiers
{
    //class ModifiersBase
    //{
    //    static void AAA()
    //    {
    //        Console.WriteLine("ModifiersBase AAA");
    //    }
    //    public static void BBB()
    //    {
    //        Console.WriteLine("ModifiersBase BBB");
    //    }
    //    protected static void CCC()
    //    {
    //        Console.WriteLine("ModifiersBase CCC");
    //    }
    //}

    //class ModifiersDerived : ModifiersBase
    //{
    //    public static void XXX()
    //    {
    //        //AAA();
    //        BBB();
    //        CCC();
    //    }
    //}

    //class Modifiers
    //{
    //    protected static void AAA()
    //    {
    //        Console.WriteLine("Modifiers AAA");
    //    }

    //    public static void BBB()
    //    {
    //        Console.WriteLine("Modifiers BBB");
    //        AAA();
    //    }
    //}

    class AAA
    {
        public int a;
        void MethodAAA(AAA aaa, BBB bbb)
        {
            aaa.a = 100;
            bbb.a = 200;
        }
    }
    class BBB : AAA
    {
        void MethodBBB(AAA aaa, BBB bbb)
        {
            aaa.a = 100;
            bbb.a = 200;
        }
    }
    abstract class ZZZ
    {

        public abstract void m(int a);
    }
    abstract class XXX
    {
        public abstract void m(int a);
    }
    interface YYY
    {
        void d(int a);
    }
    interface WWW
    {
        void w(int a);
    }
    class JJJ : ZZZ, WWW, YYY
    {
        public override void m(int a)
        {
            throw new NotImplementedException();
        }

        public void w(int a)
        {
            throw new NotImplementedException();
        }

        void YYY.d(int a)
        {
            throw new NotImplementedException();
        }
    }

    public class TestIndiaBix
    {
        public void TestSub<M>(M arg)
        {
            Console.Write(arg);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //ModifiersDerived.XXX();
            ClassC classC = new ClassC();
            classC.MethodClassC();
            TestIndiaBix bix = new TestIndiaBix();
            bix.TestSub("IndiaBIX ");
            bix.TestSub(4.2f);
            Console.ReadKey();


        }
    }
}