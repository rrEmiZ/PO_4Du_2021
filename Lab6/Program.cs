using System;
using System.Diagnostics;

namespace Lab6
{
    class Program
    {
        public static void zad1(string napis)
        {
            string n = String.Empty;
            //a) System.NullReferenceException
            try
            {
                n = napis.Length.ToString();
            }
            catch (NullReferenceException e)
            {
                n = $"Exception: {e}\n";
                StackTrace st = new StackTrace(true);
                for (int i = 0; i < st.FrameCount; i++)
                {
                    StackFrame sf = st.GetFrame(i);
                    Console.WriteLine($"High up the call stack, Method: {sf.GetMethod()}");
                    Console.WriteLine($"High up the call stack, Line Number: {sf.GetFileLineNumber()}");
                }
            }
            Console.WriteLine(n);
        }
        //zad2
        public static void RandomExeption()
        {

            Random rn = new Random();
            var i = rn.Next(10);
            if (i > 5)
            {
                throw new DivideByZeroException();
            }
            else if (i < 5)
            {
                throw new NullReferenceException();
            }
            else
            {
                throw new Exception();
            }


        }
        public static void zad2()
        {
            string n = String.Empty;
            try
            {
                RandomExeption();
            }
            catch (NullReferenceException e1)
            {
                n = $"Exception: {e1}\n";
            }
            catch (DivideByZeroException e2)
            {
                n = $"Exception: {e2}\n";
            }
            catch (Exception e3)
            {
                n = $"Exception: {e3}\n";
            }
            Console.WriteLine(n);

        }
        //zad3
        public static void zad3()
        {
            try
            {
            }
            catch (Exception e)
            {
            }
            /* nie mogą być obsłużone
            catch (e)
            {
            }
            catch (Exception e)
            {
            }*/
        }
        //zad4
        public class SomeClass
        {
            public void CanThrowException()
            { if (new Random().Next(5) == 0)
                    throw new Exception();
            }
        }
        public static void zad4()
        {
            SomeClass someClassObj = new SomeClass();
            try
            {
                someClassObj.CanThrowException();
                someClassObj.CanThrowException();
                someClassObj.CanThrowException();
                someClassObj.CanThrowException();
                someClassObj.CanThrowException();
            }
            catch (Exception e)
            {
                StackTrace st = new StackTrace(true);
                for (int i = 0; i < st.FrameCount; i++)
                {
                    StackFrame sf = st.GetFrame(i);
                    Console.WriteLine($"High up the call stack, Method: {sf.GetMethod()}");
                    Console.WriteLine($"High up the call stack, Line Number: {sf.GetFileLineNumber()}");
                }
                Console.WriteLine($"{e}");
            }
        }
        //zad5-6
        public class Point : ICloneable
        {
            public int X { get; set; }
            public Object Clone()
            {
                return MemberwiseClone();
            }
        }
        public static void zad5_6()
        {
            try
            {
                Point a = new Point();
                a.X = Convert.ToInt32("text");
                Point b = new Point();
                b = (Point)a.Clone();
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        static void Main(string[] args)
        {
            //zad1();
            //zad2();
            //zad4();
            zad5_6();
        }
    }
}
