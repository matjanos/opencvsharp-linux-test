using OpenCvSharp;
using System;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                var test = new Mat();
                Console.WriteLine("Woooo hoooo! You managed to run OpenCVSharp here!");
            }
            catch (TypeInitializationException e)
            {
                Console.WriteLine("It still crashes... ;(");
                Console.WriteLine(e.InnerException.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Hold on! It still crashes, but an exception is different.");
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}