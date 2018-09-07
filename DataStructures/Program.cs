using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        //static void ConsoleWrite(double data)
        //{
        //    Console.WriteLine(data);
        //}
        
        static void Main(string[] args)
        {
            //Action delegate
            //Action<double> print = delegate (double data){
            //    Console.WriteLine(data);
            //};


            //lemda expresion virsui esancio kodo
            //delegates
            /*Action<bool> print = d => Console.WriteLine(d);
            Func<double, double> square = d => d * d;
            //paskutinis double(paskutinis narys) reiskia return type
            Func<double, double, double> add = (x, y) => x + y;

            Predicate<double> isLessThanTen = d => d < 10;
            //Predicate<tipas> paima tipa ir returnina visada bool

            print(isLessThanTen(add(square(1.2), square(1.1))));*/


           
            
            var buffer = new CircularBuffer<double>(capacity:3);
            buffer.ItemDiscarded += ItemDiscarded;    

            ProcessInput(buffer);


            Converter<double, DateTime> converter = d => new DateTime(2018,1,1).AddDays(d);
            var asDate = buffer.Map<double, DateTime>(converter);
            foreach (var date in asDate)
            {
                Console.WriteLine(date);
            }


            Console.WriteLine("----------------------");

            //var asInt = buffer.AsEnumemerableOf<double, int>();
            ///var asInt = BufferExtensions.AsEnumemerableOf<double, int>(buffer);
           
            //foreach (var item in asInt)
            //{
                //Console.WriteLine(item);
           // }

            Console.WriteLine("----------------------");
            //buffer.Dump<double>();

            //var consoleOut = new Printer<double>(ConsoleWrite);
            //virsutinio kodo netnereikia galima consolewrite is 
            //kart i dup ideti kompiliatorius susigaudys

            //buffer.Dump<double>();
            buffer.Dump(d => Console.WriteLine(d));  //Compiliatorius pats susigaudo koks tipas turibut



            ProcessBuffer(buffer);

        }

        private static void ItemDiscarded(object sender,
            ItemDiscardedEventArgs<double> e)
        {
            Console.WriteLine($"New item {e.NewItem} added and Buffer is full! So the oldest item {e.ItemDiscarded} is discarded");
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;
            Console.WriteLine("Buffer: ");
            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }
            Console.WriteLine(sum);
        }

        private static void ProcessInput(IBuffer<double> buffer)
        {
            while (true)
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }
        }
    }
}
