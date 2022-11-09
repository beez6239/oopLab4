using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopLab4
{
 
    class program
   {  //Delegate and events variant 12
       
        static void Main(string[] args)
        {
            Del del = new Del();
            del.basin1.Anonymous();
            del.basin1.WaterVolume();
            del.basin1.Drainwater();
            del.basin1.Fillup();

            Console.WriteLine("Short story : A boy is 8 years old , ".ToUpper() +
            "lives in no. 23 old trafford street. zipcode: 305939\n".ToUpper());

            del.inttotal?.Invoke();
            del.stringtotal?.Invoke();
            Console.ReadLine();
        }
    }
        
    class Basin
    {
        public delegate void Basinsize(double a, double b, double c);
        public delegate void Volume(double n, double x, double y);
        public delegate void Fill();
        public delegate void Drain();


        public delegate void PoolflowHandler();
        public PoolflowHandler flow;
        public void Anonymous()
        {   // Anonymouse method
            Basinsize anonymous = (delegate (double SideA, double SideB, double SideC)
            {
                Console.WriteLine($"Basin three dimension sizes {SideA} X {SideB} X {SideC} Inches\n");               
            });
            anonymous(12.95, 12.24, 2.4);
        }
        public void WaterVolume()
        {  //Lambda expression using Func
            Func<double, double, double, double> func = (sideA, sideB, sideC) => sideA * sideB * sideC;
            Console.WriteLine("Water Volume : " + func(12.95, 12.24, 2.4)+ "cm");
            flow?.Invoke();
        }   
        public void Fillup()
        {   //Anonymouse methog
            Fill fill = (delegate { Console.WriteLine("The Basin is filled up (From anonymouse method)" ); });
            fill?.Invoke();
            flow?.Invoke();
        }

        public void Drainwater()
        {   //Lambda expression
            Drain drain = () => Console.WriteLine("Currently draining water\n".ToUpper());
            drain();
            
        }
         
    }
    
    class Del
    {
        public delegate int IntTotal();
        public delegate int StringTotal();
        public StringTotal stringtotal;
        public IntTotal inttotal;
        public readonly Basin basin1;
        public Del()
        {
           basin1 = new Basin();  
            basin1.flow += Pool;
            inttotal = digits;
            stringtotal = Strings;

        }

        private void Pool()
        {  //Event method
            Console.WriteLine("Warning !! Pool overflow from event handler\n".ToUpper());
        }

        private int Strings()
        {
            int totalstring = 0;
            string textline = ("A boy is 8 years old , " +
           "lives in no. 23 old trafford street. zipcode: 305939");
            foreach(char l in textline)
            {
                if (char.IsLetter(l))
                    totalstring++;
            }
            Console.WriteLine("Total number of string (Alphabets) in Short Story is = " + totalstring);
            return totalstring;
        }

        private int digits()
        {
            string textline = ("A boy is 8 years old , " +
           "lives in no. 23 old trafford street. zipcode: 305939");
            int intcount = 0;
            foreach(char c in textline)
            {
                if (char.IsDigit(c))
                    intcount++;
            }
            Console.WriteLine("Total number of digits (Integers) in Short Story is = " + intcount);
            return intcount;
        }
       

    }
}
